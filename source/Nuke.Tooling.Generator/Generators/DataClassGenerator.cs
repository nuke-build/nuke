// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common;
using Nuke.Common.Utilities;
using Serilog;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators
{
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
            var baseType = dataClass.BaseClass ?? (dataClass.Name.EndsWith("Settings") ? "ToolSettings" : "ISettingsEntity");

            writer
                .WriteLine($"#region {dataClass.Name}")
                .WriteSummary(dataClass)
                .WriteLine("[PublicAPI]")
                .WriteObsoleteAttributeWhenObsolete(dataClass)
                .WriteLine("[ExcludeFromCodeCoverage]")
                .WriteLine("[Serializable]")
                .WriteLine($"public partial class {dataClass.Name} : {baseType}")
                .WriteBlock(w => w
                    .WriteProcessToolPath()
                    .WriteProcessCustomLogger()
                    .ForEach(dataClass.Properties, WritePropertyDeclaration)
                    .WriteConfigureArguments())
                .WriteLine("#endregion");
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

        private static DataClassWriter WriteProcessToolPath(this DataClassWriter writer)
        {
            if (writer.DataClass is not SettingsClass settingsClass)
                return writer;

            var tool = settingsClass.Tool.NotNull();
            var resolver = !tool.CustomExecutable
                ? $"{tool.GetClassName()}.{tool.Name}Path"
                : "GetProcessToolPath()";

            return writer
                .WriteSummary($"Path to the {tool.Name} executable.")
                .WriteLine($"public override string ProcessToolPath => base.ProcessToolPath ?? {resolver};");
        }

        private static DataClassWriter WriteProcessCustomLogger(this DataClassWriter writer)
        {
            if (!writer.DataClass.IsToolSettingsClass)
                return writer;

            var tool = writer.DataClass.Tool;
            var logger = $"{tool.GetClassName()}.{tool.Name}Logger";
            return writer.WriteLine($"public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? {logger};");
        }

        private static void WritePropertyDeclaration(DataClassWriter writer, Property property)
        {
            if (property.CustomImpl)
                return;

            var type = GetPublicPropertyType(property);
            var implementation = GetPublicPropertyImplementation(property);
            var hasInternalProperty = property.IsList() || property.IsDictionary() || property.IsLookupTable();

            writer
                .WriteSummary(property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteLineIfTrue(!hasInternalProperty, GetJsonSerializationAttribute(property))
                .WriteLineIfTrue(hasInternalProperty, GetJsonIgnoreAttribute(property))
                .WriteLine($"public virtual {type} {property.Name} {implementation}")
                .WriteLineIfTrue(hasInternalProperty, GetJsonSerializationAttribute(property))
                .WriteLineIfTrue(hasInternalProperty, $"internal {property.Type} {property.Name}Internal {{ get; set; }}{GetPropertyInitialization(property)}");
        }

        private static string GetJsonSerializationAttribute(Property property)
        {
            return !string.IsNullOrWhiteSpace(property.Json) ? $"[JsonProperty({property.Json.DoubleQuote()})]" : null;
        }

        private static string GetJsonIgnoreAttribute(Property property)
        {
            return !string.IsNullOrWhiteSpace(property.Json) ? "[JsonIgnore]" : null;
        }

        private static string GetPropertyInitialization(Property property)
        {
            string initializationExpression;
            if (property.IsList())
                initializationExpression = $"new {property.Type}()";
            else if (property.IsDictionary() || property.IsLookupTable())
                initializationExpression = $"new {property.Type}({property.GetKeyComparer()})";
            else
                initializationExpression = property.Default;

            return initializationExpression != null
                ? $" = {initializationExpression};"
                : string.Empty;
        }

        private static string GetPublicPropertyImplementation(Property property)
        {
            return property.IsList() || property.IsDictionary() || property.IsLookupTable()
                ? $"=> {property.Name}Internal.AsReadOnly();"
                : $"{{ get; internal set; }}{GetPropertyInitialization(property)}";
        }

        private static string GetPublicPropertyType(Property property)
        {
            if (property.IsList())
                return $"IReadOnlyList<{property.GetListValueType()}>";

            if (property.IsDictionary())
            {
                var (keyType, valueType) = property.GetDictionaryKeyValueTypes();
                return $"IReadOnlyDictionary<{keyType}, {valueType}>";
            }

            if (property.IsLookupTable())
            {
                var (keyType, valueType) = property.GetLookupTableKeyValueTypes();
                return $"ILookup<{keyType}, {valueType}>";
            }

            return property.GetNullableType();
        }

        private static DataClassWriter WriteConfigureArguments(this DataClassWriter writer)
        {
            var formatProperties = writer.DataClass.Properties.Where(x => x.Format != null).ToList();
            if ((writer.DataClass as SettingsClass)?.Task.DefiniteArgument == null && formatProperties.Count == 0)
                return writer;

            var argumentAdditions = formatProperties.Select(GetArgumentAddition).ToList();

            var settingsClass = writer.DataClass as SettingsClass;
            if (settingsClass?.Task.DefiniteArgument != null)
                argumentAdditions.Insert(index: 0, $"  .Add({settingsClass.Task.DefiniteArgument.DoubleQuote()})");

            var hasArguments = argumentAdditions.Count > 0;
            if (hasArguments)
                argumentAdditions[argumentAdditions.Count - 1] += ";";

            return writer
                .WriteLine("protected override Arguments ConfigureProcessArguments(Arguments arguments)")
                .WriteBlock(w => w
                    .WriteLine("arguments")
                    .ForEachWriteLine(argumentAdditions)
                    .WriteLine("return base.ConfigureProcessArguments(arguments);"));
        }

        private static string GetArgumentAddition(Property property)
        {
            var arguments = new List<string>
                            {
                                property.Format.DoubleQuote(),
                                property.CustomValue ? $"Get{property.Name}()" : property.Name
                            };
            if (property.IsDictionary() || property.IsLookupTable())
                arguments.Add(property.ItemFormat.NotNull($"{property.Name}.ItemFormat != null").DoubleQuote());
            if (property.Separator.HasValue)
                arguments.Add($"separator: {property.Separator.SingleQuote()}");
            if (property.DisallowedCharacter.HasValue)
                arguments.Add($"disallowed: {property.DisallowedCharacter.SingleQuote()}");
            if (property.QuoteMultiple)
                arguments.Add("quoteMultiple: true");
            if (property.CustomValue)
                arguments.Add("customValue: true");
            if (property.Secret ?? false)
                arguments.Add("secret: true");

            return $"  .Add({arguments.JoinCommaSpace()})";
        }
    }
}
