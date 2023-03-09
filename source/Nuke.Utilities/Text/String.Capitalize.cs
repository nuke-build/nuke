// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class StringExtensions
    {
        /// <summary>
        /// Converts the first character of a given string to upper-case.
        /// </summary>
        [Pure]
        public static string Capitalize(this string text)
        {
            return !text.IsNullOrEmpty()
                ? text.Substring(startIndex: 0, length: 1).ToUpper(CultureInfo.InvariantCulture) +
                  text.Substring(startIndex: 1)
                : text;
        }
    }
}
