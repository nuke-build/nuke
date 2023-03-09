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
        /// Trims any multi-occurrence of a string in another string to a single-occurrence.
        /// </summary>
        [Pure]
        public static string TrimToOne(this string str, string trim)
        {
            while (str.Contains(trim + trim))
            {
                str = str.Replace(trim + trim, trim);
            }

            return str;
        }

        /// <summary>
        /// Trims the occurrence of a string from the end of another string.
        /// </summary>
        [Pure]
        public static string TrimEnd(this string str, string trim)
        {
            return str.EndsWith(trim) ? str.Substring(startIndex: 0, str.Length - trim.Length) : str;
        }

        /// <summary>
        /// Trims the occurrence of a string from the start of another string.
        /// </summary>
        [Pure]
        public static string TrimStart(this string str, string trim)
        {
            return str.StartsWith(trim) ? str.Substring(trim.Length) : str;
        }

        /// <summary>
        /// Trims matching double-quotes from the start and end of a string.
        /// </summary>
        [Pure]
        public static string TrimMatchingDoubleQuotes(this string str)
        {
            return TrimMatchingQuotes(str, quote: '"');
        }

        /// <summary>
        /// Trims matching double-quotes from the start and end of a string.
        /// </summary>
        [Pure]
        public static string TrimMatchingSingleQuotes(this string str)
        {
            return TrimMatchingQuotes(str, quote: '\'');
        }

        [Pure]
        internal static string TrimMatchingQuotes(this string str, char quote)
        {
            if (str.Length < 2)
                return str;

            if (str[index: 0] != quote || str[str.Length - 1] != quote)
                return str;

            return str.Substring(startIndex: 1, str.Length - 2);
        }
    }
}
