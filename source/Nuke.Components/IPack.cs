﻿// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    public interface IPack : ICompile, IHazArtifacts
    {
        AbsolutePath PackagesDirectory => ArtifactsDirectory / "packages";

        Target Pack => _ => _
            .DependsOn(Compile)
            .Produces(PackagesDirectory / "*.nupkg")
            .Executes(() =>
            {
                DotNetPack(_ => _
                    .SetProject(Solution)
                    .SetConfiguration(Configuration)
                    .SetNoBuild(InvokedTargets.Contains(Compile))
                    .SetOutputDirectory(PackagesDirectory)
                    .WhenNotNull(this as IHazGitVersion, (_, o) => _
                        .SetVersion(o.Versioning.NuGetVersionV2))
                    .WhenNotNull(this as IHazNerdbankGitVersioning, (_, o) => _
                        .SetVersion(o.Versioning.NuGetPackageVersion))
                    .WhenNotNull(this as IHazChangelog, (_, o) => _
                        .SetPackageReleaseNotes(o.ReleaseNotes))
                    .Apply(PackSettings));
            });

        Configure<DotNetPackSettings> PackSettings => _ => _;
    }
}
