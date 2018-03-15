// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverSettingsExtensions
    {
        [Obsolete("Use " + nameof(SetTargetSettings) + " instead.")]
        public static OpenCoverSettings SetTestAction(this OpenCoverSettings toolSettings, Action testAction)
        {    
            var capturedStartInfo = ProcessTasks.CaptureProcessStartInfo(testAction);
            return toolSettings
                .SetTargetPath(capturedStartInfo.ToolPath)
                .SetTargetArguments(capturedStartInfo.Arguments)
                .SetTargetDirectory(capturedStartInfo.WorkingDirectory);
        }

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
