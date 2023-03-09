// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Nuke.Common.Tooling;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class PackPackageToolsTask : ContextAwareTask
    {
        [Required]
        public string ProjectAssetsFile { get; set; }

        [Required]
        public string NuGetPackageRoot { get; set; }

        [Required]
        public string TargetFramework { get; set; }

        [Output]
        public ITaskItem[] TargetOutputs { get; set; }

        protected override bool ExecuteInner()
        {
            var packages = NuGetPackageResolver.GetLocalInstalledPackages(ProjectAssetsFile);
            TargetOutputs = packages.SelectMany(x => GetFiles(x.Id, x.Version.ToString())).ToArray();
            return true;
        }

        private IEnumerable<ITaskItem> GetFiles(string packageId, string packageVersion)
        {
            var packageToolsDirectory =  Path.Combine(NuGetPackageRoot, packageId.ToLowerInvariant(), packageVersion.ToLowerInvariant(), "tools");
            if (!Directory.Exists(packageToolsDirectory))
                yield break;

            foreach (var file in Directory.GetFiles(packageToolsDirectory, "*", SearchOption.AllDirectories))
            {
                var taskItem = new TaskItem(file);
                taskItem.SetMetadata("BuildAction", "None");
                taskItem.SetMetadata("PackagePath",
                    Path.Combine(
                        "tools",
                        TargetFramework,
                        "any",
                        packageId,
                        GetRelativePath(packageToolsDirectory, file)));
                yield return taskItem;
            }
        }
    }
}
