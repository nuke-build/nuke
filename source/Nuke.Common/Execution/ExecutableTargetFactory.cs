// Copyright 2019 Maintainers of NUKE.
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
            var targetProperties = GetTargetProperties(buildType);
            var defaultTargets = defaultTargetExpressions.Select(x => x.Compile().Invoke(build)).ToList();

            var executables = new List<ExecutableTarget>();
            foreach (var property in targetProperties)
            {
                var baseMembers = buildType
                    .Descendants(x => x.BaseType)
                    .Select(x => x.GetProperty(property.Name))
                    .Where(x => x != null && x.DeclaringType == x.ReflectedType)
                    .Reverse().ToList();
                var definition = new TargetDefinition(property, build, new Stack<PropertyInfo>(baseMembers));

                var factory = (Target) property.GetValue(build);
                factory.Invoke(definition);

                var target = new ExecutableTarget
                             {
                                 Name = property.Name,
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
                                 Listed = !definition.IsInternal
                             };

                executables.Add(target);
            }

            foreach (var executable in executables)
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
            }

            return executables;
        }

        private static IEnumerable<PropertyInfo> GetTargetProperties(Type buildType)
        {
            // TODO: static targets?
            var interfaceProperties = buildType.GetInterfaces()
                .SelectMany(x => x.GetProperties(ReflectionService.Instance))
                .Where(x => x.PropertyType == typeof(Target))
                .Where(x => buildType.GetProperty(x.Name) == null).ToLookup(x => x.Name);
            var classProperties = buildType
                .GetProperties(ReflectionService.Instance)
                .Where(x => x.PropertyType == typeof(Target))
                .Where(x => !x.Name.Contains(".")).ToDictionary(x => x.Name);

            foreach (var interfacePropertiesByName in interfaceProperties)
            {
                var propertyName = interfacePropertiesByName.Key;
                var classProperty = classProperties.GetValueOrDefault(propertyName);
                ControlFlow.Assert(interfacePropertiesByName.Count() == 1 || classProperty != null,
                    new[] { $"Target '{propertyName}' must be implemented explicitly because it is inherited from multiple interfaces:" }
                        .Concat(interfacePropertiesByName.Select(x => $" - {x.DeclaringType.NotNull().Name}"))
                        .JoinNewLine());
                ControlFlow.Assert(classProperty == null || classProperty.IsPublic(),
                    new[] { $"Target '{propertyName}' must be marked public to override inherited member from:" }
                        .Concat(interfacePropertiesByName.Select(x => $" - {x.DeclaringType.NotNull().Name}"))
                        .JoinNewLine());
            }

            return classProperties.Values
                .Concat(interfaceProperties.SelectMany(x => x)).ToList();
        }
    }
}
