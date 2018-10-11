// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common;
using Nuke.Common.Utilities;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators
{
    public static class DataClassGenerator
    {
        public static void Run(DataClass dataClass, ToolWriter toolWriter)
        {
            if (dataClass.ArgumentConstruction)
            {
                foreach (var property in dataClass.Properties)
                {
                    if (property.NoArgument)
                        continue;

                    if (new[] { "int", "bool" }.Contains(property.Type))
                        continue;

                    if (property.Format != null && property.Format.Contains("{value}"))
                        continue;

                    Console.WriteLine($"Format for '{dataClass.Name}.{property.Name}' doesn't contain '{{value}}'.");
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
                    .WriteToolPath()
                    .WriteLogLevelParser()
                    .ForEach(dataClass.Properties, WritePropertyDeclaration)
                    .WriteAssertValid()
                    .WriteConfigureArguments())
                .WriteLine("#endregion");
        }

        private static DataClassWriter WriteToolPath(this DataClassWriter writer)
        {
            if (!(writer.DataClass is SettingsClass settingsClass))
                return writer;

            var tool = settingsClass.Tool.NotNull();
            var resolver = !tool.CustomExecutable
                ? $"{tool.GetClassName()}.{tool.Name}Path"
                : "GetToolPath()";

            return writer
                .WriteSummary($"Path to the {tool.Name} executable.")
                .WriteLine($"public override string ToolPath => base.ToolPath ?? {resolver};");
        }

        private static DataClassWriter WriteLogLevelParser(this DataClassWriter writer)
        {
            var tool = writer.DataClass.Tool;
            if (!tool.LogLevelParsing)
                return writer;

            var logLevelParser = $"{tool.GetClassName()}.ParseLogLevel";
            return writer.WriteLine($"protected override Func<string, LogLevel> LogLevelParser => {logLevelParser};");
        }

        private static void WritePropertyDeclaration(DataClassWriter writer, Property property)
        {
            if (property.CustomImpl)
                return;

            writer
                .WriteSummary(property)
                .WritePublicProperty(property)
                .WriteInternalPropertyWhenNeeded(property);
        }

        private static string GetJsonSerializationAttribute(Property property)
        {
            if (string.IsNullOrWhiteSpace(property.Json))
                return null;

            return $"[JsonProperty({property.Json.DoubleQuote()})]";
        }

        private static T WriteInternalPropertyWhenNeeded<T>(this T writer, Property property)
            where T : DataClassWriter
        {
            if (!property.IsList() && !property.IsDictionary() && !property.IsLookupTable())
                return writer;
            return writer.WriteLine($"internal {property.Type} {property.Name}Internal {{ get; set; }}{GetPropertyInitialization(property)}");
        }

        private static T WritePublicProperty<T>(this T writer, Property property)
            where T : DataClassWriter
        {
            var type = GetPublicPropertyType(property);
            var implementation = GetPublicPropertyImplementation(property);
            return writer
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteLine(GetJsonSerializationAttribute(property))
                .WriteLine($"public virtual {type} {property.Name} {implementation}");
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

        private static DataClassWriter WriteAssertValid(this DataClassWriter writer)
        {
            var validatedProperties = writer.DataClass.Properties.Where(x => x.Assertion != null).ToList();
            if (validatedProperties.Count == 0)
                return writer;

            return writer
                .WriteLine("protected override void AssertValid()")
                .WriteBlock(w => w
                    .WriteLine("base.AssertValid();")
                    .ForEach(
                        validatedProperties.Select(GetAssertedProperty),
                        assertedProperty =>
                            w.WriteLine(
                                $"ControlFlow.Assert({assertedProperty.assertion}, {AssertionWithValue(assertedProperty.assertion, assertedProperty.propertyName)});"))
                );
        }

        private static string AssertionWithValue(string assertion, string propertyName)
        {
            return $"{assertion} [{propertyName} = {{{propertyName}}}]".DoubleQuoteInterpolated();
        }

        private static (string assertion, string propertyName) GetAssertedProperty(Property property)
        {
            switch (property.Assertion)
            {
                case AssertionType.NotNull:
                    return ($"{property.Name} != null", property.Name);
                case AssertionType.File:
                    return ($"File.Exists({property.Name})", property.Name);
                case AssertionType.Directory:
                    return ($"Directory.Exists({property.Name})", property.Name);
                case AssertionType.FileOrNull:
                    return ($"File.Exists({property.Name}) || {property.Name} == null", property.Name);
                case AssertionType.DirectoryOrNull:
                    return ($"Directory.Exists({property.Name}) || {property.Name} == null", property.Name);
                default:
                    throw new NotSupportedException(property.Assertion.ToString());
            }
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
                .WriteLine("protected override Arguments ConfigureArguments(Arguments arguments)")
                .WriteBlock(w => w
                    .WriteLine("arguments")
                    .ForEachWriteLine(argumentAdditions)
                    .WriteLine("return base.ConfigureArguments(arguments);"));
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
            if (property.Secret)
                arguments.Add("secret: true");

            return $"  .Add({arguments.JoinComma()})";
        }
    }
}
