// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Nuke.Common.Utilities
{
    public static class JsonExtensions
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
            return jobject.GetPropertyValueOrNull<T>(name).NotNull(name);
        }

        public static JObject GetPropertyValue(this JObject jobject, string name)
        {
            return jobject.GetPropertyValue<JObject>(name);
        }

        public static string GetPropertyStringValue(this JObject jobject, string name)
        {
            return jobject.GetPropertyValue<string>(name);
        }

        public static JEnumerable<T> GetChildren<T>(this JObject jobject, string name)
            where T : JToken
        {
            return jobject.GetPropertyValue<JArray>(name).Children<T>();
        }

        public static JEnumerable<JObject> GetChildren(this JObject jobject, string name)
        {
            return jobject.GetChildren<JObject>(name);
        }
    }
}
