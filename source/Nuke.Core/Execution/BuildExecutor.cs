// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Core.OutputSinks;
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
                    PrintTargets(build, defaultTargetName);
                    Logger.Log();
                    PrintParameters(build);
                    return 0;
                }

                executionList = TargetDefinitionLoader.GetExecutionList(build, defaultTargetFactory);
                RequirementService.ValidateRequirements(executionList, build);
            }

            return new ExecutionListRunner().Run(executionList);
            
        }

        private static void PrintLogo()
        {
            Logger.Log(FigletTransform.GetText("NUKE"));
            Logger.Log($"Version: {BuildAssembly.GetName().Version}");
            Logger.Log(string.Empty);
        }

        private static void PrintTargets<T> (T build, string defaultTargetName)
            where T : NukeBuild
        {
            var targetDefinitions = build.GetTargetDefinitions();
            var longestTargetName = targetDefinitions.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightTargets = Math.Max(longestTargetName, val2: 20);
            Logger.Log("  Targets:");
            Logger.Log();
            foreach (var target in targetDefinitions)
            {
                var defaultMarker = target.Name.Equals(defaultTargetName, StringComparison.OrdinalIgnoreCase) ? " (default)" : string.Empty;
                var dependencies = target.TargetDefinitionDependencies.Count > 0
                    ? $" -> {target.TargetDefinitionDependencies.Select(x => x.Name).Join(", ")}"
                    : string.Empty;
                Logger.Log($"    {(target.Name + defaultMarker).PadRight(padRightTargets)}{dependencies}");
                if (!string.IsNullOrWhiteSpace(target.Description))
                    Logger.Log($"      {target.Description}");
            }
        }

        private static void PrintParameters<T> (T build)
            where T : NukeBuild
        {
            var parameters = build.GetParameterMembers().OrderBy(x => x.Name).ToList();
            var longestParameterName = parameters.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightParameter = Math.Max(longestParameterName, val2: 17);

            void PrintParameter (MemberInfo parameter)
            {
                var attribute = parameter.GetCustomAttribute<ParameterAttribute>();
                var description = SplitLines(attribute.Description);
                Logger.Log($"    -{(attribute.Name ?? parameter.Name).PadRight(padRightParameter)}  {description.First()}");
                foreach (var line in description.Skip(count: 1))
                    Logger.Log($"{new string(c: ' ', count: padRightParameter + 7)}{line}");
            }

            Logger.Log("  Parameters:");
            Logger.Log();
            var inheritedParameters = parameters.Where(x => x.DeclaringType == typeof(NukeBuild));
            foreach (var parameter in inheritedParameters)
                PrintParameter(parameter);

            var customParameters = parameters.Where(x => x.DeclaringType != typeof(NukeBuild)).ToList();
            if (customParameters.Count > 0)
                Logger.Log();
            foreach (var parameter in customParameters)
                PrintParameter(parameter);
        }

        private static List<string> SplitLines(string text)
        {
            var words = new Queue<string>(text.Split(' ').ToList());
            var lines = new List<string> { string.Empty };
            foreach (var word in words)
            {
                if (lines.Last().Length + word.Length > 40)
                    lines.Add(string.Empty);

                lines[lines.Count - 1] = $"{lines.Last()} {word}";
            }
            return lines;
        }
    }
}
