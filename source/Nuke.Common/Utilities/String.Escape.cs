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
        public static string EscapeBraces([CanBeNull] this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return str.NotNull().Replace("{", "{{").Replace("}", "}}");
        }
    }
}
