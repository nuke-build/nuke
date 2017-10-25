// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    public static partial class DotNetTasks
    {
        //public static MSBuildSettings DefaultMSBuild
        //{
        //    get
        //    {
        //        var toolSettings = new MSBuildSettings ()
        //                .SetWorkingDirectory (NukeBuild.Instance.SolutionDirectory)
        //                .SetSolutionFile (NukeBuild.Instance.SolutionFile)
        //                .SetMaxCpuCount (Environment.ProcessorCount)
        //                .SetConfiguration (NukeBuild.Instance.Configuration);

        //        var teamCityLogger = TeamCity.Instance?.ConfigurationProperties["TEAMCITY_DOTNET_MSBUILD_EXTENSIONS4_0"];
        //        if (teamCityLogger != null)
        //            toolSettings = toolSettings
        //                    .AddLoggers ($"JetBrains.BuildServer.MSBuildLoggers.MSBuildLogger,{teamCityLogger}")
        //                    .EnableNoConsoleLogger ();

        //        return toolSettings;
        //    }
        //}

        public static DotNetRestoreSettings DefaultDotNetRestore => new DotNetRestoreSettings()
                .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
                .SetProjectFile(NukeBuild.Instance.SolutionFile);

        public static DotNetBuildSettings DefaultDotNetBuild => new DotNetBuildSettings()
                .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
                .SetProjectFile(NukeBuild.Instance.SolutionFile)
                .EnableNoRestore()
                .SetConfiguration(NukeBuild.Instance.Configuration)
                .SetAssemblyVersion(GitVersionAttribute.Value?.AssemblySemVer)
                .SetFileVersion(GitVersionAttribute.Value?.FullSemVer)
                .SetInformationalVersion(GitVersionAttribute.Value?.InformationalVersion);

        public static DotNetPackSettings DefaultDotNetPack => new DotNetPackSettings()
                .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
                .SetProject(NukeBuild.Instance.SolutionFile)
                .EnableNoBuild()
                .SetConfiguration(NukeBuild.Instance.Configuration)
                .EnableIncludeSymbols()
                .SetOutputDirectory(NukeBuild.Instance.OutputDirectory)
                .SetVersion(GitVersionAttribute.Value?.NuGetVersionV2);
    }
}
