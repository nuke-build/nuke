// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class EmbedPackagesForSelfContainedTask : ContextAwareTask
    {
        [Required]
        public string ProjectAssetsFile { get; set; }

        [Required]
        public string TargetFramework { get; set; }

        [Output]
        public ITaskItem[] TargetOutputs { get; set; }

        protected override bool ExecuteInner()
        {
            var packages = NuGetPackageResolver.GetLocalInstalledPackages(ProjectAssetsFile);
            TargetOutputs = packages
                .Where(x => !x.Id.StartsWithOrdinalIgnoreCase("microsoft.netcore.app.runtime"))
                .Where(x => Directory.GetDirectories(x.Directory, "tools").Any())
                .Select(x => new TaskItem(x.File)).ToArray<ITaskItem>();
            return true;
        }
    }
}
