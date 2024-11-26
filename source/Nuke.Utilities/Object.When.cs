// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Utilities;

partial class ObjectExtensions
{
    public static T When<T>(this T input, bool condition, Func<T, T> transform)
    {
        return condition ? input.Apply(transform) : input;
    }

    public static T WhenNotNull<T, TObject>(this T input, TObject obj, Func<T, TObject, T> transform)
    {
        return obj != null ? transform.Invoke(input, obj) : input;
    }
}
