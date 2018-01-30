// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nuke.Core.Execution
{
    internal static class BuildExtensions
    {
        public static IReadOnlyCollection<TargetDefinition> GetTargetDefinitions<T> (
                this T build,
                Expression<Func<T, Target>> defaultTargetExpression)
                where T : NukeBuild
        {
            var defaultTarget = defaultTargetExpression.Compile().Invoke(build);
            var targetDefinitions = build.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(x => x.PropertyType == typeof(Target))
                    .Select(x => LoadTargetDefinition(build, x)).ToList();

            var nameDictionary = targetDefinitions.ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);
            var factoryDictionary = targetDefinitions.ToDictionary(x => x.Factory, x => x);

            foreach (var targetDefinition in targetDefinitions)
            {
                var dependencies = GetDependencies(targetDefinition, nameDictionary, factoryDictionary);
                targetDefinition.TargetDefinitionDependencies.AddRange(dependencies);
                targetDefinition.IsDefault = targetDefinition.Factory == defaultTarget;
            }

            return targetDefinitions;
        }

        private static TargetDefinition LoadTargetDefinition (NukeBuild build, PropertyInfo property)
        {
            var targetFactory = (Target) property.GetValue(build);
            return TargetDefinition.Create(property.Name, targetFactory);
        }

        private static IEnumerable<TargetDefinition> GetDependencies (
            TargetDefinition targetDefinition,
            IReadOnlyDictionary<string, TargetDefinition> nameDictionary,
            IReadOnlyDictionary<Target, TargetDefinition> factoryDictionary)
        {
            return targetDefinition.ShadowTargetDependencies
                    .Select(shadowTargetName => nameDictionary.TryGetValue(shadowTargetName, out var shadowTarget)
                        ? shadowTarget
                        : TargetDefinition.Create(shadowTargetName))
                    .Concat(targetDefinition.TargetDependencies.Select(x => factoryDictionary[x]));
        }


        public static IReadOnlyCollection<MemberInfo> GetParameterMembers<T> (this T build)
        {
            return build.GetType()
                    .GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(x => x.GetCustomAttribute<ParameterAttribute>() != null).ToList();
        }
    }
}
