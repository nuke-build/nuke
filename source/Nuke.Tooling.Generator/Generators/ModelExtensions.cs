// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.Utilities;

namespace Nuke.CodeGeneration.Generators
{
    public static class ModelExtensions
    {
        public static bool IsValueType(this Property property)
        {
            return property.Type.EqualsAnyOrdinalIgnoreCase(
                "int",
                "bool",
                "sbyte",
                "short",
                "long",
                "byte",
                "ushort",
                "uint",
                "ulong",
                "float",
                "double",
                "char",
                "decimal");
        }

        public static string GetNullableType(this Property property)
        {
            return property.IsValueType() ? property.Type + "?" : property.Type.Trim('!');
        }

        public static string GetCrefTag(this Property property)
        {
            return $"<see cref={$"{property.DataClass.Name}.{property.Name}".DoubleQuote()}/>";
        }

        public static string GetListValueType(this Property property)
        {
            Assert.True(property.IsList());
            return GetGenerics(property).Single();
        }

        public static (string, string) GetDictionaryKeyValueTypes(this Property property)
        {
            Assert.True(property.IsDictionary());
            var generics = GetGenerics(property);
            return (generics[0], generics[1]);
        }

        public static (string, string) GetLookupTableKeyValueTypes(this Property property)
        {
            Assert.True(property.IsLookupTable());
            var generics = GetGenerics(property);
            return (generics[0], generics[1]);
        }

        public static string GetKeyComparer(this Property property)
        {
            Assert.True(property.IsDictionary() || property.IsLookupTable());
            var keyType = GetGenerics(property).First();

            return keyType.EqualsOrdinalIgnoreCase("string")
                ? "StringComparer.OrdinalIgnoreCase"
                : $"EqualityComparer<{keyType}>.Default";
        }

        private static string[] GetGenerics(Property property)
        {
            var match = Regex.Match(property.Type, ".*<(?<generics>.*)>");
            return match.Groups["generics"].Value.Split(',').Select(x => x.Trim()).ToArray();
        }

        public static bool IsList(this Property property)
        {
            return property.Type.StartsWith("List<");
        }

        public static bool IsDictionary(this Property property)
        {
            return property.Type.StartsWith("Dictionary<");
        }

        public static bool IsLookupTable(this Property property)
        {
            return property.Type.StartsWith("LookupTable<");
        }

        public static bool IsBoolean(this Property property)
        {
            return property.Type.EqualsOrdinalIgnoreCase("bool");
        }

        public static bool IsString(this Property property)
        {
            return property.Type.EqualsOrdinalIgnoreCase("string");
        }

        public static bool HasCustomListType(this Property property)
        {
            return property.DataClass.Tool.DataClasses.Any(x => x.Name == property.GetListValueType());
        }

        public static string GetClassName(this Tool tool)
        {
            return $"{tool.Name}Tasks";
        }

        public static string GetTaskMethodName(this Task task)
        {
            return $"{task.Tool.Name}{task.Postfix}";
        }

        public static string GetReturnType(this Task task)
        {
            return task.ReturnType ?? "void";
        }

        public static bool HasReturnValue(this Task task)
        {
            return task.GetReturnType() != "void";
        }
    }
}
