﻿// Copyright 2019 Maintainers of NUKE.
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

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ControlFlow
    {
        [Obsolete("Use " + nameof(Common.Assert) + "." + nameof(Common.Assert.Fail))]
        public static void Fail(string format, params object[] args)
        {
            Fail(string.Format(format, args));
        }

        [Obsolete("Use " + nameof(Common.Assert) + "." + nameof(Common.Assert.Fail))]
        public static void Fail(object value, Exception exception = null)
        {
            Fail(value.ToString(), exception);
        }

        [Obsolete("Use " + nameof(Common.Assert) + "." + nameof(Common.Assert.Fail))]
        public static void Fail(string text, Exception exception = null)
        {
            Common.Assert.Fail(text, exception);
        }

        [Obsolete("Use " + nameof(Common.Assert) + "." + nameof(Common.Assert.True) +
                  " or " + nameof(Common.Assert) + "." + nameof(Common.Assert.False))]
        public static void Assert(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string text)
        {
            Common.Assert.True(condition, text);
        }

        [Obsolete("Use " + nameof(Common.Assert) + "." + nameof(Common.Assert.NotNullOrEmpty))]
        public static IReadOnlyCollection<T> NotEmpty<T>([CanBeNull] this IEnumerable<T> enumerable, string message = null)
        {
            var collection = enumerable.NotNull().ToList().AsReadOnly();
            Common.Assert.NotEmpty(collection);
            return collection;
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        public static void SuppressErrors(Action action, bool includeStackTrace = false)
        {
            SuppressErrorsIf(condition: true, action, includeStackTrace: includeStackTrace);
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// var author = SuppressErrors(GetAuthor, defaultValue: "John Doe");
        /// </code>
        /// </example>
        [ContractAnnotation("defaultValue: notnull => notnull")]
        [CanBeNull]
        public static T SuppressErrors<T>(Func<T> action, T defaultValue = default, bool includeStackTrace = false, bool logWarning = true)
        {
            return (T)SuppressErrorsIf(condition: true, action, defaultValue, includeStackTrace, logWarning);
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        /// <returns>
        /// Returns an empty collection for convenience.
        /// </returns>
        /// <example>
        /// <code>
        /// // Won't throw NRE if GetAuthors throws
        /// var authorsCount = SuppressErrors(GetAuthors).Length;
        /// </code>
        /// </example>
        public static IEnumerable<T> SuppressErrors<T>(Func<IEnumerable<T>> action, bool includeStackTrace = false)
        {
            return SuppressErrors<IEnumerable<T>>(action, includeStackTrace: includeStackTrace) ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
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
                    Log.Warning(exception, exception.Message);

                return defaultValue;
            }
        }

        /// <summary>
        /// Executes a given action under retry-policy. After reaching the specified amount of attempts, the actions fails permanently.
        /// </summary>
        /// <example>
        /// <code>
        /// ExecuteWithRetry(() => NuGetRestore(SolutionFile), waitInSeconds: 30);
        /// </code>
        /// </example>
        public static void ExecuteWithRetry(
            [InstantHandle] Action action,
            [InstantHandle] Action cleanup = null,
            int retryAttempts = 3,
            TimeSpan? delay = null,
            Action<string> logAction = null)
        {
            Assert(retryAttempts > 0, "retryAttempts > 0");

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

            Fail(new[]
                 {
                     $"Execution failed permanently after {retryAttempts} attempts.",
                     $"Last attempt failed with: {lastException!.Message}"
                 }.JoinNewLine());
        }
    }
}
