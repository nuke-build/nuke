// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
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
                    Logger.Log(GetTargetsText(build, defaultTargetFactory));
                    Logger.Log();
                    Logger.Log(GetParametersText(build));
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

        public static string GetTargetsText<T> (T build, Target defaultTargetFactory)
            where T : NukeBuild
        {
            var builder = new StringBuilder();

            var targetDefinitions = build.GetTargetDefinitions(defaultTargetFactory);
            var longestTargetName = targetDefinitions.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightTargets = Math.Max(longestTargetName, val2: 20);
            builder.AppendLine("  Targets:");
            builder.AppendLine();
            foreach (var target in targetDefinitions)
            {
                var defaultMarker = target.IsDefault ? " (default)" : string.Empty;
                var dependencies = target.TargetDefinitionDependencies.Count > 0
                    ? $" -> {target.TargetDefinitionDependencies.Select(x => x.Name).Join(", ")}"
                    : string.Empty;
                builder.AppendLine($"    {(target.Name + defaultMarker).PadRight(padRightTargets)}{dependencies}");
                if (!string.IsNullOrWhiteSpace(target.Description))
                    builder.AppendLine($"      {target.Description}");
            }

            return builder.ToString();
        }

        public static string GetParametersText<T> (T build)
            where T : NukeBuild
        {
            var builder = new StringBuilder();

            var parameters = build.GetParameterMembers().OrderBy(x => x.Name).ToList();
            var padRightParameter = Math.Max(parameters.Max(x => x.Name.Length), val2: 17);

            void PrintParameter (MemberInfo parameter)
            {
                var attribute = parameter.GetCustomAttribute<ParameterAttribute>();
                var description = SplitLines(attribute.Description);
                builder.AppendLine($"    -{(attribute.Name ?? parameter.Name).PadRight(padRightParameter)}  {description.First()}");
                foreach (var line in description.Skip(count: 1))
                    builder.AppendLine($"{new string(c: ' ', count: padRightParameter + 7)}{line}");
            }

            builder.AppendLine("  Parameters:");
            builder.AppendLine();
            var inheritedParameters = parameters.Where(x => x.DeclaringType == typeof(NukeBuild));
            foreach (var parameter in inheritedParameters)
                PrintParameter(parameter);

            var customParameters = parameters.Where(x => x.DeclaringType != typeof(NukeBuild)).ToList();
            if (customParameters.Count > 0)
                builder.AppendLine();
            foreach (var parameter in customParameters)
                PrintParameter(parameter);

            return builder.ToString();
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
