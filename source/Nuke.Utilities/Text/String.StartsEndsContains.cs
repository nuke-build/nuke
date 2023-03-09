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
        /// Indicates whether a string contains another string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool ContainsOrdinalIgnoreCase(this string str, string other)
        {
            return str.IndexOf(other, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Indicates whether a string equals another string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool EqualsOrdinalIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string contains any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool ContainsAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return others.Any(str.ContainsOrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string contains any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool ContainsAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.ContainsOrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string equals any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool EqualsAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return others.Any(str.EqualsOrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string equals any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool EqualsAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.EqualsOrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string starts with another string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool StartsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.StartsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string ends with another string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool EndsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.EndsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string starts with any other string under <see cref="StringComparison.CurrentCulture"/> comparison.
        /// </summary>
        [Pure]
        public static bool StartsWithAny(this string str, params string[] others)
        {
            return str.StartsWithAny(others.AsEnumerable());
        }

        /// <summary>
        /// Indicates whether a string starts with any other string under <see cref="StringComparison.CurrentCulture"/> comparison.
        /// </summary>
        [Pure]
        public static bool StartsWithAny(this string str, IEnumerable<string> others)
        {
            return others.Any(str.StartsWith);
        }

        /// <summary>
        /// Indicates whether a string starts with any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool StartsWithAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return str.StartsWithAnyOrdinalIgnoreCase(others.AsEnumerable());
        }

        /// <summary>
        /// Indicates whether a string starts with any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool StartsWithAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.StartsWithOrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether a string ends with any other string under <see cref="StringComparison.CurrentCulture"/> comparison.
        /// </summary>
        [Pure]
        public static bool EndsWithAny(this string str, params string[] others)
        {
            return str.EndsWithAny(others.AsEnumerable());
        }

        /// <summary>
        /// Indicates whether a string ends with any other string under <see cref="StringComparison.CurrentCulture"/> comparison.
        /// </summary>
        [Pure]
        public static bool EndsWithAny(this string str, IEnumerable<string> others)
        {
            return others.Any(str.EndsWith);
        }

        /// <summary>
        /// Indicates whether a string ends with any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool EndsWithAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return str.EndsWithAnyOrdinalIgnoreCase(others.AsEnumerable());
        }

        /// <summary>
        /// Indicates whether a string ends with any other string under <see cref="StringComparison.OrdinalIgnoreCase"/> comparison.
        /// </summary>
        [Pure]
        public static bool EndsWithAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.EndsWithOrdinalIgnoreCase);
        }
    }
}
