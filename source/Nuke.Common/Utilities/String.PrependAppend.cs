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
        public static string Prepend(this string str, string prependText)
        {
            return prependText + str;
        }

        [Pure]
        public static string Append(this string str, string appendText)
        {
            return str + appendText;
        }
    }
}
