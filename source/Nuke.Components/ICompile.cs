// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    public interface ICompile : IRestore, IHazConfiguration
    {
        Target Compile => _ => _
            .DependsOn(Restore)
            .Executes(() =>
            {
                DotNetBuild(_ => _
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
                        .SetProperty("ContinuesIntegrationBuild", true))
                    .Apply(CompileSettings));

                DotNetPublish(_ => _
                        .SetConfiguration(Configuration)
                        .EnableNoBuild()
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
                            .SetProperty("ContinuesIntegrationBuild", true))
                        .CombineWith(PublishConfigurations, (_, v) => _
                            .SetProject(v.Project)
                            .SetFramework(v.Framework)),
                    degreeOfParallelism: PublishDegreeOfParallelism);
            });

        Configure<DotNetBuildSettings> CompileSettings => _ => _;

        IEnumerable<(Project Project, string Framework)> PublishConfigurations
            => new (Project Project, string Framework)[0];

        int PublishDegreeOfParallelism => 10;
    }
}
