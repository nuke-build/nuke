// Copyright 2018 Maintainers of NUKE.
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
            bool logOutput = true,
            Func<string, LogLevel> logLevelParser = null,
            Func<string, string> outputFilter = null)
        {
            return ProcessManager.Instance.StartProcess(toolPath,
                arguments,
                outputArguments: null,
                workingDirectory,
                environmentVariables,
                timeout,
                logOutput,
                logLevelParser,
                outputFilter);
        }

        /// <summary>
        /// Starts a process using <see cref="Process"/>.
        /// </summary>
        [CanBeNull]
        public static IProcess StartProcess(ToolSettings toolSettings)
        {
            return ProcessManager.Instance.StartProcess(toolSettings);
        }
    }
}
