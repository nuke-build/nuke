// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Utilities;
using Octokit;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.Tools.GitHub
{
    public enum GitHubItemType
    {
        Automatic,
        File,
        Directory
    }

    [PublicAPI]
    public static class GitHubTasks
    {
        public static GitHubClient GitHubClient = new(new ProductHeaderValue(nameof(NukeBuild)));

        static GitHubTasks()
        {
            if (EnvironmentInfo.GetVariable("GITHUB_TOKEN") is { } token)
                GitHubClient.Credentials = new Credentials(token);
        }

        public static async Task<IEnumerable<(string DownloadUrl, string RelativePath)>> GetGitHubDownloadUrls(
            this GitRepository repository,
            string directory = null,
            string branch = null)
        {
            Assert.True(repository.IsGitHubRepository());
            Assert.True(!HasPathRoot(directory) || repository.LocalDirectory != null);

            var relativeDirectory = HasPathRoot(directory)
                ? GetRelativePath(repository.LocalDirectory, directory)
                : directory;
            relativeDirectory = (relativeDirectory + "/").TrimStart("/");

            branch ??= await repository.GetDefaultBranch();
            var treeResponse = await GitHubClient.Git.Tree.GetRecursive(
                repository.GetGitHubOwner(),
                repository.GetGitHubName(),
                branch);

            return treeResponse.Tree
                .Where(x => x.Type == TreeType.Blob)
                .Where(x => x.Path.StartsWithOrdinalIgnoreCase(relativeDirectory))
                .Select(x => (repository.GetGitHubDownloadUrl(x.Path, branch), x.Path.TrimStart(relativeDirectory)));
        }

        public static async Task<string> GetDefaultBranch(this GitRepository repository)
        {
            Assert.True(repository.IsGitHubRepository());

            var repo = await GitHubClient.Repository.Get(repository.GetGitHubOwner(), repository.GetGitHubName());
            return repo.DefaultBranch;
        }

        public static async Task<string> GetLatestRelease(this GitRepository repository, bool includePrerelease = false, bool trimPrefix = false)
        {
            Assert.True(repository.IsGitHubRepository());
            var releases = await GitHubClient.Repository.Release.GetAll(repository.GetGitHubOwner(), repository.GetGitHubName());
            return releases.First(x => !x.Prerelease || includePrerelease).TagName.TrimStart(trimPrefix ? "v" : string.Empty);
        }

        [ItemCanBeNull]
        public static async Task<Milestone> GetGitHubMilestone(this GitRepository repository, string name)
        {
            Assert.True(repository.IsGitHubRepository());
            var milestones = await GitHubClient.Issue.Milestone.GetAllForRepository(
                repository.GetGitHubOwner(),
                repository.GetGitHubName(),
                new MilestoneRequest { State = ItemStateFilter.All });
            return milestones.FirstOrDefault(x => x.Title == name);
        }

        public static async Task TryCreateGitHubMilestone(this GitRepository repository, string title)
        {
            try
            {
                await repository.CreateGitHubMilestone(title);
            }
            catch
            {
                // ignored
            }
        }

        public static async Task CreateGitHubMilestone(this GitRepository repository, string title)
        {
            Assert.True(repository.IsGitHubRepository());
            await GitHubClient.Issue.Milestone.Create(
                repository.GetGitHubOwner(),
                repository.GetGitHubName(),
                new NewMilestone(title));
        }

        public static async Task CloseGitHubMilestone(this GitRepository repository, string title, bool enableIssueChecks = true)
        {
            Assert.True(repository.IsGitHubRepository());
            var milestone = (await repository.GetGitHubMilestone(title)).NotNull("milestone != null");

            if (enableIssueChecks)
            {
                Assert.True(milestone.OpenIssues == 0);
                Assert.True(milestone.ClosedIssues != 0);
            }

            await GitHubClient.Issue.Milestone.Update(
                repository.GetGitHubOwner(),
                repository.GetGitHubName(),
                milestone.Number,
                new MilestoneUpdate { State = ItemState.Closed });
        }

        public static bool IsGitHubRepository(this GitRepository repository)
        {
            return repository != null && repository.Endpoint.EqualsOrdinalIgnoreCase("github.com");
        }

        public static string GetGitHubOwner(this GitRepository repository)
        {
            Assert.True(repository.IsGitHubRepository());
            return repository.Identifier.Split('/')[0];
        }

        public static string GetGitHubName(this GitRepository repository)
        {
            Assert.True(repository.IsGitHubRepository());
            return repository.Identifier.Split('/')[1];
        }

        public static string GetGitHubCompareCommitsUrl(this GitRepository repository, string startCommitSha, string endCommitSha)
        {
            Assert.True(repository.IsGitHubRepository());
            return $"https://github.com/{repository.Identifier}/compare/{endCommitSha}^...{startCommitSha}";
        }

        public static string GetGitHubCompareTagToHeadUrl(this GitRepository repository, string tag)
        {
            Assert.True(repository.IsGitHubRepository());
            return $"https://github.com/{repository.Identifier}/compare/{tag}...HEAD";
        }

        public static string GetGitHubCompareTagsUrl(this GitRepository repository, string startTag, string endTag)
        {
            Assert.True(repository.IsGitHubRepository());
            return $"https://github.com/{repository.Identifier}/compare/{endTag}...{startTag}";
        }

        public static string GetGitHubCommitUrl(this GitRepository repository, string commitSha)
        {
            Assert.True(repository.IsGitHubRepository());
            return $"https://github.com/{repository.Identifier}/commit/{commitSha}";
        }

        /// <summary>Url in the form of <c>https://raw.githubusercontent.com/{identifier}/{branch}/{file}</c>.</summary>
        public static string GetGitHubDownloadUrl(this GitRepository repository, string file, string branch = null)
        {
            Assert.True(repository.IsGitHubRepository());

            branch ??= repository.Branch.NotNull("repository.Branch != null");
            var relativePath = GetRepositoryRelativePath(file, repository);
            return $"https://raw.githubusercontent.com/{repository.Identifier}/{branch}/{relativePath}";
        }

        /// <summary>
        /// Url in the form of <c>https://github.com/{identifier}/tree/{branch}/directory</c> or
        /// <c>https://github.com/{identifier}/blob/{branch}/file</c> depending on the item type.
        /// </summary>
        public static string GetGitHubBrowseUrl(
            this GitRepository repository,
            string path = null,
            string branch = null,
            GitHubItemType itemType = GitHubItemType.Automatic)
        {
            Assert.True(repository.IsGitHubRepository());

            branch ??= repository.Branch.NotNull();
            var relativePath = GetRepositoryRelativePath(path, repository);
            var method = GetMethod(relativePath, itemType, repository);
            Assert.True(path == null || method != null, "Could not determine item type");

            return $"https://github.com/{repository.Identifier}/{method}/{branch}/{relativePath}".TrimEnd("/");
        }

        [CanBeNull]
        private static string GetMethod([CanBeNull] string relativePath, GitHubItemType itemType, GitRepository repository)
        {
            var absolutePath = repository.LocalDirectory != null && relativePath != null
                ? NormalizePath(Path.Combine(repository.LocalDirectory, relativePath))
                : null;

            if (itemType == GitHubItemType.Directory || Directory.Exists(absolutePath) || relativePath == null)
                return "tree";

            if (itemType == GitHubItemType.File || File.Exists(absolutePath))
                return "blob";

            return null;
        }

        [ContractAnnotation("path: null => null; path: notnull => notnull")]
        private static string GetRepositoryRelativePath([CanBeNull] string path, GitRepository repository)
        {
            if (path == null)
                return null;

            if (!Path.IsPathRooted(path))
                return path;

            var localDirectory = repository.LocalDirectory.NotNull();
            Assert.True(IsDescendantPath(localDirectory, path), $"Path {path.SingleQuote()} must be descendant of {localDirectory:s}");
            return GetRelativePath(localDirectory, path).Replace(oldChar: '\\', newChar: '/');
        }
    }
}
