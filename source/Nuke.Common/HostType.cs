﻿// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common
{
    public enum HostType
    {
        Console,
        TeamCity,
        AzurePipelines,
        Bamboo,
        Bitrise,
        AppVeyor,
        Jenkins,
        Travis,
        GitLab,
        GitHubActions,
        SpaceAutomation
    }
}
