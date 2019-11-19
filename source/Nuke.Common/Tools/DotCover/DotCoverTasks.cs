// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    public static partial class DotCoverTasks
    {
        internal static string GetToolPath()
        {
            return ToolPathResolver.GetPackageExecutable(
                "JetBrains.dotCover.DotNetCliTool|JetBrains.dotCover.CommandLineTools",
                EnvironmentInfo.IsWin ? "dotCover.exe" : "dotCover.sh|dotCover.exe");
        }
    }
}
