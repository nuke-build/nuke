// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NJsonSchema.Generation;
using NuGet.Packaging;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;
using static Nuke.Common.Constants;

namespace Nuke.Common.Execution;

public class SchemaUtility
{
    private class SchemaGenerator : JsonSchemaGenerator
    {
        private class Resolver : DefaultContractResolver
        {
            protected override List<MemberInfo> GetSerializableMembers(Type objectType)
            {
                return objectType == typeof(ExecutableTarget) || objectType == typeof(Host)
                    ? new List<MemberInfo>()
                    : base.GetSerializableMembers(objectType);
            }
        }

        public static JsonSchema Generate<T>(T build) where T : INukeBuild
        {
            return new SchemaGenerator(
                build,
                new JsonSchemaGeneratorSettings
                {
                    FlattenInheritanceHierarchy = true,
                    SerializerSettings =
                        new JsonSerializerSettings
                        {
                            ContractResolver = new Resolver(),
                            Converters = new JsonConverter[] { new StringEnumConverter() }
                        }
                }).Generate();
        }

        private readonly INukeBuild _build;

        private SchemaGenerator(INukeBuild build, JsonSchemaGeneratorSettings settings)
            : base(settings)
        {
            _build = build;
        }

        private JsonSchema Generate()
        {
            var baseSchema = new JsonSchema();
            var userSchema = new JsonSchema();
            var schemaResolver = new JsonSchemaResolver(userSchema, Settings);

            var parameterMembers = ValueInjectionUtility.GetParameterMembers(_build.GetType(), includeUnlisted: true);
            foreach (var parameterMember in parameterMembers)
            {
                var schema = parameterMember.DeclaringType == typeof(NukeBuild) ? baseSchema : userSchema;
                var name = ParameterService.GetParameterMemberName(parameterMember);
                var property = CreateProperty(parameterMember, schemaResolver);
                schema.Properties[name] = property;
            }

            // ValueInjectionUtility.GetParameterMembers(_build.GetType(), includeUnlisted: true)
            //     // .Where(x => x.Name.EqualsAnyOrdinalIgnoreCase(
            //     //     nameof(NukeBuild.SkippedTargets),
            //     //     nameof(NukeBuild.InvokedTargets),
            //     //     nameof(NukeBuild.Verbosity)
            //     // ))
            //     .ToDictionary(ParameterService.GetParameterMemberName, x => CreateProperty(x, schemaResolver))
            //     .ForEach(x =>
            //     {
            //         baseSchema.Properties[x.Key] = x.Value;
            //     });

            userSchema.Reference = baseSchema;
            userSchema.Definitions[nameof(NukeBuild)] = baseSchema;

            // TODO: why can't this use value sets?
            var targetNames = ExecutableTargetFactory.GetTargetProperties(_build.GetType()).Select(x => x.GetDisplayShortName()).OrderBy(x => x);
            var executableTargetSchema = UpdatePropertySchema(nameof(ExecutableTarget), targetNames);
            baseSchema.Properties[InvokedTargetsParameterName].Item =
                baseSchema.Properties[SkippedTargetsParameterName].Item = new JsonSchema { Reference = executableTargetSchema };

            var hostNames = Host.AvailableTypes.Select(x => x.Name).OrderBy(x => x);
            var hostSchema = UpdatePropertySchema(nameof(NukeBuild.Host), hostNames);
            baseSchema.Properties[nameof(NukeBuild.Host)].Reference = hostSchema;

            RemoveXEnumValues();

            return userSchema;

            JsonSchema UpdatePropertySchema(string name, IEnumerable<string> values)
            {
                var schema = userSchema.Definitions[name];
                schema.Type = JsonObjectType.String;
                schema.AllowAdditionalProperties = true;
                schema.Enumeration.AddRange(values);
                return schema;
            }

            void RemoveXEnumValues()
            {
                foreach (var definition in userSchema.Definitions.Values)
                {
                    definition.EnumerationNames.Clear();
                    definition.AllowAdditionalProperties = true;
                }
            }
        }

        private JsonSchemaProperty CreateProperty(MemberInfo parameterMember, JsonSchemaResolver schemaResolver)
        {
            var property = parameterMember.GetCustomAttribute<ParameterAttribute>().NotNull().GetType() == typeof(ParameterAttribute)
                ? GenerateWithReference<JsonSchemaProperty>(
                    parameterMember.ToContextualAccessor().AccessorType,
                    schemaResolver)
                : new JsonSchemaProperty { Type = JsonObjectType.String };

            property.Description = ParameterService.GetParameterDescription(parameterMember);
            property.Default = parameterMember.HasCustomAttribute<SecretAttribute>()
                ? "Secrets must be entered via 'nuke :secrets [profile]'"
                : null;

            var values = ParameterService.GetParameterValueSet(parameterMember, _build)
                ?.Select(x => (object)x.Text);
            if (values != null && !parameterMember.GetMemberType().IsEnum)
            {
                property.Type = !parameterMember.GetMemberType().IsCollectionLike()
                    ? JsonObjectType.String
                    : JsonObjectType.Array;
                var propertySchema = property.Reference ?? property;
                if (property.Type == JsonObjectType.String)
                    propertySchema.Enumeration.AddRange(values);
                else
                    propertySchema.Item.Enumeration.AddRange(values);
            }

            if (Nullable.GetUnderlyingType(parameterMember.GetMemberType()) != null)
                property.Type |= JsonObjectType.Null;

            return property;
        }
    }

    public static string GetJsonString(INukeBuild build)
    {
        return SchemaGenerator.Generate(build).ToJson();
    }

    public static JsonDocument GetJsonDocument(INukeBuild build)
    {
        return JsonDocument.Parse(GetJsonString(build));
    }
}
