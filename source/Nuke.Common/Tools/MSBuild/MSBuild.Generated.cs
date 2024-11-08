// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/MSBuild/MSBuild.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.MSBuild;

/// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public partial class MSBuildTasks : ToolTasks
{
    public static string MSBuildPath => new MSBuildTasks().GetToolPath();
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> MSBuild(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new MSBuildTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="MSBuildSettings.TargetPath"/></li><li><c>/detailedsummary</c> via <see cref="MSBuildSettings.DetailedSummary"/></li><li><c>/logger</c> via <see cref="MSBuildSettings.Loggers"/></li><li><c>/maxcpucount</c> via <see cref="MSBuildSettings.MaxCpuCount"/></li><li><c>/noconsolelogger</c> via <see cref="MSBuildSettings.NoConsoleLogger"/></li><li><c>/nodeReuse</c> via <see cref="MSBuildSettings.NodeReuse"/></li><li><c>/nologo</c> via <see cref="MSBuildSettings.NoLogo"/></li><li><c>/p</c> via <see cref="MSBuildSettings.Properties"/></li><li><c>/p:Platform</c> via <see cref="MSBuildSettings.TargetPlatform"/></li><li><c>/restore</c> via <see cref="MSBuildSettings.Restore"/></li><li><c>/target</c> via <see cref="MSBuildSettings.Targets"/></li><li><c>/toolsversion</c> via <see cref="MSBuildSettings.ToolsVersion"/></li><li><c>/verbosity</c> via <see cref="MSBuildSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MSBuild(MSBuildSettings options = null) => new MSBuildTasks().Run(options);
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="MSBuildSettings.TargetPath"/></li><li><c>/detailedsummary</c> via <see cref="MSBuildSettings.DetailedSummary"/></li><li><c>/logger</c> via <see cref="MSBuildSettings.Loggers"/></li><li><c>/maxcpucount</c> via <see cref="MSBuildSettings.MaxCpuCount"/></li><li><c>/noconsolelogger</c> via <see cref="MSBuildSettings.NoConsoleLogger"/></li><li><c>/nodeReuse</c> via <see cref="MSBuildSettings.NodeReuse"/></li><li><c>/nologo</c> via <see cref="MSBuildSettings.NoLogo"/></li><li><c>/p</c> via <see cref="MSBuildSettings.Properties"/></li><li><c>/p:Platform</c> via <see cref="MSBuildSettings.TargetPlatform"/></li><li><c>/restore</c> via <see cref="MSBuildSettings.Restore"/></li><li><c>/target</c> via <see cref="MSBuildSettings.Targets"/></li><li><c>/toolsversion</c> via <see cref="MSBuildSettings.ToolsVersion"/></li><li><c>/verbosity</c> via <see cref="MSBuildSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MSBuild(Configure<MSBuildSettings> configurator) => new MSBuildTasks().Run(configurator.Invoke(new MSBuildSettings()));
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="MSBuildSettings.TargetPath"/></li><li><c>/detailedsummary</c> via <see cref="MSBuildSettings.DetailedSummary"/></li><li><c>/logger</c> via <see cref="MSBuildSettings.Loggers"/></li><li><c>/maxcpucount</c> via <see cref="MSBuildSettings.MaxCpuCount"/></li><li><c>/noconsolelogger</c> via <see cref="MSBuildSettings.NoConsoleLogger"/></li><li><c>/nodeReuse</c> via <see cref="MSBuildSettings.NodeReuse"/></li><li><c>/nologo</c> via <see cref="MSBuildSettings.NoLogo"/></li><li><c>/p</c> via <see cref="MSBuildSettings.Properties"/></li><li><c>/p:Platform</c> via <see cref="MSBuildSettings.TargetPlatform"/></li><li><c>/restore</c> via <see cref="MSBuildSettings.Restore"/></li><li><c>/target</c> via <see cref="MSBuildSettings.Targets"/></li><li><c>/toolsversion</c> via <see cref="MSBuildSettings.ToolsVersion"/></li><li><c>/verbosity</c> via <see cref="MSBuildSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(MSBuildSettings Settings, IReadOnlyCollection<Output> Output)> MSBuild(CombinatorialConfigure<MSBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(MSBuild, degreeOfParallelism, completeOnFailure);
}
#region MSBuildSettings
/// <summary>Used within <see cref="MSBuildTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MSBuildSettings>))]
[Command(Type = typeof(MSBuildTasks), Command = nameof(MSBuildTasks.MSBuild))]
public partial class MSBuildSettings : ToolOptions
{
    /// <summary>The solution or project file on which MSBuild is executed.</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</summary>
    [Argument(Format = "/detailedsummary")] public bool? DetailedSummary => Get<bool?>(() => DetailedSummary);
    /// <summary><p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p></summary>
    [Argument(Format = "/maxcpucount:{value}")] public int? MaxCpuCount => Get<int?>(() => MaxCpuCount);
    /// <summary><p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p></summary>
    [Argument(Format = "/nodeReuse:{value}")] public bool? NodeReuse => Get<bool?>(() => NodeReuse);
    /// <summary>Don't display the startup banner or the copyright message.</summary>
    [Argument(Format = "/nologo")] public bool? NoLogo => Get<bool?>(() => NoLogo);
    /// <summary>The target platform for which the project is built to run on.</summary>
    [Argument(Format = "/p:Platform={value}", FormatterMethod = nameof(FormatPlatform))] public MSBuildTargetPlatform TargetPlatform => Get<MSBuildTargetPlatform>(() => TargetPlatform);
    /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
    [Argument(Format = "/p:{key}={value}")] public IReadOnlyDictionary<string, object> Properties => Get<Dictionary<string, object>>(() => Properties);
    /// <summary>Runs the <c>Restore</c> target prior to building the actual targets.</summary>
    [Argument(Format = "/restore")] public bool? Restore => Get<bool?>(() => Restore);
    /// <summary><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
    [Argument(Format = "/target:{value}", Separator = ";")] public IReadOnlyList<string> Targets => Get<List<string>>(() => Targets);
    /// <summary><p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p></summary>
    [Argument(Format = "/toolsversion:{value}")] public MSBuildToolsVersion ToolsVersion => Get<MSBuildToolsVersion>(() => ToolsVersion);
    /// <summary>Specifies the version of MSBuild for building.</summary>
    public MSBuildVersion? MSBuildVersion => Get<MSBuildVersion?>(() => MSBuildVersion);
    /// <summary><p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p></summary>
    [Argument(Format = "/verbosity:{value}")] public MSBuildVerbosity Verbosity => Get<MSBuildVerbosity>(() => Verbosity);
    /// <summary>Specifies the platform to use when building.</summary>
    public MSBuildPlatform? MSBuildPlatform => Get<MSBuildPlatform?>(() => MSBuildPlatform);
    /// <summary>Specifies the loggers to use to log events from MSBuild.</summary>
    [Argument(Format = "/logger:{value}")] public IReadOnlyList<string> Loggers => Get<List<string>>(() => Loggers);
    /// <summary>Disable the default console logger, and don't log events to the console.</summary>
    [Argument(Format = "/noconsolelogger")] public bool? NoConsoleLogger => Get<bool?>(() => NoConsoleLogger);
}
#endregion
#region MSBuildSettingsExtensions
/// <summary>Used within <see cref="MSBuildTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MSBuildSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="MSBuildSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="MSBuildSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region DetailedSummary
    /// <inheritdoc cref="MSBuildSettings.DetailedSummary"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.DetailedSummary))]
    public static T SetDetailedSummary<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.DetailedSummary, v));
    /// <inheritdoc cref="MSBuildSettings.DetailedSummary"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.DetailedSummary))]
    public static T ResetDetailedSummary<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.DetailedSummary));
    /// <inheritdoc cref="MSBuildSettings.DetailedSummary"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.DetailedSummary))]
    public static T EnableDetailedSummary<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.DetailedSummary, true));
    /// <inheritdoc cref="MSBuildSettings.DetailedSummary"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.DetailedSummary))]
    public static T DisableDetailedSummary<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.DetailedSummary, false));
    /// <inheritdoc cref="MSBuildSettings.DetailedSummary"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.DetailedSummary))]
    public static T ToggleDetailedSummary<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.DetailedSummary, !o.DetailedSummary));
    #endregion
    #region MaxCpuCount
    /// <inheritdoc cref="MSBuildSettings.MaxCpuCount"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.MaxCpuCount))]
    public static T SetMaxCpuCount<T>(this T o, int? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.MaxCpuCount, v));
    /// <inheritdoc cref="MSBuildSettings.MaxCpuCount"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.MaxCpuCount))]
    public static T ResetMaxCpuCount<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.MaxCpuCount));
    #endregion
    #region NodeReuse
    /// <inheritdoc cref="MSBuildSettings.NodeReuse"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NodeReuse))]
    public static T SetNodeReuse<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NodeReuse, v));
    /// <inheritdoc cref="MSBuildSettings.NodeReuse"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NodeReuse))]
    public static T ResetNodeReuse<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.NodeReuse));
    /// <inheritdoc cref="MSBuildSettings.NodeReuse"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NodeReuse))]
    public static T EnableNodeReuse<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NodeReuse, true));
    /// <inheritdoc cref="MSBuildSettings.NodeReuse"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NodeReuse))]
    public static T DisableNodeReuse<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NodeReuse, false));
    /// <inheritdoc cref="MSBuildSettings.NodeReuse"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NodeReuse))]
    public static T ToggleNodeReuse<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NodeReuse, !o.NodeReuse));
    #endregion
    #region NoLogo
    /// <inheritdoc cref="MSBuildSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoLogo))]
    public static T SetNoLogo<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoLogo, v));
    /// <inheritdoc cref="MSBuildSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoLogo))]
    public static T ResetNoLogo<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.NoLogo));
    /// <inheritdoc cref="MSBuildSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoLogo))]
    public static T EnableNoLogo<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoLogo, true));
    /// <inheritdoc cref="MSBuildSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoLogo))]
    public static T DisableNoLogo<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoLogo, false));
    /// <inheritdoc cref="MSBuildSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoLogo))]
    public static T ToggleNoLogo<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoLogo, !o.NoLogo));
    #endregion
    #region TargetPlatform
    /// <inheritdoc cref="MSBuildSettings.TargetPlatform"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.TargetPlatform))]
    public static T SetTargetPlatform<T>(this T o, MSBuildTargetPlatform v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.TargetPlatform, v));
    /// <inheritdoc cref="MSBuildSettings.TargetPlatform"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.TargetPlatform))]
    public static T ResetTargetPlatform<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.TargetPlatform));
    #endregion
    #region Properties
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, object> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, object v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, object v) where T : MSBuildSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #region OutDir
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetOutDir<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "OutDir", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetOutDir<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "OutDir"));
    #endregion
    #region RunCodeAnalysis
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRunCodeAnalysis<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RunCodeAnalysis", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRunCodeAnalysis<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RunCodeAnalysis"));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnableRunCodeAnalysis<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RunCodeAnalysis", true));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisableRunCodeAnalysis<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RunCodeAnalysis", false));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ToggleRunCodeAnalysis<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "RunCodeAnalysis")));
    #endregion
    #region NoWarn
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetNoWarns<T>(this T o, params int[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "NoWarn", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetNoWarns<T>(this T o, IEnumerable<int> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "NoWarn", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddNoWarns<T>(this T o, params int[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "NoWarn", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddNoWarns<T>(this T o, IEnumerable<int> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "NoWarn", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveNoWarns<T>(this T o, params int[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "NoWarn", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveNoWarns<T>(this T o, IEnumerable<int> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "NoWarn", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetNoWarn<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "NoWarn"));
    #endregion
    #region WarningsAsErrors
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetWarningsAsErrors<T>(this T o, params int[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "WarningsAsErrors", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetWarningsAsErrors<T>(this T o, IEnumerable<int> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "WarningsAsErrors", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddWarningsAsErrors<T>(this T o, params int[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "WarningsAsErrors", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddWarningsAsErrors<T>(this T o, IEnumerable<int> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "WarningsAsErrors", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveWarningsAsErrors<T>(this T o, params int[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "WarningsAsErrors", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveWarningsAsErrors<T>(this T o, IEnumerable<int> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "WarningsAsErrors", v, ";")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetWarningsAsErrors<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "WarningsAsErrors"));
    #endregion
    #region WarningLevel
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetWarningLevel<T>(this T o, int? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "WarningLevel", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetWarningLevel<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "WarningLevel"));
    #endregion
    #region Configuration
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetConfiguration<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "Configuration", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetConfiguration<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "Configuration"));
    #endregion
    #region TreatWarningsAsErrors
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetTreatWarningsAsErrors<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "TreatWarningsAsErrors", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetTreatWarningsAsErrors<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "TreatWarningsAsErrors"));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnableTreatWarningsAsErrors<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "TreatWarningsAsErrors", true));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisableTreatWarningsAsErrors<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "TreatWarningsAsErrors", false));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ToggleTreatWarningsAsErrors<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "TreatWarningsAsErrors")));
    #endregion
    #region AssemblyVersion
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetAssemblyVersion<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "AssemblyVersion", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetAssemblyVersion<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "AssemblyVersion"));
    #endregion
    #region FileVersion
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetFileVersion<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "FileVersion", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetFileVersion<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "FileVersion"));
    #endregion
    #region InformationalVersion
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetInformationalVersion<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "InformationalVersion", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetInformationalVersion<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "InformationalVersion"));
    #endregion
    #region PackageOutputPath
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageOutputPath<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageOutputPath", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageOutputPath<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageOutputPath"));
    #endregion
    #region IncludeSymbols
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetIncludeSymbols<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "IncludeSymbols", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetIncludeSymbols<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "IncludeSymbols"));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnableIncludeSymbols<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "IncludeSymbols", true));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisableIncludeSymbols<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "IncludeSymbols", false));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ToggleIncludeSymbols<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "IncludeSymbols")));
    #endregion
    #region PackageId
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageId<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageId", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageId<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageId"));
    #endregion
    #region PackageVersion
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageVersion<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageVersion", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageVersion<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageVersion"));
    #endregion
    #region PackageVersionPrefix
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageVersionPrefix<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageVersionPrefix", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageVersionPrefix<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageVersionPrefix"));
    #endregion
    #region PackageVersionSuffix
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageVersionSuffix<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageVersionSuffix", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageVersionSuffix<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageVersionSuffix"));
    #endregion
    #region Authors
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetAuthors<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "Authors", v, ",")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetAuthors<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "Authors", v, ",")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddAuthors<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "Authors", v, ",")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddAuthors<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "Authors", v, ",")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveAuthors<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "Authors", v, ",")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveAuthors<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "Authors", v, ",")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetAuthors<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "Authors"));
    #endregion
    #region Title
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetTitle<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "Title", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetTitle<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "Title"));
    #endregion
    #region Description
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetDescription<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "Description", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetDescription<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "Description"));
    #endregion
    #region Copyright
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetCopyright<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "Copyright", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetCopyright<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "Copyright"));
    #endregion
    #region PackageRequireLicenseAcceptance
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageRequireLicenseAcceptance<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageRequireLicenseAcceptance", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageRequireLicenseAcceptance<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageRequireLicenseAcceptance"));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnablePackageRequireLicenseAcceptance<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageRequireLicenseAcceptance", true));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisablePackageRequireLicenseAcceptance<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageRequireLicenseAcceptance", false));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T TogglePackageRequireLicenseAcceptance<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "PackageRequireLicenseAcceptance")));
    #endregion
    #region PackageLicenseUrl
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageLicenseUrl<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageLicenseUrl", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageLicenseUrl<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageLicenseUrl"));
    #endregion
    #region PackageProjectUrl
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageProjectUrl<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageProjectUrl", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageProjectUrl<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageProjectUrl"));
    #endregion
    #region PackageIconUrl
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageIconUrl<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageIconUrl", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageIconUrl<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageIconUrl"));
    #endregion
    #region PackageTags
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageTags<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "PackageTags", v, " ")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageTags<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "PackageTags", v, " ")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddPackageTags<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "PackageTags", v, " ")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddPackageTags<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "PackageTags", v, " ")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemovePackageTags<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "PackageTags", v, " ")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemovePackageTags<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "PackageTags", v, " ")));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageTags<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageTags"));
    #endregion
    #region PackageReleaseNotes
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetPackageReleaseNotes<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "PackageReleaseNotes", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetPackageReleaseNotes<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "PackageReleaseNotes"));
    #endregion
    #region RepositoryUrl
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRepositoryUrl<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RepositoryUrl", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRepositoryUrl<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RepositoryUrl"));
    #endregion
    #region RepositoryType
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRepositoryType<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RepositoryType", v));
    /// <inheritdoc cref="MSBuildSettings.Properties"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRepositoryType<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RepositoryType"));
    #endregion
    #region RestoreSources
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreSources<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "RestoreSources", v, ";")));
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreSources<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "RestoreSources", v, ";")));
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddRestoreSources<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "RestoreSources", v, ";")));
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddRestoreSources<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "RestoreSources", v, ";")));
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveRestoreSources<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "RestoreSources", v, ";")));
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveRestoreSources<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "RestoreSources", v, ";")));
    /// <summary>List of package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreSources<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreSources"));
    #endregion
    #region RestorePackagesPath
    /// <summary>User packages folder path.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestorePackagesPath<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestorePackagesPath", v));
    /// <summary>User packages folder path.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestorePackagesPath<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestorePackagesPath"));
    #endregion
    #region RestoreDisableParallel
    /// <summary>Limit downloads to one at a time.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreDisableParallel<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreDisableParallel", v));
    /// <summary>Limit downloads to one at a time.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreDisableParallel<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreDisableParallel"));
    /// <summary>Limit downloads to one at a time.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnableRestoreDisableParallel<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreDisableParallel", true));
    /// <summary>Limit downloads to one at a time.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisableRestoreDisableParallel<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreDisableParallel", false));
    /// <summary>Limit downloads to one at a time.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ToggleRestoreDisableParallel<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "RestoreDisableParallel")));
    #endregion
    #region RestoreConfigFile
    /// <summary>Path to a Nuget.Config file to apply.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreConfigFile<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreConfigFile", v));
    /// <summary>Path to a Nuget.Config file to apply.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreConfigFile<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreConfigFile"));
    #endregion
    #region RestoreNoCache
    /// <summary>If true, avoids using the web cache.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreNoCache<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreNoCache", v));
    /// <summary>If true, avoids using the web cache.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreNoCache<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreNoCache"));
    /// <summary>If true, avoids using the web cache.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnableRestoreNoCache<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreNoCache", true));
    /// <summary>If true, avoids using the web cache.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisableRestoreNoCache<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreNoCache", false));
    /// <summary>If true, avoids using the web cache.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ToggleRestoreNoCache<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "RestoreNoCache")));
    #endregion
    #region RestoreIgnoreFailedSources
    /// <summary>If true, ignores failing or missing package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreIgnoreFailedSources<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreIgnoreFailedSources", v));
    /// <summary>If true, ignores failing or missing package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreIgnoreFailedSources<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreIgnoreFailedSources"));
    /// <summary>If true, ignores failing or missing package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T EnableRestoreIgnoreFailedSources<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreIgnoreFailedSources", true));
    /// <summary>If true, ignores failing or missing package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T DisableRestoreIgnoreFailedSources<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreIgnoreFailedSources", false));
    /// <summary>If true, ignores failing or missing package sources.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ToggleRestoreIgnoreFailedSources<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "RestoreIgnoreFailedSources")));
    #endregion
    #region RestoreTaskAssemblyFile
    /// <summary>Path to <c>NuGet.Build.Tasks.dll</c>.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreTaskAssemblyFile<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreTaskAssemblyFile", v));
    /// <summary>Path to <c>NuGet.Build.Tasks.dll</c>.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreTaskAssemblyFile<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreTaskAssemblyFile"));
    #endregion
    #region RestoreGraphProjectInput
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreGraphProjectInputs<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "RestoreGraphProjectInput", v, ";")));
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreGraphProjectInputs<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.SetCollection(o.Properties, "RestoreGraphProjectInput", v, ";")));
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddRestoreGraphProjectInputs<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "RestoreGraphProjectInput", v, ";")));
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T AddRestoreGraphProjectInputs<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.AddCollection(o.Properties, "RestoreGraphProjectInput", v, ";")));
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveRestoreGraphProjectInputs<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "RestoreGraphProjectInput", v, ";")));
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T RemoveRestoreGraphProjectInputs<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.RemoveCollection(o.Properties, "RestoreGraphProjectInput", v, ";")));
    /// <summary>Semicolon-delimited list of projects to restore, which should contain absolute paths.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreGraphProjectInput<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreGraphProjectInput"));
    #endregion
    #region RestoreOutputPath
    /// <summary>Output folder, defaulting to the obj folder.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetRestoreOutputPath<T>(this T o, string v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "RestoreOutputPath", v));
    /// <summary>Output folder, defaulting to the obj folder.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetRestoreOutputPath<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "RestoreOutputPath"));
    #endregion
    #region SymbolPackageFormat
    /// <summary>Format for packaging symbols.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T SetSymbolPackageFormat<T>(this T o, MSBuildSymbolPackageFormat v) where T : MSBuildSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "SymbolPackageFormat", v));
    /// <summary>Format for packaging symbols.</summary>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Properties))]
    public static T ResetSymbolPackageFormat<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "SymbolPackageFormat"));
    #endregion
    #endregion
    #region Restore
    /// <inheritdoc cref="MSBuildSettings.Restore"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Restore))]
    public static T SetRestore<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Restore, v));
    /// <inheritdoc cref="MSBuildSettings.Restore"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Restore))]
    public static T ResetRestore<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.Restore));
    /// <inheritdoc cref="MSBuildSettings.Restore"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Restore))]
    public static T EnableRestore<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Restore, true));
    /// <inheritdoc cref="MSBuildSettings.Restore"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Restore))]
    public static T DisableRestore<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Restore, false));
    /// <inheritdoc cref="MSBuildSettings.Restore"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Restore))]
    public static T ToggleRestore<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Restore, !o.Restore));
    #endregion
    #region Targets
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T SetTargets<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Targets, v));
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T SetTargets<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Targets, v));
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T AddTargets<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.AddCollection(() => o.Targets, v));
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T AddTargets<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.AddCollection(() => o.Targets, v));
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T RemoveTargets<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Targets, v));
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T RemoveTargets<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Targets, v));
    /// <inheritdoc cref="MSBuildSettings.Targets"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Targets))]
    public static T ClearTargets<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.ClearCollection(() => o.Targets));
    #endregion
    #region ToolsVersion
    /// <inheritdoc cref="MSBuildSettings.ToolsVersion"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.ToolsVersion))]
    public static T SetToolsVersion<T>(this T o, MSBuildToolsVersion v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.ToolsVersion, v));
    /// <inheritdoc cref="MSBuildSettings.ToolsVersion"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.ToolsVersion))]
    public static T ResetToolsVersion<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.ToolsVersion));
    #endregion
    #region MSBuildVersion
    /// <inheritdoc cref="MSBuildSettings.MSBuildVersion"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.MSBuildVersion))]
    public static T SetMSBuildVersion<T>(this T o, MSBuildVersion? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.MSBuildVersion, v));
    /// <inheritdoc cref="MSBuildSettings.MSBuildVersion"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.MSBuildVersion))]
    public static T ResetMSBuildVersion<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.MSBuildVersion));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="MSBuildSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, MSBuildVerbosity v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="MSBuildSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region MSBuildPlatform
    /// <inheritdoc cref="MSBuildSettings.MSBuildPlatform"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.MSBuildPlatform))]
    public static T SetMSBuildPlatform<T>(this T o, MSBuildPlatform? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.MSBuildPlatform, v));
    /// <inheritdoc cref="MSBuildSettings.MSBuildPlatform"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.MSBuildPlatform))]
    public static T ResetMSBuildPlatform<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.MSBuildPlatform));
    #endregion
    #region Loggers
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T SetLoggers<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Loggers, v));
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T SetLoggers<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.Loggers, v));
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T AddLoggers<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.AddCollection(() => o.Loggers, v));
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T AddLoggers<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.AddCollection(() => o.Loggers, v));
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T RemoveLoggers<T>(this T o, params string[] v) where T : MSBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Loggers, v));
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T RemoveLoggers<T>(this T o, IEnumerable<string> v) where T : MSBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Loggers, v));
    /// <inheritdoc cref="MSBuildSettings.Loggers"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.Loggers))]
    public static T ClearLoggers<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.ClearCollection(() => o.Loggers));
    #endregion
    #region NoConsoleLogger
    /// <inheritdoc cref="MSBuildSettings.NoConsoleLogger"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoConsoleLogger))]
    public static T SetNoConsoleLogger<T>(this T o, bool? v) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoConsoleLogger, v));
    /// <inheritdoc cref="MSBuildSettings.NoConsoleLogger"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoConsoleLogger))]
    public static T ResetNoConsoleLogger<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Remove(() => o.NoConsoleLogger));
    /// <inheritdoc cref="MSBuildSettings.NoConsoleLogger"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoConsoleLogger))]
    public static T EnableNoConsoleLogger<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoConsoleLogger, true));
    /// <inheritdoc cref="MSBuildSettings.NoConsoleLogger"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoConsoleLogger))]
    public static T DisableNoConsoleLogger<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoConsoleLogger, false));
    /// <inheritdoc cref="MSBuildSettings.NoConsoleLogger"/>
    [Pure] [Builder(Type = typeof(MSBuildSettings), Property = nameof(MSBuildSettings.NoConsoleLogger))]
    public static T ToggleNoConsoleLogger<T>(this T o) where T : MSBuildSettings => o.Modify(b => b.Set(() => o.NoConsoleLogger, !o.NoConsoleLogger));
    #endregion
}
#endregion
#region MSBuildToolsVersion
/// <summary>Used within <see cref="MSBuildTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MSBuildToolsVersion>))]
public partial class MSBuildToolsVersion : Enumeration
{
    public static MSBuildToolsVersion _2_0 = (MSBuildToolsVersion) "2.0";
    public static MSBuildToolsVersion _3_5 = (MSBuildToolsVersion) "3.5";
    public static MSBuildToolsVersion _4_0 = (MSBuildToolsVersion) "4.0";
    public static MSBuildToolsVersion _12_0 = (MSBuildToolsVersion) "12.0";
    public static MSBuildToolsVersion _14_0 = (MSBuildToolsVersion) "14.0";
    public static MSBuildToolsVersion _15_0 = (MSBuildToolsVersion) "15.0";
    public static implicit operator MSBuildToolsVersion(string value)
    {
        return new MSBuildToolsVersion { Value = value };
    }
}
#endregion
#region MSBuildVerbosity
/// <summary>Used within <see cref="MSBuildTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MSBuildVerbosity>))]
public partial class MSBuildVerbosity : Enumeration
{
    public static MSBuildVerbosity Quiet = (MSBuildVerbosity) "Quiet";
    public static MSBuildVerbosity Minimal = (MSBuildVerbosity) "Minimal";
    public static MSBuildVerbosity Normal = (MSBuildVerbosity) "Normal";
    public static MSBuildVerbosity Detailed = (MSBuildVerbosity) "Detailed";
    public static MSBuildVerbosity Diagnostic = (MSBuildVerbosity) "Diagnostic";
    public static implicit operator MSBuildVerbosity(string value)
    {
        return new MSBuildVerbosity { Value = value };
    }
}
#endregion
#region MSBuildTargetPlatform
/// <summary>Used within <see cref="MSBuildTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MSBuildTargetPlatform>))]
public partial class MSBuildTargetPlatform : Enumeration
{
    public static MSBuildTargetPlatform MSIL = (MSBuildTargetPlatform) "MSIL";
    public static MSBuildTargetPlatform x86 = (MSBuildTargetPlatform) "x86";
    public static MSBuildTargetPlatform x64 = (MSBuildTargetPlatform) "x64";
    public static MSBuildTargetPlatform arm = (MSBuildTargetPlatform) "arm";
    public static MSBuildTargetPlatform Win32 = (MSBuildTargetPlatform) "Win32";
    public static implicit operator MSBuildTargetPlatform(string value)
    {
        return new MSBuildTargetPlatform { Value = value };
    }
}
#endregion
#region MSBuildSymbolPackageFormat
/// <summary>Used within <see cref="MSBuildTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MSBuildSymbolPackageFormat>))]
public partial class MSBuildSymbolPackageFormat : Enumeration
{
    public static MSBuildSymbolPackageFormat symbols_nupkg = (MSBuildSymbolPackageFormat) "symbols.nupkg";
    public static MSBuildSymbolPackageFormat snupkg = (MSBuildSymbolPackageFormat) "snupkg";
    public static implicit operator MSBuildSymbolPackageFormat(string value)
    {
        return new MSBuildSymbolPackageFormat { Value = value };
    }
}
#endregion
