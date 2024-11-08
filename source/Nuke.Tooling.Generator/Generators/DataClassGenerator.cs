// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators;

public static class DataClassGenerator
{
    public static void Run(DataClass dataClass, ToolWriter toolWriter)
    {
        if (dataClass.OmitDataClass)
            return;

        if (dataClass.IsToolSettingsClass)
        {
            foreach (var property in dataClass.Properties)
            {
                CheckMissingValue(property);
                CheckMissingSecret(property);
            }
        }

        var writer = new DataClassWriter(dataClass, toolWriter);
        var baseTypes = new[]
        {
            dataClass.BaseClass ?? (dataClass.Name.EndsWith("Settings") ? nameof(ToolOptions) : nameof(Options)),
            dataClass.Tool.NuGetFramework ? "IToolOptionsWithFramework" : null
        }.WhereNotNull();

        writer
            .WriteLine($"#region {dataClass.Name}")
            .WriteSummary(dataClass)
            .WriteLine("[PublicAPI]")
            .WriteObsoleteAttributeWhenObsolete(dataClass)
            .WriteLine("[ExcludeFromCodeCoverage]")
            .WriteLine($"[TypeConverter(typeof(TypeConverter<{dataClass.Name}>))]")
            .WriteLine(GetCommandAttribute())
            .WriteLine($"public partial class {dataClass.Name} : {baseTypes.JoinCommaSpace()}")
            .WriteBlock(w => w
                .ForEach(dataClass.Properties, WritePropertyDeclaration))
            .WriteLine("#endregion");

        string GetCommandAttribute()
        {
            if (dataClass is not SettingsClass settingsClass)
                return null;

            var commandArguments = new (string Name, string Value)[]
                {
                    (nameof(CommandAttribute.Type), $"typeof({dataClass.Tool.GetClassName()})"),
                    (nameof(CommandAttribute.Command), $"nameof({dataClass.Tool.GetClassName()}.{settingsClass.Task.GetTaskMethodName()})"),
                    (nameof(CommandAttribute.Arguments), settingsClass.Task.DefiniteArgument?.DoubleQuote()),
                }.Where(x => x.Item2 != null)
                .Select(x => $"{x.Name} = {x.Value}").JoinCommaSpace();
            return $"[Command({commandArguments})]";
        }
    }

    private static void CheckMissingValue(Property property)
    {
        if (property.NoArgument)
            return;

        if (property.Format != null && property.Format.Contains("{value}"))
            return;

        if (new[] { "int", "bool" }.Contains(property.Type))
            return;

        Log.Warning("Property {ClassName}.{PropertyName} doesn't contain '{{value}}'", property.DataClass.Name, property.Name);
    }

    private static void CheckMissingSecret(Property property)
    {
        if (property.Secret.HasValue)
            return;

        if (!property.Name.ContainsOrdinalIgnoreCase("key") &&
            !property.Name.ContainsOrdinalIgnoreCase("password") &&
            !property.Name.ContainsOrdinalIgnoreCase("token"))
            return;

        Log.Warning("Property {ClassName}.{PropertyName} should have explicit secret definition", property.DataClass.Name, property.Name);
    }

    private static void WritePropertyDeclaration(DataClassWriter writer, Property property)
    {
        if (property.CustomImpl)
            return;

        var type = GetPropertyType(property);
        var attributes = new[] { GetArgumentAttribute(), GetJsonPropertyAttribute() }.WhereNotNull();

        writer
            .WriteLine($"/// <summary>{property.Help}</summary>")
            .WriteLine($"{attributes.JoinSpace()} public {type.External} {property.Name} => Get<{type.Internal}>(() => {property.Name});");

        string GetArgumentAttribute()
        {
            if (property.Format.IsNullOrWhiteSpace())
                return null;

            var arguments = new (string Name, string Value)[]
                {
                    (nameof(ArgumentAttribute.Format), property.Format?.DoubleQuote()),
                    (nameof(ArgumentAttribute.Position), property.Position?.ToString().ToLowerInvariant()),
                    (nameof(ArgumentAttribute.Secret), property.Secret?.ToString().ToLowerInvariant()),
                    (nameof(ArgumentAttribute.Separator), property.Separator?.DoubleQuote()),
                    (nameof(ArgumentAttribute.QuoteMultiple), property.QuoteMultiple ? bool.TrueString.ToLowerInvariant() : null),
                    (nameof(ArgumentAttribute.FormatterMethod), property.Formatter?.Apply<string, string>(x => $"nameof({x})")),
                }.Where(x => x.Item2 != null)
                .Select(x => $"{x.Name} = {x.Value}").JoinCommaSpace();

            return $"[Argument({arguments})]";
        }

        string GetJsonPropertyAttribute()
        {
            if (property.Json.IsNullOrWhiteSpace())
                return null;

            return $"[JsonProperty({property.Json.DoubleQuote()})]";
        }
    }

    private static (string External, string Internal) GetPropertyType(Property property)
    {
        if (property.IsList())
            return ($"IReadOnlyList<{property.GetListValueType()}>", $"List<{property.GetListValueType()}>");

        if (property.IsDictionary())
        {
            var (keyType, valueType) = property.GetDictionaryKeyValueTypes();
            return ($"IReadOnlyDictionary<{keyType}, {valueType}>", $"Dictionary<{keyType}, {valueType}>");
        }

        if (property.IsLookupTable())
        {
            var (keyType, valueType) = property.GetLookupTableKeyValueTypes();
            return ($"ILookup<{keyType}, {valueType}>", $"LookupTable<{keyType}, {valueType}>");
        }

        return (property.GetNullableType(), property.GetNullableType());
    }
}
