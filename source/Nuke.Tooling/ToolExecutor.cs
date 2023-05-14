// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling;

internal class ToolExecutor
{
    private readonly string _toolPath;

    public ToolExecutor(string toolPath)
    {
        _toolPath = toolPath;
    }

#if NET6_0_OR_GREATER
    public IReadOnlyCollection<Output> Execute(
        ref ArgumentStringHandler arguments,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        Action<OutputType, string> customLogger = null,
        Action<IProcess> exitHandler = null)
    {
        var process = ProcessTasks.StartProcess(
            _toolPath,
            ref arguments,
            workingDirectory,
            environmentVariables,
            timeout,
            logOutput,
            logInvocation,
            customLogger);
#else
    public IReadOnlyCollection<Output> Execute(
        string arguments,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        Action<OutputType, string> customLogger = null,
        Action<IProcess> exitHandler = null,
        Func<string, string> outputFilter = null)
    {
        var process = ProcessTasks.StartProcess(
            _toolPath,
            arguments,
            workingDirectory,
            environmentVariables,
            timeout,
            logOutput,
            logInvocation,
            customLogger,
            outputFilter);
#endif
        (exitHandler ?? (p => ProcessTasks.DefaultExitHandler(toolSettings: null, p))).Invoke(process.AssertWaitForExit());
        return process.Output;
    }
}
