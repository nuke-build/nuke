// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this object obj)
        {
            return obj is IEnumerable enumerable ? enumerable.Cast<T>() : new[] { (T) obj };
        }
    }
}
