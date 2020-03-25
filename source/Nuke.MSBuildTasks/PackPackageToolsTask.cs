// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using JetBrains.Annotations;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Nuke.Common;
using Nuke.Common.Tooling;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.MSBuildTasks
{
    [UsedImplicitly]
    public class PackPackageToolsTask : ContextAwareTask
    {
        [Microsoft.Build.Framework.Required]
        public string ProjectAssetsFile { get; set; }

        [Microsoft.Build.Framework.Required]
        public string NuGetPackageRoot { get; set; }

        [Microsoft.Build.Framework.Required]
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
            var packageToolsPath = Path.Combine(NuGetPackageRoot, packageId, packageVersion, "tools");
            if (!Directory.Exists(packageToolsPath))
                yield break;

            foreach (var file in Directory.GetFiles(packageToolsPath, "*", SearchOption.AllDirectories))
            {
                var taskItem = new TaskItem(file);
                taskItem.SetMetadata("BuildAction", "None");
                taskItem.SetMetadata("PackagePath",
                    Path.Combine(
                        "tools",
                        TargetFramework,
                        "any",
                        packageId,
                        GetRelativePath(packageToolsPath, file)));
                yield return taskItem;
            }
        }
    }
}
