// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

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
        public static void YamlSerialize<T> (T obj, string path, Configure<SerializerBuilder> configurator = null)
        {
            var builder = new SerializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention());
            builder = configurator.InvokeSafe(builder);

            var serializer = builder.Build();
            var content = serializer.Serialize(obj);
            File.WriteAllText(path, content);
        }

        public static T YamlDeserialize<T> (string path, Configure<DeserializerBuilder> configurator = null)
        {
            var builder = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention());
            builder = configurator.InvokeSafe(builder);

            var content = File.ReadAllText(path);
            var deserializer = builder.Build();
            return deserializer.Deserialize<T>(content);
        }
    }
}
