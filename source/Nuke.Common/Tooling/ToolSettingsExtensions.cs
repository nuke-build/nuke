// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class ToolSettingsExtensions
    {
        public static T When<T>(this T settings, bool condition, Configure<T> configurator)
            where T : ToolSettings
        {
            return condition ? configurator(settings) : settings;
        }
        
        public static T[] CombineWith<T>(this T toolSettings, params Configure<T>[] configurators)
            where T : ToolSettings
        {
            return configurators.Select(x => x(toolSettings)).ToArray();
        }
        
        public static T[] CombineWith<T>(this T toolSettings, params CombinatorialConfigure<T>[] configurators)
            where T : ToolSettings
        {
            return configurators.SelectMany(x => x(toolSettings)).ToArray();
        }
        
        public static T[] CombineWith<T>(this IEnumerable<T> toolSettings, params Configure<T>[] configurators)
            where T : ToolSettings
        {
            return configurators.SelectMany(x => toolSettings.Select(y => x(y))).ToArray();
        }
        
        public static T[] CombineWith<T>(this IEnumerable<T> toolSettings, params CombinatorialConfigure<T>[] configurators)
            where T : ToolSettings
        {
            return configurators.SelectMany(x => toolSettings.SelectMany(y => x(y))).ToArray();
        }
        
        public static T[] CombineWith<T, TValue>(this T toolSettings, Func<T, TValue, T> configurator, params TValue[] values)
            where T : ToolSettings
        {
            return values.Select(x => configurator(toolSettings, x)).ToArray();
        }
        
        public static T[] CombineWith<T, TValue>(this T toolSettings, Func<T, TValue, T> configurator, IEnumerable<TValue> values)
            where T : ToolSettings
        {
            return values.Select(x => configurator(toolSettings, x)).ToArray();
        }
        
        public static T[] CombineWith<T, TValue>(this IEnumerable<T> toolSettings, Func<T, TValue, T> configurator, params TValue[] values)
            where T : ToolSettings
        {
            return toolSettings.SelectMany(x => values.Select(y => configurator(x, y))).ToArray();
        }
        
        public static T[] CombineWith<T, TValue>(this IEnumerable<T> toolSettings, Func<T, TValue, T> configurator, IEnumerable<TValue> values)
            where T : ToolSettings
        {
            return toolSettings.SelectMany(x => values.Select(y => configurator(x, y))).ToArray();
        }
        
        public static T[] CombineWith<T, TValue>(this T toolSettings, Func<T, TValue, IEnumerable<T>> configurator, params TValue[] values)
            where T : ToolSettings
        {
            return values.SelectMany(x => configurator(toolSettings, x)).ToArray();
        }
        public static T[] CombineWith<T, TValue>(this T toolSettings, Func<T, TValue, IEnumerable<T>> configurator, IEnumerable<TValue> values)
            where T : ToolSettings
        {
            return values.SelectMany(x => configurator(toolSettings, x)).ToArray();
        }
        
        public static T[] CombineWith<T, TValue>(this IEnumerable<T> toolSettings, Func<T, TValue, IEnumerable<T>> configurator, params TValue[] values)
            where T : ToolSettings
        {
            return toolSettings.SelectMany(x => values.SelectMany(y => configurator(x, y))).ToArray();
        }
        
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
