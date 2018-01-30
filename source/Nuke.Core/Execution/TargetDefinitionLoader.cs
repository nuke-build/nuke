// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuke.Core.Utilities;

namespace Nuke.Core.Execution
{
    internal static class TargetDefinitionLoader
    {
        public static IReadOnlyCollection<TargetDefinition> GetExecutionList (NukeBuild build)
        {
            ControlFlow.Assert(build.TargetDefinitions.All(x => !x.Name.EqualsOrdinalIgnoreCase("default")),
                    "The name 'default' cannot be used as target name.");

            var specifiedTargets = build.InvokedTargets.Select(x => GetDefinition(x, build)).ToList();
            return GetSortedList(build, specifiedTargets);
        }
        
        private static TargetDefinition GetDefinition (
                string targetName,
                NukeBuild build)
        {
            if (targetName.EqualsOrdinalIgnoreCase("default"))
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
        
        private static List<TargetDefinition> GetSortedList (NukeBuild build, IReadOnlyCollection<TargetDefinition> specifiedTargets)
        {
            var vertexDictionary = build.TargetDefinitions.ToDictionary(x => x, x => new Vertex<TargetDefinition>(x));
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
