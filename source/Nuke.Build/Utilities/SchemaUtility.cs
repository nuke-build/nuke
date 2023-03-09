// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;
using static Nuke.Common.Constants;

namespace Nuke.Common.Execution
{
    public class SchemaUtility
    {
        public static void WriteBuildSchemaFile(INukeBuild build)
        {
            var buildSchemaFile = GetBuildSchemaFile(build.RootDirectory);
            var buildSchema = GetBuildSchema(build);
            var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            var json = JsonSerializer.Serialize(buildSchema, options);
            buildSchemaFile.WriteAllText(json);
        }

        // ReSharper disable once CognitiveComplexity
        public static JsonDocument GetBuildSchema(INukeBuild build)
        {
            var parameters = ValueInjectionUtility
                .GetParameterMembers(build.GetType(), includeUnlisted: true)
                // .Where(x => x.DeclaringType != typeof(NukeBuild))
                .Select(x =>
                    new
                    {
                        Name = ParameterService.GetParameterMemberName(x),
                        Description = ParameterService.GetParameterDescription(x),
                        MemberType = x.GetMemberType(),
                        ScalarType = x.GetMemberType().GetScalarType(),
                        EnumValues = ParameterService.GetParameterValueSet(x, build)?.Select(x => x.Text),
                        IsRequired = x.HasCustomAttribute<RequiredAttribute>(),
                        IsSecret = x.HasCustomAttribute<SecretAttribute>()
                    }).ToList();

            string GetJsonType(Type type)
                => type.IsCollectionLike()
                    ? "array"
                    : type.GetScalarType() == typeof(int)
                        ? "integer"
                        : type.GetScalarType() == typeof(bool)
                            ? "boolean"
                            : "string";

            var properties = new Dictionary<string, object>();
            foreach (var parameter in parameters)
            {
                var property = new Dictionary<string, object>();
                property["type"] = GetJsonType(parameter.MemberType);

                if (parameter.Description != null)
                    property["description"] = parameter.Description;

                if (parameter.IsSecret)
                    property["default"] = "Secrets must be entered via 'nuke :secrets [profile]'";

                if (parameter.EnumValues != null && !parameter.MemberType.IsCollectionLike())
                    property["enum"] = parameter.EnumValues;

                if (parameter.MemberType.IsCollectionLike())
                {
                    var items = new Dictionary<string, object>();
                    items["type"] = GetJsonType(parameter.ScalarType);
                    if (parameter.EnumValues != null)
                        items["enum"] = parameter.EnumValues;
                    property["items"] = items;
                }

                properties[parameter.Name] = property;
            }

            var build2 = new Dictionary<string, object> { ["type"] = "object", ["properties"] = properties };
            var definitions = new Dictionary<string, object> { ["build"] = build2 };
            var jsonDictionary = new Dictionary<string, object>
                              {
                                  ["$schema"] = "http://json-schema.org/draft-04/schema#",
                                  ["$ref"] = "#/definitions/build",
                                  ["title"] = "Build Schema",
                                  ["definitions"] = definitions
                              };
            return JsonDocument.Parse(JsonSerializer.Serialize(jsonDictionary));
        }

        public static void WriteDefaultParametersFile(INukeBuild build)
        {
            var parametersFile = GetDefaultParametersFile(build.RootDirectory);
            if (parametersFile.Exists())
                return;

            parametersFile.WriteAllLines(
                new[]
                {
                    "{",
                    $"  \"$schema\": \"./{BuildSchemaFileName}\"",
                    "}"
                });
        }
    }
}
