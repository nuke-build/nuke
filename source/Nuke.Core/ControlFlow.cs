// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Execution;

[assembly: IconClass(typeof(ControlFlow), "footprint")]

namespace Nuke.Core
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ControlFlow
    {
        /// <summary>
        /// Asserts a condition to be true, calling <see cref="Logger.Warn(string)"/> otherwise.
        /// </summary>
        public static void AssertWarn (bool condition, string text)
        {
            if (!condition)
                Logger.Warn($"Assertion failed: {text}");
        }

        /// <summary>
        /// Asserts a condition to be true, calling <see cref="Logger.Fail(string)"/> otherwise.
        /// </summary>
        [AssertionMethod]
        [ContractAnnotation("condition: false => halt")]
        public static void Assert ([AssertionCondition(AssertionConditionType.IS_TRUE)] bool condition, string text)
        {
            if (!condition)
                Logger.Fail($"Assertion failed: {text}");
        }

        /// <summary>
        /// Asserts an object to be not null, calling <see cref="Logger.Fail(string)"/> otherwise.
        /// </summary>
        [AssertionMethod]
        [ContractAnnotation("obj: null => halt")]
        public static T NotNull<T> ([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull] this T obj, string text = null)
            where T : class
        {
            if (obj == null)
                Logger.Fail($"Assertion failed: {text ?? "obj != null"}");
            return obj;
        }

        /// <summary>
        /// Checks an object to be not null, calling <see cref="Logger.Warn(string)"/> otherwise.
        /// </summary>
        [CanBeNull]
        public static T NotNullWarn<T> ([CanBeNull] this T obj, string text = null)
            where T : class
        {
            if (obj == null)
                Logger.Warn($"Check failed: {text ?? "obj != null"}");
            return obj;
        }

        /// <summary>
        /// Asserts a collection to be not empty, calling <see cref="Logger.Fail(string)"/> otherwise.
        /// </summary>
        [ContractAnnotation("enumerable: null => halt")]
        public static IReadOnlyCollection<T> NotEmpty<T> ([CanBeNull] this IEnumerable<T> enumerable)
            where T : class
        {
            var collection = enumerable.NotNull("enumerable != null").ToList().AsReadOnly();
            Assert(collection.Count > 0, "collection.Count > 0");
            return collection;
        }

        /// <summary>
        /// Asserts a collection to contain only <i>non-null</i> elements, calling <see cref="Logger.Fail(string)"/> otherwise.
        /// </summary>
        [ContractAnnotation("enumerable: null => halt")]
        public static IReadOnlyCollection<T> NoNullItems<T> ([CanBeNull] this IEnumerable<T> enumerable)
            where T : class
        {
            var collection = enumerable.NotNull("enumerable != null").ToList().AsReadOnly();
            Assert(collection.All(x => x != null), "collection.All(x => x != null)");
            return collection;
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        public static void SuppressErrors (Action action)
        {
            SuppressErrorsIf(condition: true, action: action);
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        [ContractAnnotation ("defaultValue: notnull => notnull")]
        [CanBeNull]
        public static T SuppressErrors<T> (Func<T> action, T defaultValue = default (T))
        {
            return SuppressErrorsIf(condition: true, action: action, defaultValue: defaultValue);
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        /// <returns>
        /// Returns an empty collection for convenience.
        /// </returns>
        public static IEnumerable<T> SuppressErrors<T> (Func<IEnumerable<T>> action)
        {
            return SuppressErrors<IEnumerable<T>>(action) ?? Enumerable.Empty<T>();
        }

        private static void SuppressErrorsIf (bool condition, Action action)
        {
            if (!condition)
                action();

            try
            {
                action();
            }
            catch (Exception exception)
            {
                Logger.Warn(exception.Message);
            }
        }

        /// <summary>
        /// Executes a given action and suppresses all errors while delegating them to <see cref="Logger.Warn(string)"/>.
        /// </summary>
        [ContractAnnotation ("defaultValue: notnull => notnull")]
        [CanBeNull]
        private static T SuppressErrorsIf<T> (bool condition, Func<T> action, T defaultValue = default(T))
        {
            if (!condition)
                return action();

            try
            {
                return action();
            }
            catch (Exception exception)
            {
                Logger.Warn(exception.Message);
                return defaultValue;
            }
        }


        //public static void ExecuteWithRetry (Action action, Action cleanup = null, int retryAttempts = 3, int timeoutInSeconds = 3600)
        //{
        //    ExecuteWithRetry ((attempt, max) => action.Invoke (), cleanup, retryAttempts, timeoutInSeconds);
        //}

        //public static void ExecuteWithRetry (Action<int, int> action, Action cleanup, int retryAttempts = 3, int timeoutInSeconds = 3600)
        //{
        //    for (var attempt = 0; attempt < retryAttempts; attempt++)
        //    {
        //        try
        //        {
        //            ExecuteWithTimeout (() => action (attempt + 1, retryAttempts), cleanup, timeoutInSeconds);
        //            return;
        //        }
        //        catch (Exception exception)
        //        {
        //            Logger.Warn ($"Attempt #{attempt + 1} failed with:");
        //            Logger.Warn (exception.Message);
        //        }
        //    }

        //    Logger.Warn ($"Executing action after " + retryAttempts + " attempts failed.");
        //}

        //public static void ExecuteWithTimeout (Action action, Action cleanup = null, int timeoutInSeconds = 3600)
        //{
        //    var task = System.Threading.Tasks.Task.Run (action);
        //    var delay = System.Threading.Tasks.Task.Delay (TimeSpan.FromSeconds (timeoutInSeconds));
        //    if (System.Threading.Tasks.Task.WhenAny (task, delay) == task)
        //        return;

        //    cleanup?.Invoke ();
        //    Logger.Fail ("Executing action with timeout failed.");
        //}
    }
}
