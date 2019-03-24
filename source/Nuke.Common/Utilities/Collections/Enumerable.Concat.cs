// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "MissingXmlDoc")]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>([CanBeNull] this T obj, IEnumerable<T> enumerable)
        {
            yield return obj;

            foreach (var element in enumerable)
                yield return element;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> enumerable, params T[] others)
        {
            foreach (var element in enumerable)
                yield return element;

            foreach (var element in others)
                yield return element;
        }
    }
}
