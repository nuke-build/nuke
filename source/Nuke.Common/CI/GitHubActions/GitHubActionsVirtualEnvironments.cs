// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.GitHubActions
{
    [PublicAPI]
    public enum GitHubActionsVirtualEnvironments
    {
        WindowsServer2019,
        WindowsServer2016R2,
        Ubuntu1804,
        Ubuntu1604,
        MacOs1014,
        WindowsLatest,
        UbuntuLatest,
        MacOsLatest
    }

    public static class GitHubActionsVirtualEnvironmentsExtensions
    {
        public static string ConvertToString(this GitHubActionsVirtualEnvironments environment)
        {
            return environment switch
            {
                GitHubActionsVirtualEnvironments.WindowsServer2019 => "windows-2019",
                GitHubActionsVirtualEnvironments.WindowsLatest => "windows-2019",
                GitHubActionsVirtualEnvironments.WindowsServer2016R2 => "windows-2016",
                GitHubActionsVirtualEnvironments.Ubuntu1804 => "ubuntu-18.04",
                GitHubActionsVirtualEnvironments.UbuntuLatest => "ubuntu-18.04",
                GitHubActionsVirtualEnvironments.Ubuntu1604 => "ubuntu-16.04",
                GitHubActionsVirtualEnvironments.MacOs1014 => "macOS-10.14",
                GitHubActionsVirtualEnvironments.MacOsLatest => "macOS-10.14",
                _ => throw new ArgumentOutOfRangeException(nameof(environment), environment, message: null)
            };
        }
    }
}
