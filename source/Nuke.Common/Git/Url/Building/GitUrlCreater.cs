using Nuke.Common.Git.Url.Model;

namespace Nuke.Common.Git.Url.Building
{
    public sealed class GitUrlCreater
    {
        private readonly GitUrlBuilder _builder = new GitUrlBuilder();

        public string HttpsUrlFrom(IGitUrl url)
        {
            return _builder.Reset().From(url).Protocol(GitProtocol.ssh).AsString();
        }
        public string GitUrlWithoutPrefix(IGitUrl url)
        {
            return $"git@{url.Endpoint}/{url.Identifier}";
        }

        public IGitUrl From(string url)
        {
            return new GitUrlParser(url).Parse();
        }
    }
}
