// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

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

        private static void WriteMethods (DataClassWriter writer, Property property)
        {
            var reference = $"{writer.DataClass.Name}.{property.Name}".ToSeeCref();
            var instanceName = writer.DataClass.Name.ToInstance();
            var propertyInstance = property.Name.ToInstance();

            if (!property.IsList() && !property.IsDictionary() && !property.IsLookupTable())
                writer
                        .WriteSummaryExtension($"setting {reference}", property)
                        .WriteMethod(
                            $"Set{property.Name}",
                            property,
                            $"{instanceName}.{property.Name} = {property.Name.ToInstance()};");

            if (property.IsBoolean())
            {
                writer
                        .WriteSummaryExtension($"enabling {reference}", property)
                        .WriteMethod($"Enable{property.Name}", $"{instanceName}.{property.Name} = true;")
                        .WriteSummaryExtension($"disabling {reference}", property)
                        .WriteMethod($"Disable{property.Name}", $"{instanceName}.{property.Name} = false;")
                        .WriteSummaryExtension($"toggling {reference}", property)
                        .WriteMethod($"Toggle{property.Name}", $"{instanceName}.{property.Name} = !{instanceName}.{property.Name};");

                // TODO: negate for 'skip', 'no', 'disable'
            }
            else if (property.IsList())
            {
                var propertyInternal = $"{property.Name}Internal";

                var valueType = property.GetListValueType();
                var propertySingular = property.Name.ToSingular();
                var propertySingularInstance = property.Name.ToSingular().ToInstance();

                writer
                        .WriteSummaryExtension($"setting {reference} to a new list", property)
                        .WriteMethod($"Set{property.Name}",
                            $"params {valueType}[] {propertyInstance}",
                            $"{instanceName}.{propertyInternal} = {propertyInstance}.ToList();")
                        .WriteSummaryExtension($"setting {reference} to a new list", property)
                        .WriteMethod($"Set{property.Name}",
                            $"IEnumerable<{valueType}> {propertyInstance}",
                            $"{instanceName}.{propertyInternal} = {propertyInstance}.ToList();")
                        .WriteSummaryExtension($"adding new {propertyInstance} to the existing {reference}", property)
                        .WriteMethod($"Add{property.Name}",
                            $"params {valueType}[] {propertyInstance}",
                            $"{instanceName}.{propertyInternal}.AddRange({propertyInstance});")
                        .WriteSummaryExtension($"adding new {propertyInstance} to the existing {reference}", property)
                        .WriteMethod($"Add{property.Name}",
                            $"IEnumerable<{valueType}> {propertyInstance}",
                            $"{instanceName}.{propertyInternal}.AddRange({propertyInstance});")
                        .WriteSummaryExtension($"clearing {reference}", property)
                        .WriteMethod($"Clear{property.Name}",
                            $"{instanceName}.{propertyInternal}.Clear();")
                        .WriteSummaryExtension($"adding a single {propertySingularInstance} to {reference}", property)
                        .WriteMethod($"Add{propertySingular}",
                            $"{valueType} {propertySingularInstance}",
                            $"{instanceName}.{propertyInternal}.Add({propertySingularInstance});")
                        .WriteSummaryExtension($"removing a single {propertySingularInstance} from {reference}", property)
                        .WriteMethod($"Remove{propertySingular}",
                            $"{valueType} {propertySingularInstance}",
                            $"{instanceName}.{propertyInternal}.Remove({propertySingularInstance});");
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
                        .WriteSummaryExtension($"setting {reference} to a new dictionary", property)
                        .WriteMethod($"Set{property.Name}",
                            $"IDictionary<{keyType}, {valueType}> {propertyInstance}",
                            $"{instanceName}.{propertyInternal} = {propertyInstance}.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);")
                        .WriteSummaryExtension($"clearing {reference}", property)
                        .WriteMethod($"Clear{property.Name}",
                            $"{instanceName}.{propertyInternal}.Clear();")
                        .WriteSummaryExtension($"adding a {propertySingularInstance} to {reference}", property)
                        .WriteMethod($"Add{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"{instanceName}.{propertyInternal}.Add({keyInstance}, {valueInstance});")
                        .WriteSummaryExtension($"removing a {propertySingularInstance} from {reference}", property)
                        .WriteMethod($"Remove{propertySingular}",
                            $"{keyType} {keyInstance}",
                            $"{instanceName}.{propertyInternal}.Remove({keyInstance});")
                        .WriteSummaryExtension($"setting a {propertySingularInstance} in {reference}", property)
                        .WriteMethod($"Set{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"{instanceName}.{propertyInternal}[{keyInstance}] = {valueInstance};");
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
                        .WriteSummaryExtension($"setting {reference} to a new lookup table", property)
                        .WriteMethod($"Set{property.Name}",
                            $"ILookup<{keyType}, {valueType}> {propertyInstance}",
                            $"{instanceName}.{propertyInternal} = {propertyInstance}.ToLookupTable(StringComparer.OrdinalIgnoreCase);")
                        .WriteSummaryExtension($"clearing {reference}", property)
                        .WriteMethod($"Clear{property.Name}",
                            $"{instanceName}.{propertyInternal}.Clear();")
                        .WriteSummaryExtension($"adding a {propertySingularInstance} to {reference}", property)
                        .WriteMethod($"Add{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"{instanceName}.{propertyInternal}.Add({keyInstance}, {valueInstance});")
                        .WriteSummaryExtension($"removing a single {propertySingularInstance} entry from {reference}", property)
                        .WriteMethod($"Remove{propertySingular}",
                            new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                            $"{instanceName}.{propertyInternal}.Remove({keyInstance}, {valueInstance});");
            }
        }

        private static DataClassWriter WriteMethod (this DataClassWriter writer, string name, Property property, string modification)
        {
            return WriteMethod(writer, name, $"{property.GetNullabilityAttribute()}{property.Type} {property.Name.ToInstance()}", modification);
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
            var instanceName = writer.DataClass.Name.ToInstance();
            var parameters = new[] { $"this {writer.DataClass.Name} {instanceName}" }.Concat(additionalParameters);
            return writer
                    .WriteLine("[Pure]")
                    .WriteLine($"public static {writer.DataClass.Name} {name}({parameters.Join()})")
                    .WriteBlock(w => w
                            .WriteLine($"{instanceName} = {instanceName}.NewInstance();")
                            .WriteLine(modification)
                            .WriteLine($"return {instanceName};"));
        }
    }
}
