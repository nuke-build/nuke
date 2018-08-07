// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    internal static class TargetDefinitionLoader
    {
        public static IReadOnlyCollection<TargetDefinition> GetExecutingTargets(NukeBuild build, [CanBeNull] string[] invokedTargetNames = null)
        {
            ControlFlow.Assert(build.TargetDefinitions.All(x => !x.Name.EqualsOrdinalIgnoreCase(BuildExecutor.DefaultTarget)),
                $"The name '{BuildExecutor.DefaultTarget}' cannot be used as target name.");

            var invokedTargets = invokedTargetNames?.Select(x => GetDefinition(x, build)).ToList() ?? new List<TargetDefinition>();
            var executingTargets = GetUnfilteredExecutingTargets(build, invokedTargets);

            var skippedTargets = executingTargets
                .Where(x => !invokedTargets.Contains(x) &&
                            build.SkippedTargets != null &&
                            (build.SkippedTargets.Length == 0 ||
                             build.SkippedTargets.Contains(x.Name, StringComparer.OrdinalIgnoreCase))).ToList();
            skippedTargets.ForEach(x => x.Skip = true);
            executingTargets
                .Where(x => x.DependencyBehavior == DependencyBehavior.Skip)
                .Where(x => x.Conditions.Any(y => !y()))
                .ForEach(x => SkipTargetAndDependencies(x, invokedTargets, executingTargets));

            string[] GetNames(IEnumerable<TargetDefinition> targets)
                => targets.Select(x => x.Name).ToArray();

            ReflectionService.SetValue(build, nameof(NukeBuild.InvokedTargets), GetNames(invokedTargets));
            ReflectionService.SetValue(build, nameof(NukeBuild.SkippedTargets), GetNames(skippedTargets));
            ReflectionService.SetValue(build, nameof(NukeBuild.ExecutingTargets), GetNames(executingTargets.Except(skippedTargets)));

            return executingTargets;
        }

        private static void SkipTargetAndDependencies(
            TargetDefinition targetDefinition,
            IReadOnlyCollection<TargetDefinition> invokedTargets,
            IReadOnlyCollection<TargetDefinition> executingTargets,
            IDictionary<TargetDefinition, List<TargetDefinition>> skipRequestDictionary = null)
        {
            skipRequestDictionary = skipRequestDictionary ?? new Dictionary<TargetDefinition, List<TargetDefinition>>();

            targetDefinition.Skip = true;
            foreach (var dependency in targetDefinition.TargetDefinitionDependencies)
            {
                if (invokedTargets.Contains(dependency))
                    continue;

                var skipRequests = skipRequestDictionary.GetValueOrDefault(dependency);
                if (skipRequests == null)
                    skipRequests = skipRequestDictionary[dependency] = new List<TargetDefinition>();

                var executingDependentTargets = executingTargets
                    .Where(x => x != targetDefinition)
                    .Where(x => x.TargetDefinitionDependencies.Contains(dependency) && !skipRequests.Contains(x));

                if (executingDependentTargets.Any())
                    skipRequests.Add(targetDefinition);
                else
                    SkipTargetAndDependencies(dependency, invokedTargets, executingTargets, skipRequestDictionary);
            }
        }

        private static TargetDefinition GetDefinition(
            string targetName,
            NukeBuild build)
        {
            if (targetName.EqualsOrdinalIgnoreCase(BuildExecutor.DefaultTarget))
                return build.TargetDefinitions.Single(x => x.IsDefault);

            var targetDefinition = build.TargetDefinitions.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(targetName));
            if (targetDefinition == null)
            {
                var stringBuilder = new StringBuilder()
                    .AppendLine($"Target with name '{targetName}' is not available.")
                    .AppendLine()
                    .AppendLine(HelpTextService.GetTargetsText(build));

                ControlFlow.Fail(stringBuilder.ToString());
            }

            return targetDefinition;
        }

        private static List<TargetDefinition> GetUnfilteredExecutingTargets(NukeBuild build, IReadOnlyCollection<TargetDefinition> invokedTargets)
        {
            var vertexDictionary = build.TargetDefinitions.ToDictionary(x => x, x => new Vertex<TargetDefinition>(x));
            foreach (var pair in vertexDictionary)
                pair.Value.Dependencies = pair.Key.TargetDefinitionDependencies.Select(x => vertexDictionary[x]).ToList();

            var graphAsList = vertexDictionary.Values.ToList();
            var executingTargets = new List<TargetDefinition>();

            while (graphAsList.Any())
            {
                var independents = graphAsList.Where(x => !graphAsList.Any(y => y.Dependencies.Contains(x))).ToList();
                if (EnvironmentInfo.ArgumentSwitch("strict") && independents.Count > 1)
                {
                    ControlFlow.Fail(
                        new[] { "Incomplete target definition order." }
                            .Concat(independents.Select(x => $"  - {x.Value.Name}"))
                            .JoinNewLine());
                }

                var independent = independents.FirstOrDefault();
                if (independent == null)
                {
                    var scc = new StronglyConnectedComponentFinder<TargetDefinition>();
                    var cycles = scc.DetectCycle(graphAsList)
                        .Cycles()
                        .Select(x => string.Join(" -> ", x.Select(y => y.Value.Name)));

                    ControlFlow.Fail(
                        new[] { "Circular dependencies between target definitions." }
                            .Concat(independents.Select(x => $"  - {cycles}"))
                            .JoinNewLine());
                }

                graphAsList.Remove(independent);

                var targetDefinition = independent.Value;
                var factoryDependencies = executingTargets.SelectMany(x => x.FactoryDependencies);
                var nameDependencies = executingTargets.SelectMany(x => x.NamedDependencies);
                if (!invokedTargets.Contains(targetDefinition) &&
                    !(factoryDependencies.Contains(targetDefinition.Factory) || nameDependencies.Contains(targetDefinition.Name)))
                    continue;

                executingTargets.Add(targetDefinition);
            }

            executingTargets.Reverse();

            return executingTargets;
        }
    }
}
