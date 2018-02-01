// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    public static partial class DotCoverTasks
    {
        [CanBeNull]
        private static IProcess StartProcess(DotCoverAnalyseSettings toolSettings, ProcessSettings processSettings)
        {
            var testAction = toolSettings.TestAction.NotNull("testAction != null");
            var capturedStartInfo = ProcessTasks.CaptureProcessStartInfo(testAction);
            toolSettings = toolSettings
                .SetTargetExecutable(capturedStartInfo.ToolPath)
                .SetTargetArguments(capturedStartInfo.Arguments)
                .SetTargetWorkingDirectory(capturedStartInfo.WorkingDirectory);

            return ProcessTasks.StartProcess(toolSettings, processSettings);
        }
    }
}
