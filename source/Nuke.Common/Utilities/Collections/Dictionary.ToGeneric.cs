// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Utilities.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> ToGeneric<TKey, TValue>(this IDictionary dictionary, IEqualityComparer<TKey> equalityComparer = null)
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
