// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.BuildServers
{
    [PublicAPI]
    public enum TeamServicesRepositoryType
    {
        /// <summary>
        /// <a href="https://docs.microsoft.com/en-us/vsts/git/overview">TFS Git repository</a>.
        /// </summary>
        TfsGit,

        /// <summary>
        /// <a href="https://docs.microsoft.com/en-us/vsts/tfvc/overview">Team Foundation Version Control</a>.
        /// </summary>
        TfsVersionControl,

        /// <summary>
        /// Git repository hosted on an external server.
        /// </summary>
        Git,

        /// <summary>
        /// Git repository hosted on GitHub.
        /// </summary>
        GitHub,

        /// <summary>
        /// Subversion.
        /// </summary>
        Svn
    }
}
