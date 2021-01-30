// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    public static class TemplateUtility
    {
        public static void AddRegion(List<string> content, string section, IEnumerable<string> lines)
        {
            var index = content.FindIndex(x => x.TrimStart().StartsWith(section)) + 1;
            foreach (var line in lines)
                content.Insert(index++, line);
        }

        public static ILookup<string, string> ExtractAndRemoveRegions(List<string> content, string beginPrefix, string endPrefix)
        {
            var regions = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);

            for (var i = 0; i < content.Count; i++)
            {
                if (!content[i].TrimStart().StartsWith(beginPrefix))
                    continue;

                var regionName = content[i].TrimStart().TrimStart(beginPrefix).TrimStart();
                i++;

                while (i < content.Count && !content[i].TrimStart().StartsWith(endPrefix))
                {
                    regions.Add(regionName, content[i]);
                    content.RemoveAt(i);
                }
            }

            return regions;
        }

        public static IReadOnlyDictionary<string, string> GetDictionary<T>(T obj)
            where T : class
        {
            return obj != null
                ? obj.ToPropertyDictionary(x => GetTokenName(x.Name), x => x?.ToString() ?? string.Empty)
                : new Dictionary<string, string>();
        }

        public static string GetTokenName(string name)
        {
            return name.SplitCamelHumpsWithSeparator("_", exclusions: Constants.KnownWords).ToUpper();
        }

        public static void FillTemplateDirectoryRecursively(
            string directory,
            IReadOnlyDictionary<string, string> tokens = null,
            Func<DirectoryInfo, bool> excludeDirectory = null,
            Func<FileInfo, bool> excludeFile = null)
        {
            Logger.Info($"Recursively filling out template directory '{directory}'...");
            FillTemplateDirectoryRecursivelyInternal(new DirectoryInfo(directory), tokens, excludeDirectory, excludeFile);
        }

        private static void FillTemplateDirectoryRecursivelyInternal(
            DirectoryInfo directory,
            [CanBeNull] IReadOnlyDictionary<string, string> tokens,
            [CanBeNull] Func<DirectoryInfo, bool> excludeDirectory,
            [CanBeNull] Func<FileInfo, bool> excludeFile = null)
        {
            if (excludeDirectory != null && excludeDirectory(directory))
                return;

            bool ShouldMove(FileSystemInfo file) => tokens?.Keys.Any(x => file.Name.Contains(x)) ?? false;

            foreach (var file in directory.GetFiles())
            {
                if (excludeFile != null && excludeFile(file))
                    continue;

                FillTemplateFile(file.FullName, tokens);

                if (ShouldMove(file))
                    FileSystemTasks.RenameFile(file.FullName, file.Name.Replace(tokens), FileExistsPolicy.OverwriteIfNewer);
            }

            directory.GetDirectories()
                .ForEach(x => FillTemplateDirectoryRecursivelyInternal(x, tokens, excludeDirectory, excludeFile));

            if (ShouldMove(directory))
            {
                FileSystemTasks.RenameDirectory(
                    directory.FullName,
                    directory.Name.Replace(tokens),
                    DirectoryExistsPolicy.Merge,
                    FileExistsPolicy.OverwriteIfNewer);
            }
        }

        public static void FillTemplateFile(
            string file,
            IReadOnlyDictionary<string, string> tokens = null)
        {
            TextTasks.WriteAllLines(file, FillTemplate(TextTasks.ReadAllLines(file), tokens));
        }

        public static string[] FillTemplate(
            IEnumerable<string> template,
            IReadOnlyDictionary<string, string> tokens = null)
        {
            tokens = (tokens ?? new Dictionary<string, string>())
                .ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);

            // TODO: checked build?
            // definitions.ForEach(x => ControlFlow.Assert(template.Contains(x),
            //     $"Definition '{x}' is not contained in template."));
            // replacements.Keys.ForEach(x => ControlFlow.Assert(template.Contains(x),
            //     $"Replacement for '{x}' is not contained in template."));

            var lines = template
                .Select(x => HandleLine(x, tokens))
                .WhereNotNull()
                .ToList();

            RemoveDoubleEmptyLines(lines);

            return lines.ToArray();
        }

        private static string HandleLine(
            string line,
            IReadOnlyDictionary<string, string> tokens)
        {
            var commentIndex = line.LastIndexOf("  // ", StringComparison.OrdinalIgnoreCase);
            if (!ShouldIncludeLine(line, commentIndex, tokens))
                return null;

            return (commentIndex == -1
                    ? line
                    : line.Substring(startIndex: 0, commentIndex).TrimEnd())
                .Replace(tokens);
        }

        private static bool ShouldIncludeLine(string line, int commentIndex, IReadOnlyDictionary<string, string> tokens)
        {
            if (commentIndex == -1)
                return true;

            var requiredTokensText = line.Substring(commentIndex + 4).Replace(" ", string.Empty);
            var requiredTokens = requiredTokensText.Split(new[] { "||", "&&" }, StringSplitOptions.RemoveEmptyEntries);
            var orConjunction = requiredTokensText.Contains("||");
            var andConjunction = requiredTokensText.Contains("&&");
            ControlFlow.Assert(!orConjunction || !andConjunction, "Conjunctions AND and OR can only be used mutually exclusively.");

            return andConjunction && requiredTokens.All(tokens.ContainsKey) ||
                   !andConjunction && requiredTokens.Any(tokens.ContainsKey);
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

        private static string Replace(this string str, [CanBeNull] IReadOnlyDictionary<string, string> tokens)
        {
            return tokens?.OrderByDescending(x => x.Key.Length).Aggregate(str, (t, r) => t.Replace($"_{r.Key}_", r.Value));
        }
    }
}
