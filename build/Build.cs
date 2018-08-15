// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.GitHub;
using Nuke.NSwag.Generator;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static Nuke.GitHub.GitHubTasks;
using static RegenerateTasks;
using Release = Octokit.Release;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    const string c_addonRepoOwner = "nuke-build";
    const string c_addonRepoName = "nswag";
    const string c_addonName = "NSwag";
    const string c_toolNamespace = "Nuke.NSwag";

    const string c_regenerationRepoOwner = "RSuter";
    const string c_regenerationRepoName = "NSwag";

    public Build()
    {
        LatestNSwagReleases = new Lazy<IReadOnlyList<Release>>(() =>
            GetReleases(x => x
                    .SetRepositoryName(c_regenerationRepoName)
                    .SetRepositoryOwner(c_regenerationRepoOwner)
                    .SetToken(GitHubApiKey), numberOfReleases: 50)
                .GetAwaiter().GetResult()
                .Where(x => !x.Prerelease)
                .ToArray());
    }

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
    [Solution] readonly Solution Solution;

    [Parameter("Api key to push packages to NuGet.org.")] readonly string NuGetApiKey;
    [Parameter("Api key to access the GitHub.")] readonly string GitHubApiKey;

    readonly Lazy<IReadOnlyList<Release>> LatestNSwagReleases;
    Release LatestNSwagRelease => LatestNSwagReleases.Value[index: 0];
    Project NSwagProject => Solution.GetProject("Nuke.NSwag").NotNull();

    AbsolutePath SpecificationDirectory => NSwagProject.Directory / "specifications";
    string GenerationBaseDirectory => NSwagProject.Directory / "Generated";
    string PackageDirectory => TemporaryDirectory / "packages";
    string ChangelogFile => RootDirectory / "CHANGELOG.md";

    Target Clean => _ => _
        .Executes(() =>
        {
            DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
            EnsureCleanDirectory(OutputDirectory);
        });

    Target CleanGeneratedFiles => _ => _
        .Executes(() =>
        {
            DeleteDirectory(PackageDirectory);
            DeleteDirectory(GenerationBaseDirectory);
            DeleteDirectory(SpecificationDirectory);
        });

    Target DownloadPackages => _ => _
        .DependsOn(CleanGeneratedFiles)
        .Executes(() =>
        {
            NugetPackageLoader.InstallPackage("Nswag.Commands", PackageDirectory, dependencyBehavior: NuGet.Resolver.DependencyBehavior.Highest);
        });

    Target GenerateSpecifications => _ => _
        .DependsOn(DownloadPackages)
        .Executes(() =>
        {
            NSwagSpecificationGenerator.WriteSpecifications(x => x
                .SetGitReference(LatestNSwagReleases.Value[index: 0].TargetCommitish.Substring(startIndex: 0, length: 10))
                .SetOutputFolder(SpecificationDirectory)
                .SetPackageFolder(PackageDirectory));
        });

    Target Generate => _ => _
        .After(GenerateSpecifications)
        .Executes(() =>
        {
            CodeGenerator.GenerateCode(SpecificationDirectory, GenerationBaseDirectory, baseNamespace: "Nuke.NSwag",
                gitRepository: GitRepository.SetBranch("master"));
        });

    Target CompilePlugin => _ => _
        .DependsOn(Generate, Clean)
        .Executes(() =>
        {
            DotNetRestore(x => DefaultDotNetRestore
                .SetProjectFile(NSwagProject));
            DotNetBuild(x => DefaultDotNetBuild
                .SetProjectFile(NSwagProject));
        });

    Target Pack => _ => _
        .DependsOn(CompilePlugin)
        .Executes(() =>
        {
            var releaseNotes = ExtractChangelogSectionNotes(ChangelogFile)
                .Select(x => x.Replace("- ", "\u2022 ").Replace("`", string.Empty).Replace(",", "%2C"))
                .Concat(string.Empty)
                .Concat($"Full changelog at {GitRepository.GetGitHubBrowseUrl(ChangelogFile)}")
                .JoinNewLine();

            DotNetPack(s => DefaultDotNetPack
                .SetProject(NSwagProject)
                .EnableNoBuild()
                .EnableNoRestore()
                .SetVersion(GitVersion.NuGetVersionV2)
                .SetPackageReleaseNotes(releaseNotes));
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .Requires(() => NuGetApiKey)
        .Requires(() => GitHasCleanWorkingCopy())
        .Requires(() => Configuration.EqualsOrdinalIgnoreCase("release"))
        .Requires(() => IsReleaseBranch || IsMasterBranch)
        .Executes(() =>
        {
            GlobFiles(OutputDirectory, "*.nupkg")
                .Where(x => !x.EndsWith(".symbols.nupkg")).NotEmpty()
                .ForEach(x => DotNetNuGetPush(s => s
                    .SetTargetPath(x)
                    .SetSource("https://api.nuget.org/v3/index.json")
                    .SetSymbolSource("https://nuget.smbsrc.net/")
                    .SetApiKey(NuGetApiKey)));
        });

    Target Regenerate => _ => _
        .Requires(() => GitHubApiKey)
        .Requires(() => LatestNSwagRelease != null)
        .DependsOn(CompilePlugin, GenerateSpecifications)
        .OnlyWhen(ShouldRegenerate)
        .WhenSkipped(DependencyBehavior.Skip)
        .Executes(async () =>
        {
            var release = await GetReleaseInformation(LatestNSwagReleases.Value, c_regenerationRepoOwner, c_regenerationRepoName, GitHubApiKey);
            if (release.Version == null)
            {
                Logger.Info($"Build {release.BuildNumber} was not published to nuGet. PR will not be created.");
                return;
            }

            var branch = $"nswag-update-{release.Version}";
            var versionName = $"NSwag v{release.Version}";
            var message = $"Regenerate for {versionName}";
            var commitMessage = new[] { message, $"+semver: {release.Bump.ToString().ToLowerInvariant()}" };
            var prBody = $"Regenerate for [{versionName}](https://github.com/RSuter/NSwag/releases/tag/NSwag-Build-{release.BuildNumber}).";

            CheckoutBranchOrCreateNewFrom(branch, "master");
            UpdateChangeLog(ChangelogFile, release.Version.ToString(), release.BuildNumber);
            AddAndCommitChanges(commitMessage, new[] { NSwagProject.Directory, ChangelogFile }, addUntracked: true);
            Git($"push --force --set-upstream origin {branch}");

            await CreatePullRequest(x => x
                .SetRepositoryName(c_addonRepoName)
                .SetRepositoryOwner(c_addonRepoOwner)
                .SetBase("master")
                .SetHead(branch)
                .SetTitle(message)
                .SetBody(prBody)
                .SetToken(GitHubApiKey));
        });

    Target PrepareRelease => _ => _
        .Before(CompilePlugin)
        .DependsOn(Changelog, Clean)
        .Executes(() =>
        {
            var releaseBranch = IsReleaseBranch ? GitRepository.Branch : $"release/v{GitVersion.MajorMinorPatch}";
            var isMasterBranch = IsMasterBranch;
            var pushMaster = false;
            if (!isMasterBranch && !IsReleaseBranch) Git($"checkout -b {releaseBranch}");

            if (!GitHasCleanWorkingCopy())
            {
                Git($"add {ChangelogFile}");
                Git($"commit -m \"Finalize v{GitVersion.MajorMinorPatch}\"");
                pushMaster = true;
            }

            if (!isMasterBranch)
            {
                Git("checkout master");
                Git($"merge --no-ff --no-edit {releaseBranch}");
                Git($"branch -D {releaseBranch}");
                pushMaster = true;
            }

            if (IsReleaseBranch) Git($"push origin --delete {releaseBranch}");
            if (pushMaster) Git("push origin master");
        });

    Target Release => _ => _
        .Requires(() => GitHubApiKey)
        .DependsOn(Push)
        .After(PrepareRelease)
        .Executes(async () =>
        {
            var releaseNotes = new[]
                               {
                                   $"- [Nuget](https://www.nuget.org/packages/{c_toolNamespace}/{GitVersion.SemVer})",
                                   $"- [Changelog](https://github.com/{c_addonRepoOwner}/{c_addonRepoName}/blob/{GitVersion.SemVer}/CHANGELOG.md)"
                               };

            await PublishRelease(x => x.SetToken(GitHubApiKey)
                .SetArtifactPaths(GlobFiles(OutputDirectory, "*.nupkg").ToArray())
                .SetRepositoryName(c_addonRepoName)
                .SetRepositoryOwner(c_addonRepoOwner)
                .SetCommitSha("master")
                .SetName($"NUKE {c_addonName} Addon v{GitVersion.MajorMinorPatch}")
                .SetTag($"{GitVersion.MajorMinorPatch}")
                .SetReleaseNotes(releaseNotes.Join("\n"))
            );
        });

    Target Changelog => _ => _
        .OnlyWhen(ShouldUpdateChangelog)
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.MajorMinorPatch, GitRepository);
        });

    bool ShouldUpdateChangelog()
    {
        bool TryGetChangelogSectionNotes(string tag, out string[] sectionNotes)
        {
            sectionNotes = new string[0];
            try
            {
                sectionNotes = ExtractChangelogSectionNotes(ChangelogFile, tag).ToArray();
                return sectionNotes.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        var nextSectionAvailable = TryGetChangelogSectionNotes("vNext", out var vNextSection);
        var semVerSectionAvailable = TryGetChangelogSectionNotes(GitVersion.MajorMinorPatch, out var semVerSection);
        if (semVerSectionAvailable)
        {
            ControlFlow.Assert(!nextSectionAvailable, $"{GitVersion.MajorMinorPatch} is already in changelog.");
            return false;
        }

        return nextSectionAvailable;
    }

    bool IsReleaseBranch => GitRepository.Branch.NotNull().StartsWith("release/");

    bool IsMasterBranch => GitRepository.Branch == "master";

    bool ShouldRegenerate() =>
        IsUpdateAvailable(LatestNSwagRelease, c_regenerationRepoOwner, c_regenerationRepoName, SpecificationDirectory / "NSwag.json") || true;
}
