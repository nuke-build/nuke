using JetBrains.Annotations;
using Nuke.Common.Logging;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuke.Common.Execution.Orchestration.Sequential
{
    public static class SequentialBuildExecutor
    {
        public static void Execute(NukeBuild build)
        {
            var previouslyExecutedTargets = TargetExecutor.UpdateInvocationHash();

            BuildManager.CancellationHandler += () => ExecuteAssuredTargets(build, previouslyExecutedTargets);

            try
            {
                var executionItem = build.ExecutionPlan.ExecutionItems.Single();
                executionItem.Logger = LoggerProvider.GetCurrentLogger();
                TargetExecutor.ExecuteItem(build, executionItem, previouslyExecutedTargets);
            }
            catch
            {
                ExecuteAssuredTargets(build, previouslyExecutedTargets);
                throw;
            }
        }

        internal static void ExecuteAssuredTargets(NukeBuild build, IReadOnlyCollection<string> previouslyExecutedTargets)
        {
            var assuredTargets = build.ExecutionPlan.AllExecutionTargets.Where(x => x.AssuredAfterFailure && x.Status == ExecutionStatus.NotRun);
            assuredTargets.ForEach(x => TargetExecutor.Execute(build, x, previouslyExecutedTargets, failureMode: true));
        }
    }
}
