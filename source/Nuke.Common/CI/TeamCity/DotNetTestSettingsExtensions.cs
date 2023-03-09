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
    public static class DotNetTestSettingsExtensions
    {
        public static DotNetTestSettings AddTeamCityLogger(this DotNetTestSettings toolSettings)
        {
            Assert.True(TeamCity.Instance != null);
            var teamcityPackage = NuGetPackageResolver
                .GetLocalInstalledPackage("TeamCity.Dotnet.Integration", NuGetToolPathResolver.NuGetPackagesConfigFile)
                .NotNull("teamcityPackage != null");
            var loggerPath = teamcityPackage.Directory / "build" / "_common" / "vstest15";
            Assert.DirectoryExists(loggerPath);
            return toolSettings
                .SetLoggers("teamcity")
                .SetTestAdapterPath(loggerPath);
        }
    }
}
