// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;

namespace Nuke.Common.Tooling
{
    partial class SettingsEntityExtensions
    {
        public static T Apply<T>(this T settings, Configure<T> configurator)
        {
            return configurator(settings);
        }

        public static T[] Apply<T>(this T[] settings, Configure<T> configurator)
            where T : ISettingsEntity, new()
        {
            return settings.Select(x => configurator(x)).ToArray();
        }

        public static TSettings Apply<TSettings, TValue>(this TSettings settings, Configure<TSettings, TValue> configurator, TValue value)
            where TSettings : ISettingsEntity, new()
        {
            return configurator(settings, value);
        }

        public static TSettings[] Apply<TSettings, TValue>(this TSettings[] settings, Configure<TSettings, TValue> configurator, TValue value)
            where TSettings : ISettingsEntity, new()
        {
            return settings.Select(x => configurator(x, value)).ToArray();
        }
    }
}
