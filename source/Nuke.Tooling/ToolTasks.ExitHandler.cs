// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public abstract partial class ToolTasks
{
    internal Func<IProcess, object> GetExitHandlerInternal(ToolOptions options = null)
    {
        return options?.ProcessExitHandling ?? true
            ? GetExitHandler(options)
            : _ => null;
    }

    protected virtual partial Func<IProcess, object> GetExitHandler(ToolOptions options)
    {
        return x => x.AssertZeroExitCode();
    }
}
