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

namespace Nuke.Common.Tools.NUnit
{
    /// <summary>
    ///   <p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p>
    ///   <p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(NUnitPackageId)]
    public partial class NUnitTasks
        : IRequireNuGetPackage
    {
        public const string NUnitPackageId = "NUnit.ConsoleRunner";
        /// <summary>
        ///   Path to the NUnit executable.
        /// </summary>
        public static string NUnitPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NUNIT_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("NUnit.ConsoleRunner", "nunit3-console.exe");
        public static Action<OutputType, string> NUnitLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p>
        ///   <p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> NUnit(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(NUnitPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? NUnitLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p>
        ///   <p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="NUnit3Settings.InputFiles"/></li>
        ///     <li><c>--agents</c> via <see cref="NUnit3Settings.Agents"/></li>
        ///     <li><c>--config</c> via <see cref="NUnit3Settings.Configuration"/></li>
        ///     <li><c>--debug</c> via <see cref="NUnit3Settings.Debug"/></li>
        ///     <li><c>--debug-agent</c> via <see cref="NUnit3Settings.DebugAgent"/></li>
        ///     <li><c>--dispose-runners</c> via <see cref="NUnit3Settings.DisposeRunners"/></li>
        ///     <li><c>--domain</c> via <see cref="NUnit3Settings.Domain"/></li>
        ///     <li><c>--encoding</c> via <see cref="NUnit3Settings.Encoding"/></li>
        ///     <li><c>--err</c> via <see cref="NUnit3Settings.ErrorFile"/></li>
        ///     <li><c>--explore</c> via <see cref="NUnit3Settings.Explores"/></li>
        ///     <li><c>--framework</c> via <see cref="NUnit3Settings.Framework"/></li>
        ///     <li><c>--inprocess</c> via <see cref="NUnit3Settings.InProcess"/></li>
        ///     <li><c>--labels</c> via <see cref="NUnit3Settings.Labels"/></li>
        ///     <li><c>--list-extensions</c> via <see cref="NUnit3Settings.ListExtensions"/></li>
        ///     <li><c>--loaduserprofile</c> via <see cref="NUnit3Settings.LoadUserProfile"/></li>
        ///     <li><c>--nocolor</c> via <see cref="NUnit3Settings.NoColor"/></li>
        ///     <li><c>--noheader</c> via <see cref="NUnit3Settings.NoHeader"/></li>
        ///     <li><c>--noresult</c> via <see cref="NUnit3Settings.NoResults"/></li>
        ///     <li><c>--output</c> via <see cref="NUnit3Settings.OutputFile"/></li>
        ///     <li><c>--params</c> via <see cref="NUnit3Settings.Parameters"/></li>
        ///     <li><c>--pause</c> via <see cref="NUnit3Settings.Pause"/></li>
        ///     <li><c>--process</c> via <see cref="NUnit3Settings.Process"/></li>
        ///     <li><c>--result</c> via <see cref="NUnit3Settings.Results"/></li>
        ///     <li><c>--seed</c> via <see cref="NUnit3Settings.Seed"/></li>
        ///     <li><c>--set-principal-policy</c> via <see cref="NUnit3Settings.SetPrincipalPolicy"/></li>
        ///     <li><c>--shadowcopy</c> via <see cref="NUnit3Settings.ShadowCopy"/></li>
        ///     <li><c>--skipnontestassemblies</c> via <see cref="NUnit3Settings.SkipNonTestAssemblies"/></li>
        ///     <li><c>--stoponerror</c> via <see cref="NUnit3Settings.StopOnError"/></li>
        ///     <li><c>--teamcity</c> via <see cref="NUnit3Settings.TeamCity"/></li>
        ///     <li><c>--test</c> via <see cref="NUnit3Settings.Tests"/></li>
        ///     <li><c>--testlist</c> via <see cref="NUnit3Settings.TestListFile"/></li>
        ///     <li><c>--timeout</c> via <see cref="NUnit3Settings.Timeout"/></li>
        ///     <li><c>--trace</c> via <see cref="NUnit3Settings.Trace"/></li>
        ///     <li><c>--wait</c> via <see cref="NUnit3Settings.Wait"/></li>
        ///     <li><c>--where</c> via <see cref="NUnit3Settings.WhereExpression"/></li>
        ///     <li><c>--work</c> via <see cref="NUnit3Settings.WorkPath"/></li>
        ///     <li><c>--workers</c> via <see cref="NUnit3Settings.Workers"/></li>
        ///     <li><c>--x86</c> via <see cref="NUnit3Settings.X86"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NUnit3(NUnit3Settings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NUnit3Settings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p>
        ///   <p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="NUnit3Settings.InputFiles"/></li>
        ///     <li><c>--agents</c> via <see cref="NUnit3Settings.Agents"/></li>
        ///     <li><c>--config</c> via <see cref="NUnit3Settings.Configuration"/></li>
        ///     <li><c>--debug</c> via <see cref="NUnit3Settings.Debug"/></li>
        ///     <li><c>--debug-agent</c> via <see cref="NUnit3Settings.DebugAgent"/></li>
        ///     <li><c>--dispose-runners</c> via <see cref="NUnit3Settings.DisposeRunners"/></li>
        ///     <li><c>--domain</c> via <see cref="NUnit3Settings.Domain"/></li>
        ///     <li><c>--encoding</c> via <see cref="NUnit3Settings.Encoding"/></li>
        ///     <li><c>--err</c> via <see cref="NUnit3Settings.ErrorFile"/></li>
        ///     <li><c>--explore</c> via <see cref="NUnit3Settings.Explores"/></li>
        ///     <li><c>--framework</c> via <see cref="NUnit3Settings.Framework"/></li>
        ///     <li><c>--inprocess</c> via <see cref="NUnit3Settings.InProcess"/></li>
        ///     <li><c>--labels</c> via <see cref="NUnit3Settings.Labels"/></li>
        ///     <li><c>--list-extensions</c> via <see cref="NUnit3Settings.ListExtensions"/></li>
        ///     <li><c>--loaduserprofile</c> via <see cref="NUnit3Settings.LoadUserProfile"/></li>
        ///     <li><c>--nocolor</c> via <see cref="NUnit3Settings.NoColor"/></li>
        ///     <li><c>--noheader</c> via <see cref="NUnit3Settings.NoHeader"/></li>
        ///     <li><c>--noresult</c> via <see cref="NUnit3Settings.NoResults"/></li>
        ///     <li><c>--output</c> via <see cref="NUnit3Settings.OutputFile"/></li>
        ///     <li><c>--params</c> via <see cref="NUnit3Settings.Parameters"/></li>
        ///     <li><c>--pause</c> via <see cref="NUnit3Settings.Pause"/></li>
        ///     <li><c>--process</c> via <see cref="NUnit3Settings.Process"/></li>
        ///     <li><c>--result</c> via <see cref="NUnit3Settings.Results"/></li>
        ///     <li><c>--seed</c> via <see cref="NUnit3Settings.Seed"/></li>
        ///     <li><c>--set-principal-policy</c> via <see cref="NUnit3Settings.SetPrincipalPolicy"/></li>
        ///     <li><c>--shadowcopy</c> via <see cref="NUnit3Settings.ShadowCopy"/></li>
        ///     <li><c>--skipnontestassemblies</c> via <see cref="NUnit3Settings.SkipNonTestAssemblies"/></li>
        ///     <li><c>--stoponerror</c> via <see cref="NUnit3Settings.StopOnError"/></li>
        ///     <li><c>--teamcity</c> via <see cref="NUnit3Settings.TeamCity"/></li>
        ///     <li><c>--test</c> via <see cref="NUnit3Settings.Tests"/></li>
        ///     <li><c>--testlist</c> via <see cref="NUnit3Settings.TestListFile"/></li>
        ///     <li><c>--timeout</c> via <see cref="NUnit3Settings.Timeout"/></li>
        ///     <li><c>--trace</c> via <see cref="NUnit3Settings.Trace"/></li>
        ///     <li><c>--wait</c> via <see cref="NUnit3Settings.Wait"/></li>
        ///     <li><c>--where</c> via <see cref="NUnit3Settings.WhereExpression"/></li>
        ///     <li><c>--work</c> via <see cref="NUnit3Settings.WorkPath"/></li>
        ///     <li><c>--workers</c> via <see cref="NUnit3Settings.Workers"/></li>
        ///     <li><c>--x86</c> via <see cref="NUnit3Settings.X86"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NUnit3(Configure<NUnit3Settings> configurator)
        {
            return NUnit3(configurator(new NUnit3Settings()));
        }
        /// <summary>
        ///   <p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p>
        ///   <p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;inputFiles&gt;</c> via <see cref="NUnit3Settings.InputFiles"/></li>
        ///     <li><c>--agents</c> via <see cref="NUnit3Settings.Agents"/></li>
        ///     <li><c>--config</c> via <see cref="NUnit3Settings.Configuration"/></li>
        ///     <li><c>--debug</c> via <see cref="NUnit3Settings.Debug"/></li>
        ///     <li><c>--debug-agent</c> via <see cref="NUnit3Settings.DebugAgent"/></li>
        ///     <li><c>--dispose-runners</c> via <see cref="NUnit3Settings.DisposeRunners"/></li>
        ///     <li><c>--domain</c> via <see cref="NUnit3Settings.Domain"/></li>
        ///     <li><c>--encoding</c> via <see cref="NUnit3Settings.Encoding"/></li>
        ///     <li><c>--err</c> via <see cref="NUnit3Settings.ErrorFile"/></li>
        ///     <li><c>--explore</c> via <see cref="NUnit3Settings.Explores"/></li>
        ///     <li><c>--framework</c> via <see cref="NUnit3Settings.Framework"/></li>
        ///     <li><c>--inprocess</c> via <see cref="NUnit3Settings.InProcess"/></li>
        ///     <li><c>--labels</c> via <see cref="NUnit3Settings.Labels"/></li>
        ///     <li><c>--list-extensions</c> via <see cref="NUnit3Settings.ListExtensions"/></li>
        ///     <li><c>--loaduserprofile</c> via <see cref="NUnit3Settings.LoadUserProfile"/></li>
        ///     <li><c>--nocolor</c> via <see cref="NUnit3Settings.NoColor"/></li>
        ///     <li><c>--noheader</c> via <see cref="NUnit3Settings.NoHeader"/></li>
        ///     <li><c>--noresult</c> via <see cref="NUnit3Settings.NoResults"/></li>
        ///     <li><c>--output</c> via <see cref="NUnit3Settings.OutputFile"/></li>
        ///     <li><c>--params</c> via <see cref="NUnit3Settings.Parameters"/></li>
        ///     <li><c>--pause</c> via <see cref="NUnit3Settings.Pause"/></li>
        ///     <li><c>--process</c> via <see cref="NUnit3Settings.Process"/></li>
        ///     <li><c>--result</c> via <see cref="NUnit3Settings.Results"/></li>
        ///     <li><c>--seed</c> via <see cref="NUnit3Settings.Seed"/></li>
        ///     <li><c>--set-principal-policy</c> via <see cref="NUnit3Settings.SetPrincipalPolicy"/></li>
        ///     <li><c>--shadowcopy</c> via <see cref="NUnit3Settings.ShadowCopy"/></li>
        ///     <li><c>--skipnontestassemblies</c> via <see cref="NUnit3Settings.SkipNonTestAssemblies"/></li>
        ///     <li><c>--stoponerror</c> via <see cref="NUnit3Settings.StopOnError"/></li>
        ///     <li><c>--teamcity</c> via <see cref="NUnit3Settings.TeamCity"/></li>
        ///     <li><c>--test</c> via <see cref="NUnit3Settings.Tests"/></li>
        ///     <li><c>--testlist</c> via <see cref="NUnit3Settings.TestListFile"/></li>
        ///     <li><c>--timeout</c> via <see cref="NUnit3Settings.Timeout"/></li>
        ///     <li><c>--trace</c> via <see cref="NUnit3Settings.Trace"/></li>
        ///     <li><c>--wait</c> via <see cref="NUnit3Settings.Wait"/></li>
        ///     <li><c>--where</c> via <see cref="NUnit3Settings.WhereExpression"/></li>
        ///     <li><c>--work</c> via <see cref="NUnit3Settings.WorkPath"/></li>
        ///     <li><c>--workers</c> via <see cref="NUnit3Settings.Workers"/></li>
        ///     <li><c>--x86</c> via <see cref="NUnit3Settings.X86"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NUnit3Settings Settings, IReadOnlyCollection<Output> Output)> NUnit3(CombinatorialConfigure<NUnit3Settings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NUnit3, NUnitLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region NUnit3Settings
    /// <summary>
    ///   Used within <see cref="NUnitTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NUnit3Settings : ToolSettings
    {
        /// <summary>
        ///   Path to the NUnit executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NUnitTasks.NUnitPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NUnitTasks.NUnitLogger;
        /// <summary>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.
        /// </summary>
        public virtual IReadOnlyList<string> Tests => TestsInternal.AsReadOnly();
        internal List<string> TestsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   The name (or path) of a file containing a list of tests to run or explore, one per line.
        /// </summary>
        public virtual string TestListFile { get; internal set; }
        /// <summary>
        ///   An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators <c>==</c>, <c>!=</c>, <c>=~</c> and <c>!~</c>. See Test Selection Language for a full description of the syntax.
        /// </summary>
        public virtual string WhereExpression { get; internal set; }
        /// <summary>
        ///   A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the <c>--params</c> option multiple times.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Parameters => ParametersInternal.AsReadOnly();
        internal Dictionary<string, string> ParametersInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Name of a project configuration to load (e.g.: <c>Debug</c>).
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Process isolation for test assemblies. Values: <c>Single</c>, <c>Separate</c>, <c>Multiple</c>. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.
        /// </summary>
        public virtual NUnitProcessType Process { get; internal set; }
        /// <summary>
        ///   This option is a synonym for <c>--process=Single</c>
        /// </summary>
        public virtual bool? InProcess { get; internal set; }
        /// <summary>
        ///   Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.
        /// </summary>
        public virtual int? Agents { get; internal set; }
        /// <summary>
        ///   Domain isolation for test assemblies. Values: <c>None</c>, <c>Single</c>, <c>Multiple</c>. If not specified, defaults to <c>Single</c> for a single assembly or <c>Multiple</c> for more than one.
        /// </summary>
        public virtual string Domain { get; internal set; }
        /// <summary>
        ///   Framework type/version to use for tests. Examples: <c>mono</c>, <c>net-4.5,</c> <c>v4.0</c>, <c>2.0</c>, <c>mono-4.0</c>
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Run tests in a 32-bit process on 64-bit systems.
        /// </summary>
        public virtual bool? X86 { get; internal set; }
        /// <summary>
        ///   Dispose each test runner after it has finished running its tests
        /// </summary>
        public virtual bool? DisposeRunners { get; internal set; }
        /// <summary>
        ///   Set timeout for each test case in milliseconds.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   Set the random seed used to generate test cases.
        /// </summary>
        public virtual int? Seed { get; internal set; }
        /// <summary>
        ///   Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the <c>Parallelizable</c> attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.
        /// </summary>
        public virtual int? Workers { get; internal set; }
        /// <summary>
        ///   Stop run immediately upon any test failure or error.
        /// </summary>
        public virtual bool? StopOnError { get; internal set; }
        /// <summary>
        ///   Skip any non-test assemblies specified, without error.
        /// </summary>
        public virtual bool? SkipNonTestAssemblies { get; internal set; }
        /// <summary>
        ///   Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.
        /// </summary>
        public virtual bool? DebugAgent { get; internal set; }
        /// <summary>
        ///   Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.
        /// </summary>
        public virtual bool? Pause { get; internal set; }
        /// <summary>
        ///   Wait for input before closing console window.
        /// </summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary>
        ///   Path of the directory to use for output files.
        /// </summary>
        public virtual string WorkPath { get; internal set; }
        /// <summary>
        ///   File path to contain text output from the tests.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   File path to contain error output from the tests.
        /// </summary>
        public virtual string ErrorFile { get; internal set; }
        /// <summary>
        ///   An output spec for saving the test results. This option may be repeated.
        /// </summary>
        public virtual IReadOnlyList<string> Results => ResultsInternal.AsReadOnly();
        internal List<string> ResultsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.
        /// </summary>
        public virtual IReadOnlyList<string> Explores => ExploresInternal.AsReadOnly();
        internal List<string> ExploresInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Don't save any test results.
        /// </summary>
        public virtual bool? NoResults { get; internal set; }
        /// <summary>
        ///   Specify whether to write test case names to the output. Values: <c>Off</c>, <c>On</c>, <c>All</c>
        /// </summary>
        public virtual NUnitLabelType Labels { get; internal set; }
        /// <summary>
        ///   Set internal trace level. Values: <c>Off</c>, !<c>Error</c>, <c>Warning</c>, <c>Info</c>, <c>Verbose</c> (<c>Debug</c>)
        /// </summary>
        public virtual NUnitTraceLevel Trace { get; internal set; }
        /// <summary>
        ///   Specify the console codepage, such as <c>utf-8</c>, <c>ascii</c>cc, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.
        /// </summary>
        public virtual string Encoding { get; internal set; }
        /// <summary>
        ///   Tells .NET to copy loaded assemblies to the shadowcopy directory.
        /// </summary>
        public virtual bool? ShadowCopy { get; internal set; }
        /// <summary>
        ///   Turns on use of TeamCity service messages.
        /// </summary>
        public virtual bool? TeamCity { get; internal set; }
        /// <summary>
        ///   Causes the user profile to be loaded in any separate test processes.
        /// </summary>
        public virtual bool? LoadUserProfile { get; internal set; }
        /// <summary>
        ///   Lists all extension points and the extensions installed on each of them.
        /// </summary>
        public virtual bool? ListExtensions { get; internal set; }
        /// <summary>
        ///   Set the principal policy for the test domain. Values: <c>UnauthenticatedPrincipal</c>, <c>NoPrincipal</c>, <c>WindowsPrincipal</c>
        /// </summary>
        public virtual NUnitPrincipalPolicy SetPrincipalPolicy { get; internal set; }
        /// <summary>
        ///   Suppress display of program information at start of run.
        /// </summary>
        public virtual bool? NoHeader { get; internal set; }
        /// <summary>
        ///   Displays console output without color.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", InputFiles)
              .Add("--test={value}", Tests, separator: ',')
              .Add("--testlist={value}", TestListFile)
              .Add("--where={value}", WhereExpression)
              .Add("--params={value}", Parameters, "{key}={value}")
              .Add("--config={value}", Configuration)
              .Add("--process={value}", Process)
              .Add("--inprocess", InProcess)
              .Add("--agents={value}", Agents)
              .Add("--domain={value}", Domain)
              .Add("--framework={value}", Framework)
              .Add("--x86", X86)
              .Add("--dispose-runners", DisposeRunners)
              .Add("--timeout={value}", Timeout)
              .Add("--seed={value}", Seed)
              .Add("--workers={value}", Workers)
              .Add("--stoponerror", StopOnError)
              .Add("--skipnontestassemblies", SkipNonTestAssemblies)
              .Add("--debug", Debug)
              .Add("--debug-agent", DebugAgent)
              .Add("--pause", Pause)
              .Add("--wait", Wait)
              .Add("--work={value}", WorkPath)
              .Add("--output={value}", OutputFile)
              .Add("--err={value}", ErrorFile)
              .Add("--result={value}", Results)
              .Add("--explore={value}", Explores)
              .Add("--noresult", NoResults)
              .Add("--labels={value}", Labels)
              .Add("--trace={value}", Trace)
              .Add("--encoding={value}", Encoding)
              .Add("--shadowcopy", ShadowCopy)
              .Add("--teamcity", TeamCity)
              .Add("--loaduserprofile", LoadUserProfile)
              .Add("--list-extensions", ListExtensions)
              .Add("--set-principal-policy={value}", SetPrincipalPolicy)
              .Add("--noheader", NoHeader)
              .Add("--nocolor", NoColor);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NUnit3SettingsExtensions
    /// <summary>
    ///   Used within <see cref="NUnitTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NUnit3SettingsExtensions
    {
        #region InputFiles
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.InputFiles"/> to a new list</em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T SetInputFiles<T>(this T toolSettings, params string[] inputFiles) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.InputFiles"/> to a new list</em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T SetInputFiles<T>(this T toolSettings, IEnumerable<string> inputFiles) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.InputFiles"/></em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T AddInputFiles<T>(this T toolSettings, params string[] inputFiles) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.InputFiles"/></em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T AddInputFiles<T>(this T toolSettings, IEnumerable<string> inputFiles) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NUnit3Settings.InputFiles"/></em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T ClearInputFiles<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.InputFiles"/></em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T RemoveInputFiles<T>(this T toolSettings, params string[] inputFiles) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.InputFiles"/></em></p>
        ///   <p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (<c>.nunit</c>) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p>
        /// </summary>
        [Pure]
        public static T RemoveInputFiles<T>(this T toolSettings, IEnumerable<string> inputFiles) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Tests
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Tests"/> to a new list</em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T SetTests<T>(this T toolSettings, params string[] tests) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal = tests.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Tests"/> to a new list</em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T SetTests<T>(this T toolSettings, IEnumerable<string> tests) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal = tests.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.Tests"/></em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T AddTests<T>(this T toolSettings, params string[] tests) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.AddRange(tests);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.Tests"/></em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T AddTests<T>(this T toolSettings, IEnumerable<string> tests) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.AddRange(tests);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NUnit3Settings.Tests"/></em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T ClearTests<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.Tests"/></em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T RemoveTests<T>(this T toolSettings, params string[] tests) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tests);
            toolSettings.TestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.Tests"/></em></p>
        ///   <p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p>
        /// </summary>
        [Pure]
        public static T RemoveTests<T>(this T toolSettings, IEnumerable<string> tests) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tests);
            toolSettings.TestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TestListFile
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.TestListFile"/></em></p>
        ///   <p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p>
        /// </summary>
        [Pure]
        public static T SetTestListFile<T>(this T toolSettings, string testListFile) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestListFile = testListFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.TestListFile"/></em></p>
        ///   <p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p>
        /// </summary>
        [Pure]
        public static T ResetTestListFile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestListFile = null;
            return toolSettings;
        }
        #endregion
        #region WhereExpression
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.WhereExpression"/></em></p>
        ///   <p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators <c>==</c>, <c>!=</c>, <c>=~</c> and <c>!~</c>. See Test Selection Language for a full description of the syntax.</p>
        /// </summary>
        [Pure]
        public static T SetWhereExpression<T>(this T toolSettings, string whereExpression) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhereExpression = whereExpression;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.WhereExpression"/></em></p>
        ///   <p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators <c>==</c>, <c>!=</c>, <c>=~</c> and <c>!~</c>. See Test Selection Language for a full description of the syntax.</p>
        /// </summary>
        [Pure]
        public static T ResetWhereExpression<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhereExpression = null;
            return toolSettings;
        }
        #endregion
        #region Parameters
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Parameters"/> to a new dictionary</em></p>
        ///   <p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the <c>--params</c> option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetParameters<T>(this T toolSettings, IDictionary<string, string> parameters) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal = parameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NUnit3Settings.Parameters"/></em></p>
        ///   <p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the <c>--params</c> option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearParameters<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="NUnit3Settings.Parameters"/></em></p>
        ///   <p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the <c>--params</c> option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddParameter<T>(this T toolSettings, string parameterKey, string parameterValue) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Add(parameterKey, parameterValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="NUnit3Settings.Parameters"/></em></p>
        ///   <p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the <c>--params</c> option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveParameter<T>(this T toolSettings, string parameterKey) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Remove(parameterKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="NUnit3Settings.Parameters"/></em></p>
        ///   <p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the <c>--params</c> option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetParameter<T>(this T toolSettings, string parameterKey, string parameterValue) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal[parameterKey] = parameterValue;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Configuration"/></em></p>
        ///   <p>Name of a project configuration to load (e.g.: <c>Debug</c>).</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Configuration"/></em></p>
        ///   <p>Name of a project configuration to load (e.g.: <c>Debug</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Process
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Process"/></em></p>
        ///   <p>Process isolation for test assemblies. Values: <c>Single</c>, <c>Separate</c>, <c>Multiple</c>. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetProcess<T>(this T toolSettings, NUnitProcessType process) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Process = process;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Process"/></em></p>
        ///   <p>Process isolation for test assemblies. Values: <c>Single</c>, <c>Separate</c>, <c>Multiple</c>. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetProcess<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Process = null;
            return toolSettings;
        }
        #endregion
        #region InProcess
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.InProcess"/></em></p>
        ///   <p>This option is a synonym for <c>--process=Single</c></p>
        /// </summary>
        [Pure]
        public static T SetInProcess<T>(this T toolSettings, bool? inProcess) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = inProcess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.InProcess"/></em></p>
        ///   <p>This option is a synonym for <c>--process=Single</c></p>
        /// </summary>
        [Pure]
        public static T ResetInProcess<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.InProcess"/></em></p>
        ///   <p>This option is a synonym for <c>--process=Single</c></p>
        /// </summary>
        [Pure]
        public static T EnableInProcess<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.InProcess"/></em></p>
        ///   <p>This option is a synonym for <c>--process=Single</c></p>
        /// </summary>
        [Pure]
        public static T DisableInProcess<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.InProcess"/></em></p>
        ///   <p>This option is a synonym for <c>--process=Single</c></p>
        /// </summary>
        [Pure]
        public static T ToggleInProcess<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = !toolSettings.InProcess;
            return toolSettings;
        }
        #endregion
        #region Agents
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Agents"/></em></p>
        ///   <p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetAgents<T>(this T toolSettings, int? agents) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Agents = agents;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Agents"/></em></p>
        ///   <p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetAgents<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Agents = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Domain"/></em></p>
        ///   <p>Domain isolation for test assemblies. Values: <c>None</c>, <c>Single</c>, <c>Multiple</c>. If not specified, defaults to <c>Single</c> for a single assembly or <c>Multiple</c> for more than one.</p>
        /// </summary>
        [Pure]
        public static T SetDomain<T>(this T toolSettings, string domain) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Domain"/></em></p>
        ///   <p>Domain isolation for test assemblies. Values: <c>None</c>, <c>Single</c>, <c>Multiple</c>. If not specified, defaults to <c>Single</c> for a single assembly or <c>Multiple</c> for more than one.</p>
        /// </summary>
        [Pure]
        public static T ResetDomain<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Framework"/></em></p>
        ///   <p>Framework type/version to use for tests. Examples: <c>mono</c>, <c>net-4.5,</c> <c>v4.0</c>, <c>2.0</c>, <c>mono-4.0</c></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Framework"/></em></p>
        ///   <p>Framework type/version to use for tests. Examples: <c>mono</c>, <c>net-4.5,</c> <c>v4.0</c>, <c>2.0</c>, <c>mono-4.0</c></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region X86
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.X86"/></em></p>
        ///   <p>Run tests in a 32-bit process on 64-bit systems.</p>
        /// </summary>
        [Pure]
        public static T SetX86<T>(this T toolSettings, bool? x86) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = x86;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.X86"/></em></p>
        ///   <p>Run tests in a 32-bit process on 64-bit systems.</p>
        /// </summary>
        [Pure]
        public static T ResetX86<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.X86"/></em></p>
        ///   <p>Run tests in a 32-bit process on 64-bit systems.</p>
        /// </summary>
        [Pure]
        public static T EnableX86<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.X86"/></em></p>
        ///   <p>Run tests in a 32-bit process on 64-bit systems.</p>
        /// </summary>
        [Pure]
        public static T DisableX86<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.X86"/></em></p>
        ///   <p>Run tests in a 32-bit process on 64-bit systems.</p>
        /// </summary>
        [Pure]
        public static T ToggleX86<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = !toolSettings.X86;
            return toolSettings;
        }
        #endregion
        #region DisposeRunners
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.DisposeRunners"/></em></p>
        ///   <p>Dispose each test runner after it has finished running its tests</p>
        /// </summary>
        [Pure]
        public static T SetDisposeRunners<T>(this T toolSettings, bool? disposeRunners) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = disposeRunners;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.DisposeRunners"/></em></p>
        ///   <p>Dispose each test runner after it has finished running its tests</p>
        /// </summary>
        [Pure]
        public static T ResetDisposeRunners<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.DisposeRunners"/></em></p>
        ///   <p>Dispose each test runner after it has finished running its tests</p>
        /// </summary>
        [Pure]
        public static T EnableDisposeRunners<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.DisposeRunners"/></em></p>
        ///   <p>Dispose each test runner after it has finished running its tests</p>
        /// </summary>
        [Pure]
        public static T DisableDisposeRunners<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.DisposeRunners"/></em></p>
        ///   <p>Dispose each test runner after it has finished running its tests</p>
        /// </summary>
        [Pure]
        public static T ToggleDisposeRunners<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = !toolSettings.DisposeRunners;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Timeout"/></em></p>
        ///   <p>Set timeout for each test case in milliseconds.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Timeout"/></em></p>
        ///   <p>Set timeout for each test case in milliseconds.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Seed
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Seed"/></em></p>
        ///   <p>Set the random seed used to generate test cases.</p>
        /// </summary>
        [Pure]
        public static T SetSeed<T>(this T toolSettings, int? seed) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Seed = seed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Seed"/></em></p>
        ///   <p>Set the random seed used to generate test cases.</p>
        /// </summary>
        [Pure]
        public static T ResetSeed<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Seed = null;
            return toolSettings;
        }
        #endregion
        #region Workers
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Workers"/></em></p>
        ///   <p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the <c>Parallelizable</c> attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p>
        /// </summary>
        [Pure]
        public static T SetWorkers<T>(this T toolSettings, int? workers) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Workers = workers;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Workers"/></em></p>
        ///   <p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the <c>Parallelizable</c> attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p>
        /// </summary>
        [Pure]
        public static T ResetWorkers<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Workers = null;
            return toolSettings;
        }
        #endregion
        #region StopOnError
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.StopOnError"/></em></p>
        ///   <p>Stop run immediately upon any test failure or error.</p>
        /// </summary>
        [Pure]
        public static T SetStopOnError<T>(this T toolSettings, bool? stopOnError) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = stopOnError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.StopOnError"/></em></p>
        ///   <p>Stop run immediately upon any test failure or error.</p>
        /// </summary>
        [Pure]
        public static T ResetStopOnError<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.StopOnError"/></em></p>
        ///   <p>Stop run immediately upon any test failure or error.</p>
        /// </summary>
        [Pure]
        public static T EnableStopOnError<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.StopOnError"/></em></p>
        ///   <p>Stop run immediately upon any test failure or error.</p>
        /// </summary>
        [Pure]
        public static T DisableStopOnError<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.StopOnError"/></em></p>
        ///   <p>Stop run immediately upon any test failure or error.</p>
        /// </summary>
        [Pure]
        public static T ToggleStopOnError<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = !toolSettings.StopOnError;
            return toolSettings;
        }
        #endregion
        #region SkipNonTestAssemblies
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.SkipNonTestAssemblies"/></em></p>
        ///   <p>Skip any non-test assemblies specified, without error.</p>
        /// </summary>
        [Pure]
        public static T SetSkipNonTestAssemblies<T>(this T toolSettings, bool? skipNonTestAssemblies) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = skipNonTestAssemblies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.SkipNonTestAssemblies"/></em></p>
        ///   <p>Skip any non-test assemblies specified, without error.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipNonTestAssemblies<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.SkipNonTestAssemblies"/></em></p>
        ///   <p>Skip any non-test assemblies specified, without error.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipNonTestAssemblies<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.SkipNonTestAssemblies"/></em></p>
        ///   <p>Skip any non-test assemblies specified, without error.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipNonTestAssemblies<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.SkipNonTestAssemblies"/></em></p>
        ///   <p>Skip any non-test assemblies specified, without error.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipNonTestAssemblies<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = !toolSettings.SkipNonTestAssemblies;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Debug"/></em></p>
        ///   <p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Debug"/></em></p>
        ///   <p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.Debug"/></em></p>
        ///   <p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.Debug"/></em></p>
        ///   <p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.Debug"/></em></p>
        ///   <p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region DebugAgent
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.DebugAgent"/></em></p>
        ///   <p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p>
        /// </summary>
        [Pure]
        public static T SetDebugAgent<T>(this T toolSettings, bool? debugAgent) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = debugAgent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.DebugAgent"/></em></p>
        ///   <p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p>
        /// </summary>
        [Pure]
        public static T ResetDebugAgent<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.DebugAgent"/></em></p>
        ///   <p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p>
        /// </summary>
        [Pure]
        public static T EnableDebugAgent<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.DebugAgent"/></em></p>
        ///   <p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p>
        /// </summary>
        [Pure]
        public static T DisableDebugAgent<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.DebugAgent"/></em></p>
        ///   <p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebugAgent<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = !toolSettings.DebugAgent;
            return toolSettings;
        }
        #endregion
        #region Pause
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Pause"/></em></p>
        ///   <p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.</p>
        /// </summary>
        [Pure]
        public static T SetPause<T>(this T toolSettings, bool? pause) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = pause;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Pause"/></em></p>
        ///   <p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.</p>
        /// </summary>
        [Pure]
        public static T ResetPause<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.Pause"/></em></p>
        ///   <p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.</p>
        /// </summary>
        [Pure]
        public static T EnablePause<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.Pause"/></em></p>
        ///   <p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.</p>
        /// </summary>
        [Pure]
        public static T DisablePause<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.Pause"/></em></p>
        ///   <p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where <c>--debug </c>does not work.</p>
        /// </summary>
        [Pure]
        public static T TogglePause<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = !toolSettings.Pause;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Wait"/></em></p>
        ///   <p>Wait for input before closing console window.</p>
        /// </summary>
        [Pure]
        public static T SetWait<T>(this T toolSettings, bool? wait) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Wait"/></em></p>
        ///   <p>Wait for input before closing console window.</p>
        /// </summary>
        [Pure]
        public static T ResetWait<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.Wait"/></em></p>
        ///   <p>Wait for input before closing console window.</p>
        /// </summary>
        [Pure]
        public static T EnableWait<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.Wait"/></em></p>
        ///   <p>Wait for input before closing console window.</p>
        /// </summary>
        [Pure]
        public static T DisableWait<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.Wait"/></em></p>
        ///   <p>Wait for input before closing console window.</p>
        /// </summary>
        [Pure]
        public static T ToggleWait<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region WorkPath
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.WorkPath"/></em></p>
        ///   <p>Path of the directory to use for output files.</p>
        /// </summary>
        [Pure]
        public static T SetWorkPath<T>(this T toolSettings, string workPath) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkPath = workPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.WorkPath"/></em></p>
        ///   <p>Path of the directory to use for output files.</p>
        /// </summary>
        [Pure]
        public static T ResetWorkPath<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkPath = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.OutputFile"/></em></p>
        ///   <p>File path to contain text output from the tests.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.OutputFile"/></em></p>
        ///   <p>File path to contain text output from the tests.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ErrorFile
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.ErrorFile"/></em></p>
        ///   <p>File path to contain error output from the tests.</p>
        /// </summary>
        [Pure]
        public static T SetErrorFile<T>(this T toolSettings, string errorFile) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorFile = errorFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.ErrorFile"/></em></p>
        ///   <p>File path to contain error output from the tests.</p>
        /// </summary>
        [Pure]
        public static T ResetErrorFile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorFile = null;
            return toolSettings;
        }
        #endregion
        #region Results
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Results"/> to a new list</em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T SetResults<T>(this T toolSettings, params string[] results) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal = results.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Results"/> to a new list</em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T SetResults<T>(this T toolSettings, IEnumerable<string> results) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal = results.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.Results"/></em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T AddResults<T>(this T toolSettings, params string[] results) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.AddRange(results);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.Results"/></em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T AddResults<T>(this T toolSettings, IEnumerable<string> results) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.AddRange(results);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NUnit3Settings.Results"/></em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T ClearResults<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.Results"/></em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T RemoveResults<T>(this T toolSettings, params string[] results) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(results);
            toolSettings.ResultsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.Results"/></em></p>
        ///   <p>An output spec for saving the test results. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T RemoveResults<T>(this T toolSettings, IEnumerable<string> results) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(results);
            toolSettings.ResultsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Explores
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Explores"/> to a new list</em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T SetExplores<T>(this T toolSettings, params string[] explores) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal = explores.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Explores"/> to a new list</em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T SetExplores<T>(this T toolSettings, IEnumerable<string> explores) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal = explores.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.Explores"/></em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T AddExplores<T>(this T toolSettings, params string[] explores) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.AddRange(explores);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NUnit3Settings.Explores"/></em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T AddExplores<T>(this T toolSettings, IEnumerable<string> explores) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.AddRange(explores);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NUnit3Settings.Explores"/></em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T ClearExplores<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.Explores"/></em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T RemoveExplores<T>(this T toolSettings, params string[] explores) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(explores);
            toolSettings.ExploresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NUnit3Settings.Explores"/></em></p>
        ///   <p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p>
        /// </summary>
        [Pure]
        public static T RemoveExplores<T>(this T toolSettings, IEnumerable<string> explores) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(explores);
            toolSettings.ExploresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoResults
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.NoResults"/></em></p>
        ///   <p>Don't save any test results.</p>
        /// </summary>
        [Pure]
        public static T SetNoResults<T>(this T toolSettings, bool? noResults) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = noResults;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.NoResults"/></em></p>
        ///   <p>Don't save any test results.</p>
        /// </summary>
        [Pure]
        public static T ResetNoResults<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.NoResults"/></em></p>
        ///   <p>Don't save any test results.</p>
        /// </summary>
        [Pure]
        public static T EnableNoResults<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.NoResults"/></em></p>
        ///   <p>Don't save any test results.</p>
        /// </summary>
        [Pure]
        public static T DisableNoResults<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.NoResults"/></em></p>
        ///   <p>Don't save any test results.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoResults<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = !toolSettings.NoResults;
            return toolSettings;
        }
        #endregion
        #region Labels
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Labels"/></em></p>
        ///   <p>Specify whether to write test case names to the output. Values: <c>Off</c>, <c>On</c>, <c>All</c></p>
        /// </summary>
        [Pure]
        public static T SetLabels<T>(this T toolSettings, NUnitLabelType labels) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Labels = labels;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Labels"/></em></p>
        ///   <p>Specify whether to write test case names to the output. Values: <c>Off</c>, <c>On</c>, <c>All</c></p>
        /// </summary>
        [Pure]
        public static T ResetLabels<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Labels = null;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Trace"/></em></p>
        ///   <p>Set internal trace level. Values: <c>Off</c>, !<c>Error</c>, <c>Warning</c>, <c>Info</c>, <c>Verbose</c> (<c>Debug</c>)</p>
        /// </summary>
        [Pure]
        public static T SetTrace<T>(this T toolSettings, NUnitTraceLevel trace) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Trace"/></em></p>
        ///   <p>Set internal trace level. Values: <c>Off</c>, !<c>Error</c>, <c>Warning</c>, <c>Info</c>, <c>Verbose</c> (<c>Debug</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetTrace<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        #endregion
        #region Encoding
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.Encoding"/></em></p>
        ///   <p>Specify the console codepage, such as <c>utf-8</c>, <c>ascii</c>cc, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p>
        /// </summary>
        [Pure]
        public static T SetEncoding<T>(this T toolSettings, string encoding) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Encoding = encoding;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.Encoding"/></em></p>
        ///   <p>Specify the console codepage, such as <c>utf-8</c>, <c>ascii</c>cc, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p>
        /// </summary>
        [Pure]
        public static T ResetEncoding<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Encoding = null;
            return toolSettings;
        }
        #endregion
        #region ShadowCopy
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.ShadowCopy"/></em></p>
        ///   <p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p>
        /// </summary>
        [Pure]
        public static T SetShadowCopy<T>(this T toolSettings, bool? shadowCopy) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = shadowCopy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.ShadowCopy"/></em></p>
        ///   <p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p>
        /// </summary>
        [Pure]
        public static T ResetShadowCopy<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.ShadowCopy"/></em></p>
        ///   <p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p>
        /// </summary>
        [Pure]
        public static T EnableShadowCopy<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.ShadowCopy"/></em></p>
        ///   <p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p>
        /// </summary>
        [Pure]
        public static T DisableShadowCopy<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.ShadowCopy"/></em></p>
        ///   <p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p>
        /// </summary>
        [Pure]
        public static T ToggleShadowCopy<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = !toolSettings.ShadowCopy;
            return toolSettings;
        }
        #endregion
        #region TeamCity
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.TeamCity"/></em></p>
        ///   <p>Turns on use of TeamCity service messages.</p>
        /// </summary>
        [Pure]
        public static T SetTeamCity<T>(this T toolSettings, bool? teamCity) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = teamCity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.TeamCity"/></em></p>
        ///   <p>Turns on use of TeamCity service messages.</p>
        /// </summary>
        [Pure]
        public static T ResetTeamCity<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.TeamCity"/></em></p>
        ///   <p>Turns on use of TeamCity service messages.</p>
        /// </summary>
        [Pure]
        public static T EnableTeamCity<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.TeamCity"/></em></p>
        ///   <p>Turns on use of TeamCity service messages.</p>
        /// </summary>
        [Pure]
        public static T DisableTeamCity<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.TeamCity"/></em></p>
        ///   <p>Turns on use of TeamCity service messages.</p>
        /// </summary>
        [Pure]
        public static T ToggleTeamCity<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = !toolSettings.TeamCity;
            return toolSettings;
        }
        #endregion
        #region LoadUserProfile
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.LoadUserProfile"/></em></p>
        ///   <p>Causes the user profile to be loaded in any separate test processes.</p>
        /// </summary>
        [Pure]
        public static T SetLoadUserProfile<T>(this T toolSettings, bool? loadUserProfile) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = loadUserProfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.LoadUserProfile"/></em></p>
        ///   <p>Causes the user profile to be loaded in any separate test processes.</p>
        /// </summary>
        [Pure]
        public static T ResetLoadUserProfile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.LoadUserProfile"/></em></p>
        ///   <p>Causes the user profile to be loaded in any separate test processes.</p>
        /// </summary>
        [Pure]
        public static T EnableLoadUserProfile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.LoadUserProfile"/></em></p>
        ///   <p>Causes the user profile to be loaded in any separate test processes.</p>
        /// </summary>
        [Pure]
        public static T DisableLoadUserProfile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.LoadUserProfile"/></em></p>
        ///   <p>Causes the user profile to be loaded in any separate test processes.</p>
        /// </summary>
        [Pure]
        public static T ToggleLoadUserProfile<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = !toolSettings.LoadUserProfile;
            return toolSettings;
        }
        #endregion
        #region ListExtensions
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.ListExtensions"/></em></p>
        ///   <p>Lists all extension points and the extensions installed on each of them.</p>
        /// </summary>
        [Pure]
        public static T SetListExtensions<T>(this T toolSettings, bool? listExtensions) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = listExtensions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.ListExtensions"/></em></p>
        ///   <p>Lists all extension points and the extensions installed on each of them.</p>
        /// </summary>
        [Pure]
        public static T ResetListExtensions<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.ListExtensions"/></em></p>
        ///   <p>Lists all extension points and the extensions installed on each of them.</p>
        /// </summary>
        [Pure]
        public static T EnableListExtensions<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.ListExtensions"/></em></p>
        ///   <p>Lists all extension points and the extensions installed on each of them.</p>
        /// </summary>
        [Pure]
        public static T DisableListExtensions<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.ListExtensions"/></em></p>
        ///   <p>Lists all extension points and the extensions installed on each of them.</p>
        /// </summary>
        [Pure]
        public static T ToggleListExtensions<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = !toolSettings.ListExtensions;
            return toolSettings;
        }
        #endregion
        #region SetPrincipalPolicy
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.SetPrincipalPolicy"/></em></p>
        ///   <p>Set the principal policy for the test domain. Values: <c>UnauthenticatedPrincipal</c>, <c>NoPrincipal</c>, <c>WindowsPrincipal</c></p>
        /// </summary>
        [Pure]
        public static T SetSetPrincipalPolicy<T>(this T toolSettings, NUnitPrincipalPolicy setPrincipalPolicy) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetPrincipalPolicy = setPrincipalPolicy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.SetPrincipalPolicy"/></em></p>
        ///   <p>Set the principal policy for the test domain. Values: <c>UnauthenticatedPrincipal</c>, <c>NoPrincipal</c>, <c>WindowsPrincipal</c></p>
        /// </summary>
        [Pure]
        public static T ResetSetPrincipalPolicy<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetPrincipalPolicy = null;
            return toolSettings;
        }
        #endregion
        #region NoHeader
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.NoHeader"/></em></p>
        ///   <p>Suppress display of program information at start of run.</p>
        /// </summary>
        [Pure]
        public static T SetNoHeader<T>(this T toolSettings, bool? noHeader) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = noHeader;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.NoHeader"/></em></p>
        ///   <p>Suppress display of program information at start of run.</p>
        /// </summary>
        [Pure]
        public static T ResetNoHeader<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.NoHeader"/></em></p>
        ///   <p>Suppress display of program information at start of run.</p>
        /// </summary>
        [Pure]
        public static T EnableNoHeader<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.NoHeader"/></em></p>
        ///   <p>Suppress display of program information at start of run.</p>
        /// </summary>
        [Pure]
        public static T DisableNoHeader<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.NoHeader"/></em></p>
        ///   <p>Suppress display of program information at start of run.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoHeader<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = !toolSettings.NoHeader;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="NUnit3Settings.NoColor"/></em></p>
        ///   <p>Displays console output without color.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NUnit3Settings.NoColor"/></em></p>
        ///   <p>Displays console output without color.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NUnit3Settings.NoColor"/></em></p>
        ///   <p>Displays console output without color.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NUnit3Settings.NoColor"/></em></p>
        ///   <p>Displays console output without color.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NUnit3Settings.NoColor"/></em></p>
        ///   <p>Displays console output without color.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : NUnit3Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NUnitProcessType
    /// <summary>
    ///   Used within <see cref="NUnitTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NUnitTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NUnitTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NUnitLabelType>))]
    public partial class NUnitLabelType : Enumeration
    {
        public static NUnitLabelType Off = (NUnitLabelType) "Off";
        public static NUnitLabelType On = (NUnitLabelType) "On";
        public static NUnitLabelType All = (NUnitLabelType) "All";
        public static implicit operator NUnitLabelType(string value)
        {
            return new NUnitLabelType { Value = value };
        }
    }
    #endregion
    #region NUnitTraceLevel
    /// <summary>
    ///   Used within <see cref="NUnitTasks"/>.
    /// </summary>
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
}
