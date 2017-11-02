// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
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
using Nuke.CodeGeneration.Model;
using Nuke.Common.IO;
using Nuke.Core;
using Nuke.Core.Utilities;
using static Nuke.Core.IO.PathConstruction;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class CodeGenerator
    {
        public static void GenerateCode (string metadataDirectory, string generationDirectory, bool downloadSchema = true)
        {
            if (downloadSchema)
            {
                HttpTasks.HttpDownloadFile(
                    uri: "https://raw.githubusercontent.com/nuke-build/tools/master/metadata/_schema.json",
                    path: (AbsolutePath) metadataDirectory / "_schema.json");
            }

            var files = Directory.GetFiles(metadataDirectory, "*.json", SearchOption.TopDirectoryOnly).Where(x => !x.EndsWith("_schema.json"));
            files.AsParallel().ForAll(file =>
            {
                var tool = Load(file, generationDirectory);

                foreach (var task in tool.Tasks)
                {
                    if (task.OmitCommonProperties)
                        continue;

                    tool.CommonTaskProperties.ForEach(y => task.SettingsClass.Properties.Add(y.Clone()));
                }

                ApplyBackReferences(tool);

                using (var streamWriter = new StreamWriter(File.Open(tool.GenerationFileBase + ".Generated.cs", FileMode.Create)))
                {
                    Generators.ToolGenerator.Run(tool, streamWriter);
                }

                tool.Tasks.ForEach(x => tool.CommonTaskProperties.ForEach(y => x.SettingsClass.Properties.RemoveAll(z => z.Name == y.Name)));
                UpdateReferences(tool);

                Save(tool);

                Logger.Info($"Processed {Path.GetFileName(file)}.");
            });
        }

        private static Tool Load (string file, string generation)
        {
            var content = File.ReadAllText(file);
            var tool = JsonConvert.DeserializeObject<Tool>(content);

            var directory = Path.Combine(generation, tool.Name);
            Directory.CreateDirectory(directory);

            tool.DefinitionFile = file;
            tool.GenerationFileBase = Path.Combine(directory, Path.GetFileNameWithoutExtension(file));
            tool.RepositoryUrl = $"https://github.com/nuke-build/tools/blob/master/{Path.GetFileName(file)}";

            return tool;
        }

        // ReSharper disable once CyclomaticComplexity
        private static void ApplyBackReferences (Tool tool)
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

        private static void UpdateReferences (Tool tool)
        {
            Parallel.For(fromInclusive: 0,
                toExclusive: tool.References.Count,
                body: async i =>
                {
                    try
                    {
                        var referenceContent = await GetReferenceContent(tool.References[i]);
                        File.WriteAllText(
                            $"{tool.GenerationFileBase}.ref.{i.ToString().PadLeft(totalWidth: 3, paddingChar: '0')}.txt",
                            referenceContent);
                    }
                    catch (Exception exception)
                    {
                        Logger.Error($"Couldn't update reference #{i} for {Path.GetFileName(tool.DefinitionFile)}:");
                        Logger.Error(exception.Message);
                    }
                });
        }

        private static void Save (Tool tool)
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

            //File.WriteAllText(tool.DefinitionFile, content);
        }

        private static async Task<string> GetReferenceContent (string reference)
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
            return document.DocumentNode.SelectSingleNode(referenceValues[1]).InnerText;
        }

        private class CustomContractResolver : CamelCasePropertyNamesContractResolver
        {
            protected override JsonProperty CreateProperty ([NotNull] MemberInfo member, MemberSerialization memberSerialization)
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
            protected override WebRequest GetWebRequest (Uri address)
            {
                var request = base.GetWebRequest(address) as HttpWebRequest;

                if (request != null)
                    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                return request;
            }
        }
    }
}
