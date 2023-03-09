// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    [PublicAPI]
    public static class LookupExtensions
    {
        public static LookupTable<TKey, TValue> ToLookupTable<TKey, TValue>(this ILookup<TKey, TValue> lookup, IEqualityComparer<TKey> comparer)
        {
            return new LookupTable<TKey, TValue>(lookup, comparer);
        }
    }
}
