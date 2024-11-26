﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.SpaceAutomation;
using Nuke.Components;

[SpaceAutomation(
    name: "continuous",
    image: "mcr.microsoft.com/dotnet/sdk:8.0",
    OnPush = true,
    InvokedTargets = new[] { nameof(ITest.Test) })]
partial class Build
{
}
