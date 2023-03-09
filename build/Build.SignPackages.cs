// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Components;

partial class Build : ISignPackages
{
    public IEnumerable<AbsolutePath> SignPathPackages
        => From<IPack>().PackagesDirectory.GlobFiles("*.nupkg")
            .Where(x => Path.GetFileNameWithoutExtension(x)
                .StartsWithAnyOrdinalIgnoreCase(
                    Solution.Nuke_Common.Name,
                    Solution.Nuke_Components.Name,
                    Solution.Nuke_Tooling_Generator.Name,
                    Solution.Nuke_GlobalTool.Name));

    public Target SignPackages => _ => _
        .Inherit<ISignPackages>()
        .OnlyWhenStatic(() => GitRepository.IsOnMasterBranch() || GitRepository.IsOnReleaseBranch())
        .OnlyWhenStatic(() => EnvironmentInfo.IsWin);
}
