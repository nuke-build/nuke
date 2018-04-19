// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.BuildServers
{
    [PublicAPI]
    public enum TeamServicesBuildReason
    {
        /// <summary>A user manually queued the build.</summary>
        Manual,

        /// <summary><b>Continuous integration (CI)</b> triggered by a Git push or a TFVC check-in.</summary>
        IndividualCI,

        /// <summary><b>Continuous integration (CI)</b> triggered by a Git push or a TFVC check-in, and the <b>Batch changes</b> was selected.</summary>
        BatchedCI,

        /// <summary><b>Scheduled</b> trigger.</summary>
        Schedule,

        /// <summary>A user manually queued the build of a specific TFVC shelveset.</summary>
        ValidateShelveset,

        /// <summary><b>Gated check-in</b> trigger.</summary>
        CheckInShelveset,

        /// <summary>The build was triggered by a Git branch policy that requires a build.</summary>
        PullRequest
    }
}
