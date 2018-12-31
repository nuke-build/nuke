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
                .Select(x => DownloadExternalFile(x.GetMetadata("Fullpath"), Timeout, ReportWarning, ReportError))
                .ToList()
                .All(x => x.Result);
        }

        public static async Task<bool> DownloadExternalFile(
            string externalFile,
            int timeout,
            Action<string, string> warningSink,
            Action<string, string> errorSink)
        {
            try
            {
                var lines = File.ReadAllLines(externalFile).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var uriConversion = Uri.TryCreate(lines.FirstOrDefault(), UriKind.Absolute, out var uri);
                ControlFlow.Assert(uriConversion, $"Could not parse URI for external file from first line of '{externalFile}'.");

                var outputFile = externalFile.Substring(startIndex: 0, length: externalFile.Length - 4);
                var previousHash = File.Exists(outputFile) ? FileSystemTasks.GetFileHash(outputFile) : null;
                
                var template = await HttpTasks.HttpDownloadStringAsync(uri.OriginalString);
                var replacements = lines.Skip(1)
                    .Where(x => x.Contains('='))
                    .Select(x => x.Split('='))
                    .Where(x => x.Length == 2)
                    .ToDictionary(
                        x => $"_{x.First().Trim('_').ToUpperInvariant()}_",
                        x => x.ElementAt(1));
                var definitions = lines.Skip(1)
                    .Where(x => !x.Contains('=') && !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.ToUpperInvariant())
                    .ToList();
                
                File.WriteAllText(outputFile, TemplateUtility.FillTemplate(template, definitions, replacements));
                var newHash = FileSystemTasks.GetFileHash(outputFile);

                if (newHash != previousHash)
                    warningSink(externalFile, "External file has been updated.");

                return true;
            }
            catch (Exception exception)
            {
                errorSink(externalFile, exception.Message);
                return false;
            }
        }

        private void ReportWarning(string externalFile, string message)
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
                    message: message,
                    helpKeyword: null,
                    senderName: typeof(ExternalFilesTask).FullName));
        }

        private void ReportError(string externalFile, string message)
        {
            BuildEngine.LogErrorEvent(new BuildErrorEventArgs(
                subcategory: "Build",
                code: null,
                file: externalFile,
                lineNumber: 0,
                columnNumber: 0,
                endLineNumber: 0,
                endColumnNumber: 0,
                message: message,
                helpKeyword: null,
                senderName: typeof(ExternalFilesTask).FullName));
        }
    }
}
