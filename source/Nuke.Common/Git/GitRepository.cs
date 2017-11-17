// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.IO;
using Nuke.Core.Utilities;

namespace Nuke.Common.Git
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class GitRepository
    {
        /// <summary>
        /// Tries to parse a string to a valid <see cref="GitRepository" />.
        /// </summary>
        [CanBeNull]
        public static GitRepository TryParse (string directory)
        {
            var rootDirectory = FileSystemTasks.SearchDirectory(directory, x => x.GetDirectories(".git").Any());
            ControlFlow.Assert(rootDirectory != null, $"Could not locate '.git' directory while traversing up from '{directory}'.");
            var gitDirectory = Path.Combine(rootDirectory, ".git");

            var headFile = Path.Combine(gitDirectory, "HEAD");
            ControlFlow.Assert(File.Exists(headFile), $"File.Exists({headFile})");
            var headFileContent = File.ReadAllLines(headFile);
            var head = headFileContent.First();

            var configFile = Path.Combine(gitDirectory, "config");
            var configFileContent = File.ReadAllLines(configFile);
            var url = configFileContent
                    .Select(x => x.Trim())
                    .SkipWhile(x => x != "[remote \"origin\"]")
                    .Skip(count: 1)
                    .TakeWhile(x => !x.StartsWith("["))
                    .Single(x => x.StartsWithOrdinalIgnoreCase("url = "))
                    .Split('=')[1];

            var match = new[]
                        {
                            @"git@(?<endpoint>.*):(?<owner>.*)/(?<name>.*?)(\.git)?$",
                            @"https://(?<endpoint>.*)/(?<owner>.*)/(?<name>.*?)(\.git)?$"
                        }.Select(x => Regex.Match(url, x)).FirstOrDefault(x => x.Success);
            if (match == null)
                return null;
            var branchMatch = Regex.Match(head, "^ref: refs/heads/(?<branch>.*)");

            return new GitRepository
                   {
                       Endpoint = match.Groups["endpoint"].Value,
                       Owner = match.Groups["owner"].Value,
                       Name = match.Groups["name"].Value,
                       Head = head,
                       Branch = branchMatch.Success ? branchMatch.Groups["branch"].Value : null
                   };
        }

        /// <summary>The endpoint for the repository. For instance <em>github.com</em>.</summary>
        public string Endpoint { get; set; }

        /// <summary>The owner of the repository.</summary>
        public string Owner { get; set; }

        /// <summary>The name of the repository.</summary>
        public string Name { get; set; }

        /// <summary>A construction of <c>owner/name</c></summary>
        public string Identifier => $"{Owner.NotNull("Owner != null")}/{Name.NotNull("Name != null")}";

        /// <summary>Url in the form of <c>https://endpoint/identifier</c></summary>
        public string SvnUrl => $"https://{Endpoint.NotNull("Endpoint != Endpoint")}/{Identifier}";

        /// <summary>Url in the form of <c>https://endpoint/identifier.git</c></summary>
        public string CloneUrl => $"https://{Endpoint.NotNull("Endpoint != Endpoint")}/{Identifier}.git";

        /// <summary>Url in the form of <c>git://endpoint/identifier.git</c></summary>
        public string GitUrl => $"git://{Endpoint.NotNull("Endpoint != Endpoint")}/{Identifier}.git";

        /// <summary>Url in the form of <c>git@endpoint:identifier.git</c></summary>
        public string SshUrl => $"git@{Endpoint.NotNull("Endpoint != Endpoint")}:{Identifier}.git";

        /// <summary>Current head.</summary>
        public string Head { get; set; }

        /// <summary>Current branch. Null if head is detached.</summary>
        [CanBeNull]
        public string Branch { get; set; }

        public override string ToString ()
        {
            return CloneUrl;
        }
    }
}
