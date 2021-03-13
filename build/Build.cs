// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using Nuke.Components;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

[CheckBuildProjectConfigurations]
[DotNetVerbosityMapping]
[ShutdownDotNetAfterServerBuild]
partial class Build
    : NukeBuild,
        IHazTwitterCredentials,
        IHazChangelog,
        IHazGitRepository,
        IHazGitVersion,
        IHazSolution,
        IRestore,
        ICompile,
        IPack,
        ITest,
        IReportCoverage,
        IReportIssues,
        IReportDuplicates,
        IPublish
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => ((IPack) x).Pack);

    [CI] readonly TeamCity TeamCity;
    [CI] readonly AzurePipelines AzurePipelines;
    [CI] readonly GitHubActions GitHubActions;

    GitVersion GitVersion => From<IHazGitVersion>().Versioning;
    GitRepository GitRepository => From<IHazGitRepository>().GitRepository;

    [Solution(GenerateProjects = true)]  readonly Solution Solution;
    Nuke.Common.ProjectModel.Solution IHazSolution.Solution => Solution;

    IHazTwitterCredentials TwitterCredentials => From<IHazTwitterCredentials>();

    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath SourceDirectory => RootDirectory / "source";

    const string MasterBranch = "master";
    const string DevelopBranch = "develop";
    const string ReleaseBranchPrefix = "release";
    const string HotfixBranchPrefix = "hotfix";

    AbsolutePath IHazArtifacts.ArtifactsDirectory => RootDirectory / "output";

    Target Clean => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("*/bin", "*/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(OutputDirectory);
        });

    IEnumerable<(Project Project, string Framework)> ICompile.PublishConfigurations =>
        from project in new[] { Solution.Nuke_GlobalTool, Solution.Nuke_MSBuildTasks }
        from framework in project.GetTargetFrameworks()
        select (project, framework);

    [Partition(2)] readonly Partition TestPartition;
    IEnumerable<Project> ITest.TestProjects => TestPartition.GetCurrent(Solution.GetProjects("*.Tests"));

    Target ITest.Test => _ => _
        .Inherit<ITest>()
        .Partition(() => TestPartition);

    bool IReportCoverage.CreateCoverageHtmlReport => true;
    bool IReportCoverage.ReportToCodecov => false;

    IEnumerable<(string PackageId, string Version)> IReportIssues.InspectCodePlugins
        => new (string PackageId, string Version)[]
           {
               new("ReSharperPlugin.CognitiveComplexity", ReSharperPluginLatest)
           };

    bool IReportIssues.InspectCodeFailOnWarning => false;
    bool IReportIssues.InspectCodeReportWarnings => true;
    IEnumerable<string> IReportIssues.InspectCodeFailOnIssues => new[] { "CognitiveComplexity" };
    IEnumerable<string> IReportIssues.InspectCodeFailOnCategories => new string[0];

    string PublicNuGetSource => "https://api.nuget.org/v3/index.json";

    string GitHubRegistrySource => GitHubActions != null
        ? $"https://nuget.pkg.github.com/{GitHubActions.GitHubRepositoryOwner}/index.json"
        : null;

    [Parameter] readonly string PublicNuGetApiKey;
    [Parameter] readonly string GitHubRegistryApiKey;

    bool IsOriginalRepository => GitRepository.Identifier == "nuke-build/nuke";
    string IPublish.NuGetApiKey => IsOriginalRepository ? PublicNuGetApiKey : GitHubRegistryApiKey;
    string IPublish.NuGetSource => IsOriginalRepository ? PublicNuGetSource : GitHubRegistrySource;

    Target IPublish.Publish => _ => _
        .Inherit<IPublish>()
        .Consumes(From<IPack>().Pack);
        // .Requires(() => IsOriginalRepository && GitRepository.IsOnMasterBranch() ||
        //                 IsOriginalRepository && GitRepository.IsOnReleaseBranch() ||
        //                 !IsOriginalRepository && GitRepository.IsOnDevelopBranch());

    Target Install => _ => _
        .DependsOn<IPack>()
        .Executes(() =>
        {
            SuppressErrors(() => DotNet($"tool uninstall -g {Solution.Nuke_GlobalTool.Name}"));
            DotNet($"tool install -g {Solution.Nuke_GlobalTool.Name} --add-source {OutputDirectory} --version {GitVersion.NuGetVersionV2}");
        });

    T From<T>()
        where T : INukeBuild
        => (T) (object) this;
}
