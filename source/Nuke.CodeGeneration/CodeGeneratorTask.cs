// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Nuke.Common.Git;
using Nuke.Common;
using Nuke.Common.IO;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public class CodeGeneratorTask : ITask
    {
        private const string c_exampleUrl = "https://raw.githubusercontent.com/nuke-build/nuke/master/source/Nuke.CodeGeneration/RandomTool.json";

        public IBuildEngine BuildEngine { get; set; }
        public ITaskHost HostObject { get; set; }

        [Required]
        public ITaskItem[] MetadataFiles { get; set; }

        [Required]
        public string BaseDirectory { get; set; }

        public bool UseNestedNamespaces { get; set; }

        [CanBeNull]
        public string BaseNamespace { get; set; }

        public bool UpdateReferences { get; set; }

        public bool Execute()
        {
            var metadataFiles = MetadataFiles.Select(x => x.GetMetadata("Fullpath")).ToList();
            if (!MetadataFiles.Any())
            {
                ControlFlow.SuppressErrors(() =>
                {
                    var exampleFile = Path.Combine(BaseDirectory, "RandomTool.json");
                    HttpTasks.HttpDownloadFile(c_exampleUrl, exampleFile);
                    metadataFiles.Add(exampleFile);
                });
            }

            CodeGenerator.GenerateCode(
                metadataFiles,
                BaseDirectory,
                UseNestedNamespaces,
                BaseNamespace,
                GitRepository.FromLocalDirectory(BaseDirectory));

            if (UpdateReferences)
                ReferenceUpdater.UpdateReferences(metadataFiles);

            return true;
        }
    }
}
