// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Double-quotes a given string if it contains spaces. Empty and already quoted strings remain unchanged.
        /// </summary>
        [Pure]
        public static string DoubleQuoteIfNeeded([CanBeNull] this string str)
        {
            return str.DoubleQuoteIfNeeded(' ');
        }

        /// <summary>
        /// Double-quotes a given string if it contains disallowed characters. Empty and already quoted strings remain unchanged.
        /// </summary>
        [Pure]
        public static string DoubleQuoteIfNeeded([CanBeNull] this string str, params char?[] disallowed)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            if (str.IsDoubleQuoted())
                return str;

            if (!str.Contains(disallowed))
                return str;

            return str.DoubleQuote();
        }

        /// <summary>
        /// Double-quotes a given string in double-quotes with existing double-quotes escaped.
        /// </summary>
        [Pure]
        public static string DoubleQuote([CanBeNull] this string str)
        {
            return $"\"{str?.Replace("\"", "\\\"")}\"";
        }

        /// <summary>
        /// Single-quotes a given string if it contains spaces. Empty and already quoted strings remain unchanged.
        /// </summary>
        [Pure]
        public static string SingleQuoteIfNeeded([CanBeNull] this string str)
        {
            return str.SingleQuoteIfNeeded(' ');
        }

        /// <summary>
        /// Single-quotes a given string if it contains disallowed characters. Empty and already quoted strings remain unchanged.
        /// </summary>
        [Pure]
        public static string SingleQuoteIfNeeded([CanBeNull] this string str, params char?[] disallowed)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            if (str.IsSingleQuoted())
                return str;

            if (!str.Contains(disallowed))
                return str;

            return str.SingleQuote();
        }

        /// <summary>
        /// Single-quotes a given string with existing single-quotes escaped.
        /// </summary>
        [Pure]
        public static string SingleQuote([CanBeNull] this string str)
        {
            return $"'{str?.Replace("'", "\\'")}'";
        }

        /// <summary>
        /// Indicates whether a given string is double-quoted.
        /// </summary>
        [Pure]
        public static bool IsDoubleQuoted(this string str)
        {
            return str.StartsWith("\"") && str.EndsWith("\"");
        }

        /// <summary>
        /// Indicates whether a given string is single-quoted.
        /// </summary>
        [Pure]
        public static bool IsSingleQuoted(this string str)
        {
            return str.StartsWith("'") && str.EndsWith("'");
        }

        [Pure]
        private static bool Contains(this string str, char?[] chars)
        {
            return chars.Any(x => x.HasValue && str.IndexOf(x.Value) != -1);
        }
    }
}
