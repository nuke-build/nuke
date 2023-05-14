// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling;

#if NET6_0_OR_GREATER
public delegate IReadOnlyCollection<Output> Tool(
    ref ArgumentStringHandler arguments,
    string workingDirectory = null,
    IReadOnlyDictionary<string, string> environmentVariables = null,
    int? timeout = null,
    bool? logOutput = null,
    bool? logInvocation = null,
    Action<OutputType, string> logger = null,
    Action<IProcess> exitHandler = null);
#else
public delegate IReadOnlyCollection<Output> Tool(
    string arguments,
    string workingDirectory = null,
    IReadOnlyDictionary<string, string> environmentVariables = null,
    int? timeout = null,
    bool? logOutput = null,
    bool? logInvocation = null,
    Action<OutputType, string> logger = null,
    Action<IProcess> exitHandler = null,
    Func<string, string> outputFilter = null);
#endif
