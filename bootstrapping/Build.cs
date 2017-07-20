using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.MSBuild;
using Nuke.Core;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;
using static Nuke.Core.EnvironmentInfo;

class Build : NukeBuild
{
    //[GitVersion] readonly GitVersion GitVersion;
    //[GitRepository] readonly GitRepository GitRepository;

    // This is the application entry point for the build.
    // It also defines the default target to execute.
    public static int Main () => Execute<Build>(x => x.Compile);

    Target Clean => _ => _
            // Disabled for safety.
            .OnlyWhen(() => false)
            .Executes(() => DeleteDirectories(GlobDirectories(SolutionDirectory, "**/bin", "**/obj")))
            .Executes(() => EnsureCleanDirectory(OutputDirectory));

    Target Restore => _ => _
            .DependsOn(Clean)
            .Executes(() =>
            {
                // Remove tasks as needed. They exist for compatibility.

                DotNetRestore(SolutionDirectory);

                if (MSBuildVersion == Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2017)
                    MSBuild(s => DefaultSettings.MSBuildRestore);

                NuGetRestore(SolutionFile);
            });

    Target Compile => _ => _
            .DependsOn(Restore)
            .Executes(() => MSBuild(s => DefaultSettings.MSBuildCompile
                    .SetMSBuildVersion(MSBuildVersion)));

    // When having xproj-based projects, using VS2015 is necessary.
    MSBuildVersion? MSBuildVersion =>
            !IsUnix
                ? GlobFiles(SolutionDirectory, "*.xproj").Any()
                    ? Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2015
                    : Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2017
                : default(MSBuildVersion?);
}
