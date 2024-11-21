// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;

// ReSharper disable ArrangeMethodOrOperatorBody

namespace Nuke.Common.Tooling;

partial class ToolOptionsExtensions
{
    /// <inheritdoc cref="ToolOptions.ProcessLogger"/>
    [Obsolete($"Marked for removal")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessLogger))]
    public static T SetProcessLogger<T>(this T o, Action<OutputType, string> v)
        where T : ToolOptions
    {
        return o.Modify2(b =>
        {
            b.ProcessLogger = v;
        });
    }

    /// <inheritdoc cref="ToolOptions.ProcessExitHandler"/>
    [Obsolete($"Marked for removal")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandler))]
    [System.Diagnostics.Contracts.Pure]
    public static T SetProcessExitHandler<T>(this T o, [CanBeNull] Action<IProcess> exitHandler)
        where T : ToolOptions
    {
        return o.Modify2(b =>
        {
            b.ProcessExitHandler = exitHandler != null
                ? (_, process) =>
                {
                    exitHandler.Invoke(process);
                    return null;
                }
                : null;
        });
    }

    /// <inheritdoc cref="ToolOptions.ProcessExitHandler"/>
    [Obsolete($"Marked for removal")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandler))]
    [System.Diagnostics.Contracts.Pure]
    public static T SetProcessExitHandler<T>(this T o, [CanBeNull] Func<IProcess, object> exitHandler)
        where T : ToolOptions
    {
        return o.Modify2(b =>
        {
            b.ProcessExitHandler = exitHandler != null
                ? (_, process) => exitHandler.Invoke(process)
                : null;
        });
    }

    /// <inheritdoc cref="ToolOptions.ProcessExitHandler"/>
    [Obsolete($"Marked for removal")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandler))]
    [System.Diagnostics.Contracts.Pure]
    public static T SetProcessExitHandler<T>(this T o, [CanBeNull] Action<T, IProcess> exitHandler)
        where T : ToolOptions
    {
        return o.Modify2(b =>
        {
            b.ProcessExitHandler = exitHandler != null
                ? (options, process) =>
                {
                    exitHandler.Invoke((T)options, process);
                    return null;
                }
                : null;
        });
    }

    /// <inheritdoc cref="ToolOptions.ProcessExitHandler"/>
    [Obsolete($"Marked for removal")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandler))]
    [System.Diagnostics.Contracts.Pure]
    public static T SetProcessExitHandler<T>(this T o, [CanBeNull] Func<T, IProcess, object> exitHandler)
        where T : ToolOptions
    {
        return o.Modify2(b =>
        {
            b.ProcessExitHandler = exitHandler != null
                ? (options, process) => exitHandler.Invoke((T)options, process)
                : null;
        });
    }

    /// <inheritdoc cref="ToolOptions.ProcessOutputLogging"/>
    [Obsolete($"Use {nameof(DisableProcessOutputLogging)} instead")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessOutputLogging))]
    public static T DisableProcessLogOutput<T>(this T o)
        where T : ToolOptions => o.DisableProcessOutputLogging();

    /// <inheritdoc cref="ToolOptions.ProcessInvocationLogging"/>
    [Obsolete($"Use {nameof(DisableProcessInvocationLogging)} instead")]
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessInvocationLogging))]
    public static T DisableProcessLogInvocation<T>(this T o)
        where T : ToolOptions => o.DisableProcessInvocationLogging();
}
