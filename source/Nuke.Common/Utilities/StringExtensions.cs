// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class StringExtensions
    {
        [Pure]
        public static bool ContainsOrdinalIgnoreCase(this string str, string other)
        {
            return str.IndexOf(other, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        [Pure]
        public static bool EqualsOrdinalIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        [Pure]
        public static bool StartsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.StartsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        [Pure]
        public static bool EndsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.EndsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        [Pure]
        public static string EscapeBraces([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.NotNull().Replace("{", "{{").Replace("}", "}}");
        }

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
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return $"\"{str.NotNull().Replace("\"", "\\\"")}\"";
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
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return $"'{str.NotNull().Replace("'", "\\'")}'";
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

        [Pure]
        public static string Join(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }

        [Pure]
        public static string Join(this IEnumerable<string> enumerable, char separator)
        {
            return enumerable.Join(separator.ToString());
        }

        [Pure]
        public static string JoinSpace(this IEnumerable<string> values)
        {
            return values.Join(" ");
        }

        [Pure]
        public static string JoinComma(this IEnumerable<string> values)
        {
            return values.Join(", ");
        }

        [Pure]
        public static string JoinNewLine(this IEnumerable<string> values, PlatformFamily? platformFamily = null)
        {
            var newLine = !platformFamily.HasValue
                ? Environment.NewLine
                : platformFamily.Value == PlatformFamily.Windows
                    ? "\r\n"
                    : "\n";
            return values.Join(newLine);
        }

        [Pure]
        public static string TrimEnd(this string str, string trim)
        {
            return str.EndsWith(trim) ? str.Substring(startIndex: 0, length: str.Length - trim.Length) : str;
        }

        [Pure]
        public static string TrimStart(this string str, string trim)
        {
            return str.StartsWith(trim) ? str.Substring(trim.Length) : str;
        }

        [Pure]
        public static string TrimMatchingQuotes(this string str, char quote)
        {
            if (str.Length < 2)
                return str;
            
            if (str[index: 0] != quote || str[str.Length - 1] != quote)
                return str;

            return str.Substring(startIndex: 1, length: str.Length - 2);
        }

        [Pure]
        public static string TrimMatchingDoubleQuotes(this string str)
        {
            return TrimMatchingQuotes(str, quote: '"');
        }

        [Pure]
        public static string TrimMatchingQuotes(this string str)
        {
            return TrimMatchingQuotes(str, quote: '\'');
        }

        [Pure]
        public static string ReplaceRegex(
            this string str,
            string pattern,
            MatchEvaluator matchEvaluator,
            RegexOptions options = RegexOptions.None)
        {
            return Regex.Replace(str, pattern, matchEvaluator, options);
        }

        [Pure]
        public static IEnumerable<string> Split(this string str, Func<char, bool> predicate)
        {
            var next = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (!predicate(str[i]))
                    continue;
                
                yield return str.Substring(next, i - next);
                next = i;
            }

            yield return str.Substring(next);
        }
    }
}
