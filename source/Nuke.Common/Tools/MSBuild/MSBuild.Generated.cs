// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/MSBuild.json
// Generated with Nuke.CodeGeneration version LOCAL (OSX,.NETStandard,Version=v2.0)

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
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

namespace Nuke.Common.Tools.MSBuild
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MSBuildTasks
    {
        /// <summary>
        ///   Path to the MSBuild executable.
        /// </summary>
        public static string MSBuildPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("MSBUILD_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> MSBuildLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.
        /// </summary>
        public static IReadOnlyCollection<Output> MSBuild(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(MSBuildPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, MSBuildLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
        ///   <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> MSBuild(MSBuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MSBuildSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
        ///   <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="MSBuildSettings.TargetPath"/></li>
        ///     <li><c>/detailedsummary</c> via <see cref="MSBuildSettings.DetailedSummary"/></li>
        ///     <li><c>/logger</c> via <see cref="MSBuildSettings.Loggers"/></li>
        ///     <li><c>/maxcpucount</c> via <see cref="MSBuildSettings.MaxCpuCount"/></li>
        ///     <li><c>/noconsolelogger</c> via <see cref="MSBuildSettings.NoConsoleLogger"/></li>
        ///     <li><c>/nodeReuse</c> via <see cref="MSBuildSettings.NodeReuse"/></li>
        ///     <li><c>/nologo</c> via <see cref="MSBuildSettings.NoLogo"/></li>
        ///     <li><c>/p</c> via <see cref="MSBuildSettings.Properties"/></li>
        ///     <li><c>/p:Platform</c> via <see cref="MSBuildSettings.TargetPlatform"/></li>
        ///     <li><c>/restore</c> via <see cref="MSBuildSettings.Restore"/></li>
        ///     <li><c>/target</c> via <see cref="MSBuildSettings.Targets"/></li>
        ///     <li><c>/toolsversion</c> via <see cref="MSBuildSettings.ToolsVersion"/></li>
        ///     <li><c>/verbosity</c> via <see cref="MSBuildSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MSBuild(Configure<MSBuildSettings> configurator)
        {
            return MSBuild(configurator(new MSBuildSettings()));
        }
        /// <summary>
        ///   <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
        ///   <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="MSBuildSettings.TargetPath"/></li>
        ///     <li><c>/detailedsummary</c> via <see cref="MSBuildSettings.DetailedSummary"/></li>
        ///     <li><c>/logger</c> via <see cref="MSBuildSettings.Loggers"/></li>
        ///     <li><c>/maxcpucount</c> via <see cref="MSBuildSettings.MaxCpuCount"/></li>
        ///     <li><c>/noconsolelogger</c> via <see cref="MSBuildSettings.NoConsoleLogger"/></li>
        ///     <li><c>/nodeReuse</c> via <see cref="MSBuildSettings.NodeReuse"/></li>
        ///     <li><c>/nologo</c> via <see cref="MSBuildSettings.NoLogo"/></li>
        ///     <li><c>/p</c> via <see cref="MSBuildSettings.Properties"/></li>
        ///     <li><c>/p:Platform</c> via <see cref="MSBuildSettings.TargetPlatform"/></li>
        ///     <li><c>/restore</c> via <see cref="MSBuildSettings.Restore"/></li>
        ///     <li><c>/target</c> via <see cref="MSBuildSettings.Targets"/></li>
        ///     <li><c>/toolsversion</c> via <see cref="MSBuildSettings.ToolsVersion"/></li>
        ///     <li><c>/verbosity</c> via <see cref="MSBuildSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(MSBuildSettings Settings, IReadOnlyCollection<Output> Output)> MSBuild(CombinatorialConfigure<MSBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(MSBuild, MSBuildLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region MSBuildSettings
    /// <summary>
    ///   Used within <see cref="MSBuildTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MSBuildSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the MSBuild executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => MSBuildTasks.MSBuildLogger;
        /// <summary>
        ///   The solution or project file on which MSBuild is executed.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.
        /// </summary>
        public virtual bool? DetailedSummary { get; internal set; }
        /// <summary>
        ///   <p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p>
        /// </summary>
        public virtual int? MaxCpuCount { get; internal set; }
        /// <summary>
        ///   <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        public virtual bool? NodeReuse { get; internal set; }
        /// <summary>
        ///   Don't display the startup banner or the copyright message.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   The target platform for which the project is built to run on.
        /// </summary>
        public virtual MSBuildTargetPlatform TargetPlatform { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Runs the <c>Restore</c> target prior to building the actual targets.
        /// </summary>
        public virtual bool? Restore { get; internal set; }
        /// <summary>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        public virtual IReadOnlyList<string> Targets => TargetsInternal.AsReadOnly();
        internal List<string> TargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   <p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p>
        /// </summary>
        public virtual MSBuildToolsVersion ToolsVersion { get; internal set; }
        /// <summary>
        ///   Specifies the version of MSBuild for building.
        /// </summary>
        public virtual MSBuildVersion? MSBuildVersion { get; internal set; }
        /// <summary>
        ///   <p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p>
        /// </summary>
        public virtual MSBuildVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Specifies the platform to use when building.
        /// </summary>
        public virtual MSBuildPlatform? MSBuildPlatform { get; internal set; }
        /// <summary>
        ///   Specifies the loggers to use to log events from MSBuild.
        /// </summary>
        public virtual IReadOnlyList<string> Loggers => LoggersInternal.AsReadOnly();
        internal List<string> LoggersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disable the default console logger, and don't log events to the console.
        /// </summary>
        public virtual bool? NoConsoleLogger { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetPath)
              .Add("/detailedsummary", DetailedSummary)
              .Add("/maxcpucount:{value}", MaxCpuCount)
              .Add("/nodeReuse:{value}", NodeReuse)
              .Add("/nologo", NoLogo)
              .Add("/p:Platform={value}", GetTargetPlatform(), customValue: true)
              .Add("/p:{value}", Properties, "{key}={value}", disallowed: ';')
              .Add("/restore", Restore)
              .Add("/target:{value}", Targets, separator: ';')
              .Add("/toolsversion:{value}", ToolsVersion)
              .Add("/verbosity:{value}", Verbosity)
              .Add("/logger:{value}", Loggers)
              .Add("/noconsolelogger", NoConsoleLogger);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region MSBuildSettingsExtensions
    /// <summary>
    ///   Used within <see cref="MSBuildTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MSBuildSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.TargetPath"/></em></p>
        ///   <p>The solution or project file on which MSBuild is executed.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargetPath(this MSBuildSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.TargetPath"/></em></p>
        ///   <p>The solution or project file on which MSBuild is executed.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetTargetPath(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region DetailedSummary
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.DetailedSummary"/></em></p>
        ///   <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetDetailedSummary(this MSBuildSettings toolSettings, bool? detailedSummary)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = detailedSummary;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.DetailedSummary"/></em></p>
        ///   <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSBuildSettings.DetailedSummary"/></em></p>
        ///   <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSBuildSettings.DetailedSummary"/></em></p>
        ///   <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSBuildSettings.DetailedSummary"/></em></p>
        ///   <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = !toolSettings.DetailedSummary;
            return toolSettings;
        }
        #endregion
        #region MaxCpuCount
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.MaxCpuCount"/></em></p>
        ///   <p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetMaxCpuCount(this MSBuildSettings toolSettings, int? maxCpuCount)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxCpuCount = maxCpuCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.MaxCpuCount"/></em></p>
        ///   <p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetMaxCpuCount(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxCpuCount = null;
            return toolSettings;
        }
        #endregion
        #region NodeReuse
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.NodeReuse"/></em></p>
        ///   <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetNodeReuse(this MSBuildSettings toolSettings, bool? nodeReuse)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = nodeReuse;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.NodeReuse"/></em></p>
        ///   <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSBuildSettings.NodeReuse"/></em></p>
        ///   <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSBuildSettings.NodeReuse"/></em></p>
        ///   <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSBuildSettings.NodeReuse"/></em></p>
        ///   <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = !toolSettings.NodeReuse;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.NoLogo"/></em></p>
        ///   <p>Don't display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetNoLogo(this MSBuildSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.NoLogo"/></em></p>
        ///   <p>Don't display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSBuildSettings.NoLogo"/></em></p>
        ///   <p>Don't display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSBuildSettings.NoLogo"/></em></p>
        ///   <p>Don't display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSBuildSettings.NoLogo"/></em></p>
        ///   <p>Don't display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region TargetPlatform
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.TargetPlatform"/></em></p>
        ///   <p>The target platform for which the project is built to run on.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargetPlatform(this MSBuildSettings toolSettings, MSBuildTargetPlatform targetPlatform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPlatform = targetPlatform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.TargetPlatform"/></em></p>
        ///   <p>The target platform for which the project is built to run on.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetTargetPlatform(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPlatform = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetProperties(this MSBuildSettings toolSettings, IDictionary<string, object> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearProperties(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddProperty(this MSBuildSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveProperty(this MSBuildSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetProperty(this MSBuildSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region OutDir
        /// <summary>
        ///   <p><em>Sets <c>OutDir</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetOutDir(this MSBuildSettings toolSettings, string outDir)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["OutDir"] = outDir;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>OutDir</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetOutDir(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("OutDir");
            return toolSettings;
        }
        #endregion
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRunCodeAnalysis(this MSBuildSettings toolSettings, bool? runCodeAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRunCodeAnalysis(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableRunCodeAnalysis(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableRunCodeAnalysis(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleRunCodeAnalysis(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetNoWarns(this MSBuildSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetNoWarns(this MSBuildSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddNoWarns(this MSBuildSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddNoWarns(this MSBuildSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearNoWarns(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveNoWarns(this MSBuildSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveNoWarns(this MSBuildSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetWarningsAsErrors(this MSBuildSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetWarningsAsErrors(this MSBuildSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddWarningsAsErrors(this MSBuildSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddWarningsAsErrors(this MSBuildSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearWarningsAsErrors(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveWarningsAsErrors(this MSBuildSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveWarningsAsErrors(this MSBuildSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetWarningLevel(this MSBuildSettings toolSettings, int? warningLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetWarningLevel(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <c>Configuration</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetConfiguration(this MSBuildSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Configuration"] = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Configuration</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetConfiguration(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Configuration");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTreatWarningsAsErrors(this MSBuildSettings toolSettings, bool? treatWarningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetTreatWarningsAsErrors(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableTreatWarningsAsErrors(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableTreatWarningsAsErrors(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleTreatWarningsAsErrors(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetAssemblyVersion(this MSBuildSettings toolSettings, string assemblyVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetAssemblyVersion(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetFileVersion(this MSBuildSettings toolSettings, string fileVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetFileVersion(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetInformationalVersion(this MSBuildSettings toolSettings, string informationalVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetInformationalVersion(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageOutputPath
        /// <summary>
        ///   <p><em>Sets <c>PackageOutputPath</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageOutputPath(this MSBuildSettings toolSettings, string packageOutputPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageOutputPath"] = packageOutputPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageOutputPath</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageOutputPath(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageOutputPath");
            return toolSettings;
        }
        #endregion
        #region IncludeSymbols
        /// <summary>
        ///   <p><em>Sets <c>IncludeSymbols</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetIncludeSymbols(this MSBuildSettings toolSettings, bool? includeSymbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["IncludeSymbols"] = includeSymbols;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>IncludeSymbols</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetIncludeSymbols(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("IncludeSymbols");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>IncludeSymbols</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableIncludeSymbols(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["IncludeSymbols"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>IncludeSymbols</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableIncludeSymbols(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["IncludeSymbols"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>IncludeSymbols</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleIncludeSymbols(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "IncludeSymbols");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageId(this MSBuildSettings toolSettings, string packageId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageId(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region PackageVersion
        /// <summary>
        ///   <p><em>Sets <c>PackageVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageVersion(this MSBuildSettings toolSettings, string packageVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageVersion"] = packageVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageVersion</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageVersion(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageVersion");
            return toolSettings;
        }
        #endregion
        #region PackageVersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>PackageVersionPrefix</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageVersionPrefix(this MSBuildSettings toolSettings, string packageVersionPrefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageVersionPrefix"] = packageVersionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageVersionPrefix</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageVersionPrefix(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageVersionPrefix");
            return toolSettings;
        }
        #endregion
        #region PackageVersionSuffix
        /// <summary>
        ///   <p><em>Sets <c>PackageVersionSuffix</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageVersionSuffix(this MSBuildSettings toolSettings, string packageVersionSuffix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageVersionSuffix"] = packageVersionSuffix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageVersionSuffix</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageVersionSuffix(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageVersionSuffix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetAuthors(this MSBuildSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetAuthors(this MSBuildSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddAuthors(this MSBuildSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddAuthors(this MSBuildSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearAuthors(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveAuthors(this MSBuildSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveAuthors(this MSBuildSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTitle(this MSBuildSettings toolSettings, string title)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetTitle(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetDescription(this MSBuildSettings toolSettings, string description)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetDescription(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetCopyright(this MSBuildSettings toolSettings, string copyright)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetCopyright(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageRequireLicenseAcceptance(this MSBuildSettings toolSettings, bool? packageRequireLicenseAcceptance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageRequireLicenseAcceptance(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnablePackageRequireLicenseAcceptance(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisablePackageRequireLicenseAcceptance(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings TogglePackageRequireLicenseAcceptance(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageLicenseUrl(this MSBuildSettings toolSettings, string packageLicenseUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageLicenseUrl(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageProjectUrl(this MSBuildSettings toolSettings, string packageProjectUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageProjectUrl(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageIconUrl(this MSBuildSettings toolSettings, string packageIconUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageIconUrl(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageTags(this MSBuildSettings toolSettings, params string[] packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageTags(this MSBuildSettings toolSettings, IEnumerable<string> packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddPackageTags(this MSBuildSettings toolSettings, params string[] packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddPackageTags(this MSBuildSettings toolSettings, IEnumerable<string> packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearPackageTags(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemovePackageTags(this MSBuildSettings toolSettings, params string[] packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemovePackageTags(this MSBuildSettings toolSettings, IEnumerable<string> packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetPackageReleaseNotes(this MSBuildSettings toolSettings, string packageReleaseNotes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetPackageReleaseNotes(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRepositoryUrl(this MSBuildSettings toolSettings, string repositoryUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRepositoryUrl(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRepositoryType(this MSBuildSettings toolSettings, string repositoryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRepositoryType(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region RestoreSources
        /// <summary>
        ///   <p><em>Sets <c>RestoreSources</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreSources(this MSBuildSettings toolSettings, params string[] restoreSources)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "RestoreSources", restoreSources, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>RestoreSources</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreSources(this MSBuildSettings toolSettings, IEnumerable<string> restoreSources)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "RestoreSources", restoreSources, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>RestoreSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddRestoreSources(this MSBuildSettings toolSettings, params string[] restoreSources)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "RestoreSources", restoreSources, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>RestoreSources</c> in existing <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddRestoreSources(this MSBuildSettings toolSettings, IEnumerable<string> restoreSources)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "RestoreSources", restoreSources, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>RestoreSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearRestoreSources(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreSources");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>RestoreSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveRestoreSources(this MSBuildSettings toolSettings, params string[] restoreSources)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "RestoreSources", restoreSources, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>RestoreSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>List of package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveRestoreSources(this MSBuildSettings toolSettings, IEnumerable<string> restoreSources)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "RestoreSources", restoreSources, ';');
            return toolSettings;
        }
        #endregion
        #region RestorePackagesPath
        /// <summary>
        ///   <p><em>Sets <c>RestorePackagesPath</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>User packages folder path.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestorePackagesPath(this MSBuildSettings toolSettings, string restorePackagesPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestorePackagesPath"] = restorePackagesPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestorePackagesPath</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>User packages folder path.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestorePackagesPath(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestorePackagesPath");
            return toolSettings;
        }
        #endregion
        #region RestoreDisableParallel
        /// <summary>
        ///   <p><em>Sets <c>RestoreDisableParallel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Limit downloads to one at a time.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreDisableParallel(this MSBuildSettings toolSettings, bool? restoreDisableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreDisableParallel"] = restoreDisableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestoreDisableParallel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Limit downloads to one at a time.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestoreDisableParallel(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreDisableParallel");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RestoreDisableParallel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableRestoreDisableParallel(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreDisableParallel"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RestoreDisableParallel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableRestoreDisableParallel(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreDisableParallel"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RestoreDisableParallel</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleRestoreDisableParallel(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RestoreDisableParallel");
            return toolSettings;
        }
        #endregion
        #region RestoreConfigFile
        /// <summary>
        ///   <p><em>Sets <c>RestoreConfigFile</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Path to a Nuget.Config file to apply.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreConfigFile(this MSBuildSettings toolSettings, string restoreConfigFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreConfigFile"] = restoreConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestoreConfigFile</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Path to a Nuget.Config file to apply.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestoreConfigFile(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreConfigFile");
            return toolSettings;
        }
        #endregion
        #region RestoreNoCache
        /// <summary>
        ///   <p><em>Sets <c>RestoreNoCache</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>If true, avoids using the web cache.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreNoCache(this MSBuildSettings toolSettings, bool? restoreNoCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreNoCache"] = restoreNoCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestoreNoCache</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>If true, avoids using the web cache.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestoreNoCache(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreNoCache");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RestoreNoCache</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableRestoreNoCache(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreNoCache"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RestoreNoCache</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableRestoreNoCache(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreNoCache"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RestoreNoCache</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleRestoreNoCache(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RestoreNoCache");
            return toolSettings;
        }
        #endregion
        #region RestoreIgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <c>RestoreIgnoreFailedSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>If true, ignores failing or missing package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreIgnoreFailedSources(this MSBuildSettings toolSettings, bool? restoreIgnoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreIgnoreFailedSources"] = restoreIgnoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestoreIgnoreFailedSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>If true, ignores failing or missing package sources.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestoreIgnoreFailedSources(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreIgnoreFailedSources");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RestoreIgnoreFailedSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableRestoreIgnoreFailedSources(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreIgnoreFailedSources"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RestoreIgnoreFailedSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableRestoreIgnoreFailedSources(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreIgnoreFailedSources"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RestoreIgnoreFailedSources</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleRestoreIgnoreFailedSources(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RestoreIgnoreFailedSources");
            return toolSettings;
        }
        #endregion
        #region RestoreTaskAssemblyFile
        /// <summary>
        ///   <p><em>Sets <c>RestoreTaskAssemblyFile</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Path to <c>NuGet.Build.Tasks.dll</c>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreTaskAssemblyFile(this MSBuildSettings toolSettings, string restoreTaskAssemblyFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreTaskAssemblyFile"] = restoreTaskAssemblyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestoreTaskAssemblyFile</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Path to <c>NuGet.Build.Tasks.dll</c>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestoreTaskAssemblyFile(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreTaskAssemblyFile");
            return toolSettings;
        }
        #endregion
        #region RestoreGraphProjectInput
        /// <summary>
        ///   <p><em>Sets <c>RestoreGraphProjectInput</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreGraphProjectInputs(this MSBuildSettings toolSettings, params string[] restoreGraphProjectInput)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "RestoreGraphProjectInput", restoreGraphProjectInput, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>RestoreGraphProjectInput</c> in <see cref="MSBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreGraphProjectInputs(this MSBuildSettings toolSettings, IEnumerable<string> restoreGraphProjectInput)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "RestoreGraphProjectInput", restoreGraphProjectInput, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>RestoreGraphProjectInput</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddRestoreGraphProjectInputs(this MSBuildSettings toolSettings, params string[] restoreGraphProjectInput)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "RestoreGraphProjectInput", restoreGraphProjectInput, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>RestoreGraphProjectInput</c> in existing <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddRestoreGraphProjectInputs(this MSBuildSettings toolSettings, IEnumerable<string> restoreGraphProjectInput)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "RestoreGraphProjectInput", restoreGraphProjectInput, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>RestoreGraphProjectInput</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearRestoreGraphProjectInputs(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreGraphProjectInput");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>RestoreGraphProjectInput</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveRestoreGraphProjectInputs(this MSBuildSettings toolSettings, params string[] restoreGraphProjectInput)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "RestoreGraphProjectInput", restoreGraphProjectInput, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>RestoreGraphProjectInput</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Semicolon-delimited list of projects to restore, which should contain absolute paths.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveRestoreGraphProjectInputs(this MSBuildSettings toolSettings, IEnumerable<string> restoreGraphProjectInput)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "RestoreGraphProjectInput", restoreGraphProjectInput, ';');
            return toolSettings;
        }
        #endregion
        #region RestoreOutputPath
        /// <summary>
        ///   <p><em>Sets <c>RestoreOutputPath</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Output folder, defaulting to the obj folder.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestoreOutputPath(this MSBuildSettings toolSettings, string restoreOutputPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RestoreOutputPath"] = restoreOutputPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RestoreOutputPath</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Output folder, defaulting to the obj folder.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestoreOutputPath(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RestoreOutputPath");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetSymbolPackageFormat(this MSBuildSettings toolSettings, MSBuildSymbolPackageFormat symbolPackageFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="MSBuildSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetSymbolPackageFormat(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
        #region Restore
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Restore"/></em></p>
        ///   <p>Runs the <c>Restore</c> target prior to building the actual targets.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetRestore(this MSBuildSettings toolSettings, bool? restore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Restore = restore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.Restore"/></em></p>
        ///   <p>Runs the <c>Restore</c> target prior to building the actual targets.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetRestore(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Restore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSBuildSettings.Restore"/></em></p>
        ///   <p>Runs the <c>Restore</c> target prior to building the actual targets.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableRestore(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Restore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSBuildSettings.Restore"/></em></p>
        ///   <p>Runs the <c>Restore</c> target prior to building the actual targets.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableRestore(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Restore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSBuildSettings.Restore"/></em></p>
        ///   <p>Runs the <c>Restore</c> target prior to building the actual targets.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleRestore(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Restore = !toolSettings.Restore;
            return toolSettings;
        }
        #endregion
        #region Targets
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Targets"/> to a new list</em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargets(this MSBuildSettings toolSettings, params string[] targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal = targets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Targets"/> to a new list</em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargets(this MSBuildSettings toolSettings, IEnumerable<string> targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal = targets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSBuildSettings.Targets"/></em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddTargets(this MSBuildSettings toolSettings, params string[] targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.AddRange(targets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSBuildSettings.Targets"/></em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddTargets(this MSBuildSettings toolSettings, IEnumerable<string> targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.AddRange(targets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSBuildSettings.Targets"/></em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearTargets(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSBuildSettings.Targets"/></em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveTargets(this MSBuildSettings toolSettings, params string[] targets)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(targets);
            toolSettings.TargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSBuildSettings.Targets"/></em></p>
        ///   <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveTargets(this MSBuildSettings toolSettings, IEnumerable<string> targets)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(targets);
            toolSettings.TargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ToolsVersion
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.ToolsVersion"/></em></p>
        ///   <p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetToolsVersion(this MSBuildSettings toolSettings, MSBuildToolsVersion toolsVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsVersion = toolsVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.ToolsVersion"/></em></p>
        ///   <p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetToolsVersion(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsVersion = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildVersion
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.MSBuildVersion"/></em></p>
        ///   <p>Specifies the version of MSBuild for building.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetMSBuildVersion(this MSBuildSettings toolSettings, MSBuildVersion? msbuildVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.MSBuildVersion"/></em></p>
        ///   <p>Specifies the version of MSBuild for building.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetMSBuildVersion(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetVerbosity(this MSBuildSettings toolSettings, MSBuildVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetVerbosity(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildPlatform
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.MSBuildPlatform"/></em></p>
        ///   <p>Specifies the platform to use when building.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetMSBuildPlatform(this MSBuildSettings toolSettings, MSBuildPlatform? msbuildPlatform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPlatform = msbuildPlatform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.MSBuildPlatform"/></em></p>
        ///   <p>Specifies the platform to use when building.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetMSBuildPlatform(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPlatform = null;
            return toolSettings;
        }
        #endregion
        #region Loggers
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Loggers"/> to a new list</em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetLoggers(this MSBuildSettings toolSettings, params string[] loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal = loggers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.Loggers"/> to a new list</em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetLoggers(this MSBuildSettings toolSettings, IEnumerable<string> loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal = loggers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddLoggers(this MSBuildSettings toolSettings, params string[] loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.AddRange(loggers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddLoggers(this MSBuildSettings toolSettings, IEnumerable<string> loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.AddRange(loggers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearLoggers(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveLoggers(this MSBuildSettings toolSettings, params string[] loggers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(loggers);
            toolSettings.LoggersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveLoggers(this MSBuildSettings toolSettings, IEnumerable<string> loggers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(loggers);
            toolSettings.LoggersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoConsoleLogger
        /// <summary>
        ///   <p><em>Sets <see cref="MSBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetNoConsoleLogger(this MSBuildSettings toolSettings, bool? noConsoleLogger)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = noConsoleLogger;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ResetNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = !toolSettings.NoConsoleLogger;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region MSBuildToolsVersion
    /// <summary>
    ///   Used within <see cref="MSBuildTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<MSBuildToolsVersion>))]
    public partial class MSBuildToolsVersion : Enumeration
    {
        public static MSBuildToolsVersion _2_0 = new MSBuildToolsVersion { Value = "2.0" };
        public static MSBuildToolsVersion _3_5 = new MSBuildToolsVersion { Value = "3.5" };
        public static MSBuildToolsVersion _4_0 = new MSBuildToolsVersion { Value = "4.0" };
        public static MSBuildToolsVersion _12_0 = new MSBuildToolsVersion { Value = "12.0" };
        public static MSBuildToolsVersion _14_0 = new MSBuildToolsVersion { Value = "14.0" };
        public static MSBuildToolsVersion _15_0 = new MSBuildToolsVersion { Value = "15.0" };
    }
    #endregion
    #region MSBuildVerbosity
    /// <summary>
    ///   Used within <see cref="MSBuildTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<MSBuildVerbosity>))]
    public partial class MSBuildVerbosity : Enumeration
    {
        public static MSBuildVerbosity Quiet = new MSBuildVerbosity { Value = "Quiet" };
        public static MSBuildVerbosity Minimal = new MSBuildVerbosity { Value = "Minimal" };
        public static MSBuildVerbosity Normal = new MSBuildVerbosity { Value = "Normal" };
        public static MSBuildVerbosity Detailed = new MSBuildVerbosity { Value = "Detailed" };
        public static MSBuildVerbosity Diagnostic = new MSBuildVerbosity { Value = "Diagnostic" };
    }
    #endregion
    #region MSBuildTargetPlatform
    /// <summary>
    ///   Used within <see cref="MSBuildTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<MSBuildTargetPlatform>))]
    public partial class MSBuildTargetPlatform : Enumeration
    {
        public static MSBuildTargetPlatform MSIL = new MSBuildTargetPlatform { Value = "MSIL" };
        public static MSBuildTargetPlatform x86 = new MSBuildTargetPlatform { Value = "x86" };
        public static MSBuildTargetPlatform x64 = new MSBuildTargetPlatform { Value = "x64" };
        public static MSBuildTargetPlatform arm = new MSBuildTargetPlatform { Value = "arm" };
        public static MSBuildTargetPlatform Win32 = new MSBuildTargetPlatform { Value = "Win32" };
    }
    #endregion
    #region MSBuildSymbolPackageFormat
    /// <summary>
    ///   Used within <see cref="MSBuildTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<MSBuildSymbolPackageFormat>))]
    public partial class MSBuildSymbolPackageFormat : Enumeration
    {
        public static MSBuildSymbolPackageFormat symbols_nupkg = new MSBuildSymbolPackageFormat { Value = "symbols.nupkg" };
        public static MSBuildSymbolPackageFormat snupkg = new MSBuildSymbolPackageFormat { Value = "snupkg" };
    }
    #endregion
}
