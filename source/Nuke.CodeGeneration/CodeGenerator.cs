// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Generators;
using Nuke.CodeGeneration.Model;
using Nuke.Common.Git;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class CodeGenerator
    {
        public static void GenerateCode(
            string metadataDirectory,
            string generationBaseDirectory,
            bool useNestedNamespaces = false,
            string baseNamespace = null,
            GitRepository gitRepository = null)
        {
            GenerateCode(
                Directory.GetFiles(metadataDirectory, "*.json", SearchOption.TopDirectoryOnly),
                generationBaseDirectory,
                useNestedNamespaces,
                baseNamespace,
                gitRepository);
        }

        public static void GenerateCode(
            IReadOnlyCollection<string> metadataFiles,
            string baseDirectory,
            bool useNestedNamespaces,
            [CanBeNull] string baseNamespace,
            [CanBeNull] GitRepository repository)
        {
            foreach (var metadataFile in metadataFiles)
            {
                var tool = ToolSerializer.Load(metadataFile);
                // for formatting and ordering of properties
                ToolSerializer.Save(tool);
                ApplyRuntimeInformation(tool, repository);

                var generationDirectory = useNestedNamespaces ? Path.Combine(baseDirectory, tool.Name) : baseDirectory;
                var generationFile = Path.Combine(generationDirectory, $"{Path.GetFileNameWithoutExtension(tool.DefinitionFile)}.Generated.cs");
                FileSystemTasks.EnsureExistingDirectory(generationDirectory);

                var @namespace =
                    !useNestedNamespaces
                        ? baseNamespace
                        : string.IsNullOrEmpty(baseNamespace)
                            ? tool.Name
                            : $"{baseNamespace}.{tool.Name}";

                using (var fileStream = File.Open(generationFile, FileMode.Create))
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    ToolGenerator.Run(tool, @namespace, streamWriter);
                }

                Logger.Info($"Generated code from '{Path.GetFileName(tool.DefinitionFile)}'.");
            }
        }

        // ReSharper disable once CyclomaticComplexity
        private static void ApplyRuntimeInformation(Tool tool, GitRepository repository)
        {
            tool.RepositoryUrl = repository?.GetGitHubBrowseUrl(tool.DefinitionFile);

            foreach (var task in tool.Tasks)
            {
                task.Tool = tool;
                task.SettingsClass.Tool = tool;
                task.SettingsClass.Task = task;

                if (!task.OmitCommonProperties)
                    tool.CommonTaskProperties.ForEach(x => task.SettingsClass.Properties.Add(x.Clone()));

                foreach (var commonPropertySet in task.CommonPropertySets)
                {
                    ControlFlow.Assert(tool.CommonTaskPropertySets.TryGetValue(commonPropertySet, out var properties),
                        $"commonPropertySets[{commonPropertySet}] != null");
                    properties.ForEach(x => task.SettingsClass.Properties.Add(x.Clone()));
                }

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
