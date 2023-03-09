// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Unity
{
    public static partial class UnitySettingsExtensions
    {
        #region BuildTarget

        /// <summary><p><em>Sets <see cref="UnitySettings.BuildTarget"/>.</em></p><p>Allows the selection of an active build target before a project is loaded.</p></summary>
        [Pure]
        public static UnitySettings SetBuildTarget(this UnitySettings toolSettings, UnityBuildTarget buildTarget)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildTarget = buildTarget.ToString();
            return toolSettings;
        }

        #endregion
    }
}
