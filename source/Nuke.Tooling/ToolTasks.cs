// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling;

[PublicAPI]
public abstract partial class ToolTasks
{
    public static string GetToolPath<T>() where T : ToolTasks, new() => new T().GetToolPathInternal();

    protected internal virtual partial Action<OutputType, string> GetLogger(ToolOptions options = null);

    protected virtual partial string GetToolPath(ToolOptions options = null);
    protected virtual partial Func<IProcess, object> GetExitHandler(ToolOptions options = null);

    protected virtual ToolOptions PreProcess(ToolOptions options) => options;
    protected virtual void PostProcess(ToolOptions options) { }

    protected virtual object GetResult<T>(ToolOptions options, IReadOnlyCollection<Output> output) => default;
}
