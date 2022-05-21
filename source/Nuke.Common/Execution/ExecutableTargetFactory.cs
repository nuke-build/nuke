// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NuGet.Packaging;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    /// <summary>
    /// Creates all target objects according to the build instance.
    /// </summary>
    internal static class ExecutableTargetFactory
    {
        public static IReadOnlyCollection<ExecutableTarget> CreateAll<T>(
            T build,
            params Expression<Func<T, Target>>[] defaultTargetExpressions)
            where T : NukeBuild
        {
            var buildType = build.GetType();
            var targetProperties = GetTargetProperties(build.GetType()).ToList();
            var defaultTargets = defaultTargetExpressions.Select(x => x.Compile().Invoke(build)).ToList();

            ExecutableTarget Create(PropertyInfo property)
            {
                var baseMembers = buildType
                    .Descendants(x => x.BaseType)
                    .Select(x => x.GetProperty(property.Name))
                    .Where(x => x != null && x.DeclaringType == x.ReflectedType)
                    .Reverse().ToList();
                var definition = new TargetDefinition(property, build, new Stack<PropertyInfo>(baseMembers));

                var factory = (Target) property.GetValue(build);
                factory.Invoke(definition);

                return new ExecutableTarget
                             {
                                 Name = property.GetDisplayShortName(),
                                 Member = property,
                                 Definition = definition,
                                 Description = definition.Description,
                                 Factory = factory,
                                 IsDefault = defaultTargets.Contains(factory),
                                 DynamicConditions = definition.DynamicConditions,
                                 StaticConditions = definition.StaticConditions,
                                 DependencyBehavior = definition.DependencyBehavior,
                                 ProceedAfterFailure = definition.IsProceedAfterFailure,
                                 AssuredAfterFailure = definition.IsAssuredAfterFailure,
                                 Requirements = definition.Requirements,
                                 Actions = definition.Actions,
                                 Listed = !definition.IsInternal,
                                 PartitionSize = definition.PartitionSize,
                                 ArtifactProducts = definition.ArtifactProducts,
                                 ExecuteInDockerSettings = definition.ExecuteInDockerSettings
                             };
            }

            var executables = targetProperties.Select(Create).ToList();
            executables.ForEach(x => ApplyDependencies(x, executables));

            return executables;
        }

        private static void ApplyDependencies(ExecutableTarget executable, IReadOnlyCollection<ExecutableTarget> executables)
        {
            IEnumerable<ExecutableTarget> GetDependencies(
                Func<TargetDefinition, IReadOnlyList<Target>> directDependenciesSelector,
                Func<TargetDefinition, IReadOnlyList<Target>> indirectDependenciesSelector)
            {
                foreach (var factoryDependency in directDependenciesSelector(executable.Definition))
                    yield return executables.Single(x => x.Factory == factoryDependency);

                foreach (var otherExecutables in executables.Where(x => x != executable))
                {
                    var otherDependencies = indirectDependenciesSelector(otherExecutables.Definition);
                    if (otherDependencies.Any(x => x == executable.Factory))
                        yield return otherExecutables;
                }
            }

            executable.ExecutionDependencies.AddRange(GetDependencies(x => x.DependsOnTargets, x => x.DependentForTargets));
            executable.OrderDependencies.AddRange(GetDependencies(x => x.AfterTargets, x => x.BeforeTargets));
            executable.TriggerDependencies.AddRange(GetDependencies(x => x.TriggeredByTargets, x => x.TriggersTargets));
            executable.Triggers.AddRange(GetDependencies(x => x.TriggersTargets, x => x.TriggeredByTargets));

            foreach (var artifactDependency in executable.Definition.ArtifactDependencies)
            {
                var dependency = executables.Single(x => x.Factory == artifactDependency.Key);
                foreach (var artifacts in artifactDependency)
                    executable.ArtifactDependencies.AddRange(dependency, artifacts.Length > 0 ? artifacts : dependency.ArtifactProducts);
            }
        }

        internal static IEnumerable<PropertyInfo> GetTargetProperties(Type buildType)
        {
            // TODO: static targets?
            return buildType.GetAllMembers(
                x => x is PropertyInfo property && property.PropertyType == typeof(Target),
                bindingFlags: ReflectionUtility.Instance,
                allowAmbiguity: false,
                filterQuasiOverridden: true).Cast<PropertyInfo>();
        }
    }
}
