// Copyright 2019 Maintainers of NUKE.
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
    public static partial class ToolSettingsExtensions
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

        ///<summary>Sets <see cref="ToolSettings.LogOutput"/> -- <inheritdoc cref="ToolSettings.LogOutput" /></summary>
        [Pure]
        public static T SetLogOutput<T>(this T toolSettings, bool enableOutput)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogOutput = enableOutput;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.LogOutput"/> -- <inheritdoc cref="ToolSettings.LogOutput" /></summary>
        [Pure]
        public static T EnableLogOutput<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogOutput = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.LogOutput"/> -- <inheritdoc cref="ToolSettings.LogOutput" /></summary>
        [Pure]
        public static T DisableLogOutput<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogOutput = false;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.LogInvocation"/> -- <inheritdoc cref="ToolSettings.LogInvocation" /></summary>
        [Pure]
        public static T SetLogInvocation<T>(this T toolSettings, bool enableInvocation)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogInvocation = enableInvocation;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.LogInvocation"/> -- <inheritdoc cref="ToolSettings.LogInvocation" /></summary>
        [Pure]
        public static T EnableLogInvocation<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogInvocation = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.LogInvocation"/> -- <inheritdoc cref="ToolSettings.LogInvocation" /></summary>
        [Pure]
        public static T DisableLogInvocation<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogInvocation = false;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.LogTimestamp"/> -- <inheritdoc cref="ToolSettings.LogTimestamp" /></summary>
        [Pure]
        public static T SetLogTimestamp<T>(this T toolSettings, bool logTimestamp)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogTimestamp = logTimestamp;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.LogTimestamp"/> -- <inheritdoc cref="ToolSettings.LogTimestamp" /></summary>
        [Pure]
        public static T EnableLogTimestamp<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogTimestamp = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.LogTimestamp"/> -- <inheritdoc cref="ToolSettings.LogTimestamp" /></summary>
        [Pure]
        public static T DisableLogTimestamp<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogTimestamp = false;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.LogFile"/> -- <inheritdoc cref="ToolSettings.LogFile" /></summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.LogFile = logFile;
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
