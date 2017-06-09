using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Tools.MSBuild;
using Nuke.Core;
using static Nuke.Common.FileSystem.FileSystemTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Core.EnvironmentInfo;

// ReSharper disable CheckNamespace
class DefaultBuild : GitHubBuild
{
    public static void Main () => Execute<DefaultBuild> (x => x.Compile);

    Target Restore => _ => _
            .Executes (() =>
            {
                if (MSBuildVersion == Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2017)
                    MSBuild (s => DefaultSettings.MSBuildRestore);
                else
                    NuGetRestore (SolutionFile);
            });

    Target Compile => _ => _
            .DependsOn (Restore)
            .Executes (() => MSBuild (s => DefaultSettings.MSBuildCompile
                    .SetMSBuildVersion (MSBuildVersion)));

    MSBuildVersion? MSBuildVersion =>
            !IsUnix
                ? GlobFiles (SolutionDirectory, "*.xproj").Any ()
                    ? Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2015
                    : Nuke.Common.Tools.MSBuild.MSBuildVersion.VS2017
                : default (MSBuildVersion);
}
