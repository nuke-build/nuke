// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverTasks
    {
        [CanBeNull]
        private static IProcess StartProcess (OpenCoverSettings toolSettings, ProcessSettings processSettings = null)
        {
            var testAction = toolSettings.TestAction.NotNull("testAction != null");
            var capturedStartInfo = ProcessTasks.CaptureProcessStartInfo(testAction);
            toolSettings = toolSettings
                    .SetTargetPath(capturedStartInfo.ToolPath)
                    .SetTargetArguments(capturedStartInfo.Arguments)
                    .SetTargetDirectory(capturedStartInfo.WorkingDirectory);

            return ProcessTasks.StartProcess(toolSettings, processSettings);
        }
    }
}
