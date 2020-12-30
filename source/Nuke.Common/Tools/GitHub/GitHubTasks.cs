// Copyright 2019 Maintainers of NUKE.
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
    [PublicAPI]
    public static class GitHubTasks
    {
        public static GitHubClient GitHubClient;

        private static GitHubClient Client =>
            GitHubClient ??= new GitHubClient(new ProductHeaderValue(nameof(NukeBuild)));

        public static async Task<IEnumerable<(string DownloadUrl, string RelativePath)>> GetGitHubDownloadUrls(
            this GitRepository repository,
            string directory = null,
            string branch = null)
        {
            ControlFlow.Assert(repository.IsGitHubRepository(), "repository.IsGitHubRepository()");
            ControlFlow.Assert(!HasPathRoot(directory) || repository.LocalDirectory != null,
                "!HasPathRoot(directory) || repository.LocalDirectory != null");

            var relativeDirectory = HasPathRoot(directory)
                ? GetRelativePath(repository.LocalDirectory, directory)
                : directory;
            relativeDirectory = (relativeDirectory + "/").TrimStart("/");

            branch ??= await repository.GetDefaultBranch();
            var treeResponse = await Client.Git.Tree.GetRecursive(
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
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            var repo = await Client.Repository.Get(repository.GetGitHubOwner(), repository.GetGitHubName());
            return repo.DefaultBranch;
        }

        public static async Task<string> GetLatestRelease(this GitRepository repository, bool includePrerelease = false, bool trimPrefix = false)
        {
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            var releases = await Client.Repository.Release.GetAll(repository.GetGitHubOwner(), repository.GetGitHubName());
            return releases.First(x => !x.Prerelease || includePrerelease).TagName.TrimStart(trimPrefix ? "v" : string.Empty);
        }

        [ItemCanBeNull]
        public static async Task<Milestone> GetGitHubMilestone(this GitRepository repository, string name)
        {
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            var milestones = await Client.Issue.Milestone.GetAllForRepository(
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
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            await Client.Issue.Milestone.Create(
                repository.GetGitHubOwner(),
                repository.GetGitHubName(),
                new NewMilestone(title));
        }

        public static async Task CloseGitHubMilestone(this GitRepository repository, string title, bool enableIssueChecks = true)
        {
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            var milestone = (await repository.GetGitHubMilestone(title)).NotNull("milestone != null");

            if (enableIssueChecks)
            {
                ControlFlow.Assert(milestone.OpenIssues == 0, "milestone.OpenIssues == 0");
                ControlFlow.Assert(milestone.ClosedIssues != 0, "milestone.ClosedIssues != 0");
            }

            await Client.Issue.Milestone.Update(
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
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            return repository.Identifier.Split('/')[0];
        }

        public static string GetGitHubName(this GitRepository repository)
        {
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            return repository.Identifier.Split('/')[1];
        }

        /// <summary>Url in the form of <c>https://raw.githubusercontent.com/{identifier}/{branch}/{file}</c>.</summary>
        public static string GetGitHubDownloadUrl(this GitRepository repository, string file, string branch = null)
        {
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

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
            ControlFlow.Assert(repository.IsGitHubRepository(), text: "repository.IsGitHubRepository()");

            branch ??= repository.Branch.NotNull("repository.Branch != null");
            var relativePath = GetRepositoryRelativePath(path, repository);
            var method = GetMethod(relativePath, itemType, repository);
            ControlFlow.Assert(path == null || method != null, text: "Could not determine item type.");

            return $"https://github.com/{repository.Identifier}/{method}/{branch}/{relativePath}";
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

            ControlFlow.Assert(IsDescendantPath(repository.LocalDirectory.NotNull("repository.LocalDirectory != null"), path),
                $"PathConstruction.IsDescendantPath({repository.LocalDirectory}, {path})");
            return GetRelativePath(repository.LocalDirectory, path).Replace(oldChar: '\\', newChar: '/');
        }
    }
}
