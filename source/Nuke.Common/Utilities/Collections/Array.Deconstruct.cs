// Copyright 2019 Maintainers of NUKE.
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
            t0 = items.ElementAtOrDefault(0);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1)
        {
            t0 = items.ElementAtOrDefault(0);
            t1 = items.ElementAtOrDefault(1);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2)
        {
            t0 = items.ElementAtOrDefault(0);
            t1 = items.ElementAtOrDefault(1);
            t2 = items.ElementAtOrDefault(2);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3)
        {
            t0 = items.ElementAtOrDefault(0);
            t1 = items.ElementAtOrDefault(1);
            t2 = items.ElementAtOrDefault(2);
            t3 = items.ElementAtOrDefault(3);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3, out T t4)
        {
            t0 = items.ElementAtOrDefault(0);
            t1 = items.ElementAtOrDefault(1);
            t2 = items.ElementAtOrDefault(2);
            t3 = items.ElementAtOrDefault(3);
            t4 = items.ElementAtOrDefault(4);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3, out T t4, out T t5)
        {
            t0 = items.ElementAtOrDefault(0);
            t1 = items.ElementAtOrDefault(1);
            t2 = items.ElementAtOrDefault(2);
            t3 = items.ElementAtOrDefault(3);
            t4 = items.ElementAtOrDefault(4);
            t5 = items.ElementAtOrDefault(5);
        }
    }
}
