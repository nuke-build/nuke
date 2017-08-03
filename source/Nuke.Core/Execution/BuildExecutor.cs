// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Nuke.Core.OutputSinks;
using Nuke.Core.Utilities;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.Execution
{
    internal static class BuildExecutor
    {
        public static int Execute<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : IBuild
        {
            var build = Activator.CreateInstance<T>();
            var defaultTargetName = ((MemberExpression) defaultTargetExpression.Body).Member.Name;
            var defaultTargetFactory = defaultTargetExpression.Compile().Invoke(build);
            
            if (ArgumentSwitch ("help"))
            {
                PrintHelp(build, defaultTargetName);
                return 0;
            }

            IReadOnlyCollection<TargetDefinition> executionList;
            using (DelegateDisposable.CreateBracket(
                () => ControlFlow.IsPreparing = true,
                () => ControlFlow.IsPreparing = false))
            {
                InjectionService.InjectValues(build);
                executionList = TargetDefinitionLoader.GetExecutionList(build, defaultTargetFactory);
                RequirementService.ValidateRequirements(executionList, build);
            }

            return new ExecutionListRunner().Run(executionList);
            
        }

        private static void PrintHelp<T> (T build, string defaultTargetName)
            where T : IBuild
        {
            Logger.Block("NUKE");
            Logger.Info($"Version: {BuildAssembly.GetName().Version}");
            Logger.Info(string.Empty);

            var targetDefinitions = build.GetTargetDefinitions();
            var longestName = targetDefinitions.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRight = Math.Max(longestName, val2: 15);
            Logger.Info("Targets");
            Logger.Info();
            foreach (var target in targetDefinitions)
            {
                var defaultMarker = target.Name.Equals(defaultTargetName, StringComparison.OrdinalIgnoreCase) ? " (default)" : string.Empty;
                var dependencies = target.TargetDefinitionDependencies.Count > 0
                    ? $" -> {target.TargetDefinitionDependencies.Select(x => x.Name).Join(", ")}"
                    : string.Empty;
                Logger.Info($"  {(target.Name + defaultMarker).PadRight(padRight)}{dependencies}");
                if (!string.IsNullOrWhiteSpace(target.Description))
                    Logger.Info($"    {target.Description}");
            }
        }
    }
}
