namespace Nuke.Common.Git.Url.Model
{
    public sealed class NullGitUrl : IGitUrl
    {
        public string Endpoint => string.Empty;

        public string Identifier => string.Empty;

        public GitProtocol Protocol => GitProtocol.undef;

        public string Url => string.Empty;
    }

}
