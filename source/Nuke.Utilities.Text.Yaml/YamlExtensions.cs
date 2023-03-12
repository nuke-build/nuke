// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;
using Nuke.Common.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nuke.Utilities.Text.Yaml
{
    [PublicAPI]
    public static class YamlExtensions
    {
        public static SerializerBuilder DefaultSerializerBuilder = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance);

        public static DeserializerBuilder DefaultDeserializerBuilder = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance);

        /// <summary>
        /// Serializes an object as YAML string.
        /// </summary>
        [Pure]
        public static string ToYaml<T>(this T obj, SerializerBuilder serializerBuilder = null)
        {
            var serializer = (serializerBuilder ?? DefaultSerializerBuilder).Build();
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// Deserializes an object from a YAML string.
        /// </summary>
        [Pure]
        public static T GetYaml<T>(this string content, DeserializerBuilder deserializerBuilder = null)
        {
            var deserializer = (deserializerBuilder ?? DefaultDeserializerBuilder).Build();
            return deserializer.Deserialize<T>(content);
        }

        /// <summary>
        /// Serializes an object as YAML to a file.
        /// </summary>
        public static void WriteYaml<T>(this AbsolutePath path, T obj, SerializerBuilder serializerBuilder = null)
        {
            var content = obj.ToYaml(serializerBuilder);
            path.WriteAllText(content);
        }

        /// <summary>
        /// Deserializes an object as YAML from a file.
        /// </summary>
        [Pure]
        public static T ReadYaml<T>(this AbsolutePath path, DeserializerBuilder deserializerBuilder = null)
        {
            var content = path.ReadAllText();
            return content.GetYaml<T>(deserializerBuilder);
        }

        /// <summary>
        /// Deserializes an object as YAML from a file, applies updates, and serializes it back to the file.
        /// </summary>
        public static void UpdateYaml<T>(
            this AbsolutePath path,
            Action<T> update,
            DeserializerBuilder deserializerBuilder = null,
            SerializerBuilder serializerBuilder = null)
        {
            var before = path.ReadAllText();
            var obj = before.GetYaml<T>(deserializerBuilder);
            update.Invoke(obj);
            var after = obj.ToYaml(serializerBuilder);
            path.WriteAllText(after);
        }
    }
}
