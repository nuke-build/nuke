// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.ToolGenerator.Model;

namespace Nuke.ToolGenerator.Generators
{
    public static class ModelExtensions
    {
        public static string GetNamespace (this Tool tool)
        {
            var namespaces = new Stack<string>();
            var directory = new FileInfo(tool.GenerationFile).Directory;
            while (directory != null)
            {
                namespaces.Push(directory.Name);

                if (directory.GetFiles("*.csproj", SearchOption.TopDirectoryOnly).Any())
                    break;
                directory = directory.Parent;
            }
            return string.Join(".", namespaces);
        }

        public static string GetListValueType (this Property property)
        {
            return GetGenerics(property).Single();
        }

        public static (string, string) GetDictionaryKeyValueTypes (this Property property)
        {
            var generics = GetGenerics(property);
            return (generics[0], generics[1]);
        }

        public static (string, string) GetLookupTableKeyValueTypes (this Property property)
        {
            var generics = GetGenerics(property);
            return (generics[0], generics[1]);
        }

        private static string[] GetGenerics (Property property)
        {
            var match = Regex.Match(property.Type, ".*<(?<generics>.*)>");
            return match.Groups["generics"].Value.Split(',').Select(x => x.Trim()).ToArray();
        }

        public static bool IsList (this Property property)
        {
            return property.Type.StartsWith("List");
        }

        public static bool IsDictionary (this Property property)
        {
            return property.Type.StartsWith("Dictionary");
        }

        public static bool IsLookupTable (this Property property)
        {
            return property.Type.StartsWith("LookupTable");
        }

        public static bool IsBoolean (this Property property)
        {
            return property.Type.StartsWith("bool");
        }

        public static string GetNullabilityAttribute (this Property property)
        {
            var isOptional = property.Assertion.ToString().StartsWith("NullOr");
            return isOptional ? "[CanBeNull] " : string.Empty;
        }

        public static string GetTaskClassName (this Task task)
        {
            return $"{task.Tool.Name}Tasks";
        }

        public static string GetTaskMethodName (this Task task)
        {
            return $"{task.Tool.Name}{task.Postfix}";
        }
    }
}
