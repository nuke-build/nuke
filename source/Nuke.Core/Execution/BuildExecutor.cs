// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Core.Utilities;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.Execution
{
    internal static class BuildExecutor
    {
        public static int Execute<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            IReadOnlyCollection<TargetDefinition> executionList;
            using (DelegateDisposable.CreateBracket(
                () => ControlFlow.IsPreparing = true,
                () => ControlFlow.IsPreparing = false))
            {
                var build = Activator.CreateInstance<T>();
                var defaultTargetName = ((MemberExpression) defaultTargetExpression.Body).Member.Name;
                var defaultTargetFactory = defaultTargetExpression.Compile().Invoke(build);
            
                InjectionService.InjectValues(build);

                PrintLogo();

                if (build.Help)
                {
                    PrintHelp(build, defaultTargetName);
                    return 0;
                }

                executionList = TargetDefinitionLoader.GetExecutionList(build, defaultTargetFactory);
                RequirementService.ValidateRequirements(executionList, build);
            }

            return new ExecutionListRunner().Run(executionList);
            
        }

        private static void PrintLogo()
        {
            Logger.Block("NUKE");
            Logger.Info($"Version: {BuildAssembly.GetName().Version}");
            Logger.Info(string.Empty);
        }

        private static void PrintHelp<T> (T build, string defaultTargetName)
            where T : NukeBuild
        {
            var targetDefinitions = build.GetTargetDefinitions();
            var longestTargetName = targetDefinitions.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightTargets = Math.Max(longestTargetName, val2: 20);
            Logger.Info("  Targets:");
            Logger.Info();
            foreach (var target in targetDefinitions)
            {
                var defaultMarker = target.Name.Equals(defaultTargetName, StringComparison.OrdinalIgnoreCase) ? " (default)" : string.Empty;
                var dependencies = target.TargetDefinitionDependencies.Count > 0
                    ? $" -> {target.TargetDefinitionDependencies.Select(x => x.Name).Join(", ")}"
                    : string.Empty;
                Logger.Info($"    {(target.Name + defaultMarker).PadRight(padRightTargets)}{dependencies}");
                if (!string.IsNullOrWhiteSpace(target.Description))
                    Logger.Info($"      {target.Description}");
            }

            Logger.Info();

            var parameters = build.GetParameterMembers();
            var longestParameterName = parameters.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightParameter = Math.Max(longestParameterName, val2: 18);
            Logger.Info("  Parameters:");
            Logger.Info();
            foreach (var parameter in parameters)
            {
                var attribute = parameter.GetCustomAttribute<ParameterAttribute>();
                Logger.Info($"    -{(attribute.Name ?? parameter.Name).ToLowerInvariant().PadRight(padRightParameter)}  {attribute.Description}");
            }
        }
    }
}
