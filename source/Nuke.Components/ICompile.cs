// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface ICompile : IRestore, IHazConfiguration
    {
        Target Compile => _ => _
            .DependsOn(Restore)
            .WhenSkipped(DependencyBehavior.Skip)
            .Executes(() =>
            {
                DotNetBuild(_ => _
                    .Apply(CompileSettingsBase)
                    .Apply(CompileSettings));

                DotNetPublish(_ => _
                        .Apply(PublishSettingsBase)
                        .Apply(PublishSettings)
                        .CombineWith(PublishConfigurations, (_, v) => _
                            .SetProject(v.Project)
                            .SetFramework(v.Framework)),
                    PublishDegreeOfParallelism);
            });

        sealed Configure<DotNetBuildSettings> CompileSettingsBase => _ => _
            .SetProjectFile(Solution)
            .SetConfiguration(Configuration)
            // .SetNoRestore(InvokedTargets.Contains(Restore))
            .WhenNotNull(this as IHazGitRepository, (_, o) => _
                .SetRepositoryUrl(o.GitRepository.HttpsUrl))
            .WhenNotNull(this as IHazGitVersion, (_, o) => _
                .SetAssemblyVersion(o.Versioning.AssemblySemVer)
                .SetFileVersion(o.Versioning.AssemblySemFileVer)
                .SetInformationalVersion(o.Versioning.InformationalVersion))
            .WhenNotNull(this as IHazNerdbankGitVersioning, (_, o) => _
                .SetAssemblyVersion(o.Versioning.AssemblyVersion)
                .SetFileVersion(o.Versioning.AssemblyFileVersion)
                .SetInformationalVersion(o.Versioning.AssemblyInformationalVersion))
            .When(IsServerBuild, _ => _
                .SetProperty("ContinuesIntegrationBuild", true));

        sealed Configure<DotNetPublishSettings> PublishSettingsBase => _ => _
            .SetConfiguration(Configuration)
            .EnableNoBuild()
            .EnableNoLogo()
            .WhenNotNull(this as IHazGitRepository, (_, o) => _
                .SetRepositoryUrl(o.GitRepository.HttpsUrl))
            .WhenNotNull(this as IHazGitVersion, (_, o) => _
                .SetAssemblyVersion(o.Versioning.AssemblySemVer)
                .SetFileVersion(o.Versioning.AssemblySemFileVer)
                .SetInformationalVersion(o.Versioning.InformationalVersion))
            .WhenNotNull(this as IHazNerdbankGitVersioning, (_, o) => _
                .SetAssemblyVersion(o.Versioning.AssemblyVersion)
                .SetFileVersion(o.Versioning.AssemblyFileVersion)
                .SetInformationalVersion(o.Versioning.AssemblyInformationalVersion))
            .When(IsServerBuild, _ => _
                .SetProperty("ContinuesIntegrationBuild", true));

        Configure<DotNetBuildSettings> CompileSettings => _ => _;
        Configure<DotNetPublishSettings> PublishSettings => _ => _;

        IEnumerable<(Project Project, string Framework)> PublishConfigurations
            => new (Project Project, string Framework)[0];

        int PublishDegreeOfParallelism => 10;
    }
}
