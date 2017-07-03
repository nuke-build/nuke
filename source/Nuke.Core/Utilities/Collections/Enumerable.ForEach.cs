// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        public static void ForEach<T> (this IEnumerable<T> enumerable, [InstantHandle] Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);
        }

        public static IEnumerable<T> ForEachLazy<T> (this IEnumerable<T> enumerable, [InstantHandle] Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
                yield return item;
            }
        }
    }
}
