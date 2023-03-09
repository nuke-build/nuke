// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IGlobalTool : INukeBuild
    {
        string GlobalToolPackageName => Path.GetFileNameWithoutExtension(BuildProjectFile);
        string GlobalToolVersion => "1.0.0";

        Target PackGlobalTool => _ => _
            .Unlisted()
            .Executes(() =>
            {
                DotNetPack(_ => _
                    .SetProject(BuildProjectFile)
                    .SetOutputDirectory(TemporaryDirectory));
            });

        Target InstallGlobalTool => _ => _
            .Unlisted()
            .DependsOn(UninstallGlobalTool)
            .DependsOn(PackGlobalTool)
            .Executes(() =>
            {
                DotNetToolInstall(_ => _
                    .SetPackageName(GlobalToolPackageName)
                    .EnableGlobal()
                    .AddSources(TemporaryDirectory)
                    .SetVersion(GlobalToolVersion));
            });

        Target UninstallGlobalTool => _ => _
            .Unlisted()
            .ProceedAfterFailure()
            .Executes(() =>
            {
                DotNetToolUninstall(_ => _
                    .SetPackageName(GlobalToolPackageName)
                    .EnableGlobal());
            });
    }
}
