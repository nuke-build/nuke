// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/NUnit/NUnit.json

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

namespace Nuke.Common.Tools.NUnit;

/// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class NUnitTasks : ToolTasks, IRequireNuGetPackage
{
    public static string NUnitPath => new NUnitTasks().GetToolPath();
    public const string PackageId = "NUnit.ConsoleRunner";
    public const string PackageExecutable = "nunit3-console.exe";
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> NUnit(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new NUnitTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;inputFiles&gt;</c> via <see cref="NUnit3Settings.InputFiles"/></li><li><c>--agents</c> via <see cref="NUnit3Settings.Agents"/></li><li><c>--config</c> via <see cref="NUnit3Settings.Configuration"/></li><li><c>--debug</c> via <see cref="NUnit3Settings.Debug"/></li><li><c>--debug-agent</c> via <see cref="NUnit3Settings.DebugAgent"/></li><li><c>--dispose-runners</c> via <see cref="NUnit3Settings.DisposeRunners"/></li><li><c>--domain</c> via <see cref="NUnit3Settings.Domain"/></li><li><c>--encoding</c> via <see cref="NUnit3Settings.Encoding"/></li><li><c>--err</c> via <see cref="NUnit3Settings.ErrorFile"/></li><li><c>--explore</c> via <see cref="NUnit3Settings.Explores"/></li><li><c>--framework</c> via <see cref="NUnit3Settings.Framework"/></li><li><c>--inprocess</c> via <see cref="NUnit3Settings.InProcess"/></li><li><c>--labels</c> via <see cref="NUnit3Settings.Labels"/></li><li><c>--list-extensions</c> via <see cref="NUnit3Settings.ListExtensions"/></li><li><c>--loaduserprofile</c> via <see cref="NUnit3Settings.LoadUserProfile"/></li><li><c>--nocolor</c> via <see cref="NUnit3Settings.NoColor"/></li><li><c>--noheader</c> via <see cref="NUnit3Settings.NoHeader"/></li><li><c>--noresult</c> via <see cref="NUnit3Settings.NoResults"/></li><li><c>--output</c> via <see cref="NUnit3Settings.OutputFile"/></li><li><c>--pause</c> via <see cref="NUnit3Settings.Pause"/></li><li><c>--process</c> via <see cref="NUnit3Settings.Process"/></li><li><c>--result</c> via <see cref="NUnit3Settings.Results"/></li><li><c>--seed</c> via <see cref="NUnit3Settings.Seed"/></li><li><c>--set-principal-policy</c> via <see cref="NUnit3Settings.SetPrincipalPolicy"/></li><li><c>--shadowcopy</c> via <see cref="NUnit3Settings.ShadowCopy"/></li><li><c>--skipnontestassemblies</c> via <see cref="NUnit3Settings.SkipNonTestAssemblies"/></li><li><c>--stoponerror</c> via <see cref="NUnit3Settings.StopOnError"/></li><li><c>--teamcity</c> via <see cref="NUnit3Settings.TeamCity"/></li><li><c>--test</c> via <see cref="NUnit3Settings.Tests"/></li><li><c>--testlist</c> via <see cref="NUnit3Settings.TestListFile"/></li><li><c>--testparam</c> via <see cref="NUnit3Settings.Parameters"/></li><li><c>--timeout</c> via <see cref="NUnit3Settings.Timeout"/></li><li><c>--trace</c> via <see cref="NUnit3Settings.Trace"/></li><li><c>--wait</c> via <see cref="NUnit3Settings.Wait"/></li><li><c>--where</c> via <see cref="NUnit3Settings.WhereExpression"/></li><li><c>--work</c> via <see cref="NUnit3Settings.WorkPath"/></li><li><c>--workers</c> via <see cref="NUnit3Settings.Workers"/></li><li><c>--x86</c> via <see cref="NUnit3Settings.X86"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NUnit3(NUnit3Settings options = null) => new NUnitTasks().Run(options);
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;inputFiles&gt;</c> via <see cref="NUnit3Settings.InputFiles"/></li><li><c>--agents</c> via <see cref="NUnit3Settings.Agents"/></li><li><c>--config</c> via <see cref="NUnit3Settings.Configuration"/></li><li><c>--debug</c> via <see cref="NUnit3Settings.Debug"/></li><li><c>--debug-agent</c> via <see cref="NUnit3Settings.DebugAgent"/></li><li><c>--dispose-runners</c> via <see cref="NUnit3Settings.DisposeRunners"/></li><li><c>--domain</c> via <see cref="NUnit3Settings.Domain"/></li><li><c>--encoding</c> via <see cref="NUnit3Settings.Encoding"/></li><li><c>--err</c> via <see cref="NUnit3Settings.ErrorFile"/></li><li><c>--explore</c> via <see cref="NUnit3Settings.Explores"/></li><li><c>--framework</c> via <see cref="NUnit3Settings.Framework"/></li><li><c>--inprocess</c> via <see cref="NUnit3Settings.InProcess"/></li><li><c>--labels</c> via <see cref="NUnit3Settings.Labels"/></li><li><c>--list-extensions</c> via <see cref="NUnit3Settings.ListExtensions"/></li><li><c>--loaduserprofile</c> via <see cref="NUnit3Settings.LoadUserProfile"/></li><li><c>--nocolor</c> via <see cref="NUnit3Settings.NoColor"/></li><li><c>--noheader</c> via <see cref="NUnit3Settings.NoHeader"/></li><li><c>--noresult</c> via <see cref="NUnit3Settings.NoResults"/></li><li><c>--output</c> via <see cref="NUnit3Settings.OutputFile"/></li><li><c>--pause</c> via <see cref="NUnit3Settings.Pause"/></li><li><c>--process</c> via <see cref="NUnit3Settings.Process"/></li><li><c>--result</c> via <see cref="NUnit3Settings.Results"/></li><li><c>--seed</c> via <see cref="NUnit3Settings.Seed"/></li><li><c>--set-principal-policy</c> via <see cref="NUnit3Settings.SetPrincipalPolicy"/></li><li><c>--shadowcopy</c> via <see cref="NUnit3Settings.ShadowCopy"/></li><li><c>--skipnontestassemblies</c> via <see cref="NUnit3Settings.SkipNonTestAssemblies"/></li><li><c>--stoponerror</c> via <see cref="NUnit3Settings.StopOnError"/></li><li><c>--teamcity</c> via <see cref="NUnit3Settings.TeamCity"/></li><li><c>--test</c> via <see cref="NUnit3Settings.Tests"/></li><li><c>--testlist</c> via <see cref="NUnit3Settings.TestListFile"/></li><li><c>--testparam</c> via <see cref="NUnit3Settings.Parameters"/></li><li><c>--timeout</c> via <see cref="NUnit3Settings.Timeout"/></li><li><c>--trace</c> via <see cref="NUnit3Settings.Trace"/></li><li><c>--wait</c> via <see cref="NUnit3Settings.Wait"/></li><li><c>--where</c> via <see cref="NUnit3Settings.WhereExpression"/></li><li><c>--work</c> via <see cref="NUnit3Settings.WorkPath"/></li><li><c>--workers</c> via <see cref="NUnit3Settings.Workers"/></li><li><c>--x86</c> via <see cref="NUnit3Settings.X86"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NUnit3(Configure<NUnit3Settings> configurator) => new NUnitTasks().Run(configurator.Invoke(new NUnit3Settings()));
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;inputFiles&gt;</c> via <see cref="NUnit3Settings.InputFiles"/></li><li><c>--agents</c> via <see cref="NUnit3Settings.Agents"/></li><li><c>--config</c> via <see cref="NUnit3Settings.Configuration"/></li><li><c>--debug</c> via <see cref="NUnit3Settings.Debug"/></li><li><c>--debug-agent</c> via <see cref="NUnit3Settings.DebugAgent"/></li><li><c>--dispose-runners</c> via <see cref="NUnit3Settings.DisposeRunners"/></li><li><c>--domain</c> via <see cref="NUnit3Settings.Domain"/></li><li><c>--encoding</c> via <see cref="NUnit3Settings.Encoding"/></li><li><c>--err</c> via <see cref="NUnit3Settings.ErrorFile"/></li><li><c>--explore</c> via <see cref="NUnit3Settings.Explores"/></li><li><c>--framework</c> via <see cref="NUnit3Settings.Framework"/></li><li><c>--inprocess</c> via <see cref="NUnit3Settings.InProcess"/></li><li><c>--labels</c> via <see cref="NUnit3Settings.Labels"/></li><li><c>--list-extensions</c> via <see cref="NUnit3Settings.ListExtensions"/></li><li><c>--loaduserprofile</c> via <see cref="NUnit3Settings.LoadUserProfile"/></li><li><c>--nocolor</c> via <see cref="NUnit3Settings.NoColor"/></li><li><c>--noheader</c> via <see cref="NUnit3Settings.NoHeader"/></li><li><c>--noresult</c> via <see cref="NUnit3Settings.NoResults"/></li><li><c>--output</c> via <see cref="NUnit3Settings.OutputFile"/></li><li><c>--pause</c> via <see cref="NUnit3Settings.Pause"/></li><li><c>--process</c> via <see cref="NUnit3Settings.Process"/></li><li><c>--result</c> via <see cref="NUnit3Settings.Results"/></li><li><c>--seed</c> via <see cref="NUnit3Settings.Seed"/></li><li><c>--set-principal-policy</c> via <see cref="NUnit3Settings.SetPrincipalPolicy"/></li><li><c>--shadowcopy</c> via <see cref="NUnit3Settings.ShadowCopy"/></li><li><c>--skipnontestassemblies</c> via <see cref="NUnit3Settings.SkipNonTestAssemblies"/></li><li><c>--stoponerror</c> via <see cref="NUnit3Settings.StopOnError"/></li><li><c>--teamcity</c> via <see cref="NUnit3Settings.TeamCity"/></li><li><c>--test</c> via <see cref="NUnit3Settings.Tests"/></li><li><c>--testlist</c> via <see cref="NUnit3Settings.TestListFile"/></li><li><c>--testparam</c> via <see cref="NUnit3Settings.Parameters"/></li><li><c>--timeout</c> via <see cref="NUnit3Settings.Timeout"/></li><li><c>--trace</c> via <see cref="NUnit3Settings.Trace"/></li><li><c>--wait</c> via <see cref="NUnit3Settings.Wait"/></li><li><c>--where</c> via <see cref="NUnit3Settings.WhereExpression"/></li><li><c>--work</c> via <see cref="NUnit3Settings.WorkPath"/></li><li><c>--workers</c> via <see cref="NUnit3Settings.Workers"/></li><li><c>--x86</c> via <see cref="NUnit3Settings.X86"/></li></ul></remarks>
    public static IEnumerable<(NUnit3Settings Settings, IReadOnlyCollection<Output> Output)> NUnit3(CombinatorialConfigure<NUnit3Settings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NUnit3, degreeOfParallelism, completeOnFailure);
}
#region NUnit3Settings
/// <summary>Used within <see cref="NUnitTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NUnit3Settings>))]
[Command(Type = typeof(NUnitTasks), Command = nameof(NUnitTasks.NUnit3))]
public partial class NUnit3Settings : ToolOptions
{
    /// <summary><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
    [Argument(Format = "{value}", Position = 1)] public IReadOnlyList<string> InputFiles => Get<List<string>>(() => InputFiles);
    /// <summary>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</summary>
    [Argument(Format = "--test={value}", Separator = ",")] public IReadOnlyList<string> Tests => Get<List<string>>(() => Tests);
    /// <summary>The name (or path) of a file containing a list of tests to run or explore, one per line.</summary>
    [Argument(Format = "--testlist={value}")] public string TestListFile => Get<string>(() => TestListFile);
    /// <summary>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators <c>==</c>, <c>!=</c>, <c>=~</c> and <c>!~</c>. See Test Selection Language for a full description of the syntax.</summary>
    [Argument(Format = "--where={value}")] public string WhereExpression => Get<string>(() => WhereExpression);
    /// <summary>A test parameter specified in the form NAME=VALUE for consumption by tests. Multiple parameters must be specified separated using a <c>--testparam</c> option for each.</summary>
    [Argument(Format = "--testparam={key}={value}")] public IReadOnlyDictionary<string, string> Parameters => Get<Dictionary<string, string>>(() => Parameters);
    /// <summary>Name of a project configuration to load (e.g.: <c>Debug</c>).</summary>
    [Argument(Format = "--config={value}")] public string Configuration => Get<string>(() => Configuration);
    /// <summary>Process isolation for test assemblies. Values: <c>Single</c>, <c>Separate</c>, <c>Multiple</c>. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</summary>
    [Argument(Format = "--process={value}")] public NUnitProcessType Process => Get<NUnitProcessType>(() => Process);
    /// <summary>This option is a synonym for <c>--process=Single</c></summary>
    [Argument(Format = "--inprocess")] public bool? InProcess => Get<bool?>(() => InProcess);
    /// <summary>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</summary>
    [Argument(Format = "--agents={value}")] public int? Agents => Get<int?>(() => Agents);
    /// <summary>Domain isolation for test assemblies. Values: <c>None</c>, <c>Single</c>, <c>Multiple</c>. If not specified, defaults to <c>Single</c> for a single assembly or <c>Multiple</c> for more than one.</summary>
    [Argument(Format = "--domain={value}")] public string Domain => Get<string>(() => Domain);
    /// <summary>Framework type/version to use for tests. Examples: <c>mono</c>, <c>net-4.5,</c> <c>v4.0</c>, <c>2.0</c>, <c>mono-4.0</c></summary>
    [Argument(Format = "--framework={value}")] public string Framework => Get<string>(() => Framework);
    /// <summary>Run tests in a 32-bit process on 64-bit systems.</summary>
    [Argument(Format = "--x86")] public bool? X86 => Get<bool?>(() => X86);
    /// <summary>Dispose each test runner after it has finished running its tests</summary>
    [Argument(Format = "--dispose-runners")] public bool? DisposeRunners => Get<bool?>(() => DisposeRunners);
    /// <summary>Set timeout for each test case in milliseconds.</summary>
    [Argument(Format = "--timeout={value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>Set the random seed used to generate test cases.</summary>
    [Argument(Format = "--seed={value}")] public int? Seed => Get<int?>(() => Seed);
    /// <summary>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the <c>Parallelizable</c> attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</summary>
    [Argument(Format = "--workers={value}")] public int? Workers => Get<int?>(() => Workers);
    /// <summary>Stop run immediately upon any test failure or error.</summary>
    [Argument(Format = "--stoponerror")] public bool? StopOnError => Get<bool?>(() => StopOnError);
    /// <summary>Skip any non-test assemblies specified, without error.</summary>
    [Argument(Format = "--skipnontestassemblies")] public bool? SkipNonTestAssemblies => Get<bool?>(() => SkipNonTestAssemblies);
    /// <summary>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</summary>
    [Argument(Format = "--debug-agent")] public bool? DebugAgent => Get<bool?>(() => DebugAgent);
    /// <summary>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.</summary>
    [Argument(Format = "--pause")] public bool? Pause => Get<bool?>(() => Pause);
    /// <summary>Wait for input before closing console window.</summary>
    [Argument(Format = "--wait")] public bool? Wait => Get<bool?>(() => Wait);
    /// <summary>Path of the directory to use for output files.</summary>
    [Argument(Format = "--work={value}")] public string WorkPath => Get<string>(() => WorkPath);
    /// <summary>File path to contain text output from the tests.</summary>
    [Argument(Format = "--output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>File path to contain error output from the tests.</summary>
    [Argument(Format = "--err={value}")] public string ErrorFile => Get<string>(() => ErrorFile);
    /// <summary>An output spec for saving the test results. This option may be repeated.</summary>
    [Argument(Format = "--result={value}")] public IReadOnlyList<string> Results => Get<List<string>>(() => Results);
    /// <summary>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</summary>
    [Argument(Format = "--explore={value}")] public IReadOnlyList<string> Explores => Get<List<string>>(() => Explores);
    /// <summary>Don't save any test results.</summary>
    [Argument(Format = "--noresult")] public bool? NoResults => Get<bool?>(() => NoResults);
    /// <summary>Specify whether to write test case names to the output. Values: <c>Off</c>, <c>On</c>, <c>All</c>, <c>OnOutputOnly</c>, <c>Before</c>, <c>After</c>, <c>BeforeAndAfter</c></summary>
    [Argument(Format = "--labels={value}")] public NUnitLabelType Labels => Get<NUnitLabelType>(() => Labels);
    /// <summary>Set internal trace level. Values: <c>Off</c>, !<c>Error</c>, <c>Warning</c>, <c>Info</c>, <c>Verbose</c> (<c>Debug</c>)</summary>
    [Argument(Format = "--trace={value}")] public NUnitTraceLevel Trace => Get<NUnitTraceLevel>(() => Trace);
    /// <summary>Specify the console codepage, such as <c>utf-8</c>, <c>ascii</c>cc, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</summary>
    [Argument(Format = "--encoding={value}")] public string Encoding => Get<string>(() => Encoding);
    /// <summary>Tells .NET to copy loaded assemblies to the shadowcopy directory.</summary>
    [Argument(Format = "--shadowcopy")] public bool? ShadowCopy => Get<bool?>(() => ShadowCopy);
    /// <summary>Turns on use of TeamCity service messages.</summary>
    [Argument(Format = "--teamcity")] public bool? TeamCity => Get<bool?>(() => TeamCity);
    /// <summary>Causes the user profile to be loaded in any separate test processes.</summary>
    [Argument(Format = "--loaduserprofile")] public bool? LoadUserProfile => Get<bool?>(() => LoadUserProfile);
    /// <summary>Lists all extension points and the extensions installed on each of them.</summary>
    [Argument(Format = "--list-extensions")] public bool? ListExtensions => Get<bool?>(() => ListExtensions);
    /// <summary>Set the principal policy for the test domain. Values: <c>UnauthenticatedPrincipal</c>, <c>NoPrincipal</c>, <c>WindowsPrincipal</c></summary>
    [Argument(Format = "--set-principal-policy={value}")] public NUnitPrincipalPolicy SetPrincipalPolicy => Get<NUnitPrincipalPolicy>(() => SetPrincipalPolicy);
    /// <summary>Suppress display of program information at start of run.</summary>
    [Argument(Format = "--noheader")] public bool? NoHeader => Get<bool?>(() => NoHeader);
    /// <summary>Displays console output without color.</summary>
    [Argument(Format = "--nocolor")] public bool? NoColor => Get<bool?>(() => NoColor);
}
#endregion
#region NUnit3SettingsExtensions
/// <summary>Used within <see cref="NUnitTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NUnit3SettingsExtensions
{
    #region InputFiles
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T SetInputFiles<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.InputFiles, v));
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T SetInputFiles<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.InputFiles, v));
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T AddInputFiles<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.InputFiles, v));
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T AddInputFiles<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.InputFiles, v));
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T RemoveInputFiles<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.InputFiles, v));
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T RemoveInputFiles<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.InputFiles, v));
    /// <inheritdoc cref="NUnit3Settings.InputFiles"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InputFiles))]
    public static T ClearInputFiles<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.ClearCollection(() => o.InputFiles));
    #endregion
    #region Tests
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T SetTests<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Tests, v));
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T SetTests<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Tests, v));
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T AddTests<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.Tests, v));
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T AddTests<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.Tests, v));
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T RemoveTests<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.Tests, v));
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T RemoveTests<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.Tests, v));
    /// <inheritdoc cref="NUnit3Settings.Tests"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Tests))]
    public static T ClearTests<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.ClearCollection(() => o.Tests));
    #endregion
    #region TestListFile
    /// <inheritdoc cref="NUnit3Settings.TestListFile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TestListFile))]
    public static T SetTestListFile<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.TestListFile, v));
    /// <inheritdoc cref="NUnit3Settings.TestListFile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TestListFile))]
    public static T ResetTestListFile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.TestListFile));
    #endregion
    #region WhereExpression
    /// <inheritdoc cref="NUnit3Settings.WhereExpression"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.WhereExpression))]
    public static T SetWhereExpression<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.WhereExpression, v));
    /// <inheritdoc cref="NUnit3Settings.WhereExpression"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.WhereExpression))]
    public static T ResetWhereExpression<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.WhereExpression));
    #endregion
    #region Parameters
    /// <inheritdoc cref="NUnit3Settings.Parameters"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Parameters))]
    public static T SetParameters<T>(this T o, IDictionary<string, string> v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Parameters, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="NUnit3Settings.Parameters"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Parameters))]
    public static T SetParameter<T>(this T o, string k, string v) where T : NUnit3Settings => o.Modify(b => b.SetDictionary(() => o.Parameters, k, v));
    /// <inheritdoc cref="NUnit3Settings.Parameters"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Parameters))]
    public static T AddParameter<T>(this T o, string k, string v) where T : NUnit3Settings => o.Modify(b => b.AddDictionary(() => o.Parameters, k, v));
    /// <inheritdoc cref="NUnit3Settings.Parameters"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Parameters))]
    public static T RemoveParameter<T>(this T o, string k) where T : NUnit3Settings => o.Modify(b => b.RemoveDictionary(() => o.Parameters, k));
    /// <inheritdoc cref="NUnit3Settings.Parameters"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Parameters))]
    public static T ClearParameters<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.ClearDictionary(() => o.Parameters));
    #endregion
    #region Configuration
    /// <inheritdoc cref="NUnit3Settings.Configuration"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="NUnit3Settings.Configuration"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region Process
    /// <inheritdoc cref="NUnit3Settings.Process"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Process))]
    public static T SetProcess<T>(this T o, NUnitProcessType v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Process, v));
    /// <inheritdoc cref="NUnit3Settings.Process"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Process))]
    public static T ResetProcess<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Process));
    #endregion
    #region InProcess
    /// <inheritdoc cref="NUnit3Settings.InProcess"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InProcess))]
    public static T SetInProcess<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.InProcess, v));
    /// <inheritdoc cref="NUnit3Settings.InProcess"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InProcess))]
    public static T ResetInProcess<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.InProcess));
    /// <inheritdoc cref="NUnit3Settings.InProcess"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InProcess))]
    public static T EnableInProcess<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.InProcess, true));
    /// <inheritdoc cref="NUnit3Settings.InProcess"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InProcess))]
    public static T DisableInProcess<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.InProcess, false));
    /// <inheritdoc cref="NUnit3Settings.InProcess"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.InProcess))]
    public static T ToggleInProcess<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.InProcess, !o.InProcess));
    #endregion
    #region Agents
    /// <inheritdoc cref="NUnit3Settings.Agents"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Agents))]
    public static T SetAgents<T>(this T o, int? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Agents, v));
    /// <inheritdoc cref="NUnit3Settings.Agents"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Agents))]
    public static T ResetAgents<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Agents));
    #endregion
    #region Domain
    /// <inheritdoc cref="NUnit3Settings.Domain"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Domain))]
    public static T SetDomain<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Domain, v));
    /// <inheritdoc cref="NUnit3Settings.Domain"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Domain))]
    public static T ResetDomain<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Domain));
    #endregion
    #region Framework
    /// <inheritdoc cref="NUnit3Settings.Framework"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Framework, v));
    /// <inheritdoc cref="NUnit3Settings.Framework"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Framework))]
    public static T ResetFramework<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Framework));
    #endregion
    #region X86
    /// <inheritdoc cref="NUnit3Settings.X86"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.X86))]
    public static T SetX86<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.X86, v));
    /// <inheritdoc cref="NUnit3Settings.X86"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.X86))]
    public static T ResetX86<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.X86));
    /// <inheritdoc cref="NUnit3Settings.X86"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.X86))]
    public static T EnableX86<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.X86, true));
    /// <inheritdoc cref="NUnit3Settings.X86"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.X86))]
    public static T DisableX86<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.X86, false));
    /// <inheritdoc cref="NUnit3Settings.X86"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.X86))]
    public static T ToggleX86<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.X86, !o.X86));
    #endregion
    #region DisposeRunners
    /// <inheritdoc cref="NUnit3Settings.DisposeRunners"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DisposeRunners))]
    public static T SetDisposeRunners<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DisposeRunners, v));
    /// <inheritdoc cref="NUnit3Settings.DisposeRunners"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DisposeRunners))]
    public static T ResetDisposeRunners<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.DisposeRunners));
    /// <inheritdoc cref="NUnit3Settings.DisposeRunners"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DisposeRunners))]
    public static T EnableDisposeRunners<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DisposeRunners, true));
    /// <inheritdoc cref="NUnit3Settings.DisposeRunners"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DisposeRunners))]
    public static T DisableDisposeRunners<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DisposeRunners, false));
    /// <inheritdoc cref="NUnit3Settings.DisposeRunners"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DisposeRunners))]
    public static T ToggleDisposeRunners<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DisposeRunners, !o.DisposeRunners));
    #endregion
    #region Timeout
    /// <inheritdoc cref="NUnit3Settings.Timeout"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="NUnit3Settings.Timeout"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Seed
    /// <inheritdoc cref="NUnit3Settings.Seed"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Seed))]
    public static T SetSeed<T>(this T o, int? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Seed, v));
    /// <inheritdoc cref="NUnit3Settings.Seed"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Seed))]
    public static T ResetSeed<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Seed));
    #endregion
    #region Workers
    /// <inheritdoc cref="NUnit3Settings.Workers"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Workers))]
    public static T SetWorkers<T>(this T o, int? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Workers, v));
    /// <inheritdoc cref="NUnit3Settings.Workers"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Workers))]
    public static T ResetWorkers<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Workers));
    #endregion
    #region StopOnError
    /// <inheritdoc cref="NUnit3Settings.StopOnError"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.StopOnError))]
    public static T SetStopOnError<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.StopOnError, v));
    /// <inheritdoc cref="NUnit3Settings.StopOnError"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.StopOnError))]
    public static T ResetStopOnError<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.StopOnError));
    /// <inheritdoc cref="NUnit3Settings.StopOnError"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.StopOnError))]
    public static T EnableStopOnError<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.StopOnError, true));
    /// <inheritdoc cref="NUnit3Settings.StopOnError"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.StopOnError))]
    public static T DisableStopOnError<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.StopOnError, false));
    /// <inheritdoc cref="NUnit3Settings.StopOnError"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.StopOnError))]
    public static T ToggleStopOnError<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.StopOnError, !o.StopOnError));
    #endregion
    #region SkipNonTestAssemblies
    /// <inheritdoc cref="NUnit3Settings.SkipNonTestAssemblies"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SkipNonTestAssemblies))]
    public static T SetSkipNonTestAssemblies<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.SkipNonTestAssemblies, v));
    /// <inheritdoc cref="NUnit3Settings.SkipNonTestAssemblies"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SkipNonTestAssemblies))]
    public static T ResetSkipNonTestAssemblies<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.SkipNonTestAssemblies));
    /// <inheritdoc cref="NUnit3Settings.SkipNonTestAssemblies"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SkipNonTestAssemblies))]
    public static T EnableSkipNonTestAssemblies<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.SkipNonTestAssemblies, true));
    /// <inheritdoc cref="NUnit3Settings.SkipNonTestAssemblies"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SkipNonTestAssemblies))]
    public static T DisableSkipNonTestAssemblies<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.SkipNonTestAssemblies, false));
    /// <inheritdoc cref="NUnit3Settings.SkipNonTestAssemblies"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SkipNonTestAssemblies))]
    public static T ToggleSkipNonTestAssemblies<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.SkipNonTestAssemblies, !o.SkipNonTestAssemblies));
    #endregion
    #region Debug
    /// <inheritdoc cref="NUnit3Settings.Debug"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="NUnit3Settings.Debug"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Debug))]
    public static T ResetDebug<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="NUnit3Settings.Debug"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Debug))]
    public static T EnableDebug<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="NUnit3Settings.Debug"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Debug))]
    public static T DisableDebug<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="NUnit3Settings.Debug"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region DebugAgent
    /// <inheritdoc cref="NUnit3Settings.DebugAgent"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DebugAgent))]
    public static T SetDebugAgent<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DebugAgent, v));
    /// <inheritdoc cref="NUnit3Settings.DebugAgent"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DebugAgent))]
    public static T ResetDebugAgent<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.DebugAgent));
    /// <inheritdoc cref="NUnit3Settings.DebugAgent"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DebugAgent))]
    public static T EnableDebugAgent<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DebugAgent, true));
    /// <inheritdoc cref="NUnit3Settings.DebugAgent"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DebugAgent))]
    public static T DisableDebugAgent<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DebugAgent, false));
    /// <inheritdoc cref="NUnit3Settings.DebugAgent"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.DebugAgent))]
    public static T ToggleDebugAgent<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.DebugAgent, !o.DebugAgent));
    #endregion
    #region Pause
    /// <inheritdoc cref="NUnit3Settings.Pause"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Pause))]
    public static T SetPause<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Pause, v));
    /// <inheritdoc cref="NUnit3Settings.Pause"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Pause))]
    public static T ResetPause<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Pause));
    /// <inheritdoc cref="NUnit3Settings.Pause"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Pause))]
    public static T EnablePause<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Pause, true));
    /// <inheritdoc cref="NUnit3Settings.Pause"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Pause))]
    public static T DisablePause<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Pause, false));
    /// <inheritdoc cref="NUnit3Settings.Pause"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Pause))]
    public static T TogglePause<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Pause, !o.Pause));
    #endregion
    #region Wait
    /// <inheritdoc cref="NUnit3Settings.Wait"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Wait))]
    public static T SetWait<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Wait, v));
    /// <inheritdoc cref="NUnit3Settings.Wait"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Wait))]
    public static T ResetWait<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Wait));
    /// <inheritdoc cref="NUnit3Settings.Wait"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Wait))]
    public static T EnableWait<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Wait, true));
    /// <inheritdoc cref="NUnit3Settings.Wait"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Wait))]
    public static T DisableWait<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Wait, false));
    /// <inheritdoc cref="NUnit3Settings.Wait"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Wait))]
    public static T ToggleWait<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Wait, !o.Wait));
    #endregion
    #region WorkPath
    /// <inheritdoc cref="NUnit3Settings.WorkPath"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.WorkPath))]
    public static T SetWorkPath<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.WorkPath, v));
    /// <inheritdoc cref="NUnit3Settings.WorkPath"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.WorkPath))]
    public static T ResetWorkPath<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.WorkPath));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="NUnit3Settings.OutputFile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="NUnit3Settings.OutputFile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region ErrorFile
    /// <inheritdoc cref="NUnit3Settings.ErrorFile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ErrorFile))]
    public static T SetErrorFile<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ErrorFile, v));
    /// <inheritdoc cref="NUnit3Settings.ErrorFile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ErrorFile))]
    public static T ResetErrorFile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.ErrorFile));
    #endregion
    #region Results
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T SetResults<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Results, v));
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T SetResults<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Results, v));
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T AddResults<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.Results, v));
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T AddResults<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.Results, v));
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T RemoveResults<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.Results, v));
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T RemoveResults<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.Results, v));
    /// <inheritdoc cref="NUnit3Settings.Results"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Results))]
    public static T ClearResults<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.ClearCollection(() => o.Results));
    #endregion
    #region Explores
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T SetExplores<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Explores, v));
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T SetExplores<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Explores, v));
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T AddExplores<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.Explores, v));
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T AddExplores<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.AddCollection(() => o.Explores, v));
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T RemoveExplores<T>(this T o, params string[] v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.Explores, v));
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T RemoveExplores<T>(this T o, IEnumerable<string> v) where T : NUnit3Settings => o.Modify(b => b.RemoveCollection(() => o.Explores, v));
    /// <inheritdoc cref="NUnit3Settings.Explores"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Explores))]
    public static T ClearExplores<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.ClearCollection(() => o.Explores));
    #endregion
    #region NoResults
    /// <inheritdoc cref="NUnit3Settings.NoResults"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoResults))]
    public static T SetNoResults<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoResults, v));
    /// <inheritdoc cref="NUnit3Settings.NoResults"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoResults))]
    public static T ResetNoResults<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.NoResults));
    /// <inheritdoc cref="NUnit3Settings.NoResults"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoResults))]
    public static T EnableNoResults<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoResults, true));
    /// <inheritdoc cref="NUnit3Settings.NoResults"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoResults))]
    public static T DisableNoResults<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoResults, false));
    /// <inheritdoc cref="NUnit3Settings.NoResults"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoResults))]
    public static T ToggleNoResults<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoResults, !o.NoResults));
    #endregion
    #region Labels
    /// <inheritdoc cref="NUnit3Settings.Labels"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Labels))]
    public static T SetLabels<T>(this T o, NUnitLabelType v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Labels, v));
    /// <inheritdoc cref="NUnit3Settings.Labels"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Labels))]
    public static T ResetLabels<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Labels));
    #endregion
    #region Trace
    /// <inheritdoc cref="NUnit3Settings.Trace"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Trace))]
    public static T SetTrace<T>(this T o, NUnitTraceLevel v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Trace, v));
    /// <inheritdoc cref="NUnit3Settings.Trace"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Trace))]
    public static T ResetTrace<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Trace));
    #endregion
    #region Encoding
    /// <inheritdoc cref="NUnit3Settings.Encoding"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Encoding))]
    public static T SetEncoding<T>(this T o, string v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.Encoding, v));
    /// <inheritdoc cref="NUnit3Settings.Encoding"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.Encoding))]
    public static T ResetEncoding<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.Encoding));
    #endregion
    #region ShadowCopy
    /// <inheritdoc cref="NUnit3Settings.ShadowCopy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ShadowCopy))]
    public static T SetShadowCopy<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ShadowCopy, v));
    /// <inheritdoc cref="NUnit3Settings.ShadowCopy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ShadowCopy))]
    public static T ResetShadowCopy<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.ShadowCopy));
    /// <inheritdoc cref="NUnit3Settings.ShadowCopy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ShadowCopy))]
    public static T EnableShadowCopy<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ShadowCopy, true));
    /// <inheritdoc cref="NUnit3Settings.ShadowCopy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ShadowCopy))]
    public static T DisableShadowCopy<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ShadowCopy, false));
    /// <inheritdoc cref="NUnit3Settings.ShadowCopy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ShadowCopy))]
    public static T ToggleShadowCopy<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ShadowCopy, !o.ShadowCopy));
    #endregion
    #region TeamCity
    /// <inheritdoc cref="NUnit3Settings.TeamCity"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TeamCity))]
    public static T SetTeamCity<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.TeamCity, v));
    /// <inheritdoc cref="NUnit3Settings.TeamCity"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TeamCity))]
    public static T ResetTeamCity<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.TeamCity));
    /// <inheritdoc cref="NUnit3Settings.TeamCity"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TeamCity))]
    public static T EnableTeamCity<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.TeamCity, true));
    /// <inheritdoc cref="NUnit3Settings.TeamCity"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TeamCity))]
    public static T DisableTeamCity<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.TeamCity, false));
    /// <inheritdoc cref="NUnit3Settings.TeamCity"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.TeamCity))]
    public static T ToggleTeamCity<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.TeamCity, !o.TeamCity));
    #endregion
    #region LoadUserProfile
    /// <inheritdoc cref="NUnit3Settings.LoadUserProfile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.LoadUserProfile))]
    public static T SetLoadUserProfile<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.LoadUserProfile, v));
    /// <inheritdoc cref="NUnit3Settings.LoadUserProfile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.LoadUserProfile))]
    public static T ResetLoadUserProfile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.LoadUserProfile));
    /// <inheritdoc cref="NUnit3Settings.LoadUserProfile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.LoadUserProfile))]
    public static T EnableLoadUserProfile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.LoadUserProfile, true));
    /// <inheritdoc cref="NUnit3Settings.LoadUserProfile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.LoadUserProfile))]
    public static T DisableLoadUserProfile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.LoadUserProfile, false));
    /// <inheritdoc cref="NUnit3Settings.LoadUserProfile"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.LoadUserProfile))]
    public static T ToggleLoadUserProfile<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.LoadUserProfile, !o.LoadUserProfile));
    #endregion
    #region ListExtensions
    /// <inheritdoc cref="NUnit3Settings.ListExtensions"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ListExtensions))]
    public static T SetListExtensions<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ListExtensions, v));
    /// <inheritdoc cref="NUnit3Settings.ListExtensions"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ListExtensions))]
    public static T ResetListExtensions<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.ListExtensions));
    /// <inheritdoc cref="NUnit3Settings.ListExtensions"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ListExtensions))]
    public static T EnableListExtensions<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ListExtensions, true));
    /// <inheritdoc cref="NUnit3Settings.ListExtensions"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ListExtensions))]
    public static T DisableListExtensions<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ListExtensions, false));
    /// <inheritdoc cref="NUnit3Settings.ListExtensions"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.ListExtensions))]
    public static T ToggleListExtensions<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.ListExtensions, !o.ListExtensions));
    #endregion
    #region SetPrincipalPolicy
    /// <inheritdoc cref="NUnit3Settings.SetPrincipalPolicy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SetPrincipalPolicy))]
    public static T SetSetPrincipalPolicy<T>(this T o, NUnitPrincipalPolicy v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.SetPrincipalPolicy, v));
    /// <inheritdoc cref="NUnit3Settings.SetPrincipalPolicy"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.SetPrincipalPolicy))]
    public static T ResetSetPrincipalPolicy<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.SetPrincipalPolicy));
    #endregion
    #region NoHeader
    /// <inheritdoc cref="NUnit3Settings.NoHeader"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoHeader))]
    public static T SetNoHeader<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoHeader, v));
    /// <inheritdoc cref="NUnit3Settings.NoHeader"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoHeader))]
    public static T ResetNoHeader<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.NoHeader));
    /// <inheritdoc cref="NUnit3Settings.NoHeader"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoHeader))]
    public static T EnableNoHeader<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoHeader, true));
    /// <inheritdoc cref="NUnit3Settings.NoHeader"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoHeader))]
    public static T DisableNoHeader<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoHeader, false));
    /// <inheritdoc cref="NUnit3Settings.NoHeader"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoHeader))]
    public static T ToggleNoHeader<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoHeader, !o.NoHeader));
    #endregion
    #region NoColor
    /// <inheritdoc cref="NUnit3Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="NUnit3Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="NUnit3Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="NUnit3Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="NUnit3Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(NUnit3Settings), Property = nameof(NUnit3Settings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : NUnit3Settings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
}
#endregion
#region NUnitProcessType
/// <summary>Used within <see cref="NUnitTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NUnitProcessType>))]
public partial class NUnitProcessType : Enumeration
{
    public static NUnitProcessType Single = (NUnitProcessType) "Single";
    public static NUnitProcessType Separate = (NUnitProcessType) "Separate";
    public static NUnitProcessType Multiple = (NUnitProcessType) "Multiple";
    public static implicit operator NUnitProcessType(string value)
    {
        return new NUnitProcessType { Value = value };
    }
}
#endregion
#region NUnitPrincipalPolicy
/// <summary>Used within <see cref="NUnitTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NUnitPrincipalPolicy>))]
public partial class NUnitPrincipalPolicy : Enumeration
{
    public static NUnitPrincipalPolicy UnauthenticatedPrincipal = (NUnitPrincipalPolicy) "UnauthenticatedPrincipal";
    public static NUnitPrincipalPolicy NoPrincipal = (NUnitPrincipalPolicy) "NoPrincipal";
    public static NUnitPrincipalPolicy WindowsPrincipal = (NUnitPrincipalPolicy) "WindowsPrincipal";
    public static implicit operator NUnitPrincipalPolicy(string value)
    {
        return new NUnitPrincipalPolicy { Value = value };
    }
}
#endregion
#region NUnitLabelType
/// <summary>Used within <see cref="NUnitTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NUnitLabelType>))]
public partial class NUnitLabelType : Enumeration
{
    public static NUnitLabelType Off = (NUnitLabelType) "Off";
    public static NUnitLabelType On = (NUnitLabelType) "On";
    public static NUnitLabelType All = (NUnitLabelType) "All";
    public static NUnitLabelType OnOutputOnly = (NUnitLabelType) "OnOutputOnly";
    public static NUnitLabelType Before = (NUnitLabelType) "Before";
    public static NUnitLabelType After = (NUnitLabelType) "After";
    public static NUnitLabelType BeforeAndAfter = (NUnitLabelType) "BeforeAndAfter";
    public static implicit operator NUnitLabelType(string value)
    {
        return new NUnitLabelType { Value = value };
    }
}
#endregion
#region NUnitTraceLevel
/// <summary>Used within <see cref="NUnitTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NUnitTraceLevel>))]
public partial class NUnitTraceLevel : Enumeration
{
    public static NUnitTraceLevel Off = (NUnitTraceLevel) "Off";
    public static NUnitTraceLevel Error = (NUnitTraceLevel) "Error";
    public static NUnitTraceLevel Warning = (NUnitTraceLevel) "Warning";
    public static NUnitTraceLevel Info = (NUnitTraceLevel) "Info";
    public static NUnitTraceLevel Verbose = (NUnitTraceLevel) "Verbose";
    public static implicit operator NUnitTraceLevel(string value)
    {
        return new NUnitTraceLevel { Value = value };
    }
}
#endregion
