// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
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
        public static GitRepository FromUrl(string url, string branch = null)
        {
            var (protocol, endpoint, identifier) = GetRemoteFromUrl(url);
            return new GitRepository(
                protocol,
                endpoint,
                identifier,
                branch,
                localDirectory: null,
                head: null);
        }

        /// <summary>
        /// Obtains information from a local git repository. Auto-injection can be utilized via <see cref="GitRepositoryAttribute"/>.
        /// </summary>
        public static GitRepository FromLocalDirectory(string directory, string branch = null, string remote = null)
        {
            var rootDirectory = FileSystemTasks.FindParentDirectory(directory, x => x.GetDirectories(".git").Any());
            ControlFlow.Assert(rootDirectory != null, $"Could not find git directory for '{directory}'.");
            var gitDirectory = Path.Combine(rootDirectory, ".git");

            var head = GetHead(gitDirectory);
            var (protocol, endpoint, identifier) = GetRemoteFromConfig(gitDirectory, remote ?? "origin");

            return new GitRepository(
                protocol,
                endpoint,
                identifier,
                branch ?? GetBranch(head),
                rootDirectory,
                head);
        }

        private static string GetHead(string gitDirectory)
        {
            var headFile = Path.Combine(gitDirectory, "HEAD");
            ControlFlow.Assert(File.Exists(headFile), $"File.Exists({headFile})");
            var headFileContent = File.ReadAllLines(headFile);
            return headFileContent.First();
        }

        private static string GetBranch(string head)
        {
            var match = Regex.Match(head, "^ref: refs/heads/(?<branch>.*)");
            return
                AppVeyor.Instance?.RepositoryBranch ??
                Bitrise.Instance?.GitBranch ??
                GitLab.Instance?.CommitRefName ??
                Jenkins.Instance?.GitBranch ??
                Jenkins.Instance?.BranchName ??
                TeamCity.Instance?.BranchName ??
                AzurePipelines.Instance?.SourceBranchName ??
                TravisCI.Instance?.Branch ??
                GitHubActions.Instance?.GitHubRef ??
                (match.Success ? match.Groups["branch"].Value : null);
        }

        private static (GitProtocol Protocol, string Endpoint, string Identifier) GetRemoteFromUrl(string url)
        {
            ControlFlow.Assert(url != null, $"Could not parse remote for '{url}'.");
            var regex = new Regex(
                @"^(?'protocol'\w+)?(\:\/\/)?(?>(?'user'.*)@)?(?'endpoint'[^\/:]+)(?>\:(?'port'\d+))?[\/:](?'identifier'.*?)\/?(?>\.git)?$");
            var match = regex.Match(url.Trim());

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
                .Skip(count: 1)
                .TakeWhile(x => !x.StartsWith("["))
                .SingleOrDefault(x => x.StartsWithOrdinalIgnoreCase("url = "))
                ?.Split('=')[1]
                .Trim();

            return GetRemoteFromUrl(url);
        }

        public GitRepository(
            GitProtocol protocol,
            string endpoint,
            string identifier,
            string branch,
            string localDirectory,
            string head)
        {
            Protocol = protocol;
            Endpoint = endpoint;
            Identifier = identifier;
            Branch = branch;
            LocalDirectory = localDirectory;
            Head = head;
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
                Head);
        }

        public override string ToString()
        {
            return (Protocol == GitProtocol.Https ? HttpsUrl : SshUrl).TrimEnd(".git");
        }
    }
}
