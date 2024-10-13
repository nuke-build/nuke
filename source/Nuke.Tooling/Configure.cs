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

public delegate T Configure<T>(T settings);

public delegate TSettings Configure<TSettings, in TValue>(TSettings settings, TValue value)
    where TSettings : new();

public delegate IEnumerable<T> CombinatorialConfigure<T>(T settings)
    where T : new();

public static class ConfigureExtensions
{
    public static T InvokeSafe<T>([CanBeNull] this Configure<T> configurator, T obj)
    {
        return (configurator ?? (x => x)).Invoke(obj);
    }

    public static IReadOnlyCollection<(TSettings Settings, IReadOnlyCollection<Output> Output)> Invoke<TSettings>(
        this CombinatorialConfigure<TSettings> configurator,
        Func<TSettings, IReadOnlyCollection<Output>> executor,
        Action<OutputType, string> defaultLogger,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TSettings : ToolSettings, new()
    {
        return Invoke(
            configurator,
            x => (Settings: x, Output: executor(x)),
            x => x.Output,
            defaultLogger,
            degreeOfParallelism,
            completeOnFailure);
    }

    public static IReadOnlyCollection<(TSettings Settings, TResult Result, IReadOnlyCollection<Output> Output)> Invoke<TSettings, TResult>(
        this CombinatorialConfigure<TSettings> configurator,
        Func<TSettings, (TResult Result, IReadOnlyCollection<Output> Output)> executor,
        Action<OutputType, string> defaultLogger,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TSettings : ToolSettings, new()
    {
        return Invoke(
                configurator,
                executor: x => (Settings: x, ReturnValue: executor(x)),
                outputSelector: x => x.ReturnValue.Output,
                defaultLogger,
                degreeOfParallelism,
                completeOnFailure)
            .Select(x => (x.Settings, x.ReturnValue.Result, x.ReturnValue.Output)).ToList();
    }

    private static IReadOnlyCollection<TResult> Invoke<TSettings, TResult>(
        CombinatorialConfigure<TSettings> configurator,
        Func<TSettings, TResult> executor,
        Func<TResult, IReadOnlyCollection<Output>> outputSelector,
        Action<OutputType, string> defaultLogger,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TSettings : ToolSettings, new()
    {
        var invocations = new ConcurrentBag<(TSettings Settings, Action<OutputType, string> logger, TResult Result, Exception Exception)>();

        try
        {
            configurator(new TSettings())
                .AsParallel()
                .WithDegreeOfParallelism(degreeOfParallelism)
                .ForAll(x =>
                {
                    var logger = x.ProcessLogger ?? defaultLogger;
                    try
                    {
                        var result = executor(x.DisableProcessLogOutput());
                        invocations.Add((x, logger, result, default));
                    }
                    catch (Exception exception)
                    {
                        invocations.Add((x, logger, default, exception));

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
                .Where(x => x.Settings.ProcessLogOutput ?? ProcessTasks.DefaultLogOutput)
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
