using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    public static partial class DotCoverTasks
    {
        internal static string GetToolPath()
        {
            return ToolPathResolver.GetPackageExecutable(
                "jetbrains.dotcover.dotnetclitool|JetBrains.dotCover.CommandLineTools",
                EnvironmentInfo.IsWin ? "dotCover.exe" : "dotCover.sh|dotCover.exe");
        }
    }

    public partial class DotCoverMergeSettings
    {
        private string GetToolPath()
        {
            return DotCoverTasks.GetToolPath();
        }
    }

    public partial class DotCoverAnalyseSettings
    {
        private string GetToolPath()
        {
            return DotCoverTasks.GetToolPath();
        }
    }

    public partial class DotCoverCoverSettings
    {
        private string GetToolPath()
        {
            return DotCoverTasks.GetToolPath();
        }
    }

    public partial class DotCoverDeleteSettings
    {
        private string GetToolPath()
        {
            return DotCoverTasks.GetToolPath();
        }
    }

    public partial class DotCoverReportSettings
    {
        private string GetToolPath()
        {
            return DotCoverTasks.GetToolPath();
        }
    }

    public partial class DotCoverZipSettings
    {
        private string GetToolPath()
        {
            return DotCoverTasks.GetToolPath();
        }
    }
}
