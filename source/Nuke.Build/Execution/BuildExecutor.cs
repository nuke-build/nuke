// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Gradually executes targets of the execution plan.
    /// Targets are skipped according to static conditions, dependency behavior, dynamic conditions and previous build attempts.
    /// </summary>
    internal static class BuildExecutor
    {
        // NOTE: no INukeBuild because of BuildAttemptFile + WriteTarget
        private static AbsolutePath BuildAttemptFile => Constants.GetBuildAttemptFile(NukeBuild.RootDirectory);

        public static void Execute(NukeBuild build, [CanBeNull] IReadOnlyCollection<string> skippedTargets)
        {
            if (skippedTargets != null)
            {
                build.ExecutionPlan
                    .Where(x => skippedTargets.Count == 0 || skippedTargets.Contains(x.Name, StringComparer.OrdinalIgnoreCase))
                    .ForEach(x => MarkTargetSkipped(build, x, reason: "via parameter"));
            }

            build.ExecutionPlan.ForEach(x => CheckConditions(build, x, x.StaticConditions));
            // .Where(x => HasSkippingCondition(x, x.StaticConditions))
            // .ForEach(x => MarkTargetSkipped(build, x));

            DelegateRequirementService.ValidateRequirements(build, build.ScheduledTargets);
            var previouslyExecutedTargets = UpdateInvocationHash(build);

            BuildManager.CancellationHandler += ExecuteAssuredTargets;

            try
            {
                build.ExecutionPlan.ForEach(x => Execute(build, x, previouslyExecutedTargets));
            }
            catch
            {
                ExecuteAssuredTargets();
                throw;
            }

            void ExecuteAssuredTargets()
            {
                var assuredScheduledTargets = build.ExecutionPlan.Where(x => x.AssuredAfterFailure && x.Status == ExecutionStatus.Scheduled);
                assuredScheduledTargets.ForEach(x => Execute(build, x, previouslyExecutedTargets, failureMode: true));
            }
        }

        private static IReadOnlyCollection<string> UpdateInvocationHash(NukeBuild build)
        {
            var continueParameterName = ParameterService.GetParameterMemberName(() => build.Continue);
            var invocation = EnvironmentInfo.CommandLineArguments
                .Where(x => !x.StartsWith("-") || x.TrimStart("-").EqualsOrdinalIgnoreCase(continueParameterName))
                .JoinSpace();
            var invocationHash = invocation.GetMD5Hash();

            IReadOnlyCollection<string> GetPreviouslyExecutedTargets()
            {
                if (!build.Continue || !BuildAttemptFile.Exists())
                    return new string[0];

                var previousBuild = BuildAttemptFile.ReadAllLines();
                if (previousBuild.FirstOrDefault() != invocationHash)
                {
                    Log.Warning("Build invocation changed. Restarting ...");
                    return new string[0];
                }

                return previousBuild.Skip(1).ToArray();
            }

            var previouslyExecutedTargets = GetPreviouslyExecutedTargets();
            BuildAttemptFile.WriteAllLines(new[] { invocationHash }.Concat(previouslyExecutedTargets));
            return previouslyExecutedTargets;
        }

        private static void Execute(
            NukeBuild build,
            ExecutableTarget target,
            IReadOnlyCollection<string> previouslyExecutedTargets,
            bool failureMode = false)
        {
            if (target.Status == ExecutionStatus.Skipped ||
                previouslyExecutedTargets.Contains(target.Name) ||
                CheckConditions(build, target, target.DynamicConditions))
            {
                target.Status = ExecutionStatus.Skipped;
                build.ExecuteExtension<IOnTargetSkipped>(x => x.OnTargetSkipped(target));
                return;
            }

            if (target.Actions.Count == 0)
            {
                target.Status = ExecutionStatus.Collective;
                return;
            }

            using (Logging.SetTarget(target.Name))
            using (build.WriteTarget(target.Name))
            {
                target.Stopwatch.Start();
                target.Status = ExecutionStatus.Running;
                build.ExecuteExtension<IOnTargetRunning>(x => x.OnTargetRunning(target));
                try
                {
                    if (target.Intercept == null || !target.Intercept.Invoke())
                        target.Actions.ForEach(x => x());

                    target.Stopwatch.Stop();
                    target.Status = ExecutionStatus.Succeeded;
                    build.ExecuteExtension<IOnTargetSucceeded>(x => x.OnTargetSucceeded(target));

                    AppendToBuildAttemptFile(target.Name);
                }
                catch (Exception exception)
                {
                    exception = exception.Unwrap();
                    if (!target.SummaryInformation.Any())
                    {
                        build.ReportSummary(
                            target,
                            _ => _.AddPair(exception.GetType().Name, exception.Message.SplitLineBreaks().First()));
                    }

                    Log.Error(exception, "Target {TargetName} has thrown an exception", target.Name);

                    target.Stopwatch.Stop();
                    target.Status = ExecutionStatus.Failed;
                    build.ExecuteExtension<IOnTargetFailed>(x => x.OnTargetFailed(target));

                    if (!target.ProceedAfterFailure && !failureMode)
                        throw new TargetExecutionException(target.Name, exception);
                }
            }
        }

        private static bool CheckConditions(INukeBuild build, ExecutableTarget target, IEnumerable<(string Text, Func<bool> Delegate)> conditions)
        {
            string Format(string condition)
                => condition
                    .TrimStart('(').Trim()
                    .TrimStart(')').Trim()
                    .TrimStart('=').Trim()
                    .TrimStart('>').Trim();

            try
            {
                var violatedConditions = conditions
                    .Where(x => !x.Delegate.Invoke())
                    .Select(x => x.Text)
                    .Select(Format).ToList();

                if (violatedConditions.Count > 0)
                {
                    target.OnlyWhen = violatedConditions.Join(" && ");
                    MarkTargetSkipped(build, target);
                }
            }
            catch (Exception exception)
            {
                exception = exception.Unwrap();
                Log.Error(exception, "Invocation of condition for {TargetName} has thrown an exception", target.Name);
                throw new TargetExecutionException(target.Name, exception);
            }

            return target.OnlyWhen != null;
        }

        private static void MarkTargetSkipped(INukeBuild build, ExecutableTarget target, string reason = null)
        {
            if (target.Invoked || target.Status != ExecutionStatus.Scheduled)
                return;

            target.Status = ExecutionStatus.Skipped;
            target.Skipped ??= reason;

            if (target.DependencyBehavior == DependencyBehavior.Execute)
                return;

            bool HasOtherDependencies(ExecutableTarget dependentTarget)
                => build.ExecutionPlan
                    .Where(x => x.Status == ExecutionStatus.Scheduled)
                    .Any(x => x.ExecutionDependencies.Contains(dependentTarget) || x.Triggers.Contains(dependentTarget));

            var skippableTargets = target.ExecutionDependencies.Concat(target.Triggers)
                .Where(x => !HasOtherDependencies(x)).ToList();
            skippableTargets.ForEach(x => MarkTargetSkipped(build, x, $"because of {target.Name}"));
        }

        private static void AppendToBuildAttemptFile(string value)
        {
            File.AppendAllLines(BuildAttemptFile, new[] { value });
        }
    }
}
