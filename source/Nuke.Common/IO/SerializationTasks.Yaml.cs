// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Utilities.Text.Yaml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nuke.Common.IO
{
    public static partial class SerializationTasks
    {
        public static SerializerBuilder DefaultYamlSerializerBuilder = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance);

        public static DeserializerBuilder DefaultYamlDeserializerBuilder = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance);

        [Obsolete($"Use {nameof(YamlExtensions)}.{nameof(YamlExtensions.WriteYaml)} as {nameof(AbsolutePath)} extension method")]
        public static void YamlSerializeToFile<T>(T obj, string path, Configure<SerializerBuilder> configurator = null)
        {
            TextTasks.WriteAllText(path, YamlSerialize(obj, configurator));
        }

        [Pure]
        [Obsolete($"Use {nameof(YamlExtensions)}.{nameof(YamlExtensions.ReadYaml)} as {nameof(AbsolutePath)} extension method")]
        public static T YamlDeserializeFromFile<T>(string path, Configure<DeserializerBuilder> configurator = null)
        {
            Assert.FileExists(path);
            return YamlDeserialize<T>(File.ReadAllText(path), configurator);
        }

        [Pure]
        [Obsolete($"Use {nameof(YamlExtensions)}.{nameof(YamlExtensions.ToYaml)} as object extension method")]
        public static string YamlSerialize<T>(T obj, Configure<SerializerBuilder> configurator = null)
        {
            var serializer = configurator.InvokeSafe(DefaultYamlSerializerBuilder).Build();
            return serializer.Serialize(obj);
        }

        [Pure]
        [Obsolete($"Use {nameof(YamlExtensions)}.{nameof(YamlExtensions.GetYaml)} as string extension method")]
        public static T YamlDeserialize<T>(string content, Configure<DeserializerBuilder> configurator = null)
        {
            var deserializer = configurator.InvokeSafe(DefaultYamlDeserializerBuilder).Build();
            return deserializer.Deserialize<T>(content);
        }

        [Obsolete($"Use {nameof(YamlExtensions)}.{nameof(YamlExtensions.UpdateYaml)} as {nameof(AbsolutePath)} extension method")]
        public static void YamlUpdateFile<T>(
            string path,
            Action<T> update,
            Configure<DeserializerBuilder> deserializationConfigurator = null,
            Configure<SerializerBuilder> serializationConfigurator = null)
        {
            var obj = YamlDeserializeFromFile<T>(path, deserializationConfigurator);
            update.Invoke(obj);
            YamlSerializeToFile(obj, path, serializationConfigurator);
        }
    }
}
