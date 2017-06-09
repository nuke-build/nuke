// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> WhereNotNull<T> (this IEnumerable<T> enumerable)
            where T : class
        {
            return enumerable.Where(x => x != null);
        }
    }
}
