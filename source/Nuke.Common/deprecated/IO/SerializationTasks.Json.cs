#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Core.Tooling;

namespace Nuke.Core.IO
{
    [PublicAPI]
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
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
            configurator = configurator ?? (x => x);
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
