// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities
{
    public class TemplateUtility
    {
        public static string FillTemplate(
            string template, 
            IReadOnlyCollection<string> definitions = null,
            IReadOnlyDictionary<string, string> replacements = null)
        {
            definitions = definitions ?? new List<string>();
            replacements = replacements ?? new Dictionary<string, string>();
            
            // TODO: checked build?
            // definitions.ForEach(x => ControlFlow.Assert(template.Contains(x),
            //     $"Definition '{x}' is not contained in template."));
            // replacements.Keys.ForEach(x => ControlFlow.Assert(template.Contains(x),
            //     $"Replacement for '{x}' is not contained in template."));

            var crCount = template.Count(x => x == '\r');
            var lfCount = template.Count(x => x == '\n');
            var lineEnding = crCount == lfCount ? "\r\n" : "\n";
            var lines = template.Split(new[] { lineEnding }, StringSplitOptions.None)
                .Select(x => HandleLine(x, definitions))
                .Where(x => x != null)
                .ToList();

            for (var i = 0; i < lines.Count; i++)
            {
                if (i > 0 &&
                    string.IsNullOrWhiteSpace(lines[i - 1]) &&
                    string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines.RemoveAt(i);
                    i--;
                }
            }

            return replacements.Aggregate(lines.Join(lineEnding), (t, r) => t.Replace(r.Key, r.Value));
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

            return line.Substring(startIndex: 0, commentIndex).TrimEnd();
        }
    }
}
