// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.Git
{
    partial class GitTasks
    {
        public static bool GitIsDetached()
        {
            return GitIsDetached(workingDirectory: null);
        }

        public static bool GitIsDetached(string workingDirectory)
        {
            return !Git($"branch --show-current", workingDirectory, logOutput: false).Any();
        }

        public static bool GitHasCleanWorkingCopy()
        {
            return GitHasCleanWorkingCopy(workingDirectory: null);
        }

        public static bool GitHasCleanWorkingCopy(string workingDirectory)
        {
            return !Git($"status --short", workingDirectory, logOutput: false).Any();
        }

        public static string GitCurrentBranch()
        {
            return GitCurrentBranch(workingDirectory: null);
        }

        public static string GitCurrentBranch(string workingDirectory)
        {
            return Git($"rev-parse --abbrev-ref HEAD", workingDirectory, logOutput: false).Select(x => x.Text).Single();
        }

        public static string GitCurrentCommit()
        {
            return GitCurrentCommit(workingDirectory: null);
        }

        public static string GitCurrentCommit(string workingDirectory)
        {
            return Git($"rev-parse HEAD", workingDirectory, logOutput: false).Select(x => x.Text).Single();
        }
    }
}
