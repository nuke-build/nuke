// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverAnalyseSettingsExtensions
    {
        public static DotCoverAnalyseSettings SetTargetSettings(this DotCoverAnalyseSettings toolSettings, ToolSettings targetSettings)
        {
            return toolSettings
                .SetTargetExecutable(targetSettings.ToolPath)
                .SetTargetArguments(targetSettings.GetArguments().RenderForExecution())
                .SetTargetWorkingDirectory(targetSettings.WorkingDirectory);
        }

        public static DotCoverAnalyseSettings ResetTargetSettings(this DotCoverAnalyseSettings toolSettings)
        {
            return toolSettings
                .ResetTargetExecutable()
                .ResetTargetArguments()
                .ResetTargetWorkingDirectory();
        }
    }
}
