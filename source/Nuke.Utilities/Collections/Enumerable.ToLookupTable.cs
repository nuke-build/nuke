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
        public static LookupTable<TKey, TValue> ToLookupTable<TItem, TKey, TValue>(
            this IEnumerable<TItem> enumerable,
            Func<TItem, TKey> keySelector,
            Func<TItem, TValue> valueSelector)
        {
            return new LookupTable<TKey, TValue>(enumerable.ToLookup(keySelector, valueSelector));
        }
    }
}
