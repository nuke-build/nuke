// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Core.Utilities.Collections;
using Nuke.NSwag.Generator.Utilities;

namespace Nuke.NSwag.Generator
{
    public class NSwagSpecificationParser : SpecificationParser
    {
        public static NSwagSpecificationParser FromPackages(string packageDirectory, string gitReference)
        {
            var assemblies = LoadAssemblies(packageDirectory);
            return new NSwagSpecificationParser(assemblies, gitReference);
        }

        private static AssemblyDefinition[] LoadAssemblies (string packageDirectory)
        {
            var assemblyDirectories = GetAssemblyDirectories(packageDirectory);

            var assemblyResolver = new DefaultAssemblyResolver();
            assemblyDirectories.ForEach(x => assemblyResolver.AddSearchDirectory(x));

            return assemblyDirectories
                    .SelectMany(x => PathConstruction.GlobFiles(x, "*.dll"))
                    .Select(x => AssemblyDefinition.ReadAssembly(x, new ReaderParameters { AssemblyResolver = assemblyResolver }))
                    .ToArray();
        }

        private static string[] GetAssemblyDirectories (string packageDirectory)
        {
            string GetBestFrameworkDirectory (string libDirectory)
            {
                var frameworkDirectory = PathConstruction.Combine(libDirectory, "lib");
                var bestFramework = Directory.GetDirectories(frameworkDirectory)
                        .Select(Path.GetFileName)
                        .Where(x => x.StartsWith("dotnet") || x.StartsWith("net"))
                        .OrderBy(x => x.StartsWith("dotnet") || x.StartsWith("netstandard") ? $"!{x}" : x)
                        .First();
                return PathConstruction.Combine(frameworkDirectory, bestFramework);
            }

            return Directory.GetDirectories(packageDirectory)
                    .Select(GetBestFrameworkDirectory)
                    .ToArray();
        }

        private readonly AssemblyDefinition[] _assemblies;
        private readonly string _gitReference;
        private readonly TypeDefinition[] _commandTypes;

        public NSwagSpecificationParser (AssemblyDefinition[] assemblies, string gitReference)
        {
            _assemblies = assemblies;
            _gitReference = gitReference;
            _commandTypes = _assemblies
                    .SelectMany(x => x.MainModule.Types)
                    .Where(x => x.HasCommandAttribute())
                    .ToArray();
        }

        public override void Dispose ()
        {
            _assemblies?.ForEach(x => x?.Dispose());
        }

        protected override List<string> ParseReferences ()
        {
            string GetGitHubUrl (string fullName)
            {
                var commandPath = fullName.Replace("NSwag.Commands.", string.Empty).Replace(oldChar: '.', newChar: '/');
                return $"https://raw.githubusercontent.com/RSuter/NSwag/{_gitReference}/src/NSwag.Commands/Commands/{commandPath}.cs";
            }

            return _commandTypes
                    .Select(x => GetGitHubUrl(x.FullName))
                    .ToList();
        }

        protected override List<Task> ParseTasks ()
        {
            return _commandTypes
                    .Select(ParseTask)
                    .ToList();
        }

        protected override Dictionary<string, List<Property>> ParseCommonTaskPropertySets ()
        {
            return _assemblies
                    .SelectMany(x => x.MainModule.Types)
                    .Where(x => x.IsCommandBaseClass())
                    .ToDictionary(x => x.GetPropertySetName(), ParseProperties);
        }

        protected override List<Enumeration> ParseEnumerations ()
        {
            bool IsUnique (IGrouping<string, Enumeration> grouping)
            {
                return grouping.Count() == 1 || grouping.GroupBy(x => x.Values, new SequenceEqualityComparer()).Count() == 1;
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
            return enumerations
                    .SelectMany(x => x.AsEnumerable())
                    .Distinct(new EnumerationEqualityComparer())
                    .ToList();
        }

        protected override List<Property> ParseCommonTaskProperties ()
        {
            return new List<Property>
                   {
                           new Property
                           {
                                   Name = "NSwagRuntime",
                                   CustomImpl = true,
                                   Format = "{value}",
                                   Type = "string",
                                   CustomValue = true
                           }
                   };
        }

        private Enumeration ParseEnumeration (TypeDefinition typeDefinition)
        {
            return new Enumeration
                   {
                           Name = typeDefinition.Name,
                           Values = typeDefinition.Fields.Where(x => x.Name != "value__").Select(x => x.Name).ToList()
                   };
        }

        private Task ParseTask (TypeDefinition typeDefinition)
        {
            var commandAttribute = typeDefinition.GetCommandAttribute();

            var task = new Task
                       {
                               Postfix = typeDefinition.Name.Replace("Command", string.Empty),
                               DefiniteArgument = commandAttribute.GetPropertyValue<string>("Name"),
                               Help = commandAttribute.GetPropertyValue<string>("Description"),
                               CommonPropertySets = typeDefinition.GetCommonPropertySets()
                       };
            task.SettingsClass = new SettingsClass
                                 {
                                         Properties = ParseProperties(typeDefinition),
                                         BaseClass = "NSwagSettings"
                                 };
            return task;
        }

        private List<Property> ParseProperties (TypeDefinition typeDefinition)
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
    }
}