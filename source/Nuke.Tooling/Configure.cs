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
        int degreeOfParallelism,
        bool completeOnFailure)
        where TSettings : ToolSettings, new()
    {
        return Invoke(
            configurator,
            x => (Settings: x, Output: executor(x)),
            x => x.Output,
            degreeOfParallelism,
            completeOnFailure);
    }

    public static IReadOnlyCollection<(TSettings Settings, TResult Result, IReadOnlyCollection<Output> Output)> Invoke<TSettings, TResult>(
        this CombinatorialConfigure<TSettings> configurator,
        Func<TSettings, (TResult Result, IReadOnlyCollection<Output> Output)> executor,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TSettings : ToolSettings, new()
    {
        return Invoke(
                configurator,
                x => (Settings: x, ReturnValue: executor(x)),
                x => x.ReturnValue.Output,
                degreeOfParallelism,
                completeOnFailure)
            .Select(x => (x.Settings, x.ReturnValue.Result, x.ReturnValue.Output)).ToList();
    }

    private static IReadOnlyCollection<TResult> Invoke<TSettings, TResult>(
        CombinatorialConfigure<TSettings> configurator,
        Func<TSettings, TResult> executor,
        Func<TResult, IReadOnlyCollection<Output>> outputSelector,
        int degreeOfParallelism,
        bool completeOnFailure)
        where TSettings : ToolSettings, new()
    {
        var singleExecution = degreeOfParallelism == 1;

        var invocations = new ConcurrentBag<(TSettings Settings, TResult Result, Exception Exception)>();

        try
        {
            configurator(new TSettings())
                .AsParallel()
                .WithDegreeOfParallelism(degreeOfParallelism)
                .ForAll(x =>
                {
                    try
                    {
                        invocations.Add((x, executor(x.SetProcessLogOutput(singleExecution)), default));
                    }
                    catch (Exception exception)
                    {
                        invocations.Add((x, default, exception));

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
            if (!singleExecution)
            {
                invocations
                    .Where(x => x.Settings.ProcessLogOutput ?? ProcessTasks.DefaultLogOutput)
                    .SelectMany(x =>
                    {
                        var (settings, result, exception) = x;
                        var logger = settings.ProcessLogger ?? defaultLogger;
                        var output = exception switch
                        {
                            ProcessException processException => processException.Process.Output,
                            _ => outputSelector(result),
                        };

                        return output.Select(line => (logger, line));
                    })
                    .ForEach(x => x.logger(x.line.Type, x.line.Text));
            }
        }
    }
}
