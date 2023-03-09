// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.AzurePipelines
{
    /// <summary>
    /// See <a href="https://docs.microsoft.com/en-us/azure/devops/pipelines/agents/hosted">Microsoft-hosted agents</a>
    /// </summary>
    [PublicAPI]
    public enum AzurePipelinesImage
    {
        [EnumValue("windows-latest")] WindowsLatest,
        [EnumValue("windows-2022")] Windows2022,
        [EnumValue("windows-2019")] Windows2019,
        [EnumValue("vs2017-win2016")] Vs2017Win2016,
        [EnumValue("ubuntu-latest")] UbuntuLatest,
        [EnumValue("ubuntu-20.04")] Ubuntu2004,
        [EnumValue("ubuntu-18.04")] Ubuntu1804,
        [EnumValue("ubuntu-16.04")] Ubuntu1604,
        [EnumValue("macOS-latest")] MacOsLatest,
        [EnumValue("macOS-11")] MacOs11,
        [EnumValue("macOS-10.15")] MacOs1015,
        [EnumValue("macOS-10.14")] MacOs1014
    }
}
