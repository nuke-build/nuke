// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Replaces matches of regular expressions.
        /// </summary>
        [Pure]
        public static string ReplaceRegex(
            this string str,
            [RegexPattern] string pattern,
            MatchEvaluator matchEvaluator,
            RegexOptions options = RegexOptions.None)
        {
            return Regex.Replace(str, pattern, matchEvaluator, options);
        }

        private static readonly Regex s_unicodeRegex = new(@"\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled);

        [Pure]
        public static string ReplaceUnicode(this string str)
        {
            return s_unicodeRegex.Replace(str, m => ((char) int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
        }

        [Pure]
        public static string ReplaceKnownWords(this string str)
        {
            return KnownWords.Aggregate(str, (s, r) => s.ReplaceRegex(r, _ => r, RegexOptions.IgnoreCase));
        }
    }
}
