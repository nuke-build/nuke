// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.IO;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;

[assembly: IconClass(typeof(JsonTasks), "file-empty2")]

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class JsonTasks
    {
        public static void JsonSerialize<T> (T obj, string path, Configure<JsonSerializerSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            var settings = new JsonSerializerSettings
                           {
                               Formatting = Formatting.Indented,
                               NullValueHandling = NullValueHandling.Ignore,
                               DefaultValueHandling = DefaultValueHandling.Ignore
                           };
            configurator(settings);

            var content = JsonConvert.SerializeObject(obj, settings);
            File.WriteAllText(path, content);
        }

        [Pure]
        public static T JsonDeserialize<T> (string path, Configure<JsonSerializerSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            var settings = new JsonSerializerSettings
                           {
                               Formatting = Formatting.Indented,
                               NullValueHandling = NullValueHandling.Ignore,
                               DefaultValueHandling = DefaultValueHandling.Ignore
                           };
            configurator(settings);

            var content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}
