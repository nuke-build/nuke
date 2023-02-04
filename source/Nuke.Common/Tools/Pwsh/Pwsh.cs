// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Pwsh
{
    partial class PwshTasks
    {
        internal static string GetToolPath()
        {
            return ToolPathResolver.GetPathExecutable("pwsh");
        }
    }

    partial class PwshSettings
    {
        private string GetProcessToolPath()
        {
            return PwshTasks.GetToolPath();
        }
    }
}
