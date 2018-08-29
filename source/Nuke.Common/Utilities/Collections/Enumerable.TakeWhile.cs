// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> enumerable, Func<bool> condition)
        {
            return enumerable.TakeWhile(x => condition());
        }
    }
}
