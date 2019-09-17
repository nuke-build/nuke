// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NuGet.Packaging;

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
            var defaultTargets = defaultTargetExpressions.Select(x => x.Compile().Invoke(build)).ToList();
            var properties = build.GetType()
                .GetProperties(ReflectionService.Instance)
                .Where(x => x.PropertyType == typeof(Target)).ToList();

            var executables = new List<ExecutableTarget>();

            foreach (var property in properties)
            {
                var factory = (Target) property.GetValue(build);
                var definition = new TargetDefinition();
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
                                 Listed = !definition.IsInternal,
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
    }
}
