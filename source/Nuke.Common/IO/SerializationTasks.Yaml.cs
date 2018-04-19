// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nuke.Common.IO
{
    public static partial class SerializationTasks
    {
        public static void YamlSerializeToFile(object obj, string path, Configure<SerializerBuilder> configurator = null)
        {
            File.WriteAllText(path, YamlSerialize(obj, configurator));
        }

        [Pure]
        public static T YamlDeserializeFromFile<T>(string path, Configure<DeserializerBuilder> configurator = null)
        {
            return YamlDeserialize<T>(File.ReadAllText(path), configurator);
        }

        [Pure]
        public static string YamlSerialize(object obj, Configure<SerializerBuilder> configurator = null)
        {
            var builder = configurator.InvokeSafe(new SerializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention()));

            var serializer = builder.Build();
            return serializer.Serialize(obj);
        }

        [Pure]
        public static T YamlDeserialize<T>(string content, Configure<DeserializerBuilder> configurator = null)
        {
            var builder = configurator.InvokeSafe(new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention()));

            var deserializer = builder.Build();
            return deserializer.Deserialize<T>(content);
        }
    }
}
