// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities.Collections
{
    public static partial class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> SetKeyValue<TKey, TValue> (
            this IDictionary<TKey, TValue> dictionary,
            [CanBeNull] TKey key,
            [CanBeNull] TValue value)
        {
            dictionary[key] = value;
            return dictionary;
        }
    }
}
