// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.Git
{
    public static partial class GitTasks
    {
        private static IProcess StartProcess (GitSettings toolSettings, ProcessSettings processSettings)
        {
            return ProcessTasks.StartProcess(
                    toolSettings.ToolPath,
                    toolSettings.Arguments,
                    toolSettings.WorkingDirectory,
                    processSettings?.EnvironmentVariables,
                    processSettings?.ExecutionTimeout,
                    processSettings?.RedirectOutput ?? false);
        }
    }
}
