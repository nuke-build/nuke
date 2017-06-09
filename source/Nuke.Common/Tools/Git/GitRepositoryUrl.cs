// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Core;

namespace Nuke.Common.Tools.Git
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class GitRepositoryUrl
    {
        /// <summary>
        /// Tries to parse a string to a valid <see cref="GitRepositoryUrl" />.
        /// </summary>
        [CanBeNull]
        public static GitRepositoryUrl TryParse (string url)
        {
            var patterns =
                    new[]
                    {
                        @"git@(?<endpoint>.*):(?<owner>.*)/(?<name>.*)(\.git)?",
                        @"https://(?<endpoint>.*)/(?<owner>.*)/(?<name>.*)(\.git)?"
                    };

            var match = patterns.Select(x => Regex.Match(url, x)).FirstOrDefault(x => x.Success);
            if (match == null)
                return null;

            return new GitRepositoryUrl
                   {
                       Endpoint = match.Groups["endpoint"].Value,
                       Owner = match.Groups["owner"].Value,
                       Name = match.Groups["name"].Value
                   };
        }

        /// <summary>The endpoint for the repository. For instance <i>github.com</i>.</summary>
        public string Endpoint { get; set; }
        /// <summary>The owner of the repository.</summary>
        public string Owner { get; set; }
        /// <summary>The name of the repository.</summary>
        public string Name { get; set; }

        /// <summary>A construction of <c>owner/name</c></summary>
        public string Identifier => $"{Owner.AssertNotNull("Owner != null")}/{Name.AssertNotNull("Repository != null")}";

        /// <summary>Url in the form of <c>https://endpoint/identifier</c></summary>
        public string SvnUrl => $"https://{Endpoint.AssertNotNull("Endpoint != Endpoint")}/{Identifier}";
        /// <summary>Url in the form of <c>https://endpoint/identifier.git</c></summary>
        public string CloneUrl => $"https://{Endpoint.AssertNotNull("Endpoint != Endpoint")}/{Identifier}.git";
        /// <summary>Url in the form of <c>git://endpoint/identifier.git</c></summary>
        public string GitUrl => $"git://{Endpoint.AssertNotNull("Endpoint != Endpoint")}/{Identifier}.git";
        /// <summary>Url in the form of <c>git@endpoint:identifier.git</c></summary>
        public string SshUrl => $"git@{Endpoint.AssertNotNull("Endpoint != Endpoint")}:{Identifier}.git";

        public override string ToString ()
        {
            return CloneUrl;
        }
    }
}
