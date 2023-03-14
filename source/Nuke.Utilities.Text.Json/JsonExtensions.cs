// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    public static class JsonExtensions
    {
        public static JsonSerializerSettings DefaultSerializerSettings =
            new()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new AllWritableContractResolver()
            };

        /// <summary>
        /// Serializes an object as JSON string.
        /// </summary>
        [Pure]
        public static string ToJson<T>(this T obj, JsonSerializerSettings serializerSettings = null)
        {
            return JsonConvert.SerializeObject(obj, serializerSettings ?? DefaultSerializerSettings);
        }

        /// <summary>
        /// Deserializes an object from a JSON string.
        /// </summary>
        [Pure]
        public static T GetJson<T>(this string content, JsonSerializerSettings serializerSettings = null)
        {
            return JsonConvert.DeserializeObject<T>(content, serializerSettings ?? DefaultSerializerSettings);
        }

        /// <summary>
        /// Deserializes a <see cref="JObject"/> from a JSON string.
        /// </summary>
        [Pure]
        public static JObject GetJson(this string content, JsonSerializerSettings serializerSettings = null)
        {
            return content.GetJson<JObject>(serializerSettings);
        }

        /// <summary>
        /// Serializes an object as JSON to a file.
        /// </summary>
        public static void WriteJson<T>(this AbsolutePath path, T obj, JsonSerializerSettings serializerSettings = null)
        {
            var content = obj.ToJson(serializerSettings);
            path.WriteAllText(content);
        }

        /// <summary>
        /// Deserializes an object as JSON from a file.
        /// </summary>
        [Pure]
        public static T ReadJson<T>(this AbsolutePath path, JsonSerializerSettings serializerSettings = null)
        {
            var content = path.ReadAllText();
            return content.GetJson<T>(serializerSettings);
        }

        /// <summary>
        /// Deserializes a <see cref="JObject"/> as JSON from a file.
        /// </summary>
        [Pure]
        public static JObject ReadJson(this AbsolutePath path, JsonSerializerSettings serializerSettings = null)
        {
            return path.ReadJson<JObject>(serializerSettings);
        }

        /// <summary>
        /// Deserializes an object as JSON from a file, applies updates, and serializes it back to the file.
        /// </summary>
        public static void UpdateJson<T>(
            this AbsolutePath path,
            Action<T> update,
            JsonSerializerSettings serializerSettings = null)
        {
            var before = path.ReadAllText();
            var obj = before.GetJson<T>(serializerSettings);
            update.Invoke(obj);
            var after = obj.ToJson(serializerSettings);
            path.WriteAllText(after);
        }

        /// <summary>
        /// Deserializes a <see cref="JObject"/> from a file, applies updates, and serializes it back to the file.
        /// </summary>
        public static void UpdateJson(
            this AbsolutePath path,
            Action<JObject> update,
            JsonSerializerSettings serializerSettings = null)
        {
            path.UpdateJson<JObject>(update, serializerSettings);
        }
    }
}
