// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Newtonsoft.Json.Linq;

namespace Nuke.Common.Utilities
{
    public static partial class JObjectExtensions
    {
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
