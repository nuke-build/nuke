// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling;

[PublicAPI]
public static class DelegateHelper
{
    public static IDictionary<string, object> Toggle(IReadOnlyDictionary<string, object> dictionary, string key)
    {
        var newDictionary = dictionary?.ToDictionary(x => x.Key, x => x.Value) ?? new Dictionary<string, object>();
        newDictionary[key] = !newDictionary.ContainsKey(key) || !ReflectionUtility.Convert<bool>(newDictionary[key].ToString());
        return newDictionary;
    }

    public static IDictionary<string, object> SetCollection<TValue>(
        IReadOnlyDictionary<string, object> dictionary,
        string key,
        IEnumerable<TValue> values,
        string separator)
    {
        var newDictionary = dictionary.ToDictionary(x => x.Key, x => x.Value);
        var collectionAsString = CollectionToString(values, separator);
        if (!string.IsNullOrWhiteSpace(collectionAsString))
            newDictionary[key] = collectionAsString;
        return newDictionary;
    }

    public static IDictionary<string, object> AddCollection<TValue>(
        IReadOnlyDictionary<string, object> dictionary,
        string key,
        IEnumerable<TValue> values,
        string separator)
    {
        var newDictionary = dictionary.ToDictionary(x => x.Key, x => x.Value);
        var collection = ParseCollection<TValue>(dictionary, key, separator);
        collection.AddRange(values);
        newDictionary[key] = CollectionToString(collection, separator);
        return newDictionary;
    }

    public static IDictionary<string, object> RemoveCollection<TValue>(
        IReadOnlyDictionary<string, object> dictionary,
        string key,
        IEnumerable<TValue> values,
        string separator)
    {
        var newDictionary = dictionary.ToDictionary(x => x.Key, x => x.Value);
        var valueHashSet = new HashSet<TValue>(values);
        var collection = ParseCollection<TValue>(dictionary, key, separator);
        collection.RemoveAll(x => valueHashSet.Contains((TValue)x));
        newDictionary[key] = CollectionToString(collection, separator);
        return newDictionary;
    }

    public static List<TValue> ParseCollection<TValue>(IReadOnlyDictionary<string, object> dictionary, string key, string separator)
    {
        return (dictionary.TryGetValue(key, out var value)
                ? ((string)value).Split([separator], StringSplitOptions.RemoveEmptyEntries)
                : [])
            .Select(ReflectionUtility.Convert<TValue>).ToList();
    }

    private static string CollectionToString<T>(IEnumerable<T> collection, string separator)
    {
        return collection.Select(x => x.ToString()).Join(separator);
    }
}
