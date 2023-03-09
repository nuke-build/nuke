// Copyright 2023 Maintainers of NUKE.
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
        /// <summary>
        /// Joins all strings with a given separator.
        /// </summary>
        [Pure]
        public static string Join(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }

        /// <summary>
        /// Joins all strings with a given separator.
        /// </summary>
        [Pure]
        public static string Join(this IEnumerable<string> enumerable, char separator)
        {
            return enumerable.Join(separator.ToString());
        }

        /// <summary>
        /// Joins all strings with a space.
        /// </summary>
        [Pure]
        public static string JoinSpace(this IEnumerable<string> values)
        {
            return values.Join(" ");
        }

        /// <summary>
        /// Joins all strings with a dash.
        /// </summary>
        [Pure]
        public static string JoinDash(this IEnumerable<string> values)
        {
            return values.Join("-");
        }

        /// <summary>
        /// Joins all strings with an underscore.
        /// </summary>
        [Pure]
        public static string JoinUnderscore(this IEnumerable<string> values)
        {
            return values.Join("_");
        }

        /// <summary>
        /// Joins all strings with an ampersand.
        /// </summary>
        [Pure]
        public static string JoinAmpersand(this IEnumerable<string> values)
        {
            return values.Join("&");
        }

        /// <summary>
        /// Joins all strings with a semicolon.
        /// </summary>
        [Pure]
        public static string JoinSemicolon(this IEnumerable<string> values)
        {
            return values.Join(";");
        }

        /// <summary>
        /// Joins all strings with a slash.
        /// </summary>
        [Pure]
        public static string JoinSlash(this IEnumerable<string> values)
        {
            return values.Join("/");
        }

        /// <summary>
        /// Joins all strings with a backslash.
        /// </summary>
        [Pure]
        public static string JoinBackslash(this IEnumerable<string> values)
        {
            return values.Join("\\");
        }

        /// <summary>
        /// Joins all strings with a dot.
        /// </summary>
        [Pure]
        public static string JoinDot(this IEnumerable<string> values)
        {
            return values.Join(".");
        }

        /// <summary>
        /// Joins all strings with a comma.
        /// </summary>
        [Pure]
        public static string JoinComma(this IEnumerable<string> values)
        {
            return values.Join(",");
        }

        /// <summary>
        /// Joins all strings with a comma and space.
        /// </summary>
        [Pure]
        public static string JoinCommaSpace(this IEnumerable<string> values)
        {
            return values.Join(", ");
        }

        /// <summary>
        /// Joins all strings with a logical <em>or</em> conjunction.
        /// </summary>
        [Pure]
        public static string JoinCommaOr(this IEnumerable<string> values)
        {
            var valuesList = values.ToArray();
            return valuesList.Length >= 2
                ? valuesList.Reverse().Skip(1).Reverse().JoinCommaSpace() + $"{(valuesList.Length > 2 ? "," : string.Empty)} or " + valuesList.Last()
                : valuesList.JoinCommaSpace();
        }

        /// <summary>
        /// Joins all strings with a logical <em>and</em> conjunction.
        /// </summary>
        [Pure]
        public static string JoinCommaAnd(this IEnumerable<string> values)
        {
            var valuesList = values.ToArray();
            return valuesList.Length >= 2
                ? valuesList.Reverse().Skip(1).Reverse().JoinCommaSpace() + $"{(valuesList.Length > 2 ? "," : string.Empty)} and " + valuesList.Last()
                : valuesList.JoinCommaSpace();
        }

        /// <summary>
        /// Joins all strings with a new-line.
        /// </summary>
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
