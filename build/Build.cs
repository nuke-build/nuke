// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.SpaceAutomation;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Codecov;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotCover;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Tools.ReSharper;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.Codecov.CodecovTasks;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

[CheckBuildProjectConfigurations]
[DotNetVerbosityMapping]
[ShutdownDotNetAfterServerBuild]
[TeamCitySetDotCoverHomePath]
[GitHubActions(
    "deployment",
    GitHubActionsImage.MacOsLatest,
    OnPushBranches = new[] { MasterBranch, ReleaseBranchPrefix + "/*" },
    InvokedTargets = new[] { nameof(Publish) },
    ImportGitHubTokenAs = nameof(GitHubToken),
    ImportSecrets =
        new[]
        {
            nameof(NuGetApiKey),
            nameof(SlackWebhook),
            nameof(GitterAuthToken),
            nameof(TwitterConsumerKey),
            nameof(TwitterConsumerSecret),
            nameof(TwitterAccessToken),
            nameof(TwitterAccessTokenSecret)
        })]
[SpaceAutomation(
    name: "continuous",
    image: "mcr.microsoft.com/dotnet/sdk:5.0",
    OnPush = true,
    InvokedTargets = new[] { nameof(Test) })]
[TeamCity(
    Version = "2020.1",
    VcsTriggeredTargets = new[] { nameof(Pack), nameof(Test) },
    NightlyTriggeredTargets = new[] { nameof(Pack), nameof(Test) },
    ManuallyTriggeredTargets = new[] { nameof(Publish) },
    NonEntryTargets = new[] { nameof(Restore), nameof(DownloadFonts), nameof(InstallFonts), nameof(ReleaseImage) },
    ExcludedTargets = new[] { nameof(Clean), nameof(SignPackages) })]
[GitHubActions(
    "continuous",
    GitHubActionsImage.WindowsLatest,
    GitHubActionsImage.UbuntuLatest,
    GitHubActionsImage.MacOsLatest,
    OnPushBranchesIgnore = new[] { MasterBranch, ReleaseBranchPrefix + "/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    PublishArtifacts = false,
    InvokedTargets = new[] { nameof(Test), nameof(Pack) },
    ImportSecrets = new[] { nameof(CodecovToken) })]
[AppVeyor(
    AppVeyorImage.VisualStudio2019,
    AppVeyorImage.Ubuntu1804,
    AutoGenerate = false,
    SkipTags = true,
    InvokedTargets = new[] { nameof(Test), nameof(Pack) })]
[AzurePipelines(
    suffix: null,
    AzurePipelinesImage.UbuntuLatest,
    AzurePipelinesImage.WindowsLatest,
    AzurePipelinesImage.MacOsLatest,
    InvokedTargets = new[] { nameof(Test), nameof(Pack) },
    NonEntryTargets = new[] { nameof(Restore), nameof(DownloadFonts), nameof(InstallFonts), nameof(ReleaseImage) },
    ExcludedTargets = new[] { nameof(Clean), nameof(Coverage), nameof(SignPackages) })]
partial class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Pack);

    [CI] readonly TeamCity TeamCity;
    [CI] readonly AzurePipelines AzurePipelines;
    [CI] readonly GitHubActions GitHubActions;

    [Required] [GitVersion(Framework = "netcoreapp3.1", NoFetch = true)] readonly GitVersion GitVersion;
    [Required] [GitRepository] readonly GitRepository GitRepository;
    [Required] [Solution] readonly Solution Solution;

    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath SourceDirectory => RootDirectory / "source";

    const string MasterBranch = "master";
    const string DevelopBranch = "develop";
    const string ReleaseBranchPrefix = "release";
    const string HotfixBranchPrefix = "hotfix";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("*/bin", "*/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(OutputDirectory);
        });

    [Parameter] bool IgnoreFailedSources;

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(_ => _
                .SetProjectFile(Solution)
                .SetIgnoreFailedSources(IgnoreFailedSources));
        });

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Project GlobalToolProject => Solution.GetProject("Nuke.GlobalTool");
    Project MSBuildTasksProject => Solution.GetProject("Nuke.MSBuildTasks");

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(_ => _
                .SetProjectFile(Solution)
                .SetNoRestore(InvokedTargets.Contains(Restore))
                .SetConfiguration(Configuration)
                .SetRepositoryUrl(GitRepository.HttpsUrl)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion));

            var publishConfigurations =
                from project in new[] { GlobalToolProject, MSBuildTasksProject }
                from framework in project.GetTargetFrameworks()
                select new { project, framework };

            DotNetPublish(_ => _
                    .SetNoRestore(InvokedTargets.Contains(Restore))
                    .SetConfiguration(Configuration)
                    .SetRepositoryUrl(GitRepository.HttpsUrl)
                    .SetAssemblyVersion(GitVersion.AssemblySemVer)
                    .SetFileVersion(GitVersion.AssemblySemFileVer)
                    .SetInformationalVersion(GitVersion.InformationalVersion)
                    .CombineWith(publishConfigurations, (_, v) => _
                        .SetProject(v.project)
                        .SetFramework(v.framework)),
                degreeOfParallelism: 10);
        });

    string ChangelogFile => RootDirectory / "CHANGELOG.md";
    AbsolutePath PackageDirectory => OutputDirectory / "packages";
    IReadOnlyCollection<AbsolutePath> PackageFiles => PackageDirectory.GlobFiles("*.nupkg");
    IEnumerable<string> ChangelogSectionNotes => ExtractChangelogSectionNotes(ChangelogFile);

    Target Pack => _ => _
        .DependsOn(Compile)
        .Produces(PackageDirectory / "*.nupkg")
        .Executes(() =>
        {
            DotNetPack(_ => _
                .SetProject(Solution)
                .SetNoBuild(InvokedTargets.Contains(Compile))
                .SetConfiguration(Configuration)
                .SetOutputDirectory(PackageDirectory)
                .SetVersion(GitVersion.NuGetVersionV2)
                .SetPackageReleaseNotes(GetNuGetReleaseNotes(ChangelogFile, GitRepository)));
        });

    [Partition(2)] readonly Partition TestPartition;
    AbsolutePath TestResultDirectory => OutputDirectory / "test-results";
    IEnumerable<Project> TestProjects => TestPartition.GetCurrent(Solution.GetProjects("*.Tests"));

    Target Test => _ => _
        .DependsOn(Compile)
        .Produces(TestResultDirectory / "*.trx")
        .Produces(TestResultDirectory / "*.xml")
        .Partition(() => TestPartition)
        .Executes(() =>
        {
            DotNetTest(_ => _
                .SetConfiguration(Configuration)
                .SetNoBuild(InvokedTargets.Contains(Compile))
                .ResetVerbosity()
                .SetResultsDirectory(TestResultDirectory)
                .When(InvokedTargets.Contains(Coverage) || IsServerBuild, _ => _
                    .EnableCollectCoverage()
                    .SetCoverletOutputFormat(CoverletOutputFormat.cobertura)
                    .SetExcludeByFile("*.Generated.cs")
                    .When(IsServerBuild, _ => _
                        .EnableUseSourceLink()))
                .CombineWith(TestProjects, (_, v) => _
                    .SetProjectFile(v)
                    .SetLogger($"trx;LogFileName={v.Name}.trx")
                    .When(InvokedTargets.Contains(Coverage) || IsServerBuild, _ => _
                        .SetCoverletOutput(TestResultDirectory / $"{v.Name}.xml"))));

            TestResultDirectory.GlobFiles("*.trx").ForEach(x =>
                AzurePipelines?.PublishTestResults(
                    type: AzurePipelinesTestResultsType.VSTest,
                    title: $"{Path.GetFileNameWithoutExtension(x)} ({AzurePipelines.StageDisplayName})",
                    files: new string[] { x }));
        });

    string CoverageReportDirectory => OutputDirectory / "coverage-report";
    string CoverageReportArchive => OutputDirectory / "coverage-report.zip";
    bool PublishCodecov => GitHubActions != null && !GitRepository.IsOnMasterBranch();
    [Parameter] readonly string CodecovToken;

    Target Coverage => _ => _
        .DependsOn(Test)
        .TriggeredBy(Test)
        .Consumes(Test)
        .Produces(CoverageReportArchive)
        .Requires(() => !PublishCodecov || CodecovToken != null)
        .Executes(() =>
        {
            if (PublishCodecov)
            {
                Codecov(_ => _
                    .SetFiles(TestResultDirectory.GlobFiles("*.xml").Select(x => x.ToString()))
                    .SetToken(CodecovToken)
                    .SetBranch(GitRepository.Branch)
                    .SetSha(GitRepository.Commit)
                    .SetBuild(GitVersion.FullSemVer)
                    .SetFramework("netcoreapp3.0"));
            }

            ReportGenerator(_ => _
                .SetReports(TestResultDirectory / "*.xml")
                .SetReportTypes(ReportTypes.HtmlInline)
                .SetTargetDirectory(CoverageReportDirectory)
                .SetFramework("netcoreapp2.1"));

            TestResultDirectory.GlobFiles("*.xml").ForEach(x =>
                AzurePipelines?.PublishCodeCoverage(
                    AzurePipelinesCodeCoverageToolType.Cobertura,
                    x,
                    CoverageReportDirectory));

            CompressZip(
                directory: CoverageReportDirectory,
                archiveFile: CoverageReportArchive,
                fileMode: FileMode.Create);
        });

    Target Analysis => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            ReSharperInspectCode(_ => _
                .SetTargetPath(Solution)
                .SetOutput(OutputDirectory / "inspectCode.xml")
                .When(RootDirectory.Contains(DotNetPath), _ => _
                    .SetDotNetCore(DotNetPath))
                .AddPlugin("ReSharperPlugin.CognitiveComplexity", ReSharperPluginLatest));
        });

    [Parameter] readonly string NuGetApiKey;
    bool IsOriginalRepository => GitRepository.Identifier == "nuke-build/nuke";

    string NuGetPackageSource => "https://api.nuget.org/v3/index.json";
    string GitHubPackageSource => $"https://nuget.pkg.github.com/{GitHubActions.GitHubRepositoryOwner}/index.json";
    string Source => IsOriginalRepository ? NuGetPackageSource : GitHubPackageSource;

    Target Publish => _ => _
        .ProceedAfterFailure()
        .DependsOn(Clean, Test, Pack)
        .Consumes(Pack)
        .Requires(() => !NuGetApiKey.IsNullOrEmpty() || !IsOriginalRepository)
        .Requires(() => GitHasCleanWorkingCopy())
        .Requires(() => Configuration.Equals(Configuration.Release))
        .Requires(() => IsOriginalRepository && GitRepository.IsOnMasterBranch() ||
                        IsOriginalRepository && GitRepository.IsOnReleaseBranch() ||
                        !IsOriginalRepository && GitRepository.IsOnDevelopBranch())
        .Executes(() =>
        {
            if (!IsOriginalRepository)
            {
                DotNetNuGetAddSource(_ => _
                    .SetSource(GitHubPackageSource)
                    .SetUsername(GitHubActions.GitHubActor)
                    .SetPassword(GitHubToken));
            }

            Assert(PackageFiles.Count == 4, "packages.Count == 4");

            DotNetNuGetPush(_ => _
                    .SetSource(Source)
                    .SetApiKey(NuGetApiKey)
                    .CombineWith(PackageFiles, (_, v) => _
                        .SetTargetPath(v)),
                degreeOfParallelism: 5,
                completeOnFailure: true);
        });

    Target Install => _ => _
        .DependsOn(Pack)
        .Executes(() =>
        {
            SuppressErrors(() => DotNet($"tool uninstall -g {GlobalToolProject.Name}"));
            DotNet($"tool install -g {GlobalToolProject.Name} --add-source {OutputDirectory} --version {GitVersion.NuGetVersionV2}");
        });
}
