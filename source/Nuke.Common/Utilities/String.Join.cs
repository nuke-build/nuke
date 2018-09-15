// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string Join(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }

        [Pure]
        public static string Join(this IEnumerable<string> enumerable, char separator)
        {
            return enumerable.Join(separator.ToString());
        }

        [Pure]
        public static string JoinSpace(this IEnumerable<string> values)
        {
            return values.Join(" ");
        }

        [Pure]
        public static string JoinComma(this IEnumerable<string> values)
        {
            return values.Join(", ");
        }

        [Pure]
        public static string JoinNewLine(this IEnumerable<string> values, PlatformFamily? platformFamily = null)
        {
            var newLine = !platformFamily.HasValue
                ? Environment.NewLine
                : platformFamily.Value == PlatformFamily.Windows
                    ? "\r\n"
                    : "\n";
            return values.Join(newLine);
        }
    }
}
