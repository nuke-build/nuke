// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.AzurePipelines;

/// <summary>
/// See <a href="https://docs.microsoft.com/en-us/azure/devops/pipelines/agents/hosted">Microsoft-hosted agents</a>
/// </summary>
[PublicAPI]
public enum AzurePipelinesImage
{
    [EnumValue("windows-2022")] Windows2022,
    [EnumValue("windows-2019")] Windows2019,
    [EnumValue("ubuntu-22.04")] Ubuntu2204,
    [EnumValue("ubuntu-20.04")] Ubuntu2004,
    [EnumValue("macOS-13")] MacOs13,
    [EnumValue("macOS-12")] MacOs12,
    [EnumValue("macOS-11")] MacOs11,
    [EnumValue("windows-latest")] WindowsLatest,
    [EnumValue("ubuntu-latest")] UbuntuLatest,
    [EnumValue("macOS-latest")] MacOsLatest
}
