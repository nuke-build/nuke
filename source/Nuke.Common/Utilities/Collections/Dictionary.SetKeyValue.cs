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
        public static IDictionary<TKey, TValue> SetKeyValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            [CanBeNull] TValue value = default)
        {
            dictionary[key] = value;
            return dictionary;
        }
    }
}
