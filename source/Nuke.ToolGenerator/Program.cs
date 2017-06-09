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
    public class Program
    {
        private static void Main ()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.td", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                Console.WriteLine($"Processing {file}...");

                var tool = Load(file);
                var streamWriter = new StreamWriter(File.Open(Path.ChangeExtension (tool.File, "Generated.cs"), FileMode.Create));

                Generators.ToolGenerator.Run(tool, streamWriter);
                TryUpdateReference (tool);
                Save(tool);
            }
        }

        private static Tool Load (string file)
        {
            var content = File.ReadAllText(file);
            var tool = JsonConvert.DeserializeObject<Tool>(content);
            tool.File = file;
            return tool;
        }

        private static void TryUpdateReference (Tool tool)
        {
            if (tool.Reference?.Url == null)
                return;

            try
            {
                var reference = GetReferenceContent(tool);
                var referenceFile = Path.ChangeExtension(tool.File, ".reference.txt");
                Trace.Assert(referenceFile != null, "referenceFile != null");
                File.WriteAllText(referenceFile, reference);
                tool.Reference.HashCode = reference.GetHashCode();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Couldn't update reference for {0}:", Path.GetFileName(tool.File));
                Console.WriteLine(exception.Message);
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
            File.WriteAllText(tool.File, content);
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
