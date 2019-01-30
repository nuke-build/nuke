// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    
    public static class TemplateUtility
    {
        public static void FillTemplateDirectoryRecursively(
            string directory,
            IReadOnlyCollection<string> definitions = null,
            IReadOnlyDictionary<string, string> replacements = null,
            Func<DirectoryInfo, bool> excludeDirectory = null,
            Func<FileInfo, bool> excludeFile = null)
        {
            Logger.Info($"Recursively filling out template directory '{directory}'...");
            FillTemplateDirectoryRecursivelyInternal(new DirectoryInfo(directory), definitions, replacements, excludeDirectory, excludeFile);
        }

        private static void FillTemplateDirectoryRecursivelyInternal(
            DirectoryInfo directory,
            [CanBeNull] IReadOnlyCollection<string> definitions,
            [CanBeNull] IReadOnlyDictionary<string, string> replacements,
            [CanBeNull] Func<DirectoryInfo, bool> excludeDirectory,
            [CanBeNull] Func<FileInfo, bool> excludeFile = null)
        {
            if (excludeDirectory != null && excludeDirectory(directory))
                return;
            
            bool ShouldMove(FileSystemInfo info) => replacements?.Keys.Any(x => info.Name.Contains(x)) ?? false;

            foreach (var file in directory.GetFiles())
            {
                if (excludeFile != null && excludeFile(file))
                    continue;

                FillTemplateFile(file.FullName, definitions, replacements);

                if (ShouldMove(file))
                    FileSystemTasks.RenameFile(file.FullName, file.Name.Replace(replacements), FileExistsPolicy.OverwriteIfNewer);
            }

            directory.GetDirectories().ForEach(x => FillTemplateDirectoryRecursivelyInternal(x, definitions, replacements, excludeDirectory, excludeFile));

            if (ShouldMove(directory))
            {
                FileSystemTasks.RenameDirectory(
                    directory.FullName,
                    directory.Name.Replace(replacements),
                    DirectoryExistsPolicy.Merge,
                    FileExistsPolicy.OverwriteIfNewer);
            }
        }

        public static void FillTemplateFile(
            string file,
            IReadOnlyCollection<string> definitions = null,
            IReadOnlyDictionary<string, string> replacements = null)
        {
            TextTasks.WriteAllLines(file, FillTemplate(TextTasks.ReadAllLines(file), definitions, replacements));
        }

        public static string[] FillTemplate(
            IEnumerable<string> template, 
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

            var lines = template
                .Select(x => HandleLine(x, definitions, replacements))
                .WhereNotNull()
                .ToList();

            RemoveDoubleEmptyLines(lines);

            return lines.ToArray();
        }

        private static string HandleLine(
            string line,
            IReadOnlyCollection<string> definitions,
            IReadOnlyDictionary<string, string> replacements)
        {
            var commentIndex = line.LastIndexOf("  // ", StringComparison.OrdinalIgnoreCase);
            if (!ShouldIncludeLine(line, commentIndex, definitions))
                return null;

            return (commentIndex == -1
                    ? line
                    : line.Substring(startIndex: 0, commentIndex).TrimEnd())
                .Replace(replacements);
        }

        private static bool ShouldIncludeLine(string line, int commentIndex, IReadOnlyCollection<string> definitions)
        {
            if (commentIndex == -1)
                return true;
            
            var requiredDefinitionText = line.Substring(commentIndex + 4).Replace(" ", string.Empty);
            var requiredDefinitions = requiredDefinitionText.Split(new[] { "||", "&&" }, StringSplitOptions.RemoveEmptyEntries);
            var orConjunction = requiredDefinitionText.Contains("||");
            var andConjunction = requiredDefinitionText.Contains("&&");
            ControlFlow.Assert(!orConjunction || !andConjunction, "Conjunctions AND and OR can only be used mutually exclusively.");

            return andConjunction && requiredDefinitions.All(x => definitions.Contains(x)) ||
                   !andConjunction && requiredDefinitions.Any(x => definitions.Contains(x));
        }

        private static void RemoveDoubleEmptyLines(IList<string> lines)
        {
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
        }

        private static string Replace(this string str, [CanBeNull] IReadOnlyDictionary<string, string> replacements)
        {
            return replacements?.Aggregate(str, (t, r) => t.Replace(r.Key, r.Value));
        }
    }
}
