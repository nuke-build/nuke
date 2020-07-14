// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.Bitrise;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.GitLab;
using Nuke.Common.CI.Jenkins;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.CI.TravisCI;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Git
{
    public enum GitProtocol
    {
        Https,
        Ssh
    }

    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class GitRepository
    {
        private static readonly Regex s_headRegex = new Regex("^ref: (?<reference>refs/heads/(?<branch>.*))");

        public static GitRepository FromUrl(string url, string branch = null)
        {
            var (protocol, endpoint, identifier) = GetRemoteFromUrl(url);
            return new GitRepository(
                protocol,
                endpoint,
                identifier,
                branch,
                localDirectory: null,
                head: null,
                commit: null,
                tags: null);
        }

        /// <summary>
        /// Obtains information from a local git repository. Auto-injection can be utilized via <see cref="GitRepositoryAttribute"/>.
        /// </summary>
        public static GitRepository FromLocalDirectory(string directory, string branch = null, string remote = null)
        {
            var rootDirectory = FileSystemTasks.FindParentDirectory(directory, x => x.GetDirectories(".git").Any());
            ControlFlow.Assert(rootDirectory != null, $"Could not find git directory for '{directory}'.");
            var gitDirectory = Path.Combine(rootDirectory, ".git");

            var (protocol, endpoint, identifier) = GetRemoteFromConfig(gitDirectory, remote ?? "origin");
            var head = GetHead(gitDirectory);
            var commit = GetCommitFromCI() ?? GetCommitFromHead(gitDirectory, head);
            var tags = GetTagsFromCommit(gitDirectory, commit);

            return new GitRepository(
                protocol,
                endpoint,
                identifier,
                branch ?? GetBranchFromCI() ?? GetBranchFromHead(head),
                rootDirectory,
                head,
                commit,
                tags);
        }

        internal static string GetBranchFromHead(string head)
        {
            var match = s_headRegex.Match(head);
            return match.Success ? match.Groups["branch"].Value : null;
        }

        internal static string GetCommitFromHead(string gitDirectory, string head)
        {
            var match = s_headRegex.Match(head);
            if (!match.Success)
                return head;

            var headRefFile = Path.Combine(gitDirectory, match.Groups["reference"].Value);
            ControlFlow.Assert(File.Exists(headRefFile), $"File.Exists({headRefFile})");
            return File.ReadAllLines(headRefFile).First();
        }

        private static string GetHead(string gitDirectory)
        {
            var headFile = Path.Combine(gitDirectory, "HEAD");
            ControlFlow.Assert(File.Exists(headFile), $"File.Exists({headFile})");
            return File.ReadAllText(headFile).Trim();
        }

        internal static string GetBranchFromCI()
        {
            return AppVeyor.Instance?.RepositoryBranch ??
                   Bitrise.Instance?.GitBranch ??
                   GitLab.Instance?.CommitRefName ??
                   Jenkins.Instance?.GitBranch ?? Jenkins.Instance?.BranchName ??
                   TeamCity.Instance?.BranchName ??
                   AzurePipelines.Instance?.SourceBranchName ??
                   TravisCI.Instance?.Branch ??
                   GitHubActions.Instance?.GitHubRef;
        }

        internal static string GetCommitFromCI()
        {
            return AppVeyor.Instance?.RepositoryCommitSha ??
                   Bitrise.Instance?.GitCommit ??
                   GitLab.Instance?.CommitSha ??
                   Jenkins.Instance?.GitCommit ??
                   TeamCity.Instance?.BuildVcsNumber ??
                   AzurePipelines.Instance?.SourceVersion ??
                   TravisCI.Instance?.Commit ??
                   GitHubActions.Instance?.GitHubSha;
        }

        private static IReadOnlyCollection<string> GetTagsFromCommit(string gitDirectory, string commit)
        {
            if (commit == null)
                return new string[0];

            var packedRefsFile = (AbsolutePath) gitDirectory / "packed-refs";
            var packedTags = File.Exists(packedRefsFile)
                ? File.ReadAllLines(packedRefsFile)
                    .Where(x => !x.StartsWith("#") && !x.StartsWith("^"))
                    .Select(x => x.Split(' '))
                    .Select(x => (Commit: x[0], Reference: x[1]))
                    .Where(x => x.Commit == commit && x.Reference.StartsWithOrdinalIgnoreCase("refs/tags"))
                    .Select(x => x.Reference.TrimStart("refs/tags/"))
                : new string[0];

            var tagsDirectory = (AbsolutePath) gitDirectory / "refs" / "tags";
            var localTags = tagsDirectory
                .GlobFiles("**/*")
                .Where(x => File.ReadAllText(x).Trim() == commit)
                .Select(x => tagsDirectory.GetUnixRelativePathTo(x).ToString());

            return localTags.Concat(packedTags).ToList();
        }

        private static (GitProtocol Protocol, string Endpoint, string Identifier) GetRemoteFromUrl(string url)
        {
            var regex = new Regex(
                @"^(?'protocol'\w+)?(\:\/\/)?(?>(?'user'.*)@)?(?'endpoint'[^\/:]+)(?>\:(?'port'\d+))?[\/:](?'identifier'.*?)\/?(?>\.git)?$");
            var match = regex.Match(url.NotNull("url != null").Trim());

            ControlFlow.Assert(match.Success, $"Url '{url}' could not be parsed.");
            var protocol = match.Groups["protocol"].Value.EqualsOrdinalIgnoreCase(GitProtocol.Https.ToString())
                ? GitProtocol.Https
                : GitProtocol.Ssh;
            return (protocol, match.Groups["endpoint"].Value, match.Groups["identifier"].Value);
        }

        private static (GitProtocol Protocol, string Endpoint, string Identifier) GetRemoteFromConfig(string gitDirectory, string remote)
        {
            var configFile = Path.Combine(gitDirectory, "config");
            var configFileContent = File.ReadAllLines(configFile);
            var url = configFileContent
                .Select(x => x.Trim())
                .SkipWhile(x => x != $"[remote \"{remote}\"]")
                .Skip(1)
                .TakeWhile(x => !x.StartsWith("["))
                .SingleOrDefault(x => x.StartsWithOrdinalIgnoreCase("url = "))
                ?.Split('=').ElementAt(1)
                .Trim();

            return GetRemoteFromUrl(url);
        }

        public GitRepository(
            GitProtocol protocol,
            string endpoint,
            string identifier,
            string branch,
            string localDirectory,
            string head,
            string commit,
            IReadOnlyCollection<string> tags)
        {
            Protocol = protocol;
            Endpoint = endpoint;
            Identifier = identifier;
            Branch = branch;
            LocalDirectory = localDirectory;
            Head = head;
            Commit = commit;
            Tags = tags;
        }

        /// <summary>Default protocol for the repository.</summary>
        public GitProtocol Protocol { get; private set; }

        /// <summary>Endpoint for the repository. For instance <em>github.com</em>.</summary>
        public string Endpoint { get; private set; }

        /// <summary>Identifier of the repository.</summary>
        public string Identifier { get; private set; }

        /// <summary>Local path from which the repository was parsed.</summary>
        [CanBeNull]
        public string LocalDirectory { get; private set; }

        /// <summary>Current head; <c>null</c> if parsed from URL.</summary>
        [CanBeNull]
        public string Head { get; private set; }

        /// <summary>Current commit; <c>null</c> if parsed from URL.</summary>
        public string Commit { get; }

        /// <summary>List of tags; <c>null</c> if parsed from URL.</summary>
        public IReadOnlyCollection<string> Tags { get; }

        /// <summary>Current branch; <c>null</c> if head is detached.</summary>
        [CanBeNull]
        public string Branch { get; private set; }

        /// <summary>Url in the form of <c>https://endpoint/identifier.git</c></summary>
        public string HttpsUrl => $"https://{Endpoint}/{Identifier}.git";

        /// <summary>Url in the form of <c>git@endpoint:identifier.git</c></summary>
        public string SshUrl => $"git@{Endpoint}:{Identifier}.git";

        public GitRepository SetBranch(string branch)
        {
            return new GitRepository(
                Protocol,
                Endpoint,
                Identifier,
                branch,
                LocalDirectory,
                Head,
                Commit,
                Tags);
        }

        public override string ToString()
        {
            return (Protocol == GitProtocol.Https ? HttpsUrl : SshUrl).TrimEnd(".git");
        }
    }
}
