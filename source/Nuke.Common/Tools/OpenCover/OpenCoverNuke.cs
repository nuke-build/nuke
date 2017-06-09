// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    public static partial class OpenCoverTasks
    {
        public static void OpenCover (OpenCoverSettings openCoverSettings, ProcessSettings processSettings = null)
        {
            var testAction = openCoverSettings.TestAction.NotNull("testAction != null");
            var capturedArguments = ProcessManager.Instance.CaptureProcessStartInfo(testAction);
            openCoverSettings = openCoverSettings
                    .SetTargetPath(capturedArguments.ToolPath)
                    .SetTargetArguments(capturedArguments.Arguments)
                    .SetTargetDirectory(capturedArguments.WorkingDirectory);

            var process = ProcessManager.Instance.StartProcess(openCoverSettings, processSettings);
            process.AssertZeroExitCode();
        }

        public static void OpenCover (Action testAction, OpenCoverSettings openCoverSettings = null, ProcessSettings processSettings = null)
        {
            openCoverSettings = openCoverSettings ?? new OpenCoverSettings();
            OpenCover(openCoverSettings.SetTestAction(testAction), processSettings);
        }

        public static void OpenCover (
            Action testAction,
            string outputPath,
            OpenCoverSettings openCoverSettings = null,
            ProcessSettings processSettings = null)
        {
            openCoverSettings = openCoverSettings ?? new OpenCoverSettings();
            OpenCover(testAction, openCoverSettings.SetOutput(outputPath), processSettings);
        }
    }
}
