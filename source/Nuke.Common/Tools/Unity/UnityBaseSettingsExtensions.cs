// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Unity
{
    public static partial class UnityBaseSettingsExtensions
    {
        #region LogFile

        /// <summary><p><em>Sets <see cref="UnityBaseSettings.LogFile"/>.</em></p><p>Specify where the Editor or Windows/Linux/OSX standalone log file are written.</p></summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }

        /// <summary><p><em>Resets <see cref="UnityBaseSettings.LogFile"/>.</em></p><p>Specify where the Editor or Windows/Linux/OSX standalone log file are written.</p></summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }

        #endregion

        #region MinimalOutput

        /// <summary><p><em>Sets <see cref="UnityBaseSettings.MinimalOutput"/>.</em></p><p>(experimental) If set to true only warnings and errors will be printed to the output.</p></summary>
        [Pure]
        public static T SetMinimalOutput<T>(this T toolSettings, bool? minimalOutput)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = minimalOutput;
            return toolSettings;
        }

        /// <summary><p><em>Resets <see cref="UnityBaseSettings.MinimalOutput"/>.</em></p><p>(experimental) If set to true only warnings and errors will be printed to the output.</p></summary>
        [Pure]
        public static T ResetMinimalOutput<T>(this T toolSettings)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = null;
            return toolSettings;
        }

        /// <summary><p><em>Enables <see cref="UnityBaseSettings.MinimalOutput"/>.</em></p><p>(experimental) If set to true only warnings and errors will be printed to the output.</p></summary>
        [Pure]
        public static T EnableMinimalOutput<T>(this T toolSettings)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = true;
            return toolSettings;
        }

        /// <summary><p><em>Disables <see cref="UnityBaseSettings.MinimalOutput"/>.</em></p><p>(experimental) If set to true only warnings and errors will be printed to the output.</p></summary>
        [Pure]
        public static T DisableMinimalOutput<T>(this T toolSettings)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = false;
            return toolSettings;
        }

        /// <summary><p><em>Toggles <see cref="UnityBaseSettings.MinimalOutput"/>.</em></p><p>(experimental) If set to true only warnings and errors will be printed to the output.</p></summary>
        [Pure]
        public static T ToggleMinimalOutput<T>(this T toolSettings)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = !toolSettings.MinimalOutput;
            return toolSettings;
        }

        #endregion

        #region StableExitCodes

        /// <summary><p><em>Sets <see cref="UnityBaseSettings.StableExitCodes"/> to a new list.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T SetStableExitCodes<T>(this T toolSettings, params int[] stableExitCodes)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal = stableExitCodes.ToList();
            return toolSettings;
        }

        /// <summary><p><em>Sets <see cref="UnityBaseSettings.StableExitCodes"/> to a new list.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T SetStableExitCodes<T>(this T toolSettings, IEnumerable<int> stableExitCodes)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal = stableExitCodes.ToList();
            return toolSettings;
        }

        /// <summary><p><em>Adds values to <see cref="UnityBaseSettings.StableExitCodes"/>.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T AddStableExitCodes<T>(this T toolSettings, params int[] stableExitCodes)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal.AddRange(stableExitCodes);
            return toolSettings;
        }

        /// <summary><p><em>Adds values to <see cref="UnityBaseSettings.StableExitCodes"/>.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T AddStableExitCodes<T>(this T toolSettings, IEnumerable<int> stableExitCodes)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal.AddRange(stableExitCodes);
            return toolSettings;
        }

        /// <summary><p><em>Clears <see cref="UnityBaseSettings.StableExitCodes"/>.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T ClearStableExitCodes<T>(this T toolSettings)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal.Clear();
            return toolSettings;
        }

        /// <summary><p><em>Removes values from <see cref="UnityBaseSettings.StableExitCodes"/>.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T RemoveStableExitCodes<T>(this T toolSettings, params int[] stableExitCodes)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(stableExitCodes);
            toolSettings.StableExitCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }

        /// <summary><p><em>Removes values from <see cref="UnityBaseSettings.StableExitCodes"/>.</em></p><p>Define exit codes which will not fail the build.</p></summary>
        [Pure]
        public static T RemoveStableExitCodes<T>(this T toolSettings, IEnumerable<int> stableExitCodes)
            where T : UnityBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(stableExitCodes);
            toolSettings.StableExitCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }

        #endregion
    }
}
