// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Recursively traverses an object. The starting object is the first of the collection.
        /// </summary>
        public static IEnumerable<T> DescendantsAndSelf<T>(
            this T obj,
            Func<T, T> selector,
            [CanBeNull] Func<T, bool> traverse = null)
        {
            yield return obj;

            foreach (var p in obj.Descendants(selector, traverse))
                yield return p;
        }

        /// <summary>
        /// Recursively traverses an object. The starting object is not part of the collection.
        /// </summary>
        public static IEnumerable<T> Descendants<T>(
            this T obj,
            Func<T, T> selector,
            [CanBeNull] Func<T, bool> traverse = null)
        {
            if (traverse != null && !traverse(obj))
                yield break;

            var next = selector(obj);
            if (traverse == null && Equals(next, default(T)))
                yield break;

            foreach (var nextOrDescendant in next.DescendantsAndSelf(selector, traverse))
                yield return nextOrDescendant;
        }

        /// <summary>
        /// Recursively traverses an object. The starting object is the first of the collection.
        /// </summary>
        public static IEnumerable<T> DescendantsAndSelf<T>(
            this T obj,
            Func<T, IEnumerable<T>> selector,
            [CanBeNull] Func<T, bool> traverse = null)
        {
            yield return obj;

            foreach (var p in Descendants(obj, selector, traverse))
                yield return p;
        }

        /// <summary>
        /// Recursively traverses an object. The starting object is not part of the collection.
        /// </summary>
        public static IEnumerable<T> Descendants<T>(
            this T obj,
            Func<T, IEnumerable<T>> selector,
            [CanBeNull] Func<T, bool> traverse = null)
        {
            foreach (var child in selector(obj).Where(x => traverse == null || traverse(x)))
            foreach (var childOrDescendant in child.DescendantsAndSelf(selector, traverse))
                yield return childOrDescendant;
        }
    }
}
