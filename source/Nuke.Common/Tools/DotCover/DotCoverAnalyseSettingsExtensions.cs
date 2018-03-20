// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverAnalyseSettingsExtensions
    {
        [Obsolete("Use " + nameof(SetTargetSettings) + " instead.")]
        public static DotCoverAnalyseSettings SetTestAction(this DotCoverAnalyseSettings toolSettings, Action testAction)
        {
            var capturedStartInfo = ProcessTasks.CaptureProcessStartInfo(testAction);
            return toolSettings
                .SetTargetExecutable(capturedStartInfo.ToolPath)
                .SetTargetArguments(capturedStartInfo.Arguments)
                .SetTargetWorkingDirectory(capturedStartInfo.WorkingDirectory);
        }

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
