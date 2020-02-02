// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AddPair<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            [CanBeNull] TValue value = default)
        {
            dictionary.Add(key, value);
            return dictionary;
        }

        public static IDictionary<TKey, TValue> AddPairWhenKeyNotNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            [CanBeNull] TKey key,
            [CanBeNull] TValue value = default)
            where TKey : class
        {
            return key != null
                ? dictionary.AddPair(key, value)
                : dictionary;
        }

        public static IDictionary<TKey, TValue> AddPairWhenValueNotNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            [CanBeNull] TKey key,
            [CanBeNull] TValue value)
            where TValue : class
        {
            return value != null
                ? dictionary.AddPair(key, value)
                : dictionary;
        }
    }
}
