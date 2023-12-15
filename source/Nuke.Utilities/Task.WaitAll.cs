// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities;

[PublicAPI]
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static partial class TaskExtensions
{
    public static void WaitAll(this IEnumerable<Task> tasks)
    {
        var tasksArray = tasks.ToArray();
        Task.WaitAll(tasksArray);
    }

    public static IReadOnlyCollection<T> WaitAll<T>(this IEnumerable<Task<T>> tasks)
    {
        var tasksArray = tasks.ToArray();
        Task.WaitAll(tasksArray);
        return tasksArray.Select(x => x.Result).ToList();
    }
}
