// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using Nuke.Common;
using Nuke.Common.IO;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class SchemaGenerator
    {
        public static void GenerateSchema<T>(string output, string id, string title)
        {
            Logger.Info($"Generating schema for '{typeof(T).Name}' to '{output}'...");

            var schemaGenerator = new JSchemaGenerator
                                  {
                                      DefaultRequired = Required.DisallowNull,
                                      ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                      GenerationProviders = { new StringEnumGenerationProvider() }
                                  };
            var toolSchema = schemaGenerator.Generate(typeof(T));
            toolSchema.Id = new Uri(id);
            toolSchema.Title = title;

            TextTasks.WriteAllText(output, toolSchema.ToString(SchemaVersion.Draft4));
        }
    }
}
