// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> ToGeneric<TKey, TValue>(this IDictionary dictionary, IEqualityComparer<TKey> equalityComparer = null)
        {
            var genericDictionary = new Dictionary<TKey, TValue>(equalityComparer);

            var enumerator = dictionary.NotNull().GetEnumerator();
            while (enumerator.MoveNext())
            {
                genericDictionary.Add((TKey) enumerator.Key, (TValue) enumerator.Value);
            }

            return genericDictionary;
        }
    }
}
