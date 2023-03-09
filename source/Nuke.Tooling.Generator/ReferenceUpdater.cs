// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.Utilities.Net;
using Serilog;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public static class ReferenceUpdater
    {
        private static HttpClient s_client = new();

        public static void UpdateReferences(string specificationsDirectory, string referencesDirectory = null)
        {
            UpdateReferences(Directory.GetFiles(specificationsDirectory, "*.json", SearchOption.TopDirectoryOnly), referencesDirectory);
        }

        public static void UpdateReferences(IEnumerable<string> specificationFiles, string referencesDirectory = null)
        {
            var tools = specificationFiles.Select(ToolSerializer.Load);
            var updateTasks = tools.SelectMany(x => x.References.Select(y => Update(y, x, referencesDirectory)));
            System.Threading.Tasks.Task.WaitAll(updateTasks.ToArray());
        }

        private static async System.Threading.Tasks.Task Update(string reference, Tool tool, [CanBeNull] string referencesDirectory)
        {
            var index = tool.References.IndexOf(reference);
            try
            {
                referencesDirectory ??= Path.GetDirectoryName(tool.SpecificationFile).NotNull();
                var referenceId = index.ToString().PadLeft(totalWidth: 3, paddingChar: '0');
                var referenceFile = Path.Combine(
                    referencesDirectory,
                    $"{Path.GetFileNameWithoutExtension(tool.SpecificationFile)}.ref.{referenceId}.txt");
                var referenceContent = await GetReferenceContent(reference);
                File.WriteAllText(referenceFile, referenceContent);

                Log.Information("Updated reference for {File}#{Index}'", Path.GetFileName(tool.SpecificationFile), index);
            }
            catch (Exception exception)
            {
                Log.Error("Couldn't update {File}#{Index}: {Reference}", Path.GetFileName(tool.SpecificationFile), index, reference);
                Log.Error(exception.Message);
            }
        }

        private static async Task<string> GetReferenceContent(string reference)
        {
            var referenceValues = reference.Split('#');
            var tempFile = Path.GetTempFileName();

            var response = await s_client.CreateRequest(HttpMethod.Get, referenceValues[0])
                .GetResponseAsync();
            await response.WriteToFile(tempFile);

            if (referenceValues.Length == 1)
                return File.ReadAllText(tempFile, Encoding.UTF8);

            var document = new HtmlDocument();
            document.Load(tempFile, Encoding.UTF8);
            var selectedNode = document.DocumentNode.SelectSingleNode(referenceValues[1]);
            return selectedNode.NotNull().InnerText;
        }

        // private class AutomaticDecompressingWebClient : WebClient
        // {
        //     [CanBeNull]
        //     protected override WebRequest GetWebRequest(Uri address)
        //     {
        //         var request = base.GetWebRequest(address) as HttpWebRequest;
        //
        //         if (request != null)
        //             request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        //
        //         return request;
        //     }
        // }
    }
}
