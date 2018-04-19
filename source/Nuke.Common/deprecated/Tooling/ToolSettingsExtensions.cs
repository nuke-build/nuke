#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class ToolSettingsExtensions
    {
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
