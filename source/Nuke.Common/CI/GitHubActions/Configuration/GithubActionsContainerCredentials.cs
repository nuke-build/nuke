// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    /// <summary>
    /// Github Actions container credentials <see href="https://docs.github.com/en/actions/learn-github-actions/workflow-syntax-for-github-actions#jobsjob_idcontainercredentials">documentation</see>
    /// </summary>
    [PublicAPI]
    public class GithubActionsContainerCredentials : ConfigurationEntity
    {
        /// <summary>
        /// Both <see cref="Username"/> and <see cref="Password"/> should be a secret
        /// </summary>
        /// <param name="username">Username. Use a secret</param>
        /// <param name="password">Password. Use a secret</param>
        public GithubActionsContainerCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("credentials:");

            using (writer.Indent())
            {
                writer.WriteLine($"username: ${{{{ {Username} }}}}");
                writer.WriteLine($"password: ${{{{ {Password} }}}}");
            }
        }
    }
}
