// Copyright Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/arodus/nuke-plugin-nswag/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NConsole;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.CodeGeneration.Model;
using Nuke.Core;
using Nuke.Core.Utilities.Collections;

namespace Tools
{
    public static class NSwagMetadataGenerator
    {
        public static void Generate([NotNull] string metaDataDirectory)
        {
            if (string.IsNullOrEmpty(metaDataDirectory))
                throw new ArgumentException("Value cannot be null or empty.", nameof(metaDataDirectory));
            var tool = new Tool
            {
                Name = "NSwag",
                Help =
                    "The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain."
                    + " This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification"
                    + " or JSON Schema are better supported (e.g. <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance\">inheritance</a>,"
                    + " <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Enums\">enum</a> and reference handling). "
                    + "The NSwag project heavily uses <a href=\"http://njsonschema.org/\">NJsonSchema for .NET</a> for JSON Schema handling and"
                    + " C#/TypeScript class/interface generation.",
                CustomExecutable = true,
                License = new[]
                {
                    "Copyright Sebastian Karasek 2017.",
                    "Distributed under the MIT License.",
                    "https://github.com/arodus/nuke-nswag/blob/master/LICENSE"
                },
                OfficialUrl = "https://github.com/RSuter/NSwag"
            };

            var references = new List<string>();
            var enumTypes = new HashSet<Type>();

            tool.Tasks = GetTasks(tool, references, enumTypes);
            tool.Enumerations = GetEnumerations(enumTypes);
            tool.References = references;

            if (!Directory.Exists(metaDataDirectory)) Directory.CreateDirectory(metaDataDirectory);
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new NukeToolClassContractResolver()
            };

            File.WriteAllText(metaDataDirectory + "/NSwag.json",
                JsonConvert.SerializeObject(tool, Formatting.Indented, jsonSettings));
        }

        static Task CreateTask([NotNull] Type commandType, [NotNull] ICollection<string> references)
        {
            if (commandType == null) throw new ArgumentNullException(nameof(commandType));
            if (references == null) throw new ArgumentNullException(nameof(references));
            var referenceUrl = "https://raw.githubusercontent.com/RSuter/NSwag/master/src/NSwag.Commands"
                               + commandType.Namespace.Split('.').Skip(1)
                                   .Aggregate("", (current, next) => $"{current}/{next}")
                               + $"/{commandType.Name}.cs";
            references.Add(referenceUrl);
            var commandAttribute = commandType.GetCustomAttribute<CommandAttribute>(false);

            var postfix = commandAttribute.Name
                .Replace("-", "")
                .Replace("schema", "Schema")
                .Replace("tsc", "Tsc")
                .Replace("json", "Json")
                .Replace("client", "Client")
                .Replace("aspnetcore", "AspNetCore")
                .Replace("swagger", "Swagger")
                .Replace("version", "Version")
                .Replace("list", "List")
                .Replace("types", "Types")
                .Replace("controllers", "Controllers")
                .Replace("webapi", "WebApi")
                .Replace("to", "To")
                .Replace("cs", "Cs");
            postfix = char.ToUpper(postfix[0]) + postfix.Substring(1);
            var isPascalCase = Regex.Match(postfix, "^[A-Z][a-z0-9]+(?:[A-Z][a-z0-9]+)*$").Success;
            ControlFlow.Assert(isPascalCase, $"{postfix} is not in pascal case.");

            var task = new Task
            {
                Postfix = postfix,
                Help = commandAttribute.Description
            };
            return task;
        }

        static List<Enumeration> GetEnumerations([NotNull] IEnumerable<Type> enumTypes)
        {
            if (enumTypes == null) throw new ArgumentNullException(nameof(enumTypes));
            var enumerations = new List<Enumeration>();
            enumTypes.ForEach(enumType =>
            {
                var enumeration = new Enumeration
                {
                    Name = enumType.Name,
                    Values = new List<string>()
                };
                foreach (var value in Enum.GetValues(enumType))
                    enumeration.Values.Add(value.ToString());
                enumerations.Add(enumeration);
            });
            return enumerations;
        }

        static List<Property> GetProperties([NotNull] IReflect commandType, [NotNull] ISet<Type> enumTypes)
        {
            if (commandType == null) throw new ArgumentNullException(nameof(commandType));
            if (enumTypes == null) throw new ArgumentNullException(nameof(enumTypes));
            var properties = new List<Property>();

            var argumentProperties = commandType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttributes(typeof(ArgumentAttribute), false).Length > 0);

   
            argumentProperties.ForEach(argumentProperty =>
            {
                var argumentAttribute = argumentProperty.GetCustomAttribute<ArgumentAttribute>(false);

                // ReSharper disable once UseObjectOrCollectionInitializer
                var property = new Property();
                property.Help = argumentAttribute.Description;
                property.Name = (argumentAttribute.Name ?? argumentProperty.Name)
                    .Replace("Namespace", "TargetNamespace");

                property.Type = argumentProperty.PropertyType.Name.ToString()
                    .Replace("String", "string")
                    .Replace("Object", "string")
                    .Replace("Boolean", "bool")
                    .Replace("Decimal", "string");

                property.Format = argumentAttribute.Name == null
                    ? "{value}"
                    : $"/{char.ToLower(argumentAttribute.Name[0])}{argumentAttribute.Name.Substring(1)}:\\\"{{value}}\\\"";

                if (argumentProperty.PropertyType.IsArray)
                {
                    property.Separator = ',';
                    property.Type = $"List<{argumentProperty.PropertyType.Name.TrimEnd('[', ']')}>";
                }
                if (argumentProperty.PropertyType.IsEnum)
                    enumTypes.Add(argumentProperty.PropertyType);
                if (argumentProperty.Name == "Variables")
                {
                    property.Type = "Dictionary<string,string>";
                    property.ItemFormat = "{Key}={Value}";
                    property.Separator = ',';
                }

                properties.Add(property);
            });
            return properties;
        }

        static List<Task> GetTasks([NotNull] Tool tool, [NotNull] ICollection<string> references,
            [NotNull] ISet<Type> enumTypes)
        {
            if (tool == null) throw new ArgumentNullException(nameof(tool));
            if (references == null) throw new ArgumentNullException(nameof(references));
            if (enumTypes == null) throw new ArgumentNullException(nameof(enumTypes));
            var assembly = AppDomain.CurrentDomain.Load("Nswag.Commands");
            var commandClasses = assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0);

            var tasks = new List<Task>();

            commandClasses.ForEach(commandType =>
            {
                var task = CreateTask(commandType, references);
                var settingsClass = new SettingsClass
                {
                    Tool = tool,
                    Task = task,
                    BaseClass = "NSwagSettings",
                    Properties = GetProperties(commandType, enumTypes)
                };


                task.SettingsClass = settingsClass;
                tasks.Add(task);
            });
            return tasks;
        }

        class NukeToolClassContractResolver : CamelCasePropertyNamesContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);

                var shouldSerialize = property.ShouldSerialize;
                property.ShouldSerialize = obj => (shouldSerialize == null || shouldSerialize(obj)) &&
                                                  !IsEmptyCollection(property, obj) && !IsSettingsClassName(property);
                return property;
            }

            static bool IsEmptyCollection(JsonProperty property, object target)
            {
                var value = property.ValueProvider.GetValue(target);
                if (value is ICollection collection && collection.Count == 0)
                    return true;

                if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                    return false;

                var countProp = property.PropertyType.GetProperty("Count");
                if (countProp == null)
                    return false;

                var count = (int) countProp.GetValue(value, null);
                return count == 0;
            }

            static bool IsSettingsClassName(JsonProperty property)
            {
                return property.DeclaringType == typeof(SettingsClass) &&
                       property.PropertyName.Equals("name", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}