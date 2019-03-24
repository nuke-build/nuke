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
        public static IEnumerable<TSource> Distinct<TSource, TValue>(this IEnumerable<TSource> enumerable, Func<TSource, TValue> selector)
        {
            return enumerable.Distinct(new DelegateEqualityComparer<TSource, TValue>(selector));
        }

        private class DelegateEqualityComparer<TSource, TValue> : IEqualityComparer<TSource>
        {
            private readonly Func<TSource, TValue> _selector;

            public DelegateEqualityComparer(Func<TSource, TValue> selector)
            {
                _selector = selector;
            }

            public bool Equals([CanBeNull] TSource x, [CanBeNull] TSource y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                if (ReferenceEquals(x, objB: null))
                    return false;
                if (ReferenceEquals(y, objB: null))
                    return false;
                if (x.GetType() != y.GetType())
                    return false;
                return Equals(_selector(x), _selector(y));
            }

            public int GetHashCode([NotNull] TSource obj)
            {
                return _selector(obj).GetHashCode();
            }
        }
    }
}
