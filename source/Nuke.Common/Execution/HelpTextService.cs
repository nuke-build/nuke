// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Execution
{
    internal static class HelpTextService
    {
        public static string GetTargetsText(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var builder = new StringBuilder();

            var longestTargetName = executableTargets.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightTargets = Math.Max(longestTargetName, val2: 20);
            builder.AppendLine("Targets (with their direct dependencies):");
            builder.AppendLine();
            foreach (var target in executableTargets.Where(x => x.Listed))
            {
                var dependencies = target.ExecutionDependencies.Count > 0
                    ? $" -> {target.ExecutionDependencies.Select(x => x.Name).JoinComma()}"
                    : string.Empty;
                var targetEntry = target.Name + (target.IsDefault ? " (default)" : string.Empty);
                builder.AppendLine($"  {targetEntry.PadRight(padRightTargets)}{dependencies}");
                if (!string.IsNullOrWhiteSpace(target.Description))
                    builder.AppendLine($"    {target.Description}");
            }

            return builder.ToString();
        }

        public static string GetParametersText(NukeBuild build)
        {
            var defaultTarget = build.ExecutableTargets.SingleOrDefault(x => x.IsDefault);
            var builder = new StringBuilder();

            var parameters = ValueInjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: false)
                .OrderBy(x => x.Name).ToList();
            var padRightParameter = Math.Max(parameters.Max(x => x.Name.Length), val2: 16);

            void PrintParameter(MemberInfo parameter)
            {
                var description = SplitLines(
                    // TODO: remove
                    ParameterService.GetParameterDescription(parameter)
                        ?.Replace("{default_target}", defaultTarget?.Name).Append(".")
                    ?? "<no description>");
                var parameterName = ParameterService.GetParameterDashedName(parameter);
                builder.AppendLine($"  --{parameterName.PadRight(padRightParameter)}  {description.First()}");
                foreach (var line in description.Skip(count: 1))
                    builder.AppendLine($"{new string(c: ' ', count: padRightParameter + 6)}{line}");
            }

            builder.AppendLine("Parameters:");

            var customParameters = parameters.Where(x => x.DeclaringType != typeof(NukeBuild)).ToList();
            if (customParameters.Count > 0)
                builder.AppendLine();
            foreach (var parameter in customParameters)
                PrintParameter(parameter);

            builder.AppendLine();

            var inheritedParameters = parameters.Where(x => x.DeclaringType == typeof(NukeBuild));
            foreach (var parameter in inheritedParameters)
                PrintParameter(parameter);

            return builder.ToString();
        }

        private static List<string> SplitLines(string text)
        {
            var words = new Queue<string>(text.Split(' ').ToList());
            var lines = new List<string> { string.Empty };
            foreach (var word in words)
            {
                if (lines.Last().Length + word.Length > 60)
                    lines.Add(string.Empty);

                lines[lines.Count - 1] = $"{lines.Last()} {word}";
            }

            return lines;
        }
    }
}
