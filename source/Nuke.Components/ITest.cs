// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface ITest : ICompile, IHazArtifacts
    {
        AbsolutePath TestResultDirectory => ArtifactsDirectory / "test-results";

        Target Test => _ => _
            .DependsOn(Compile)
            .Produces(TestResultDirectory / "*.trx")
            .Produces(TestResultDirectory / "*.xml")
            .Executes(() =>
            {
                try
                {
                    DotNetTest(_ => _
                            .Apply(TestSettingsBase)
                            .Apply(TestSettings)
                            .CombineWith(TestProjects, (_, v) => _
                                .Apply(TestProjectSettingsBase, v)
                                .Apply(TestProjectSettings, v)),
                        completeOnFailure: true);
                }
                finally
                {
                    ReportTestResults();
                }
            });

        void ReportTestResults()
        {
            TestResultDirectory.GlobFiles("*.trx").ForEach(x =>
                AzurePipelines.Instance?.PublishTestResults(
                    type: AzurePipelinesTestResultsType.VSTest,
                    title: $"{Path.GetFileNameWithoutExtension(x)} ({AzurePipelines.Instance.StageDisplayName})",
                    files: new string[] { x }));
        }

        sealed Configure<DotNetTestSettings> TestSettingsBase => _ => _
            .SetConfiguration(Configuration)
            .SetNoBuild(InvokedTargets.Contains(Compile))
            .ResetVerbosity()
            .SetResultsDirectory(TestResultDirectory)
            .When(InvokedTargets.Contains((this as IReportTestCoverage)?.ReportTestCoverage) || IsServerBuild, _ => _
                .EnableCollectCoverage()
                .SetCoverletOutputFormat((CoverletOutputFormat) $"{CoverletOutputFormat.teamcity},{CoverletOutputFormat.cobertura}")
                .SetExcludeByFile("*.Generated.cs")
                .When(IsServerBuild, _ => _
                    .EnableUseSourceLink()));

        sealed Configure<DotNetTestSettings, Project> TestProjectSettingsBase => (_, v) => _
            .SetProjectFile(v)
            .SetLogger($"trx;LogFileName={v.Name}.trx")
            .When(InvokedTargets.Contains((this as IReportTestCoverage)?.ReportTestCoverage) || IsServerBuild, _ => _
                .SetCoverletOutput(TestResultDirectory / $"{v.Name}.xml"));

        Configure<DotNetTestSettings> TestSettings => _ => _;
        Configure<DotNetTestSettings, Project> TestProjectSettings => (_, v) => _;

        IEnumerable<Project> TestProjects { get; }
    }
}
