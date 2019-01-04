using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

static class TeamCityManager
{
    public static void WriteTeamCityConfiguration(string configurationFile, IReadOnlyCollection<GitRepository> repositories)
    {
        var content = File.ReadAllLines(configurationFile).ToList();

        content.Purge();

        string GetName(GitRepository repository)
            => string.Concat(repository.Identifier.Split(x => !char.IsLetter(x)).Select(x => x.Capitalize()));

        content.AddLines("PROJECT",
            repositories
                .Select(GetName)
                .SelectMany(x =>
                    new[]
                    {
                        $"vcsRoot({x}VcsRoot)",
                        $"buildType({x}BuildType)"
                    })
                .Select(x => x.Indent(4)));

        content.AddLines("OBJECTS",
            repositories
                .SelectMany(x =>
                    new[]
                    {
                        $"object {GetName(x)}VcsRoot : CustomGitVcsRoot({x.ToString().DoubleQuote()}, {x.Branch.DoubleQuote()})",
                        $"object {GetName(x)}BuildType : CustomBuildType({x.Identifier.DoubleQuote()}, {GetName(x)}VcsRoot)"
                    }));

        File.WriteAllLines(configurationFile, content);
    }

    static void Purge(this List<string> content)
    {
        for (var i = 0; i < content.Count; i++)
        {
            if (!content[i].TrimStart().StartsWith("// BEGIN"))
                continue;

            i++;
            while (i < content.Count && !content[i].TrimStart().StartsWith("// END"))
            {
                content.RemoveAt(i);
            }
        }
    }

    static void AddLines(this List<string> content, string section, IEnumerable<string> lines)
    {
        var index = content.FindIndex(x => x.TrimStart().StartsWith($"// BEGIN {section.ToUpper()}")) + 1;
        foreach (var line in lines)
            content.Insert(index++, line);
    }
}