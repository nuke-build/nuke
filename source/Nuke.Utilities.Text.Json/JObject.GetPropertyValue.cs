// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Nuke.Common.Utilities
{
    public static partial class JObjectExtensions
    {
        [CanBeNull]
        public static T GetPropertyValueOrNull<T>(this JObject jobject, string name)
        {
            var property = jobject.Property(name);
            return property != null
                ? property.Value.Value<T>()
                : default;
        }

        public static T GetPropertyValue<T>(this JObject jobject, string name)
        {
            var property = jobject.Property(name).NotNull($"Property '{name}' not found");
            return property.Value.Value<T>();
        }

        public static JObject GetPropertyValue(this JObject jobject, string name)
        {
            return jobject.GetPropertyValue<JObject>(name);
        }

        public static string GetPropertyStringValue(this JObject jobject, string name)
        {
            return jobject.GetPropertyValue<string>(name);
        }
    }
}
