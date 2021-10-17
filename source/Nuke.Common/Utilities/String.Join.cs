// Copyright 2021 Maintainers of NUKE.
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
        public static string JoinDash(this IEnumerable<string> values)
        {
            return values.Join("-");
        }

        [Pure]
        public static string JoinUnderscore(this IEnumerable<string> values)
        {
            return values.Join("_");
        }

        [Pure]
        public static string JoinAmpersand(this IEnumerable<string> values)
        {
            return values.Join("&");
        }

        [Pure]
        public static string JoinSemicolon(this IEnumerable<string> values)
        {
            return values.Join(";");
        }

        [Pure]
        public static string JoinSlash(this IEnumerable<string> values)
        {
            return values.Join("/");
        }

        [Pure]
        public static string JoinBackslash(this IEnumerable<string> values)
        {
            return values.Join("\\");
        }

        [Pure]
        public static string JoinDot(this IEnumerable<string> values)
        {
            return values.Join(".");
        }

        [Pure]
        public static string JoinComma(this IEnumerable<string> values)
        {
            return values.Join(",");
        }

        [Pure]
        public static string JoinCommaSpace(this IEnumerable<string> values)
        {
            return values.Join(", ");
        }

        [Pure]
        public static string JoinCommaOr(this IEnumerable<string> values)
        {
            var valuesList = values.ToArray();
            return valuesList.Length >= 2
                ? valuesList.Reverse().Skip(1).Reverse().JoinCommaSpace() + $"{(valuesList.Length > 2 ? "," : string.Empty)} or " + valuesList.Last()
                : valuesList.JoinCommaSpace();
        }

        [Pure]
        public static string JoinCommaAnd(this IEnumerable<string> values)
        {
            var valuesList = values.ToArray();
            return valuesList.Length >= 2
                ? valuesList.Reverse().Skip(1).Reverse().JoinCommaSpace() + $"{(valuesList.Length > 2 ? "," : string.Empty)} and " + valuesList.Last()
                : valuesList.JoinCommaSpace();
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
