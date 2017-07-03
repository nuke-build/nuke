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
        public static string EscapeBraces ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.Replace("{", "{{").Replace("}", "}}");
        }

        public static string DoubleQuoteIfNeeded ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.Contains(" ") ? str.DoubleQuote() : str;
        }

        public static string DoubleQuote ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return $"\"{str.Replace("\"", "\\\"")}\"";
        }

        public static string SingleQuoteIfNeeded ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.Contains(" ") ? str.SingleQuote() : str;
        }

        public static string SingleQuote ([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return $"'{str.Replace("'", "\\'")}'";
        }

        public static string Join (this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
    }
}
