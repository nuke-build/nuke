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
    public static class ProcessSettingsExtensions
    {
        [Pure]
        public static ProcessSettings AddEnvironmentVariable(
            this ProcessSettings processSettings,
            string environmentVariableKey,
            string environmentVariableValue)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.EnvironmentVariablesInternal.Add(environmentVariableKey, environmentVariableValue);
            return newProcessSettings;
        }

        [Pure]
        public static ProcessSettings RemoveEnvironmentVariable(this ProcessSettings processSettings, string environmentVariableKey)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.EnvironmentVariablesInternal.Remove(environmentVariableKey);
            return newProcessSettings;
        }

        [Pure]
        public static ProcessSettings SetEnvironmentVariable(
            this ProcessSettings processSettings,
            string environmentVariableKey,
            string environmentVariableValue)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.EnvironmentVariablesInternal[environmentVariableKey] = environmentVariableValue;
            return newProcessSettings;
        }

        [Pure]
        public static ProcessSettings ClearEnvironmentVariables(this ProcessSettings processSettings)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.EnvironmentVariablesInternal.Clear();
            return newProcessSettings;
        }

        ///<summary>Sets <see cref="ProcessSettings.ExecutionTimeout"/> -- <inheritdoc cref="ProcessSettings.ExecutionTimeout" /></summary>
        [Pure]
        public static ProcessSettings SetExecutionTimeout(this ProcessSettings processSettings, [CanBeNull] int? executionTimeout)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.ExecutionTimeout = executionTimeout;
            return newProcessSettings;
        }

        ///<summary>Sets <see cref="ProcessSettings.RedirectOutput"/> -- <inheritdoc cref="ProcessSettings.RedirectOutput" /></summary>
        [Pure]
        public static ProcessSettings SetRedirectOutput(this ProcessSettings processSettings, bool redirectOutput)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.RedirectOutput = redirectOutput;
            return newProcessSettings;
        }

        ///<summary>Enables <see cref="ProcessSettings.RedirectOutput"/> -- <inheritdoc cref="ProcessSettings.RedirectOutput" /></summary>
        [Pure]
        public static ProcessSettings EnableRedirectOutput(this ProcessSettings processSettings)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.RedirectOutput = true;
            return newProcessSettings;
        }

        ///<summary>Disables <see cref="ProcessSettings.RedirectOutput"/> -- <inheritdoc cref="ProcessSettings.RedirectOutput" /></summary>
        [Pure]
        public static ProcessSettings DisableRedirectOutput(this ProcessSettings processSettings)
        {
            var newProcessSettings = processSettings.NewInstance();
            newProcessSettings.RedirectOutput = false;
            return newProcessSettings;
        }
    }
}
