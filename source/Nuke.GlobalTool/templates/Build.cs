using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;                                                                          // GIT
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;                                                                 // DOTNET
using Nuke.Common.Tools.GitVersion;                                                             // GITVERSION
using Nuke.Common.Tools.MSBuild;                                                                // MSBUILD
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;                                              // DOTNET
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;                                            // MSBUILD

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly string Configuration = IsLocalBuild ? "Debug" : "Release";

    [Parameter("Source to push NuGet packages")]                                                // NUGET
    readonly string Source = "https://api.nuget.org/v3/index.json";                             // NUGET
    [Parameter("API endpoint to push NuGet source packages")]                                   // NUGET
    readonly string SymbolSource = "https://nuget.smbsrc.net/";                                 // NUGET
    [Parameter("API key for pushing NuGet packages")]                                           // NUGET
    readonly string ApiKey;                                                                     // NUGET

    [Solution("_SOLUTION_FILE_")] readonly Solution Solution;                                   // SOLUTION_FILE
    [GitRepository] readonly GitRepository GitRepository;                                       // GIT
    [GitVersion] readonly GitVersion GitVersion;                                                // GITVERSION

    AbsolutePath SourceDirectory => RootDirectory / "source";                                   // SOURCE_DIR
    AbsolutePath SourceDirectory => RootDirectory / "src";                                      // SRC_DIR
    AbsolutePath TestsDirectory => RootDirectory / "tests";                                     // TESTS_DIR
    AbsolutePath OutputDirectory => RootDirectory / "output";                                   // OUTPUT_DIR
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";                             // ARTIFACTS_DIR

    Target Clean => _ => _
        .Executes(() =>
        {
            DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));            // SOURCE_DIR
            DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));            // SRC_DIR
            DeleteDirectories(GlobDirectories(TestsDirectory, "**/bin", "**/obj"));             // TESTS_DIR
            EnsureCleanDirectory(OutputDirectory);                                              // OUTPUT_DIR
            EnsureCleanDirectory(ArtifactsDirectory);                                           // ARTIFACTS_DIR
        });

    Target Restore => _ => _
        .DependsOn(Clean)
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
                .SetAssemblyVersion(GitVersion.GetNormalizedAssemblyVersion())                  // MSBUILD && GITVERSION
                .SetFileVersion(GitVersion.GetNormalizedFileVersion())                          // MSBUILD && GITVERSION
                .SetInformationalVersion(GitVersion.InformationalVersion)                       // MSBUILD && GITVERSION
                .SetMaxCpuCount(Environment.ProcessorCount)                                     // MSBUILD
                .SetNodeReuse(IsLocalBuild));                                                   // MSBUILD
            DotNetBuild(s => s                                                                  // DOTNET
                .SetProjectFile(Solution)                                                       // DOTNET
                .SetConfiguration(Configuration)                                                // DOTNET
                .SetAssemblyVersion(GitVersion.GetNormalizedAssemblyVersion())                  // DOTNET && GITVERSION
                .SetFileVersion(GitVersion.GetNormalizedFileVersion())                          // DOTNET && GITVERSION
                .SetInformationalVersion(GitVersion.InformationalVersion)                       // DOTNET && GITVERSION
                .EnableNoRestore());                                                            // DOTNET
        });

    Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            MSBuild(s => s                                                                      // MSBUILD
                .SetTargetPath(Solution)                                                        // MSBUILD
                .SetTargets("Restore", "Pack")                                                  // MSBUILD
                .SetPackageVersion(GitVersion.NuGetVersionV2)                                   // MSBUILD && GITVERSION
                .SetPackageOutputPath(ArtifactsDirectory)                                       // MSBUILD && ARTIFACTS_DIR
                .SetPackageOutputPath(OutputDirectory)                                          // MSBUILD && OUTPUT_DIR
                .SetConfiguration(Configuration)                                                // MSBUILD
                .EnableIncludeSymbols());                                                       // MSBUILD
            DotNetPack(s => s                                                                   // DOTNET
                .SetProject(Solution)                                                           // DOTNET
                .SetVersion(GitVersion.NuGetVersionV2)                                          // DOTNET && GITVERSION
                .SetOutputDirectory(ArtifactsDirectory)                                         // DOTNET && ARTIFACTS_DIR
                .SetOutputDirectory(OutputDirectory)                                            // DOTNET && OUTPUT_DIR
                .SetConfiguration(Configuration)                                                // DOTNET
                .EnableNoBuild()                                                                // DOTNET
                .EnableIncludeSymbols());                                                       // DOTNET
        });
}
