// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

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
        if (EnvironmentInfo.IsWin)
            return "codecov.exe";
        if (EnvironmentInfo.IsOsx)
            return "codecov-macos";
        return "codecov-linux";
    }
}
