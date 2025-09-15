// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling;

public delegate T Configure<T>(T options);

public delegate TOptions Configure<TOptions, in TValue>(TOptions options, TValue value)
    where TOptions : new();

public delegate IEnumerable<T> CombinatorialConfigure<T>(T options)
    where T : new();

public static class ConfigureExtensions
{
    public static T InvokeSafe<T>([CanBeNull] this Configure<T> configurator, T obj)
    {
        return (configurator ?? (x => x)).Invoke(obj);
    }

    public static IReadOnlyCollection<(TOptions Options, IReadOnlyCollection<Output> Output)> Invoke<TOptions>(
        this CombinatorialConfigure<TOptions> configurator,
        Func<TOptions, IReadOnlyCollection<Output>> executor,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TOptions : ToolOptions, new()
    {
        return Invoke(
            configurator,
            x => (Options: x, Output: executor(x)),
            x => x.Output,
            degreeOfParallelism,
            completeOnFailure);
    }

    public static IReadOnlyCollection<(TOptions Options, TResult Result, IReadOnlyCollection<Output> Output)> Invoke<TOptions, TResult>(
        this CombinatorialConfigure<TOptions> configurator,
        Func<TOptions, (TResult Result, IReadOnlyCollection<Output> Output)> executor,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TOptions : ToolOptions, new()
    {
        return Invoke(
                configurator,
                x => (Options: x, ReturnValue: executor(x)),
                x => x.ReturnValue.Output,
                degreeOfParallelism,
                completeOnFailure)
            .Select(x => (x.Options, x.ReturnValue.Result, x.ReturnValue.Output)).ToList();
    }

    private static IReadOnlyCollection<TResult> Invoke<TOptions, TResult>(
        CombinatorialConfigure<TOptions> configurator,
        Func<TOptions, TResult> executor,
        Func<TResult, IReadOnlyCollection<Output>> outputSelector,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TOptions : ToolOptions, new()
    {
        var invocations = new ConcurrentBag<(TOptions Options, Action<OutputType, string> Logger, TResult Result, Exception Exception)>();
        try
        {
            configurator(new TOptions())
                .AsParallel()
                .WithDegreeOfParallelism(degreeOfParallelism)
                .ForAll(x =>
                {
                    try
                    {
                        var result = executor(x.DisableProcessOutputLogging());
                        invocations.Add((x, x.GetLogger(), result, default));
                    }
                    catch (Exception exception)
                    {
                        invocations.Add((x, x.GetLogger(), default, exception));

                        if (!completeOnFailure)
                            throw;
                    }
                });

            if (invocations.Any(x => x.Exception != null))
                throw new AggregateException(invocations.Select(x => x.Exception).WhereNotNull());

            return invocations.Select(x => x.Result).ToList();
        }
        finally
        {
            invocations
                .Where(x => x.Options.ProcessOutputLogging ?? ProcessTasks.DefaultLogOutput)
                .SelectMany(x =>
                {
                    var (_, logger, result, exception) = x;
                    var output = exception switch
                    {
                        ProcessException processException => processException.Process.Output,
                        _ => outputSelector(result),
                    };

                    return output.Select(x => (Logger: logger, Line: x));
                })
                .ForEach(x => x.Logger(x.Line.Type, x.Line.Text));
        }
    }
}
