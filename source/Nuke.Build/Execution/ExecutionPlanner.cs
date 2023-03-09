// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NuGet.Packaging;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Given the invoked target names, creates an execution plan under consideration of execution, ordering and trigger dependencies.
    /// </summary>
    internal static class ExecutionPlanner
    {
        public static IReadOnlyCollection<ExecutableTarget> GetExecutionPlan(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            [CanBeNull] IReadOnlyCollection<string> invokedTargetNames)
        {
            var invokedTargets = invokedTargetNames?.Select(x => GetExecutableTarget(x, executableTargets)).ToList() ??
                                 executableTargets.Where(x => x.IsDefault).ToList();
            invokedTargets.ForEach(x => x.Invoked = true);

            // Repeat to create the plan with triggers taken into account until plan doesn't change
            IReadOnlyCollection<ExecutableTarget> executionPlan;
            IReadOnlyCollection<ExecutableTarget> additionallyTriggered;
            do
            {
                executionPlan = GetExecutionPlanInternal(executableTargets, invokedTargets);
                additionallyTriggered = executionPlan
                    .SelectMany(x => x.Triggers)
                    .Except(executionPlan)
                    .Where(executableTargets.Contains).ToList();
                invokedTargets = executionPlan.Concat(additionallyTriggered).ToList();
            } while (additionallyTriggered.Count > 0);

            return executionPlan.ForEachLazy(x => x.Status = ExecutionStatus.Scheduled).ToList();
        }

        private static IReadOnlyCollection<ExecutableTarget> GetExecutionPlanInternal(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            ICollection<ExecutableTarget> invokedTargets)
        {
            var vertexDictionary = GetVertexDictionary(executableTargets);
            var graphAsList = vertexDictionary.Values.ToList();
            var scheduledTargets = new List<ExecutableTarget>();

            var scc = new StronglyConnectedComponentFinder<ExecutableTarget>();
            var cycles = scc.DetectCycle(graphAsList).Cycles().ToList();
            if (cycles.Count > 0)
            {
                // TODO: logging additional
                Assert.Fail("Circular dependencies between targets:"
                    .Concat(cycles.Select(x => $" - {x.Select(y => y.Value.Name).JoinCommaSpace()}"))
                    .JoinNewLine());
            }

            while (graphAsList.Any())
            {
                var independents = graphAsList.Where(x => !graphAsList.Any(y => y.Dependencies.Contains(x))).ToList();
                if (ParameterService.GetNamedArgument<bool>("strict") && independents.Count > 1)
                {
                    // TODO: logging additional
                    Assert.Fail("Incomplete target definition order:"
                        .Concat(independents.Select(x => $"  - {x.Value.Name}"))
                        .JoinNewLine());
                }

                var independent = independents.First();
                graphAsList.Remove(independent);

                var executableTarget = independent.Value;
                if (!invokedTargets.Contains(executableTarget) &&
                    !scheduledTargets.SelectMany(x => x.ExecutionDependencies).Contains(executableTarget))
                    continue;

                scheduledTargets.Add(executableTarget);
            }

            scheduledTargets.Reverse();

            return scheduledTargets;
        }

        private static IReadOnlyDictionary<ExecutableTarget, Vertex<ExecutableTarget>> GetVertexDictionary(
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var vertexDictionary = executableTargets.ToDictionary(x => x, x => new Vertex<ExecutableTarget>(x));
            foreach (var (executable, vertex) in vertexDictionary)
                vertex.Dependencies.AddRange(executable.AllDependencies.Select(x => vertexDictionary.GetValueOrDefault(x)).WhereNotNull());

            return vertexDictionary;
        }

        private static ExecutableTarget GetExecutableTarget(
            string targetName,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            targetName = targetName.Replace("-", string.Empty);
            var executableTarget = executableTargets.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(targetName));
            if (executableTarget == null)
            {
                Assert.Fail($"Target with name {targetName.SingleQuote()} does not exist. Available targets are:"
                    .Concat(executableTargets.Select(x => $"  - {x.Name}").OrderBy(x => x))
                    .JoinNewLine());
            }

            return executableTarget;
        }
    }
}
