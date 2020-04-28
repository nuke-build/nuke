using JetBrains.Annotations;
using Nuke.Common.Git.Url.Model;
using System;
using System.Text.RegularExpressions;

namespace Nuke.Common.Git.Url.Building
{

    public sealed class GitUrlParser
    {
        private static readonly Regex _regex =
                new Regex(@"^(?'protocol'(https|ssh|http|git)\:\/\/)?(?>(?'user'.*)@)?(?'endpoint'[^\/:]+)(?>\:(?'port'\d+))?[\/:](?'identifier'.*?)\/?(?>\.git)?$");

        [NotNull]
        private string GitUrl { get; }

        public GitUrlParser([NotNull] string gitUrl)
        {
            if (string.IsNullOrEmpty(gitUrl)) throw new ArgumentException("message", nameof(gitUrl));
            GitUrl = gitUrl.Trim();
        }

        public IGitUrl Parse()
        {
            var match = _regex.Match(GitUrl);
            ControlFlow.Assert(match.Success, $"Url '{GitUrl}' could not be parsed.");

            var protocol = From(match.Groups["protocol"].Value);

            return new GitUrl(
                match.Groups["endpoint"].Value,
                match.Groups["identifier"].Value,
                protocol
                 );
        }

        private static GitProtocol From (string protocol)
        {
            var trimmedProtocol = string.IsNullOrEmpty(protocol) ? string.Empty : protocol.Split(':')[0];
            return trimmedProtocol switch
            {
                "https" => GitProtocol.https,
                "http" => GitProtocol.http,
                "git" => GitProtocol.git,
                _ => GitProtocol.ssh,
            };
        }
    }
}
