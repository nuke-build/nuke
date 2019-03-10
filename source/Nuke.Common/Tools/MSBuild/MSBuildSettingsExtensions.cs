// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.BuildServers;

namespace Nuke.Common.Tools.MSBuild
{
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetSolutionFile(this MSBuildSettings toolSettings, string solutionFile)
        {
            return toolSettings.SetTargetPath(solutionFile);
        }

        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetProjectFile(this MSBuildSettings toolSettings, string projectFile)
        {
            return toolSettings.SetTargetPath(projectFile);
        }

        public static MSBuildSettings AddTeamCityLogger(this MSBuildSettings toolSettings)
        {
            var teamCity = TeamCity.Instance.NotNull("TeamCity.Instance != null");
            var teamCityLogger = teamCity.ConfigurationProperties["TEAMCITY_DOTNET_MSBUILD_EXTENSIONS4_0"];
            return toolSettings
                .AddLoggers($"JetBrains.BuildServer.MSBuildLoggers.MSBuildLogger,{teamCityLogger}")
                .EnableNoConsoleLogger();
        }
    }
}
