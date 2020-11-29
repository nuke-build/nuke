// Copyright 2019 Maintainers of NUKE.
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
        public static bool ContainsOrdinalIgnoreCase(this string str, string other)
        {
            return str.IndexOf(other, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        [Pure]
        public static bool EqualsOrdinalIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        [Pure]
        public static bool ContainsAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return others.Any(str.ContainsOrdinalIgnoreCase);
        }

        [Pure]
        public static bool ContainsAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.ContainsOrdinalIgnoreCase);
        }

        [Pure]
        public static bool EqualsAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return others.Any(str.EqualsOrdinalIgnoreCase);
        }

        [Pure]
        public static bool EqualsAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.EqualsOrdinalIgnoreCase);
        }

        [Pure]
        public static bool StartsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.StartsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        [Pure]
        public static bool EndsWithOrdinalIgnoreCase(this string str, string other)
        {
            return str.EndsWith(other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithAny(this string str, params string[] others)
        {
            return str.StartsWithAny(others.AsEnumerable());
        }

        public static bool StartsWithAny(this string str, IEnumerable<string> others)
        {
            return others.Any(str.StartsWith);
        }

        public static bool StartsWithAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return str.StartsWithAnyOrdinalIgnoreCase(others.AsEnumerable());
        }

        public static bool StartsWithAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.StartsWithOrdinalIgnoreCase);
        }

        public static bool EndsWithAny(this string str, params string[] others)
        {
            return str.EndsWithAny(others.AsEnumerable());
        }

        public static bool EndsWithAny(this string str, IEnumerable<string> others)
        {
            return others.Any(str.EndsWith);
        }

        public static bool EndsWithAnyOrdinalIgnoreCase(this string str, params string[] others)
        {
            return str.EndsWithAnyOrdinalIgnoreCase(others.AsEnumerable());
        }

        public static bool EndsWithAnyOrdinalIgnoreCase(this string str, IEnumerable<string> others)
        {
            return others.Any(str.EndsWithOrdinalIgnoreCase);
        }
    }
}
