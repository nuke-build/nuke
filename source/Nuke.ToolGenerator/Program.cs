// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using HtmlAgilityPack;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.ToolGenerator.Model;

namespace Nuke.ToolGenerator
{
    [SuppressMessage("ReSharper", "MissingXmlDoc")]
    public static class Program
    {
        private static void Main (string[] args)
        {
            var files = Directory.GetFiles(args[0], "*.td", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                Console.WriteLine($"Processing {file}...");

                var tool = Load(file);
                using (var streamWriter = new StreamWriter(File.Open(tool.GenerationFileBase + ".Generated.cs", FileMode.Create)))
                {
                    Generators.ToolGenerator.Run(tool, streamWriter);
                }
                UpdateReferences (tool);
                Save(tool);
            }
        }

        private static Tool Load (string file)
        {
            var content = File.ReadAllText(file);
            var tool = JsonConvert.DeserializeObject<Tool>(content);

            var directory = Path.Combine(Environment.CurrentDirectory, tool.Name);
            Directory.CreateDirectory(directory);
            
            tool.DefinitionFile = file;
            tool.GenerationFileBase = Path.Combine(directory, Path.GetFileNameWithoutExtension(file));

            foreach (var task in tool.Tasks)
            {
                task.Tool = tool;
                task.SettingsClass.Tool = tool;
                task.SettingsClass.Task = task;
            }
            foreach (var dataClass in tool.DataClasses)
                dataClass.Tool = tool;
            foreach (var enumeration in tool.Enumerations)
                enumeration.Tool = tool;

            return tool;
        }

        private static void UpdateReferences (Tool tool)
        {
            for (var i = 0; i < tool.References.Count; i++)
            {
                try
                {
                    File.WriteAllText(
                        $"{tool.GenerationFileBase}.ref.{i.ToString().PadLeft(totalWidth: 3, paddingChar: '0')}.txt",
                        GetReferenceContent(tool.References[i]));
                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine($"Couldn't update reference #{i} for {Path.GetFileName(tool.DefinitionFile)}:");
                    Console.Error.WriteLine(exception.Message);
                }
            }
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
            File.WriteAllText(tool.DefinitionFile, content);
        }

        private static string GetReferenceContent (string reference)
        {
            var referenceValues = reference.Split('#');

            var tempFile = Path.GetTempFileName();
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(referenceValues[0], tempFile);
            }

            if (referenceValues.Length == 1)
                return File.ReadAllText(tempFile, Encoding.UTF8);

            var document = new HtmlDocument();
            document.Load(tempFile, Encoding.UTF8);
            return document.DocumentNode.SelectSingleNode(referenceValues[1]).InnerText;
        }

        private class CustomContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty ([NotNull] MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = x =>
                {
                    var propertyInfo = member as PropertyInfo;
                    return propertyInfo == null || propertyInfo.GetSetMethod() != null;
                };
                return property;
            }
        }
    }
}
