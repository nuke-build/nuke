// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;

namespace Nuke.Common.Tooling
{
    partial class ToolSettingsExtensions
    {
        public static T Apply<T>(this T settings, Configure<T> configurator)
            where T : ToolSettings
        {
            return configurator(settings);
        }

        public static T[] Apply<T>(this T[] settings, Configure<T> configurator)
            where T : ToolSettings
        {
            return settings.Select(x => configurator(x)).ToArray();
        }
    }
}
