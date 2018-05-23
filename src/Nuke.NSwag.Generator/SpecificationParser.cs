// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Newtonsoft.Json;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;
using Nuke.NSwag.Generator.Utilities;

namespace Nuke.NSwag.Generator
{
    public class SpecificationParser
    {
        private static List<Property> ParseProperties(TypeDefinition typeDefinition)
        {
            var positionalArguments = new Dictionary<string, int>();

            var properties = typeDefinition.Properties
                .Where(x => x.HasArgumentAttribute())
                .Select(x =>
                {
                    var argumentAttribute = x.GetArgumentAttribute();
                    var name = argumentAttribute.GetPropertyValue<string>("Name") ?? x.Name;
                    var type = x.GetTypeName(argumentAttribute);

                    var position = argumentAttribute.GetPropertyValue<int>("Position");
                    if (position > 0) positionalArguments.Add(name, position);

                    return new Property
                           {
                               Name = name,
                               Type = type,
                               Help = argumentAttribute.GetPropertyValue<string>("Description"),
                               Format = $"/{name}:{{value}}",
                               Separator = type.StartsWith("List<") && type.StartsWith("Dictionary<") ? ',' : default(char?),
                               ItemFormat = type.StartsWith("Dictionary<") ? "{key}={value}" : null
                           };
                })
                .OrderBy(x => positionalArguments.TryGetValue(x.Name, out var position) ? $"!{position}" : x.Name)
                .ToList();
            return properties;
        }

        private static Tool CreateTool()
        {
            return new Tool
                   {
                       Name = "NSwag",
                       PackageExecutable = "NSwag.Commandline",
                       License = new[]
                                 {
                                     "Copyright Sebastian Karasek, Matthias Koch 2018.",
                                     "Distributed under the MIT License.",
                                     "https://github.com/nuke-build/nswag/blob/master/LICENSE"
                                 },
                       Help =
                           "The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain. This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification or JSON Schema are better supported (e.g. <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance\">inheritance</a>, <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Enums\">enum</a> and reference handling). The NSwag project heavily uses <a href=\"http://njsonschema.org/\">NJsonSchema for .NET</a> for JSON Schema handling and C#/TypeScript class/interface generation.",
                       CustomExecutable = true,
                       OfficialUrl = "https://github.com/RSuter/NSwag",
                       CommonTaskProperties = new List<Property>
                                              {
                                                  new Property
                                                  {
                                                      Name = "NSwagRuntime",
                                                      CustomImpl = true,
                                                      Format = "{value}",
                                                      Type = "string",
                                                      CustomValue = true
                                                  }
                                              }
                   };
        }

        public static void WriteSpecifications(SpecificationGeneratorSettings settings)
        {
            Console.WriteLine($"Generating NSwag specifications...");
            Console.WriteLine();

            var parser = new SpecificationParser(settings.PackageFolder, settings.Version);
            parser.PopulateTasks();
            parser.PopulateCommonTaskPropertySets();
            parser.PopulateEnumerations();
            parser.PopulateReferences();

            Console.WriteLine($"Tasks: {parser._tool.Tasks.Count}");
            Console.WriteLine($"Enumerations: {parser._tool.Enumerations.Count}");
            Console.WriteLine($"CommonTaskProperties: {parser._tool.CommonTaskProperties.Count}");
            Console.WriteLine($"CommonTaskPropertySets: {parser._tool.CommonTaskPropertySets.Count}");

            File.WriteAllText(Path.Combine(settings.OutputFolder, "NSwag.json"),
                JsonConvert.SerializeObject(parser._tool,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }));
        }

        private readonly Tool _tool;
        private readonly AssemblyDefinition[] _assemblies;
        private readonly string _version;

        private SpecificationParser(string packageFolder, string version)
        {
            _assemblies = PathConstruction.GlobFiles(packageFolder, "lib/netstandard*/*.dll")
                .Select(AssemblyDefinition.ReadAssembly)
                .ToArray();
            _tool = CreateTool();
            _version = version;
        }

        private void PopulateTasks()
        {
            _tool.Tasks = GetCommandTypes()
                .Select(ParseTask)
                .ToList();
        }

        private void PopulateEnumerations()
        {
            bool IsUnique(IGrouping<string, Enumeration> grouping)
            {
                return grouping.Count() == 1
                       || grouping.GroupBy(x => x.Values, new SequenceEqualityComparer()).Count() == 1;
            }

            var enumerations = _assemblies
                .SelectMany(x => x.MainModule.Types)
                .SelectMany(x => x.Properties)
                .Where(x => x.HasArgumentAttribute())
                .Select(x => x.PropertyType.Resolve())
                .Where(x => x.IsEnum)
                .Select(ParseEnumeration)
                .ToLookup(x => x.Name, x => x);

            enumerations.ForEach(x => ControlFlow.Assert(IsUnique(x), "Multiple enumerations with same name but different values were found."));
            _tool.Enumerations = enumerations
                .SelectMany(x => x.AsEnumerable())
                .Distinct(new EnumerationEqualityComparer())
                .ToList();
        }

        private void PopulateReferences()
        {
            string GetGitHubUrl(string fullName)
            {
                var commandPath = fullName.Replace("NSwag.Commands.", string.Empty).Replace(oldChar: '.', newChar: '/');
                return $"https://raw.githubusercontent.com/RSuter/NSwag/{_version}/src/NSwag.Commands/Commands/{commandPath}.cs";
            }

            _tool.References = GetCommandTypes()
                .Select(x => GetGitHubUrl(x.FullName))
                .ToList();
        }

        private IEnumerable<TypeDefinition> GetCommandTypes()
        {
            return _assemblies
                .SelectMany(x => x.MainModule.Types)
                .Where(x => x.HasCommandAttribute());
        }

        private Enumeration ParseEnumeration(TypeDefinition typeDefinition)
        {
            return new Enumeration
                   {
                       Tool = _tool,
                       Name = typeDefinition.Name,
                       Values = typeDefinition.Fields.Where(x => x.Name != "value__").Select(x => x.Name).ToList()
                   };
        }

        private void PopulateCommonTaskPropertySets()
        {
            _tool.CommonTaskPropertySets = _assemblies
                .SelectMany(x => x.MainModule.Types)
                .Where(x => x.IsBaseClass())
                .ToDictionary(x => x.GetPropertySetName(), ParseProperties);
        }

        private Task ParseTask(TypeDefinition typeDefinition)
        {
            var commandAttribute = typeDefinition.GetCommandAttribute();

            var task = new Task
                       {
                           Tool = _tool,
                           Postfix = typeDefinition.Name.Replace("Command", string.Empty),
                           DefiniteArgument = commandAttribute.GetPropertyValue<string>("Name"),
                           Help = commandAttribute.GetPropertyValue<string>("Description"),
                           CommonPropertySets = typeDefinition.GetCommonPropertySets()
                       };
            task.SettingsClass = new SettingsClass
                                 {
                                     Properties = ParseProperties(typeDefinition),
                                     BaseClass = "NSwagSettings",
                                     Task = task,
                                     Tool = _tool
                                 };
            return task;
        }
    }
}