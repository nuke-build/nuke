// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.DotCover;

partial class DotCoverTasks
{
    protected override string GetToolPath(ToolOptions options = null)
    {
        return NuGetToolPathResolver.GetPackageExecutable(
            PackageId,
            EnvironmentInfo.IsWin ? "dotCover.exe" : "dotCover.sh|dotCover.dll");
    }
}

partial class DotCoverAnalyseSettingsExtensions
{
    public static DotCoverAnalyseSettings SetTargetSettings(this DotCoverAnalyseSettings toolSettings, ToolOptions targetSettings)
    {
        return toolSettings
            .SetTargetExecutable(targetSettings.ProcessToolPath)
            .SetTargetArguments(targetSettings.GetArguments().JoinSpace())
            .SetTargetWorkingDirectory(targetSettings.ProcessWorkingDirectory);
    }

    public static DotCoverAnalyseSettings ResetTargetSettings(this DotCoverAnalyseSettings toolSettings)
    {
        return toolSettings
            .ResetTargetExecutable()
            .ResetTargetArguments()
            .ResetTargetWorkingDirectory();
    }
}

partial class DotCoverCoverSettingsExtensions
{
    public static DotCoverCoverSettings SetTargetSettings(this DotCoverCoverSettings toolSettings, ToolOptions targetSettings)
    {
        return toolSettings
            .SetTargetExecutable(targetSettings.ProcessToolPath)
            .SetTargetArguments(targetSettings.GetArguments().JoinSpace())
            .SetTargetWorkingDirectory(targetSettings.ProcessWorkingDirectory);
    }

    public static DotCoverCoverSettings ResetTargetSettings(this DotCoverCoverSettings toolSettings)
    {
        return toolSettings
            .ResetTargetExecutable()
            .ResetTargetArguments()
            .ResetTargetWorkingDirectory();
    }
}
