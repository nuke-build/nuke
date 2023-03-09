// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Kubernetes
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class KubernetesExecBaseSettingsExtensions
    {
        #region Command

        /// <summary><p><em>Sets <see cref="KubernetesExecBaseSettings.Command"/>.</em></p></summary>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, string command)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }

        /// <summary><p><em>Resets <see cref="KubernetesExecBaseSettings.Command"/>.</em></p></summary>
        [Pure]
        public static T ResetCommand<T>(this T toolSettings)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }

        #endregion

        #region Arguments

        /// <summary><p><em>Sets <see cref="KubernetesExecBaseSettings.Arguments"/> to a new list.</em></p></summary>
        [Pure]
        public static T SetArguments<T>(this T toolSettings, params string[] arguments)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }

        /// <summary><p><em>Sets <see cref="KubernetesExecBaseSettings.Arguments"/> to a new list.</em></p></summary>
        [Pure]
        public static T SetArguments<T>(this T toolSettings, IEnumerable<string> arguments)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }

        /// <summary><p><em>Adds values to <see cref="KubernetesExecBaseSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static T AddArguments<T>(this T toolSettings, params string[] arguments)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }

        /// <summary><p><em>Adds values to <see cref="KubernetesExecBaseSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static T AddArguments<T>(this T toolSettings, IEnumerable<string> arguments)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }

        /// <summary><p><em>Clears <see cref="KubernetesExecBaseSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static T ClearArguments<T>(this T toolSettings)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.Clear();
            return toolSettings;
        }

        /// <summary><p><em>Removes values from <see cref="KubernetesExecBaseSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static T RemoveArguments<T>(this T toolSettings, params string[] arguments)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }

        /// <summary><p><em>Removes values from <see cref="KubernetesExecBaseSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static T RemoveArguments<T>(this T toolSettings, IEnumerable<string> arguments)
            where T : KubernetesExecBaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }

        #endregion
    }
}
