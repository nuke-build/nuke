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
        public static IEnumerable<T> TakeWhile<T> (this IEnumerable<T> enumerable, Func<bool> condition)
        {
            return enumerable.TakeWhile(x => condition());
        }
    }
}
