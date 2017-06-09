// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities.Collections
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "MissingXmlDoc")]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> Concat<T> ([CanBeNull] this T obj, IEnumerable<T> enumerable)
        {
            yield return obj;

            foreach (var element in enumerable)
                yield return element;
        }

        public static IEnumerable<T> Concat<T> (this IEnumerable<T> enumerable, [CanBeNull] T obj)
        {
            foreach (var element in enumerable)
                yield return element;

            yield return obj;
        }
    }
}
