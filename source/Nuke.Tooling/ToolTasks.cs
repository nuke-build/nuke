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
    protected internal virtual partial Action<OutputType, string> GetLogger(ToolOptions options = null);

    protected virtual partial string GetToolPath(ToolOptions options = null);
    protected virtual partial IReadOnlyCollection<Output> Run<T>(T options = null) where T : ToolOptions, new();
    protected virtual partial (TResult Result, IReadOnlyCollection<Output> Output) Run<TOptions, TResult>(TOptions options = null) where TOptions : ToolOptions, new();
    protected virtual partial Func<ToolOptions, IProcess, object> GetExitHandler(ToolOptions options = null);

    protected virtual T PreProcess<T>(T options) where T : ToolOptions => options;
    protected virtual void PostProcess(ToolOptions options) { }

    protected virtual object GetResult<T>(ToolOptions options, IReadOnlyCollection<Output> output) => default;
}
