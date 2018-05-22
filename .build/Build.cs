using System.IO;
using System.Linq;
using NuGet.Resolver;
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

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
    [Solution] readonly Solution Solution;

    [Parameter("ApiKey for the specified source.")]
    readonly string ApiKey;

    [Parameter("Indicates to push to nuget.org feed.")]
    readonly bool NuGet;

    string Source => NuGet
        ? "https://api.nuget.org/v3/index.json"
        : "https://www.myget.org/F/nukebuild/api/v2/package";

    string SymbolSource => NuGet
        ? "https://nuget.smbsrc.net"
        : "https://www.myget.org/F/nukebuild/symbols/api/v2/package";

    string ChangelogFile => RootDirectory / "CHANGELOG.md";

    Project NSwagProject => Solution.GetProject("Nuke.NSwag");
    AbsolutePath NSwagProjectPath => (AbsolutePath) NSwagProject.Directory;
    AbsolutePath PackageDirectory => TemporaryDirectory / "packages";

    Target Clean => _ => _
        .Executes(() =>
        {
            DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
            EnsureCleanDirectory(OutputDirectory);
            File.Delete(NSwagProjectPath / "NSwag.json");
            File.Delete(NSwagProjectPath / "NSwag.Generated.cs");
            DeleteDirectory(PackageDirectory);
        });

    Target DownloadPackages => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            NugetPackageLoader.InstallPackage("Nswag.Commands", TemporaryDirectory / "packages", dependencyBehavior: DependencyBehavior.Highest);
        });

    Target Generate => _ => _
        .DependsOn(DownloadPackages)
        .Executes(() =>
        {
            var settings = new SpecificationGeneratorSettings
                           {
                               PackageFolder = PackageDirectory,
                               OutputFolder = NSwagProjectPath,
                               Version = GitHubCommitHashFetcher.FetchHashForReference("heads/master")
                           };
            SpecificationParser.WriteSpecifications(settings);
            CodeGenerator.GenerateCode(NSwagProjectPath, NSwagProjectPath, baseNamespace: "Nuke.NSwag", gitRepository: GitRepository);
        });

    Target CompilePlugin => _ => _
        .DependsOn(Generate)
        .Executes(() =>
        {
            DotNetRestore(x => DefaultDotNetRestore
                .SetProjectFile(NSwagProject));
            DotNetBuild(x => DefaultDotNetBuild.SetProjectFile(NSwagProject));
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
        .Requires(() => !GitHasUncommitedChanges())
        .Requires(() => !NuGet || GitVersionAttribute.Bump.HasValue)
        .Requires(() => !NuGet || Configuration.EqualsOrdinalIgnoreCase("release"))
        .Requires(() => !NuGet || GitVersion.BranchName.Equals("master"))
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

    Target Changelog => _ => _
        .OnlyWhen(() => InvokedTargets.Contains(nameof(Changelog)))
        .Executes(() =>
        {
            FinalizeChangelog(ChangelogFile, GitVersion.SemVer, GitRepository);

            Git($"add {ChangelogFile}");
            Git($"commit -m \"Finalize {Path.GetFileName(ChangelogFile)} for {GitVersion.SemVer}.\"");
            Git($"tag -f {GitVersion.SemVer}");
        });
}
