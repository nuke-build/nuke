// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverCoverSettingsExtensions
    {
        public static DotCoverCoverSettings SetTargetSettings(this DotCoverCoverSettings toolSettings, ToolSettings targetSettings)
        {
            return toolSettings
                .SetTargetExecutable(targetSettings.ProcessToolPath)
                .SetTargetArguments(targetSettings.GetProcessArguments().RenderForExecution())
                .SetTargetWorkingDirectory(targetSettings.ProcessWorkingDirectory);
        }

        public static DotCoverCoverSettings ResetTargetSettings(this DotCoverCoverSettings toolSettings)
        {
            return toolSettings
                .ResetTargetExecutable()
                .ResetTargetArguments()
                .ResetTargetWorkingDirectory();
        }
    }
}
