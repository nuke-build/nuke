using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;                                                                          // GIT
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;                                                                 // DOTNET
using Nuke.Common.Tools.GitVersion;                                                             // GITVERSION
using Nuke.Common.Tools.MSBuild;                                                                // MSBUILD
using Nuke.Common.Tools.NuGet;                                                                  // NUGET && MSBUILD
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.ChangeLog.ChangelogTasks;                                              // CHANGELOG
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;                                              // DOTNET
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;                                            // MSBUILD
using static Nuke.Common.Tools.NuGet.NuGetTasks;                                                // NUGET && MSBUILD

[CheckBuildProjectConfigurations]                                                               // SOLUTION_FILE
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Source to push NuGet packages")]                                                // NUGET
    readonly string Source = "https://api.nuget.org/v3/index.json";                             // NUGET
    [Parameter("API endpoint to push NuGet source packages")]                                   // NUGET
    readonly string SymbolSource = "https://nuget.smbsrc.net/";                                 // NUGET
    [Parameter("API key for pushing NuGet packages")]                                           // NUGET
    readonly string ApiKey;                                                                     // NUGET

    [Solution] readonly Solution Solution;                                                      // SOLUTION_FILE
    [GitRepository] readonly GitRepository GitRepository;                                       // GIT
    [GitVersion] readonly GitVersion GitVersion;                                                // GITVERSION

    AbsolutePath SourceDirectory => RootDirectory / "source";                                   // SOURCE_DIR
    AbsolutePath SourceDirectory => RootDirectory / "src";                                      // SRC_DIR
    AbsolutePath TestsDirectory => RootDirectory / "tests";                                     // TESTS_DIR
    AbsolutePath OutputDirectory => RootDirectory / "output";                                   // OUTPUT_DIR
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";                             // ARTIFACTS_DIR

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);       // SOURCE_DIR || SRC_DIR
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);        // TESTS_DIR
            EnsureCleanDirectory(OutputDirectory);                                              // OUTPUT_DIR
            EnsureCleanDirectory(ArtifactsDirectory);                                           // ARTIFACTS_DIR
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            MSBuild(s => s                                                                      // MSBUILD
                .SetTargetPath(Solution)                                                        // MSBUILD
                .SetTargets("Restore"));                                                        // MSBUILD
            DotNetRestore(s => s                                                                // DOTNET
                .SetProjectFile(Solution));                                                     // DOTNET
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            MSBuild(s => s                                                                      // MSBUILD
                .SetTargetPath(Solution)                                                        // MSBUILD
                .SetTargets("Rebuild")                                                          // MSBUILD
                .SetConfiguration(Configuration)                                                // MSBUILD
                .SetAssemblyVersion(GitVersion.AssemblySemVer)                                  // MSBUILD && GITVERSION
                .SetFileVersion(GitVersion.AssemblySemFileVer)                                  // MSBUILD && GITVERSION
                .SetInformationalVersion(GitVersion.InformationalVersion)                       // MSBUILD && GITVERSION
                .SetMaxCpuCount(Environment.ProcessorCount)                                     // MSBUILD
                .SetNodeReuse(IsLocalBuild));                                                   // MSBUILD
            DotNetBuild(s => s                                                                  // DOTNET
                .SetProjectFile(Solution)                                                       // DOTNET
                .SetConfiguration(Configuration)                                                // DOTNET
                .SetAssemblyVersion(GitVersion.AssemblySemVer)                                  // DOTNET && GITVERSION
                .SetFileVersion(GitVersion.AssemblySemFileVer)                                  // DOTNET && GITVERSION
                .SetInformationalVersion(GitVersion.InformationalVersion)                       // DOTNET && GITVERSION
                .EnableNoRestore());                                                            // DOTNET
        });

    string ChangelogFile => RootDirectory / "CHANGELOG.md";                                     // CHANGELOG

    Target Pack => _ => _                                                                       // NUGET
        .DependsOn(Compile)                                                                     // NUGET
        .Executes(() =>                                                                         // NUGET
        {                                                                                       // NUGET
            MSBuild(s => s                                                                      // NUGET && MSBUILD
                .SetTargetPath(Solution)                                                        // NUGET && MSBUILD
                .SetTargets("Restore", "Pack")                                                  // NUGET && MSBUILD
                .SetPackageVersion(GitVersion.NuGetVersionV2)                                   // NUGET && MSBUILD && GITVERSION
                .SetPackageReleaseNotes(GetNuGetReleaseNotes(ChangelogFile, GitRepository))     // NUGET && MSBUILD && CHANGELOG && GIT
                .SetPackageOutputPath(ArtifactsDirectory)                                       // NUGET && MSBUILD && ARTIFACTS_DIR
                .SetPackageOutputPath(OutputDirectory)                                          // NUGET && MSBUILD && OUTPUT_DIR
                .SetConfiguration(Configuration)                                                // NUGET && MSBUILD
                .EnableIncludeSymbols()                                                         // NUGET && MSBUILD
                .SetSymbolPackageFormat(NuGetSymbolPackageFormat.snupkg));                      // NUGET && MSBUILD
            DotNetPack(s => s                                                                   // NUGET && DOTNET
                .SetProject(Solution)                                                           // NUGET && DOTNET
                .SetVersion(GitVersion.NuGetVersionV2)                                          // NUGET && DOTNET && GITVERSION
                .SetPackageReleaseNotes(GetNuGetReleaseNotes(ChangelogFile, GitRepository))     // NUGET && DOTNET && CHANGELOG && GIT
                .SetOutputDirectory(ArtifactsDirectory)                                         // NUGET && DOTNET && ARTIFACTS_DIR
                .SetOutputDirectory(OutputDirectory)                                            // NUGET && DOTNET && OUTPUT_DIR
                .SetConfiguration(Configuration)                                                // NUGET && DOTNET
                .EnableNoBuild()                                                                // NUGET && DOTNET
                .EnableIncludeSymbols()                                                         // NUGET && DOTNET
                .SetSymbolPackageFormat(DotNetSymbolPackageFormat.snupkg));                     // NUGET && DOTNET
        });                                                                                     // NUGET
                                                                                                // NUGET
    Target Push => _ => _                                                                       // NUGET
        .DependsOn(Pack)                                                                        // NUGET
        .Requires(() => ApiKey)                                                                 // NUGET
        .Requires(() => Configuration.Equals(Configuration.Release))                            // NUGET
        .Executes(() =>                                                                         // NUGET
        {                                                                                       // NUGET
            DotNetNuGetPush(s => s                                                              // NUGET && DOTNET
            NuGetPush(s => s                                                                    // NUGET && MSBUILD
                    .SetSource(Source)                                                          // NUGET
                    .SetSymbolSource(SymbolSource)                                              // NUGET
                    .SetApiKey(ApiKey)                                                          // NUGET
                    .CombineWith(                                                               // NUGET
                        OutputDirectory.GlobFiles("*.nupkg"), (cs, v) => cs                     // NUGET && OUTPUT_DIR
                        ArtifactsDirectory.GlobFiles("*.nupkg"), (cs, v) => cs                  // NUGET && ARTIFACTS_DIR
                            .SetTargetPath(v)),                                                 // NUGET
                degreeOfParallelism: 5,                                                         // NUGET
                completeOnFailure: true);                                                       // NUGET
        });                                                                                     // NUGET
}
