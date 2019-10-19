// Copyright 2019 Maintainers of NUKE.
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
        [EnumValue("windows-2019")] Windows2019,
        [EnumValue("vs2017-win2016")] Vs2017Win2016,
        [EnumValue("vs2015-win2012r2")] Vs2015Win2012R2,
        [EnumValue("win1803")] Win1803,
        [EnumValue("ubuntu-16.04")] Ubuntu1604,
        [EnumValue("ubuntu-18.04")] Ubuntu1804,
        [EnumValue("ubuntu-latest")] UbuntuLatest,
        [EnumValue("macOS-latest")] MacOsLatest,
        [EnumValue("macOS-10.14")] MacOs1014,
        [EnumValue("macOS-10.13")] MacOs1013
    }
}
