// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Codecov;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.Tools.Codecov.CodecovTasks;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IReportCoverage : ITest, IHazReports, IHazGitRepository, IHazGitVersion
    {
        bool CreateCoverageHtmlReport { get; }
        bool ReportToCodecov { get; }
        [Parameter] [Secret] string CodecovToken => TryGetValue(() => CodecovToken);

        string CoverageReportDirectory => ReportDirectory / "coverage-report";
        string CoverageReportArchive => Path.ChangeExtension(CoverageReportDirectory, ".zip");

        Target ReportCoverage => _ => _
            .DependsOn(Test)
            .TryAfter<ITest>()
            .Consumes(Test)
            .Produces(CoverageReportArchive)
            .Requires(() => !ReportToCodecov || CodecovToken != null)
            .Executes(() =>
            {
                if (ReportToCodecov)
                {
                    Codecov(_ => _
                        .Apply(CodecovSettingsBase)
                        .Apply(CodecovSettings));
                }

                if (CreateCoverageHtmlReport)
                {
                    ReportGenerator(_ => _
                        .Apply(ReportGeneratorSettingsBase)
                        .Apply(ReportGeneratorSettings));

                    CompressZip(
                        directory: CoverageReportDirectory,
                        archiveFile: CoverageReportArchive,
                        fileMode: FileMode.Create);
                }

                UploadCoverageData();
            });

        sealed Configure<CodecovSettings> CodecovSettingsBase => _ => _
            .SetFiles(TestResultDirectory.GlobFiles("*.xml").Select(x => x.ToString()))
            .SetToken(CodecovToken)
            .SetBranch(GitRepository.Branch)
            .SetSha(GitRepository.Commit)
            .SetBuild(Versioning.FullSemVer)
            .SetFramework("netcoreapp3.0");

        Configure<CodecovSettings> CodecovSettings => _ => _;

        sealed Configure<ReportGeneratorSettings> ReportGeneratorSettingsBase => _ => _
            .SetReports(TestResultDirectory / "*.xml")
            .SetReportTypes(ReportTypes.HtmlInline)
            .SetTargetDirectory(CoverageReportDirectory)
            .SetFramework("netcoreapp2.1");

        Configure<ReportGeneratorSettings> ReportGeneratorSettings => _ => _;

        void UploadCoverageData()
        {
            TestResultDirectory.GlobFiles("*.xml").ForEach(x =>
                AzurePipelines.Instance?.PublishCodeCoverage(
                    AzurePipelinesCodeCoverageToolType.Cobertura,
                    x,
                    CoverageReportDirectory));
        }
    }
}
