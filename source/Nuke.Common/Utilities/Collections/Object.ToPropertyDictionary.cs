// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuke.Common.Utilities.Collections
{
    partial class EnumerableExtensions
    {
        public static IReadOnlyDictionary<TKey, TValue> ToPropertyDictionary<T, TKey, TValue>(
            this T obj,
            Func<PropertyInfo, TKey> keySelector,
            Func<object, TValue> valueSelector)
        {
            var type = obj.GetType();
            var properties = type.GetProperties().Where(x => x.GetIndexParameters().Length == 0);
            return properties.ToDictionary(keySelector, x => valueSelector(x.GetValue(obj: obj))).AsReadOnly();
        }
    }
}
