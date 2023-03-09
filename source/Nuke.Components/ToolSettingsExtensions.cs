// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Components
{
    public static class ToolSettingsExtensions
    {
        public static T WhenNotNull<T, TObject>(
            this T settings,
            TObject obj,
            Func<T, TObject, T> configurator)
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
