// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using NuGet.Versioning;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;

// ReSharper disable ArgumentsStyleLiteral
namespace Nuke.Common.ChangeLog
{
    [PublicAPI]
    public static class ChangelogTasks
    {
        public static string GetNuGetReleaseNotes(string changelogFile, GitRepository repository = null)
        {
            var changelogSectionNotes = ExtractChangelogSectionNotes(changelogFile)
                .Select(x => x.Replace("- ", "\u2022 ").Replace("`", string.Empty).Replace(",", "%2C")).ToList();

            if (repository.IsGitHubRepository())
            {
                changelogSectionNotes.Add(string.Empty);
                changelogSectionNotes.Add($"Full changelog at {repository.GetGitHubBrowseUrl(changelogFile)}");
            }

            return changelogSectionNotes.JoinNewLine();
        }

        /// <summary>
        /// Reads the release notes from the given changelog file and returns the result.
        /// </summary>
        /// <param name="changelogFile">The path to the changelog file.</param>
        /// <returns>A readonly list of the release sections contained in the changelog.</returns>
        [Pure]
        public static IReadOnlyList<ReleaseNotes> ReadReleaseNotes(string changelogFile)
        {
            var lines = TextTasks.ReadAllLines(changelogFile).ToList();
            var releaseSections = GetReleaseSections(lines).ToList();

            ControlFlow.Assert(releaseSections.Any(), "Changelog should have at least one release note section");
            return releaseSections.Select(Parse).ToList().AsReadOnly();

            ReleaseNotes Parse(ReleaseSection section)
            {
                var releaseNotes = lines
                    .Skip(section.StartIndex + 1)
                    .Take(section.EndIndex - section.StartIndex)
                    .ToList()
                    .AsReadOnly();

                return NuGetVersion.TryParse(section.Caption, out var version)
                    ? new ReleaseNotes(version, releaseNotes, section.StartIndex, section.EndIndex)
                    : new ReleaseNotes(releaseNotes, section.StartIndex, section.EndIndex);
            }
        }

        /// <summary>
        /// Reads the specified changelog.
        /// </summary>
        /// <param name="changelogFile">The path to the changelog file.</param>
        /// <returns>A <see cref="ChangeLog"/> object to work with the changelog.</returns>
        [Pure]
        public static ChangeLog ReadChangelog(string changelogFile)
        {
            var releaseNotes = ReadReleaseNotes(changelogFile);
            var unreleased = releaseNotes.Where(x => x.Unreleased).ToArray();

            if (unreleased.Length > 0)
            {
                ControlFlow.Assert(unreleased.Length == 1, "Changelog should have only one draft section.");
                return new ChangeLog(changelogFile, unreleased.First(), releaseNotes);
            }

            ControlFlow.Assert(releaseNotes.Count(x => !x.Unreleased) >= 1, "Changelog should have at lease one released version section.");
            return new ChangeLog(changelogFile, releaseNotes);
        }

        /// <summary>
        /// Finalizes the changelog by moving all entries from `[vNext]` to the version specified by release.
        /// <p>If <paramref name="repository"/> is specified a summary with all versions and links to list the changes directly on GitHub is appended to the end of the changelog.</p>
        /// </summary>
        /// <param name="changelogFile">The path to the changelog file.</param>
        /// <param name="tag">The <see cref="NuGetVersion"/> to finalize the changelog.</param>
        /// <param name="repository">The repository to create the version overview for.</param>
        /// <seealso cref="FinalizeChangelog(ChangeLog,NuGetVersion,GitRepository)"/>
        public static void FinalizeChangelog(ChangeLog changelogFile, NuGetVersion tag, [CanBeNull] GitRepository repository = null)
        {
            Logger.Info($"Finalizing {PathConstruction.GetRelativePath(NukeBuild.RootDirectory, changelogFile.Path)} for '{tag}'...");

            var unreleasedNotes = changelogFile.Unreleased;
            var releaseNotes = changelogFile.ReleaseNotes;
            var lastReleased = changelogFile.LatestVersion;

            ControlFlow.Assert(unreleasedNotes != null, "Changelog should have draft section.");
            ControlFlow.Assert(releaseNotes.Any(x => x.Version != null && x.Version.Equals(tag)), $"Tag '{tag}' already exists.");
            ControlFlow.Assert(lastReleased != null && tag.CompareTo(lastReleased.Version) > 0,
                $"Tag '{tag}' is not greater compared to last tag '{lastReleased.NotNull().Version}'.");

            var path = changelogFile.Path;

            var content = TextTasks.ReadAllLines(path).ToList();

            content.Insert(unreleasedNotes.StartIndex + 1, string.Empty);
            content.Insert(unreleasedNotes.EndIndex + 2, $"## [{tag}] / {DateTime.Now:yyyy-MM-dd}");

            UpdateVersionSummary(tag.ToString(), content, repository);

            content.Add(string.Empty);

            TextTasks.WriteAllLines(path, content);
        }

        /// <summary>
        /// Finalizes the changelog by moving all entries from `[vNext]` to the version specified by release.
        /// <p>If <paramref name="repository"/> is specified a summary with all versions and links to list the changes directly on GitHub is appended to the end of the changelog.</p>
        /// </summary>
        /// <param name="changelogFile">The path to the changelog file.</param>
        /// <param name="tag">The version to finalize the changelog.</param>
        /// <param name="repository">The repository to create the version overview for.</param>
        /// <seealso cref="FinalizeChangelog(ChangeLog,NuGetVersion,GitRepository)"/>
        public static void FinalizeChangelog(string changelogFile, string tag, [CanBeNull] GitRepository repository = null)
        {
            Logger.Info($"Finalizing {PathConstruction.GetRelativePath(NukeBuild.RootDirectory, changelogFile)} for '{tag}'...");

            var content = TextTasks.ReadAllLines(changelogFile).ToList();
            var sections = GetReleaseSections(content).ToList();
            var firstSection = sections.First();
            var secondSection = sections.Skip(1).FirstOrDefault();

            ControlFlow.Assert(firstSection.Caption.All(char.IsLetter), "Cannot find a draft section.");
            ControlFlow.Assert(sections.All(x => !x.Caption.EqualsOrdinalIgnoreCase(tag)), $"Tag '{tag}' already exists.");
            ControlFlow.Assert(firstSection.EndIndex > firstSection.StartIndex,
                $"Draft section '{firstSection.Caption}' does not contain any information.");
            ControlFlow.Assert(secondSection == null || NuGetVersion.Parse(tag).CompareTo(NuGetVersion.Parse(secondSection.Caption)) > 0,
                $"Tag '{tag}' is not greater compared to last tag '{secondSection?.Caption}'.");

            content.Insert(firstSection.StartIndex + 1, string.Empty);
            content.Insert(firstSection.StartIndex + 2, $"## [{tag}] / {DateTime.Now:yyyy-MM-dd}");

            UpdateVersionSummary(tag, content, repository);

            content.Add(string.Empty);

            TextTasks.WriteAllLines(changelogFile, content);
        }

        /// <summary>
        /// Extracts the notes of the specified changelog section.
        /// </summary>
        /// <param name="changelogFile">The path to the changelog file.</param>
        /// <param name="tag">The tag which release notes should get extracted.</param>
        /// <returns>A collection of the release notes.</returns>
        [Pure]
        public static IEnumerable<string> ExtractChangelogSectionNotes(string changelogFile, string tag = null)
        {
            var content = TextTasks.ReadAllLines(changelogFile).ToList();
            var sections = GetReleaseSections(content);
            var section = tag == null
                ? sections.First(x => x.StartIndex < x.EndIndex)
                : sections.First(x => x.Caption.EqualsOrdinalIgnoreCase(tag)).NotNull($"Could not find release section for '{tag}'.");

            return content
                .Skip(section.StartIndex + 1)
                .Take(section.EndIndex - section.StartIndex);
        }

        private static IEnumerable<ReleaseSection> GetReleaseSections(List<string> content)
        {
            bool IsReleaseHead(string str)
                => str.StartsWith("## ");

            bool IsReleaseContent(string str)
                => str.StartsWith("###") || str.Trim().StartsWith("-");

            string GetCaption(string str)
                => str
                    .TrimStart('#', ' ', '[')
                    .Split(' ')
                    .First()
                    .TrimEnd(']');

            var index = content.FindIndex(IsReleaseHead);
            while (index < content.Count)
            {
                var line = content[index];
                if (!IsReleaseHead(line))
                {
                    index++;
                    continue;
                }

                var caption = GetCaption(line);
                var nextNonReleaseContentIndex = content.FindIndex(index + 1, x => IsReleaseHead(x) || !IsReleaseContent(x));

                var releaseData =
                    new ReleaseSection
                    {
                        Caption = caption,
                        StartIndex = index,
                        EndIndex = nextNonReleaseContentIndex != -1
                            ? nextNonReleaseContentIndex - 1
                            : content.Count - 1
                    };

                yield return releaseData;
                Logger.Trace($"Found section '{caption}' [{index}-{releaseData.EndIndex}].");

                index = releaseData.EndIndex + 1;
            }
        }

        private static void UpdateVersionSummary(string tag, List<string> content, [CanBeNull] GitRepository repository)
        {
            if (repository != null && repository.IsGitHubRepository())
            {
                var sections = GetReleaseSections(content).ToList();
                var firstSection = sections.First();
                var lastSection = sections.Last();

                content.RemoveRange(lastSection.EndIndex + 1, content.Count - lastSection.EndIndex - 1);

                content.Add(string.Empty);
                content.Add($"[{firstSection.Caption}]: {repository}/compare/{tag}...HEAD");
                for (var i = 1; i + 1 < sections.Count; i++)
                    content.Add($"[{sections[i].Caption}]: {repository}/compare/{sections[i + 1].Caption}...{sections[i].Caption}");
                content.Add($"[{lastSection.Caption}]: {repository}/tree/{lastSection.Caption}");
            }
        }

        [DebuggerDisplay("{" + nameof(Caption) + "} [{" + nameof(StartIndex) + "}-{" + nameof(EndIndex) + "}]")]
        private class ReleaseSection
        {
            public string Caption;
            public int StartIndex;
            public int EndIndex;
        }
    }
}
