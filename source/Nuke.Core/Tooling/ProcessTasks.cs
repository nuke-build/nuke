// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;

[assembly: IconClass (typeof (ProcessTasks), "terminal")]

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    public static class ProcessTasks
    {
        /// <summary>
        /// Starts a process using <see cref="Process"/>.
        /// </summary>
        [CanBeNull]
        public static IProcess StartProcess (
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
        public static IProcess StartProcess (ToolSettings toolSettings, ProcessSettings processSettings = null)
        {
            return ProcessManager.Instance.StartProcess(toolSettings, processSettings);
        }
    }
}
