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

    const string Source = "https://www.myget.org/F/nuke-plugins/api/v2/package";

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
    [Parameter] readonly string MyGetApiKey;
    [Solution] readonly Solution Solution;
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
        .Requires(() => MyGetApiKey != null,
            () => GitRepository.Branch == "master" || GitRepository.Branch == "develop")
        .OnlyWhen(() => GitRepository.Branch == "master")
        .Executes(() =>
        {
            GlobFiles(OutputDirectory, "*.nupkg").NotEmpty()
                .Where(f => !f.EndsWith("symbols.nupkg"))
                .ForEach(p => DotNetNuGetPush(c => c
                    .SetSource(Source)
                    .SetApiKey(MyGetApiKey)
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
