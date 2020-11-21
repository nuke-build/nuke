// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Nuke.CodeGeneration;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities.Collections;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class CodeGenerationTask : ContextAwareTask
    {
        [Microsoft.Build.Framework.Required]
        public ITaskItem[] SpecificationFiles { get; set; }

        [Microsoft.Build.Framework.Required]
        public string BaseDirectory { get; set; }

        public bool UseNestedNamespaces { get; set; }

        [CanBeNull]
        public string BaseNamespace { get; set; }

        public bool UpdateReferences { get; set; }

        protected override bool ExecuteInner()
        {
            var specificationFiles = SpecificationFiles.Select(x => x.GetMetadata("Fullpath")).ToList();
            var repository = ControlFlow.SuppressErrors(() => GitRepository.FromLocalDirectory(BaseDirectory), includeStackTrace: true);

            string GetFilePath(Tool tool)
                => (AbsolutePath) BaseDirectory
                   / (UseNestedNamespaces ? tool.Name : ".")
                   / tool.DefaultOutputFileName;

            string GetNamespace(Tool tool)
                => !UseNestedNamespaces
                    ? BaseNamespace
                    : string.IsNullOrEmpty(BaseNamespace)
                        ? tool.Name
                        : $"{BaseNamespace}.{tool.Name}";

            string GetSourceFile(Tool tool)
                => repository.IsGitHubRepository() ? repository?.GetGitHubDownloadUrl(tool.SpecificationFile) : null;

            specificationFiles
                .ForEachLazy(x => LogMessage(message: $"Handling {x} ..."))
                .ForEach(x => CodeGenerator.GenerateCode(x, GetFilePath, GetNamespace, GetSourceFile));

            if (UpdateReferences)
                ReferenceUpdater.UpdateReferences(specificationFiles);

            return true;
        }
    }
}
