// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

// ReSharper disable CompareNonConstrainedGenericWithNull

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ControlFlow
    {
        /// <summary>
        /// Logs a message as failure. Halts execution.
        /// </summary>
        [StringFormatMethod("format")]
        [ContractAnnotation("=> halt")]
        public static void Fail(string format, params object[] args)
        {
            Fail(string.Format(format, args));
        }

        /// <summary>
        /// Logs a message as failure. Halts execution.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void Fail(object value, Exception exception = null)
        {
            Fail(value.ToString(), exception);
        }

        /// <summary>
        /// Logs a message as failure. Halts execution.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void Fail(string text, Exception exception = null)
        {
            throw new Exception(text, innerException: exception);
        }

        /// <summary>
        /// Asserts a condition to be true, calling <see cref="Logger.Warn(string)"/> otherwise.
        /// </summary>
        [AssertionMethod]
        public static void AssertWarn(bool condition, string text)
        {
            if (!condition)
                Logger.Warn($"Check failed: {text}");
        }

        /// <summary>
        /// Asserts a condition to be true, halts otherwise.
        /// </summary>
        [AssertionMethod]
        [ContractAnnotation("condition: false => halt")]
        public static void Assert(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string text)
        {
            if (!condition)
                Fail($"Assertion failed: {text}");
        }

        /// <summary>
        /// Asserts an object to be not null, halts otherwise.
        /// </summary>
        [AssertionMethod]
        [ContractAnnotation("obj: null => void; => notnull")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this T obj,
            string text = null)
        {
            if (obj == null)
                Fail($"Assertion failed: {text ?? $"{typeof(T).FullName} != null"}");
            return obj;
        }

        /// <summary>
        /// Checks an object to be not null, calling <see cref="Logger.Warn(string)"/> otherwise.
        /// </summary>
        [CanBeNull]
        [ContractAnnotation("obj: null => void; => notnull")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NotNullWarn<T>([CanBeNull] this T obj, string text = null)
        {
            if (obj == null)
                Logger.Warn($"Check failed: {text ?? $"{typeof(T).FullName} != null"}");
            return obj;
        }

        /// <summary>
        /// Asserts a collection to be not empty, halts otherwise.
        /// </summary>
        [ContractAnnotation("enumerable: null => halt")]
        public static IReadOnlyCollection<T> NotEmpty<T>([CanBeNull] this IEnumerable<T> enumerable, string message = null)
        {
            var collection = enumerable.NotNull("enumerable != null").ToList().AsReadOnly();
            Assert(collection.Count > 0, message ?? $"IEnumerable<{typeof(T).FullName}>.Count > 0");
            return collection;
        }

        /// <summary>
        /// Asserts a collection to contain only <em>non-null</em> elements, halts otherwise.
        /// </summary>
        [ContractAnnotation("enumerable: null => halt")]
        public static IReadOnlyCollection<T> NoNullItems<T>([CanBeNull] this IEnumerable<T> enumerable)
        {
            var collection = enumerable.NotNull("enumerable != null").ToList().AsReadOnly();
            Assert(collection.All(x => x != null), $"IEnumerable<{typeof(T).FullName}>.All(x => x != null)");
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
            return (T) SuppressErrorsIf(condition: true, action, defaultValue, includeStackTrace, logWarning);
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
                {
                    var innerException = exception.InnerException.NotNull("innerException != null");
                    Logger.Warn(includeStackTrace
                        ? new[] { innerException.Message, "StackTrace:", innerException.StackTrace }.JoinNewLine()
                        : innerException.Message);
                }

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
            int waitInSeconds = 0,
            Action<string> logAction = null)
        {
            Assert(retryAttempts > 0, "retryAttempts > 0");

            logAction ??= Logger.Warn;
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
                    logAction($"Attempt #{attempt + 1} failed with: {exception.Message}");

                    if (waitInSeconds <= 0 || attempt + 1 >= retryAttempts)
                        continue;

                    logAction($"Waiting {waitInSeconds} seconds before next attempt...");
                    Task.Delay(TimeSpan.FromSeconds(waitInSeconds)).Wait();
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }

            Fail(new[]
                 {
                     $"Executing failed permanently after {retryAttempts} attempts.",
                     $"Last attempt failed with: {lastException!.Message}"
                 }.JoinNewLine());
        }
    }
}
