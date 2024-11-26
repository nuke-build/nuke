// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling;

/// <summary>Marks a class as CLI tool wrapper.</summary>
[AttributeUsage(AttributeTargets.Class)]
public abstract class ToolAttribute : Attribute
{
    internal abstract string GetToolPath(ToolOptions options);
}

public abstract partial class ToolTasks
{
    internal string GetToolPathInternal(ToolOptions options = null)
    {
        if (options?.ProcessToolPath != null)
            return options.ProcessToolPath;

        var toolType = GetType();
        var environmentVariable = toolType.Name.TrimEnd("Tasks").ToUpperInvariant() + "_EXE";
        if (ToolPathResolver.TryGetEnvironmentExecutable(environmentVariable) is { } environmentExecutable)
            return environmentExecutable;

        return GetToolPath(options);
    }

    protected virtual partial string GetToolPath(ToolOptions options)
    {
        var toolType = GetType();
        return toolType.GetCustomAttribute<ToolAttribute>().NotNull().GetToolPath(options);
    }
}

public class PathToolAttribute : ToolAttribute
{
    public string Executable { get; set; }

    internal override string GetToolPath(ToolOptions options)
    {
        return ToolPathResolver.GetPathExecutable(Executable);
    }
}

#if NET6_0_OR_GREATER

// TODO OPTIONS: Npm etc.

public class NuGetToolAttribute : ToolAttribute
{
    public string Id { get; set; }
    public string Executable { get; set; }

    internal override string GetToolPath(ToolOptions options)
    {
        var framework = (options as IToolOptionsWithFramework)?.Framework;
        return NuGetToolPathResolver.GetPackageExecutable(Id, Executable, framework: framework);
    }
}

public interface IToolOptionsWithFramework
{
    public string Framework => ((IOptions)this).Get<string>(() => Framework);
}

public static class ToolOptionsWithFrameworkExtensions
{
    [Pure] [Builder(Type = typeof(IToolOptionsWithFramework), Property = nameof(IToolOptionsWithFramework.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : Options, IToolOptionsWithFramework => o.Modify(b => b.Set(() => o.Framework, v));
}

#endif
