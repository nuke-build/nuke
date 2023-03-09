// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common.Utilities;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators
{
    public static class DataClassExtensionGenerator
    {
        public static void Run(DataClass dataClass, ToolWriter toolWriter)
        {
            var writer = new DataClassWriter(dataClass, toolWriter);
            writer
                .WriteLine($"#region {dataClass.Name}Extensions")
                .WriteSummary(dataClass)
                .WriteLine("[PublicAPI]")
                .WriteObsoleteAttributeWhenObsolete(dataClass)
                .WriteLine("[ExcludeFromCodeCoverage]")
                .WriteLine($"public static partial class {dataClass.Name}Extensions")
                .WriteBlock(w => w.ForEach(dataClass.Properties, WriteMethods))
                .WriteLine("#endregion");
        }

        // TODO [3]: less naming? -> value
        private static void WriteMethods(DataClassWriter writer, Property property)
        {
            if (property.CustomImpl)
                return;

            writer.WriteLine($"#region {property.Name}");

            if (!property.IsList() && !property.IsDictionary() && !property.IsLookupTable())
            {
                writer
                    .WriteSummaryExtension($"Sets {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod(
                        $"Set{property.Name}",
                        property,
                        $"toolSettings.{property.Name} = {property.Name.ToInstance().EscapeParameter()};")
                    .WriteSummaryExtension($"Resets {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod(
                        $"Reset{property.Name}",
                        $"toolSettings.{property.Name} = null;");
            }

            if (property.IsBoolean())
                WriteBooleanExtensions(writer, property);
            else if (property.IsList())
                WriteListExtensions(writer, property);
            else if (property.IsDictionary())
                WriteDictionaryExtensions(writer, property);
            else if (property.IsLookupTable())
                WriteLookupExtensions(writer, property);

            writer.WriteLine("#endregion");
        }

        private static void WriteBooleanExtensions(DataClassWriter writer, Property property)
        {
            var propertyAccess = $"toolSettings.{property.Name}";

            writer
                .WriteSummaryExtension($"Enables {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Enable{property.Name}", $"{propertyAccess} = true;")
                .WriteSummaryExtension($"Disables {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Disable{property.Name}", $"{propertyAccess} = false;")
                .WriteSummaryExtension($"Toggles {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Toggle{property.Name}", $"{propertyAccess} = !{propertyAccess};");

            // TODO [4]: negate for 'skip', 'no', 'disable'
        }

        private static void WriteListExtensions(DataClassWriter writer, Property property)
        {
            var propertyInternal = $"{property.Name}Internal";
            var propertyInstance = property.Name.ToInstance().EscapeParameter();
            var valueType = property.GetListValueType();
            var propertyAccess = $"toolSettings.{propertyInternal}";

            writer
                .WriteSummaryExtension($"Sets {property.GetCrefTag()} to a new list", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Set{property.Name}",
                    $"params {valueType}[] {propertyInstance}",
                    $"{propertyAccess} = {propertyInstance}.ToList();")
                .WriteSummaryExtension($"Sets {property.GetCrefTag()} to a new list", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Set{property.Name}",
                    $"IEnumerable<{valueType}> {propertyInstance}",
                    $"{propertyAccess} = {propertyInstance}.ToList();")
                .WriteSummaryExtension($"Adds values to {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Add{property.Name}",
                    $"params {valueType}[] {propertyInstance}",
                    $"{propertyAccess}.AddRange({propertyInstance});")
                .When(property.HasCustomListType(), _ => _
                    .WriteSummaryExtension($"Adds a value to {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Add{property.Name.ToSingular()}",
                        $"Configure<{valueType}> configurator",
                        $"{propertyAccess}.Add(configurator.InvokeSafe(new {valueType}()));"))
                .WriteSummaryExtension($"Adds values to {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Add{property.Name}",
                    $"IEnumerable<{valueType}> {propertyInstance}",
                    $"{propertyAccess}.AddRange({propertyInstance});")
                .WriteSummaryExtension($"Clears {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Clear{property.Name}",
                    $"{propertyAccess}.Clear();")
                //.WriteSummaryExtension($"Adds a single {propertySingularInstance} to {property.GetCrefTag()}", property)
                //.WriteListAddMethod(propertySingular, propertySingularInstanceEscaped, valueType, propertyInternal)
                .WriteSummaryExtension($"Removes values from {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Remove{property.Name}",
                    $"params {valueType}[] {propertyInstance}",
                    $"var hashSet = new HashSet<{valueType}>({propertyInstance});",
                    $"{propertyAccess}.RemoveAll(x => hashSet.Contains(x));")
                .WriteSummaryExtension($"Removes values from {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Remove{property.Name}",
                    $"IEnumerable<{valueType}> {propertyInstance}",
                    $"var hashSet = new HashSet<{valueType}>({propertyInstance});",
                    $"{propertyAccess}.RemoveAll(x => hashSet.Contains(x));");
        }

        private static void WriteDictionaryExtensions(DataClassWriter writer, Property property)
        {
            if (!property.OnlyDelegates)
            {
                var propertyInstance = property.Name.ToInstance().EscapeParameter();
                var (keyType, valueType) = property.GetDictionaryKeyValueTypes();
                var propertySingular = property.Name.ToSingular();
                var propertySingularInstance = property.Name.ToSingular().ToInstance();
                var keyInstance = $"{propertySingularInstance}Key";
                var valueInstance = $"{propertySingularInstance}Value";
                var propertyAccess = $"toolSettings.{property.Name}Internal";

                writer
                    .WriteSummaryExtension($"Sets {property.GetCrefTag()} to a new dictionary", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Set{property.Name}",
                        $"IDictionary<{keyType}, {valueType}> {propertyInstance}",
                        $"{propertyAccess} = {propertyInstance}.ToDictionary(x => x.Key, x => x.Value, {property.GetKeyComparer()});")
                    .WriteSummaryExtension($"Clears {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Clear{property.Name}",
                        $"{propertyAccess}.Clear();")
                    .WriteSummaryExtension($"Adds a new key-value-pair {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Add{propertySingular}",
                        new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                        $"{propertyAccess}.Add({keyInstance}, {valueInstance});")
                    .WriteSummaryExtension($"Removes a key-value-pair from {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Remove{propertySingular}",
                        $"{keyType} {keyInstance}",
                        $"{propertyAccess}.Remove({keyInstance});")
                    .WriteSummaryExtension($"Sets a key-value-pair in {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Set{propertySingular}",
                        new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                        $"{propertyAccess}[{keyInstance}] = {valueInstance};");
            }

            writer.ForEach(property.Delegates, x => WriteDictionaryDelegateExtensions(writer, property, x));
        }

        private static void WriteDictionaryDelegateExtensions(DataClassWriter writer, Property property, Property delegateProperty)
        {
            writer.WriteLine($"#region {delegateProperty.Name}");

            var propertyAccess = $"toolSettings.{property.Name}Internal";
            var reference = $"<c>{delegateProperty.Name}</c>";

            string GetModification(string newValue) => $"{propertyAccess}[{delegateProperty.Name.DoubleQuote()}] = {newValue};";

            if (!delegateProperty.IsList())
            {
                writer
                    .WriteSummaryExtension($"Sets {reference} in {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod(
                        $"Set{delegateProperty.Name}",
                        delegateProperty,
                        GetModification(delegateProperty.Name.ToInstance()))
                    .WriteSummaryExtension($"Resets {reference} in {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod(
                        $"Reset{delegateProperty.Name}",
                        $"{propertyAccess}.Remove({delegateProperty.Name.DoubleQuote()});");
            }

            if (delegateProperty.IsBoolean())
            {
                writer
                    .WriteSummaryExtension($"Enables {reference} in {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Enable{delegateProperty.Name}", GetModification("true"))
                    .WriteSummaryExtension($"Disables {reference} in {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Disable{delegateProperty.Name}", GetModification("false"))
                    .WriteSummaryExtension($"Toggles {reference} in {property.GetCrefTag()}", property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Toggle{delegateProperty.Name}",
                        $"ExtensionHelper.ToggleBoolean({propertyAccess}, {delegateProperty.Name.DoubleQuote()});");
            }

            if (delegateProperty.IsList())
            {
                var propertyInstance = delegateProperty.Name.ToInstance();
                var valueType = delegateProperty.GetListValueType();
                var propertyPlural = delegateProperty.Name.ToPlural();

                writer
                    .WriteSummaryExtension($"Sets {reference} in {property.GetCrefTag()} to a new collection", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Set{propertyPlural}",
                        $"params {valueType}[] {propertyInstance}",
                        $"ExtensionHelper.SetCollection({propertyAccess}, {delegateProperty.Name.DoubleQuote()}, {propertyInstance}, {delegateProperty.Separator.SingleQuote()});")
                    .WriteSummaryExtension($"Sets {reference} in {property.GetCrefTag()} to a new collection", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Set{propertyPlural}",
                        $"IEnumerable<{valueType}> {propertyInstance}",
                        $"ExtensionHelper.SetCollection({propertyAccess}, {delegateProperty.Name.DoubleQuote()}, {propertyInstance}, {delegateProperty.Separator.SingleQuote()});")
                    .WriteSummaryExtension($"Adds values to {reference} in {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Add{propertyPlural}",
                        $"params {valueType}[] {propertyInstance}",
                        $"ExtensionHelper.AddItems({propertyAccess}, {delegateProperty.Name.DoubleQuote()}, {propertyInstance}, {delegateProperty.Separator.SingleQuote()});")
                    .WriteSummaryExtension($"Adds values to {reference} in existing {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Add{propertyPlural}",
                        $"IEnumerable<{valueType}> {propertyInstance}",
                        $"ExtensionHelper.AddItems({propertyAccess}, {delegateProperty.Name.DoubleQuote()}, {propertyInstance}, {delegateProperty.Separator.SingleQuote()});")
                    .WriteSummaryExtension($"Clears {reference} in {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Clear{propertyPlural}",
                        $"{propertyAccess}.Remove({delegateProperty.Name.DoubleQuote()});")
                    .WriteSummaryExtension($"Removes values from {reference} in {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Remove{propertyPlural}",
                        $"params {valueType}[] {propertyInstance}",
                        $"ExtensionHelper.RemoveItems({propertyAccess}, {delegateProperty.Name.DoubleQuote()}, {propertyInstance}, {delegateProperty.Separator.SingleQuote()});")
                    .WriteSummaryExtension($"Removes values from {reference} in {property.GetCrefTag()}", delegateProperty, property)
                    .WriteObsoleteAttributeWhenObsolete(property)
                    .WriteMethod($"Remove{propertyPlural}",
                        $"IEnumerable<{valueType}> {propertyInstance}",
                        $"ExtensionHelper.RemoveItems({propertyAccess}, {delegateProperty.Name.DoubleQuote()}, {propertyInstance}, {delegateProperty.Separator.SingleQuote()});");
            }

            writer.WriteLine("#endregion");
        }

        private static void WriteLookupExtensions(DataClassWriter writer, Property property)
        {
            var propertyInstance = property.Name.ToInstance();
            var (keyType, valueType) = property.GetLookupTableKeyValueTypes();
            var propertySingular = property.Name.ToSingular();
            var propertySingularInstance = property.Name.ToSingular().ToInstance();
            var keyInstance = $"{propertyInstance}Key";
            var valueInstance = $"{propertyInstance}Value";
            var valueInstances = $"{propertyInstance}Values";
            var propertyAccess = $"toolSettings.{property.Name}Internal";

            // TODO: params
            // TODO: remove by key
            writer
                .WriteSummaryExtension($"Sets {property.GetCrefTag()} to a new lookup table", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Set{property.Name}",
                    $"ILookup<{keyType}, {valueType}> {propertyInstance}",
                    $"{propertyAccess} = {propertyInstance}.ToLookupTable(StringComparer.OrdinalIgnoreCase);")
                .WriteSummaryExtension($"Clears {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Clear{property.Name}",
                    $"{propertyAccess}.Clear();")
                .WriteSummaryExtension($"Adds new values for the given key to {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Add{property.Name}",
                    new[] { $"{keyType} {keyInstance}", $"params {valueType}[] {valueInstances}" },
                    $"{propertyAccess}.AddRange({keyInstance}, {valueInstances});")
                .WriteSummaryExtension($"Adds new values for the given key to {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Add{property.Name}",
                    new[] { $"{keyType} {keyInstance}", $"IEnumerable<{valueType}> {valueInstances}" },
                    $"{propertyAccess}.AddRange({keyInstance}, {valueInstances});")
                .WriteSummaryExtension($"Removes a single {propertySingularInstance} from {property.GetCrefTag()}", property)
                .WriteObsoleteAttributeWhenObsolete(property)
                .WriteMethod($"Remove{propertySingular}",
                    new[] { $"{keyType} {keyInstance}", $"{valueType} {valueInstance}" },
                    $"{propertyAccess}.Remove({keyInstance}, {valueInstance});");
        }

        private static DataClassWriter WriteMethod(this DataClassWriter writer, string name, Property property, string modification)
        {
            var attributes = property.Secret ?? false ? "[Secret] " : string.Empty;
            return writer.WriteMethod(name, $"{attributes}{property.GetNullableType()} {property.Name.ToInstance().EscapeParameter()}", modification);
        }

        private static DataClassWriter WriteMethod(
            this DataClassWriter writer,
            string name,
            string additionalParameter,
            params string[] modifications)
        {
            return writer.WriteMethod(name, new[] { additionalParameter }, modifications);
        }

        private static DataClassWriter WriteMethod(this DataClassWriter writer, string name, string modification)
        {
            return writer.WriteMethod(name, new[] { modification });
        }

        private static DataClassWriter WriteMethod(this DataClassWriter writer, string name, string[] modifications)
        {
            return writer.WriteMethod(name, new string[0], modifications);
        }

        private static DataClassWriter WriteMethod(
            this DataClassWriter writer,
            string name,
            IEnumerable<string> additionalParameters,
            params string[] modifications)
        {
            // NOTE: methods cannot be generic because constraints are not taken into account for overload resolution
            var parameters = new[] { "this T toolSettings" }.Concat(additionalParameters);
            return writer
                .WriteLine("[Pure]")
                .WriteLine($"public static T {name}<T>({parameters.JoinCommaSpace()}) where T : {writer.DataClass.Name}")
                .WriteBlock(w => w
                    .WriteLine("toolSettings = toolSettings.NewInstance();")
                    .ForEachWriteLine(modifications)
                    .WriteLine("return toolSettings;"));
        }
    }
}
