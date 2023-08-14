// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Unity;

public static partial class UnityProjectSettingsExtensions
{
    #region BuildTarget

    /// <summary><p><em>Sets <see cref="UnityProjectSettings.BuildTarget"/>.</em></p><p>Allows the selection of an active build target before a project is loaded.</p></summary>
    [Pure]
    public static UnityProjectSettings SetBuildTarget(this UnityProjectSettings toolSettings, UnityBuildTarget buildTarget)
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BuildTarget = buildTarget.ToString();
        return toolSettings;
    }

    #endregion
}
