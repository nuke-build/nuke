// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.OpenCover;

[PublicAPI]
public class OpenCoverVerbosityMappingAttribute : VerbosityMappingAttribute
{
    public OpenCoverVerbosityMappingAttribute()
        : base(typeof(OpenCoverVerbosity))
    {
        Quiet = nameof(OpenCoverVerbosity.Off);
        Minimal = nameof(OpenCoverVerbosity.Warn);
        Normal = nameof(OpenCoverVerbosity.Info);
        Verbose = nameof(OpenCoverVerbosity.Verbose);
    }
}

partial class OpenCoverSettingsExtensions
{
    public static OpenCoverSettings SetTargetSettings(this OpenCoverSettings toolSettings, ToolOptions targetSettings)
    {
        return toolSettings
            .SetTargetPath(targetSettings.ProcessToolPath)
            .SetTargetArguments(targetSettings.GetArguments().JoinSpace())
            .SetTargetDirectory(targetSettings.ProcessWorkingDirectory);
    }

    public static OpenCoverSettings ResetTargetSettings(this OpenCoverSettings toolSettings)
    {
        return toolSettings
            .ResetTargetPath()
            .ResetTargetArguments()
            .ResetTargetDirectory();
    }
}
