// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class StringExtensions
    {
        public static bool EqualsOrdinalIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.StartsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EndsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.EndsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        public static string EscapeBraces ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.Replace("{", "{{").Replace("}", "}}");
        }

        public static string DoubleQuoteIfNeeded ([CanBeNull] this string str)
        {
            return str.DoubleQuoteIfNeeded(' ');
        }

        public static string DoubleQuoteIfNeeded ([CanBeNull] this string str, params char?[] disallowed)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            if (str.IsDoubleQuoted ())
                return str;

            if (!str.Contains(disallowed))
                return str;

            return str.DoubleQuote();
        }

        public static string DoubleQuote ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return $"\"{str.Replace("\"", "\\\"")}\"";
        }

        public static string SingleQuoteIfNeeded ([CanBeNull] this string str)
        {
            return str.SingleQuoteIfNeeded(' ');
        }

        public static string SingleQuoteIfNeeded ([CanBeNull] this string str, params char?[] disallowed)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            if (str.IsSingleQuoted ())
                return str;

            if (!str.Contains(disallowed))
                return str;

            return str.SingleQuote();
        }

        public static string SingleQuote ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return $"'{str.Replace("'", "\\'")}'";
        }

        public static bool IsDoubleQuoted(this string str)
        {
            return str.StartsWith("\"") && str.EndsWith("\"");
        }

        public static bool IsSingleQuoted(this string str)
        {
            return str.StartsWith("'") && str.EndsWith("'");
        }

        private static bool Contains (this string str, char?[] chars)
        {
            return chars.Any(x => x.HasValue && str.IndexOf(x.Value) != -1);
        }

        public static string Join (this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }

        public static string Join (this IEnumerable<string> enumerable, char separator)
        {
            return enumerable.Join(separator.ToString());
        }

        public static string JoinComma (this IEnumerable<string> values)
        {
            return values.Join(", ");
        }

        public static string JoinNewLine (this IEnumerable<string> values)
        {
            return values.Join(Environment.NewLine);
        }

        public static string TrimEnd (this string str, string trim)
        {
            return str.EndsWith(trim) ? str.Substring(startIndex: 0, length: str.Length - trim.Length) : str;
        }

        public static string TrimStart (this string str, string trim)
        {
            return str.StartsWith(trim) ? str.Substring(trim.Length) : str;
        }
    }
}
