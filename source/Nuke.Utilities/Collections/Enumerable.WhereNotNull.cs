﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Filters the collection to elements that are not <c>null</c>.
    /// </summary>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> enumerable)
        where T : class
    {
        return enumerable.Where(x => x != null);
    }

    /// <summary>
    /// Filters the collection to elements that don't meet the condition.
    /// </summary>
    public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> enumerable, Func<T, bool> condition)
        where T : class
    {
        return enumerable.Where(x => condition == null || !condition(x));
    }
}
