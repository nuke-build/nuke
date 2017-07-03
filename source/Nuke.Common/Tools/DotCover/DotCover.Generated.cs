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
        static partial void PreProcess (DotCoverSettings dotCoverSettings);
        static partial void PostProcess (DotCoverSettings dotCoverSettings);
        /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
        public static void DotCover (Configure<DotCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotCoverSettings = new DotCoverSettings();
            dotCoverSettings = configurator(dotCoverSettings);
            PreProcess(dotCoverSettings);
            var process = StartProcess(dotCoverSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotCoverSettings);
        }
        /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
        public static void DotCover (Action testAction, Configure<DotCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotCover(x => configurator(x).SetTestAction(testAction));
        }
    }
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"JetBrains.dotCover.CommandLineTools", packageExecutable: $"{GetPackageExecutable()}");
        /// <summary><p>The action that executes tests.</p></summary>
        public virtual Action TestAction { get; internal set; }
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
        /// <summary><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
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
    public static partial class DotCoverSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.TestAction"/>.</i></p><p>The action that executes tests.</p></summary>
        [Pure]
        public static DotCoverSettings SetTestAction(this DotCoverSettings dotCoverSettings, Action testAction)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.TestAction = testAction;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.TargetExecutable"/>.</i></p><p>File name of the program to analyse.</p></summary>
        [Pure]
        public static DotCoverSettings SetTargetExecutable(this DotCoverSettings dotCoverSettings, string targetExecutable)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.TargetExecutable = targetExecutable;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.TargetArguments"/>.</i></p><p>Program arguments.</p></summary>
        [Pure]
        public static DotCoverSettings SetTargetArguments(this DotCoverSettings dotCoverSettings, string targetArguments)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.TargetArguments = targetArguments;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.TargetWorkingDirectory"/>.</i></p><p>Program working directory.</p></summary>
        [Pure]
        public static DotCoverSettings SetTargetWorkingDirectory(this DotCoverSettings dotCoverSettings, string targetWorkingDirectory)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.TargetWorkingDirectory = targetWorkingDirectory;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.TempDirectory"/>.</i></p><p>Directory for auxiliary files. Set to the system temp by default.</p></summary>
        [Pure]
        public static DotCoverSettings SetTempDirectory(this DotCoverSettings dotCoverSettings, string tempDirectory)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.TempDirectory = tempDirectory;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.ReportType"/>.</i></p><p>A type of the report. XML by default.</p></summary>
        [Pure]
        public static DotCoverSettings SetReportType(this DotCoverSettings dotCoverSettings, string reportType)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ReportType = reportType;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.OutputFile"/>.</i></p><p>Resulting report file name.</p></summary>
        [Pure]
        public static DotCoverSettings SetOutputFile(this DotCoverSettings dotCoverSettings, string outputFile)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.OutputFile = outputFile;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverSettings SetInheritConsole(this DotCoverSettings dotCoverSettings, bool inheritConsole)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.InheritConsole = inheritConsole;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverSettings EnableInheritConsole(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.InheritConsole = true;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverSettings DisableInheritConsole(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.InheritConsole = false;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverSettings ToggleInheritConsole(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.InheritConsole = !dotCoverSettings.InheritConsole;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverSettings SetAnalyseTargetArguments(this DotCoverSettings dotCoverSettings, bool analyseTargetArguments)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AnalyseTargetArguments = analyseTargetArguments;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverSettings EnableAnalyseTargetArguments(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AnalyseTargetArguments = true;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverSettings DisableAnalyseTargetArguments(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AnalyseTargetArguments = false;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverSettings ToggleAnalyseTargetArguments(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AnalyseTargetArguments = !dotCoverSettings.AnalyseTargetArguments;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.Scope"/> to a new list.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings SetScope(this DotCoverSettings dotCoverSettings, params string[] scope)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal = scope.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.Scope"/> to a new list.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings SetScope(this DotCoverSettings dotCoverSettings, IEnumerable<string> scope)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal = scope.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new scope to the existing <see cref="DotCoverSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings AddScope(this DotCoverSettings dotCoverSettings, params string[] scope)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal.AddRange(scope);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new scope to the existing <see cref="DotCoverSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings AddScope(this DotCoverSettings dotCoverSettings, IEnumerable<string> scope)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal.AddRange(scope);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings ClearScope(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal.Clear();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single scope to <see cref="DotCoverSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings AddScope(this DotCoverSettings dotCoverSettings, string scope)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal.Add(scope);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single scope from <see cref="DotCoverSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverSettings RemoveScope(this DotCoverSettings dotCoverSettings, string scope)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ScopeInternal.Remove(scope);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.Filters"/> to a new list.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings SetFilters(this DotCoverSettings dotCoverSettings, params string[] filters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal = filters.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.Filters"/> to a new list.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings SetFilters(this DotCoverSettings dotCoverSettings, IEnumerable<string> filters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal = filters.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="DotCoverSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddFilters(this DotCoverSettings dotCoverSettings, params string[] filters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal.AddRange(filters);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="DotCoverSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddFilters(this DotCoverSettings dotCoverSettings, IEnumerable<string> filters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal.AddRange(filters);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings ClearFilters(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal.Clear();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single filter to <see cref="DotCoverSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddFilter(this DotCoverSettings dotCoverSettings, string filter)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal.Add(filter);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single filter from <see cref="DotCoverSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings RemoveFilter(this DotCoverSettings dotCoverSettings, string filter)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.FiltersInternal.Remove(filter);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.AttributeFilters"/> to a new list.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings SetAttributeFilters(this DotCoverSettings dotCoverSettings, params string[] attributeFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.AttributeFilters"/> to a new list.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings SetAttributeFilters(this DotCoverSettings dotCoverSettings, IEnumerable<string> attributeFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new attributeFilters to the existing <see cref="DotCoverSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddAttributeFilters(this DotCoverSettings dotCoverSettings, params string[] attributeFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new attributeFilters to the existing <see cref="DotCoverSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddAttributeFilters(this DotCoverSettings dotCoverSettings, IEnumerable<string> attributeFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings ClearAttributeFilters(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal.Clear();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single attributeFilter to <see cref="DotCoverSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddAttributeFilter(this DotCoverSettings dotCoverSettings, string attributeFilter)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal.Add(attributeFilter);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single attributeFilter from <see cref="DotCoverSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverSettings RemoveAttributeFilter(this DotCoverSettings dotCoverSettings, string attributeFilter)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AttributeFiltersInternal.Remove(attributeFilter);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverSettings SetDisableDefaultFilters(this DotCoverSettings dotCoverSettings, bool disableDefaultFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.DisableDefaultFilters = disableDefaultFilters;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverSettings EnableDisableDefaultFilters(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.DisableDefaultFilters = true;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverSettings DisableDisableDefaultFilters(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.DisableDefaultFilters = false;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverSettings ToggleDisableDefaultFilters(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.DisableDefaultFilters = !dotCoverSettings.DisableDefaultFilters;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.SymbolSearchPaths"/> to a new list.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings SetSymbolSearchPaths(this DotCoverSettings dotCoverSettings, params string[] symbolSearchPaths)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.SymbolSearchPaths"/> to a new list.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings SetSymbolSearchPaths(this DotCoverSettings dotCoverSettings, IEnumerable<string> symbolSearchPaths)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new symbolSearchPaths to the existing <see cref="DotCoverSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddSymbolSearchPaths(this DotCoverSettings dotCoverSettings, params string[] symbolSearchPaths)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new symbolSearchPaths to the existing <see cref="DotCoverSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddSymbolSearchPaths(this DotCoverSettings dotCoverSettings, IEnumerable<string> symbolSearchPaths)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings ClearSymbolSearchPaths(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal.Clear();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single symbolSearchPath to <see cref="DotCoverSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings AddSymbolSearchPath(this DotCoverSettings dotCoverSettings, string symbolSearchPath)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal.Add(symbolSearchPath);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single symbolSearchPath from <see cref="DotCoverSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverSettings RemoveSymbolSearchPath(this DotCoverSettings dotCoverSettings, string symbolSearchPath)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.SymbolSearchPathsInternal.Remove(symbolSearchPath);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverSettings SetAllowSymbolServerAccess(this DotCoverSettings dotCoverSettings, bool allowSymbolServerAccess)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AllowSymbolServerAccess = allowSymbolServerAccess;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverSettings EnableAllowSymbolServerAccess(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AllowSymbolServerAccess = true;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverSettings DisableAllowSymbolServerAccess(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AllowSymbolServerAccess = false;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverSettings ToggleAllowSymbolServerAccess(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.AllowSymbolServerAccess = !dotCoverSettings.AllowSymbolServerAccess;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverSettings SetReturnTargetExitCode(this DotCoverSettings dotCoverSettings, bool returnTargetExitCode)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ReturnTargetExitCode = returnTargetExitCode;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverSettings EnableReturnTargetExitCode(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ReturnTargetExitCode = true;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverSettings DisableReturnTargetExitCode(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ReturnTargetExitCode = false;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverSettings ToggleReturnTargetExitCode(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ReturnTargetExitCode = !dotCoverSettings.ReturnTargetExitCode;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.ProcessFilters"/> to a new list.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings SetProcessFilters(this DotCoverSettings dotCoverSettings, params string[] processFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal = processFilters.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.ProcessFilters"/> to a new list.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings SetProcessFilters(this DotCoverSettings dotCoverSettings, IEnumerable<string> processFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal = processFilters.ToList();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new processFilters to the existing <see cref="DotCoverSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings AddProcessFilters(this DotCoverSettings dotCoverSettings, params string[] processFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal.AddRange(processFilters);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new processFilters to the existing <see cref="DotCoverSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings AddProcessFilters(this DotCoverSettings dotCoverSettings, IEnumerable<string> processFilters)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal.AddRange(processFilters);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings ClearProcessFilters(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal.Clear();
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single processFilter to <see cref="DotCoverSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings AddProcessFilter(this DotCoverSettings dotCoverSettings, string processFilter)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal.Add(processFilter);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single processFilter from <see cref="DotCoverSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverSettings RemoveProcessFilter(this DotCoverSettings dotCoverSettings, string processFilter)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.ProcessFiltersInternal.Remove(processFilter);
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverSettings SetHideAutoProperties(this DotCoverSettings dotCoverSettings, bool hideAutoProperties)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.HideAutoProperties = hideAutoProperties;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverSettings EnableHideAutoProperties(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.HideAutoProperties = true;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverSettings DisableHideAutoProperties(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.HideAutoProperties = false;
            return dotCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverSettings ToggleHideAutoProperties(this DotCoverSettings dotCoverSettings)
        {
            dotCoverSettings = dotCoverSettings.NewInstance();
            dotCoverSettings.HideAutoProperties = !dotCoverSettings.HideAutoProperties;
            return dotCoverSettings;
        }
    }
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p></summary>
    [PublicAPI]
    public enum DotCoverReportType
    {
        Html,
        Json,
        Xml,
        DetailedXml
    }
}
