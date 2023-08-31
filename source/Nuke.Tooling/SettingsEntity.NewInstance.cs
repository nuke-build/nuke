// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using System.Text.Json;

namespace Nuke.Common.Tooling;

[PublicAPI]
public static partial class SettingsEntityExtensions
{
    public static T NewInstance<T>(this T settingsEntity)
        where T : ISettingsEntity
    {
        var json = JsonSerializer.Serialize(settingsEntity);
        var newInstance = JsonSerializer.Deserialize<T>(json);

        if (newInstance is ToolSettings toolSettings)
        {
            var originalToolSettings = settingsEntity as ToolSettings;
            toolSettings.ProcessArgumentConfigurator = originalToolSettings.ProcessArgumentConfigurator;
            toolSettings.ProcessLogger = originalToolSettings.ProcessLogger;
            toolSettings.ProcessExitHandler = originalToolSettings.ProcessExitHandler;
        }

        return newInstance;
    }
}
