// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ProcessTasks
    {
        /// <summary>
        /// Starts a process using <see cref="Process"/>.
        /// </summary>
        [CanBeNull]
        public static IProcess StartProcess(
            string toolPath,
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool redirectOutput = false,
            Func<string, string> outputFilter = null)
        {
            return ProcessManager.Instance.StartProcess(toolPath,
                arguments,
                workingDirectory,
                environmentVariables,
                timeout,
                redirectOutput,
                outputFilter);
        }

        /// <summary>
        /// Starts a process using <see cref="Process"/>.
        /// </summary>
        [CanBeNull]
        public static IProcess StartProcess(ToolSettings toolSettings, ProcessSettings processSettings = null)
        {
            return ProcessManager.Instance.StartProcess(toolSettings, processSettings);
        }

        public static CapturedProcessStartInfo CaptureProcessStartInfo(Action action)
        {
            return ProcessManager.Instance.CaptureProcessStartInfo(action);
        }
    }
}
