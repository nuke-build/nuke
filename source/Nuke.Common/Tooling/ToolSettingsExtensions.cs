// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class ToolSettingsExtensions
    {
        [Pure]
        public static T AddEnvironmentVariable<T>(
            this T toolSettings,
            string environmentVariableKey,
            string environmentVariableValue)
        where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.EnvironmentVariablesInternal.Add(environmentVariableKey, environmentVariableValue);
            return newToolSettings;
        }

        [Pure]
        public static T RemoveEnvironmentVariable<T>(this T toolSettings, string environmentVariableKey)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.EnvironmentVariablesInternal.Remove(environmentVariableKey);
            return newToolSettings;
        }

        [Pure]
        public static T SetEnvironmentVariable<T>(
            this T toolSettings,
            string environmentVariableKey,
            string environmentVariableValue)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.EnvironmentVariablesInternal[environmentVariableKey] = environmentVariableValue;
            return newToolSettings;
        }

        [Pure]
        public static T ClearEnvironmentVariables<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.EnvironmentVariablesInternal.Clear();
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ExecutionTimeout"/> -- <inheritdoc cref="ToolSettings.ExecutionTimeout" /></summary>
        [Pure]
        public static T SetExecutionTimeout<T>(this T toolSettings, [CanBeNull] int? executionTimeout)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ExecutionTimeout = executionTimeout;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.RedirectOutput"/> -- <inheritdoc cref="ToolSettings.RedirectOutput" /></summary>
        [Pure]
        public static T SetRedirectOutput<T>(this T toolSettings, bool redirectOutput)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.RedirectOutput = redirectOutput;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.RedirectOutput"/> -- <inheritdoc cref="ToolSettings.RedirectOutput" /></summary>
        [Pure]
        public static T EnableRedirectOutput<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.RedirectOutput = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.RedirectOutput"/> -- <inheritdoc cref="ToolSettings.RedirectOutput" /></summary>
        [Pure]
        public static T DisableRedirectOutput<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.RedirectOutput = false;
            return newToolSettings;
        }
        
        ///<summary>Sets <see cref="ToolSettings.ToolPath"/> -- <inheritdoc cref="ToolSettings.ToolPath" /></summary>
        [Pure]
        public static T SetToolPath<T>(this T toolSettings, [CanBeNull] string toolPath)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ToolPath = toolPath;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.WorkingDirectory"/> -- <inheritdoc cref="ToolSettings.WorkingDirectory" /></summary>
        [Pure]
        public static T SetWorkingDirectory<T>(this T toolSettings, [CanBeNull] string workingDirectory)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.WorkingDirectory = workingDirectory;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ArgumentConfigurator"/> -- <inheritdoc cref="ToolSettings.ArgumentConfigurator" /></summary>
        [Pure]
        public static T SetArgumentConfigurator<T>(this T toolSettings, [CanBeNull] Func<Arguments, Arguments> argumentConfigurator)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ArgumentConfigurator = argumentConfigurator;
            return newToolSettings;
        }
    }
}
