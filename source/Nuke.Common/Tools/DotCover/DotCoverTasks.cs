// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverTasks
    {
        internal static string GetToolPath()
        {
            return NuGetToolPathResolver.GetPackageExecutable(
                "JetBrains.dotCover.DotNetCliTool|JetBrains.dotCover.CommandLineTools",
                EnvironmentInfo.IsWin ? "dotCover.exe" : "dotCover.sh|dotCover.exe");
        }
    }
}
