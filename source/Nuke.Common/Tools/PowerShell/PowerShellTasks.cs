// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.PowerShell
{
    partial class PowerShellTasks
    {
        internal static string GetToolPath()
        {
            return ToolPathResolver.GetPathExecutable(EnvironmentInfo.IsWin ? "powershell" : "pwsh");
        }
    }

    partial class PowerShellSettings
    {
        private string GetProcessToolPath()
        {
            return PowerShellTasks.GetToolPath();
        }
    }
}
