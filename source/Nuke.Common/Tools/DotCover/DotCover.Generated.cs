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

[assembly: IconClass(typeof(Nuke.Common.Tools.DotCover.DotCoverTasks), "shield2")]

namespace Nuke.Common.Tools.DotCover
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverTasks
    {
        static partial void PreProcess (DotCoverAnalyseSettings toolSettings);
        static partial void PostProcess (DotCoverAnalyseSettings toolSettings);
        /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
        public static void DotCoverAnalyse (Configure<DotCoverAnalyseSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotCoverAnalyseSettings());
            PreProcess(toolSettings);
            var process = StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
        public static void DotCoverAnalyse (Action testAction, Configure<DotCoverAnalyseSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotCoverAnalyse(x => configurator(x).SetTestAction(testAction));
        }
    }
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverAnalyseSettings : ToolSettings
    {
        /// <summary>Path of the executable to be invoked.</summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"JetBrains.dotCover.CommandLineTools", packageExecutable: $"{GetPackageExecutable()}");
        /// <summary><p>File name of the program to analyse.</p></summary>
        public virtual string TargetExecutable { get; internal set; }
        /// <summary><p>Program arguments.</p></summary>
        public virtual string TargetArguments { get; internal set; }
        /// <summary><p>Program working directory.</p></summary>
        public virtual string TargetWorkingDirectory { get; internal set; }
        /// <summary><p>Directory for auxiliary files. Set to the system temp by default.</p></summary>
        public virtual string TempDirectory { get; internal set; }
        /// <summary><p>A type of the report. XML by default.</p></summary>
        public virtual string ReportType { get; internal set; }
        /// <summary><p>Resulting report file name.</p></summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        public virtual bool InheritConsole { get; internal set; }
        /// <summary><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        public virtual bool AnalyseTargetArguments { get; internal set; }
        /// <summary><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        public virtual IReadOnlyList<string> Scope => ScopeInternal.AsReadOnly();
        internal List<string> ScopeInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        public virtual IReadOnlyList<string> AttributeFilters => AttributeFiltersInternal.AsReadOnly();
        internal List<string> AttributeFiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Disables default (automatically added) filters.</p></summary>
        public virtual bool DisableDefaultFilters { get; internal set; }
        /// <summary><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        public virtual IReadOnlyList<string> SymbolSearchPaths => SymbolSearchPathsInternal.AsReadOnly();
        internal List<string> SymbolSearchPathsInternal { get; set; } = new List<string>();
        /// <summary><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        public virtual bool AllowSymbolServerAccess { get; internal set; }
        /// <summary><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        public virtual bool ReturnTargetExitCode { get; internal set; }
        /// <summary><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        public virtual IReadOnlyList<string> ProcessFilters => ProcessFiltersInternal.AsReadOnly();
        internal List<string> ProcessFiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Remove auto-implemented properties from report.</p></summary>
        public virtual bool HideAutoProperties { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("analyse")
              .Add("/TargetExecutable={value}", TargetExecutable)
              .Add("/TargetArguments={value}", TargetArguments)
              .Add("/TargetWorkingDir={value}", TargetWorkingDirectory)
              .Add("/TempDir={value}", TempDirectory)
              .Add("/ReportType={value}", ReportType)
              .Add("/Output={value}", OutputFile)
              .Add("/InheritConsole={value}", InheritConsole)
              .Add("/AnalyseTargetArguments={value}", AnalyseTargetArguments)
              .Add("/Scope={value}", Scope, mainSeparator: $";")
              .Add("/Filters={value}", Filters, mainSeparator: $";")
              .Add("/AttributeFilters={value}", AttributeFilters, mainSeparator: $";")
              .Add("/DisableDefaultFilters", DisableDefaultFilters)
              .Add("/SymbolSearchPaths={value}", SymbolSearchPaths, mainSeparator: $";")
              .Add("/AllowSymbolServerAccess", AllowSymbolServerAccess)
              .Add("/ReturnTargetExitCode", ReturnTargetExitCode)
              .Add("/ProcessFilters={value}", ProcessFilters, mainSeparator: $";")
              .Add("/HideAutoProperties", HideAutoProperties);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverAnalyseSettingsExtensions
    {
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.TargetExecutable"/>.</em></p><p>File name of the program to analyse.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTargetExecutable(this DotCoverAnalyseSettings toolSettings, string targetExecutable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExecutable = targetExecutable;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.TargetArguments"/>.</em></p><p>Program arguments.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTargetArguments(this DotCoverAnalyseSettings toolSettings, string targetArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/>.</em></p><p>Program working directory.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTargetWorkingDirectory(this DotCoverAnalyseSettings toolSettings, string targetWorkingDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = targetWorkingDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.TempDirectory"/>.</em></p><p>Directory for auxiliary files. Set to the system temp by default.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTempDirectory(this DotCoverAnalyseSettings toolSettings, string tempDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = tempDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.ReportType"/>.</em></p><p>A type of the report. XML by default.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetReportType(this DotCoverAnalyseSettings toolSettings, string reportType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = reportType;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.OutputFile"/>.</em></p><p>Resulting report file name.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetOutputFile(this DotCoverAnalyseSettings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</em></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetInheritConsole(this DotCoverAnalyseSettings toolSettings, bool inheritConsole)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = inheritConsole;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</em></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableInheritConsole(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</em></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableInheritConsole(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</em></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleInheritConsole(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = !toolSettings.InheritConsole;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</em></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAnalyseTargetArguments(this DotCoverAnalyseSettings toolSettings, bool analyseTargetArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = analyseTargetArguments;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</em></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableAnalyseTargetArguments(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</em></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableAnalyseTargetArguments(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</em></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleAnalyseTargetArguments(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = !toolSettings.AnalyseTargetArguments;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.Scope"/> to a new list.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetScope(this DotCoverAnalyseSettings toolSettings, params string[] scope)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.Scope"/> to a new list.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetScope(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> scope)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a scope to the existing <see cref="DotCoverAnalyseSettings.Scope"/>.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddScope(this DotCoverAnalyseSettings toolSettings, params string[] scope)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary><p><em>Adds a scope to the existing <see cref="DotCoverAnalyseSettings.Scope"/>.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddScope(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> scope)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotCoverAnalyseSettings.Scope"/>.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearScope(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single scope to <see cref="DotCoverAnalyseSettings.Scope"/>.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddScope(this DotCoverAnalyseSettings toolSettings, string scope, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (scope != null || evenIfNull) toolSettings.ScopeInternal.Add(scope);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single scope from <see cref="DotCoverAnalyseSettings.Scope"/>.</em></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveScope(this DotCoverAnalyseSettings toolSettings, string scope)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = toolSettings.Scope.Where(x => x == scope).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.Filters"/> to a new list.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetFilters(this DotCoverAnalyseSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.Filters"/> to a new list.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetFilters(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a filters to the existing <see cref="DotCoverAnalyseSettings.Filters"/>.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddFilters(this DotCoverAnalyseSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><em>Adds a filters to the existing <see cref="DotCoverAnalyseSettings.Filters"/>.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddFilters(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotCoverAnalyseSettings.Filters"/>.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearFilters(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single filter to <see cref="DotCoverAnalyseSettings.Filters"/>.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddFilter(this DotCoverAnalyseSettings toolSettings, string filter, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (filter != null || evenIfNull) toolSettings.FiltersInternal.Add(filter);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single filter from <see cref="DotCoverAnalyseSettings.Filters"/>.</em></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveFilter(this DotCoverAnalyseSettings toolSettings, string filter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = toolSettings.Filters.Where(x => x == filter).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.AttributeFilters"/> to a new list.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAttributeFilters(this DotCoverAnalyseSettings toolSettings, params string[] attributeFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.AttributeFilters"/> to a new list.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAttributeFilters(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> attributeFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a attributeFilters to the existing <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddAttributeFilters(this DotCoverAnalyseSettings toolSettings, params string[] attributeFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary><p><em>Adds a attributeFilters to the existing <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddAttributeFilters(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> attributeFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearAttributeFilters(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single attributeFilter to <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddAttributeFilter(this DotCoverAnalyseSettings toolSettings, string attributeFilter, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (attributeFilter != null || evenIfNull) toolSettings.AttributeFiltersInternal.Add(attributeFilter);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single attributeFilter from <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</em></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveAttributeFilter(this DotCoverAnalyseSettings toolSettings, string attributeFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = toolSettings.AttributeFilters.Where(x => x == attributeFilter).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</em></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetDisableDefaultFilters(this DotCoverAnalyseSettings toolSettings, bool disableDefaultFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = disableDefaultFilters;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</em></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableDisableDefaultFilters(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</em></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableDisableDefaultFilters(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</em></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleDisableDefaultFilters(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = !toolSettings.DisableDefaultFilters;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/> to a new list.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetSymbolSearchPaths(this DotCoverAnalyseSettings toolSettings, params string[] symbolSearchPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/> to a new list.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetSymbolSearchPaths(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> symbolSearchPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a symbolSearchPaths to the existing <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddSymbolSearchPaths(this DotCoverAnalyseSettings toolSettings, params string[] symbolSearchPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds a symbolSearchPaths to the existing <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddSymbolSearchPaths(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> symbolSearchPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearSymbolSearchPaths(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single symbolSearchPath to <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddSymbolSearchPath(this DotCoverAnalyseSettings toolSettings, string symbolSearchPath, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (symbolSearchPath != null || evenIfNull) toolSettings.SymbolSearchPathsInternal.Add(symbolSearchPath);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single symbolSearchPath from <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</em></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveSymbolSearchPath(this DotCoverAnalyseSettings toolSettings, string symbolSearchPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = toolSettings.SymbolSearchPaths.Where(x => x == symbolSearchPath).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</em></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAllowSymbolServerAccess(this DotCoverAnalyseSettings toolSettings, bool allowSymbolServerAccess)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = allowSymbolServerAccess;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</em></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableAllowSymbolServerAccess(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</em></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableAllowSymbolServerAccess(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</em></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleAllowSymbolServerAccess(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = !toolSettings.AllowSymbolServerAccess;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</em></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetReturnTargetExitCode(this DotCoverAnalyseSettings toolSettings, bool returnTargetExitCode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = returnTargetExitCode;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</em></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableReturnTargetExitCode(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</em></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableReturnTargetExitCode(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</em></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleReturnTargetExitCode(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = !toolSettings.ReturnTargetExitCode;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.ProcessFilters"/> to a new list.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetProcessFilters(this DotCoverAnalyseSettings toolSettings, params string[] processFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.ProcessFilters"/> to a new list.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetProcessFilters(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> processFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a processFilters to the existing <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddProcessFilters(this DotCoverAnalyseSettings toolSettings, params string[] processFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary><p><em>Adds a processFilters to the existing <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddProcessFilters(this DotCoverAnalyseSettings toolSettings, IEnumerable<string> processFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearProcessFilters(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single processFilter to <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddProcessFilter(this DotCoverAnalyseSettings toolSettings, string processFilter, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (processFilter != null || evenIfNull) toolSettings.ProcessFiltersInternal.Add(processFilter);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single processFilter from <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</em></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveProcessFilter(this DotCoverAnalyseSettings toolSettings, string processFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = toolSettings.ProcessFilters.Where(x => x == processFilter).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</em></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetHideAutoProperties(this DotCoverAnalyseSettings toolSettings, bool hideAutoProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = hideAutoProperties;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</em></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableHideAutoProperties(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</em></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableHideAutoProperties(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</em></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleHideAutoProperties(this DotCoverAnalyseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = !toolSettings.HideAutoProperties;
            return toolSettings;
        }
    }
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p></summary>
    [PublicAPI]
    public enum DotCoverReportType
    {
        Html,
        Json,
        Xml,
        DetailedXml,
    }
}
