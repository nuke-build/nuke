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
        public static IDictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(
            this IEnumerable<T> enumerable,
            [InstantHandle] Func<T, TKey> keySelector,
            [InstantHandle] Func<T, TValue> valueSelector,
            IEqualityComparer<TKey> comparer = null,
            Func<ArgumentException, TKey, Exception> exceptionFactory = null)
        {
            var list = enumerable.ToList();
            var dictionary = new Dictionary<TKey, TValue>(list.Count, comparer);

            foreach (var item in list)
            {
                var key = keySelector(item);
                try
                {
                    dictionary.Add(key, valueSelector(item));
                }
                catch (ArgumentException exception)
                {
                    exceptionFactory ??= (ex, _) => ex;
                    throw exceptionFactory(exception, key);
                }
            }

            return dictionary;
        }
    }
}
