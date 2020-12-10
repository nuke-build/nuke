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
        public static T AddProcessEnvironmentVariable<T>(
            this T toolSettings,
            string environmentVariableKey,
            string environmentVariableValue)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessEnvironmentVariablesInternal.Add(environmentVariableKey, environmentVariableValue);
            return newToolSettings;
        }

        [Pure]
        public static T RemoveProcessEnvironmentVariable<T>(this T toolSettings, string environmentVariableKey)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessEnvironmentVariablesInternal.Remove(environmentVariableKey);
            return newToolSettings;
        }

        [Pure]
        public static T SetProcessEnvironmentVariable<T>(
            this T toolSettings,
            string environmentVariableKey,
            string environmentVariableValue)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessEnvironmentVariablesInternal[environmentVariableKey] = environmentVariableValue;
            return newToolSettings;
        }

        [Pure]
        public static T ClearProcessEnvironmentVariables<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessEnvironmentVariablesInternal.Clear();
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessExecutionTimeout"/> -- <inheritdoc cref="ToolSettings.ProcessExecutionTimeout" /></summary>
        [Pure]
        public static T SetProcessExecutionTimeout<T>(this T toolSettings, [CanBeNull] int? executionTimeout)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessExecutionTimeout = executionTimeout;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessLogOutput"/> -- <inheritdoc cref="ToolSettings.ProcessLogOutput" /></summary>
        [Pure]
        public static T SetProcessLogOutput<T>(this T toolSettings, bool enableOutput)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogOutput = enableOutput;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.ProcessLogOutput"/> -- <inheritdoc cref="ToolSettings.ProcessLogOutput" /></summary>
        [Pure]
        public static T EnableProcessLogOutput<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogOutput = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.ProcessLogOutput"/> -- <inheritdoc cref="ToolSettings.ProcessLogOutput" /></summary>
        [Pure]
        public static T DisableProcessLogOutput<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogOutput = false;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessLogInvocation"/> -- <inheritdoc cref="ToolSettings.ProcessLogInvocation" /></summary>
        [Pure]
        public static T SetProcessLogInvocation<T>(this T toolSettings, bool enableInvocation)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogInvocation = enableInvocation;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.ProcessLogInvocation"/> -- <inheritdoc cref="ToolSettings.ProcessLogInvocation" /></summary>
        [Pure]
        public static T EnableProcessLogInvocation<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogInvocation = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.ProcessLogInvocation"/> -- <inheritdoc cref="ToolSettings.ProcessLogInvocation" /></summary>
        [Pure]
        public static T DisableProcessLogInvocation<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogInvocation = false;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessLogTimestamp"/> -- <inheritdoc cref="ToolSettings.ProcessLogTimestamp" /></summary>
        [Pure]
        public static T SetProcessLogTimestamp<T>(this T toolSettings, bool logTimestamp)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogTimestamp = logTimestamp;
            return newToolSettings;
        }

        ///<summary>Enables <see cref="ToolSettings.ProcessLogTimestamp"/> -- <inheritdoc cref="ToolSettings.ProcessLogTimestamp" /></summary>
        [Pure]
        public static T EnableProcessLogTimestamp<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogTimestamp = true;
            return newToolSettings;
        }

        ///<summary>Disables <see cref="ToolSettings.ProcessLogTimestamp"/> -- <inheritdoc cref="ToolSettings.ProcessLogTimestamp" /></summary>
        [Pure]
        public static T DisableProcessLogTimestamp<T>(this T toolSettings)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogTimestamp = false;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessLogFile"/> -- <inheritdoc cref="ToolSettings.ProcessLogFile" /></summary>
        [Pure]
        public static T SetProcessLogFile<T>(this T toolSettings, string logFile)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessLogFile = logFile;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessToolPath"/> -- <inheritdoc cref="ToolSettings.ProcessToolPath" /></summary>
        [Pure]
        public static T SetProcessToolPath<T>(this T toolSettings, [CanBeNull] string toolPath)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessToolPath = toolPath;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessWorkingDirectory"/> -- <inheritdoc cref="ToolSettings.ProcessWorkingDirectory" /></summary>
        [Pure]
        public static T SetProcessWorkingDirectory<T>(this T toolSettings, [CanBeNull] string workingDirectory)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessWorkingDirectory = workingDirectory;
            return newToolSettings;
        }

        ///<summary>Sets <see cref="ToolSettings.ProcessArgumentConfigurator"/> -- <inheritdoc cref="ToolSettings.ProcessArgumentConfigurator" /></summary>
        [Pure]
        public static T SetProcessArgumentConfigurator<T>(this T toolSettings, [CanBeNull] Func<Arguments, Arguments> argumentConfigurator)
            where T : ToolSettings
        {
            var newToolSettings = toolSettings.NewInstance();
            newToolSettings.ProcessArgumentConfigurator = argumentConfigurator;
            return newToolSettings;
        }
    }
}
