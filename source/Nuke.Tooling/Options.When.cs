// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

partial class OptionsExtensions
{
    public static T When<T>(this T options, Func<T, bool> condition, Configure<T> configurator)
        where T : Options, new()
    {
        return condition.Invoke(options) ? options.Apply(configurator) : options;
    }

    public static T[] When<T>(this T[] options, Func<T, bool> condition, Configure<T> configurator)
        where T : Options, new()
    {
        return options.Select(x => condition(x) ? x.Apply(configurator) : x).ToArray();
    }
}
