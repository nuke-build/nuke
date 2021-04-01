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
        public static string TrimToOne(this string str, string trim)
        {
            while (str.Contains(trim + trim))
            {
                str = str.Replace(trim + trim, trim);
            }

            return str;
        }

        [Pure]
        public static string TrimEnd(this string str, string trim)
        {
            return str.EndsWith(trim) ? str.Substring(startIndex: 0, str.Length - trim.Length) : str;
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

            return str.Substring(startIndex: 1, str.Length - 2);
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
    }
}
