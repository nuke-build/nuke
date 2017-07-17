// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.ToolGenerator.Generators
{
    public static class DataClassExtensionGenerator
    {
        public static void Run (DataClass dataClass, ToolWriter toolWriter)
        {
            var writer = new DataClassWriter(dataClass, toolWriter);
            writer
                    .WriteLine("[PublicAPI]")
                    .WriteLine("[ExcludeFromCodeCoverage]")
                    .WriteLine($"public static partial class {dataClass.Name}Extensions")
                    .WriteBlock(w => w.ForEach(dataClass.Properties, WriteMethods));
        }

        // TODO [3]: less naming? -> value
        private static void WriteMethods (DataClassWriter writer, Property property)
        {
            if (property.CustomImpl || property.NoExtensionMethod)
                return;

            var reference = $"{writer.DataClass.Name}.{property.Name}".ToSeeCref();
            var propertyInstance = property.Name.ToInstance();

            if (!property.IsList() && !property.IsDictionary() && !property.IsLookupTable())
                writer
                        .WriteSummaryExtension($"Sets {reference}", property)
                        .WriteMethod(
                            $"Set{property.Name}",
                            property,
                            $"toolSettings.{property.Name} = {property.Name.ToInstance()};");

            if (property.IsBoolean())
            {
                writer
                        .WriteSummaryExtension($"Enables {reference}", property)
                        .WriteMethod($"Enable{property.Name}", $"toolSettings.{property.Name} = true;")
                        .WriteSummaryExtension($"Disables {reference}", property)
                        .WriteMethod($"Disable{property.Name}", $"toolSettings.{property.Name} = false;")
                        .WriteSummaryExtension($"Toggles {reference}", property)
                        .WriteMethod($"Toggle{property.Name}", $"toolSettings.{property.Name} = !toolSettings.{property.Name};");

                // TODO [4]: negate for 'skip', 'no', 'disable'
            }
            else if (property.IsList())
            {
                var propertyInternal = $"{property.Name}Internal";

                var valueType = property.GetListValueType();
                var propertySingular = property.Name.ToSingular();
                var propertySingularInstance = property.Name.ToSingular().ToInstance();

                writer
                        .WriteSummaryExtension($"Sets {reference} to a new list", property)
                        .WriteMethod($"Set{property.Name}",
                            $"params {valueType}[] {propertyInstance}",
                            $"toolSettings.{propertyInternal} = {propertyInstance}.ToList();")
                        .WriteSummaryExtension($"Sets {reference} to a new list", property)
                        .WriteMethod($"Set{property.Name}",
                            $"IEnumerable<{valueType}> {propertyInstance}",
                            $"toolSettings.{propertyInternal} = {propertyInstance}.ToList();")
                        .WriteSummaryExtension($"Adds a {propertyInstance} to the existing {reference}", property)
                        .WriteMethod($"Add{property.Name}",
                            $"params {valueType}[] {propertyInstance}",
                            $"toolSettings.{propertyInternal}.AddRange({propertyInstance});")
                        .WriteSummaryExtension($"Adds a {propertyInstance} to the existing {reference}", property)
                        .WriteMethod($"Add{property.Name}",
                            $"IEnumerable<{valueType}> {propertyInstance}",
                            $"toolSettings.{propertyInternal}.AddRange({propertyInstance});")
                        .WriteSummaryExtension($"Clears {reference}", property)
                        .WriteMethod($"Clear{property.Name}",
                            $"toolSettings.{propertyInternal}.Clear();")
                        .WriteSummaryExtension($"Adds a single {propertySingularInstance} to {reference}", property)
                        .WriteListAddMethod(propertySingular, propertySingularInstance, valueType, propertyInternal)
                        .WriteSummaryExtension($"Removes a single {propertySingularInstance} from {reference}", property)
                        .WriteMethod($"Remove{propertySingular}",
                            $"{valueType} {propertySingularInstance}",
                            $"toolSettings.{propertyInternal} = toolSettings.{property.Name}.Where(x => x == {propertySingularInstance}).ToList();");
            }
            else if (property.IsDictionary())
            {
                var propertyInternal = $"{property.Name}Internal";

                var (keyType, valueType) = property.GetDictionaryKeyValueTypes();
                var propertySingular = property.Name.ToSingular();
                var propertySingularInstance = property.Name.ToSingular().ToInstance();
                var keyInstance = $"{propertySingularInstance}Key";
                var valueInstance = $"{propertySingularInstance}Value";

                writer
                        .WriteSummaryExtension($"Sets {reference} to a new dictionary", property)
                        .WriteMethod($"Set{property.Name}",
                            $"IDictionary<{keyType}, {valueType}> {propertyInstance}",
                            $"toolSettings.{propertyInternal} = {propertyInstance}.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);")
                        .WriteSummaryExtension($"Clears {reference}", property)
                        .WriteMethod($"Clear{property.Name}",
                            $"toolSettings.{propertyInternal}.Clear();")
                        .WriteSummaryExtension($"Adds a {propertySingularInstance} to the existing {reference}", property)
                        .WriteMethod($"Add{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"toolSettings.{propertyInternal}.Add({keyInstance}, {valueInstance});")
                        .WriteSummaryExtension($"Removes a single {propertySingularInstance} from {reference}", property)
                        .WriteMethod($"Remove{propertySingular}",
                            $"{keyType} {keyInstance}",
                            $"toolSettings.{propertyInternal}.Remove({keyInstance});")
                        .WriteSummaryExtension($"Sets a {propertySingularInstance} in {reference}", property)
                        .WriteMethod($"Set{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"toolSettings.{propertyInternal}[{keyInstance}] = {valueInstance};");
            }
            else if (property.IsLookupTable())
            {
                var propertyInternal = $"{property.Name}Internal";

                var (keyType, valueType) = property.GetLookupTableKeyValueTypes();
                var propertySingular = property.Name.ToSingular();
                var propertySingularInstance = property.Name.ToSingular().ToInstance();
                var keyInstance = $"{propertySingularInstance}Key";
                var valueInstance = $"{propertySingularInstance}Value";

                writer
                        .WriteSummaryExtension($"Sets {reference} to a new lookup table", property)
                        .WriteMethod($"Set{property.Name}",
                            $"ILookup<{keyType}, {valueType}> {propertyInstance}",
                            $"toolSettings.{propertyInternal} = {propertyInstance}.ToLookupTable(StringComparer.OrdinalIgnoreCase);")
                        .WriteSummaryExtension($"Clears {reference}", property)
                        .WriteMethod($"Clear{property.Name}",
                            $"toolSettings.{propertyInternal}.Clear();")
                        .WriteSummaryExtension($"Adds a {propertySingularInstance} to the existing {reference}", property)
                        .WriteMethod($"Add{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"toolSettings.{propertyInternal}.Add({keyInstance}, {valueInstance});")
                        .WriteSummaryExtension($"Removes a single {propertySingularInstance} from {reference}", property)
                        .WriteMethod($"Remove{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"toolSettings.{propertyInternal}.Remove({keyInstance}, {valueInstance});");
            }
        }

        private static DataClassWriter WriteListAddMethod (
            this DataClassWriter writer,
            string propertySingular,
            string propertySingularInstance,
            string valueType,
            string propertyInternal)
        {
            return writer.DataClass.Tool.Enumerations.Select(x => x.Name).Concat(
                new[] { "int", "bool" }).Contains(valueType)
                ? writer.WriteMethod($"Add{propertySingular}",
                    $"{valueType} {propertySingularInstance}",
                    $"toolSettings.{propertyInternal}.Add({propertySingularInstance});")
                : writer.WriteMethod($"Add{propertySingular}",
                    $"{valueType} {propertySingularInstance}, bool evenIfNull = true",
                    $"if ({propertySingularInstance} != null || evenIfNull) toolSettings.{propertyInternal}.Add({propertySingularInstance});");
        }

        private static DataClassWriter WriteMethod (this DataClassWriter writer, string name, Property property, string modification)
        {
            return writer.WriteMethod(name, $"{property.GetNullabilityAttribute()}{property.Type} {property.Name.ToInstance()}", modification);
        }

        private static DataClassWriter WriteMethod (this DataClassWriter writer, string name, string additionalParameter, string modification)
        {
            return writer.WriteMethod(name, new[] { additionalParameter }, modification);
        }

        private static DataClassWriter WriteMethod (this DataClassWriter writer, string name, string modification)
        {
            return writer.WriteMethod(name, new string[0], modification);
        }

        private static DataClassWriter WriteMethod (
            this DataClassWriter writer,
            string name,
            IEnumerable<string> additionalParameters,
            string modification)
        {
            var parameters = new[] { $"this {writer.DataClass.Name} toolSettings" }.Concat(additionalParameters);
            return writer
                    .WriteLine("[Pure]")
                    .WriteLine($"public static {writer.DataClass.Name} {name}({parameters.Join()})")
                    .WriteBlock(w => w
                            .WriteLine("toolSettings = toolSettings.NewInstance();")
                            .WriteLine(modification)
                            .WriteLine("return toolSettings;"));
        }
    }
}
