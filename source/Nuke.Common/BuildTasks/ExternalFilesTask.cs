// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Nuke.Common.IO;
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
        private async Task<bool> DownloadExternalFile(string file, int timeout)
        {
            try
            {
                var lines = File.ReadAllLines(file).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                ControlFlow.Assert(lines.Count == 1, $"External file '{file}' must contain single URI.");

                var uriString = lines.FirstOrDefault();
                if (!Uri.TryCreate(uriString, UriKind.Absolute, out var uri))
                    ControlFlow.Fail($"Could not parse '{uriString}' from external file '{file}'.");

                var outputFile = file.Substring(0, file.Length - 4);
                await HttpTasks.HttpDownloadFileAsync(uri.AbsolutePath, outputFile);

                BuildEngine.LogMessageEvent(new BuildMessageEventArgs(
                    $"Successfully downloaded external file '{outputFile}' from '{uri}'.",
                    helpKeyword: null,
                    senderName: typeof(ExternalFilesTask).FullName,
                    importance: MessageImportance.Normal));

                return true;
            }
            catch (Exception exception)
            {
                BuildEngine.LogErrorEvent(new BuildErrorEventArgs(
                    subcategory: "Build",
                    code: null,
                    file: file,
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
