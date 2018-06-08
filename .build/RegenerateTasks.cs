// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.CodeGeneration.Model;
using Nuke.Common.IO;
using Nuke.Common.Tools.Git;
using Octokit;

// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ArrangeTypeModifiers

internal static class RegenerateTasks
{
    public static Version GetVersion(Release release, string repositoryOwner, string repositoryName, string githubApiKey)
    {
        var commit = GitHubTasks.GetCommit(repositoryOwner, repositoryName, release.TargetCommitish, githubApiKey);
        var versionRegex = new Regex("Release v(?'version'\\d+\\.\\d+\\.\\d+)$", RegexOptions.IgnoreCase);
        var versionString = versionRegex.Match(commit.Message).Groups["version"].Value;
        return Version.Parse(versionString);
    }

    public static string GetBump(Version latest, Version old)
    {
        if (latest.Major > old.Major) return "major";
        if (latest.Minor > old.Minor) return "minor";
        return "patch";
    }

    public static void CommitAndPushChanges(Version version, string projectDir, string bump, string branch)
    {
        var commitmessage = new[] { $"Regenerate for NSwag v{version}", $"+semver: {bump}" };

        try
        {
            GitTasks.Git($"checkout -B {branch} --track origin/{branch}");
        }
        catch (Exception)
        {
            // remote branch does not exist
            GitTasks.Git($"checkout -B {branch} --no-track origin/master");
        }

        GitTasks.Git($"add --all {projectDir}");
        GitTasks.Git($"commit {commitmessage.Aggregate(string.Empty, (x, y) => $"{x}-m \"{y}\" ").TrimEnd()}");
        GitTasks.Git($"push --force --set-upstream origin {branch}");
    }

    public static bool IsUpdateAvailable(Release latest, string repositoryOwner, string repositoryName, string specificationFile)
    {
        if (!File.Exists(specificationFile)) return true;
        var tool = SerializationTasks.JsonDeserializeFromFile<Tool>(specificationFile);
        var toolReferenceSha = tool.References.First()
            .Replace($"https://raw.githubusercontent.com/{repositoryOwner}/{repositoryName}/", string.Empty).Split(separator: '/')
            .First();
        return !latest.TargetCommitish.StartsWith(toolReferenceSha);
    }
}