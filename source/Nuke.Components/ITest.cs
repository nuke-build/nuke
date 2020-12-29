// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    public interface ITest : ICompile, IHazArtifacts
    {
        AbsolutePath TestResultDirectory => ArtifactsDirectory / "test-results";

        Target Test => _ => _
            .DependsOn(Compile)
            .Produces(TestResultDirectory / "*.trx")
            .Produces(TestResultDirectory / "*.xml")
            .Executes(() =>
            {
                DotNetTest(_ => _
                    .SetConfiguration(Configuration)
                    .SetNoBuild(InvokedTargets.Contains(Compile))
                    .ResetVerbosity()
                    .SetResultsDirectory(TestResultDirectory)
                    .When( /*InvokedTargets.Contains(Coverage) ||*/ IsServerBuild, _ => _
                        .EnableCollectCoverage()
                        .SetCoverletOutputFormat(CoverletOutputFormat.cobertura)
                        .SetExcludeByFile("*.Generated.cs")
                        .When(IsServerBuild, _ => _
                            .EnableUseSourceLink()))
                    .CombineWith(TestProjects, (_, v) => _
                        .SetProjectFile(v)
                        .SetLogger($"trx;LogFileName={v.Name}.trx")
                        .When( /*InvokedTargets.Contains(Coverage) ||*/ IsServerBuild, _ => _
                            .SetCoverletOutput(TestResultDirectory / $"{v.Name}.xml")))
                    .Apply(TestSettings));
            });

        Configure<DotNetTestSettings> TestSettings => _ => _;

        IEnumerable<Project> TestProjects { get; }
    }
}
