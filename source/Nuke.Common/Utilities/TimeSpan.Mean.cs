// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class TimeSpanExtensions
    {
        [Pure]
        public static TimeSpan Mean(this IEnumerable<TimeSpan> source)
        {
            return TimeSpan.FromTicks(source.Aggregate((m: 0L, r: 0L, n: source.Count()), (tm, s) =>
            {
                var r = tm.r + s.Ticks % tm.n;
                return (tm.m + s.Ticks / tm.n + r / tm.n, r % tm.n, tm.n);
            }).m);
        }
    }
}
