// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling;

partial class ToolTasks
{
    protected virtual IReadOnlyCollection<Output> Run(ToolOptions options)
    {
        var secrets = options.GetSecrets().ToList();
        string Filter(string text) => secrets.Aggregate(text, (str, s) => str.Replace(s, "[REDACTED]"));

        options = PreProcess(options);
        using var process = StartProcess(
            options.GetArguments().JoinSpace(),
            options.ProcessWorkingDirectory,
            options.ProcessEnvironmentVariables,
            options.ProcessExecutionTimeout,
            options.ProcessOutputLogging,
            options.ProcessInvocationLogging,
            GetLogger(options),
            Filter);

        GetExitHandlerInternal().Invoke(process);
        PostProcess(options);

        return process.Output;
    }

    protected virtual (TResult Result, IReadOnlyCollection<Output> Output) Run<TResult>(ToolOptions options)
    {
        var output = Run(options);
        try
        {
            var result = GetResult<TResult>(options, output);
            return (Result: (TResult)result, Output: output);
        }
        catch (Exception exception)
        {
            throw new Exception($"Cannot parse {typeof(TResult).Name} from output:".Concat(output.Select(x => x.Text)).JoinNewLine(), exception);
        }
    }

#if NET6_0_OR_GREATER

    protected IReadOnlyCollection<Output> Run(
        ArgumentStringHandler arguments,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        Action<OutputType, string> logger = null,
        Func<IProcess, object> exitHandler = null)
    {
        using var process = StartProcess(
            arguments.ToStringAndClear(),
            workingDirectory,
            environmentVariables,
            timeout,
            logOutput,
            logInvocation,
            logger ?? GetLogger());

        (exitHandler ?? GetExitHandlerInternal()).Invoke(process);
        return process.Output;
    }

#endif

    protected virtual IProcess StartProcess(
        string arguments,
        string workingDirectory,
        IReadOnlyDictionary<string, string> environmentVariables,
        int? executionTimeout,
        bool? outputLogging,
        bool? invocationLogging,
        Action<OutputType, string> logger,
        Func<string, string> outputFilter = null)
    {
        return ProcessTasks.StartProcess(
            GetToolPathInternal(),
            arguments,
            workingDirectory,
            environmentVariables,
            executionTimeout,
            outputLogging,
            invocationLogging,
            logger,
            outputFilter);
    }
}
