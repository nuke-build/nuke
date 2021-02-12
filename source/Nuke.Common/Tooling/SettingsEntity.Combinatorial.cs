// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling
{
    partial class SettingsEntityExtensions
    {
        public static T[] CombineWith<T>(this T settings, params Configure<T>[] configurators)
            where T : ISettingsEntity, new()
        {
            return configurators.Select(x => x(settings)).ToArray();
        }

        public static T[] CombineWith<T>(this T settings, params CombinatorialConfigure<T>[] configurators)
            where T : ISettingsEntity, new()
        {
            return configurators.SelectMany(x => x(settings)).ToArray();
        }

        public static T[] CombineWith<T>(this IEnumerable<T> settings, params Configure<T>[] configurators)
            where T : ISettingsEntity, new()
        {
            return configurators.SelectMany(x => settings.Select(y => x(y))).ToArray();
        }

        public static T[] CombineWith<T>(this IEnumerable<T> settings, params CombinatorialConfigure<T>[] configurators)
            where T : ISettingsEntity, new()
        {
            return configurators.SelectMany(x => settings.SelectMany(y => x(y))).ToArray();
        }

        public static T[] CombineWith<T, TValue>(this T settings, IEnumerable<TValue> values, Func<T, TValue, T> configurator)
            where T : ISettingsEntity
        {
            return values.Select(x => configurator(settings, x)).ToArray();
        }

        public static T[] CombineWith<T, TValue>(this IEnumerable<T> settings, IEnumerable<TValue> values, Func<T, TValue, T> configurator)
            where T : ISettingsEntity
        {
            return settings.SelectMany(x => values.Select(y => configurator(x, y))).ToArray();
        }

        public static T[] CombineWith<T, TValue>(this T settings, IEnumerable<TValue> values, Func<T, TValue, IEnumerable<T>> configurator)
            where T : ISettingsEntity
        {
            return values.SelectMany(x => configurator(settings, x)).ToArray();
        }

        public static T[] CombineWith<T, TValue>(
            this IEnumerable<T> settings,
            IEnumerable<TValue> values,
            // TODO: add delegate type?
            Func<T, TValue, IEnumerable<T>> configurator)
            where T : ISettingsEntity
        {
            return settings.SelectMany(x => values.SelectMany(y => configurator(x, y))).ToArray();
        }
    }
}
