// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.CodeGeneration;
using Nuke.CodeGeneration.Model;
using Nuke.Common.IO;

namespace Nuke.NSwag.Generator
{
    public abstract class SpecificationGenerator
    {
        private readonly string _outputFolder;

        protected SpecificationGenerator(string outputFolder)
        {
            _outputFolder = outputFolder;
        }

        protected abstract string ToolName { get; }
        protected abstract string Help { get; }
        protected abstract string OfficialUrl { get; }
        protected abstract string[] License { get; }

        protected abstract ISpecificationParser CreateSpecificationParser();

        public void GenerateSpecifications()
        {
            Console.WriteLine($"Generating {ToolName} specifications...");

            var tool = GenerateTool(PathConstruction.Combine(_outputFolder, $"{ToolName}.json"));
            using (var parser = CreateSpecificationParser())
            {
                parser.Populate(tool);
            }

            PopulateReferences(tool);

            Directory.CreateDirectory(_outputFolder);
            ToolSerializer.Save(tool);

            Console.WriteLine();
            Console.WriteLine("Generation finished.");
            Console.WriteLine($"Created Tasks: {tool.Tasks.Count}");
            Console.WriteLine($"Created Data Classes: {tool.DataClasses.Count}");
            Console.WriteLine($"Created Enumerations: {tool.Enumerations.Count}");
            Console.WriteLine($"Created Common Task Properties: {tool.CommonTaskProperties.Count}");
            Console.WriteLine($"Created Common Task Property Sets: {tool.CommonTaskPropertySets.Count}");
        }

        protected virtual string PathExecutable => null;
        protected virtual string EnvironmentExecutable => null;
        protected virtual string PackageId => null;
        protected virtual string PackageExecutable => null;
        protected virtual bool CustomExecutable => false;

        private Tool GenerateTool(string specificationFilePath)
        {
            var tool = new Tool
                       {
                           Name = ToolName,
                           CustomExecutable = CustomExecutable,
                           License = License,
                           OfficialUrl = OfficialUrl,
                           EnvironmentExecutable = EnvironmentExecutable,
                           PackageExecutable = PackageExecutable,
                           PathExecutable = PathExecutable,
                           PackageId = PackageId,
                           DefinitionFile = specificationFilePath,
                           Help = Help
                       };
            return tool;
        }

        private void PopulateReferences(Tool tool)
        {
            foreach (var x in tool.DataClasses)
            {
                x.Tool = tool;
            }

            foreach (var task in tool.Tasks)
            {
                task.Tool = tool;
                task.SettingsClass.Tool = tool;
                task.SettingsClass.Task = task;
            }
        }
    }
}
