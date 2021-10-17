﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;
using Nuke.Common.IO;
using Serilog;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class SchemaGenerator
    {
        public static void GenerateSchema<T>(string output, string id, string title)
        {
            Log.Information("Generating schema for {TypeName} to {Output} ...", typeof(T).Name, output);

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
