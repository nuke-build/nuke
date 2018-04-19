// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.Git
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class GitRepository
    {
        public static GitRepository FromUrl(string url, string branch = null)
        {
            var (endpoint, identifier) = ParseUrl(url);
            return new GitRepository(endpoint, identifier, branch: branch);
        }

        /// <summary>
        /// Obtains information from a local git repository. Auto-injection can be utilized via <see cref="GitRepositoryAttribute"/>.
        /// </summary>
        public static GitRepository FromLocalDirectory(string directory, string branch = null, string remote = "origin")
        {
            var rootDirectory = FileSystemTasks.FindParentDirectory(directory, x => x.GetDirectories(".git").Any());
            ControlFlow.Assert(rootDirectory != null, $"Could not find root directory for '{directory}'.");
            var gitDirectory = Path.Combine(rootDirectory, ".git");

            var headFile = Path.Combine(gitDirectory, "HEAD");
            ControlFlow.Assert(File.Exists(headFile), $"File.Exists({headFile})");
            var headFileContent = File.ReadAllLines(headFile);
            var head = headFileContent.First();
            var branchMatch = Regex.Match(head, "^ref: refs/heads/(?<branch>.*)");

            var configFile = Path.Combine(gitDirectory, "config");
            var configFileContent = File.ReadAllLines(configFile);
            var url = configFileContent
                .Select(x => x.Trim())
                .SkipWhile(x => x != $"[remote \"{remote}\"]")
                .Skip(count: 1)
                .TakeWhile(x => !x.StartsWith("["))
                .SingleOrDefault(x => x.StartsWithOrdinalIgnoreCase("url = "))
                ?.Split('=')[1];
            ControlFlow.Assert(url != null, $"Could not parse remote URL for '{remote}'.");

            var (endpoint, identifier) = ParseUrl(url);

            return new GitRepository(
                endpoint,
                identifier,
                rootDirectory,
                head,
                branch ?? (branchMatch.Success ? branchMatch.Groups["branch"].Value : null));
        }

        private static (string endpoint, string identifier) ParseUrl(string url)
        {
            var match = new[]
                        {
                            @"git@(?<endpoint>[^:/]+?)(:|/)(?<identifier>.+?)/?(\.git)?$",
                            @"^https://([^:]+:[^:@]+@)?(?<endpoint>[^/]+?)/(?<identifier>.+?)/?(\.git)?$"
                        }
                .Select(x => Regex.Match(url.Trim(), x))
                .FirstOrDefault(x => x.Success);
            ControlFlow.Assert(match != null, $"Url '{url}' could not be parsed.");

            return (match.Groups["endpoint"].Value, match.Groups["identifier"].Value);
        }

        public GitRepository(
            string endpoint,
            string identifier,
            string localDirectory = null,
            string head = null,
            string branch = null)
        {
            Endpoint = endpoint;
            Identifier = identifier;
            LocalDirectory = localDirectory;
            Head = head;
            Branch = branch;
        }

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

        public override string ToString()
        {
            return HttpsUrl.TrimEnd(".git");
        }
    }
}
