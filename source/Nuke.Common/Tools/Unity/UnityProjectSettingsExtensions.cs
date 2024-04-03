// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.Unity;

public static partial class UnityProjectSettingsExtensions
{
    #region BuildTarget

    /// <summary><p><em>Sets <see cref="UnityProjectSettings.BuildTarget"/>.</em></p><p>Allows the selection of an active build target before a project is loaded.</p></summary>
    [Pure]
    public static T SetBuildTarget<T>(this T toolSettings, UnityBuildTarget buildTarget)
        where T : UnityProjectSettings
    {
        return toolSettings.SetBuildTarget(buildTarget.ToString());
    }

    #endregion
}
