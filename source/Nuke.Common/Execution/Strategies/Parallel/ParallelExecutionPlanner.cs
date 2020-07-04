using JetBrains.Annotations;
using Nuke.Common.Execution.Strategies.Sequential;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuke.Common.Execution.Strategies.Parallel
{
    public static class ParallelExecutionPlanner
    {
        /// <summary>
        /// Removes top level dependencies from targets which already are dependencies downstream.
        /// Goal is to have a clean directed graph with only direct dependencies.
        /// </summary>
        private static void CleanUpDependencies(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            foreach (var target in executableTargets)
            {
                // Build flattened list of all dependencies. If a direct dependency is part of this list, remove it.
                var remove = target.ExecutionDependencies
                    .Where(x => target.ExecutionDependencies
                        .Except(new[] { x })
                        .Flatten(x => x.ExecutionDependencies)
                        .Contains(x)
                    ).ToList();

                remove.ForEach(x => target.ExecutionDependencies.Remove(x));
            }
        }

        /// <summary>
        /// Creates a parallel execution plan by clustering independent sequences of targets, and connecting them as a graph.
        /// </summary>
        public static ExecutionPlan GetParallelExecutionPlan(
           IReadOnlyCollection<ExecutableTarget> executableTargets,
           [CanBeNull] IReadOnlyCollection<string> invokedTargetNames)
        {
            var orderedTargets = SequentialExecutionPlanner.GetExecutionPlan(executableTargets, invokedTargetNames)
                .AllExecutionTargets
                .ToList();
            CleanUpDependencies(orderedTargets);

            var targetsToProcess = orderedTargets.ToList();
            targetsToProcess.Reverse();

            var executionItems = new List<ExecutionItem>();

            // Begin with the target which would be last executed
            // i.e. "near" the invoked targets (or its triggered targets)
            do
            {
                // process the next target in line
                var target = targetsToProcess.First();
                targetsToProcess.Remove(target);

                var executionItem = new ExecutionItem();
                executionItem.Targets.Push(target);

                // Now try to take as many single-dependency targets as possible.
                // These will need to be executed sequentially
                var current = target;
                while (current.AllDependencies.Distinct().Count() == 1)
                {
                    var dependency = current.AllDependencies.First();

                    // If any target in the execution plan apart from the current also has the same dependency, 
                    // we can't include it in the sequence. It is no longer a single-dependency.
                    if (orderedTargets.Any(x => x != current && x.AllDependencies.Contains(dependency)))
                        break;

                    executionItem.Targets.Push(dependency);
                    targetsToProcess.Remove(dependency);
                    current = dependency;
                }

                executionItems.Add(executionItem);
            } while (targetsToProcess.Any());

            // We have built the clusters
            // Now connect them, so we can traverse it later in parallel execution
            foreach (var item in executionItems)
            {
                var top = item.Targets.Peek();

                // the dependencies of this item are those of the top (= first to execute) target in the execution stack.
                // so just look for the item which contains this target.
                item.Dependencies = executionItems.Where(x => top.AllDependencies.Any(y => x.Targets.Contains(y))).ToList();
            }

            return new ExecutionPlan(executionItems, orderedTargets);
        }
    }
}
