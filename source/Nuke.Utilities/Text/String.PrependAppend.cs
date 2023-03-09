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
        /// Prepends a string to another string.
        /// </summary>
        [Pure]
        public static string Prepend(this string str, string prependText)
        {
            return prependText + str;
        }

        /// <summary>
        /// Appends a string to another string.
        /// </summary>
        [Pure]
        public static string Append(this string str, string appendText)
        {
            return str + appendText;
        }
    }
}
