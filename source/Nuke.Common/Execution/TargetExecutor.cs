// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Gradually executes targets of the execution plan.
    /// Targets are skipped according to static conditions, dependency behavior, dynamic conditions and previous build attempts.
    /// </summary>
    internal static class TargetExecutor
    {
        private static Mutex BuildAttemptFileLock = new Mutex();

        private static AbsolutePath BuildAttemptFile => Constants.GetBuildAttemptFile(NukeBuild.RootDirectory);

        public static IReadOnlyCollection<string> UpdateInvocationHash()
        {
            var continueParameterName = ParameterService.GetParameterMemberName(() => NukeBuild.Continue);
            var invocation = EnvironmentInfo.CommandLineArguments
                .Where(x => !x.StartsWith("-") || x.TrimStart("-").EqualsOrdinalIgnoreCase(continueParameterName))
                .JoinSpace();
            var invocationHash = invocation.GetMD5Hash();

            IReadOnlyCollection<string> GetPreviouslyExecutedTargets()
            {
                if (!NukeBuild.Continue ||
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

        internal static void ExecuteItem(
            NukeBuild build,
            ExecutionItem item,
            IReadOnlyCollection<string> previouslyExecutedTargets,
            CancellationToken? cancellationToken = null)
        {
            // Hook into status changed events
            item.StartWatchProgress();

            var workStack = new Stack<ExecutableTarget>(item.Targets.Reverse());

            while (workStack.Count > 0)
            {
                if (cancellationToken?.IsCancellationRequested == true)
                    break;

                var target = workStack.Pop();
                Execute(build, target, previouslyExecutedTargets);
            }

            // Signal finished work
            item.WorkFinished();
        }

        public static void Execute(
            NukeBuild build,
            ExecutableTarget target,
            IReadOnlyCollection<string> previouslyExecutedTargets,
            bool failureMode = false)
        {
            if (target.Status == ExecutionStatus.Skipped ||
                previouslyExecutedTargets.Contains(target.Name) ||
                RunConditionEvaluator.HasSkippingCondition(target, target.DynamicConditions))
            {
                target.Status = ExecutionStatus.Skipped;
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
                target.Status = ExecutionStatus.Executing;
                build.OnTargetStart(target.Name);
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    target.Actions.ForEach(x => x());
                    target.Status = ExecutionStatus.Executed;
                    build.OnTargetExecuted(target.Name);
                    AppendToBuildAttemptFile(target.Name);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    target.Status = ExecutionStatus.Failed;
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

        private static void AppendToBuildAttemptFile(string value)
        {
            BuildAttemptFileLock.WaitOne();
            File.AppendAllLines(BuildAttemptFile, new[] { value });
            BuildAttemptFileLock.ReleaseMutex();
        }
    }
}
