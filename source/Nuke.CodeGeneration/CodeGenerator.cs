// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.CodeGeneration.Generators;
using Nuke.CodeGeneration.Model;
using Nuke.Common.Git;
using Nuke.Core;
using Nuke.Core.Utilities;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public class CodeGenerator
    {
        public static void GenerateCode(
            string metadataDirectory,
            string generationBaseDirectory,
            bool useNestedNamespaces = false,
            string baseNamespace = null,
            GitRepository gitRepository = null)
        {
            new CodeGenerator(
                    Directory.GetFiles(metadataDirectory, "*.json", SearchOption.TopDirectoryOnly),
                    generationBaseDirectory,
                    useNestedNamespaces,
                    baseNamespace,
                    gitRepository)
                .Execute();
        }

        private readonly IReadOnlyCollection<string> _metadataFiles;
        private readonly string _baseDirectory;
        private readonly bool _useNestedNamespaces;
        private readonly string _baseNamespace;
        private readonly GitRepository _repository;

        public CodeGenerator(
            IReadOnlyCollection<string> metadataFiles,
            string baseDirectory,
            bool useNestedNamespaces,
            [CanBeNull] string baseNamespace,
            [CanBeNull] GitRepository repository)
        {
            _metadataFiles = metadataFiles;
            _baseDirectory = baseDirectory;
            _repository = repository;
            _baseNamespace = baseNamespace;
            _useNestedNamespaces = useNestedNamespaces;
        }

        public void Execute()
        {
            _metadataFiles.AsParallel().ForAll(file =>
            {
                var tool = Load(file);

                foreach (var task in tool.Tasks)
                {
                    if (task.OmitCommonProperties)
                        continue;

                    tool.CommonTaskProperties.ForEach(y => task.SettingsClass.Properties.Add(y.Clone()));
                }

                ApplyBackReferences(tool);

                using (var streamWriter = new StreamWriter(File.Open(tool.GenerationFileBase + ".Generated.cs", FileMode.Create)))
                {
                    ToolGenerator.Run(tool, GetNamespace(tool), streamWriter);
                }

                tool.Tasks.ForEach(x => tool.CommonTaskProperties.ForEach(y => x.SettingsClass.Properties.RemoveAll(z => z.Name == y.Name)));
                System.Threading.Tasks.Task.WaitAll(
                    tool.References.Select(reference => UpdateReference(reference, tool)).ToArray());

                Save(tool);

                Logger.Info($"Generated code from '{Path.GetFileName(file)}'.");
            });
        }

        [CanBeNull]
        private string GetNamespace(Tool tool)
        {
            return !_useNestedNamespaces
                ? _baseNamespace
                : string.IsNullOrEmpty(_baseNamespace)
                    ? tool.Name
                    : $"{_baseNamespace}.{tool.Name}";
        }

        private Tool Load(string file)
        {
            Logger.Info($"Loading metadata from '{Path.GetFileName(file)}'...");

            var content = File.ReadAllText(file);
            var tool = JsonConvert.DeserializeObject<Tool>(content);

            var toolDirectory = _useNestedNamespaces ? Path.Combine(_baseDirectory, tool.Name) : _baseDirectory;
            Directory.CreateDirectory(toolDirectory);

            tool.DefinitionFile = file;
            tool.GenerationFileBase = Path.Combine(toolDirectory, Path.GetFileNameWithoutExtension(file));
            tool.RepositoryUrl = _repository?.GetGitHubBrowseUrl(file);

            return tool;
        }

        // ReSharper disable once CyclomaticComplexity
        private void ApplyBackReferences(Tool tool)
        {
            foreach (var task in tool.Tasks)
            {
                task.Tool = tool;
                task.SettingsClass.Tool = tool;
                task.SettingsClass.Task = task;
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

        private async System.Threading.Tasks.Task UpdateReference(string reference, Tool tool)
        {
            var index = tool.References.IndexOf(reference);
            try
            {
                var referenceContent = await GetReferenceContent(reference);
                File.WriteAllText(
                    $"{tool.GenerationFileBase}.ref.{index.ToString().PadLeft(totalWidth: 3, paddingChar: '0')}.txt",
                    referenceContent);
            }
            catch (Exception exception)
            {
                Logger.Error($"Couldn't update {Path.GetFileName(tool.DefinitionFile)}#{index}: {reference}");
                Logger.Error(exception.Message);
            }
        }

        private void Save(Tool tool)
        {
            var content = JsonConvert.SerializeObject(
                tool,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CustomContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            var originalLineCount = File.ReadAllLines(tool.DefinitionFile).Length;
            var serializationLineCount = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;

            var postfix = originalLineCount != serializationLineCount ? ".new" : string.Empty;
            File.WriteAllText(tool.DefinitionFile + postfix, content);
        }

        private async Task<string> GetReferenceContent(string reference)
        {
            var referenceValues = reference.Split('#');

            var tempFile = Path.GetTempFileName();
            using (var webClient = new AutomaticDecompressingWebClient())
            {
                await webClient.DownloadFileTaskAsync(referenceValues[0], tempFile);
            }

            if (referenceValues.Length == 1)
                return File.ReadAllText(tempFile, Encoding.UTF8);

            var document = new HtmlDocument();
            document.Load(tempFile, Encoding.UTF8);
            var selectedNode = document.DocumentNode.SelectSingleNode(referenceValues[1]);
            ControlFlow.Assert(selectedNode != null, "selectedNode != null");
            return selectedNode.InnerText;
        }

        private class CustomContractResolver : CamelCasePropertyNamesContractResolver
        {
            protected override JsonProperty CreateProperty([NotNull] MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = x =>
                {
                    var propertyInfo = (PropertyInfo) member;

                    if (propertyInfo.GetSetMethod(nonPublic: true) == null)
                        return false;

                    if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                        return ((IEnumerable) propertyInfo.GetValue(x)).GetEnumerator().MoveNext();

                    return true;
                };
                return property;
            }
        }

        private class AutomaticDecompressingWebClient : WebClient
        {
            [CanBeNull]
            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address) as HttpWebRequest;

                if (request != null)
                    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                return request;
            }
        }
    }
}
