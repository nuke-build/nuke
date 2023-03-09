// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
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

        int TestDegreeOfParallelism => 1;

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
                        completeOnFailure: true,
                        degreeOfParallelism: TestDegreeOfParallelism);
                }
                finally
                {
                    ReportTestResults();
                    ReportTestCount();
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

        void ReportTestCount()
        {
            IEnumerable<string> GetOutcomes(AbsolutePath file)
                => XmlTasks.XmlPeek(
                    file,
                    "/xn:TestRun/xn:Results/xn:UnitTestResult/@outcome",
                    ("xn", "http://microsoft.com/schemas/VisualStudio/TeamTest/2010"));

            var resultFiles = TestResultDirectory.GlobFiles("*.trx");
            var outcomes = resultFiles.SelectMany(GetOutcomes).ToList();
            var passedTests = outcomes.Count(x => x == "Passed");
            var failedTests = outcomes.Count(x => x == "Failed");
            var skippedTests = outcomes.Count(x => x == "NotExecuted");

            ReportSummary(_ => _
                .When(failedTests > 0, _ => _
                    .AddPair("Failed", failedTests.ToString()))
                .AddPair("Passed", passedTests.ToString())
                .When(skippedTests > 0, _ => _
                    .AddPair("Skipped", skippedTests.ToString())));
        }

        sealed Configure<DotNetTestSettings> TestSettingsBase => _ => _
            .SetConfiguration(Configuration)
            .SetNoBuild(SucceededTargets.Contains(Compile))
            .ResetVerbosity()
            .SetResultsDirectory(TestResultDirectory)
            .When(InvokedTargets.Contains((this as IReportCoverage)?.ReportCoverage) || IsServerBuild, _ => _
                .EnableCollectCoverage()
                .SetCoverletOutputFormat(CoverletOutputFormat.cobertura)
                .SetExcludeByFile("*.Generated.cs")
                .When(TeamCity.Instance is not null, _ => _
                    .SetCoverletOutputFormat($"\\\"{CoverletOutputFormat.cobertura},{CoverletOutputFormat.teamcity}\\\""))
                .When(IsServerBuild, _ => _
                    .EnableUseSourceLink()));

        sealed Configure<DotNetTestSettings, Project> TestProjectSettingsBase => (_, v) => _
            .SetProjectFile(v)
            // https://github.com/Tyrrrz/GitHubActionsTestLogger
            .When(GitHubActions.Instance is not null && v.HasPackageReference("GitHubActionsTestLogger"), _ => _
                .AddLoggers("GitHubActions;report-warnings=false"))
            // https://github.com/JetBrains/TeamCity.VSTest.TestAdapter
            .When(TeamCity.Instance is not null && v.HasPackageReference("TeamCity.VSTest.TestAdapter"), _ => _
                .AddLoggers("TeamCity")
                // https://github.com/xunit/visualstudio.xunit/pull/108
                .AddRunSetting("RunConfiguration.NoAutoReporters", bool.TrueString))
            .AddLoggers($"trx;LogFileName={v.Name}.trx")
            .When(InvokedTargets.Contains((this as IReportCoverage)?.ReportCoverage) || IsServerBuild, _ => _
                .SetCoverletOutput(TestResultDirectory / $"{v.Name}.xml"));

        Configure<DotNetTestSettings> TestSettings => _ => _;
        Configure<DotNetTestSettings, Project> TestProjectSettings => (_, v) => _;

        IEnumerable<Project> TestProjects { get; }
    }
}
