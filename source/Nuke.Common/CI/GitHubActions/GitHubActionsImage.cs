// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.GitHubActions
{
    /// <summary>
    /// See <a href="https://help.github.com/en/articles/virtual-environments-for-github-actions#about-virtual-environments">Virtual environments for GitHub Actions</a>
    /// </summary>
    [PublicAPI]
    public enum GitHubActionsImage
    {
        [EnumValue("windows-2022")] WindowsServer2022,
        [EnumValue("windows-2019")] WindowsServer2019,
        [EnumValue("windows-2016")] WindowsServer2016R2,
        [EnumValue("ubuntu-20.04")] Ubuntu2004,
        [EnumValue("ubuntu-18.04")] Ubuntu1804,
        [EnumValue("ubuntu-16.04")] Ubuntu1604,
        [EnumValue("macOS-11")] MacOs11,
        [EnumValue("macOS-10.15")] MacOs1015,
        [EnumValue("macOS-10.14")] MacOs1014,
        [EnumValue("windows-latest")] WindowsLatest,
        [EnumValue("ubuntu-latest")] UbuntuLatest,
        [EnumValue("macOS-latest")] MacOsLatest
    }
}
