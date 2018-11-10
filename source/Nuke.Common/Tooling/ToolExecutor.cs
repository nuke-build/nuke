// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling
{
    internal class ToolExecutor
    {
        private readonly string _toolPath;

        public ToolExecutor(string toolPath)
        {
            _toolPath = toolPath;
        }

        public IReadOnlyCollection<Output> Execute(
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool logOutput = true,
            Func<string, LogLevel> logLevelParser = null,
            Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(
                _toolPath,
                arguments,
                workingDirectory,
                environmentVariables,
                timeout,
                logOutput,
                logLevelParser,
                outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
}
