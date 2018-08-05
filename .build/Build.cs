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
using Nuke.NSwag.Generator;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.ChangeLog.ChangelogTasks;
using static Nuke.Common.Tools.Git.GitTasks;
using static GitHubTasks;
using static RegenerateTasks;
using Release = Octokit.Release;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    const string c_nSwagRepoOwner = "RSuter";
    const string c_nSwagRepoName = "NSwag";

    public Build()
    {
        LatestNSwagReleases = new Lazy<IReadOnlyList<Release>>(() =>
            GetLatestReleases(c_nSwagRepoOwner, c_nSwagRepoName, numberOfReleases: 2, token: GitHubApiKey));
    }

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
    [Solution] readonly Solution Solution;

    [Parameter("ApiKey for the specified source.")] readonly string ApiKey;
    [Parameter("Indicates that the release is a pre release.")] readonly bool PreRelease;
    [Parameter("Api key to access the github.com api. Must have permissions to create pull-requests.")] readonly string GitHubApiKey;

    readonly Lazy<IReadOnlyList<Release>> LatestNSwagReleases;
    Release LatestNSwagRelease => LatestNSwagReleases.Value[index: 0];
    Project NSwagProject => Solution.GetProject("Nuke.NSwag");

    AbsolutePath SpecificationDirectory => NSwagProject.Directory / "specifications";
    string GenerationBaseDirectory => NSwagProject.Directory / "Generated";
    string PackageDirectory => TemporaryDirectory / "packages";
    string ChangelogFile => RootDirectory / "CHANGELOG.md";

    string Source => PreRelease
        ? "https://www.myget.org/F/nukebuild/api/v2/package"
        : "https://api.nuget.org/v3/index.json";

    string SymbolSource => PreRelease
        ? "https://www.myget.org/F/nukebuild/symbols/api/v2/package"
        : "https://nuget.smbsrc.net";

    Target Clean => _ => _
        .Executes(() =>
        {
            DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
            EnsureCleanDirectory(OutputDirectory);
            DeleteDirectory(PackageDirectory);
        });

    Target DownloadPackages => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            NugetPackageLoader.InstallPackage("Nswag.Commands", PackageDirectory, dependencyBehavior: NuGet.Resolver.DependencyBehavior.Highest);
        });

    Target Generate => _ => _
        .DependsOn(DownloadPackages)
        .Executes(() =>
        {
            DeleteDirectory(GenerationBaseDirectory);
            DeleteDirectory(SpecificationDirectory);

            NSwagSpecificationGenerator.WriteSpecifications(x => x
                .SetGitReference(LatestNSwagReleases.Value[index: 0].TargetCommitish.Substring(startIndex: 0, length: 10))
                .SetOutputFolder(SpecificationDirectory)
                .SetPackageFolder(PackageDirectory));

            CodeGenerator.GenerateCode(SpecificationDirectory, GenerationBaseDirectory, baseNamespace: "Nuke.NSwag",
                gitRepository: GitRepository.SetBranch("master"));
        });

    Target CompilePlugin => _ => _
        .DependsOn(Generate)
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
                .SetPackageReleaseNotes(releaseNotes));
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .Requires(() => ApiKey)
        .Requires(() => GitHasCleanWorkingCopy())
        .Requires(() => !PreRelease || Configuration.EqualsOrdinalIgnoreCase("release"))
        .Requires(() => !PreRelease || GitVersion.BranchName.Equals("master"))
        .Executes(() =>
        {
            GlobFiles(OutputDirectory, "*.nupkg").NotEmpty()
                .Where(f => !f.EndsWith("symbols.nupkg"))
                .ForEach(p => DotNetNuGetPush(c => c
                    .SetSource(Source)
                    .SetSymbolSource(SymbolSource)
                    .SetApiKey(ApiKey)
                    .SetTargetPath(p)));
        });

    Target Regenerate => _ => _
        .Requires(() => GitHubApiKey)
        .Requires(() => LatestNSwagRelease != null)
        .DependsOn(CompilePlugin)
        .OnlyWhen(ShouldRegenerate)
        .WhenSkipped(DependencyBehavior.Skip)
        .Executes(() =>
        {
            var release = GetReleaseInformation(LatestNSwagReleases.Value, c_nSwagRepoOwner, c_nSwagRepoName, GitHubApiKey);
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
            FinalizeChangelog(ChangelogFile, GitVersion.NextSemVer(release.Bump), GitRepository);

            AddAndCommitChanges(commitMessage, new[] { NSwagProject.Directory, ChangelogFile }, addUntracked: true);
            Git($"push --force --set-upstream origin {branch}");
            CreatePullRequestIfNeeded(GitRepository.Identifier, branch, $"{message}", prBody, GitHubApiKey);
        });

    Target Release => _ => _
        .Requires(() => GitHubApiKey)
        .DependsOn(Push)
        .Executes(() =>
        {
            var lastCommitMessage = GitLastCommitMessage();
            var tagAnnotations = lastCommitMessage.Aggregate(string.Empty, (x, y) => $"{x} -m \"{y}\"").Trim();
            var tagName = GitVersion.SemVer;

            Git($"tag -a {tagName} {tagAnnotations}");
            Git($"push origin {tagName}");
            var releaseMessage = new[]
                                 {
                                     "- [Nuget](https://www.nuget.org/packages/Nuke.NSwag/)",
                                     $"- [Changelog](https://github.com/nuke-build/nswag/blob/{tagName}/CHANGELOG.md)"
                                 }.JoinNewLine();
            CreateRelease(GitRepository.Identifier, tagName, GitHubApiKey, $"Nuke.NSwag v{tagName}", releaseMessage, PreRelease);
        });

    Target Changelog => _ => _
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.SemVer, GitRepository);
        });

    bool ShouldRegenerate() => IsUpdateAvailable(LatestNSwagRelease, c_nSwagRepoOwner, c_nSwagRepoName, SpecificationDirectory / "NSwag.json");
}
