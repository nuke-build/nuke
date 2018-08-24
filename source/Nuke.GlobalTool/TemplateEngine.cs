// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.GlobalTool
{
    public class TemplateEngine
    {
        public static string FillOutTemplate<T>(
            string templateName,
            IReadOnlyCollection<string> definitions = null,
            T replacements = null)
            where T : class
        {
            definitions = definitions ?? new List<string>();
            
            var template = GetTemplate(templateName);
            definitions.ForEach(x => ControlFlow.Assert(template.Contains(x), 
                $"Definition '{x}' is not contained in '{templateName}'. Please raise an issue"));

            var crCount = template.Count(x => x == '\r');
            var lfCount = template.Count(x => x == '\n');
            var lineEnding = crCount == lfCount ? "\r\n" : "\n";
            var lines = template.Split(lineEnding)
                .Select(x => HandleLine(x, definitions))
                .Where(x => x != null)
                .ToList();

            for (var i = 0; i < lines.Count; i++)
            {
                if (i > 0 &&
                    string.IsNullOrEmpty(lines[i - 1]) &&
                    string.IsNullOrEmpty(lines[i]))
                {
                    lines.RemoveAt(i);
                    i--;
                }
            }

            var dictionary = replacements != null
                ? replacements.ToPropertyDictionary(
                    x => $"_{x.Name.SplitCamelHumps().Join(separator: '_').ToUpper()}_",
                    x => x?.ToString() ?? string.Empty)
                : new Dictionary<string, string>();
            return dictionary.Aggregate(lines.Join(lineEnding), (t, r) => t.Replace(r.Key, r.Value));
        }

        private static string GetTemplate(string templateName)
        {
            var fullResourceName = $"{typeof(Program).Namespace}.templates.{templateName}";
            var assembly = typeof(Program).GetTypeInfo().Assembly;
            var resourceStream = assembly.GetManifestResourceStream(fullResourceName).NotNull(
                $"assembly.GetManifestResourceStream({fullResourceName}) != null");
            return new StreamReader(resourceStream).ReadToEnd();
        }

        private static string HandleLine(string line, IReadOnlyCollection<string> definitions)
        {
            var commentIndex = line.LastIndexOf("  //", StringComparison.OrdinalIgnoreCase);
            if (commentIndex == -1)
                return line;

            var requiredDefinitionText = line.Substring(commentIndex + 4).Replace(" ", string.Empty);
            var requiredDefinitions = requiredDefinitionText.Split(new[] { "||", "&&" }, StringSplitOptions.RemoveEmptyEntries);
            var orConjunction = requiredDefinitionText.Contains("||");
            var andConjunction = requiredDefinitionText.Contains("&&");
            ControlFlow.Assert(!orConjunction || !andConjunction, "Conjunctions AND and OR can only be used mutually exclusively.");

            if (!(andConjunction && requiredDefinitions.All(x => definitions.Contains(x)) ||
                  !andConjunction && requiredDefinitions.Any(x => definitions.Contains(x))))
                return null;

            return line.Substring(0, commentIndex).TrimEnd();
        }
    }
}
