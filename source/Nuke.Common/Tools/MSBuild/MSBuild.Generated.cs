// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

[assembly: IconClass(typeof(Nuke.Common.Tools.MSBuild.MSBuildTasks), "download2")]

namespace Nuke.Common.Tools.MSBuild
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MSBuildTasks
    {
        static partial void PreProcess (MSBuildSettings toolSettings);
        static partial void PostProcess (MSBuildSettings toolSettings);
        /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
        public static void MSBuild (Configure<MSBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new MSBuildSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p></summary>
        public static void MSBuild (string targetPath, Configure<MSBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            MSBuild(x => configurator(x).SetTargetPath(targetPath));
        }
    }
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MSBuildSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? MSBuildToolPathResolver.Resolve(MSBuildVersion, MSBuildPlatform);
        /// <summary><p>The solution or project file on which MSBuild is executed.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p></summary>
        public virtual bool DetailedSummary { get; internal set; }
        /// <summary><p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p></summary>
        public virtual int? MaxCpuCount { get; internal set; }
        /// <summary><p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p></summary>
        public virtual bool? NodeReuse { get; internal set; }
        /// <summary><p>Don't display the startup banner or the copyright message.</p></summary>
        public virtual bool NoLogo { get; internal set; }
        /// <summary><p>The target platform for which the project is built to run on.</p></summary>
        public virtual MSBuildTargetPlatform? TargetPlatform { get; internal set; }
        /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        public virtual IReadOnlyList<string> Targets => TargetsInternal.AsReadOnly();
        internal List<string> TargetsInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p></summary>
        public virtual MSBuildToolsVersion? ToolsVersion { get; internal set; }
        /// <summary><p>Specifies the version of MSBuild for building.</p></summary>
        public virtual MSBuildVersion? MSBuildVersion { get; internal set; }
        /// <summary><p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p></summary>
        public virtual MSBuildVerbosity? Verbosity { get; internal set; }
        /// <summary><p>Specifies the platform to use when building.</p></summary>
        public virtual MSBuildPlatform? MSBuildPlatform { get; internal set; }
        /// <summary><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        public virtual IReadOnlyList<string> Loggers => LoggersInternal.AsReadOnly();
        internal List<string> LoggersInternal { get; set; } = new List<string>();
        /// <summary><p>Disable the default console logger, and don't log events to the console.</p></summary>
        public virtual bool NoConsoleLogger { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath) || TargetPath == null, $"File.Exists(TargetPath) || TargetPath == null");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", TargetPath)
              .Add("/detailedsummary", DetailedSummary)
              .Add("/maxcpucount:{value}", MaxCpuCount)
              .Add("/nodeReuse:{value}", NodeReuse)
              .Add("/nologo", NoLogo)
              .Add("/property:Platform={value}", GetTargetPlatform())
              .Add("/property:{value}", Properties, keyValueSeparator: $"=")
              .Add("/target:{value}", Targets, mainSeparator: $";")
              .Add("/toolsversion:{value}", ToolsVersion)
              .Add("/verbosity:{value}", Verbosity)
              .Add("/logger:{value}", Loggers)
              .Add("/noconsolelogger", NoConsoleLogger);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.TargetPath"/>.</i></p><p>The solution or project file on which MSBuild is executed.</p></summary>
        [Pure]
        public static MSBuildSettings SetTargetPath(this MSBuildSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.DetailedSummary"/>.</i></p><p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p></summary>
        [Pure]
        public static MSBuildSettings SetDetailedSummary(this MSBuildSettings toolSettings, bool detailedSummary)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = detailedSummary;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="MSBuildSettings.DetailedSummary"/>.</i></p><p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p></summary>
        [Pure]
        public static MSBuildSettings EnableDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="MSBuildSettings.DetailedSummary"/>.</i></p><p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p></summary>
        [Pure]
        public static MSBuildSettings DisableDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="MSBuildSettings.DetailedSummary"/>.</i></p><p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p></summary>
        [Pure]
        public static MSBuildSettings ToggleDetailedSummary(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedSummary = !toolSettings.DetailedSummary;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.MaxCpuCount"/>.</i></p><p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p></summary>
        [Pure]
        public static MSBuildSettings SetMaxCpuCount(this MSBuildSettings toolSettings, int? maxCpuCount)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxCpuCount = maxCpuCount;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.NodeReuse"/>.</i></p><p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p></summary>
        [Pure]
        public static MSBuildSettings SetNodeReuse(this MSBuildSettings toolSettings, bool? nodeReuse)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = nodeReuse;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="MSBuildSettings.NodeReuse"/>.</i></p><p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p></summary>
        [Pure]
        public static MSBuildSettings EnableNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="MSBuildSettings.NodeReuse"/>.</i></p><p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p></summary>
        [Pure]
        public static MSBuildSettings DisableNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="MSBuildSettings.NodeReuse"/>.</i></p><p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p></summary>
        [Pure]
        public static MSBuildSettings ToggleNodeReuse(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeReuse = !toolSettings.NodeReuse;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.NoLogo"/>.</i></p><p>Don't display the startup banner or the copyright message.</p></summary>
        [Pure]
        public static MSBuildSettings SetNoLogo(this MSBuildSettings toolSettings, bool noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="MSBuildSettings.NoLogo"/>.</i></p><p>Don't display the startup banner or the copyright message.</p></summary>
        [Pure]
        public static MSBuildSettings EnableNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="MSBuildSettings.NoLogo"/>.</i></p><p>Don't display the startup banner or the copyright message.</p></summary>
        [Pure]
        public static MSBuildSettings DisableNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="MSBuildSettings.NoLogo"/>.</i></p><p>Don't display the startup banner or the copyright message.</p></summary>
        [Pure]
        public static MSBuildSettings ToggleNoLogo(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.TargetPlatform"/>.</i></p><p>The target platform for which the project is built to run on.</p></summary>
        [Pure]
        public static MSBuildSettings SetTargetPlatform(this MSBuildSettings toolSettings, MSBuildTargetPlatform? targetPlatform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPlatform = targetPlatform;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.Properties"/> to a new dictionary.</i></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static MSBuildSettings SetProperties(this MSBuildSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="MSBuildSettings.Properties"/>.</i></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static MSBuildSettings ClearProperties(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a property to <see cref="MSBuildSettings.Properties"/>.</i></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static MSBuildSettings AddProperty(this MSBuildSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a property from <see cref="MSBuildSettings.Properties"/>.</i></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static MSBuildSettings RemoveProperty(this MSBuildSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting a property in <see cref="MSBuildSettings.Properties"/>.</i></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static MSBuildSettings SetProperty(this MSBuildSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.Targets"/> to a new list.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings SetTargets(this MSBuildSettings toolSettings, params string[] targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal = targets.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.Targets"/> to a new list.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings SetTargets(this MSBuildSettings toolSettings, IEnumerable<string> targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal = targets.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new targets to the existing <see cref="MSBuildSettings.Targets"/>.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings AddTargets(this MSBuildSettings toolSettings, params string[] targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.AddRange(targets);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new targets to the existing <see cref="MSBuildSettings.Targets"/>.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings AddTargets(this MSBuildSettings toolSettings, IEnumerable<string> targets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.AddRange(targets);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="MSBuildSettings.Targets"/>.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings ClearTargets(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single target to <see cref="MSBuildSettings.Targets"/>.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings AddTarget(this MSBuildSettings toolSettings, string target, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (target != null || evenIfNull) toolSettings.TargetsInternal.Add(target);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single target from <see cref="MSBuildSettings.Targets"/>.</i></p><p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p></summary>
        [Pure]
        public static MSBuildSettings RemoveTarget(this MSBuildSettings toolSettings, string target)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetsInternal.Remove(target);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.ToolsVersion"/>.</i></p><p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p></summary>
        [Pure]
        public static MSBuildSettings SetToolsVersion(this MSBuildSettings toolSettings, MSBuildToolsVersion? toolsVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsVersion = toolsVersion;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.MSBuildVersion"/>.</i></p><p>Specifies the version of MSBuild for building.</p></summary>
        [Pure]
        public static MSBuildSettings SetMSBuildVersion(this MSBuildSettings toolSettings, MSBuildVersion? msbuildVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.Verbosity"/>.</i></p><p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p></summary>
        [Pure]
        public static MSBuildSettings SetVerbosity(this MSBuildSettings toolSettings, MSBuildVerbosity? verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.MSBuildPlatform"/>.</i></p><p>Specifies the platform to use when building.</p></summary>
        [Pure]
        public static MSBuildSettings SetMSBuildPlatform(this MSBuildSettings toolSettings, MSBuildPlatform? msbuildPlatform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPlatform = msbuildPlatform;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.Loggers"/> to a new list.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings SetLoggers(this MSBuildSettings toolSettings, params string[] loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal = loggers.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.Loggers"/> to a new list.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings SetLoggers(this MSBuildSettings toolSettings, IEnumerable<string> loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal = loggers.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new loggers to the existing <see cref="MSBuildSettings.Loggers"/>.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings AddLoggers(this MSBuildSettings toolSettings, params string[] loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.AddRange(loggers);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new loggers to the existing <see cref="MSBuildSettings.Loggers"/>.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings AddLoggers(this MSBuildSettings toolSettings, IEnumerable<string> loggers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.AddRange(loggers);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="MSBuildSettings.Loggers"/>.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings ClearLoggers(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single logger to <see cref="MSBuildSettings.Loggers"/>.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings AddLogger(this MSBuildSettings toolSettings, string logger, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (logger != null || evenIfNull) toolSettings.LoggersInternal.Add(logger);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single logger from <see cref="MSBuildSettings.Loggers"/>.</i></p><p>Specifies the loggers to use to log events from MSBuild.</p></summary>
        [Pure]
        public static MSBuildSettings RemoveLogger(this MSBuildSettings toolSettings, string logger)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.Remove(logger);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="MSBuildSettings.NoConsoleLogger"/>.</i></p><p>Disable the default console logger, and don't log events to the console.</p></summary>
        [Pure]
        public static MSBuildSettings SetNoConsoleLogger(this MSBuildSettings toolSettings, bool noConsoleLogger)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = noConsoleLogger;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="MSBuildSettings.NoConsoleLogger"/>.</i></p><p>Disable the default console logger, and don't log events to the console.</p></summary>
        [Pure]
        public static MSBuildSettings EnableNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="MSBuildSettings.NoConsoleLogger"/>.</i></p><p>Disable the default console logger, and don't log events to the console.</p></summary>
        [Pure]
        public static MSBuildSettings DisableNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="MSBuildSettings.NoConsoleLogger"/>.</i></p><p>Disable the default console logger, and don't log events to the console.</p></summary>
        [Pure]
        public static MSBuildSettings ToggleNoConsoleLogger(this MSBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = !toolSettings.NoConsoleLogger;
            return toolSettings;
        }
    }
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p></summary>
    [PublicAPI]
    public enum MSBuildToolsVersion
    {
        [FriendlyString("2.0")]
        _2_0,
        [FriendlyString("3.5,")]
        _3_5_,
        [FriendlyString("4.0")]
        _4_0,
        [FriendlyString("12.0")]
        _12_0,
        [FriendlyString("14.0")]
        _14_0,
        [FriendlyString("15.0")]
        _15_0,
    }
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p></summary>
    [PublicAPI]
    public enum MSBuildVerbosity
    {
        Quiet,
        Minimal,
        Normal,
        Detailed,
        Diagnostic,
    }
    /// <summary><p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p></summary>
    [PublicAPI]
    public enum MSBuildTargetPlatform
    {
        MSIL,
        x86,
        x64,
        arm,
        Win32,
    }
}
