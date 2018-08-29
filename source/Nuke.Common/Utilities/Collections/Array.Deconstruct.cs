// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities.Collections
{
    [PublicAPI]
    public static class ArrayExtensions
    {
        public static void Deconstruct<T>(this T[] items, out T t0)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
            t3 = items.Length > 3 ? items[3] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3, out T t4)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
            t3 = items.Length > 3 ? items[3] : default(T);
            t4 = items.Length > 4 ? items[4] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3, out T t4, out T t5)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
            t3 = items.Length > 3 ? items[3] : default(T);
            t4 = items.Length > 4 ? items[4] : default(T);
            t5 = items.Length > 5 ? items[5] : default(T);
        }
    }
}
