// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.Execution;

namespace Nuke.Common.Tests.Execution
{
    internal static class ExecutionTestUtility
    {
        public static T CreateBuild<T>(string defaultTarget = null, Action<T> configure = null)
            where T : NukeBuild
        {
            if (string.IsNullOrEmpty(defaultTarget))
            {
                defaultTarget = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .First(x => x.PropertyType == typeof(Target)).Name;
            }

            var targetExpression = CreateTargetExpressionByTargetName<T>(defaultTarget);
            return CreateBuild(targetExpression, configure);
        }

        public static T CreateBuild<T>(Expression<Func<T, Target>> defaultTargetExpression, Action<T> configure = null)
            where T : NukeBuild
        {
            var instance = Activator.CreateInstance<T>();
            configure?.Invoke(instance);
            instance.TargetDefinitions = instance.GetTargetDefinitions(defaultTargetExpression);
            return instance;
        }

        public static T CreateBuildAndExecuteDefaultTarget<T>(Expression<Func<T, Target>> targetExpression, Action<T> configure = null)
            where T : NukeBuild
        {
            var build = CreateBuild(targetExpression, configure);
            ExecuteDefaultTarget(build);
            return build;
        }

        public static void ExecuteDefaultTarget<T>(T build)
            where T : NukeBuild
        {
            var invokedTargetNames = new[] { BuildExecutor.DefaultTarget };
            var executingTargets = TargetDefinitionLoader.GetExecutingTargets(build, invokedTargetNames, skippedTargetNames: null);
            BuildExecutor.Execute(build, executingTargets);
        }

        private static Expression<Func<T, Target>> CreateTargetExpressionByTargetName<T>(string target)
            where T : NukeBuild
        {
            var param = Expression.Parameter(typeof(T));
            var body = Expression.PropertyOrField(param, target);
            return Expression.Lambda<Func<T, Target>>(body, param);
        }
    }
}
