// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.Git
{
    public static partial class GitTasks
    {
        private static IProcess StartProcess(GitSettings toolSettings, ProcessSettings processSettings)
        {
            return ProcessTasks.StartProcess(
                toolSettings.ToolPath,
                toolSettings.Arguments,
                toolSettings.WorkingDirectory,
                processSettings?.EnvironmentVariables,
                processSettings?.ExecutionTimeout,
                processSettings?.RedirectOutput ?? false);
        }

        public static bool GitIsDetached()
        {
            return GitIsDetached(EnvironmentInfo.WorkingDirectory);
        }

        public static bool GitIsDetached(string workingDirectory)
        {
            var process = StartProcess(
                    new GitSettings()
                        .SetWorkingDirectory(workingDirectory)
                        .SetArguments("symbolic-ref --short -q HEAD"),
                    new ProcessSettings().EnableRedirectOutput())
                .AssertWaitForExit();

            return !process.Output.Any();
        }

        public static bool GitHasUncommitedChanges()
        {
            return GitHasUncommitedChanges(EnvironmentInfo.WorkingDirectory);
        }

        public static bool GitHasUncommitedChanges(string workingDirectory)
        {
            var process = StartProcess(
                    new GitSettings()
                        .SetWorkingDirectory(workingDirectory)
                        .SetArguments("status --short"),
                    new ProcessSettings().EnableRedirectOutput())
                .AssertZeroExitCode();
            return process.Output.Any();
        }
    }
}
