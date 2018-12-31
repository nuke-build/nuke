// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
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
            string pattern,
            MatchEvaluator matchEvaluator,
            RegexOptions options = RegexOptions.None)
        {
            return Regex.Replace(str, pattern, matchEvaluator, options);
        }
    }
}
