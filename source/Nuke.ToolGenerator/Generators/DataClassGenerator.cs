// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.ToolGenerator.Generators
{
    public static class DataClassGenerator
    {
        public static void Run (DataClass dataClass, ToolWriter toolWriter)
        {
            if (!dataClass.NoArguments)
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
                    .WriteLine("[ExcludeFromCodeCoverage]")
                    .WriteLine("[Serializable]")
                    .WriteLine($"public partial class {dataClass.Name} : {baseType}")
                    .WriteBlock(w => w
                            .WriteToolPath()
                            .ForEach(dataClass.Properties, WritePropertyDeclaration)
                            .WriteAssertValid()
                            .WriteGetArgumentsInternal())
                    .WriteLine("#endregion");
        }

        // ReSharper disable once CyclomaticComplexity
        private static DataClassWriter WriteToolPath (this DataClassWriter writer)
        {
            var settingsClass = writer.DataClass as SettingsClass;
            if (settingsClass == null)
                return writer;

            var tool = settingsClass.Tool.NotNull();
            var arguments = new List<string>();
            if (tool.PackageId != null)
            {
                arguments.Add($"packageId: {tool.PackageId.Quote()}");
                arguments.Add($"packageExecutable: {(tool.PackageExecutable ?? "{GetPackageExecutable()}").Quote()}");
            }
            if (tool.EnvironmentExecutable != null)
                arguments.Add($"environmentExecutable: {tool.EnvironmentExecutable.Quote()}");
            if (tool.PathExecutable != null)
                arguments.Add($"pathExecutable: {tool.PathExecutable.Quote()}");

            if (arguments.Count == 0 && tool.CustomExecutable == null)
                return writer;

            var toolPathResolver = tool.CustomExecutable ?? $"ToolPathResolver.GetToolPath({arguments.Join()})";

            return writer
                    .WriteSummary($"Path to the {tool.Name} executable.")
                    .WriteLine($"public override string ToolPath => base.ToolPath ?? {toolPathResolver};");
        }

        private static void WritePropertyDeclaration (DataClassWriter writer, Property property)
        {
            if (property.CustomImpl)
                return;

            writer
                    .WriteSummary(property)
                    .WriteLine(GetPublicPropertyDeclaration(property))
                    .WriteLine(GetInternalPropertyDeclarationOrNull(property));
        }

        [CanBeNull]
        private static string GetInternalPropertyDeclarationOrNull (Property property)
        {
            if (!property.IsList() && !property.IsDictionary() && !property.IsLookupTable())
                return null;

            return $"internal {property.Type} {property.Name}Internal {{ get; set; }}{GetPropertyInitialization(property)}";
        }

        private static string GetPublicPropertyDeclaration (Property property)
        {
            var type = GetPublicPropertyType(property);
            var implementation = GetPublicPropertyImplementation(property);
            return $"public virtual {type} {property.Name} {implementation}";
        }

        private static string GetPropertyInitialization (Property property)
        {
            string initializationExpression;
            if (property.IsList())
                initializationExpression = $"new {property.Type}()";
            else if (property.IsDictionary() || property.IsLookupTable())
                initializationExpression = $"new {property.Type}(StringComparer.OrdinalIgnoreCase)";
            else
                initializationExpression = property.Default;

            return initializationExpression != null
                ? $" = {initializationExpression};"
                : string.Empty;
        }

        private static string GetPublicPropertyImplementation (Property property)
        {
            return property.IsList() || property.IsDictionary() || property.IsLookupTable()
                ? $"=> {property.Name}Internal.AsReadOnly();"
                : $"{{ get; internal set; }}{GetPropertyInitialization(property)}";
        }

        private static string GetPublicPropertyType (Property property)
        {
            if (property.IsList())
            {
                return $"IReadOnlyList<{property.GetListValueType()}>";
            }

            if (property.IsDictionary())
            {
                var (keyType, valueType) = property.GetDictionaryKeyValueTypes();
                return $"IReadOnlyDictionary<{keyType}, {valueType}>";
            }

            if (property.IsLookupTable())
            {
                var (keyType, valueType) = property.GetDictionaryKeyValueTypes();
                return $"ILookup<{keyType}, {valueType}>";
            }

            return property.Type;
        }


        private static DataClassWriter WriteAssertValid (this DataClassWriter writer)
        {
            var validatedProperties = writer.DataClass.Properties.Where(x => x.Assertion != null).ToList();
            if (validatedProperties.Count == 0)
                return writer;

            return writer
                    .WriteLine("protected override void AssertValid()")
                    .WriteBlock(w => w
                            .WriteLine("base.AssertValid();")
                            .ForEach(
                                validatedProperties.Select(GetAssertion),
                                assertion => w.WriteLine($"ControlFlow.Assert({assertion}, {assertion.Quote()});"))
                    );
        }

        private static string GetAssertion (Property property)
        {
            switch (property.Assertion)
            {
                case AssertionType.NotNull:
                    return $"{property.Name} != null";
                case AssertionType.File:
                    return $"File.Exists({property.Name})";
                case AssertionType.Directory:
                    return $"Directory.Exists({property.Name})";
                case AssertionType.FileOrNull:
                    return $"File.Exists({property.Name}) || {property.Name} == null";
                case AssertionType.DirectoryOrNull:
                    return $"Directory.Exists({property.Name}) || {property.Name} == null";
                default:
                    throw new NotSupportedException(property.Assertion.ToString());
            }
        }

        private static DataClassWriter WriteGetArgumentsInternal (this DataClassWriter writer)
        {
            var formatProperties = writer.DataClass.Properties.Where(x => x.Format != null).ToList();
            if ((writer.DataClass as SettingsClass)?.Task.DefiniteArgument == null && formatProperties.Count == 0)
                return writer;

            var argumentAdditions = formatProperties.Select(GetArgumentAddition).ToArray();
            ref var last = ref argumentAdditions[argumentAdditions.Length - 1];
            last += ";";

            return writer
                    .WriteLine("protected override Arguments GetArgumentsInternal()")
                    .WriteBlock(w => w
                            .WriteLine("return base.GetArgumentsInternal()")
                            .WriteLine(GetCommandAdditionOrNull(writer.DataClass))
                            .ForEachWriteLine(argumentAdditions));
        }

        [CanBeNull]
        private static string GetCommandAdditionOrNull (DataClass dataClass)
        {
            var settingsClass = dataClass as SettingsClass;
            return settingsClass?.Task.DefiniteArgument != null
                ? $"  .Add({settingsClass.Task.DefiniteArgument.Quote(interpolation: false)})"
                : null;
        }

        private static string GetArgumentAddition (Property property)
        {
            var arguments = new List<string>
                            {
                                property.Format.Quote(interpolation: false),
                                property.CustomValue ? $"Get{property.Name}()" : property.Name
                            };
            if (property.MainSeparator != null)
                arguments.Add($"mainSeparator: {property.MainSeparator.Quote()}");
            if (property.KeyValueSeparator != null)
                arguments.Add($"keyValueSeparator: {property.KeyValueSeparator.Quote()}");
            if (property.Secret)
                arguments.Add($"secret: true");

            return $"  .Add({arguments.Join()})";
        }
    }
}
