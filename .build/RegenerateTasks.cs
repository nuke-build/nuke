// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Model;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Octokit;

// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ArrangeTypeModifiers

internal static class RegenerateTasks
{
    public struct NSwagRelease
    {
        [CanBeNull]
        public Version Version { get; }

        public string BuildNumber { get; }
        public Bump Bump { get; }

        public NSwagRelease(Version version, string buildNumber, Bump bump)
        {
            Version = version;
            BuildNumber = buildNumber;
            Bump = bump;
        }
    }

    public static NSwagRelease GetReleaseInformation(
        IReadOnlyList<Release> releases,
        string repositoryOwner,
        string repositoryName,
        string gitHubApiKey)
    {
        var (latestVersion, oldVersion) = releases
            .Select(x => GetVersion(x, repositoryOwner, repositoryName, gitHubApiKey))
            .ToArray();

        var bump = GetBump(latestVersion, oldVersion);
        var buildNumber = Regex.Match(releases[index: 0].Name, "^NSwag Build (?'buildNumber'[0-9]+)$").Groups["buildNumber"].Value;

        return new NSwagRelease(latestVersion, buildNumber, bump);
    }

    public static void CheckoutBranchOrCreateNewFrom(string branch, string branchToCreateFrom)
    {
        try
        {
            GitTasks.Git($"checkout -B {branch} --track  refs/remotes/origin/{branch}", logOutput: false);
        }
        catch (Exception)
        {
            // remote branch does not exist
            GitTasks.Git($"checkout -B {branch} --no-track  refs/remotes/origin/{branchToCreateFrom}", logOutput: false);
        }
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

    public static void UpdateChangeLog(string changeLogPath, string version, string buildNumber)
    {
        var changeLogLines = TextTasks.ReadAllLines(changeLogPath);
        var firstVNextVersionLine = Array.FindIndex(changeLogLines, x => x == "## [vNext]") + 1;
        var latestReleaseSectionLine = Array.FindIndex(changeLogLines, firstVNextVersionLine, x => x.StartsWith("##"));
        var releaseText = changeLogLines
            .Skip(firstVNextVersionLine)
            .Take(latestReleaseSectionLine - firstVNextVersionLine)
            .Where(x => !string.IsNullOrEmpty(x))
            .Append(
                $"- Changed supported version to [NSwag v{version} (Build {buildNumber})](https://github.com/RSuter/NSwag/releases/tag/NSwag-Build-{buildNumber})");

        var updatedChangeLog =
            changeLogLines.Take(firstVNextVersionLine)
                .Concat(releaseText)
                .Concat(changeLogLines.Skip(latestReleaseSectionLine));
        TextTasks.WriteAllText(changeLogPath, updatedChangeLog.JoinNewLine());
    }

    public static void GitAdd(bool addUntracked, params string[] refs)
    {
        GitTasks.Git($"add {(addUntracked ? "--all" : string.Empty)} {refs.JoinSpace()}");
    }

    public static void GitCommit(params string[] message)
    {
        GitTasks.Git($"commit {message.Aggregate(string.Empty, (x, y) => $"{x}-m \"{y}\" ").TrimEnd()}");
    }

    public static string[] GitLastCommitMessage()
    {
        return GitTasks.Git("log -1 --pretty=%B")
            .Where(x => x.Type == OutputType.Std)
            .Select(x => x.Text)
            .ToArray();
    }

    public static void AddAndCommitChanges(string[] message, string[] refs, bool addUntracked = false)
    {
        GitAdd(addUntracked, refs);
        GitCommit(message);
    }

    [CanBeNull]
    private static Version GetVersion(Release release, string repositoryOwner, string repositoryName, string githubApiKey)
    {
        var commit = GitHubTasks.GetCommit(repositoryOwner, repositoryName, release.TargetCommitish, githubApiKey);
        var versionRegex = new Regex("Release v(?'version'\\d+\\.\\d+\\.\\d+)$", RegexOptions.IgnoreCase);
        var versionString = versionRegex.Match(commit.Message).Groups["version"].Value;
        Version.TryParse(versionString, out var version);
        return version;
    }


    private static Bump GetBump(Version latest, Version old)
    {
        if (latest.Major > old.Major) return Bump.Major;
        return latest.Minor > old.Minor ? Bump.Minor : Bump.Patch;
    }

    [Pure]
    public static string NextSemVer(this GitVersion version, Bump bump)
    {
        switch (bump)
        {
            case Bump.Major:
                return string.Format("{0}.0.0", version.Major + 1);
            case Bump.Minor:
                return string.Format("{0}.{1}.0", version.Major, version.Minor + 1);
            case Bump.Patch:
                return string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Patch + 1);
            default:
                throw new ArgumentOutOfRangeException(nameof(bump), bump, null);
        }
    }

    public enum Bump
    {
        Patch,
        Minor,
        Major
    }
}