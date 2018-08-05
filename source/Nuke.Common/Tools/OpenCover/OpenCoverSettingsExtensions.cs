// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverSettingsExtensions
    {
        public static OpenCoverSettings SetTargetSettings(this OpenCoverSettings toolSettings, ToolSettings targetSettings)
        {
            return toolSettings
                .SetTargetPath(targetSettings.ToolPath)
                .SetTargetArguments(targetSettings.GetArguments().RenderForExecution())
                .SetTargetDirectory(targetSettings.WorkingDirectory);
        }

        public static OpenCoverSettings ResetTargetSettings(this OpenCoverSettings toolSettings)
        {
            return toolSettings
                .ResetTargetPath()
                .ResetTargetArguments()
                .ResetTargetDirectory();
        }
    }
}
