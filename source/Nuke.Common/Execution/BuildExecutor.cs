// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal static class BuildExecutor
    {
        private static PathConstruction.AbsolutePath BuildAttemptFile => Constants.GetBuildAttemptFile(NukeBuild.RootDirectory);

        public static void Execute(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executionPlan,
            [CanBeNull] IReadOnlyCollection<string> skippedTargets)
        {
            var invocationHash = GetInvocationHash();
            var previouslyExecutedTargets = GetPreviouslyExecutedTargets(invocationHash);
            File.WriteAllLines(BuildAttemptFile, new[] { invocationHash });
            
            if (skippedTargets != null)
            {
                NukeBuild.ExecutionPlan
                    .Where(x => !NukeBuild.InvokedTargets.Contains(x.Name))
                    .Where(x => skippedTargets.Count == 0 || skippedTargets.Contains(x.Name, StringComparer.OrdinalIgnoreCase))
                    .ForEach(x => x.Status = ExecutionStatus.Skipped);
            }
            
            foreach (var target in executionPlan)
            {
                if (target.Status == ExecutionStatus.Skipped ||
                    previouslyExecutedTargets.Contains(target.Name) ||
                    target.Conditions.Any(x => !x()))
                {
                    target.Status = ExecutionStatus.Skipped;
                    build.OnTargetSkipped(target.Name);
                    AppendToBuildAttemptFile(target.Name);
                    continue;
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
                    catch
                    {
                        target.Status = ExecutionStatus.Failed;
                        build.OnTargetFailed(target.Name);
                        throw;
                    }
                    finally
                    {
                        target.Duration = stopwatch.Elapsed;
                    }
                }
            }
        }

        private static string GetInvocationHash()
        {
            var continueParameterName = ParameterService.Instance.GetParameterName(() => NukeBuild.Continue);
            var invocation = EnvironmentInfo.CommandLineArguments
                .Where(x => !x.StartsWith("-") || x.TrimStart("-").EqualsOrdinalIgnoreCase(continueParameterName))
                .JoinSpace();
            return invocation.GetMD5Hash();
        }
        
        private static IReadOnlyCollection<string> GetPreviouslyExecutedTargets(string invocationHash)
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

        private static void AppendToBuildAttemptFile(string value)
        {
            File.AppendAllLines(BuildAttemptFile, new[] { value });
        }
    }
}
