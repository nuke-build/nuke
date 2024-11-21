// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling;

partial class OptionsExtensions
{
    public static T[] CombineWith<T>(this T options, params Configure<T>[] configurators)
        where T : Options, new()
    {
        return configurators.Select(x => x(options)).ToArray();
    }

    public static T[] CombineWith<T>(this T options, params CombinatorialConfigure<T>[] configurators)
        where T : Options, new()
    {
        return configurators.SelectMany(x => x(options)).ToArray();
    }

    public static T[] CombineWith<T>(this IEnumerable<T> options, params Configure<T>[] configurators)
        where T : Options, new()
    {
        return configurators.SelectMany(x => options.Select(y => x(y))).ToArray();
    }

    public static T[] CombineWith<T>(this IEnumerable<T> options, params CombinatorialConfigure<T>[] configurators)
        where T : Options, new()
    {
        return configurators.SelectMany(x => options.SelectMany(y => x(y))).ToArray();
    }

    public static T[] CombineWith<T, TValue>(this T options, IEnumerable<TValue> values, Func<T, TValue, T> configurator)
        where T : Options
    {
        return values.Select(x => configurator(options, x)).ToArray();
    }

    public static T[] CombineWith<T, TValue>(this IEnumerable<T> options, IEnumerable<TValue> values, Func<T, TValue, T> configurator)
        where T : Options
    {
        return options.SelectMany(x => values.Select(y => configurator(x, y))).ToArray();
    }

    public static T[] CombineWith<T, TValue>(this T options, IEnumerable<TValue> values, Func<T, TValue, IEnumerable<T>> configurator)
        where T : Options
    {
        return values.SelectMany(x => configurator(options, x)).ToArray();
    }

    public static T[] CombineWith<T, TValue>(
        this IEnumerable<T> options,
        IEnumerable<TValue> values,
        // TODO: add delegate type?
        Func<T, TValue, IEnumerable<T>> configurator)
        where T : Options
    {
        return options.SelectMany(x => values.SelectMany(y => configurator(x, y))).ToArray();
    }
}
