// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverCoverSettingsExtensions
    {
        public static DotCoverCoverSettings SetTargetSettings(this DotCoverCoverSettings toolSettings, ToolSettings targetSettings)
        {
            return toolSettings
                .SetTargetExecutable(targetSettings.ToolPath)
                .SetTargetArguments(targetSettings.GetArguments().RenderForExecution())
                .SetTargetWorkingDirectory(targetSettings.WorkingDirectory);
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
