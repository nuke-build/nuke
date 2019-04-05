// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling
{
    partial class ToolSettingsExtensions
    {
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

        public static T[] CombineWith<T, TValue>(this T toolSettings, IEnumerable<TValue> values, Func<T, TValue, T> configurator)
            where T : ToolSettings
        {
            return values.Select(x => configurator(toolSettings, x)).ToArray();
        }

        public static T[] CombineWith<T, TValue>(this IEnumerable<T> toolSettings, IEnumerable<TValue> values, Func<T, TValue, T> configurator)
            where T : ToolSettings
        {
            return toolSettings.SelectMany(x => values.Select(y => configurator(x, y))).ToArray();
        }

        public static T[] CombineWith<T, TValue>(this T toolSettings, IEnumerable<TValue> values, Func<T, TValue, IEnumerable<T>> configurator)
            where T : ToolSettings
        {
            return values.SelectMany(x => configurator(toolSettings, x)).ToArray();
        }

        public static T[] CombineWith<T, TValue>(
            this IEnumerable<T> toolSettings,
            IEnumerable<TValue> values,
            Func<T, TValue, IEnumerable<T>> configurator)
            where T : ToolSettings
        {
            return toolSettings.SelectMany(x => values.SelectMany(y => configurator(x, y))).ToArray();
        }
    }
}
