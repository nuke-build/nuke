// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Helm
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class HelmToolSettingsExtensions
    {
        /// <summary><p><em>Sets <see cref="HelmToolSettings.CommonSettings"/>.</em></p><p>Common Helm settings like kubecontext, Tiller namespace...</p></summary>
        public static T SetCommonSettings<T>(this T toolSettings, HelmCommonSettings commonSettings)
            where T : HelmToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonSettings = commonSettings;
            return toolSettings;
        }

        /// <summary><p><em>Configures <see cref="HelmToolSettings.CommonSettings"/>.</em></p><p>Common kubernetes settings like kubecontext, Tiller namespace...</p></summary>
        public static T SetCommonSettings<T>(this T toolSettings, Configure<HelmCommonSettings> configure)
            where T : HelmToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonSettings = configure.Invoke(new HelmCommonSettings());
            return toolSettings;
        }

        /// <summary><p><em>Resets <see cref="HelmToolSettings.CommonSettings"/>.</em></p><p>Common kubernetes settings like kubecontext, Tiller namespace...</p></summary>
        public static T ResetCommonSettings<T>(this T toolSettings)
            where T : HelmToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonSettings = null;
            return toolSettings;
        }
    }
}
