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

namespace Nuke.Common.Tools.DotCover;

/// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId)]
public partial class DotCoverTasks : ToolTasks, IRequireNuGetPackage
{
    public static string DotCoverPath => new DotCoverTasks().GetToolPath();
    public const string PackageId = "JetBrains.dotCover.DotNetCliTool|JetBrains.dotCover.CommandLineTools";
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> DotCover(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new DotCoverTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverAnalyseSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverAnalyseSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverAnalyseSettings.Filters"/></li><li><c>--HideAutoProperties</c> via <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverAnalyseSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverAnalyseSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverAnalyseSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverAnalyseSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverAnalyseSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverAnalyseSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverAnalyseSettings.TargetArguments"/></li><li><c>--TargetExecutable</c> via <see cref="DotCoverAnalyseSettings.TargetExecutable"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverAnalyseSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverAnalyse(DotCoverAnalyseSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverAnalyseSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverAnalyseSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverAnalyseSettings.Filters"/></li><li><c>--HideAutoProperties</c> via <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverAnalyseSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverAnalyseSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverAnalyseSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverAnalyseSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverAnalyseSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverAnalyseSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverAnalyseSettings.TargetArguments"/></li><li><c>--TargetExecutable</c> via <see cref="DotCoverAnalyseSettings.TargetExecutable"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverAnalyseSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverAnalyse(Configure<DotCoverAnalyseSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverAnalyseSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverAnalyseSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverAnalyseSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverAnalyseSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverAnalyseSettings.Filters"/></li><li><c>--HideAutoProperties</c> via <see cref="DotCoverAnalyseSettings.HideAutoProperties"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverAnalyseSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverAnalyseSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverAnalyseSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverAnalyseSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverAnalyseSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverAnalyseSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverAnalyseSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverAnalyseSettings.TargetArguments"/></li><li><c>--TargetExecutable</c> via <see cref="DotCoverAnalyseSettings.TargetExecutable"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverAnalyseSettings.TempDirectory"/></li></ul></remarks>
    public static IEnumerable<(DotCoverAnalyseSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverAnalyse(CombinatorialConfigure<DotCoverAnalyseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverAnalyse, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverCoverSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverCoverSettings.Filters"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverCoverSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverCoverSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverCoverSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverCoverSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverCoverSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverCoverSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverCoverSettings.TargetArguments"/></li><li><c>--TargetExecutable</c> via <see cref="DotCoverCoverSettings.TargetExecutable"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverCoverSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverCover(DotCoverCoverSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverCoverSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverCoverSettings.Filters"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverCoverSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverCoverSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverCoverSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverCoverSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverCoverSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverCoverSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverCoverSettings.TargetArguments"/></li><li><c>--TargetExecutable</c> via <see cref="DotCoverCoverSettings.TargetExecutable"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverCoverSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverCover(Configure<DotCoverCoverSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverCoverSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverCoverSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverCoverSettings.Filters"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverCoverSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverCoverSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverCoverSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverCoverSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverCoverSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverCoverSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverCoverSettings.TargetArguments"/></li><li><c>--TargetExecutable</c> via <see cref="DotCoverCoverSettings.TargetExecutable"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverCoverSettings.TempDirectory"/></li></ul></remarks>
    public static IEnumerable<(DotCoverCoverSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverCover(CombinatorialConfigure<DotCoverCoverSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverCover, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverDotNetSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverCoverDotNetSettings.Filters"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverCoverDotNetSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverCoverDotNetSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverCoverDotNetSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverCoverDotNetSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverCoverDotNet(DotCoverCoverDotNetSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverDotNetSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverCoverDotNetSettings.Filters"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverCoverDotNetSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverCoverDotNetSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverCoverDotNetSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverCoverDotNetSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverCoverDotNet(Configure<DotCoverCoverDotNetSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverCoverDotNetSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverCoverDotNetSettings.Configuration"/></li><li><c>--AllowSymbolServerAccess</c> via <see cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/></li><li><c>--AnalyseTargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/></li><li><c>--AttributeFilters</c> via <see cref="DotCoverCoverDotNetSettings.AttributeFilters"/></li><li><c>--DisableDefaultFilters</c> via <see cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/></li><li><c>--Filters</c> via <see cref="DotCoverCoverDotNetSettings.Filters"/></li><li><c>--InheritConsole</c> via <see cref="DotCoverCoverDotNetSettings.InheritConsole"/></li><li><c>--LogFile</c> via <see cref="DotCoverCoverDotNetSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverCoverDotNetSettings.OutputFile"/></li><li><c>--ProcessFilters</c> via <see cref="DotCoverCoverDotNetSettings.ProcessFilters"/></li><li><c>--ReportType</c> via <see cref="DotCoverCoverDotNetSettings.ReportType"/></li><li><c>--ReturnTargetExitCode</c> via <see cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/></li><li><c>--Scope</c> via <see cref="DotCoverCoverDotNetSettings.Scope"/></li><li><c>--SymbolSearchPaths</c> via <see cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/></li><li><c>--TargetArguments</c> via <see cref="DotCoverCoverDotNetSettings.TargetArguments"/></li><li><c>--TargetWorkingDir</c> via <see cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/></li><li><c>--TempDir</c> via <see cref="DotCoverCoverDotNetSettings.TempDirectory"/></li></ul></remarks>
    public static IEnumerable<(DotCoverCoverDotNetSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverCoverDotNet(CombinatorialConfigure<DotCoverCoverDotNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverCoverDotNet, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverDeleteSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverDeleteSettings.LogFile"/></li><li><c>--Source</c> via <see cref="DotCoverDeleteSettings.Source"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverDelete(DotCoverDeleteSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverDeleteSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverDeleteSettings.LogFile"/></li><li><c>--Source</c> via <see cref="DotCoverDeleteSettings.Source"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverDelete(Configure<DotCoverDeleteSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverDeleteSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverDeleteSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverDeleteSettings.LogFile"/></li><li><c>--Source</c> via <see cref="DotCoverDeleteSettings.Source"/></li></ul></remarks>
    public static IEnumerable<(DotCoverDeleteSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverDelete(CombinatorialConfigure<DotCoverDeleteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverDelete, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverMergeSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverMergeSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverMergeSettings.OutputFile"/></li><li><c>--Source</c> via <see cref="DotCoverMergeSettings.Source"/></li><li><c>--TempDir</c> via <see cref="DotCoverMergeSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverMerge(DotCoverMergeSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverMergeSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverMergeSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverMergeSettings.OutputFile"/></li><li><c>--Source</c> via <see cref="DotCoverMergeSettings.Source"/></li><li><c>--TempDir</c> via <see cref="DotCoverMergeSettings.TempDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverMerge(Configure<DotCoverMergeSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverMergeSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverMergeSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverMergeSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverMergeSettings.OutputFile"/></li><li><c>--Source</c> via <see cref="DotCoverMergeSettings.Source"/></li><li><c>--TempDir</c> via <see cref="DotCoverMergeSettings.TempDirectory"/></li></ul></remarks>
    public static IEnumerable<(DotCoverMergeSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverMerge(CombinatorialConfigure<DotCoverMergeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverMerge, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverReportSettings.Configuration"/></li><li><c>--HideAutoProperties</c> via <see cref="DotCoverReportSettings.HideAutoProperties"/></li><li><c>--LogFile</c> via <see cref="DotCoverReportSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverReportSettings.OutputFile"/></li><li><c>--ReportType</c> via <see cref="DotCoverReportSettings.ReportType"/></li><li><c>--Source</c> via <see cref="DotCoverReportSettings.Source"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverReport(DotCoverReportSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverReportSettings.Configuration"/></li><li><c>--HideAutoProperties</c> via <see cref="DotCoverReportSettings.HideAutoProperties"/></li><li><c>--LogFile</c> via <see cref="DotCoverReportSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverReportSettings.OutputFile"/></li><li><c>--ReportType</c> via <see cref="DotCoverReportSettings.ReportType"/></li><li><c>--Source</c> via <see cref="DotCoverReportSettings.Source"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverReport(Configure<DotCoverReportSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverReportSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverReportSettings.Configuration"/></li><li><c>--HideAutoProperties</c> via <see cref="DotCoverReportSettings.HideAutoProperties"/></li><li><c>--LogFile</c> via <see cref="DotCoverReportSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverReportSettings.OutputFile"/></li><li><c>--ReportType</c> via <see cref="DotCoverReportSettings.ReportType"/></li><li><c>--Source</c> via <see cref="DotCoverReportSettings.Source"/></li></ul></remarks>
    public static IEnumerable<(DotCoverReportSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverReport(CombinatorialConfigure<DotCoverReportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverReport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverZipSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverZipSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverZipSettings.OutputFile"/></li><li><c>--Source</c> via <see cref="DotCoverZipSettings.Source"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverZip(DotCoverZipSettings options = null) => new DotCoverTasks().Run(options);
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverZipSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverZipSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverZipSettings.OutputFile"/></li><li><c>--Source</c> via <see cref="DotCoverZipSettings.Source"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotCoverZip(Configure<DotCoverZipSettings> configurator) => new DotCoverTasks().Run(configurator.Invoke(new DotCoverZipSettings()));
    /// <summary><p>dotCover is a .NET unit testing and code coverage tool that works right in Visual Studio, helps you know to what extent your code is covered with unit tests, provides great ways to visualize code coverage, and is Continuous Integration ready. dotCover calculates and reports statement-level code coverage in applications targeting .NET Framework, Silverlight, and .NET Core.</p><p>For more details, visit the <a href="https://www.jetbrains.com/dotcover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configuration&gt;</c> via <see cref="DotCoverZipSettings.Configuration"/></li><li><c>--LogFile</c> via <see cref="DotCoverZipSettings.LogFile"/></li><li><c>--Output</c> via <see cref="DotCoverZipSettings.OutputFile"/></li><li><c>--Source</c> via <see cref="DotCoverZipSettings.Source"/></li></ul></remarks>
    public static IEnumerable<(DotCoverZipSettings Settings, IReadOnlyCollection<Output> Output)> DotCoverZip(CombinatorialConfigure<DotCoverZipSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotCoverZip, degreeOfParallelism, completeOnFailure);
}
#region DotCoverAnalyseSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverAnalyseSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverAnalyse), Arguments = "analyse")]
public partial class DotCoverAnalyseSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>File name of the program to analyse.</summary>
    [Argument(Format = "--TargetExecutable={value}")] public string TargetExecutable => Get<string>(() => TargetExecutable);
    /// <summary>A type of the report. The default value is <c>XML</c>.</summary>
    [Argument(Format = "--ReportType={value}")] public DotCoverReportType ReportType => Get<DotCoverReportType>(() => ReportType);
    /// <summary>Resulting report file name.</summary>
    [Argument(Format = "--Output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Remove auto-implemented properties from report.</summary>
    [Argument(Format = "--HideAutoProperties")] public bool? HideAutoProperties => Get<bool?>(() => HideAutoProperties);
    /// <summary>Program arguments.</summary>
    [Argument(Format = "--TargetArguments={value}")] public string TargetArguments => Get<string>(() => TargetArguments);
    /// <summary>Program working directory.</summary>
    [Argument(Format = "--TargetWorkingDir={value}")] public string TargetWorkingDirectory => Get<string>(() => TargetWorkingDirectory);
    /// <summary>Directory for auxiliary files. Set to the system temp by default.</summary>
    [Argument(Format = "--TempDir={value}")] public string TempDirectory => Get<string>(() => TempDirectory);
    /// <summary>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</summary>
    [Argument(Format = "--InheritConsole={value}")] public bool? InheritConsole => Get<bool?>(() => InheritConsole);
    /// <summary>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</summary>
    [Argument(Format = "--AnalyseTargetArguments={value}")] public bool? AnalyseTargetArguments => Get<bool?>(() => AnalyseTargetArguments);
    /// <summary>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</summary>
    [Argument(Format = "--Scope={value}", Separator = ";")] public IReadOnlyList<string> Scope => Get<List<string>>(() => Scope);
    /// <summary>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</summary>
    [Argument(Format = "--Filters={value}", Separator = ";")] public IReadOnlyList<string> Filters => Get<List<string>>(() => Filters);
    /// <summary>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</summary>
    [Argument(Format = "--AttributeFilters={value}", Separator = ";")] public IReadOnlyList<string> AttributeFilters => Get<List<string>>(() => AttributeFilters);
    /// <summary>Disables default (automatically added) filters.</summary>
    [Argument(Format = "--DisableDefaultFilters")] public bool? DisableDefaultFilters => Get<bool?>(() => DisableDefaultFilters);
    /// <summary>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</summary>
    [Argument(Format = "--SymbolSearchPaths={value}", Separator = ";")] public IReadOnlyList<string> SymbolSearchPaths => Get<List<string>>(() => SymbolSearchPaths);
    /// <summary>Allows dotCover to search for PDB files on a symbol server.</summary>
    [Argument(Format = "--AllowSymbolServerAccess")] public bool? AllowSymbolServerAccess => Get<bool?>(() => AllowSymbolServerAccess);
    /// <summary>Returns the exit code of the target executable in case coverage analysis succeeded.</summary>
    [Argument(Format = "--ReturnTargetExitCode")] public bool? ReturnTargetExitCode => Get<bool?>(() => ReturnTargetExitCode);
    /// <summary>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</summary>
    [Argument(Format = "--ProcessFilters={value}", Separator = ";")] public IReadOnlyList<string> ProcessFilters => Get<List<string>>(() => ProcessFilters);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverCoverSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverCoverSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverCover), Arguments = "cover")]
public partial class DotCoverCoverSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>File name of the program to analyse.</summary>
    [Argument(Format = "--TargetExecutable={value}")] public string TargetExecutable => Get<string>(() => TargetExecutable);
    /// <summary>Path to the resulting coverage snapshot.</summary>
    [Argument(Format = "--Output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>A type of the report. The default value is <c>XML</c>.</summary>
    [Argument(Format = "--ReportType={value}")] public DotCoverReportType ReportType => Get<DotCoverReportType>(() => ReportType);
    /// <summary>Program arguments.</summary>
    [Argument(Format = "--TargetArguments={value}")] public string TargetArguments => Get<string>(() => TargetArguments);
    /// <summary>Program working directory.</summary>
    [Argument(Format = "--TargetWorkingDir={value}")] public string TargetWorkingDirectory => Get<string>(() => TargetWorkingDirectory);
    /// <summary>Directory for auxiliary files. Set to the system temp by default.</summary>
    [Argument(Format = "--TempDir={value}")] public string TempDirectory => Get<string>(() => TempDirectory);
    /// <summary>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</summary>
    [Argument(Format = "--InheritConsole={value}")] public bool? InheritConsole => Get<bool?>(() => InheritConsole);
    /// <summary>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</summary>
    [Argument(Format = "--AnalyseTargetArguments={value}")] public bool? AnalyseTargetArguments => Get<bool?>(() => AnalyseTargetArguments);
    /// <summary>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</summary>
    [Argument(Format = "--Scope={value}", Separator = ";")] public IReadOnlyList<string> Scope => Get<List<string>>(() => Scope);
    /// <summary>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</summary>
    [Argument(Format = "--Filters={value}", Separator = ";")] public IReadOnlyList<string> Filters => Get<List<string>>(() => Filters);
    /// <summary>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</summary>
    [Argument(Format = "--AttributeFilters={value}", Separator = ";")] public IReadOnlyList<string> AttributeFilters => Get<List<string>>(() => AttributeFilters);
    /// <summary>Disables default (automatically added) filters.</summary>
    [Argument(Format = "--DisableDefaultFilters")] public bool? DisableDefaultFilters => Get<bool?>(() => DisableDefaultFilters);
    /// <summary>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</summary>
    [Argument(Format = "--SymbolSearchPaths={value}", Separator = ";")] public IReadOnlyList<string> SymbolSearchPaths => Get<List<string>>(() => SymbolSearchPaths);
    /// <summary>Allows dotCover to search for PDB files on a symbol server.</summary>
    [Argument(Format = "--AllowSymbolServerAccess")] public bool? AllowSymbolServerAccess => Get<bool?>(() => AllowSymbolServerAccess);
    /// <summary>Returns the exit code of the target executable in case coverage analysis succeeded.</summary>
    [Argument(Format = "--ReturnTargetExitCode")] public bool? ReturnTargetExitCode => Get<bool?>(() => ReturnTargetExitCode);
    /// <summary>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</summary>
    [Argument(Format = "--ProcessFilters={value}", Separator = ";")] public IReadOnlyList<string> ProcessFilters => Get<List<string>>(() => ProcessFilters);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverCoverDotNetSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverCoverDotNetSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverCoverDotNet), Arguments = "dotnet")]
public partial class DotCoverCoverDotNetSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>Path to the resulting coverage snapshot.</summary>
    [Argument(Format = "--Output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>A type of the report. The default value is <c>XML</c>.</summary>
    [Argument(Format = "--ReportType={value}")] public DotCoverReportType ReportType => Get<DotCoverReportType>(() => ReportType);
    /// <summary>Program arguments.</summary>
    [Argument(Format = "--TargetArguments={value}")] public string TargetArguments => Get<string>(() => TargetArguments);
    /// <summary>Program working directory.</summary>
    [Argument(Format = "--TargetWorkingDir={value}")] public string TargetWorkingDirectory => Get<string>(() => TargetWorkingDirectory);
    /// <summary>Directory for auxiliary files. Set to the system temp by default.</summary>
    [Argument(Format = "--TempDir={value}")] public string TempDirectory => Get<string>(() => TempDirectory);
    /// <summary>Lets the analysed application inherit dotCover console. The default is <c>true</c>. Please note that windows of the analysed GUI application will not be hidden if the console is inherited.</summary>
    [Argument(Format = "--InheritConsole={value}")] public bool? InheritConsole => Get<bool?>(() => InheritConsole);
    /// <summary>Specifies whether dotCover should analyse the 'target arguments' string and convert relative paths to absolute ones. The default is <c>true</c>.</summary>
    [Argument(Format = "--AnalyseTargetArguments={value}")] public bool? AnalyseTargetArguments => Get<bool?>(() => AnalyseTargetArguments);
    /// <summary>Allows including assemblies that were not loaded in the specified scope into coverage results. Ant-style patterns are supported here (e.g. <c>ProjectFolder/**/*.dll</c>).</summary>
    [Argument(Format = "--Scope={value}", Separator = ";")] public IReadOnlyList<string> Scope => Get<List<string>>(() => Scope);
    /// <summary>Specifies coverage filters using the following syntax: <c>+:module=*;class=*;function=*;</c>. Use <c>-:myassembly</c> to exclude an assembly from code coverage. Asterisk wildcard (*) is supported here.</summary>
    [Argument(Format = "--Filters={value}", Separator = ";")] public IReadOnlyList<string> Filters => Get<List<string>>(() => Filters);
    /// <summary>Specifies attribute filters using the following syntax: <c>filter1;filter2;...</c>. Asterisk wildcard (*) is supported here.</summary>
    [Argument(Format = "--AttributeFilters={value}", Separator = ";")] public IReadOnlyList<string> AttributeFilters => Get<List<string>>(() => AttributeFilters);
    /// <summary>Disables default (automatically added) filters.</summary>
    [Argument(Format = "--DisableDefaultFilters")] public bool? DisableDefaultFilters => Get<bool?>(() => DisableDefaultFilters);
    /// <summary>Specifies additional symbol search paths. Paths to symbol servers (starting with <em>srv*</em> prefix) are supported here.</summary>
    [Argument(Format = "--SymbolSearchPaths={value}", Separator = ";")] public IReadOnlyList<string> SymbolSearchPaths => Get<List<string>>(() => SymbolSearchPaths);
    /// <summary>Allows dotCover to search for PDB files on a symbol server.</summary>
    [Argument(Format = "--AllowSymbolServerAccess")] public bool? AllowSymbolServerAccess => Get<bool?>(() => AllowSymbolServerAccess);
    /// <summary>Returns the exit code of the target executable in case coverage analysis succeeded.</summary>
    [Argument(Format = "--ReturnTargetExitCode")] public bool? ReturnTargetExitCode => Get<bool?>(() => ReturnTargetExitCode);
    /// <summary>Specifies process filters. Syntax: <c>+:process1;-:process2</c>.</summary>
    [Argument(Format = "--ProcessFilters={value}", Separator = ";")] public IReadOnlyList<string> ProcessFilters => Get<List<string>>(() => ProcessFilters);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverDeleteSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverDeleteSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverDelete), Arguments = "delete")]
public partial class DotCoverDeleteSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>List of snapshot files.</summary>
    [Argument(Format = "--Source={value}", Separator = ";")] public IReadOnlyList<string> Source => Get<List<string>>(() => Source);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverMergeSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverMergeSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverMerge), Arguments = "merge")]
public partial class DotCoverMergeSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>List of snapshot files.</summary>
    [Argument(Format = "--Source={value}", Separator = ";")] public IReadOnlyList<string> Source => Get<List<string>>(() => Source);
    /// <summary>File name for the merged snapshot.</summary>
    [Argument(Format = "--Output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Directory for auxiliary files. Set to the system temp by default.</summary>
    [Argument(Format = "--TempDir={value}")] public string TempDirectory => Get<string>(() => TempDirectory);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverReportSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverReportSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverReport), Arguments = "report")]
public partial class DotCoverReportSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>List of snapshot files.</summary>
    [Argument(Format = "--Source={value}", Separator = ";")] public IReadOnlyList<string> Source => Get<List<string>>(() => Source);
    /// <summary>Resulting report file name.</summary>
    [Argument(Format = "--Output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>A type of the report. The default value is <c>XML</c>.</summary>
    [Argument(Format = "--ReportType={value}")] public DotCoverReportType ReportType => Get<DotCoverReportType>(() => ReportType);
    /// <summary>Remove auto-implemented properties from report.</summary>
    [Argument(Format = "--HideAutoProperties")] public bool? HideAutoProperties => Get<bool?>(() => HideAutoProperties);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverZipSettings
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotCoverZipSettings>))]
[Command(Type = typeof(DotCoverTasks), Command = nameof(DotCoverTasks.DotCoverZip), Arguments = "zip")]
public partial class DotCoverZipSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Configuration => Get<string>(() => Configuration);
    /// <summary>Coverage snapshot file name.</summary>
    [Argument(Format = "--Source={value}")] public string Source => Get<string>(() => Source);
    /// <summary>Zipped snapshot file name.</summary>
    [Argument(Format = "--Output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Enables logging and specifies log file name.</summary>
    [Argument(Format = "--LogFile={value}")] public string LogFile => Get<string>(() => LogFile);
}
#endregion
#region DotCoverAnalyseSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverAnalyseSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverAnalyseSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region TargetExecutable
    /// <inheritdoc cref="DotCoverAnalyseSettings.TargetExecutable"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TargetExecutable))]
    public static T SetTargetExecutable<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.TargetExecutable, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.TargetExecutable"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TargetExecutable))]
    public static T ResetTargetExecutable<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.TargetExecutable));
    #endregion
    #region ReportType
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReportType))]
    public static T SetReportType<T>(this T o, DotCoverReportType v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ReportType, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReportType))]
    public static T ResetReportType<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.ReportType));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="DotCoverAnalyseSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region HideAutoProperties
    /// <inheritdoc cref="DotCoverAnalyseSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.HideAutoProperties))]
    public static T SetHideAutoProperties<T>(this T o, bool? v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.HideAutoProperties))]
    public static T ResetHideAutoProperties<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.HideAutoProperties));
    /// <inheritdoc cref="DotCoverAnalyseSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.HideAutoProperties))]
    public static T EnableHideAutoProperties<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, true));
    /// <inheritdoc cref="DotCoverAnalyseSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.HideAutoProperties))]
    public static T DisableHideAutoProperties<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, false));
    /// <inheritdoc cref="DotCoverAnalyseSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.HideAutoProperties))]
    public static T ToggleHideAutoProperties<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, !o.HideAutoProperties));
    #endregion
    #region TargetArguments
    /// <inheritdoc cref="DotCoverAnalyseSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TargetArguments))]
    public static T SetTargetArguments<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.TargetArguments, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TargetArguments))]
    public static T ResetTargetArguments<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.TargetArguments));
    #endregion
    #region TargetWorkingDirectory
    /// <inheritdoc cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TargetWorkingDirectory))]
    public static T SetTargetWorkingDirectory<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.TargetWorkingDirectory, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.TargetWorkingDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TargetWorkingDirectory))]
    public static T ResetTargetWorkingDirectory<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.TargetWorkingDirectory));
    #endregion
    #region TempDirectory
    /// <inheritdoc cref="DotCoverAnalyseSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TempDirectory))]
    public static T SetTempDirectory<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.TempDirectory, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.TempDirectory))]
    public static T ResetTempDirectory<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.TempDirectory));
    #endregion
    #region InheritConsole
    /// <inheritdoc cref="DotCoverAnalyseSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.InheritConsole))]
    public static T SetInheritConsole<T>(this T o, bool? v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.InheritConsole, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.InheritConsole))]
    public static T ResetInheritConsole<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.InheritConsole));
    /// <inheritdoc cref="DotCoverAnalyseSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.InheritConsole))]
    public static T EnableInheritConsole<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.InheritConsole, true));
    /// <inheritdoc cref="DotCoverAnalyseSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.InheritConsole))]
    public static T DisableInheritConsole<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.InheritConsole, false));
    /// <inheritdoc cref="DotCoverAnalyseSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.InheritConsole))]
    public static T ToggleInheritConsole<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.InheritConsole, !o.InheritConsole));
    #endregion
    #region AnalyseTargetArguments
    /// <inheritdoc cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AnalyseTargetArguments))]
    public static T SetAnalyseTargetArguments<T>(this T o, bool? v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AnalyseTargetArguments))]
    public static T ResetAnalyseTargetArguments<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.AnalyseTargetArguments));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AnalyseTargetArguments))]
    public static T EnableAnalyseTargetArguments<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, true));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AnalyseTargetArguments))]
    public static T DisableAnalyseTargetArguments<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, false));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AnalyseTargetArguments))]
    public static T ToggleAnalyseTargetArguments<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, !o.AnalyseTargetArguments));
    #endregion
    #region Scope
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T SetScope<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T SetScope<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T AddScope<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T AddScope<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T RemoveScope<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T RemoveScope<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Scope))]
    public static T ClearScope<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.ClearCollection(() => o.Scope));
    #endregion
    #region Filters
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T SetFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T SetFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T AddFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T AddFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T RemoveFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T RemoveFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.Filters))]
    public static T ClearFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.ClearCollection(() => o.Filters));
    #endregion
    #region AttributeFilters
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T SetAttributeFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T SetAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T AddAttributeFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T AddAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T RemoveAttributeFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T RemoveAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AttributeFilters))]
    public static T ClearAttributeFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.ClearCollection(() => o.AttributeFilters));
    #endregion
    #region DisableDefaultFilters
    /// <inheritdoc cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.DisableDefaultFilters))]
    public static T SetDisableDefaultFilters<T>(this T o, bool? v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.DisableDefaultFilters))]
    public static T ResetDisableDefaultFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.DisableDefaultFilters));
    /// <inheritdoc cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.DisableDefaultFilters))]
    public static T EnableDisableDefaultFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, true));
    /// <inheritdoc cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.DisableDefaultFilters))]
    public static T DisableDisableDefaultFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, false));
    /// <inheritdoc cref="DotCoverAnalyseSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.DisableDefaultFilters))]
    public static T ToggleDisableDefaultFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, !o.DisableDefaultFilters));
    #endregion
    #region SymbolSearchPaths
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T SetSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T SetSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T AddSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T AddSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T RemoveSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T RemoveSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.SymbolSearchPaths))]
    public static T ClearSymbolSearchPaths<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.ClearCollection(() => o.SymbolSearchPaths));
    #endregion
    #region AllowSymbolServerAccess
    /// <inheritdoc cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AllowSymbolServerAccess))]
    public static T SetAllowSymbolServerAccess<T>(this T o, bool? v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AllowSymbolServerAccess))]
    public static T ResetAllowSymbolServerAccess<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.AllowSymbolServerAccess));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AllowSymbolServerAccess))]
    public static T EnableAllowSymbolServerAccess<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, true));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AllowSymbolServerAccess))]
    public static T DisableAllowSymbolServerAccess<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, false));
    /// <inheritdoc cref="DotCoverAnalyseSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.AllowSymbolServerAccess))]
    public static T ToggleAllowSymbolServerAccess<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, !o.AllowSymbolServerAccess));
    #endregion
    #region ReturnTargetExitCode
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReturnTargetExitCode))]
    public static T SetReturnTargetExitCode<T>(this T o, bool? v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReturnTargetExitCode))]
    public static T ResetReturnTargetExitCode<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.ReturnTargetExitCode));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReturnTargetExitCode))]
    public static T EnableReturnTargetExitCode<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, true));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReturnTargetExitCode))]
    public static T DisableReturnTargetExitCode<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, false));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ReturnTargetExitCode))]
    public static T ToggleReturnTargetExitCode<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, !o.ReturnTargetExitCode));
    #endregion
    #region ProcessFilters
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T SetProcessFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T SetProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T AddProcessFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T AddProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.AddCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T RemoveProcessFilters<T>(this T o, params string[] v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T RemoveProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverAnalyseSettings => o.Modify(b => b.RemoveCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.ProcessFilters))]
    public static T ClearProcessFilters<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.ClearCollection(() => o.ProcessFilters));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverAnalyseSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverAnalyseSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverAnalyseSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverAnalyseSettings), Property = nameof(DotCoverAnalyseSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverAnalyseSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverCoverSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverCoverSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverCoverSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region TargetExecutable
    /// <inheritdoc cref="DotCoverCoverSettings.TargetExecutable"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TargetExecutable))]
    public static T SetTargetExecutable<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.TargetExecutable, v));
    /// <inheritdoc cref="DotCoverCoverSettings.TargetExecutable"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TargetExecutable))]
    public static T ResetTargetExecutable<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.TargetExecutable));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="DotCoverCoverSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="DotCoverCoverSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region ReportType
    /// <inheritdoc cref="DotCoverCoverSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReportType))]
    public static T SetReportType<T>(this T o, DotCoverReportType v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ReportType, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReportType))]
    public static T ResetReportType<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.ReportType));
    #endregion
    #region TargetArguments
    /// <inheritdoc cref="DotCoverCoverSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TargetArguments))]
    public static T SetTargetArguments<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.TargetArguments, v));
    /// <inheritdoc cref="DotCoverCoverSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TargetArguments))]
    public static T ResetTargetArguments<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.TargetArguments));
    #endregion
    #region TargetWorkingDirectory
    /// <inheritdoc cref="DotCoverCoverSettings.TargetWorkingDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TargetWorkingDirectory))]
    public static T SetTargetWorkingDirectory<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.TargetWorkingDirectory, v));
    /// <inheritdoc cref="DotCoverCoverSettings.TargetWorkingDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TargetWorkingDirectory))]
    public static T ResetTargetWorkingDirectory<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.TargetWorkingDirectory));
    #endregion
    #region TempDirectory
    /// <inheritdoc cref="DotCoverCoverSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TempDirectory))]
    public static T SetTempDirectory<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.TempDirectory, v));
    /// <inheritdoc cref="DotCoverCoverSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.TempDirectory))]
    public static T ResetTempDirectory<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.TempDirectory));
    #endregion
    #region InheritConsole
    /// <inheritdoc cref="DotCoverCoverSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.InheritConsole))]
    public static T SetInheritConsole<T>(this T o, bool? v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.InheritConsole, v));
    /// <inheritdoc cref="DotCoverCoverSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.InheritConsole))]
    public static T ResetInheritConsole<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.InheritConsole));
    /// <inheritdoc cref="DotCoverCoverSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.InheritConsole))]
    public static T EnableInheritConsole<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.InheritConsole, true));
    /// <inheritdoc cref="DotCoverCoverSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.InheritConsole))]
    public static T DisableInheritConsole<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.InheritConsole, false));
    /// <inheritdoc cref="DotCoverCoverSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.InheritConsole))]
    public static T ToggleInheritConsole<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.InheritConsole, !o.InheritConsole));
    #endregion
    #region AnalyseTargetArguments
    /// <inheritdoc cref="DotCoverCoverSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AnalyseTargetArguments))]
    public static T SetAnalyseTargetArguments<T>(this T o, bool? v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AnalyseTargetArguments))]
    public static T ResetAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.AnalyseTargetArguments));
    /// <inheritdoc cref="DotCoverCoverSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AnalyseTargetArguments))]
    public static T EnableAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, true));
    /// <inheritdoc cref="DotCoverCoverSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AnalyseTargetArguments))]
    public static T DisableAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, false));
    /// <inheritdoc cref="DotCoverCoverSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AnalyseTargetArguments))]
    public static T ToggleAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, !o.AnalyseTargetArguments));
    #endregion
    #region Scope
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T SetScope<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T SetScope<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T AddScope<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T AddScope<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T RemoveScope<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T RemoveScope<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Scope))]
    public static T ClearScope<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.ClearCollection(() => o.Scope));
    #endregion
    #region Filters
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T SetFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T SetFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T AddFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T AddFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T RemoveFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T RemoveFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.Filters))]
    public static T ClearFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.ClearCollection(() => o.Filters));
    #endregion
    #region AttributeFilters
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T SetAttributeFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T SetAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T AddAttributeFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T AddAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T RemoveAttributeFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T RemoveAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AttributeFilters))]
    public static T ClearAttributeFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.ClearCollection(() => o.AttributeFilters));
    #endregion
    #region DisableDefaultFilters
    /// <inheritdoc cref="DotCoverCoverSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.DisableDefaultFilters))]
    public static T SetDisableDefaultFilters<T>(this T o, bool? v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.DisableDefaultFilters))]
    public static T ResetDisableDefaultFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.DisableDefaultFilters));
    /// <inheritdoc cref="DotCoverCoverSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.DisableDefaultFilters))]
    public static T EnableDisableDefaultFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, true));
    /// <inheritdoc cref="DotCoverCoverSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.DisableDefaultFilters))]
    public static T DisableDisableDefaultFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, false));
    /// <inheritdoc cref="DotCoverCoverSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.DisableDefaultFilters))]
    public static T ToggleDisableDefaultFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, !o.DisableDefaultFilters));
    #endregion
    #region SymbolSearchPaths
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T SetSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T SetSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T AddSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T AddSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T RemoveSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T RemoveSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.SymbolSearchPaths))]
    public static T ClearSymbolSearchPaths<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.ClearCollection(() => o.SymbolSearchPaths));
    #endregion
    #region AllowSymbolServerAccess
    /// <inheritdoc cref="DotCoverCoverSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AllowSymbolServerAccess))]
    public static T SetAllowSymbolServerAccess<T>(this T o, bool? v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, v));
    /// <inheritdoc cref="DotCoverCoverSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AllowSymbolServerAccess))]
    public static T ResetAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.AllowSymbolServerAccess));
    /// <inheritdoc cref="DotCoverCoverSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AllowSymbolServerAccess))]
    public static T EnableAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, true));
    /// <inheritdoc cref="DotCoverCoverSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AllowSymbolServerAccess))]
    public static T DisableAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, false));
    /// <inheritdoc cref="DotCoverCoverSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.AllowSymbolServerAccess))]
    public static T ToggleAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, !o.AllowSymbolServerAccess));
    #endregion
    #region ReturnTargetExitCode
    /// <inheritdoc cref="DotCoverCoverSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReturnTargetExitCode))]
    public static T SetReturnTargetExitCode<T>(this T o, bool? v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReturnTargetExitCode))]
    public static T ResetReturnTargetExitCode<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.ReturnTargetExitCode));
    /// <inheritdoc cref="DotCoverCoverSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReturnTargetExitCode))]
    public static T EnableReturnTargetExitCode<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, true));
    /// <inheritdoc cref="DotCoverCoverSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReturnTargetExitCode))]
    public static T DisableReturnTargetExitCode<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, false));
    /// <inheritdoc cref="DotCoverCoverSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ReturnTargetExitCode))]
    public static T ToggleReturnTargetExitCode<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, !o.ReturnTargetExitCode));
    #endregion
    #region ProcessFilters
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T SetProcessFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T SetProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T AddProcessFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T AddProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.AddCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T RemoveProcessFilters<T>(this T o, params string[] v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T RemoveProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.ProcessFilters))]
    public static T ClearProcessFilters<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.ClearCollection(() => o.ProcessFilters));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverCoverSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverCoverSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverCoverSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverSettings), Property = nameof(DotCoverCoverSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverCoverSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverCoverDotNetSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverCoverDotNetSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region ReportType
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReportType))]
    public static T SetReportType<T>(this T o, DotCoverReportType v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ReportType, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReportType))]
    public static T ResetReportType<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.ReportType));
    #endregion
    #region TargetArguments
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.TargetArguments))]
    public static T SetTargetArguments<T>(this T o, string v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.TargetArguments, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.TargetArguments))]
    public static T ResetTargetArguments<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.TargetArguments));
    #endregion
    #region TargetWorkingDirectory
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.TargetWorkingDirectory))]
    public static T SetTargetWorkingDirectory<T>(this T o, string v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.TargetWorkingDirectory, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.TargetWorkingDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.TargetWorkingDirectory))]
    public static T ResetTargetWorkingDirectory<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.TargetWorkingDirectory));
    #endregion
    #region TempDirectory
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.TempDirectory))]
    public static T SetTempDirectory<T>(this T o, string v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.TempDirectory, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.TempDirectory))]
    public static T ResetTempDirectory<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.TempDirectory));
    #endregion
    #region InheritConsole
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.InheritConsole))]
    public static T SetInheritConsole<T>(this T o, bool? v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.InheritConsole, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.InheritConsole))]
    public static T ResetInheritConsole<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.InheritConsole));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.InheritConsole))]
    public static T EnableInheritConsole<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.InheritConsole, true));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.InheritConsole))]
    public static T DisableInheritConsole<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.InheritConsole, false));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.InheritConsole"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.InheritConsole))]
    public static T ToggleInheritConsole<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.InheritConsole, !o.InheritConsole));
    #endregion
    #region AnalyseTargetArguments
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AnalyseTargetArguments))]
    public static T SetAnalyseTargetArguments<T>(this T o, bool? v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AnalyseTargetArguments))]
    public static T ResetAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.AnalyseTargetArguments));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AnalyseTargetArguments))]
    public static T EnableAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, true));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AnalyseTargetArguments))]
    public static T DisableAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, false));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AnalyseTargetArguments"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AnalyseTargetArguments))]
    public static T ToggleAnalyseTargetArguments<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AnalyseTargetArguments, !o.AnalyseTargetArguments));
    #endregion
    #region Scope
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T SetScope<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T SetScope<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T AddScope<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T AddScope<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T RemoveScope<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T RemoveScope<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Scope, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Scope"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Scope))]
    public static T ClearScope<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.ClearCollection(() => o.Scope));
    #endregion
    #region Filters
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T SetFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T SetFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T AddFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T AddFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T RemoveFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T RemoveFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.Filters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.Filters))]
    public static T ClearFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.ClearCollection(() => o.Filters));
    #endregion
    #region AttributeFilters
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T SetAttributeFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T SetAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T AddAttributeFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T AddAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T RemoveAttributeFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T RemoveAttributeFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AttributeFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AttributeFilters))]
    public static T ClearAttributeFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.ClearCollection(() => o.AttributeFilters));
    #endregion
    #region DisableDefaultFilters
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.DisableDefaultFilters))]
    public static T SetDisableDefaultFilters<T>(this T o, bool? v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.DisableDefaultFilters))]
    public static T ResetDisableDefaultFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.DisableDefaultFilters));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.DisableDefaultFilters))]
    public static T EnableDisableDefaultFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, true));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.DisableDefaultFilters))]
    public static T DisableDisableDefaultFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, false));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.DisableDefaultFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.DisableDefaultFilters))]
    public static T ToggleDisableDefaultFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilters, !o.DisableDefaultFilters));
    #endregion
    #region SymbolSearchPaths
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T SetSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T SetSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T AddSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T AddSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T RemoveSymbolSearchPaths<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T RemoveSymbolSearchPaths<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.SymbolSearchPaths, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.SymbolSearchPaths"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.SymbolSearchPaths))]
    public static T ClearSymbolSearchPaths<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.ClearCollection(() => o.SymbolSearchPaths));
    #endregion
    #region AllowSymbolServerAccess
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AllowSymbolServerAccess))]
    public static T SetAllowSymbolServerAccess<T>(this T o, bool? v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AllowSymbolServerAccess))]
    public static T ResetAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.AllowSymbolServerAccess));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AllowSymbolServerAccess))]
    public static T EnableAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, true));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AllowSymbolServerAccess))]
    public static T DisableAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, false));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.AllowSymbolServerAccess"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.AllowSymbolServerAccess))]
    public static T ToggleAllowSymbolServerAccess<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.AllowSymbolServerAccess, !o.AllowSymbolServerAccess));
    #endregion
    #region ReturnTargetExitCode
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReturnTargetExitCode))]
    public static T SetReturnTargetExitCode<T>(this T o, bool? v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReturnTargetExitCode))]
    public static T ResetReturnTargetExitCode<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.ReturnTargetExitCode));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReturnTargetExitCode))]
    public static T EnableReturnTargetExitCode<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, true));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReturnTargetExitCode))]
    public static T DisableReturnTargetExitCode<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, false));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ReturnTargetExitCode"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ReturnTargetExitCode))]
    public static T ToggleReturnTargetExitCode<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ReturnTargetExitCode, !o.ReturnTargetExitCode));
    #endregion
    #region ProcessFilters
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T SetProcessFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T SetProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T AddProcessFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T AddProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.AddCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T RemoveProcessFilters<T>(this T o, params string[] v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T RemoveProcessFilters<T>(this T o, IEnumerable<string> v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.ProcessFilters, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.ProcessFilters"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.ProcessFilters))]
    public static T ClearProcessFilters<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.ClearCollection(() => o.ProcessFilters));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverCoverDotNetSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverCoverDotNetSettings), Property = nameof(DotCoverCoverDotNetSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverCoverDotNetSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverDeleteSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverDeleteSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverDeleteSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverDeleteSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverDeleteSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region Source
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T SetSource<T>(this T o, params string[] v) where T : DotCoverDeleteSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T SetSource<T>(this T o, IEnumerable<string> v) where T : DotCoverDeleteSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T AddSource<T>(this T o, params string[] v) where T : DotCoverDeleteSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T AddSource<T>(this T o, IEnumerable<string> v) where T : DotCoverDeleteSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T RemoveSource<T>(this T o, params string[] v) where T : DotCoverDeleteSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T RemoveSource<T>(this T o, IEnumerable<string> v) where T : DotCoverDeleteSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.Source))]
    public static T ClearSource<T>(this T o) where T : DotCoverDeleteSettings => o.Modify(b => b.ClearCollection(() => o.Source));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverDeleteSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverDeleteSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverDeleteSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverDeleteSettings), Property = nameof(DotCoverDeleteSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverDeleteSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverMergeSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverMergeSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverMergeSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverMergeSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverMergeSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region Source
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T SetSource<T>(this T o, params string[] v) where T : DotCoverMergeSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T SetSource<T>(this T o, IEnumerable<string> v) where T : DotCoverMergeSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T AddSource<T>(this T o, params string[] v) where T : DotCoverMergeSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T AddSource<T>(this T o, IEnumerable<string> v) where T : DotCoverMergeSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T RemoveSource<T>(this T o, params string[] v) where T : DotCoverMergeSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T RemoveSource<T>(this T o, IEnumerable<string> v) where T : DotCoverMergeSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverMergeSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.Source))]
    public static T ClearSource<T>(this T o) where T : DotCoverMergeSettings => o.Modify(b => b.ClearCollection(() => o.Source));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="DotCoverMergeSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : DotCoverMergeSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="DotCoverMergeSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : DotCoverMergeSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region TempDirectory
    /// <inheritdoc cref="DotCoverMergeSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.TempDirectory))]
    public static T SetTempDirectory<T>(this T o, string v) where T : DotCoverMergeSettings => o.Modify(b => b.Set(() => o.TempDirectory, v));
    /// <inheritdoc cref="DotCoverMergeSettings.TempDirectory"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.TempDirectory))]
    public static T ResetTempDirectory<T>(this T o) where T : DotCoverMergeSettings => o.Modify(b => b.Remove(() => o.TempDirectory));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverMergeSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverMergeSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverMergeSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverMergeSettings), Property = nameof(DotCoverMergeSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverMergeSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverReportSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverReportSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverReportSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverReportSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region Source
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T SetSource<T>(this T o, params string[] v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T SetSource<T>(this T o, IEnumerable<string> v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T AddSource<T>(this T o, params string[] v) where T : DotCoverReportSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T AddSource<T>(this T o, IEnumerable<string> v) where T : DotCoverReportSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T RemoveSource<T>(this T o, params string[] v) where T : DotCoverReportSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T RemoveSource<T>(this T o, IEnumerable<string> v) where T : DotCoverReportSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="DotCoverReportSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.Source))]
    public static T ClearSource<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.ClearCollection(() => o.Source));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="DotCoverReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="DotCoverReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region ReportType
    /// <inheritdoc cref="DotCoverReportSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.ReportType))]
    public static T SetReportType<T>(this T o, DotCoverReportType v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.ReportType, v));
    /// <inheritdoc cref="DotCoverReportSettings.ReportType"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.ReportType))]
    public static T ResetReportType<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Remove(() => o.ReportType));
    #endregion
    #region HideAutoProperties
    /// <inheritdoc cref="DotCoverReportSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.HideAutoProperties))]
    public static T SetHideAutoProperties<T>(this T o, bool? v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, v));
    /// <inheritdoc cref="DotCoverReportSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.HideAutoProperties))]
    public static T ResetHideAutoProperties<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Remove(() => o.HideAutoProperties));
    /// <inheritdoc cref="DotCoverReportSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.HideAutoProperties))]
    public static T EnableHideAutoProperties<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, true));
    /// <inheritdoc cref="DotCoverReportSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.HideAutoProperties))]
    public static T DisableHideAutoProperties<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, false));
    /// <inheritdoc cref="DotCoverReportSettings.HideAutoProperties"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.HideAutoProperties))]
    public static T ToggleHideAutoProperties<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.HideAutoProperties, !o.HideAutoProperties));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverReportSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverReportSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverReportSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverReportSettings), Property = nameof(DotCoverReportSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverReportSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverZipSettingsExtensions
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotCoverZipSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="DotCoverZipSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : DotCoverZipSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="DotCoverZipSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : DotCoverZipSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region Source
    /// <inheritdoc cref="DotCoverZipSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : DotCoverZipSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="DotCoverZipSettings.Source"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.Source))]
    public static T ResetSource<T>(this T o) where T : DotCoverZipSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="DotCoverZipSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : DotCoverZipSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="DotCoverZipSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : DotCoverZipSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region LogFile
    /// <inheritdoc cref="DotCoverZipSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : DotCoverZipSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="DotCoverZipSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(DotCoverZipSettings), Property = nameof(DotCoverZipSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : DotCoverZipSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
}
#endregion
#region DotCoverReportType
/// <summary>Used within <see cref="DotCoverTasks"/>.</summary>
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
