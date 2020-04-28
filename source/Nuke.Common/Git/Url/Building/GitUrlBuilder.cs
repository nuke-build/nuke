using Nuke.Common.Git.Url.Model;
using System;

namespace Nuke.Common.Git.Url.Building
{
    public sealed class GitUrlBuilder
    {
        private IGitUrl _url;
        public GitUrlBuilder From(IGitUrl url)
        {
            _url = url ?? throw new ArgumentNullException(nameof(url));
            return this;
        }

        public GitUrlBuilder Protocol(GitProtocol gitProtocol)
        {
            _url = new GitUrl(_url.Endpoint, _url.Identifier, gitProtocol);
            return this;
        }

        public GitUrlBuilder Endpoint(string endpoint)
        {
            _url = new GitUrl(endpoint, _url.Identifier, _url.Protocol);
            return this;
        }
        public GitUrlBuilder Identifier(string identifier)
        {
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
