using JetBrains.Annotations;
using Nuke.Common.Git.Url.Model;

namespace Nuke.Common.Git.Url.Building
{
    public sealed class GitUrlCreater
    {
        private readonly GitUrlBuilder _builder = new GitUrlBuilder();

        public string HttpsUrlFrom([NotNull] IGitUrl url)
        {
            if (url is null) throw new System.ArgumentNullException(nameof(url));

            return _builder.Reset().From(url).Protocol(GitProtocol.https).AsString();
        }

        public string GitUrlWithoutPrefix([NotNull] IGitUrl url)
        {
            if (url is null) throw new System.ArgumentNullException(nameof(url));

            return $"git@{url.Endpoint}:{url.Identifier}.git";
        }

        public IGitUrl From([NotNull] string url)
        {
            if (string.IsNullOrEmpty(url)) throw new System.ArgumentException("message", nameof(url));

            return new GitUrlParser(url).Parse();
        }
    }
}
