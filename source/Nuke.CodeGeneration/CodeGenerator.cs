// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Generators;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class CodeGenerator
    {
        public const string SpecificationFilePattern = "*.json";

        public static void GenerateCode(
            string specificationDirectory,
            Func<Tool, string> outputFileProvider = null,
            Func<Tool, string> namespaceProvider = null,
            Func<Tool, string> sourceFileProvider = null)
        {
            GenerateCode(
                Directory.GetFiles(specificationDirectory, SpecificationFilePattern, SearchOption.TopDirectoryOnly),
                outputFileProvider,
                namespaceProvider,
                sourceFileProvider);
        }

        public static void GenerateCode(
            IReadOnlyCollection<string> specificationFiles,
            Func<Tool, string> outputFileProvider = null,
            Func<Tool, string> namespaceProvider = null,
            Func<Tool, string> sourceFileProvider = null)
        {
            foreach (var specificationFile in specificationFiles)
            {
                var tool = ToolSerializer.Load(specificationFile);
                // for formatting and ordering of properties
                ToolSerializer.Save(tool, specificationFile);
                
                tool.SpecificationFile = specificationFile;
                tool.SourceFile = sourceFileProvider?.Invoke(tool);
                tool.Namespace = namespaceProvider?.Invoke(tool);
                ApplyRuntimeInformation(tool, specificationFile, sourceFileProvider, namespaceProvider);

                var outputFile = outputFileProvider?.Invoke(tool) ??
                                 Path.Combine(Path.GetDirectoryName(tool.SpecificationFile).NotNull(), tool.DefaultOutputFileName);

                GenerateCode(tool, outputFile);
            }
        }

        public static void GenerateCode(Tool tool, string outputFile)
        {
            FileSystemTasks.EnsureExistingDirectory(Path.GetDirectoryName(outputFile));

            using (var fileStream = File.Open(outputFile, FileMode.Create))
            using (var streamWriter = new StreamWriter(fileStream))
            {
                ToolGenerator.Run(tool, streamWriter);
            }

            Logger.Info($"Generated code for {tool.Name} from {Path.GetFileName(tool.SpecificationFile) ?? "<in-memory>"}.");
        }

        // ReSharper disable once CyclomaticComplexity
        private static void ApplyRuntimeInformation(
            Tool tool,
            string specificationFile,
            [CanBeNull] Func<Tool, string> sourceFileProvider, 
            [CanBeNull] Func<Tool, string> namespaceProvider)
        {
            foreach (var task in tool.Tasks)
            {
                task.Tool = tool;
                task.SettingsClass.Tool = tool;
                task.SettingsClass.Task = task;

                foreach (var commonPropertySet in task.CommonPropertySets)
                {
                    ControlFlow.Assert(tool.CommonTaskPropertySets.TryGetValue(commonPropertySet, out var properties),
                        $"commonPropertySets[{commonPropertySet}] != null");
                    properties.ForEach(x => task.SettingsClass.Properties.Add(x.Clone()));
                }
                
                if (!task.OmitCommonProperties)
                    tool.CommonTaskProperties.ForEach(x => task.SettingsClass.Properties.Add(x.Clone()));

                foreach (var property in task.SettingsClass.Properties)
                {
                    property.DataClass = task.SettingsClass;
                    foreach (var delegateProperty in property.Delegates)
                        delegateProperty.DataClass = task.SettingsClass;
                }
            }

            foreach (var dataClass in tool.DataClasses)
            {
                dataClass.Tool = tool;
                foreach (var property in dataClass.Properties)
                {
                    property.DataClass = dataClass;
                    foreach (var delegateProperty in property.Delegates)
                        delegateProperty.DataClass = dataClass;
                }
            }

            foreach (var enumeration in tool.Enumerations)
                enumeration.Tool = tool;
        }
    }
}
