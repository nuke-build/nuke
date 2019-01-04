using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

static class ReadmeManager
{
    static readonly string[] s_commonRepositories =
    {
        "nuke-build/common"
    };

    static readonly string[] s_extensionRepositories =
    {
        "nuke-build/vscode",
        "nuke-build/resharper"
    };
    
    public static void WriteReadme(string readmeFile, string repositoriesDirectory)
    {
        var content = File.ReadAllLines(readmeFile).ToList();

        content.Purge();

        var allEntries = new DirectoryInfo(repositoriesDirectory)
            .EnumerateFiles("README.md", maxDepth: 3)
            .Select(ReadmeEntry.TryCreate)
            .WhereNotNull()
            .OrderBy(x => x.Name)
            .ToLookup(x => x.Category);
        content.AddEntries(Category.Common, allEntries[Category.Common]);
        content.AddEntries(Category.Extensions, allEntries[Category.Extensions]);
        content.AddEntries(Category.Addons, allEntries[Category.Addons]);

        File.WriteAllLines(readmeFile, content);
    }

    static void Purge(this List<string> content)
    {
        for (var i = 0; i < content.Count; i++)
        {
            if (!content[i].StartsWith("<!-- BEGIN"))
                continue;

            i++;
            while (i < content.Count && !content[i].StartsWith("<!-- END"))
            {
                content.RemoveAt(i);
            }
        }
    }

    static void AddEntries(this List<string> content, Category category, IEnumerable<ReadmeEntry> entries)
    {
        var index = content.FindIndex(x => x.Equals($"<!-- BEGIN {category.ToString().ToUpper()} -->")) + 1;
        foreach (var entry in entries.Reverse())
        {
            content.InsertRange(
                index,
                new[]
                {
                    $"### [{entry.Name}]({entry.Repository.GetGitHubBrowseUrl()})",
                    entry.Description,
                    string.Empty
                });
        }

        content.Insert(index, string.Empty);
    }

    enum Category
    {
        Common,
        Extensions,
        Addons
    }

    class ReadmeEntry
    {
        [CanBeNull]
        public static ReadmeEntry TryCreate(FileInfo readmeFile)
        {
            var readmeContent = File.ReadAllLines(readmeFile.FullName).ToList();
            var startIndex = readmeContent.FindIndex(x => x.StartsWith("<!-- BEGIN DESCRIPTION -->"));
            var endIndex = readmeContent.FindIndex(x => x.StartsWith("<!-- END DESCRIPTION -->"));

            if (startIndex == -1 && endIndex == -1)
                return null;
            ControlFlow.Assert(startIndex > -1 && endIndex > -1, $"Incomplete description section in '{readmeFile}'.");

            var description = readmeContent
                .Skip(startIndex + 1)
                .Take(endIndex - startIndex - 1)
                .Reverse().SkipWhile(string.IsNullOrWhiteSpace)
                .Reverse().SkipWhile(string.IsNullOrWhiteSpace)
                .JoinNewLine();

            var repository = GitRepository.FromLocalDirectory(readmeFile.Directory.NotNull().FullName);
            var name = repository.Identifier;
            var category = s_commonRepositories.Contains(name, StringComparer.OrdinalIgnoreCase)
                ? Category.Common
                : s_extensionRepositories.Contains(name, StringComparer.OrdinalIgnoreCase)
                    ? Category.Extensions
                    : Category.Addons;

            return new ReadmeEntry
                   {
                       Name = name,
                       Category = category,
                       Description = description,
                       Repository = repository
                   };
        }

        public string Name { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public GitRepository Repository { get; private set; }
    }
}