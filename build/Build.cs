// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Packaging;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Components;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

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
    public static int Main() => Execute<Build>(x => ((IPack)x).Pack);

    [CI] readonly TeamCity TeamCity;
    [CI] readonly AzurePipelines AzurePipelines;
    [CI] readonly AppVeyor AppVeyor;
    [CI] readonly GitHubActions GitHubActions;

    GitVersion GitVersion => From<IHazGitVersion>().Versioning;
    GitRepository GitRepository => From<IHazGitRepository>().GitRepository;

    [Solution(GenerateProjects = true)] readonly Solution Solution;
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
            SourceDirectory.GlobDirectories("*/bin", "*/obj").DeleteDirectories();
            OutputDirectory.CreateOrCleanDirectory();
        });

    Configure<DotNetBuildSettings> ICompile.CompileSettings => _ => _
        .When(!ScheduledTargets.Contains(((IPublish)this).Publish) && !ScheduledTargets.Contains(Install), _ => _
            .ClearProperties());

    Configure<DotNetPublishSettings> ICompile.PublishSettings => _ => _
        .When(!ScheduledTargets.Contains(((IPublish)this).Publish) && !ScheduledTargets.Contains(Install), _ => _
            .ClearProperties());

    IEnumerable<(Nuke.Common.ProjectModel.Project Project, string Framework)> ICompile.PublishConfigurations =>
        from project in new[] { Solution.Nuke_GlobalTool, Solution.Nuke_MSBuildTasks }
        from framework in project.GetTargetFrameworks()
        select (project, framework);

    IEnumerable<Nuke.Common.ProjectModel.Project> ITest.TestProjects => Partition.GetCurrent(Solution.GetProjects("*.Tests"));

    [Parameter]
    public int TestDegreeOfParallelism { get; } = 1;

    Configure<DotNetTestSettings> ITest.TestSettings => _ => _
        .SetProcessEnvironmentVariable("NUKE_TELEMETRY_OPTOUT", bool.TrueString);

    Target ITest.Test => _ => _
        .Inherit<ITest>()
        .Partition(2);

    bool IReportCoverage.CreateCoverageHtmlReport => true;
    bool IReportCoverage.ReportToCodecov => false;

    IEnumerable<(string PackageId, string Version)> IReportIssues.InspectCodePlugins
        => new (string PackageId, string Version)[]
           {
               new("ReSharperPlugin.CognitiveComplexity", ReSharperPluginLatest)
           };

    bool IReportIssues.InspectCodeFailOnWarning => false;
    bool IReportIssues.InspectCodeReportWarnings => true;
    IEnumerable<string> IReportIssues.InspectCodeFailOnIssues => new string[0];
    IEnumerable<string> IReportIssues.InspectCodeFailOnCategories => new string[0];

    Configure<DotNetPackSettings> IPack.PackSettings => _ => _
        .When(Host is Terminal or GitHubActions { Workflow: "ubuntu-latest" }, _ => _
            .SetVersion(DefaultDeploymentVersion));

    string PublicNuGetSource => "https://api.nuget.org/v3/index.json";
    string FeedzNuGetSource => "https://f.feedz.io/nuke/alpha/nuget";
    string DefaultDeploymentVersion => "9999.0.0";

    [Parameter] [Secret] readonly string PublicNuGetApiKey;
    [Parameter] [Secret] readonly string FeedzNuGetApiKey;

    bool IsPublicRelease => GitRepository.IsOnMasterBranch() || GitRepository.IsOnReleaseBranch();
    string IPublish.NuGetSource => IsPublicRelease ? PublicNuGetSource : FeedzNuGetSource;
    string IPublish.NuGetApiKey => IsPublicRelease ? PublicNuGetApiKey : FeedzNuGetApiKey;

    Target IPublish.Publish => _ => _
        .Inherit<IPublish>()
        .Consumes(From<IPack>().Pack)
        .Requires(() => IsPublicRelease && Host is AppVeyor || GitRepository.IsOnDevelopBranch() && Host is GitHubActions && GitHubActions.Workflow == "ubuntu-latest")
        .WhenSkipped(DependencyBehavior.Execute);

    IEnumerable<AbsolutePath> NuGetPackageFiles
        => From<IPack>().PackagesDirectory.GlobFiles("*.nupkg");

    Target DeletePackages => _ => _
        .DependentFor<IPublish>()
        .After<IPack>()
        .OnlyWhenStatic(() => Host is Terminal or GitHubActions { Workflow: "ubuntu-latest", Ref: $"refs/heads/{DevelopBranch}" })
        .Executes(() =>
        {
            if (Host is Terminal)
            {
                var packagesDirectory = NuGetPackageResolver.GetPackagesDirectory(packagesConfigFile: BuildProjectFile);
                var packageDirectories = packagesDirectory.GlobDirectories($"nuke.*/{DefaultDeploymentVersion}");
                packageDirectories.DeleteDirectories();
            }
            else if (Host is GitHubActions)
            {
                void DeletePackage(string id, string version)
                    => DotNet(
                        $"nuget delete {id} {version} --source {FeedzNuGetSource} --api-key {FeedzNuGetApiKey} --non-interactive",
                        logOutput: false);

                var packageIds = NuGetPackageFiles.Select(x => new PackageArchiveReader(x).NuspecReader.GetId());
                foreach (var packageId in packageIds)
                    SuppressErrors(() => DeletePackage(packageId, DefaultDeploymentVersion), logWarning: false);
            }
        });

    Target Install => _ => _
        .DependsOn<IPack>()
        .Executes(() =>
        {
            SuppressErrors(() => DotNet($"tool uninstall -g {Solution.Nuke_GlobalTool.Name}"));
            DotNet($"tool install -g {Solution.Nuke_GlobalTool.Name} --add-source {OutputDirectory} --version {GitVersion.NuGetVersionV2}");
        });

    T From<T>()
        where T : INukeBuild
        => (T)(object)this;
}
