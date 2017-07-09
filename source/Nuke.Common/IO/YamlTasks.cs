// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

[assembly: IconClass(typeof(YamlTasks), "file-empty2")]

namespace Nuke.Common.IO
{
    [PublicAPI]
    public class YamlTasks
    {
        public static void YamlSerializeToFile (object obj, string path, Configure<SerializerBuilder> configurator = null)
        {
            File.WriteAllText(path, YamlSerialize(obj, configurator));
        }

        [Pure]
        public static T YamlDeserializeFromFile<T> (string path, Configure<DeserializerBuilder> configurator = null)
        {
            return YamlDeserialize<T>(File.ReadAllText(path), configurator);
        }

        [Pure]
        public static string YamlSerialize (object obj, Configure<SerializerBuilder> configurator = null)
        {
            var builder = new SerializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention());
            builder = configurator.InvokeSafe(builder);

            var serializer = builder.Build();
            return serializer.Serialize(obj);
        }

        [Pure]
        public static T YamlDeserialize<T> (string content, Configure<DeserializerBuilder> configurator = null)
        {
            var builder = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention());
            builder = configurator.InvokeSafe(builder);

            var deserializer = builder.Build();
            return deserializer.Deserialize<T>(content);
        }
    }
}
