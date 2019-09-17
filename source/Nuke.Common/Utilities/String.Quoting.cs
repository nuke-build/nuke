// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string DoubleQuoteIfNeeded([CanBeNull] this string str)
        {
            return str.DoubleQuoteIfNeeded(' ');
        }

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

        [Pure]
        public static string DoubleQuote([CanBeNull] this string str)
        {
            return $"\"{str?.Replace("\"", "\\\"")}\"";
        }

        [Pure]
        public static string SingleQuoteIfNeeded([CanBeNull] this string str)
        {
            return str.SingleQuoteIfNeeded(' ');
        }

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

        [Pure]
        public static string SingleQuote([CanBeNull] this string str)
        {
            return $"'{str?.Replace("'", "\\'")}'";
        }

        [Pure]
        public static bool IsDoubleQuoted(this string str)
        {
            return str.StartsWith("\"") && str.EndsWith("\"");
        }

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
