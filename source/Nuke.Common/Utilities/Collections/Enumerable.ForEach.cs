// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, [InstantHandle] Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, [InstantHandle] Action<T, int> action)
        {
            enumerable.Select((x, i) => new { x, i }).ForEach(x => action(x.x, x.i));
        }

        public static IEnumerable<T> ForEachLazy<T>(this IEnumerable<T> enumerable, [InstantHandle] Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
                yield return item;
            }
        }
    }
}
