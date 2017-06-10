// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Nuke.Core.Output;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Execution
{
    internal class TargetDefinitionLoader
    {
        public IReadOnlyCollection<TargetDefinition> GetExecutionList (Build build, Target defaultTarget)
        {
            var targetDefinitions = build.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.PropertyType == typeof(Target))
                    .Select(x => LoadTargetDefinition(build, x))
                    .ToList();
            var nameDictionary = targetDefinitions.ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);
            var factoryDictionary = targetDefinitions.ToDictionary(x => x.Factory, x => x);

            ControlFlow.Assert(!nameDictionary.ContainsKey("default"), "Don't use 'default' as a target identifier.");
            nameDictionary.Add("default", nameDictionary.Values.Single(x => x.Factory == defaultTarget));
            var targetTargets = build.Targets.Select(x => GetTargetByName(x, defaultTarget, nameDictionary)).ToList();

            var targetDependencies = targetDefinitions.ToDictionary(
                x => x,
                x => GetDependencies(x, nameDictionary, factoryDictionary).ToList());
            return GetSortedList(targetTargets, targetDependencies);
        }

        private static TargetDefinition GetTargetByName (string targetName, Target defaultTarget, Dictionary<string, TargetDefinition> nameDictionary)
        {
            if (nameDictionary.TryGetValue(targetName, out var targetDefinition))
                return targetDefinition;

            var stringBuilder = new StringBuilder()
                    .AppendLine($"Target with name '{targetName}' does not exist.")
                    .AppendLine("Available targets are:");
            nameDictionary
                    .Where(x => !x.Key.Equals("default", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                    .ForEach(x => stringBuilder.AppendLine($"  - {x.Key}{(x.Value.Factory == defaultTarget ? " (default)" : string.Empty)}"));

            throw new LoaderException(stringBuilder.ToString());
        }

        private TargetDefinition LoadTargetDefinition (Build build, PropertyInfo property)
        {
            var targetFactory = (Target) property.GetValue(build);
            return TargetDefinition.Create(property.Name, targetFactory);
        }

        private IEnumerable<TargetDefinition> GetDependencies (
            TargetDefinition targetDefinition,
            Dictionary<string, TargetDefinition> nameDictionary,
            Dictionary<Target, TargetDefinition> factoryDictionary)
        {
            return targetDefinition.DependentShadowTargets
                    .Select(shadowTargetName => nameDictionary.TryGetValue(shadowTargetName, out var shadowTarget)
                        ? shadowTarget
                        : TargetDefinition.Create(shadowTargetName))
                    .Concat(targetDefinition.DependentTargets.Select(x => factoryDictionary[x]));
        }

        private List<TargetDefinition> GetSortedList (
            ICollection<TargetDefinition> targetTargets,
            Dictionary<TargetDefinition, List<TargetDefinition>> targetDependencies)
        {
            var vertexDictionary = targetDependencies.ToDictionary(x => x.Key, x => new Vertex<TargetDefinition>(x.Key));
            foreach (var pair in vertexDictionary)
                pair.Value.Dependencies = targetDependencies[pair.Key].Select(x => vertexDictionary[x]).ToList();

            var graphAsList = vertexDictionary.Values.ToList();
            var result = new List<TargetDefinition>();

            while (graphAsList.Any())
            {
                var independents = graphAsList.Where(x => !graphAsList.Any(y => y.Dependencies.Contains(x))).ToList();
                if (EnvironmentInfo.ArgumentSwitch("strict") && independents.Count > 1)
                {
                    throw new LoaderException(
                        "Incomplete target definition order.",
                        string.Join(EnvironmentInfo.NewLine, independents.Select(x => $"  - {x.Value.Name}")));
                }

                var independent = independents.FirstOrDefault();
                if (independent == null)
                {
                    var scc = new StronglyConnectedComponentFinder<TargetDefinition>();
                    var cycles = scc.DetectCycle(graphAsList)
                            .Cycles()
                            .Select(x => string.Join(" -> ", x.Select(y => y.Value.Name)));

                    throw new LoaderException(
                        "Circular dependencies between target definitions.",
                        string.Join(EnvironmentInfo.NewLine, $"  - {cycles}"));
                }

                graphAsList.Remove(independent);

                var targetDefinition = independent.Value;
                var executableDependency = result.SelectMany(x => targetDependencies[x]).Contains(targetDefinition)
                                           && !EnvironmentInfo.ArgumentSwitch("nodeps");
                if (targetTargets.Contains(targetDefinition) || executableDependency)
                    result.Add(targetDefinition);
            }

            result.Reverse();
            return result;
        }
    }
}
