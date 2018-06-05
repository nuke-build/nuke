// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Git
{
    public static partial class GitTasks
    {
        public static bool GitIsDetached()
        {
            return GitIsDetached(EnvironmentInfo.WorkingDirectory);
        }

        public static bool GitIsDetached(string workingDirectory)
        {
            return !Git("symbolic-ref --short -q HEAD", workingDirectory).Any();
        }

        public static bool GitHasUncommitedChanges()
        {
            return GitHasUncommitedChanges(EnvironmentInfo.WorkingDirectory);
        }

        public static bool GitHasUncommitedChanges(string workingDirectory)
        {
            return Git("status --short", workingDirectory).Any();
        }
    }
}
