// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Utilities;

partial class ObjectExtensions
{
    public static TOutput Apply<TInput, TOutput>(this TInput input, Func<TInput, TOutput> transform)
    {
        return transform.Invoke(input);
    }
}
