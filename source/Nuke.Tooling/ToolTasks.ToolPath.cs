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
    internal abstract ToolRequirement GetRequirement(string version = null);
}

public abstract partial class ToolTasks
{
    protected internal string GetToolPathInternal(ToolOptions options = null)
    {
        if (options?.ProcessToolPath != null)
            return options.ProcessToolPath;

        if (ToolPathResolver.TryGetEnvironmentExecutable(ToolPathOverrideVariableName) is { } environmentExecutable)
            return environmentExecutable;

        return GetToolPath(options);
    }

    protected virtual partial string GetToolPath(ToolOptions options)
    {
        var toolType = GetType();
        var attribute = toolType.GetCustomAttribute<ToolAttribute>();
        if (attribute != null)
            return attribute.GetToolPath(options);

        Assert.Fail($"Unable to resolve tool path for {toolType.Name}. Set via {nameof(ToolOptionsExtensions.SetProcessToolPath)}.");
        return null;
    }

    protected void SetToolPath(string path)
    {
        Assert.FileExists(path);
        EnvironmentInfo.SetVariable(ToolPathOverrideVariableName, path);
    }

    private string ToolPathOverrideVariableName
    {
        get
        {
            var toolType = GetType();
            var environmentVariable = toolType.Name.TrimEnd("Tasks").ToUpperInvariant() + "_EXE";
            return environmentVariable;
        }
    }
}

[BaseTypeRequired(typeof(IRequirePathTool))]
public class PathToolAttribute : ToolAttribute
{
    public string Executable { get; set; }

    internal override string GetToolPath(ToolOptions options)
    {
        return ToolPathResolver.GetPathExecutable(Executable);
    }

    internal override ToolRequirement GetRequirement(string version = null)
    {
        return new PathToolRequirement(Executable);
    }
}

[BaseTypeRequired(typeof(IRequireNpmPackage))]
public class NpmToolAttribute : ToolAttribute
{
    public string Id { get; set; }
    public string Executable { get; set; }

    internal override string GetToolPath(ToolOptions options)
    {
        return NpmToolPathResolver.GetNpmExecutable(Executable);
    }

    internal override ToolRequirement GetRequirement(string version = null)
    {
        return new NpmPackageRequirement(Id, version);
    }
}

[BaseTypeRequired(typeof(IRequireAptGetPackage))]
public class AptGetToolAttribute : ToolAttribute
{
    public string Id { get; set; }

    internal override string GetToolPath(ToolOptions options)
    {
        return null;
    }

    internal override ToolRequirement GetRequirement(string version = null)
    {
        return new AptGetPackageRequirement(Id);
    }
}

[BaseTypeRequired(typeof(IRequireNuGetPackage))]
public class NuGetToolAttribute : ToolAttribute
{
    public string Id { get; set; }
    public string Executable { get; set; }

    internal override string GetToolPath(ToolOptions options)
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        var framework = (options as IToolOptionsWithFramework)?.Framework;
        return NuGetToolPathResolver.GetPackageExecutable(Id, Executable, framework: framework);
    }

    internal override ToolRequirement GetRequirement(string version = null)
    {
        return new NuGetPackageRequirement(Id, version);
    }
}

public interface IToolOptionsWithFramework
{
#if NET6_0_OR_GREATER
    public string Framework => ((IOptions)this).Get<string>(() => Framework);
#else
    public string Framework { get; }
#endif
}

public static class ToolOptionsWithFrameworkExtensions
{
    [Pure] [Builder(Type = typeof(IToolOptionsWithFramework), Property = nameof(IToolOptionsWithFramework.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : Options, IToolOptionsWithFramework => o.Modify(b => b.Set(() => o.Framework, v));
}
