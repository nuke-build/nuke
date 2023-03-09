// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tools.MSBuild;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    public static class MSBuildSettingsExtensions
    {
        public static MSBuildSettings AddTeamCityLogger(this MSBuildSettings toolSettings)
        {
            var teamCity = TeamCity.Instance.NotNull("TeamCity.Instance != null");
            var teamCityLogger = teamCity.ConfigurationProperties["teamcity.dotnet.msbuild.extensions4.0"];
            return toolSettings
                .AddLoggers($"JetBrains.BuildServer.MSBuildLoggers.MSBuildLogger,{teamCityLogger}")
                .EnableNoConsoleLogger();
        }
    }
}
