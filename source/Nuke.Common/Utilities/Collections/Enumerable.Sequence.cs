// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        public static bool SequenceStartsWith<T>(this IEnumerable<T> enumerable, IEnumerable<T> other, IEqualityComparer<T> comparer = null)
        {
            var enumerableList = enumerable as List<T> ?? enumerable.ToList();
            var otherList = other as List<T> ?? other.ToList();
            return enumerableList.Take(otherList.Count).SequenceEqual(otherList, comparer);
        }
    }
}
