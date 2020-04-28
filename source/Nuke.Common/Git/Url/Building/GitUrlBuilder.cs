using JetBrains.Annotations;
using Nuke.Common.Git.Url.Model;
using System;

namespace Nuke.Common.Git.Url.Building
{
    public sealed class GitUrlBuilder
    {
        private IGitUrl _url;
        public GitUrlBuilder From([NotNull] IGitUrl url)
        {
            _url = url ?? throw new ArgumentNullException(nameof(url));
            return this;
        }

        public GitUrlBuilder Protocol(GitProtocol gitProtocol)
        {
            _url = new GitUrl(_url.Endpoint, _url.Identifier, gitProtocol);
            return this;
        }

        public GitUrlBuilder Endpoint([NotNull] string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint)) throw new ArgumentException("message", nameof(endpoint));

            _url = new GitUrl(endpoint, _url.Identifier, _url.Protocol);
            return this;
        }
        public GitUrlBuilder Identifier([NotNull] string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) throw new ArgumentException("message", nameof(identifier));

            _url = new GitUrl(_url.Endpoint, identifier, _url.Protocol);
            return this;
        }
        public GitUrlBuilder Reset()
        {
            _url = new NullGitUrl();
            return this;
        }

        public string AsString()
        {
            return _url.Url;
        }
    }
}
