// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Utilities
{
    internal static partial class ObjectExtensions
    {
        public static T When<T>(this T obj, bool condition, Func<T, T> action)
        {
            return condition ? action.Invoke(obj) : obj;
        }
    }
}
