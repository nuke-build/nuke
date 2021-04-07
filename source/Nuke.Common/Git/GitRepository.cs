// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

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
        private const string FallbackRemoteName = "origin";

        public static GitRepository FromUrl(string url, string branch = null)
        {
            var (protocol, endpoint, identifier) = GetRemoteConnectionFromUrl(url);
            return new GitRepository(
                protocol,
                endpoint,
                identifier,
                branch,
                localDirectory: null,
                head: null,
                commit: null,
                tags: null,
                remoteName: null,
                remoteBranch: null);
        }

        /// <summary>
        /// Obtains information from a local git repository. Auto-injection can be utilized via <see cref="GitRepositoryAttribute"/>.
        /// </summary>
        public static GitRepository FromLocalDirectory(string directory)
        {
            var rootDirectory = FileSystemTasks.FindParentDirectory(directory, x => x.GetDirectories(".git").Any());
            ControlFlow.Assert(rootDirectory != null, $"Could not find git directory for '{directory}'.");
            var gitDirectory = Path.Combine(rootDirectory, ".git");

            var head = GetHead(gitDirectory);
            var branch = ((Host.Instance as IBuildServer)?.Branch ?? GetHeadIfAttached(head))?.TrimStart("refs/heads/").TrimStart("origin/");
            var commit = (Host.Instance as IBuildServer)?.Commit ?? GetCommitFromHead(gitDirectory, head);
            var tags = GetTagsFromCommit(gitDirectory, commit);
            var (remoteName, remoteBranch) = GetRemoteNameAndBranch(gitDirectory, branch);
            var (protocol, endpoint, identifier) = GetRemoteConnectionFromConfig(gitDirectory, remoteName ?? FallbackRemoteName);

            return new GitRepository(
                protocol,
                endpoint,
                identifier,
                branch,
                rootDirectory,
                head,
                commit,
                tags,
                remoteName,
                remoteBranch);
        }

        private static (string Name, string Branch) GetRemoteNameAndBranch(string gitDirectory, [CanBeNull] string branch)
        {
            if (branch == null)
                return (null, null);

            var configFile = Path.Combine(gitDirectory, "config");
            var configFileContent = File.ReadAllLines(configFile);
            var data = configFileContent
                .Select(x => x.Trim())
                .SkipWhile(x => x != $"[branch {branch.DoubleQuote()}]")
                .Skip(1)
                .TakeWhile(x => !x.StartsWith("["))
                .Select(x => x.Split('='))
                .ToDictionary(x => x.ElementAt(0).Trim(), x => x.ElementAt(1).Trim());
            return data.Count == 2
                ? (data["remote"], data["merge"].TrimStart("refs/heads/"))
                : (null, null);
        }

        internal static string GetHeadIfAttached(string head)
        {
            return head.StartsWith("refs/heads/") ? head : null;
        }

        internal static string GetCommitFromHead(string gitDirectory, string head)
        {
            if (!head.StartsWith("refs/heads/"))
                return head;

            var headRefFile = Path.Combine(gitDirectory, head);
            ControlFlow.Assert(File.Exists(headRefFile), $"File.Exists({headRefFile})");
            return File.ReadAllLines(headRefFile).First();
        }

        private static string GetHead(string gitDirectory)
        {
            var headFile = Path.Combine(gitDirectory, "HEAD");
            ControlFlow.Assert(File.Exists(headFile), $"File.Exists({headFile})");
            return File.ReadAllText(headFile).TrimStart("ref: ").Trim();
        }

        [CanBeNull]
        internal static string GetBranchFromCI()
        {
            return (Host.Instance as IBuildServer)?.Branch;
        }

        [CanBeNull]
        internal static string GetCommitFromCI()
        {
            return (Host.Instance as IBuildServer)?.Commit;
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

        private static (GitProtocol Protocol, string Endpoint, string Identifier) GetRemoteConnectionFromUrl(string url)
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

        private static (GitProtocol Protocol, string Endpoint, string Identifier) GetRemoteConnectionFromConfig(string gitDirectory, string remote)
        {
            var configFile = Path.Combine(gitDirectory, "config");
            var configFileContent = File.ReadAllLines(configFile);
            var url = configFileContent
                .Select(x => x.Trim())
                .SkipWhile(x => x != $"[remote {remote.DoubleQuote()}]")
                .Skip(1)
                .TakeWhile(x => !x.StartsWith("["))
                .SingleOrDefault(x => x.StartsWithOrdinalIgnoreCase("url = "))
                ?.Split('=').ElementAt(1)
                .Trim();

            return GetRemoteConnectionFromUrl(url);
        }

        public GitRepository(
            GitProtocol protocol,
            string endpoint,
            string identifier,
            string branch,
            string localDirectory,
            string head,
            string commit,
            IReadOnlyCollection<string> tags,
            string remoteName,
            string remoteBranch)
        {
            Protocol = protocol;
            Endpoint = endpoint;
            Identifier = identifier;
            Branch = branch;
            LocalDirectory = localDirectory;
            Head = head;
            Commit = commit;
            Tags = tags;
            RemoteName = remoteName;
            RemoteBranch = remoteBranch;
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

        /// <summary>Name of the remote.</summary>
        public string RemoteName { get; }

        /// <summary>Name of the remote branch.</summary>
        public string RemoteBranch { get; }

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
                Tags,
                RemoteName,
                RemoteBranch);
        }

        public override string ToString()
        {
            return (Protocol == GitProtocol.Https ? HttpsUrl : SshUrl).TrimEnd(".git");
        }
    }
}
