using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;
using static Nuke.Core.EnvironmentInfo;

class Build : NukeBuild
{
    // Auto-injection fields:
    //  - [GitVersion] must have 'GitVersion.CommandLine' referenced
    //  - [GitRepository] parses the origin from git config
    //  - [Parameter] retrieves its value from command-line arguments or environment variables
    //
    //[GitVersion] readonly GitVersion GitVersion;
    //[GitRepository] readonly GitRepository GitRepository;
    //[Parameter] readonly string MyGetApiKey;


    // This is the application entry point for the build.
    // It also defines the default target to execute.
    public static int Main () => Execute<Build>(x => x.Compile);


    Target Clean => _ => _
            // Disabled for safety.
            .OnlyWhen(() => false)
            .Executes(() =>
            {
                DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
                EnsureCleanDirectory(OutputDirectory);
            });

    Target Restore => _ => _
            .DependsOn(Clean)
            .Executes(() =>
            {
                DotNetRestore(SolutionDirectory);
            });

    Target Compile => _ => _
            .DependsOn(Restore)
            .Executes(() =>
            {
                DotNetBuild(SolutionDirectory);
            });
}
