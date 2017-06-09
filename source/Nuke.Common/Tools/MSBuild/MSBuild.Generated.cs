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

namespace Nuke.Common.Tools.MSBuild
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [IconClass("download2")]
    public static partial class MSBuildTasks
    {
        static partial void PreProcess (MSBuildSettings msbuildSettings);
        static partial void PostProcess (MSBuildSettings msbuildSettings);
        /// <summary>
        /// <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
        /// <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
        /// </summary>
        public static void MSBuild (Configure<MSBuildSettings> msbuildSettingsConfigure = null, ProcessSettings processSettings = null)
        {
            msbuildSettingsConfigure = msbuildSettingsConfigure ?? (x => x);
            var msbuildSettings = new MSBuildSettings();
            msbuildSettings = msbuildSettingsConfigure(msbuildSettings);
            PreProcess(msbuildSettings);
            var process = ProcessManager.Instance.StartProcess(msbuildSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(msbuildSettings);
        }
        /// <summary>
        /// <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
        /// <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
        /// </summary>
        public static void MSBuild (string targetPath, Configure<MSBuildSettings> msbuildSettingsConfigure = null, ProcessSettings processSettings = null)
        {
            msbuildSettingsConfigure = msbuildSettingsConfigure ?? (x => x);
            MSBuild(x => msbuildSettingsConfigure(x).SetTargetPath(targetPath));
        }
    }
    /// <summary>
    /// <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
    /// <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
    /// </summary>
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
        /// <summary><p>Display the startup banner or the copyright message.</p></summary>
        public virtual bool Logo { get; internal set; } = true;
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
              .Add("/nologo", !Logo)
              .Add("/property:{value}", Properties, keyValueSeparator: $"=")
              .Add("/target:{value}", Targets, mainSeparator: $";")
              .Add("/toolsversion:{value}", GetToolsVersion())
              .Add("/verbosity:{value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.TargetPath"/>.</i></p>
        /// <p>The solution or project file on which MSBuild is executed.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargetPath(this MSBuildSettings msbuildSettings, string targetPath)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetPath = targetPath;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.DetailedSummary"/>.</i></p>
        /// <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetDetailedSummary(this MSBuildSettings msbuildSettings, bool detailedSummary)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.DetailedSummary = detailedSummary;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="MSBuildSettings.DetailedSummary"/>.</i></p>
        /// <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableDetailedSummary(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.DetailedSummary = true;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="MSBuildSettings.DetailedSummary"/>.</i></p>
        /// <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableDetailedSummary(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.DetailedSummary = false;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="MSBuildSettings.DetailedSummary"/>.</i></p>
        /// <p>Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleDetailedSummary(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.DetailedSummary = !msbuildSettings.DetailedSummary;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.MaxCpuCount"/>.</i></p>
        /// <p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb651793.aspx">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetMaxCpuCount(this MSBuildSettings msbuildSettings, int? maxCpuCount)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.MaxCpuCount = maxCpuCount;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.NodeReuse"/>.</i></p>
        /// <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetNodeReuse(this MSBuildSettings msbuildSettings, bool? nodeReuse)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.NodeReuse = nodeReuse;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="MSBuildSettings.NodeReuse"/>.</i></p>
        /// <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableNodeReuse(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.NodeReuse = true;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="MSBuildSettings.NodeReuse"/>.</i></p>
        /// <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableNodeReuse(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.NodeReuse = false;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="MSBuildSettings.NodeReuse"/>.</i></p>
        /// <p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleNodeReuse(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.NodeReuse = !msbuildSettings.NodeReuse;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.Logo"/>.</i></p>
        /// <p>Display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetLogo(this MSBuildSettings msbuildSettings, bool logo)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.Logo = logo;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="MSBuildSettings.Logo"/>.</i></p>
        /// <p>Display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings EnableLogo(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.Logo = true;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="MSBuildSettings.Logo"/>.</i></p>
        /// <p>Display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings DisableLogo(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.Logo = false;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="MSBuildSettings.Logo"/>.</i></p>
        /// <p>Display the startup banner or the copyright message.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ToggleLogo(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.Logo = !msbuildSettings.Logo;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.Properties"/> to a new dictionary.</i></p>
        /// <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetProperties(this MSBuildSettings msbuildSettings, IDictionary<string, string> properties)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="MSBuildSettings.Properties"/>.</i></p>
        /// <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearProperties(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.PropertiesInternal.Clear();
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a property to <see cref="MSBuildSettings.Properties"/>.</i></p>
        /// <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddProperty(this MSBuildSettings msbuildSettings, string propertyKey, string propertyValue)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a property from <see cref="MSBuildSettings.Properties"/>.</i></p>
        /// <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveProperty(this MSBuildSettings msbuildSettings, string propertyKey)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.PropertiesInternal.Remove(propertyKey);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting a property in <see cref="MSBuildSettings.Properties"/>.</i></p>
        /// <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetProperty(this MSBuildSettings msbuildSettings, string propertyKey, string propertyValue)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.PropertiesInternal[propertyKey] = propertyValue;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.Targets"/> to a new list.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargets(this MSBuildSettings msbuildSettings, params string[] targets)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal = targets.ToList();
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.Targets"/> to a new list.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetTargets(this MSBuildSettings msbuildSettings, IEnumerable<string> targets)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal = targets.ToList();
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new targets to the existing <see cref="MSBuildSettings.Targets"/>.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddTargets(this MSBuildSettings msbuildSettings, params string[] targets)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal.AddRange(targets);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new targets to the existing <see cref="MSBuildSettings.Targets"/>.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddTargets(this MSBuildSettings msbuildSettings, IEnumerable<string> targets)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal.AddRange(targets);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="MSBuildSettings.Targets"/>.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings ClearTargets(this MSBuildSettings msbuildSettings)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal.Clear();
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single target to <see cref="MSBuildSettings.Targets"/>.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings AddTarget(this MSBuildSettings msbuildSettings, string target)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal.Add(target);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single target from <see cref="MSBuildSettings.Targets"/>.</i></p>
        /// <p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ee216359.aspx">Target Build Order</a> and <a href="https://msdn.microsoft.com/en-us/library/ms171463.aspx">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href="https://msdn.microsoft.com/en-us/library/ms171462.aspx">Targets</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings RemoveTarget(this MSBuildSettings msbuildSettings, string target)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.TargetsInternal.Remove(target);
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.ToolsVersion"/>.</i></p>
        /// <p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href="https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx">Project Element (MSBuild)</a>. For more information, see <a href="https://msdn.microsoft.com/en-us/library/bb383985.aspx">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href="https://msdn.microsoft.com/en-us/library/bb383796.aspx">Toolset (ToolsVersion)</a>, <a href="https://msdn.microsoft.com/en-us/library/bb397428.aspx">Standard and Custom Toolset Configurations</a>, and <a href="https://msdn.microsoft.com/en-us/library/hh264223.aspx">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href="https://msdn.microsoft.com/en-us/library/hh264221.aspx">Target Framework and Target Platform</a>.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetToolsVersion(this MSBuildSettings msbuildSettings, MSBuildToolsVersion? toolsVersion)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.ToolsVersion = toolsVersion;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.MSBuildVersion"/>.</i></p>
        /// <p>Specifies the version of MSBuild for building.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetMSBuildVersion(this MSBuildSettings msbuildSettings, MSBuildVersion? msbuildVersion)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.MSBuildVersion = msbuildVersion;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.Verbosity"/>.</i></p>
        /// <p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetVerbosity(this MSBuildSettings msbuildSettings, MSBuildVerbosity? verbosity)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.Verbosity = verbosity;
            return msbuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="MSBuildSettings.MSBuildPlatform"/>.</i></p>
        /// <p>Specifies the platform to use when building.</p>
        /// </summary>
        [Pure]
        public static MSBuildSettings SetMSBuildPlatform(this MSBuildSettings msbuildSettings, MSBuildPlatform? msbuildPlatform)
        {
            msbuildSettings = msbuildSettings.NewInstance();
            msbuildSettings.MSBuildPlatform = msbuildPlatform;
            return msbuildSettings;
        }
    }
    /// <summary>
    /// <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
    /// <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum MSBuildToolsVersion
    {
        _15_0,
        _14_0,
        _12_0
    }
    /// <summary>
    /// <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
    /// <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum MSBuildVerbosity
    {
        Quiet,
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }
    /// <summary>
    /// <p>The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.</p>
    /// <p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/ms164311.aspx">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum TargetPlatform
    {
        MSIL,
        x86,
        x64,
        arm,
        Win32
    }
}
