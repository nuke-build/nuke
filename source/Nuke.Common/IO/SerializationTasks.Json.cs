// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static partial class SerializationTasks
    {
        public static void JsonSerializeToFile(object obj, string path)
        {
            TextTasks.WriteAllText(path, JsonSerialize(obj));
        }

        [Pure]
        public static T JsonDeserializeFromFile<T>(string path)
        {
            return JsonDeserialize<T>(File.ReadAllText(path));
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
    }
}
