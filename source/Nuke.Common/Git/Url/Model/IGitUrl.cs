namespace Nuke.Common.Git.Url.Model
{
    public interface IGitUrl
    {
        string Endpoint { get; }

        string Identifier { get; }

        GitProtocol Protocol { get; }

        string Url { get; }

    }

}
