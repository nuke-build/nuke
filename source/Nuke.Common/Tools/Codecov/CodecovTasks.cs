// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Codecov;

partial class CodecovSettings
{
    private string GetProcessToolPath()
    {
        return CodecovTasks.GetToolPath();
    }
}

partial class CodecovTasks
{
    internal static string GetToolPath()
    {
        return NuGetToolPathResolver.GetPackageExecutable(
            packageId: "CodecovUploader",
            packageExecutable: GetPackageExecutable());
    }

    private static string GetPackageExecutable()
    {
        return EnvironmentInfo.Platform switch
        {
            PlatformFamily.Windows => "codecov.exe",
            PlatformFamily.OSX => "codecov-macos",
            PlatformFamily.Linux => "codecov-linux",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
