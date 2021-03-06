// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Gradually executes targets of the execution plan.
    /// Targets are skipped according to static conditions, dependency behavior, dynamic conditions and previous build attempts.
    /// </summary>
    internal static class BuildExecutor
    {
        private static AbsolutePath BuildAttemptFile => Constants.GetBuildAttemptFile(NukeBuild.RootDirectory);

        public static void Execute(NukeBuild build, [CanBeNull] IReadOnlyCollection<string> skippedTargets)
        {
            MarkSkippedTargets(build, skippedTargets);
            RequirementService.ValidateRequirements(build, build.ExecutingTargets.ToList());
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
                var assuredTargets = build.ExecutionPlan.Where(x => x.AssuredAfterFailure && x.Status == ExecutionStatus.NotRun);
                assuredTargets.ForEach(x => Execute(build, x, previouslyExecutedTargets, failureMode: true));
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
                if (!build.Continue ||
                    !File.Exists(BuildAttemptFile))
                    return new string[0];

                var previousBuild = File.ReadAllLines(BuildAttemptFile);
                if (previousBuild.FirstOrDefault() != invocationHash)
                {
                    Logger.Warn("Build invocation changed. Starting over...");
                    return new string[0];
                }

                return previousBuild.Skip(1).ToArray();
            }

            var previouslyExecutedTargets = GetPreviouslyExecutedTargets();
            File.WriteAllLines(BuildAttemptFile, new[] { invocationHash });
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
                HasSkippingCondition(target, target.DynamicConditions))
            {
                target.Status = ExecutionStatus.Skipped;
                build.ExecuteExtension<IOnTargetSkipped>(x => x.OnTargetSkipped(build, target));
                build.OnTargetSkipped(target.Name);
                AppendToBuildAttemptFile(target.Name);
                return;
            }

            if (target.Actions.Count == 0)
            {
                target.Status = ExecutionStatus.Collective;
                return;
            }

            using (Logger.Block(target.Name))
            {
                target.Status = ExecutionStatus.Running;
                build.ExecuteExtension<IOnTargetStart>(x => x.OnTargetStart(build, target));
                build.OnTargetStart(target.Name);
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    target.Actions.ForEach(x => x());
                    target.Status = ExecutionStatus.Succeeded;
                    build.ExecuteExtension<IOnTargetSucceeded>(x => x.OnTargetSucceeded(build, target));
                    build.OnTargetSucceeded(target.Name);
                    AppendToBuildAttemptFile(target.Name);
                }
                catch (Exception exception)
                {
                    build.ReportSummary(_ =>
                        target.SummaryInformation.Any()
                            ? target.SummaryInformation
                            : _.AddPair(exception.GetType().Name, exception.Message));

                    Logger.Error(exception);
                    target.Status = ExecutionStatus.Failed;

                    build.ExecuteExtension<IOnTargetFailed>(x => x.OnTargetFailed(build, target));
                    build.OnTargetFailed(target.Name);
                    if (!target.ProceedAfterFailure && !failureMode)
                        throw new TargetExecutionException(target.Name, exception);
                }
                finally
                {
                    target.Duration = stopwatch.Elapsed;
                }
            }
        }

        private static void MarkSkippedTargets(NukeBuild build, IReadOnlyCollection<string> skippedTargets)
        {
            void MarkTargetSkipped(ExecutableTarget target, string reason = null)
            {
                if (target.Invoked)
                    return;

                target.Status = ExecutionStatus.Skipped;
                target.SkipReason ??= reason;

                if (target.DependencyBehavior == DependencyBehavior.Execute)
                    return;

                target.ExecutionDependencies.ForEach(TryMarkTargetSkipped);
                target.Triggers.ForEach(TryMarkTargetSkipped);

                void TryMarkTargetSkipped(ExecutableTarget dependentTarget)
                {
                    var executingTargets = build.ExecutionPlan.Where(x => x.Status == ExecutionStatus.NotRun);
                    if (executingTargets.Any(x => x.ExecutionDependencies.Contains(dependentTarget) || x.Triggers.Contains(dependentTarget)))
                        return;

                    MarkTargetSkipped(dependentTarget, reason: $"skipping {target.Name}");
                }
            }

            if (skippedTargets != null)
            {
                build.ExecutionPlan
                    .Where(x => skippedTargets.Count == 0 || skippedTargets.Contains(x.Name, StringComparer.OrdinalIgnoreCase))
                    .ForEach(x => MarkTargetSkipped(x, reason: "via --skip parameter"));
            }

            build.ExecutionPlan
                .Where(x => HasSkippingCondition(x, x.StaticConditions))
                .ForEach(x => MarkTargetSkipped(x));
        }

        private static bool HasSkippingCondition(ExecutableTarget target, IEnumerable<Expression<Func<bool>>> conditions)
        {
            // TODO: trim outer parenthesis
            static string GetSkipReason(Expression<Func<bool>> condition) =>
                condition.Body.ToString()
                    .Replace("False", "false")
                    .Replace("True", "true")
                    .Replace("OrElse", "||")
                    .Replace("AndAlso", "&&")
                    // TODO: should get actual build type name
                    .Replace("value(Build).", string.Empty);

            foreach (var condition in conditions)
            {
                if (!condition.Compile().Invoke())
                    target.SkipReason = GetSkipReason(condition);
            }

            return target.SkipReason != null;
        }

        private static void AppendToBuildAttemptFile(string value)
        {
            File.AppendAllLines(BuildAttemptFile, new[] { value });
        }
    }
}
