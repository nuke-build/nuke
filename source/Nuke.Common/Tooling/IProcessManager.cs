// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public interface IProcessManager
    {
        [CanBeNull]
        IProcess StartProcess(ToolSettings toolSettings);

        [CanBeNull]
        IProcess StartProcess(
            string toolPath,
            string executionArguments = null,
            string outputArguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool logOutput = true,
            Func<string, LogLevel> logLevelParser = null,
            Func<string, string> outputFilter = null);
    }
}
