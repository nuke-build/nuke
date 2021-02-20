// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using static Nuke.Common.Utilities.ReflectionUtility;

namespace Nuke.Common.Tooling
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class ExtensionHelper
    {
        public static void ToggleBoolean(IDictionary dictionary, string key)
        {
            dictionary[key] = !dictionary.Contains(key) || !Convert<bool>(dictionary[key].ToString());
        }

        public static void SetCollection<T>(IDictionary dictionary, string key, IEnumerable<T> values, char separator)
        {
            var collectionAsString = CollectionToString(values, separator);
            if (string.IsNullOrWhiteSpace(collectionAsString))
                return;

            dictionary[key] = collectionAsString;
        }

        public static void AddItems<T>(IDictionary dictionary, string key, IEnumerable<T> values, char separator)
        {
            var collection = ParseCollection<T>(dictionary, key, separator);
            collection.AddRange(values);
            dictionary[key] = CollectionToString(collection, separator);
        }

        public static void RemoveItems<T>(IDictionary dictionary, string key, IEnumerable<T> values, char separator)
        {
            var valueHashSet = new HashSet<T>(values);
            var collection = ParseCollection<T>(dictionary, key, separator);
            collection.RemoveAll(x => valueHashSet.Contains(x));
            dictionary[key] = CollectionToString(collection, separator);
        }

        private static List<TValue> ParseCollection<TValue>(IDictionary dictionary, string key, char separator)
        {
            return (dictionary.Contains(key)
                    ? ((string) dictionary[key]).Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                    : new string[0])
                .Select(Convert<TValue>).ToList();
        }

        private static string CollectionToString<T>(IEnumerable<T> collection, char separator)
        {
            return collection.Select(x => x.ToString()).Join(separator);
        }
    }
}
