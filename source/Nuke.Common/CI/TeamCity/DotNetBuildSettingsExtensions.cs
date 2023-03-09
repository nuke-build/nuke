// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    public static class DotNetBuildSettingsExtensions
    {
        public static DotNetBuildSettings AddTeamCityLogger(this DotNetBuildSettings toolSettings)
        {
            Assert.True(TeamCity.Instance != null);
            var teamcityPackage = NuGetPackageResolver
                .GetLocalInstalledPackage("TeamCity.Dotnet.Integration", NuGetToolPathResolver.NuGetPackagesConfigFile)
                .NotNull("teamcityPackage != null");
            var loggerAssembly = teamcityPackage.Directory / "build" / "_common" / "msbuild15" / "TeamCity.MSBuild.Logger.dll";
            Assert.FileExists(loggerAssembly);
            return toolSettings
                .AddLoggers($"TeamCity.MSBuild.Logger.TeamCityMSBuildLogger,{loggerAssembly};teamcity")
                .EnableNoConsoleLogger();
        }
    }
}
