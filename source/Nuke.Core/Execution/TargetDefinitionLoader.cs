// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    internal static class TargetDefinitionLoader
    {
        public static IReadOnlyCollection<TargetDefinition> GetExecutionList (NukeBuild build, Target defaultTarget)
        {
            var allTargets = build.GetTargetDefinitions();

            ControlFlow.Assert(allTargets.All(x => x.Name != "default"), "The name 'default' cannot be used as target identifier.");
            var specifiedTargets = build.Target.Select(x => GetTargetByName(x, defaultTarget, allTargets)).ToList();

            return GetSortedList(specifiedTargets, allTargets);
        }

        private static TargetDefinition GetTargetByName (string targetName, Target defaultTarget, IReadOnlyCollection<TargetDefinition> targetDefinitions)
        {
            if (targetName == "default")
                return targetDefinitions.Single(x => x.Factory == defaultTarget);

            var targetDefinition = targetDefinitions.SingleOrDefault(x => x.Name.Equals(targetName, StringComparison.OrdinalIgnoreCase));
            if (targetDefinition == null)
            {
                var stringBuilder = new StringBuilder()
                        .AppendLine($"Target with name '{targetName}' does not exist.")
                        .AppendLine("Available targets are:");
                targetDefinitions
                        .OrderBy(x => x.Name, StringComparer.OrdinalIgnoreCase)
                        .ForEach(x => stringBuilder.AppendLine($"  - {x.Name}{(x.Factory == defaultTarget ? " (default)" : string.Empty)}"));

                ControlFlow.Fail(stringBuilder.ToString());
            }

            return targetDefinition;
        }
        
        private static List<TargetDefinition> GetSortedList (
            IReadOnlyCollection<TargetDefinition> specifiedTargets,
            IReadOnlyCollection<TargetDefinition> allTargets)
        {
            var vertexDictionary = allTargets.ToDictionary(x => x, x => new Vertex<TargetDefinition>(x));
            foreach (var pair in vertexDictionary)
                pair.Value.Dependencies = pair.Key.TargetDefinitionDependencies.Select(x => vertexDictionary[x]).ToList();

            var graphAsList = vertexDictionary.Values.ToList();
            var result = new List<TargetDefinition>();

            while (graphAsList.Any())
            {
                var independents = graphAsList.Where(x => !graphAsList.Any(y => y.Dependencies.Contains(x))).ToList();
                if (EnvironmentInfo.ArgumentSwitch("strict") && independents.Count > 1)
                {
                    ControlFlow.Fail(
                        new[] { "Incomplete target definition order." }
                                .Concat(independents.Select(x => $"  - {x.Value.Name}"))
                                .Join(Environment.NewLine));
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
                                .Join(Environment.NewLine));
                }

                graphAsList.Remove(independent);

                var targetDefinition = independent.Value;
                var executableDependency = result.SelectMany(x => x.TargetDefinitionDependencies).Contains(targetDefinition)
                                           && !EnvironmentInfo.ArgumentSwitch("nodeps");
                if (specifiedTargets.Contains(targetDefinition) || executableDependency)
                    result.Add(targetDefinition);
            }

            result.Reverse();
            return result;
        }
    }
}
