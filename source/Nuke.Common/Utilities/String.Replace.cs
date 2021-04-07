// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class StringExtensions
    {
        [Pure]
        public static string ReplaceRegex(
            this string str,
            [RegexPattern] string pattern,
            MatchEvaluator matchEvaluator,
            RegexOptions options = RegexOptions.None)
        {
            return Regex.Replace(str, pattern, matchEvaluator, options);
        }

        private static readonly Regex s_unicodeRegex = new Regex(@"\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled);

        [Pure]
        public static string ReplaceUnicode(this string str)
        {
            return s_unicodeRegex.Replace(str, m => ((char) int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
        }

        [Pure]
        public static string ReplaceKnownWords(this string str)
        {
            return Constants.KnownWords.Aggregate(str, (s, r) => s.ReplaceRegex(r, _ => r, RegexOptions.IgnoreCase));
        }
    }
}
