// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.GitHubActions
{
    /// <summary>
    /// See <a href="https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners">Virtual environments for GitHub Actions</a>
    /// </summary>
    [PublicAPI]
    public enum GitHubActionsImage
    {
        [EnumValue("windows-2022")] WindowsServer2022,
        [EnumValue("windows-2019")] WindowsServer2019,
        [EnumValue("ubuntu-22.04")] Ubuntu2204,
        [EnumValue("ubuntu-20.04")] Ubuntu2004,
        [EnumValue("ubuntu-18.04")] Ubuntu1804,
        [EnumValue("macos-12")] MacOs12,
        [EnumValue("macos-11")] MacOs11,
        [EnumValue("macos-10.15")] MacOs1015,
        [EnumValue("windows-latest")] WindowsLatest,
        [EnumValue("ubuntu-latest")] UbuntuLatest,
        [EnumValue("macos-latest")] MacOsLatest
    }
}
