// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class Assert
    {
        [ContractAnnotation("=> halt")]
        public static void Fail(string message, Exception exception = null)
        {
            throw new ApplicationException(message, exception);
        }

        [AssertionMethod]
        public static void True(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string message = null,
            [CallerArgumentExpression("condition")]
            string argumentExpression = null)
        {
            if (!condition)
                throw new ArgumentException(message ?? "Expected condition to be true", argumentExpression);
        }

        [AssertionMethod]
        public static void False(
            [AssertionCondition(AssertionConditionType.IS_FALSE)]
            bool condition,
            string message = null,
            [CallerArgumentExpression("condition")]
            string argumentExpression = null)
        {
            if (condition)
                throw new ArgumentException(message ?? "Expected condition to be false", argumentExpression);
        }

        [AssertionMethod]
        [ContractAnnotation("obj: null => halt; => notnull")]
        public static T NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this T obj,
            string message = null,
            [CallerArgumentExpression("obj")] string argumentExpression = null)
            where T : class
        {
            if (obj == null)
            {
                throw new ArgumentException(
                    message ?? $"Expected object of type {typeof(T).FullName.SingleQuote()} to be not null",
                    argumentExpression);
            }

            return obj;
        }

        [AssertionMethod]
        [ContractAnnotation("obj: null => halt; => notnull")]
        public static T? NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this T? obj,
            string message = null,
            [CallerArgumentExpression("obj")] string argumentExpression = null)
            where T : struct
        {
            if (obj == null)
            {
                throw new ArgumentException(
                    message ?? $"Expected object of type {typeof(T).FullName.SingleQuote()} to be not null",
                    argumentExpression);
            }

            return obj;
        }

        [AssertionMethod]
        public static string NotNullOrEmpty(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this string str,
            string message = null,
            [CallerArgumentExpression("str")] string argumentExpression = null)
        {
            if (str.IsNullOrEmpty())
                throw new ArgumentException(message ?? "Expected string to be not null or empty", argumentExpression);
            return str;
        }

        [AssertionMethod]
        public static string NotNullOrWhiteSpace(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this string str,
            string message = null,
            [CallerArgumentExpression("str")] string argumentExpression = null)
        {
            if (str.IsNullOrWhiteSpace())
                throw new ArgumentException(message ?? "Expected string to be not null or whitespace", argumentExpression);
            return str;
        }

        [AssertionMethod]
        public static void NotEmpty<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            ICollection<T> collection,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            if (collection.NotNull(argumentExpression: argumentExpression).IsEmpty())
                throw new ArgumentException(message ?? "Expected collection to be not empty", argumentExpression);
        }

        [AssertionMethod]
        public static void Empty<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            ICollection<T> collection,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            if (!collection.NotNull(argumentExpression: argumentExpression).IsEmpty())
                throw new ArgumentException(message ?? "Expected collection to be empty", argumentExpression);
        }

        [AssertionMethod]
        public static void Count<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            ICollection<T> collection,
            int length,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            if (collection.NotNull(argumentExpression: argumentExpression).Count != length)
                throw new ArgumentException(message ?? $"Expected collection to have length of {length}", argumentExpression);
        }

        [AssertionMethod]
        public static void HasSingleItem<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            ICollection<T> collection,
            string message = null,
            [CallerArgumentExpression("collection")]
            string argumentExpression = null)
        {
            Count(collection, length: 1, message, argumentExpression);
        }

        public static void FileExists(string path, string message = null, [CallerArgumentExpression("path")] string argumentExpression = null)
        {
            if (!File.Exists(path.NotNull(argumentExpression)))
                throw new ArgumentException(message ?? $"Expected file to exist: {path}", argumentExpression);
        }

        public static void DirectoryExists(string path, string message = null, [CallerArgumentExpression("path")] string argumentExpression = null)
        {
            if (!Directory.Exists(path.NotNull(argumentExpression)))
                throw new ArgumentException(message ?? $"Expected directory to exist: {path}", argumentExpression);
        }
    }
}
