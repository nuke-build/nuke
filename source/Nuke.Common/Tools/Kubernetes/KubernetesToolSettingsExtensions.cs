// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Kubernetes
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class KubernetesToolSettingsExtensions
    {
        /// <summary><p><em>Sets <see cref="KubernetesToolSettings.CommonSettings"/>.</em></p><p>Common kubernetes settings like context, user, token...</p></summary>
        public static T SetCommonSettings<T>(this T toolSettings, KubernetesCommonSettings commonSettings)
            where T : KubernetesToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonSettings = commonSettings;
            return toolSettings;
        }

        /// <summary><p><em>Configures <see cref="KubernetesToolSettings.CommonSettings"/>.</em></p><p>Common kubernetes settings like context, user, token...</p></summary>
        public static T SetCommonSettings<T>(this T toolSettings, Configure<KubernetesCommonSettings> configure)
            where T : KubernetesToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonSettings = configure.Invoke(new KubernetesCommonSettings());
            return toolSettings;
        }

        /// <summary><p><em>Resets <see cref="KubernetesToolSettings.CommonSettings"/>.</em></p><p>Common kubernetes settings like context, user, token...</p></summary>
        public static T ResetCommonSettings<T>(this T toolSettings)
            where T : KubernetesToolSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonSettings = null;
            return toolSettings;
        }
    }
}
