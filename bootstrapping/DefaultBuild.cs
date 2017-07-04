using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Tools.MSBuild;
using Nuke.Core;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Core.EnvironmentInfo;

class DefaultBuild : GitHubBuild
{
    // This is the application entry point for the build.
    // It also defines the default target to execute.
    public static void Main () => Execute<DefaultBuild>(x => x.Compile);

    Target Restore => _ => _
            .Executes(() =>
            {
                // Remove restore tasks as needed. They exist for compatibility.

                DotNetRestore(SolutionDirectory);

                NuGetRestore(SolutionFile);

                if (MSBuildVersion == Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2017)
                    MSBuild(s => DefaultSettings.MSBuildRestore);
            });

    Target Compile => _ => _
            .DependsOn(Restore)
            .Executes(() => MSBuild(s => DefaultSettings.MSBuildCompile
                    .SetMSBuildVersion(MSBuildVersion)));

    // If you have xproj-based projects, you need to downgrade to VS2015.
    MSBuildVersion? MSBuildVersion =>
            !IsUnix
                ? GlobFiles(SolutionDirectory, "*.xproj").Any()
                    ? Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2015
                    : Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2017
                : default(MSBuildVersion?);
}
