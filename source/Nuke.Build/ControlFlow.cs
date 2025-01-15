// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Serilog;
#pragma warning disable CS0618

// ReSharper disable CompareNonConstrainedGenericWithNull

namespace Nuke.Common;

[PublicAPI]
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class ControlFlow
{
    public static void SuppressErrors(Action action, bool includeStackTrace = false, bool logWarning = true)
    {
        SuppressErrorsIf(condition: true, action, includeStackTrace: includeStackTrace, logWarning: logWarning);
    }

    [ContractAnnotation("defaultValue: notnull => notnull")]
    [CanBeNull]
    public static T SuppressErrors<T>(Func<T> action, T defaultValue = default, bool includeStackTrace = false, bool logWarning = true)
    {
        return (T)SuppressErrorsIf(condition: true, action, defaultValue, includeStackTrace, logWarning);
    }

    public static IEnumerable<T> SuppressErrors<T>(Func<IEnumerable<T>> action, bool includeStackTrace = false)
    {
        return SuppressErrors<IEnumerable<T>>(action, includeStackTrace: includeStackTrace) ?? Enumerable.Empty<T>();
    }

    [ContractAnnotation("defaultValue: notnull => notnull")]
    [CanBeNull]
    private static object SuppressErrorsIf(
        bool condition,
        Delegate action,
        object defaultValue = null,
        bool includeStackTrace = false,
        bool logWarning = true)
    {
        if (!condition)
            return defaultValue;

        try
        {
            return action.DynamicInvoke();
        }
        catch (Exception exception)
        {
            if (logWarning)
                Log.Warning(exception.Unwrap(), "Exception was suppressed");

            return defaultValue;
        }
    }

    public static void ExecuteWithRetry(
        [InstantHandle] Action action,
        [InstantHandle] Action cleanup = null,
        int retryAttempts = 3,
        TimeSpan? delay = null,
        Action<string> logAction = null)
    {
        Assert.True(retryAttempts > 0);

        logAction ??= Log.Warning;
        Exception lastException = null;

        for (var attempt = 0; attempt < retryAttempts; attempt++)
        {
            try
            {
                action.Invoke();
                return;
            }
            catch (Exception exception)
            {
                lastException = exception;

                if (attempt + 1 >= retryAttempts)
                    break;

                logAction($"Attempt #{attempt + 1} failed with: {exception.Message}");
                if (delay != null)
                {
                    logAction($"Waiting {delay} before next attempt...");
                    Task.Delay(delay.Value).Wait();
                }
            }
            finally
            {
                cleanup?.Invoke();
            }
        }

        Assert.Fail(new[]
             {
                 $"Execution failed permanently after {retryAttempts} attempts.",
                 $"Last attempt failed with: {lastException!.Message}"
             }.JoinNewLine());
    }
}
