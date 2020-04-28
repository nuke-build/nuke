using JetBrains.Annotations;
using System;

namespace Nuke.Common.Git.Url.Model
{

    /// <summary>
    /// Acts as value type data only class for GitUrl information.
    /// </summary>
    public class GitUrl : IEquatable<GitUrl>, IGitUrl
    {
        public GitUrl(
            string endpoint,
            string identifier,
            GitProtocol protocol)
        {
            if (string.IsNullOrEmpty(endpoint)) throw new ArgumentException("message", nameof(endpoint));
            if (string.IsNullOrEmpty(identifier)) throw new ArgumentException("message", nameof(identifier));

            Endpoint = endpoint;
            Identifier = identifier;
            Protocol = protocol;
        }

        [NotNull]
        public string Endpoint { get; }

        [NotNull]
        public string Identifier { get; }

        public GitProtocol Protocol { get; }

        public string Url => $"{Protocol}://{Endpoint}/{Identifier}.git";


        #region IEquatable

        public override bool Equals(object other)
        {
            return Equals(other as GitUrl);
        }

        public bool Equals(GitUrl other)
        {
            return other != null &&
                   Endpoint == other.Endpoint &&
                   Identifier == other.Identifier &&
                   Protocol == other.Protocol;
        }

        public override int GetHashCode()
        {
            return Endpoint.GetHashCode() ^ Identifier.GetHashCode() ^ Protocol.GetHashCode();
        }

        public static bool operator ==(GitUrl a, GitUrl b)
        {
            return (
                    a is null &&
                    b is null
                   ) ||
                   (
                    a is object && a.Equals(b)
                   );
        }

        public static bool operator !=(GitUrl a, GitUrl b)
        {
            return !(a == b);
        }
        #endregion
    }
}
