// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IPack : ICompile, IHazArtifacts
    {
        AbsolutePath PackagesDirectory => ArtifactsDirectory / "packages";

        Target Pack => _ => _
            .DependsOn(Compile)
            .Produces(PackagesDirectory / "*.nupkg")
            .Executes(() =>
            {
                DotNetPack(_ => _
                    .Apply(PackSettingsBase)
                    .Apply(PackSettings));

                ReportSummary(_ => _
                    .AddPair("Packages", PackagesDirectory.GlobFiles("*.nupkg").Count.ToString()));
            });

        sealed Configure<DotNetPackSettings> PackSettingsBase => _ => _
            .SetProject(Solution)
            .SetConfiguration(Configuration)
            .SetNoBuild(SucceededTargets.Contains(Compile))
            .SetOutputDirectory(PackagesDirectory)
            .WhenNotNull(this as IHazGitRepository, (_, o) => _
                .SetRepositoryUrl(o.GitRepository.HttpsUrl))
            .WhenNotNull(this as IHazGitVersion, (_, o) => _
                .SetVersion(o.Versioning.NuGetVersionV2))
            .WhenNotNull(this as IHazNerdbankGitVersioning, (_, o) => _
                .SetVersion(o.Versioning.NuGetPackageVersion))
            .WhenNotNull(this as IHazChangelog, (_, o) => _
                .SetPackageReleaseNotes(o.NuGetReleaseNotes));

        Configure<DotNetPackSettings> PackSettings => _ => _;
    }
}
