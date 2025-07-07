// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nuke.Common.Utilities.Collections;

public static partial class DictionaryExtensions
{
    public static Dictionary<TKey, TValue> AddDictionary<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        Dictionary<TKey, TValue> otherDictionary)
    {
        foreach (var (key, value) in otherDictionary)
            dictionary.AddPair(key, value);
        return dictionary;
    }

    public static Dictionary<TKey, TValue> AddDictionary<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        ReadOnlyDictionary<TKey, TValue> otherDictionary)
    {
        foreach (var (key, value) in otherDictionary)
            dictionary.AddPair(key, value);
        return dictionary;
    }
}
