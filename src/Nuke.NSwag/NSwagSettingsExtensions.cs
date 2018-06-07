// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using static Nuke.NSwag.NSwagTasks;

namespace Nuke.NSwag
{
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class NSwagSettingsExtensions
    {
        /// <summary><p><em>Sets <see cref="NSwagSettings.NSwagRuntime"/>.</em></p></summary>
        [Pure]
        public static T SetNSwagRuntime<T> (this T toolSettings, string runtime)
                where T : NSwagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NSwagRuntime = runtime;
            return toolSettings;
        }

        /// <summary><p><em>Sets <see cref="NSwagSettings.NSwagRuntime"/>.</em></p></summary>
        [Pure]
        public static T SetNSwagRuntime<T> (this T toolSettings, Runtime runtime)
                where T : NSwagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NSwagRuntime = runtime.ToString();
            return toolSettings;
        }

        /// <summary><p><em>Resets <see cref="NSwagSettings.NSwagRuntime"/>.</em></p></summary>
        [Pure]
        public static T ResetNSwagRuntime<T> (this T toolSettings)
                where T : NSwagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NSwagRuntime = null;
            return toolSettings;
        }
    }
}