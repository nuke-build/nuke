// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Nuke.Common
{
    /// <summary>
    /// Provides a collection of common assertion methods.
    /// </summary>
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class Assert
    {
        /// <summary>
        /// Throws an exception with the specified message and inner-exception.
        /// </summary>
        [ContractAnnotation("=> halt")]
        public static void Fail(string message, Exception exception = null)
        {
            throw new Exception(message, exception);
        }

        /// <summary>
        /// Asserts that the condition is true with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("condition: false => halt")]
        public static void True(
            bool condition,
            string message = null,
            [CallerArgumentExpression("condition")]
            string argumentExpression = null)
        {
            if (!condition)
                throw new ArgumentException(message ?? "Expected condition to be true", message == null ? argumentExpression : null);
        }

        /// <summary>
        /// Asserts that the condition is false with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("condition: true => halt")]
        public static void False(
            bool condition,
            string message = null,
            [CallerArgumentExpression("condition")]
            string argumentExpression = null)
        {
            if (condition)
                throw new ArgumentException(message ?? "Expected condition to be false", message == null ? argumentExpression : null);
        }

        /// <summary>
        /// Asserts that the object is not <c>null</c> with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("obj: null => halt; => notnull")]
        public static T NotNull<T>(
            [CanBeNull]
            this T obj,
            string message = null,
            [CallerArgumentExpression("obj")]
            string argumentExpression = null)
            where T : class
        {
            if (obj == null)
            {
                throw new ArgumentException(
                    message ?? $"Expected object of type '{typeof(T).FullName}' to be not null",
                    message == null ? argumentExpression : null);
            }

            return obj;
        }

        /// <summary>
        /// Asserts that the object is not <c>null</c> with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("obj: null => halt; => notnull")]
        public static T? NotNull<T>(
            [CanBeNull]
            this T? obj,
            string message = null,
            [CallerArgumentExpression("obj")]
            string argumentExpression = null)
            where T : struct
        {
            if (obj == null)
            {
                throw new ArgumentException(
                    message ?? $"Expected object of type '{typeof(T).FullName}' to be not null",
                    message == null ? argumentExpression : null);
            }

            return obj;
        }

        /// <summary>
        /// Asserts that the string is not <c>null</c> or empty with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("str: null => halt")]
        public static string NotNullOrEmpty(
            [CanBeNull]
            this string str,
            string message = null,
            [CallerArgumentExpression("str")]
            string argumentExpression = null)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException(message ?? "Expected string to be not null or empty", message == null ? argumentExpression : null);
            return str;
        }

        /// <summary>
        /// Asserts that the string is not <c>null</c> or has only whitespace characters with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("str: null => halt")]
        public static string NotNullOrWhiteSpace(
            [CanBeNull]
            this string str,
            string message = null,
            [CallerArgumentExpression("str")]
            string argumentExpression = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException(message ?? "Expected string to be not null or whitespace", message == null ? argumentExpression : null);
            return str;
        }

        /// <summary>
        /// Asserts that the collection is not empty with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("collection: null => halt")]
        public static void NotEmpty<T>(
            [CanBeNull]
            IReadOnlyCollection<T> collection,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            if (collection.NotNull(argumentExpression: argumentExpression).Count == 0)
                throw new ArgumentException(message ?? "Expected collection to be not empty", message == null ? argumentExpression : null);
        }

        /// <summary>
        /// Asserts that the collection is empty with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("collection: null => halt")]
        public static void Empty<T>(
            [CanBeNull]
            IReadOnlyCollection<T> collection,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            if (collection.NotNull(argumentExpression: argumentExpression).Count > 0)
                throw new ArgumentException(message ?? "Expected collection to be empty", message == null ? argumentExpression : null);
        }

        /// <summary>
        /// Asserts that the collection has specified number of elements an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("collection: null => halt")]
        public static void Count<T>(
            [CanBeNull]
            IReadOnlyCollection<T> collection,
            int length,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            if (collection.NotNull(argumentExpression: argumentExpression).Count != length)
                throw new ArgumentException(message ?? $"Expected collection to have length of {length}", message == null ? argumentExpression : null);
        }

        /// <summary>
        /// Asserts that the collection has only a single element with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("collection: null => halt")]
        public static void HasSingleItem<T>(
            [CanBeNull]
            IReadOnlyCollection<T> collection,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            Count(collection, length: 1, message, argumentExpression);
        }

        /// <summary>
        /// Asserts that the file exists with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("path: null => stop")]
        public static void FileExists([CanBeNull] string path, string message = null, [CallerArgumentExpression("path")] string argumentExpression = null)
        {
            if (!File.Exists(path.NotNull(argumentExpression)))
                throw new ArgumentException(message ?? $"Expected file to exist: {path}", message == null ? argumentExpression : null);
        }

        /// <summary>
        /// Asserts that the directory exists with an optional exception message. If no message is provided, the argument expression is used.
        /// </summary>
        [ContractAnnotation("path: null => stop")]
        public static void DirectoryExists([CanBeNull] string path, string message = null, [CallerArgumentExpression("path")] string argumentExpression = null)
        {
            if (!Directory.Exists(path.NotNull(argumentExpression)))
                throw new ArgumentException(message ?? $"Expected directory to exist: {path}", message == null ? argumentExpression : null);
        }
    }
}
