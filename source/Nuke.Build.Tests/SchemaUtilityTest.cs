// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NJsonSchema.Generation;
using NuGet.Packaging;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;
using VerifyXunit;
using Xunit;

namespace Nuke.Common.Tests;

public class SchemaUtilityTest
{
    public class Resolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            return objectType == typeof(ExecutableTarget) || objectType == typeof(Host)
                ? new List<MemberInfo>()
                : base.GetSerializableMembers(objectType);
        }
    }

    private class BuildSchemaGenerator : JsonSchemaGenerator
    {
        public static JsonSchema Generate<T>(T build)
            where T : INukeBuild
        {
            return new BuildSchemaGenerator(
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

        private BuildSchemaGenerator(INukeBuild build, JsonSchemaGeneratorSettings settings)
            : base(settings)
        {
            _build = build;
        }

        public JsonSchema Generate()
        {
            var userSchema = new JsonSchema();
            var baseSchema = new JsonSchema();
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
            userSchema.Definitions["NukeBuild"] = baseSchema;

            JsonSchema UpdatePropertySchema(string name, IEnumerable<string> values)
            {
                var schema = userSchema.Definitions[name];
                schema.Type = JsonObjectType.String;
                schema.AllowAdditionalProperties = true;
                schema.Enumeration.AddRange(values);
                return schema;
            }

            // TODO: why can't this use value sets?
            var targetNames = ExecutableTargetFactory.GetTargetProperties(_build.GetType()).Select(x => x.GetDisplayShortName()).OrderBy(x => x);
            var executableTargetSchema = UpdatePropertySchema("ExecutableTarget", targetNames);
            baseSchema.Properties["Target"].Item = baseSchema.Properties["Skip"].Item = new JsonSchema { Reference = executableTargetSchema };

            var hostNames = Host.AvailableTypes.Select(x => x.Name).OrderBy(x => x);
            var hostSchema = UpdatePropertySchema("Host", hostNames);
            baseSchema.Properties["Host"].Reference = hostSchema;

            foreach (var definition in userSchema.Definitions.Values)
            {
                definition.EnumerationNames.Clear();
                definition.AllowAdditionalProperties = true;
            }

            return userSchema;
        }

        private JsonSchemaProperty CreateProperty(MemberInfo parameterMember, JsonSchemaResolver schemaResolver)
        {
            var property = GenerateWithReference<JsonSchemaProperty>(
                parameterMember.ToContextualAccessor().AccessorType,
                schemaResolver);

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

    [Fact]
    public Task TestEmptyBuild()
    {
        var jsonSchema = BuildSchemaGenerator.Generate(new EmptyBuild());
        return Verifier.Verify(jsonSchema.ToJson(), "json");
    }

    [Fact]
    public Task TestTargetBuild()
    {
        var jsonSchema = BuildSchemaGenerator.Generate(new TargetBuild());
        return Verifier.Verify(jsonSchema.ToJson(), "json");
    }

    [Fact]
    public Task TestParameterBuild()
    {
        var jsonSchema = BuildSchemaGenerator.Generate(new ParameterBuild());
        return Verifier.Verify(jsonSchema.ToJson(), "json");
    }

    [Fact]
    public Task TestGetBuildSchema()
    {
        var schema = SchemaUtility.GetBuildSchema(new ParameterBuild());
        var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        var json = System.Text.Json.JsonSerializer.Serialize(schema, options);
        return Verifier.Verify(json, "json");
    }

    // ReSharper disable All
    private class EmptyBuild : NukeBuild
    {
    }

    private class TargetBuild : NukeBuild, ITargetComponent
    {
        Target RegularTarget => _ => _;
        public Target ImplementedTarget => _ => _;
        Target ITargetComponent.ExplicitTarget => _ => _;
    }

    private interface ITargetComponent : INukeBuild
    {
        Target InheritedTarget => _ => _;
        Target ImplementedTarget => _ => _;
        Target ExplicitTarget => _ => _;
    }

    private class ParameterBuild : NukeBuild, IParameterComponent
    {
        [Parameter] readonly string RegularParam;
        [Parameter] [Secret] readonly string SecretParam;

        [Parameter] readonly bool BooleanParam;
        [Parameter] readonly bool? NullableBooleanParam;

        [Parameter] readonly string[] StringArrayParam;
        [Parameter] readonly int[] IntegerArrayParam;

        [Parameter] readonly CustomEnumeration CustomEnumerationParam;
        [Parameter] readonly CustomEnumeration[] CustomEnumerationArrayParam;

        [Parameter] readonly ComplexType ComplexTypeParam;
        [Parameter] readonly ComplexType[] ComplexTypeArrayParam;
    }

    [ParameterPrefix("Component")]
    private interface IParameterComponent : INukeBuild
    {
        [Parameter] string InheritedParam => TryGetValue(() => InheritedParam);
    }

    private class ComplexType
    {
        public string String;
        public int Number;
        public AbsolutePath[] Paths;
        public ComplexSubType SubObject;
    }

    private class ComplexSubType
    {
        public bool? Boolean;
    }

    [TypeConverter(typeof(TypeConverter<CustomEnumeration>))]
    public class CustomEnumeration : Enumeration
    {
        public static CustomEnumeration Debug = new() { Value = nameof(Debug) };
        public static CustomEnumeration Release = new() { Value = nameof(Release) };

        public static implicit operator string(CustomEnumeration configuration)
        {
            return configuration.Value;
        }
    }
    // ReSharper restore All
}
