// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;

partial class Build
{
    [UsedImplicitly]
    [RunInDockerContainer("mcr.microsoft.com/dotnet/sdk:6.0", PlatformFamily.Windows)]
    Target RunTargetInWindowsDockerImageTest => _ => _
        .Executes(() =>
        {
            Console.WriteLine("This should be running in a windows docker container");
        });

    [UsedImplicitly]
    [RunInDockerContainer("mcr.microsoft.com/dotnet/sdk:6.0", PlatformFamily.Linux)]
    Target RunTargetInLinuxDockerImageTest => _ => _
        .Executes(() =>
        {
            Console.WriteLine("This should be running in a linux docker container");
        });
}
