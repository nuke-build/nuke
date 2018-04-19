// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Model;
using Nuke.Common;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class ReferenceUpdater
    {
        public static void UpdateReferences(string metadataDirectory, string referenceDirectory = null)
        {
            UpdateReferences(Directory.GetFiles(metadataDirectory, "*.json", SearchOption.TopDirectoryOnly), referenceDirectory);
        }

        public static void UpdateReferences(IEnumerable<string> metadataFiles, string referenceDirectory = null)
        {
            var tools = metadataFiles.Select(ToolSerializer.Load);
            var updateTasks = tools.SelectMany(x => x.References.Select(y => Update(y, x, referenceDirectory)));
            System.Threading.Tasks.Task.WaitAll(updateTasks.ToArray());
        }

        private static async System.Threading.Tasks.Task Update(string reference, Tool tool, [CanBeNull] string referenceDirectory)
        {
            var index = tool.References.IndexOf(reference);
            try
            {
                referenceDirectory = referenceDirectory ?? Path.GetDirectoryName(tool.DefinitionFile).NotNull();
                var referenceId = index.ToString().PadLeft(totalWidth: 3, paddingChar: '0');
                var referenceFile = Path.Combine(
                    referenceDirectory,
                    $"{Path.GetFileNameWithoutExtension(tool.DefinitionFile)}.ref.{referenceId}.txt");
                var referenceContent = await GetReferenceContent(reference);
                File.WriteAllText(referenceFile, referenceContent);

                Logger.Info($"Updated reference for '{Path.GetFileName(tool.DefinitionFile)}#{index}'.");
            }
            catch (Exception exception)
            {
                Logger.Error($"Couldn't update {Path.GetFileName(tool.DefinitionFile)}#{index}: {reference}");
                Logger.Error(exception.Message);
            }
        }

        private static async Task<string> GetReferenceContent(string reference)
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
