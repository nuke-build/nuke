// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Coverlet
{
    public static partial class CoverletSettingsExtensions
    {
        /// <summary>
        /// <p><em>Sets <see cref="CoverletSettings.Target"/> and <see cref="CoverletSettings.TargetArgs"/> to the values defined by <paramref name="targetSettings"/>.</em></p>
        /// </summary>
        /// <returns></returns>
        [Pure]
        public static CoverletSettings SetTargetSettings(this CoverletSettings toolSettings, ToolSettings targetSettings)
        {
            return toolSettings
                .SetTarget(targetSettings.ProcessToolPath)
                .SetTargetArgs(targetSettings.GetProcessArguments().RenderForExecution());
        }

        /// <summary>
        /// <p><em>Resets <see cref="CoverletSettings.Target"/> and <see cref="CoverletSettings.TargetArgs"/>.</em></p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetTargetSettings(this CoverletSettings toolSettings)
        {
            return toolSettings
                .ResetTarget()
                .ClearTargetArgs();
        }
    }
}
