﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
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
            ControlFlow.Assert(TeamCity.Instance != null, "TeamCity.Instance != null");
            var teamcityPackage = NuGetPackageResolver
                .GetLocalInstalledPackage("TeamCity.Dotnet.Integration", ToolPathResolver.NuGetPackagesConfigFile)
                .NotNull("teamcityPackage != null");
            var loggerPath = teamcityPackage.Directory / "build" / "_common" / "vstest15";
            ControlFlow.Assert(Directory.Exists(loggerPath), $"Directory.Exists({loggerPath})");
            return toolSettings
                .SetLogger("teamcity")
                .SetTestAdapterPath(loggerPath);
        }
    }
}
