// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static partial class SerializationTasks
    {
        public static void JsonSerializeToFile<T>(T obj, string path, Configure<JsonSerializerSettings> configurator = null)
        {
            TextTasks.WriteAllText(path, JsonSerialize(obj, configurator));
        }

        [Pure]
        public static T JsonDeserializeFromFile<T>(string path, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonDeserialize<T>(File.ReadAllText(path), configurator);
        }

        [Pure]
        public static string JsonSerialize<T>(T obj, Configure<JsonSerializerSettings> configurator = null)
        {
            configurator ??= x => x;
            var settings = new JsonSerializerSettings
                           {
                               Formatting = Formatting.Indented,
                               NullValueHandling = NullValueHandling.Ignore,
                               DefaultValueHandling = DefaultValueHandling.Ignore
                           };
            configurator(settings);

            return JsonConvert.SerializeObject(obj, settings);
        }

        [Pure]
        public static T JsonDeserialize<T>(string content, Configure<JsonSerializerSettings> configurator = null)
        {
            var settings = configurator.InvokeSafe(
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            return JsonConvert.DeserializeObject<T>(content, settings);
        }

        public static void JsonUpdateFile<T>(string path, Action<T> update, Configure<JsonSerializerSettings> configurator = null)
        {
            var obj = JsonDeserializeFromFile<T>(path, configurator);
            update.Invoke(obj);
            JsonSerializeToFile(obj, path, configurator);
        }

        public static JObject JsonDeserializeFromFile(string path, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonDeserializeFromFile<JObject>(path, configurator);
        }

        public static JObject JsonDeserialize(string content, Configure<JsonSerializerSettings> configurator = null)
        {
            return JsonDeserialize<JObject>(content, configurator);
        }

        public static void JsonUpdateFile(string path, Action<JObject> update, Configure<JsonSerializerSettings> configurator = null)
        {
            JsonUpdateFile<JObject>(path, update, configurator);
        }
    }
}
