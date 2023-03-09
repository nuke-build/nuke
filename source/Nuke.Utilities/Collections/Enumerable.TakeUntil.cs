// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Takes elements until the condition is <c>false</c>.
        /// </summary>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        {
            return enumerable.TakeWhile(x => !condition(x));
        }

        /// <summary>
        /// Skips elements until the condition is <c>false</c>.
        /// </summary>
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        {
            return enumerable.SkipWhile(x => !condition(x));
        }
    }
}
