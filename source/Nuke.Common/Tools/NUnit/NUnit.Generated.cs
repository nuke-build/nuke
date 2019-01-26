// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/NUnit.json
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

namespace Nuke.Common.Tools.NUnit
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NUnitTasks
    {
        /// <summary><p>Path to the NUnit executable.</p></summary>
        public static string NUnitPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NUNIT_EXE") ??
            ToolPathResolver.GetPackageExecutable("NUnit.ConsoleRunner", "nunit3-console.exe");
        public static Action<OutputType, string> NUnitLogger { get; set; } = ProcessManager.DefaultLogger;
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
        public static IReadOnlyCollection<Output> NUnit(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(NUnitPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, NUnitLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> NUnit3(NUnit3Settings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NUnit3Settings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> NUnit3(Configure<NUnit3Settings> configurator)
        {
            return NUnit3(configurator(new NUnit3Settings()));
        }
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static IEnumerable<(NUnit3Settings Settings, IReadOnlyCollection<Output> Output)> NUnit3(CombinatorialConfigure<NUnit3Settings> configurator)
        {
            return configurator(new NUnit3Settings())
                .Select(x => (ToolSettings: x, ReturnValue: NUnit3(x)))
                .Select(x => (x.ToolSettings, x.ReturnValue)).ToList();
        }
    }
    #region NUnit3Settings
    /// <summary><p>Used within <see cref="NUnitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NUnit3Settings : ToolSettings
    {
        /// <summary><p>Path to the NUnit executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NUnitTasks.NUnitPath;
        public override Action<OutputType, string> CustomLogger => NUnitTasks.NUnitLogger;
        /// <summary><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        public virtual IReadOnlyList<string> InputFiles => InputFilesInternal.AsReadOnly();
        internal List<string> InputFilesInternal { get; set; } = new List<string>();
        /// <summary><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        public virtual IReadOnlyList<string> Tests => TestsInternal.AsReadOnly();
        internal List<string> TestsInternal { get; set; } = new List<string>();
        /// <summary><p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p></summary>
        public virtual string TestListFile { get; internal set; }
        /// <summary><p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators ==, !=, =~ and !~. See Test Selection Language for a full description of the syntax.</p></summary>
        public virtual string WhereExpression { get; internal set; }
        /// <summary><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Parameters => ParametersInternal.AsReadOnly();
        internal Dictionary<string, string> ParametersInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Name of a project configuration to load (e.g.: Debug).</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Process isolation for test assemblies. Values: Single, Separate, Multiple. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p></summary>
        public virtual NUnitProcessType Process { get; internal set; }
        /// <summary><p>This option is a synonym for --process=Single</p></summary>
        public virtual bool? InProcess { get; internal set; }
        /// <summary><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        public virtual int? Agents { get; internal set; }
        /// <summary><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        public virtual string Domain { get; internal set; }
        /// <summary><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        public virtual bool? X86 { get; internal set; }
        /// <summary><p>Dispose each test runner after it has finished running its tests</p></summary>
        public virtual bool? DisposeRunners { get; internal set; }
        /// <summary><p>Set timeout for each test case in milliseconds.</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary><p>Set the random seed used to generate test cases.</p></summary>
        public virtual int? Seed { get; internal set; }
        /// <summary><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        public virtual int? Workers { get; internal set; }
        /// <summary><p>Stop run immediately upon any test failure or error.</p></summary>
        public virtual bool? StopOnError { get; internal set; }
        /// <summary><p>Skip any non-test assemblies specified, without error.</p></summary>
        public virtual bool? SkipNonTestAssemblies { get; internal set; }
        /// <summary><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        public virtual bool? DebugAgent { get; internal set; }
        /// <summary><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        public virtual bool? Pause { get; internal set; }
        /// <summary><p>Wait for input before closing console window.</p></summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary><p>Path of the directory to use for output files.</p></summary>
        public virtual string WorkPath { get; internal set; }
        /// <summary><p>File path to contain text output from the tests.</p></summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary><p>File path to contain error output from the tests.</p></summary>
        public virtual string ErrorFile { get; internal set; }
        /// <summary><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        public virtual IReadOnlyList<string> Results => ResultsInternal.AsReadOnly();
        internal List<string> ResultsInternal { get; set; } = new List<string>();
        /// <summary><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        public virtual IReadOnlyList<string> Explores => ExploresInternal.AsReadOnly();
        internal List<string> ExploresInternal { get; set; } = new List<string>();
        /// <summary><p>Don't save any test results.</p></summary>
        public virtual bool? NoResults { get; internal set; }
        /// <summary><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        public virtual NUnitLabelType Labels { get; internal set; }
        /// <summary><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        public virtual NUnitTraceLevel Trace { get; internal set; }
        /// <summary><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        public virtual string Encoding { get; internal set; }
        /// <summary><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        public virtual bool? ShadowCopy { get; internal set; }
        /// <summary><p>Turns on use of TeamCity service messages.</p></summary>
        public virtual bool? TeamCity { get; internal set; }
        /// <summary><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        public virtual bool? LoadUserProfile { get; internal set; }
        /// <summary><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        public virtual bool? ListExtensions { get; internal set; }
        /// <summary><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        public virtual NUnitPrincipalPolicy SetPrincipalPolicy { get; internal set; }
        /// <summary><p>Suppress display of program information at start of run.</p></summary>
        public virtual bool? NoHeader { get; internal set; }
        /// <summary><p>Displays console output without color.</p></summary>
        public virtual bool? NoColor { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NUnit3SettingsExtensions
    /// <summary><p>Used within <see cref="NUnitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NUnit3SettingsExtensions
    {
        #region InputFiles
        /// <summary><p><em>Sets <see cref="NUnit3Settings.InputFiles"/> to a new list.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings SetInputFiles(this NUnit3Settings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NUnit3Settings.InputFiles"/> to a new list.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings SetInputFiles(this NUnit3Settings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings AddInputFiles(this NUnit3Settings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings AddInputFiles(this NUnit3Settings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NUnit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings ClearInputFiles(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveInputFiles(this NUnit3Settings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveInputFiles(this NUnit3Settings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Tests
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Tests"/> to a new list.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings SetTests(this NUnit3Settings toolSettings, params string[] tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal = tests.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Tests"/> to a new list.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings SetTests(this NUnit3Settings toolSettings, IEnumerable<string> tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal = tests.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings AddTests(this NUnit3Settings toolSettings, params string[] tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.AddRange(tests);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings AddTests(this NUnit3Settings toolSettings, IEnumerable<string> tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.AddRange(tests);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NUnit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings ClearTests(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveTests(this NUnit3Settings toolSettings, params string[] tests)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tests);
            toolSettings.TestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveTests(this NUnit3Settings toolSettings, IEnumerable<string> tests)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tests);
            toolSettings.TestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TestListFile
        /// <summary><p><em>Sets <see cref="NUnit3Settings.TestListFile"/>.</em></p><p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p></summary>
        [Pure]
        public static NUnit3Settings SetTestListFile(this NUnit3Settings toolSettings, string testListFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestListFile = testListFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.TestListFile"/>.</em></p><p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p></summary>
        [Pure]
        public static NUnit3Settings ResetTestListFile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestListFile = null;
            return toolSettings;
        }
        #endregion
        #region WhereExpression
        /// <summary><p><em>Sets <see cref="NUnit3Settings.WhereExpression"/>.</em></p><p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators ==, !=, =~ and !~. See Test Selection Language for a full description of the syntax.</p></summary>
        [Pure]
        public static NUnit3Settings SetWhereExpression(this NUnit3Settings toolSettings, string whereExpression)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhereExpression = whereExpression;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.WhereExpression"/>.</em></p><p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators ==, !=, =~ and !~. See Test Selection Language for a full description of the syntax.</p></summary>
        [Pure]
        public static NUnit3Settings ResetWhereExpression(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhereExpression = null;
            return toolSettings;
        }
        #endregion
        #region Parameters
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Parameters"/> to a new dictionary.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static NUnit3Settings SetParameters(this NUnit3Settings toolSettings, IDictionary<string, string> parameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal = parameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NUnit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static NUnit3Settings ClearParameters(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="NUnit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static NUnit3Settings AddParameter(this NUnit3Settings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Add(parameterKey, parameterValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="NUnit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveParameter(this NUnit3Settings toolSettings, string parameterKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Remove(parameterKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="NUnit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static NUnit3Settings SetParameter(this NUnit3Settings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal[parameterKey] = parameterValue;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Configuration"/>.</em></p><p>Name of a project configuration to load (e.g.: Debug).</p></summary>
        [Pure]
        public static NUnit3Settings SetConfiguration(this NUnit3Settings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Configuration"/>.</em></p><p>Name of a project configuration to load (e.g.: Debug).</p></summary>
        [Pure]
        public static NUnit3Settings ResetConfiguration(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Process
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Process"/>.</em></p><p>Process isolation for test assemblies. Values: Single, Separate, Multiple. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p></summary>
        [Pure]
        public static NUnit3Settings SetProcess(this NUnit3Settings toolSettings, NUnitProcessType process)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Process = process;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Process"/>.</em></p><p>Process isolation for test assemblies. Values: Single, Separate, Multiple. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p></summary>
        [Pure]
        public static NUnit3Settings ResetProcess(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Process = null;
            return toolSettings;
        }
        #endregion
        #region InProcess
        /// <summary><p><em>Sets <see cref="NUnit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static NUnit3Settings SetInProcess(this NUnit3Settings toolSettings, bool? inProcess)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = inProcess;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static NUnit3Settings ResetInProcess(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static NUnit3Settings EnableInProcess(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static NUnit3Settings DisableInProcess(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static NUnit3Settings ToggleInProcess(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = !toolSettings.InProcess;
            return toolSettings;
        }
        #endregion
        #region Agents
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Agents"/>.</em></p><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        [Pure]
        public static NUnit3Settings SetAgents(this NUnit3Settings toolSettings, int? agents)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Agents = agents;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Agents"/>.</em></p><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        [Pure]
        public static NUnit3Settings ResetAgents(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Agents = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Domain"/>.</em></p><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        [Pure]
        public static NUnit3Settings SetDomain(this NUnit3Settings toolSettings, string domain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Domain"/>.</em></p><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        [Pure]
        public static NUnit3Settings ResetDomain(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Framework"/>.</em></p><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        [Pure]
        public static NUnit3Settings SetFramework(this NUnit3Settings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Framework"/>.</em></p><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        [Pure]
        public static NUnit3Settings ResetFramework(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region X86
        /// <summary><p><em>Sets <see cref="NUnit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static NUnit3Settings SetX86(this NUnit3Settings toolSettings, bool? x86)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = x86;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static NUnit3Settings ResetX86(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static NUnit3Settings EnableX86(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static NUnit3Settings DisableX86(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleX86(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = !toolSettings.X86;
            return toolSettings;
        }
        #endregion
        #region DisposeRunners
        /// <summary><p><em>Sets <see cref="NUnit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static NUnit3Settings SetDisposeRunners(this NUnit3Settings toolSettings, bool? disposeRunners)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = disposeRunners;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static NUnit3Settings ResetDisposeRunners(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static NUnit3Settings EnableDisposeRunners(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static NUnit3Settings DisableDisposeRunners(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static NUnit3Settings ToggleDisposeRunners(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = !toolSettings.DisposeRunners;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Timeout"/>.</em></p><p>Set timeout for each test case in milliseconds.</p></summary>
        [Pure]
        public static NUnit3Settings SetTimeout(this NUnit3Settings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Timeout"/>.</em></p><p>Set timeout for each test case in milliseconds.</p></summary>
        [Pure]
        public static NUnit3Settings ResetTimeout(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Seed
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Seed"/>.</em></p><p>Set the random seed used to generate test cases.</p></summary>
        [Pure]
        public static NUnit3Settings SetSeed(this NUnit3Settings toolSettings, int? seed)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Seed = seed;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Seed"/>.</em></p><p>Set the random seed used to generate test cases.</p></summary>
        [Pure]
        public static NUnit3Settings ResetSeed(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Seed = null;
            return toolSettings;
        }
        #endregion
        #region Workers
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Workers"/>.</em></p><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        [Pure]
        public static NUnit3Settings SetWorkers(this NUnit3Settings toolSettings, int? workers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Workers = workers;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Workers"/>.</em></p><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        [Pure]
        public static NUnit3Settings ResetWorkers(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Workers = null;
            return toolSettings;
        }
        #endregion
        #region StopOnError
        /// <summary><p><em>Sets <see cref="NUnit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static NUnit3Settings SetStopOnError(this NUnit3Settings toolSettings, bool? stopOnError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = stopOnError;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static NUnit3Settings ResetStopOnError(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static NUnit3Settings EnableStopOnError(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static NUnit3Settings DisableStopOnError(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleStopOnError(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = !toolSettings.StopOnError;
            return toolSettings;
        }
        #endregion
        #region SkipNonTestAssemblies
        /// <summary><p><em>Sets <see cref="NUnit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static NUnit3Settings SetSkipNonTestAssemblies(this NUnit3Settings toolSettings, bool? skipNonTestAssemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = skipNonTestAssemblies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static NUnit3Settings ResetSkipNonTestAssemblies(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static NUnit3Settings EnableSkipNonTestAssemblies(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static NUnit3Settings DisableSkipNonTestAssemblies(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleSkipNonTestAssemblies(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = !toolSettings.SkipNonTestAssemblies;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static NUnit3Settings SetDebug(this NUnit3Settings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static NUnit3Settings ResetDebug(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static NUnit3Settings EnableDebug(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static NUnit3Settings DisableDebug(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleDebug(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region DebugAgent
        /// <summary><p><em>Sets <see cref="NUnit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static NUnit3Settings SetDebugAgent(this NUnit3Settings toolSettings, bool? debugAgent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = debugAgent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static NUnit3Settings ResetDebugAgent(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static NUnit3Settings EnableDebugAgent(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static NUnit3Settings DisableDebugAgent(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleDebugAgent(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = !toolSettings.DebugAgent;
            return toolSettings;
        }
        #endregion
        #region Pause
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static NUnit3Settings SetPause(this NUnit3Settings toolSettings, bool? pause)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = pause;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static NUnit3Settings ResetPause(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static NUnit3Settings EnablePause(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static NUnit3Settings DisablePause(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static NUnit3Settings TogglePause(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = !toolSettings.Pause;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static NUnit3Settings SetWait(this NUnit3Settings toolSettings, bool? wait)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static NUnit3Settings ResetWait(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static NUnit3Settings EnableWait(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static NUnit3Settings DisableWait(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleWait(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region WorkPath
        /// <summary><p><em>Sets <see cref="NUnit3Settings.WorkPath"/>.</em></p><p>Path of the directory to use for output files.</p></summary>
        [Pure]
        public static NUnit3Settings SetWorkPath(this NUnit3Settings toolSettings, string workPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkPath = workPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.WorkPath"/>.</em></p><p>Path of the directory to use for output files.</p></summary>
        [Pure]
        public static NUnit3Settings ResetWorkPath(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkPath = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary><p><em>Sets <see cref="NUnit3Settings.OutputFile"/>.</em></p><p>File path to contain text output from the tests.</p></summary>
        [Pure]
        public static NUnit3Settings SetOutputFile(this NUnit3Settings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.OutputFile"/>.</em></p><p>File path to contain text output from the tests.</p></summary>
        [Pure]
        public static NUnit3Settings ResetOutputFile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ErrorFile
        /// <summary><p><em>Sets <see cref="NUnit3Settings.ErrorFile"/>.</em></p><p>File path to contain error output from the tests.</p></summary>
        [Pure]
        public static NUnit3Settings SetErrorFile(this NUnit3Settings toolSettings, string errorFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorFile = errorFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.ErrorFile"/>.</em></p><p>File path to contain error output from the tests.</p></summary>
        [Pure]
        public static NUnit3Settings ResetErrorFile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorFile = null;
            return toolSettings;
        }
        #endregion
        #region Results
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Results"/> to a new list.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings SetResults(this NUnit3Settings toolSettings, params string[] results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal = results.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Results"/> to a new list.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings SetResults(this NUnit3Settings toolSettings, IEnumerable<string> results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal = results.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings AddResults(this NUnit3Settings toolSettings, params string[] results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.AddRange(results);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings AddResults(this NUnit3Settings toolSettings, IEnumerable<string> results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.AddRange(results);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NUnit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings ClearResults(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveResults(this NUnit3Settings toolSettings, params string[] results)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(results);
            toolSettings.ResultsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveResults(this NUnit3Settings toolSettings, IEnumerable<string> results)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(results);
            toolSettings.ResultsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Explores
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Explores"/> to a new list.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings SetExplores(this NUnit3Settings toolSettings, params string[] explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal = explores.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Explores"/> to a new list.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings SetExplores(this NUnit3Settings toolSettings, IEnumerable<string> explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal = explores.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings AddExplores(this NUnit3Settings toolSettings, params string[] explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.AddRange(explores);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NUnit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings AddExplores(this NUnit3Settings toolSettings, IEnumerable<string> explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.AddRange(explores);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NUnit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings ClearExplores(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveExplores(this NUnit3Settings toolSettings, params string[] explores)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(explores);
            toolSettings.ExploresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NUnit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static NUnit3Settings RemoveExplores(this NUnit3Settings toolSettings, IEnumerable<string> explores)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(explores);
            toolSettings.ExploresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoResults
        /// <summary><p><em>Sets <see cref="NUnit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static NUnit3Settings SetNoResults(this NUnit3Settings toolSettings, bool? noResults)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = noResults;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static NUnit3Settings ResetNoResults(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static NUnit3Settings EnableNoResults(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static NUnit3Settings DisableNoResults(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleNoResults(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = !toolSettings.NoResults;
            return toolSettings;
        }
        #endregion
        #region Labels
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Labels"/>.</em></p><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        [Pure]
        public static NUnit3Settings SetLabels(this NUnit3Settings toolSettings, NUnitLabelType labels)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Labels = labels;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Labels"/>.</em></p><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        [Pure]
        public static NUnit3Settings ResetLabels(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Labels = null;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Trace"/>.</em></p><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        [Pure]
        public static NUnit3Settings SetTrace(this NUnit3Settings toolSettings, NUnitTraceLevel trace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Trace"/>.</em></p><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        [Pure]
        public static NUnit3Settings ResetTrace(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        #endregion
        #region Encoding
        /// <summary><p><em>Sets <see cref="NUnit3Settings.Encoding"/>.</em></p><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        [Pure]
        public static NUnit3Settings SetEncoding(this NUnit3Settings toolSettings, string encoding)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Encoding = encoding;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.Encoding"/>.</em></p><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        [Pure]
        public static NUnit3Settings ResetEncoding(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Encoding = null;
            return toolSettings;
        }
        #endregion
        #region ShadowCopy
        /// <summary><p><em>Sets <see cref="NUnit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static NUnit3Settings SetShadowCopy(this NUnit3Settings toolSettings, bool? shadowCopy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = shadowCopy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static NUnit3Settings ResetShadowCopy(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static NUnit3Settings EnableShadowCopy(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static NUnit3Settings DisableShadowCopy(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleShadowCopy(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = !toolSettings.ShadowCopy;
            return toolSettings;
        }
        #endregion
        #region TeamCity
        /// <summary><p><em>Sets <see cref="NUnit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static NUnit3Settings SetTeamCity(this NUnit3Settings toolSettings, bool? teamCity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = teamCity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static NUnit3Settings ResetTeamCity(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static NUnit3Settings EnableTeamCity(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static NUnit3Settings DisableTeamCity(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleTeamCity(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = !toolSettings.TeamCity;
            return toolSettings;
        }
        #endregion
        #region LoadUserProfile
        /// <summary><p><em>Sets <see cref="NUnit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static NUnit3Settings SetLoadUserProfile(this NUnit3Settings toolSettings, bool? loadUserProfile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = loadUserProfile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static NUnit3Settings ResetLoadUserProfile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static NUnit3Settings EnableLoadUserProfile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static NUnit3Settings DisableLoadUserProfile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleLoadUserProfile(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = !toolSettings.LoadUserProfile;
            return toolSettings;
        }
        #endregion
        #region ListExtensions
        /// <summary><p><em>Sets <see cref="NUnit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static NUnit3Settings SetListExtensions(this NUnit3Settings toolSettings, bool? listExtensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = listExtensions;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static NUnit3Settings ResetListExtensions(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static NUnit3Settings EnableListExtensions(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static NUnit3Settings DisableListExtensions(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleListExtensions(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = !toolSettings.ListExtensions;
            return toolSettings;
        }
        #endregion
        #region SetPrincipalPolicy
        /// <summary><p><em>Sets <see cref="NUnit3Settings.SetPrincipalPolicy"/>.</em></p><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        [Pure]
        public static NUnit3Settings SetSetPrincipalPolicy(this NUnit3Settings toolSettings, NUnitPrincipalPolicy setPrincipalPolicy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetPrincipalPolicy = setPrincipalPolicy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.SetPrincipalPolicy"/>.</em></p><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        [Pure]
        public static NUnit3Settings ResetSetPrincipalPolicy(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetPrincipalPolicy = null;
            return toolSettings;
        }
        #endregion
        #region NoHeader
        /// <summary><p><em>Sets <see cref="NUnit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static NUnit3Settings SetNoHeader(this NUnit3Settings toolSettings, bool? noHeader)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = noHeader;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static NUnit3Settings ResetNoHeader(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static NUnit3Settings EnableNoHeader(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static NUnit3Settings DisableNoHeader(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleNoHeader(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = !toolSettings.NoHeader;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary><p><em>Sets <see cref="NUnit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static NUnit3Settings SetNoColor(this NUnit3Settings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NUnit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static NUnit3Settings ResetNoColor(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NUnit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static NUnit3Settings EnableNoColor(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NUnit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static NUnit3Settings DisableNoColor(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NUnit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static NUnit3Settings ToggleNoColor(this NUnit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NUnitProcessType
    /// <summary><p>Used within <see cref="NUnitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NUnitProcessType>))]
    public partial class NUnitProcessType : Enumeration
    {
        public static NUnitProcessType Single = new NUnitProcessType { Value = "Single" };
        public static NUnitProcessType Separate = new NUnitProcessType { Value = "Separate" };
        public static NUnitProcessType Multiple = new NUnitProcessType { Value = "Multiple" };
    }
    #endregion
    #region NUnitPrincipalPolicy
    /// <summary><p>Used within <see cref="NUnitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NUnitPrincipalPolicy>))]
    public partial class NUnitPrincipalPolicy : Enumeration
    {
        public static NUnitPrincipalPolicy UnauthenticatedPrincipal = new NUnitPrincipalPolicy { Value = "UnauthenticatedPrincipal" };
        public static NUnitPrincipalPolicy NoPrincipal = new NUnitPrincipalPolicy { Value = "NoPrincipal" };
        public static NUnitPrincipalPolicy WindowsPrincipal = new NUnitPrincipalPolicy { Value = "WindowsPrincipal" };
    }
    #endregion
    #region NUnitLabelType
    /// <summary><p>Used within <see cref="NUnitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NUnitLabelType>))]
    public partial class NUnitLabelType : Enumeration
    {
        public static NUnitLabelType Off = new NUnitLabelType { Value = "Off" };
        public static NUnitLabelType On = new NUnitLabelType { Value = "On" };
        public static NUnitLabelType All = new NUnitLabelType { Value = "All" };
    }
    #endregion
    #region NUnitTraceLevel
    /// <summary><p>Used within <see cref="NUnitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NUnitTraceLevel>))]
    public partial class NUnitTraceLevel : Enumeration
    {
        public static NUnitTraceLevel Off = new NUnitTraceLevel { Value = "Off" };
        public static NUnitTraceLevel Error = new NUnitTraceLevel { Value = "Error" };
        public static NUnitTraceLevel Warning = new NUnitTraceLevel { Value = "Warning" };
        public static NUnitTraceLevel Info = new NUnitTraceLevel { Value = "Info" };
        public static NUnitTraceLevel Verbose = new NUnitTraceLevel { Value = "Verbose" };
    }
    #endregion
}
