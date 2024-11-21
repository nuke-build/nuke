// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Codecov;

partial class CodecovTasks
{
    protected override string GetToolPath(ToolOptions options = null)
    {
        return NuGetToolPathResolver.GetPackageExecutable(
            packageId: PackageId,
            packageExecutable: EnvironmentInfo.Platform switch
            {
                PlatformFamily.Windows => "codecov.exe",
                PlatformFamily.OSX => "codecov-macos",
                PlatformFamily.Linux => "codecov-linux",
                _ => throw new ArgumentOutOfRangeException()
            });
    }
}
