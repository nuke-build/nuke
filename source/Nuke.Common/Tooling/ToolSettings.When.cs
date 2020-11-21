// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling
{
    partial class ToolSettingsExtensions
    {
        public static T When<T>(this T settings, bool condition, Configure<T> configurator)
            where T : ToolSettings
        {
            return condition ? settings.Apply(configurator) : settings;
        }

        public static T[] When<T>(this T[] settings, Func<T, bool> condition, Configure<T> configurator)
            where T : ToolSettings
        {
            return settings.Select(x => condition(x) ? x.Apply(configurator) : x).ToArray();
        }
    }
}
