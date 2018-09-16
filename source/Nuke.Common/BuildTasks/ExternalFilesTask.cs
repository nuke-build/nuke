// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.BuildTasks
{
    [PublicAPI]
    public class ExternalFilesTask : ITask
    {
        public IBuildEngine BuildEngine { get; set; }
        public ITaskHost HostObject { get; set; }

        [Required]
        public ITaskItem[] ExternalFiles { get; set; }

        public int Timeout { get; set; }

        public bool Execute()
        {
            return ExternalFiles
                .Select(x => DownloadExternalFile(x.GetMetadata("Fullpath"), Timeout))
                .WhereNotNull()
                .ToList()
                .All(x => x.Result);
        }

        [CanBeNull]
        private async Task<bool> DownloadExternalFile(string externalFile, int timeout)
        {
            try
            {
                var lines = File.ReadAllLines(externalFile).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var uriConversion = Uri.TryCreate(lines.FirstOrDefault(), UriKind.Absolute, out var uri);
                ControlFlow.Assert(uriConversion, $"Could not parse URI for external file from first line of '{externalFile}'.");

                var outputFile = externalFile.Substring(0, externalFile.Length - 4);
                var previousHash = File.Exists(outputFile) ? FileSystemTasks.GetFileHash(outputFile) : null;
                
                var template = await HttpTasks.HttpDownloadStringAsync(uri.AbsolutePath);
                var replacements = lines.Skip(1)
                    .Where(x => x.Contains('='))
                    .Select(x => x.Split('='))
                    .Where(x => x.Length == 2)
                    .ToDictionary(
                        x => $"_{x.First().Trim('_').ToUpperInvariant()}_",
                        x => x.ElementAt(1));
                var definitions = lines.Skip(1)
                    .Where(x => !x.Contains(x) && !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.ToUpperInvariant())
                    .ToList();
                
                File.WriteAllText(outputFile, TemplateUtility.FillTemplate(template, definitions, replacements));
                var newHash = FileSystemTasks.GetFileHash(outputFile);

                if (newHash != previousHash)
                {
                    BuildEngine.LogWarningEvent(
                        new BuildWarningEventArgs(
                            subcategory: "Build",
                            code: null,
                            file: externalFile,
                            lineNumber: 0,
                            columnNumber: 0,
                            endLineNumber: 0,
                            endColumnNumber: 0,
                            message: $"External file '{outputFile}' has been updated from '{uri}'.",
                            helpKeyword: null,
                            senderName: typeof(ExternalFilesTask).FullName));
                }

                return true;
            }
            catch (Exception exception)
            {
                BuildEngine.LogErrorEvent(new BuildErrorEventArgs(
                    subcategory: "Build",
                    code: null,
                    file: externalFile,
                    lineNumber: 0,
                    columnNumber: 0,
                    endLineNumber: 0,
                    endColumnNumber: 0,
                    message: exception.Message,
                    helpKeyword: null,
                    senderName: typeof(ExternalFilesTask).FullName));
                return false;
            }
        }
    }
}
