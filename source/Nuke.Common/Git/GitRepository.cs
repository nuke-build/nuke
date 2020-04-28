// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.Git.Url.Building;
using Nuke.Common.Git.Url.Model;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.Git
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class GitRepository
    {
        private readonly GitUrlCreater _gitUrlCreator = new GitUrlCreater();

        public static GitRepository FromUrl(string url, string branch = null)
        {
            return new GitRepository(
                new GitUrlCreater().From(url),
                branch: branch);
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
                ?.Split('=')[1]
                .Trim();
            ControlFlow.Assert(url != null, $"Could not parse remote URL for '{remote}'.");

            return new GitRepository(
                new GitUrlParser(url).Parse(),
                rootDirectory,
                head,
                branch ?? (branchMatch.Success ? branchMatch.Groups["branch"].Value : null));
        }

        public GitRepository(
            IGitUrl url,
            string localDirectory = null,
            string head = null,
            string branch = null)
        {
            Url = url;
            LocalDirectory = localDirectory;
            Head = head;
            Branch = branch;
        }


        [NotNull]
        public IGitUrl Url { get; }

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
        [NotNull]
        public string HttpsUrl => _gitUrlCreator.HttpsUrlFrom(Url);

        /// <summary>Url in the form of <c>git@endpoint:identifier.git</c></summary>
        [NotNull]
        public string SshUrl => _gitUrlCreator.GitUrlWithoutPrefix(Url);

        public GitRepository SetBranch(string branch)
        {
            return new GitRepository(Url, LocalDirectory, Head, branch);
        }

        public override string ToString()
        {
            return HttpsUrl.TrimEnd(".git");
        }
    }
}
