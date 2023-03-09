// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Indicates whether the collection is empty.
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

        /// <summary>
        /// Indicates whether the collection is not empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || enumerable.IsEmpty();
        }
    }
}
