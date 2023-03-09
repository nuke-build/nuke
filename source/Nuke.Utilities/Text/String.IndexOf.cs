// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using System.Text.RegularExpressions;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Returns the first index of a given regular expression.
        /// </summary>
        [Pure]
        public static int IndexOfRegex(this string text, [RegexPattern] string expression)
        {
            var regex = new Regex(expression, RegexOptions.Compiled);
            return regex.Match(text).Index;
        }
    }
}
