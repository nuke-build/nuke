// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/DotCover/DotCover.json

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

namespace Nuke.Common.Tools.DotCover
{
    /// <summary>
    ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
    ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(DotCoverPackageId)]
    public partial class DotCoverTasks
        : IRequireNuGetPackage
    {
        public const string DotCoverPackageId = "JetBrains.dotCover.DotNetCliTool";
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public static string DotCoverPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DOTCOVER_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> DotCoverLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotCover(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(DotCoverPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? DotCoverLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverAnalyseSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverAnalyseSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverAnalyseSettings.Filters"/></li>
        ///     <li><c>--HideAutoProperties</c> via <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverAnalyseSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverAnalyseSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverAnalyseSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverAnalyseSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverAnalyseSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverAnalyseSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverAnalyseSettings.TargetArguments"/></li>
        ///     <li><c>--TargetExecutable</c> via <see cref="DotCoverAnalyseSettings.TargetExecutable"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverAnalyseSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverAnalyse(DotCoverAnalyseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverAnalyseSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverAnalyseSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverAnalyseSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverAnalyseSettings.Filters"/></li>
        ///     <li><c>--HideAutoProperties</c> via <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverAnalyseSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverAnalyseSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverAnalyseSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverAnalyseSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverAnalyseSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverAnalyseSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverAnalyseSettings.TargetArguments"/></li>
        ///     <li><c>--TargetExecutable</c> via <see cref="DotCoverAnalyseSettings.TargetExecutable"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverAnalyseSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverAnalyse(Configure<DotCoverAnalyseSettings> configurator)
        {
            return DotCoverAnalyse(configurator(new DotCoverAnalyseSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverAnalyseSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverAnalyseSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverAnalyseSettings.Filters"/></li>
        ///     <li><c>--HideAutoProperties</c> via <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverAnalyseSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverAnalyseSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverAnalyseSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverAnalyseSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverAnalyseSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverAnalyseSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverAnalyseSettings.TargetArguments"/></li>
        ///     <li><c>--TargetExecutable</c> via <see cref="DotCoverAnalyseSettings.TargetExecutable"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverAnalyseSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverAnalyseSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverAnalyse(CombinatorialConfigure<DotCoverAnalyseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverAnalyse, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverCoverSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverCoverSettings.Filters"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverCoverSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverCoverSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverCoverSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverCoverSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverCoverSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverCoverSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverCoverSettings.TargetArguments"/></li>
        ///     <li><c>--TargetExecutable</c> via <see cref="DotCoverCoverSettings.TargetExecutable"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverCoverSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverCover(DotCoverCoverSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverCoverSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverCoverSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverCoverSettings.Filters"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverCoverSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverCoverSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverCoverSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverCoverSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverCoverSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverCoverSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverCoverSettings.TargetArguments"/></li>
        ///     <li><c>--TargetExecutable</c> via <see cref="DotCoverCoverSettings.TargetExecutable"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverCoverSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverCover(Configure<DotCoverCoverSettings> configurator)
        {
            return DotCoverCover(configurator(new DotCoverCoverSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverCoverSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverCoverSettings.Filters"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverCoverSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverCoverSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverCoverSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverCoverSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverCoverSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverCoverSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverCoverSettings.TargetArguments"/></li>
        ///     <li><c>--TargetExecutable</c> via <see cref="DotCoverCoverSettings.TargetExecutable"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverCoverSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverCoverSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverCover(CombinatorialConfigure<DotCoverCoverSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverCover, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverDotNetSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverCoverDotNetSettings.Filters"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverCoverDotNetSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverCoverDotNetSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverCoverDotNetSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverCoverDotNetSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverCoverDotNet(DotCoverCoverDotNetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverCoverDotNetSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverDotNetSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverCoverDotNetSettings.Filters"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverCoverDotNetSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverCoverDotNetSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverCoverDotNetSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverCoverDotNetSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverCoverDotNet(Configure<DotCoverCoverDotNetSettings> configurator)
        {
            return DotCoverCoverDotNet(configurator(new DotCoverCoverDotNetSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverDotNetSettings.Configuration"/></li>
        ///     <li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></li>
        ///     <li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></li>
        ///     <li><c>--AttributeFilters</c> via <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></li>
        ///     <li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></li>
        ///     <li><c>--Filters</c> via <see cref="DotCoverCoverDotNetSettings.Filters"/></li>
        ///     <li><c>--InheritConsole</c> via <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverCoverDotNetSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverCoverDotNetSettings.OutputFile"/></li>
        ///     <li><c>--ProcessFilters</c> via <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverCoverDotNetSettings.ReportType"/></li>
        ///     <li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></li>
        ///     <li><c>--Scope</c> via <see cref="DotCoverCoverDotNetSettings.Scope"/></li>
        ///     <li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></li>
        ///     <li><c>--TargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></li>
        ///     <li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverCoverDotNetSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverCoverDotNet(CombinatorialConfigure<DotCoverCoverDotNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverCoverDotNet, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverDeleteSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverDeleteSettings.LogFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverDeleteSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverDelete(DotCoverDeleteSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverDeleteSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverDeleteSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverDeleteSettings.LogFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverDeleteSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverDelete(Configure<DotCoverDeleteSettings> configurator)
        {
            return DotCoverDelete(configurator(new DotCoverDeleteSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverDeleteSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverDeleteSettings.LogFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverDeleteSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverDeleteSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverDelete(CombinatorialConfigure<DotCoverDeleteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverDelete, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverMergeSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverMergeSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverMergeSettings.OutputFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverMergeSettings.Source"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverMergeSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverMerge(DotCoverMergeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverMergeSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverMergeSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverMergeSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverMergeSettings.OutputFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverMergeSettings.Source"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverMergeSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverMerge(Configure<DotCoverMergeSettings> configurator)
        {
            return DotCoverMerge(configurator(new DotCoverMergeSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverMergeSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverMergeSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverMergeSettings.OutputFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverMergeSettings.Source"/></li>
        ///     <li><c>--TempDir</c> via <see cref="DotCoverMergeSettings.TempDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverMergeSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverMerge(CombinatorialConfigure<DotCoverMergeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverMerge, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverReportSettings.Configuration"/></li>
        ///     <li><c>--HideAutoProperties</c> via <see cref="DotCoverReportSettings.HideAutoProperties"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverReportSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverReportSettings.OutputFile"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverReportSettings.ReportType"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverReportSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverReport(DotCoverReportSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverReportSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverReportSettings.Configuration"/></li>
        ///     <li><c>--HideAutoProperties</c> via <see cref="DotCoverReportSettings.HideAutoProperties"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverReportSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverReportSettings.OutputFile"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverReportSettings.ReportType"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverReportSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverReport(Configure<DotCoverReportSettings> configurator)
        {
            return DotCoverReport(configurator(new DotCoverReportSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverReportSettings.Configuration"/></li>
        ///     <li><c>--HideAutoProperties</c> via <see cref="DotCoverReportSettings.HideAutoProperties"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverReportSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverReportSettings.OutputFile"/></li>
        ///     <li><c>--ReportType</c> via <see cref="DotCoverReportSettings.ReportType"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverReportSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverReportSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverReport(CombinatorialConfigure<DotCoverReportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverReport, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverZipSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverZipSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverZipSettings.OutputFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverZipSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverZip(DotCoverZipSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotCoverZipSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverZipSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverZipSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverZipSettings.OutputFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverZipSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotCoverZip(Configure<DotCoverZipSettings> configurator)
        {
            return DotCoverZip(configurator(new DotCoverZipSettings()));
        }
        /// <summary>
        ///   <p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configuration&gt;</c> via <see cref="DotCoverZipSettings.Configuration"/></li>
        ///     <li><c>--LogFile</c> via <see cref="DotCoverZipSettings.LogFile"/></li>
        ///     <li><c>--Output</c> via <see cref="DotCoverZipSettings.OutputFile"/></li>
        ///     <li><c>--Source</c> via <see cref="DotCoverZipSettings.Source"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotCoverZipSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverZip(CombinatorialConfigure<DotCoverZipSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotCoverZip, DotCoverLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DotCoverAnalyseSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverAnalyseSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   File name of the program to analyse.
        /// </summary>
        public virtual string TargetExecutable { get; internal set; }
        /// <summary>
        ///   A type of the report. The default value is <c>XML</c>.
        /// </summary>
        public virtual DotCoverReportType ReportType { get; internal set; }
        /// <summary>
        ///   Resulting report file name.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   Remove auto-implemented properties from report.
        /// </summary>
        public virtual bool? HideAutoProperties { get; internal set; }
        /// <summary>
        ///   Program arguments.
        /// </summary>
        public virtual string TargetArguments { get; internal set; }
        /// <summary>
        ///   Program working directory.
        /// </summary>
        public virtual string TargetWorkingDirectory { get; internal set; }
        /// <summary>
        ///   Directory for auxiliary files. Set to the system temp by default.
        /// </summary>
        public virtual string TempDirectory { get; internal set; }
        /// <summary>
        ///   Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.
        /// </summary>
        public virtual bool? InheritConsole { get; internal set; }
        /// <summary>
        ///   Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.
        /// </summary>
        public virtual bool? AnalyseTargetArguments { get; internal set; }
        /// <summary>
        ///   Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).
        /// </summary>
        public virtual IReadOnlyList<string> Scope => ScopeInternal.AsReadOnly();
        internal List<string> ScopeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.
        /// </summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.
        /// </summary>
        public virtual IReadOnlyList<string> AttributeFilters => AttributeFiltersInternal.AsReadOnly();
        internal List<string> AttributeFiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disables default (automatically added) filters.
        /// </summary>
        public virtual bool? DisableDefaultFilters { get; internal set; }
        /// <summary>
        ///   Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.
        /// </summary>
        public virtual IReadOnlyList<string> SymbolSearchPaths => SymbolSearchPathsInternal.AsReadOnly();
        internal List<string> SymbolSearchPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows dotCover to search for PDB files on a symbol server.
        /// </summary>
        public virtual bool? AllowSymbolServerAccess { get; internal set; }
        /// <summary>
        ///   Returns the exit code of the target executable in case coverage analysis succeeded.
        /// </summary>
        public virtual bool? ReturnTargetExitCode { get; internal set; }
        /// <summary>
        ///   Specifies process filters. Syntax: <c>+:process1;-:process2</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ProcessFilters => ProcessFiltersInternal.AsReadOnly();
        internal List<string> ProcessFiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("analyse")
              .Add("{value}", Configuration)
              .Add("--TargetExecutable={value}", TargetExecutable)
              .Add("--ReportType={value}", ReportType)
              .Add("--Output={value}", OutputFile)
              .Add("--HideAutoProperties", HideAutoProperties)
              .Add("--TargetArguments={value}", TargetArguments)
              .Add("--TargetWorkingDir={value}", TargetWorkingDirectory)
              .Add("--TempDir={value}", TempDirectory)
              .Add("--InheritConsole={value}", InheritConsole)
              .Add("--AnalyseTargetArguments={value}", AnalyseTargetArguments)
              .Add("--Scope={value}", Scope, separator: ';')
              .Add("--Filters={value}", Filters, separator: ';')
              .Add("--AttributeFilters={value}", AttributeFilters, separator: ';')
              .Add("--DisableDefaultFilters", DisableDefaultFilters)
              .Add("--SymbolSearchPaths={value}", SymbolSearchPaths, separator: ';')
              .Add("--AllowSymbolServerAccess", AllowSymbolServerAccess)
              .Add("--ReturnTargetExitCode", ReturnTargetExitCode)
              .Add("--ProcessFilters={value}", ProcessFilters, separator: ';')
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverCoverSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverCoverSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   File name of the program to analyse.
        /// </summary>
        public virtual string TargetExecutable { get; internal set; }
        /// <summary>
        ///   Path to the resulting coverage snapshot.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   A type of the report. The default value is <c>XML</c>.
        /// </summary>
        public virtual DotCoverReportType ReportType { get; internal set; }
        /// <summary>
        ///   Program arguments.
        /// </summary>
        public virtual string TargetArguments { get; internal set; }
        /// <summary>
        ///   Program working directory.
        /// </summary>
        public virtual string TargetWorkingDirectory { get; internal set; }
        /// <summary>
        ///   Directory for auxiliary files. Set to the system temp by default.
        /// </summary>
        public virtual string TempDirectory { get; internal set; }
        /// <summary>
        ///   Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.
        /// </summary>
        public virtual bool? InheritConsole { get; internal set; }
        /// <summary>
        ///   Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.
        /// </summary>
        public virtual bool? AnalyseTargetArguments { get; internal set; }
        /// <summary>
        ///   Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).
        /// </summary>
        public virtual IReadOnlyList<string> Scope => ScopeInternal.AsReadOnly();
        internal List<string> ScopeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.
        /// </summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.
        /// </summary>
        public virtual IReadOnlyList<string> AttributeFilters => AttributeFiltersInternal.AsReadOnly();
        internal List<string> AttributeFiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disables default (automatically added) filters.
        /// </summary>
        public virtual bool? DisableDefaultFilters { get; internal set; }
        /// <summary>
        ///   Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.
        /// </summary>
        public virtual IReadOnlyList<string> SymbolSearchPaths => SymbolSearchPathsInternal.AsReadOnly();
        internal List<string> SymbolSearchPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows dotCover to search for PDB files on a symbol server.
        /// </summary>
        public virtual bool? AllowSymbolServerAccess { get; internal set; }
        /// <summary>
        ///   Returns the exit code of the target executable in case coverage analysis succeeded.
        /// </summary>
        public virtual bool? ReturnTargetExitCode { get; internal set; }
        /// <summary>
        ///   Specifies process filters. Syntax: <c>+:process1;-:process2</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ProcessFilters => ProcessFiltersInternal.AsReadOnly();
        internal List<string> ProcessFiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("cover")
              .Add("{value}", Configuration)
              .Add("--TargetExecutable={value}", TargetExecutable)
              .Add("--Output={value}", OutputFile)
              .Add("--ReportType={value}", ReportType)
              .Add("--TargetArguments={value}", TargetArguments)
              .Add("--TargetWorkingDir={value}", TargetWorkingDirectory)
              .Add("--TempDir={value}", TempDirectory)
              .Add("--InheritConsole={value}", InheritConsole)
              .Add("--AnalyseTargetArguments={value}", AnalyseTargetArguments)
              .Add("--Scope={value}", Scope, separator: ';')
              .Add("--Filters={value}", Filters, separator: ';')
              .Add("--AttributeFilters={value}", AttributeFilters, separator: ';')
              .Add("--DisableDefaultFilters", DisableDefaultFilters)
              .Add("--SymbolSearchPaths={value}", SymbolSearchPaths, separator: ';')
              .Add("--AllowSymbolServerAccess", AllowSymbolServerAccess)
              .Add("--ReturnTargetExitCode", ReturnTargetExitCode)
              .Add("--ProcessFilters={value}", ProcessFilters, separator: ';')
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverCoverDotNetSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverCoverDotNetSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Path to the resulting coverage snapshot.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   A type of the report. The default value is <c>XML</c>.
        /// </summary>
        public virtual DotCoverReportType ReportType { get; internal set; }
        /// <summary>
        ///   Program arguments.
        /// </summary>
        public virtual string TargetArguments { get; internal set; }
        /// <summary>
        ///   Program working directory.
        /// </summary>
        public virtual string TargetWorkingDirectory { get; internal set; }
        /// <summary>
        ///   Directory for auxiliary files. Set to the system temp by default.
        /// </summary>
        public virtual string TempDirectory { get; internal set; }
        /// <summary>
        ///   Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.
        /// </summary>
        public virtual bool? InheritConsole { get; internal set; }
        /// <summary>
        ///   Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.
        /// </summary>
        public virtual bool? AnalyseTargetArguments { get; internal set; }
        /// <summary>
        ///   Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).
        /// </summary>
        public virtual IReadOnlyList<string> Scope => ScopeInternal.AsReadOnly();
        internal List<string> ScopeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.
        /// </summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.
        /// </summary>
        public virtual IReadOnlyList<string> AttributeFilters => AttributeFiltersInternal.AsReadOnly();
        internal List<string> AttributeFiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disables default (automatically added) filters.
        /// </summary>
        public virtual bool? DisableDefaultFilters { get; internal set; }
        /// <summary>
        ///   Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.
        /// </summary>
        public virtual IReadOnlyList<string> SymbolSearchPaths => SymbolSearchPathsInternal.AsReadOnly();
        internal List<string> SymbolSearchPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows dotCover to search for PDB files on a symbol server.
        /// </summary>
        public virtual bool? AllowSymbolServerAccess { get; internal set; }
        /// <summary>
        ///   Returns the exit code of the target executable in case coverage analysis succeeded.
        /// </summary>
        public virtual bool? ReturnTargetExitCode { get; internal set; }
        /// <summary>
        ///   Specifies process filters. Syntax: <c>+:process1;-:process2</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ProcessFilters => ProcessFiltersInternal.AsReadOnly();
        internal List<string> ProcessFiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("dotnet")
              .Add("{value}", Configuration)
              .Add("--Output={value}", OutputFile)
              .Add("--ReportType={value}", ReportType)
              .Add("--TargetArguments={value}", TargetArguments)
              .Add("--TargetWorkingDir={value}", TargetWorkingDirectory)
              .Add("--TempDir={value}", TempDirectory)
              .Add("--InheritConsole={value}", InheritConsole)
              .Add("--AnalyseTargetArguments={value}", AnalyseTargetArguments)
              .Add("--Scope={value}", Scope, separator: ';')
              .Add("--Filters={value}", Filters, separator: ';')
              .Add("--AttributeFilters={value}", AttributeFilters, separator: ';')
              .Add("--DisableDefaultFilters", DisableDefaultFilters)
              .Add("--SymbolSearchPaths={value}", SymbolSearchPaths, separator: ';')
              .Add("--AllowSymbolServerAccess", AllowSymbolServerAccess)
              .Add("--ReturnTargetExitCode", ReturnTargetExitCode)
              .Add("--ProcessFilters={value}", ProcessFilters, separator: ';')
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverDeleteSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverDeleteSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   List of snapshot files.
        /// </summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("delete")
              .Add("{value}", Configuration)
              .Add("--Source={value}", Source, separator: ';')
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverMergeSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverMergeSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   List of snapshot files.
        /// </summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   File name for the merged snapshot.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   Directory for auxiliary files. Set to the system temp by default.
        /// </summary>
        public virtual string TempDirectory { get; internal set; }
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("merge")
              .Add("{value}", Configuration)
              .Add("--Source={value}", Source, separator: ';')
              .Add("--Output={value}", OutputFile)
              .Add("--TempDir={value}", TempDirectory)
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverReportSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverReportSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   List of snapshot files.
        /// </summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Resulting report file name.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   A type of the report. The default value is <c>XML</c>.
        /// </summary>
        public virtual DotCoverReportType ReportType { get; internal set; }
        /// <summary>
        ///   Remove auto-implemented properties from report.
        /// </summary>
        public virtual bool? HideAutoProperties { get; internal set; }
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("report")
              .Add("{value}", Configuration)
              .Add("--Source={value}", Source, separator: ';')
              .Add("--Output={value}", OutputFile)
              .Add("--ReportType={value}", ReportType)
              .Add("--HideAutoProperties", HideAutoProperties)
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverZipSettings
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotCoverZipSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotCoverTasks.DotCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? DotCoverTasks.DotCoverLogger;
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Coverage snapshot file name.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Zipped snapshot file name.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   Enables logging and specifies log file name.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("zip")
              .Add("{value}", Configuration)
              .Add("--Source={value}", Source)
              .Add("--Output={value}", OutputFile)
              .Add("--LogFile={value}", LogFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DotCoverAnalyseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverAnalyseSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region TargetExecutable
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.TargetExecutable"/></em></p>
        ///   <p>File name of the program to analyse.</p>
        /// </summary>
        [Pure]
        public static T SetTargetExecutable<T>(this T toolSettings, string targetExecutable) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExecutable = targetExecutable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.TargetExecutable"/></em></p>
        ///   <p>File name of the program to analyse.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetExecutable<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExecutable = null;
            return toolSettings;
        }
        #endregion
        #region ReportType
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReportType<T>(this T toolSettings, DotCoverReportType reportType) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = reportType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetReportType<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.OutputFile"/></em></p>
        ///   <p>Resulting report file name.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.OutputFile"/></em></p>
        ///   <p>Resulting report file name.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region HideAutoProperties
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T SetHideAutoProperties<T>(this T toolSettings, bool? hideAutoProperties) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = hideAutoProperties;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T ResetHideAutoProperties<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T EnableHideAutoProperties<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T DisableHideAutoProperties<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T ToggleHideAutoProperties<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = !toolSettings.HideAutoProperties;
            return toolSettings;
        }
        #endregion
        #region TargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.TargetArguments"/></em></p>
        ///   <p>Program arguments.</p>
        /// </summary>
        [Pure]
        public static T SetTargetArguments<T>(this T toolSettings, string targetArguments) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.TargetArguments"/></em></p>
        ///   <p>Program arguments.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetArguments<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = null;
            return toolSettings;
        }
        #endregion
        #region TargetWorkingDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></em></p>
        ///   <p>Program working directory.</p>
        /// </summary>
        [Pure]
        public static T SetTargetWorkingDirectory<T>(this T toolSettings, string targetWorkingDirectory) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = targetWorkingDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></em></p>
        ///   <p>Program working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetWorkingDirectory<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = null;
            return toolSettings;
        }
        #endregion
        #region TempDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T SetTempDirectory<T>(this T toolSettings, string tempDirectory) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = tempDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T ResetTempDirectory<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = null;
            return toolSettings;
        }
        #endregion
        #region InheritConsole
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T SetInheritConsole<T>(this T toolSettings, bool? inheritConsole) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = inheritConsole;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T ResetInheritConsole<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverAnalyseSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T EnableInheritConsole<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverAnalyseSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T DisableInheritConsole<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverAnalyseSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T ToggleInheritConsole<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = !toolSettings.InheritConsole;
            return toolSettings;
        }
        #endregion
        #region AnalyseTargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T SetAnalyseTargetArguments<T>(this T toolSettings, bool? analyseTargetArguments) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = analyseTargetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = !toolSettings.AnalyseTargetArguments;
            return toolSettings;
        }
        #endregion
        #region Scope
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.Scope"/> to a new list</em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T SetScope<T>(this T toolSettings, params string[] scope) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.Scope"/> to a new list</em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T SetScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T AddScope<T>(this T toolSettings, params string[] scope) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T AddScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverAnalyseSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearScope<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveScope<T>(this T toolSettings, params string[] scope) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(scope);
            toolSettings.ScopeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(scope);
            toolSettings.ScopeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.Filters"/> to a new list</em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.Filters"/> to a new list</em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverAnalyseSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AttributeFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.AttributeFilters"/> to a new list</em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.AttributeFilters"/> to a new list</em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverAnalyseSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearAttributeFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeFilters);
            toolSettings.AttributeFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeFilters);
            toolSettings.AttributeFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableDefaultFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T SetDisableDefaultFilters<T>(this T toolSettings, bool? disableDefaultFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = disableDefaultFilters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = !toolSettings.DisableDefaultFilters;
            return toolSettings;
        }
        #endregion
        #region SymbolSearchPaths
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/> to a new list</em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/> to a new list</em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T AddSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T AddSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearSymbolSearchPaths<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(symbolSearchPaths);
            toolSettings.SymbolSearchPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(symbolSearchPaths);
            toolSettings.SymbolSearchPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AllowSymbolServerAccess
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T SetAllowSymbolServerAccess<T>(this T toolSettings, bool? allowSymbolServerAccess) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = allowSymbolServerAccess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = !toolSettings.AllowSymbolServerAccess;
            return toolSettings;
        }
        #endregion
        #region ReturnTargetExitCode
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T SetReturnTargetExitCode<T>(this T toolSettings, bool? returnTargetExitCode) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = returnTargetExitCode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T ResetReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T EnableReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T DisableReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T ToggleReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = !toolSettings.ReturnTargetExitCode;
            return toolSettings;
        }
        #endregion
        #region ProcessFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.ProcessFilters"/> to a new list</em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.ProcessFilters"/> to a new list</em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverAnalyseSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverAnalyseSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearProcessFilters<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(processFilters);
            toolSettings.ProcessFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverAnalyseSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(processFilters);
            toolSettings.ProcessFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverAnalyseSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverAnalyseSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverAnalyseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverCoverSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverCoverSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region TargetExecutable
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.TargetExecutable"/></em></p>
        ///   <p>File name of the program to analyse.</p>
        /// </summary>
        [Pure]
        public static T SetTargetExecutable<T>(this T toolSettings, string targetExecutable) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExecutable = targetExecutable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.TargetExecutable"/></em></p>
        ///   <p>File name of the program to analyse.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetExecutable<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExecutable = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.OutputFile"/></em></p>
        ///   <p>Path to the resulting coverage snapshot.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.OutputFile"/></em></p>
        ///   <p>Path to the resulting coverage snapshot.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ReportType
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReportType<T>(this T toolSettings, DotCoverReportType reportType) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = reportType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetReportType<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = null;
            return toolSettings;
        }
        #endregion
        #region TargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.TargetArguments"/></em></p>
        ///   <p>Program arguments.</p>
        /// </summary>
        [Pure]
        public static T SetTargetArguments<T>(this T toolSettings, string targetArguments) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.TargetArguments"/></em></p>
        ///   <p>Program arguments.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetArguments<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = null;
            return toolSettings;
        }
        #endregion
        #region TargetWorkingDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></em></p>
        ///   <p>Program working directory.</p>
        /// </summary>
        [Pure]
        public static T SetTargetWorkingDirectory<T>(this T toolSettings, string targetWorkingDirectory) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = targetWorkingDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></em></p>
        ///   <p>Program working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetWorkingDirectory<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = null;
            return toolSettings;
        }
        #endregion
        #region TempDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T SetTempDirectory<T>(this T toolSettings, string tempDirectory) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = tempDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T ResetTempDirectory<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = null;
            return toolSettings;
        }
        #endregion
        #region InheritConsole
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T SetInheritConsole<T>(this T toolSettings, bool? inheritConsole) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = inheritConsole;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T ResetInheritConsole<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T EnableInheritConsole<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T DisableInheritConsole<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T ToggleInheritConsole<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = !toolSettings.InheritConsole;
            return toolSettings;
        }
        #endregion
        #region AnalyseTargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T SetAnalyseTargetArguments<T>(this T toolSettings, bool? analyseTargetArguments) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = analyseTargetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = !toolSettings.AnalyseTargetArguments;
            return toolSettings;
        }
        #endregion
        #region Scope
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.Scope"/> to a new list</em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T SetScope<T>(this T toolSettings, params string[] scope) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.Scope"/> to a new list</em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T SetScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T AddScope<T>(this T toolSettings, params string[] scope) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T AddScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearScope<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveScope<T>(this T toolSettings, params string[] scope) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(scope);
            toolSettings.ScopeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(scope);
            toolSettings.ScopeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.Filters"/> to a new list</em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.Filters"/> to a new list</em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AttributeFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.AttributeFilters"/> to a new list</em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.AttributeFilters"/> to a new list</em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearAttributeFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeFilters);
            toolSettings.AttributeFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeFilters);
            toolSettings.AttributeFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableDefaultFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T SetDisableDefaultFilters<T>(this T toolSettings, bool? disableDefaultFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = disableDefaultFilters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = !toolSettings.DisableDefaultFilters;
            return toolSettings;
        }
        #endregion
        #region SymbolSearchPaths
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.SymbolSearchPaths"/> to a new list</em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.SymbolSearchPaths"/> to a new list</em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T AddSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T AddSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearSymbolSearchPaths<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(symbolSearchPaths);
            toolSettings.SymbolSearchPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(symbolSearchPaths);
            toolSettings.SymbolSearchPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AllowSymbolServerAccess
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T SetAllowSymbolServerAccess<T>(this T toolSettings, bool? allowSymbolServerAccess) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = allowSymbolServerAccess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = !toolSettings.AllowSymbolServerAccess;
            return toolSettings;
        }
        #endregion
        #region ReturnTargetExitCode
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T SetReturnTargetExitCode<T>(this T toolSettings, bool? returnTargetExitCode) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = returnTargetExitCode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T ResetReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T EnableReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T DisableReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T ToggleReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = !toolSettings.ReturnTargetExitCode;
            return toolSettings;
        }
        #endregion
        #region ProcessFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.ProcessFilters"/> to a new list</em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.ProcessFilters"/> to a new list</em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearProcessFilters<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(processFilters);
            toolSettings.ProcessFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(processFilters);
            toolSettings.ProcessFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverCoverDotNetSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverCoverDotNetSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.OutputFile"/></em></p>
        ///   <p>Path to the resulting coverage snapshot.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.OutputFile"/></em></p>
        ///   <p>Path to the resulting coverage snapshot.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ReportType
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReportType<T>(this T toolSettings, DotCoverReportType reportType) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = reportType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetReportType<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = null;
            return toolSettings;
        }
        #endregion
        #region TargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></em></p>
        ///   <p>Program arguments.</p>
        /// </summary>
        [Pure]
        public static T SetTargetArguments<T>(this T toolSettings, string targetArguments) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></em></p>
        ///   <p>Program arguments.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetArguments<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = null;
            return toolSettings;
        }
        #endregion
        #region TargetWorkingDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></em></p>
        ///   <p>Program working directory.</p>
        /// </summary>
        [Pure]
        public static T SetTargetWorkingDirectory<T>(this T toolSettings, string targetWorkingDirectory) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = targetWorkingDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></em></p>
        ///   <p>Program working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetWorkingDirectory<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetWorkingDirectory = null;
            return toolSettings;
        }
        #endregion
        #region TempDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T SetTempDirectory<T>(this T toolSettings, string tempDirectory) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = tempDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T ResetTempDirectory<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = null;
            return toolSettings;
        }
        #endregion
        #region InheritConsole
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T SetInheritConsole<T>(this T toolSettings, bool? inheritConsole) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = inheritConsole;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T ResetInheritConsole<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T EnableInheritConsole<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T DisableInheritConsole<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></em></p>
        ///   <p>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</p>
        /// </summary>
        [Pure]
        public static T ToggleInheritConsole<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InheritConsole = !toolSettings.InheritConsole;
            return toolSettings;
        }
        #endregion
        #region AnalyseTargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T SetAnalyseTargetArguments<T>(this T toolSettings, bool? analyseTargetArguments) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = analyseTargetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></em></p>
        ///   <p>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleAnalyseTargetArguments<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnalyseTargetArguments = !toolSettings.AnalyseTargetArguments;
            return toolSettings;
        }
        #endregion
        #region Scope
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.Scope"/> to a new list</em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T SetScope<T>(this T toolSettings, params string[] scope) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.Scope"/> to a new list</em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T SetScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal = scope.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T AddScope<T>(this T toolSettings, params string[] scope) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T AddScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.AddRange(scope);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverDotNetSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearScope<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScopeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveScope<T>(this T toolSettings, params string[] scope) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(scope);
            toolSettings.ScopeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.Scope"/></em></p>
        ///   <p>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveScope<T>(this T toolSettings, IEnumerable<string> scope) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(scope);
            toolSettings.ScopeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.Filters"/> to a new list</em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.Filters"/> to a new list</em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverDotNetSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, params string[] filters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.Filters"/></em></p>
        ///   <p>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AttributeFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/> to a new list</em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/> to a new list</em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T SetAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal = attributeFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T AddAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.AddRange(attributeFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearAttributeFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeFilters<T>(this T toolSettings, params string[] attributeFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeFilters);
            toolSettings.AttributeFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></em></p>
        ///   <p>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeFilters<T>(this T toolSettings, IEnumerable<string> attributeFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeFilters);
            toolSettings.AttributeFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableDefaultFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T SetDisableDefaultFilters<T>(this T toolSettings, bool? disableDefaultFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = disableDefaultFilters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></em></p>
        ///   <p>Disables default (automatically added) filters.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableDefaultFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilters = !toolSettings.DisableDefaultFilters;
            return toolSettings;
        }
        #endregion
        #region SymbolSearchPaths
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/> to a new list</em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/> to a new list</em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal = symbolSearchPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T AddSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T AddSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.AddRange(symbolSearchPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T ClearSymbolSearchPaths<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSearchPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveSymbolSearchPaths<T>(this T toolSettings, params string[] symbolSearchPaths) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(symbolSearchPaths);
            toolSettings.SymbolSearchPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></em></p>
        ///   <p>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</p>
        /// </summary>
        [Pure]
        public static T RemoveSymbolSearchPaths<T>(this T toolSettings, IEnumerable<string> symbolSearchPaths) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(symbolSearchPaths);
            toolSettings.SymbolSearchPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AllowSymbolServerAccess
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T SetAllowSymbolServerAccess<T>(this T toolSettings, bool? allowSymbolServerAccess) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = allowSymbolServerAccess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ResetAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T EnableAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T DisableAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></em></p>
        ///   <p>Allows dotCover to search for PDB files on a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowSymbolServerAccess<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowSymbolServerAccess = !toolSettings.AllowSymbolServerAccess;
            return toolSettings;
        }
        #endregion
        #region ReturnTargetExitCode
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T SetReturnTargetExitCode<T>(this T toolSettings, bool? returnTargetExitCode) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = returnTargetExitCode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T ResetReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T EnableReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T DisableReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></em></p>
        ///   <p>Returns the exit code of the target executable in case coverage analysis succeeded.</p>
        /// </summary>
        [Pure]
        public static T ToggleReturnTargetExitCode<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReturnTargetExitCode = !toolSettings.ReturnTargetExitCode;
            return toolSettings;
        }
        #endregion
        #region ProcessFilters
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/> to a new list</em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/> to a new list</em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal = processFilters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.AddRange(processFilters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearProcessFilters<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessFiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProcessFilters<T>(this T toolSettings, params string[] processFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(processFilters);
            toolSettings.ProcessFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></em></p>
        ///   <p>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProcessFilters<T>(this T toolSettings, IEnumerable<string> processFilters) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(processFilters);
            toolSettings.ProcessFiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverCoverDotNetSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverCoverDotNetSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverCoverDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverDeleteSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverDeleteSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverDeleteSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverDeleteSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverDeleteSettings.Source"/> to a new list</em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, params string[] source) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverDeleteSettings.Source"/> to a new list</em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverDeleteSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, params string[] source) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverDeleteSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverDeleteSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T ClearSource<T>(this T toolSettings) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverDeleteSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, params string[] source) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverDeleteSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverDeleteSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverDeleteSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverMergeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverMergeSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverMergeSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverMergeSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverMergeSettings.Source"/> to a new list</em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, params string[] source) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverMergeSettings.Source"/> to a new list</em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverMergeSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, params string[] source) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverMergeSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverMergeSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T ClearSource<T>(this T toolSettings) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverMergeSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, params string[] source) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverMergeSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverMergeSettings.OutputFile"/></em></p>
        ///   <p>File name for the merged snapshot.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverMergeSettings.OutputFile"/></em></p>
        ///   <p>File name for the merged snapshot.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region TempDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverMergeSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T SetTempDirectory<T>(this T toolSettings, string tempDirectory) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = tempDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverMergeSettings.TempDirectory"/></em></p>
        ///   <p>Directory for auxiliary files. Set to the system temp by default.</p>
        /// </summary>
        [Pure]
        public static T ResetTempDirectory<T>(this T toolSettings) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TempDirectory = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverMergeSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverMergeSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverMergeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverReportSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverReportSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverReportSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.Source"/> to a new list</em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, params string[] source) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.Source"/> to a new list</em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverReportSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, params string[] source) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotCoverReportSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotCoverReportSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T ClearSource<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverReportSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, params string[] source) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotCoverReportSettings.Source"/></em></p>
        ///   <p>List of snapshot files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, IEnumerable<string> source) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.OutputFile"/></em></p>
        ///   <p>Resulting report file name.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverReportSettings.OutputFile"/></em></p>
        ///   <p>Resulting report file name.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ReportType
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReportType<T>(this T toolSettings, DotCoverReportType reportType) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = reportType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverReportSettings.ReportType"/></em></p>
        ///   <p>A type of the report. The default value is <c>XML</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetReportType<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportType = null;
            return toolSettings;
        }
        #endregion
        #region HideAutoProperties
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T SetHideAutoProperties<T>(this T toolSettings, bool? hideAutoProperties) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = hideAutoProperties;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverReportSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T ResetHideAutoProperties<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotCoverReportSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T EnableHideAutoProperties<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotCoverReportSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T DisableHideAutoProperties<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotCoverReportSettings.HideAutoProperties"/></em></p>
        ///   <p>Remove auto-implemented properties from report.</p>
        /// </summary>
        [Pure]
        public static T ToggleHideAutoProperties<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideAutoProperties = !toolSettings.HideAutoProperties;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverReportSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverReportSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverReportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverZipSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotCoverZipSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverZipSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverZipSettings.Configuration"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverZipSettings.Source"/></em></p>
        ///   <p>Coverage snapshot file name.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverZipSettings.Source"/></em></p>
        ///   <p>Coverage snapshot file name.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverZipSettings.OutputFile"/></em></p>
        ///   <p>Zipped snapshot file name.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverZipSettings.OutputFile"/></em></p>
        ///   <p>Zipped snapshot file name.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotCoverZipSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotCoverZipSettings.LogFile"/></em></p>
        ///   <p>Enables logging and specifies log file name.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : DotCoverZipSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotCoverReportType
    /// <summary>
    ///   Used within <see cref="DotCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DotCoverReportType>))]
    public partial class DotCoverReportType : Enumeration
    {
        public static DotCoverReportType Html = (DotCoverReportType) "Html";
        public static DotCoverReportType Json = (DotCoverReportType) "Json";
        public static DotCoverReportType Xml = (DotCoverReportType) "Xml";
        public static DotCoverReportType DetailedXml = (DotCoverReportType) "DetailedXml";
        public static DotCoverReportType NDependXML = (DotCoverReportType) "NDependXML";
        public static implicit operator DotCoverReportType(string value)
        {
            return new DotCoverReportType { Value = value };
        }
    }
    #endregion
}
