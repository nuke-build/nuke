// Copyright 2023 Maintainers of NUKE.
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
        public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(
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
                var key = keySelector.Invoke(item);
                try
                {
                    dictionary.Add(key, valueSelector.Invoke(item));
                }
                catch (ArgumentException exception) when (exceptionFactory != null)
                {
                    throw exceptionFactory.Invoke(exception, key);
                }
            }

            return dictionary;
        }

        public static Dictionary<TKey, TValue> ToDictionarySafe<T, TKey, TValue>(
            this IEnumerable<T> enumerable,
            [InstantHandle] Func<T, TKey> keySelector,
            [InstantHandle] Func<T, TValue> valueSelector,
            string duplicationMessage)
        {
            var groups = enumerable.ToLookup(keySelector.Invoke, valueSelector.Invoke);
            Assert.True(
                groups.All(x => x.Count() == 1),
                new[] { $"{duplicationMessage.TrimEnd(":")}:" }
                    .Concat(groups.Where(x => x.Count() > 1).Select(x => $" - {x.Key}"))
                    .JoinNewLine());
            return groups.ToDictionary(x => x.Key, x => x.Single());
        }
    }
}
