// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    public static partial class OpenCoverTasks
    {
        [CanBeNull]
        private static IProcess StartProcess (OpenCoverSettings openCoverSettings, ProcessSettings processSettings = null)
        {
            var testAction = openCoverSettings.TestAction.NotNull("testAction != null");
            var capturedArguments = ProcessManager.Instance.CaptureProcessStartInfo(testAction);
            openCoverSettings = openCoverSettings
                    .SetTargetPath(capturedArguments.ToolPath)
                    .SetTargetArguments(capturedArguments.Arguments)
                    .SetTargetDirectory(capturedArguments.WorkingDirectory);

            return ProcessManager.Instance.StartProcess(openCoverSettings, processSettings);
        }
    }
}
