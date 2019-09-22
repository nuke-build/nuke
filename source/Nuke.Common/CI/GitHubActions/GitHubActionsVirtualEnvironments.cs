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
            switch (environment)
            {
                case GitHubActionsVirtualEnvironments.WindowsServer2019:
                case GitHubActionsVirtualEnvironments.WindowsLatest:
                    return "windows-2019";
                case GitHubActionsVirtualEnvironments.WindowsServer2016R2:
                    return "windows-2016";
                case GitHubActionsVirtualEnvironments.Ubuntu1804:
                case GitHubActionsVirtualEnvironments.UbuntuLatest:
                    return "ubuntu-18.04";
                case GitHubActionsVirtualEnvironments.Ubuntu1604:
                    return "ubuntu-16.04";
                case GitHubActionsVirtualEnvironments.MacOs1014:
                case GitHubActionsVirtualEnvironments.MacOsLatest:
                    return "macOS-10.14";
                default:
                    throw new ArgumentOutOfRangeException(nameof(environment), environment, message: null);
            }
        }
    }
}
