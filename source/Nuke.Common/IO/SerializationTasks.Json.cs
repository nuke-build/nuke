// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common.Tooling;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static partial class SerializationTasks
    {
        public static void JsonSerializeToFile(object obj, string path)
        {
            File.WriteAllText(path, JsonSerialize(obj));
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

        internal class AllWritableContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.Writable = true;
                return property;
            }
        }
    }
}
