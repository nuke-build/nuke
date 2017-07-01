// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
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
                using (var streamWriter = new StreamWriter(File.Open(tool.GenerationFile, FileMode.Create)))
                {
                    Generators.ToolGenerator.Run(tool, streamWriter);
                }
                TryUpdateReference (tool);
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
            tool.GenerationFile = Path.Combine(directory, Path.ChangeExtension(Path.GetFileNameWithoutExtension(file), "Generated.cs"));
            tool.ReferenceFile = Path.Combine(directory, Path.ChangeExtension(Path.GetFileNameWithoutExtension(file), "reference.txt"));
            
            if (tool.Task != null)
            {
                tool.Task.Tool = tool;
                tool.Task.SettingsClass.Tool = tool;
            }
            foreach (var dataClass in tool.DataClasses)
                dataClass.Tool = tool;

            return tool;
        }

        private static void TryUpdateReference (Tool tool)
        {
            if (tool.Reference?.Url == null)
                return;

            try
            {
                File.WriteAllText(tool.ReferenceFile, GetReferenceContent(tool));
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("Couldn't update reference for {0}:", Path.GetFileName(tool.DefinitionFile));
                Console.Error.WriteLine(exception.Message);
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

        private static string GetReferenceContent (Tool tool)
        {
            var tempFile = Path.GetTempFileName();
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(tool.Reference.Url, tempFile);
            }

            if (tool.Reference.XPath == null)
                return File.ReadAllText(tempFile, Encoding.UTF8);

            var document = new HtmlDocument();
            document.Load(tempFile, Encoding.UTF8);
            return document.DocumentNode.SelectSingleNode(tool.Reference.XPath).InnerText;
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
