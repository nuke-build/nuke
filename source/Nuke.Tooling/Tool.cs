// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling
{
    public delegate IReadOnlyCollection<Output> Tool(
#if NET6_0_OR_GREATER
        ref ArgumentStringHandler arguments,
#else
        string arguments = null,
#endif
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        Action<OutputType, string> customLogger = null,
        Func<string, string> outputFilter = null);
}
