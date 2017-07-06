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
        static partial void PreProcess (DotCoverAnalyseSettings dotCoverAnalyseSettings);
        static partial void PostProcess (DotCoverAnalyseSettings dotCoverAnalyseSettings);
        /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
        public static void DotCoverAnalyse (Configure<DotCoverAnalyseSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotCoverAnalyseSettings = new DotCoverAnalyseSettings();
            dotCoverAnalyseSettings = configurator(dotCoverAnalyseSettings);
            PreProcess(dotCoverAnalyseSettings);
            var process = StartProcess(dotCoverAnalyseSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotCoverAnalyseSettings);
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
    public static partial class DotCoverAnalyseSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.TestAction"/>.</i></p><p>The action that executes tests.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTestAction(this DotCoverAnalyseSettings dotCoverAnalyseSettings, Action testAction)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.TestAction = testAction;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.TargetExecutable"/>.</i></p><p>File name of the program to analyse.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTargetExecutable(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string targetExecutable)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.TargetExecutable = targetExecutable;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.TargetArguments"/>.</i></p><p>Program arguments.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTargetArguments(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string targetArguments)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.TargetArguments = targetArguments;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/>.</i></p><p>Program working directory.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTargetWorkingDirectory(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string targetWorkingDirectory)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.TargetWorkingDirectory = targetWorkingDirectory;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.TempDirectory"/>.</i></p><p>Directory for auxiliary files. Set to the system temp by default.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetTempDirectory(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string tempDirectory)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.TempDirectory = tempDirectory;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.ReportType"/>.</i></p><p>A type of the report. XML by default.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetReportType(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string reportType)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ReportType = reportType;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.OutputFile"/>.</i></p><p>Resulting report file name.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetOutputFile(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string outputFile)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.OutputFile = outputFile;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetInheritConsole(this DotCoverAnalyseSettings dotCoverAnalyseSettings, bool inheritConsole)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.InheritConsole = inheritConsole;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableInheritConsole(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.InheritConsole = true;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableInheritConsole(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.InheritConsole = false;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverAnalyseSettings.InheritConsole"/>.</i></p><p>Lets the analysed application to inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleInheritConsole(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.InheritConsole = !dotCoverAnalyseSettings.InheritConsole;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAnalyseTargetArguments(this DotCoverAnalyseSettings dotCoverAnalyseSettings, bool analyseTargetArguments)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AnalyseTargetArguments = analyseTargetArguments;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableAnalyseTargetArguments(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AnalyseTargetArguments = true;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableAnalyseTargetArguments(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AnalyseTargetArguments = false;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>.</i></p><p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleAnalyseTargetArguments(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AnalyseTargetArguments = !dotCoverAnalyseSettings.AnalyseTargetArguments;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.Scope"/> to a new list.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] scope)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal = scope.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.Scope"/> to a new list.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> scope)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal = scope.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new scope to the existing <see cref="DotCoverAnalyseSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] scope)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal.AddRange(scope);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new scope to the existing <see cref="DotCoverAnalyseSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> scope)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal.AddRange(scope);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverAnalyseSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal.Clear();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding a single scope to <see cref="DotCoverAnalyseSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string scope)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal.Add(scope);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for removing a single scope from <see cref="DotCoverAnalyseSettings.Scope"/>.</i></p><p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveScope(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string scope)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ScopeInternal.Remove(scope);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.Filters"/> to a new list.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] filters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal = filters.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.Filters"/> to a new list.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> filters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal = filters.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="DotCoverAnalyseSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] filters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal.AddRange(filters);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="DotCoverAnalyseSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> filters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal.AddRange(filters);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverAnalyseSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal.Clear();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding a single filter to <see cref="DotCoverAnalyseSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddFilter(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string filter)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal.Add(filter);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for removing a single filter from <see cref="DotCoverAnalyseSettings.Filters"/>.</i></p><p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveFilter(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string filter)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.FiltersInternal.Remove(filter);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.AttributeFilters"/> to a new list.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAttributeFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] attributeFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.AttributeFilters"/> to a new list.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAttributeFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> attributeFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new attributeFilters to the existing <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddAttributeFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] attributeFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new attributeFilters to the existing <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddAttributeFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> attributeFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearAttributeFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal.Clear();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding a single attributeFilter to <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddAttributeFilter(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string attributeFilter)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal.Add(attributeFilter);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for removing a single attributeFilter from <see cref="DotCoverAnalyseSettings.AttributeFilters"/>.</i></p><p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveAttributeFilter(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string attributeFilter)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AttributeFiltersInternal.Remove(attributeFilter);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetDisableDefaultFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, bool disableDefaultFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.DisableDefaultFilters = disableDefaultFilters;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableDisableDefaultFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.DisableDefaultFilters = true;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableDisableDefaultFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.DisableDefaultFilters = false;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>.</i></p><p>Disables default (automatically added) filters.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleDisableDefaultFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.DisableDefaultFilters = !dotCoverAnalyseSettings.DisableDefaultFilters;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/> to a new list.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetSymbolSearchPaths(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] symbolSearchPaths)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/> to a new list.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetSymbolSearchPaths(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> symbolSearchPaths)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new symbolSearchPaths to the existing <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddSymbolSearchPaths(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] symbolSearchPaths)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new symbolSearchPaths to the existing <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddSymbolSearchPaths(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> symbolSearchPaths)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearSymbolSearchPaths(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal.Clear();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding a single symbolSearchPath to <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddSymbolSearchPath(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string symbolSearchPath)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal.Add(symbolSearchPath);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for removing a single symbolSearchPath from <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>.</i></p><p>Specifies additional symbol search paths. Paths to symbol servers (starting with <i>srv*</i> prefix) are supported here.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveSymbolSearchPath(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string symbolSearchPath)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.SymbolSearchPathsInternal.Remove(symbolSearchPath);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetAllowSymbolServerAccess(this DotCoverAnalyseSettings dotCoverAnalyseSettings, bool allowSymbolServerAccess)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AllowSymbolServerAccess = allowSymbolServerAccess;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableAllowSymbolServerAccess(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AllowSymbolServerAccess = true;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableAllowSymbolServerAccess(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AllowSymbolServerAccess = false;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>.</i></p><p>Allows dotCover to search for PDB files on a symbol server.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleAllowSymbolServerAccess(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.AllowSymbolServerAccess = !dotCoverAnalyseSettings.AllowSymbolServerAccess;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetReturnTargetExitCode(this DotCoverAnalyseSettings dotCoverAnalyseSettings, bool returnTargetExitCode)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ReturnTargetExitCode = returnTargetExitCode;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableReturnTargetExitCode(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ReturnTargetExitCode = true;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableReturnTargetExitCode(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ReturnTargetExitCode = false;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>.</i></p><p>Returns the exit code of the target executable in case coverage analysis succeeded.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleReturnTargetExitCode(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ReturnTargetExitCode = !dotCoverAnalyseSettings.ReturnTargetExitCode;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.ProcessFilters"/> to a new list.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetProcessFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] processFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal = processFilters.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.ProcessFilters"/> to a new list.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetProcessFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> processFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal = processFilters.ToList();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new processFilters to the existing <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddProcessFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, params string[] processFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal.AddRange(processFilters);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding new processFilters to the existing <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddProcessFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings, IEnumerable<string> processFilters)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal.AddRange(processFilters);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ClearProcessFilters(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal.Clear();
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for adding a single processFilter to <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings AddProcessFilter(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string processFilter)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal.Add(processFilter);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for removing a single processFilter from <see cref="DotCoverAnalyseSettings.ProcessFilters"/>.</i></p><p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings RemoveProcessFilter(this DotCoverAnalyseSettings dotCoverAnalyseSettings, string processFilter)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.ProcessFiltersInternal.Remove(processFilter);
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings SetHideAutoProperties(this DotCoverAnalyseSettings dotCoverAnalyseSettings, bool hideAutoProperties)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.HideAutoProperties = hideAutoProperties;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings EnableHideAutoProperties(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.HideAutoProperties = true;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings DisableHideAutoProperties(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.HideAutoProperties = false;
            return dotCoverAnalyseSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotCoverAnalyseSettings.HideAutoProperties"/>.</i></p><p>Remove auto-implemented properties from report.</p></summary>
        [Pure]
        public static DotCoverAnalyseSettings ToggleHideAutoProperties(this DotCoverAnalyseSettings dotCoverAnalyseSettings)
        {
            dotCoverAnalyseSettings = dotCoverAnalyseSettings.NewInstance();
            dotCoverAnalyseSettings.HideAutoProperties = !dotCoverAnalyseSettings.HideAutoProperties;
            return dotCoverAnalyseSettings;
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
