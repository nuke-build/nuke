// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Components
{
    public static class ToolSettingsExtensions
    {
        public static TSettings WhenNotNull<TSettings, TObject>(
            this TSettings settings,
            TObject obj,
            Func<TSettings, TObject, TSettings> configurator)
            where TSettings : ToolSettings
        {
            return obj != null ? configurator.Invoke(settings, obj) : settings;
        }

        // public static TSettings[] When<TSettings, TObject>(this TSettings[] settings, Func<TSettings, TObject> obj, Configure<TSettings> configurator)
        //     where TSettings : ToolSettings
        // {
        //     return settings.Select(x => condition(x) ? x.Apply(configurator) : x).ToArray();
        // }
    }
}
