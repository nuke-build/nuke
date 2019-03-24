// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Nuke.Common.Git;
using Nuke.Common;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.CodeGeneration
{
    [PublicAPI]
    public class CodeGeneratorTask : ITask
    {
        private const string c_exampleUrl = "https://raw.githubusercontent.com/nuke-build/nuke/master/source/Nuke.CodeGeneration/RandomTool.json";

        public IBuildEngine BuildEngine { get; set; }
        public ITaskHost HostObject { get; set; }

        [Microsoft.Build.Framework.Required]
        public ITaskItem[] SpecificationFiles { get; set; }

        [Microsoft.Build.Framework.Required]
        public string BaseDirectory { get; set; }

        public bool UseNestedNamespaces { get; set; }

        [CanBeNull]
        public string BaseNamespace { get; set; }

        public bool UpdateReferences { get; set; }

        public bool Execute()
        {
            var specificationFiles = SpecificationFiles.Select(x => x.GetMetadata("Fullpath")).ToList();
            var repository = ControlFlow.SuppressErrors(() => GitRepository.FromLocalDirectory(BaseDirectory));

            CodeGenerator.GenerateCode(
                specificationFiles,
                outputFileProvider: x =>
                    (AbsolutePath) BaseDirectory
                    / (UseNestedNamespaces ? x.Name : ".")
                    / x.DefaultOutputFileName,
                namespaceProvider: x =>
                    !UseNestedNamespaces
                        ? BaseNamespace
                        : string.IsNullOrEmpty(BaseNamespace)
                            ? x.Name
                            : $"{BaseNamespace}.{x.Name}",
                sourceFileProvider: x =>
                    repository.IsGitHubRepository() ? repository?.GetGitHubDownloadUrl(x.SpecificationFile) : null);

            if (UpdateReferences)
                ReferenceUpdater.UpdateReferences(specificationFiles);

            return true;
        }
    }
}
