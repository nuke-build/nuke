// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling
{
    public delegate IReadOnlyCollection<Output> Tool(
        string arguments = null,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        string logFile = null,
        Action<OutputType, string> customLogger = null,
        Func<string, string> outputFilter = null);
}
