// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Nunit3.json.

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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Nunit
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NunitTasks
    {
        /// <summary><p>Path to the Nunit executable.</p></summary>
        public static string NunitPath => ToolPathResolver.GetPackageExecutable("NUnit.ConsoleRunner", "nunit3-console.exe");
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
        public static IEnumerable<string> Nunit(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool redirectOutput = false, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(NunitPath, arguments, workingDirectory, environmentVariables, timeout, redirectOutput, outputFilter);
            process.AssertZeroExitCode();
            return process.HasOutput ? process.Output.Select(x => x.Text) : null;
        }
        static partial void PreProcess(Nunit3Settings toolSettings);
        static partial void PostProcess(Nunit3Settings toolSettings);
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static void Nunit3(Configure<Nunit3Settings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new Nunit3Settings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static void Nunit3(List<string> inputFiles, Configure<Nunit3Settings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            Nunit3(x => configurator(x).SetInputFiles(inputFiles));
        }
    }
    #region Nunit3Settings
    /// <summary><p>Used within <see cref="NunitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Nunit3Settings : ToolSettings
    {
        /// <summary><p>Path to the Nunit executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NunitTasks.NunitPath;
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
        public virtual NunitProcessType Process { get; internal set; }
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
        public virtual NunitLabelType Labels { get; internal set; }
        /// <summary><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        public virtual NunitTraceLevel Trace { get; internal set; }
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
        public virtual NunitPrincipalPolicy SetPrincipalPolicy { get; internal set; }
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
    #region Nunit3SettingsExtensions
    /// <summary><p>Used within <see cref="NunitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class Nunit3SettingsExtensions
    {
        #region InputFiles
        /// <summary><p><em>Sets <see cref="Nunit3Settings.InputFiles"/> to a new list.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings SetInputFiles(this Nunit3Settings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Nunit3Settings.InputFiles"/> to a new list.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings SetInputFiles(this Nunit3Settings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal = inputFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings AddInputFiles(this Nunit3Settings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings AddInputFiles(this Nunit3Settings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.AddRange(inputFiles);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Nunit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings ClearInputFiles(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveInputFiles(this Nunit3Settings toolSettings, params string[] inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.InputFiles"/>.</em></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveInputFiles(this Nunit3Settings toolSettings, IEnumerable<string> inputFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(inputFiles);
            toolSettings.InputFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Tests
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Tests"/> to a new list.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings SetTests(this Nunit3Settings toolSettings, params string[] tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal = tests.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Tests"/> to a new list.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings SetTests(this Nunit3Settings toolSettings, IEnumerable<string> tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal = tests.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings AddTests(this Nunit3Settings toolSettings, params string[] tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.AddRange(tests);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings AddTests(this Nunit3Settings toolSettings, IEnumerable<string> tests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.AddRange(tests);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Nunit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings ClearTests(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveTests(this Nunit3Settings toolSettings, params string[] tests)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tests);
            toolSettings.TestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.Tests"/>.</em></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveTests(this Nunit3Settings toolSettings, IEnumerable<string> tests)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tests);
            toolSettings.TestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TestListFile
        /// <summary><p><em>Sets <see cref="Nunit3Settings.TestListFile"/>.</em></p><p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p></summary>
        [Pure]
        public static Nunit3Settings SetTestListFile(this Nunit3Settings toolSettings, string testListFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestListFile = testListFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.TestListFile"/>.</em></p><p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p></summary>
        [Pure]
        public static Nunit3Settings ResetTestListFile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestListFile = null;
            return toolSettings;
        }
        #endregion
        #region WhereExpression
        /// <summary><p><em>Sets <see cref="Nunit3Settings.WhereExpression"/>.</em></p><p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators ==, !=, =~ and !~. See Test Selection Language for a full description of the syntax.</p></summary>
        [Pure]
        public static Nunit3Settings SetWhereExpression(this Nunit3Settings toolSettings, string whereExpression)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhereExpression = whereExpression;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.WhereExpression"/>.</em></p><p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators ==, !=, =~ and !~. See Test Selection Language for a full description of the syntax.</p></summary>
        [Pure]
        public static Nunit3Settings ResetWhereExpression(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhereExpression = null;
            return toolSettings;
        }
        #endregion
        #region Parameters
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Parameters"/> to a new dictionary.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings SetParameters(this Nunit3Settings toolSettings, IDictionary<string, string> parameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal = parameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Nunit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings ClearParameters(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="Nunit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings AddParameter(this Nunit3Settings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Add(parameterKey, parameterValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="Nunit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveParameter(this Nunit3Settings toolSettings, string parameterKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal.Remove(parameterKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="Nunit3Settings.Parameters"/>.</em></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings SetParameter(this Nunit3Settings toolSettings, string parameterKey, string parameterValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParametersInternal[parameterKey] = parameterValue;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Configuration"/>.</em></p><p>Name of a project configuration to load (e.g.: Debug).</p></summary>
        [Pure]
        public static Nunit3Settings SetConfiguration(this Nunit3Settings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Configuration"/>.</em></p><p>Name of a project configuration to load (e.g.: Debug).</p></summary>
        [Pure]
        public static Nunit3Settings ResetConfiguration(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Process
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Process"/>.</em></p><p>Process isolation for test assemblies. Values: Single, Separate, Multiple. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p></summary>
        [Pure]
        public static Nunit3Settings SetProcess(this Nunit3Settings toolSettings, NunitProcessType process)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Process = process;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Process"/>.</em></p><p>Process isolation for test assemblies. Values: Single, Separate, Multiple. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p></summary>
        [Pure]
        public static Nunit3Settings ResetProcess(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Process = null;
            return toolSettings;
        }
        #endregion
        #region InProcess
        /// <summary><p><em>Sets <see cref="Nunit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings SetInProcess(this Nunit3Settings toolSettings, bool? inProcess)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = inProcess;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings ResetInProcess(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings EnableInProcess(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings DisableInProcess(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.InProcess"/>.</em></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings ToggleInProcess(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InProcess = !toolSettings.InProcess;
            return toolSettings;
        }
        #endregion
        #region Agents
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Agents"/>.</em></p><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        [Pure]
        public static Nunit3Settings SetAgents(this Nunit3Settings toolSettings, int? agents)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Agents = agents;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Agents"/>.</em></p><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        [Pure]
        public static Nunit3Settings ResetAgents(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Agents = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Domain"/>.</em></p><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        [Pure]
        public static Nunit3Settings SetDomain(this Nunit3Settings toolSettings, string domain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Domain"/>.</em></p><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        [Pure]
        public static Nunit3Settings ResetDomain(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Framework"/>.</em></p><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        [Pure]
        public static Nunit3Settings SetFramework(this Nunit3Settings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Framework"/>.</em></p><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        [Pure]
        public static Nunit3Settings ResetFramework(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region X86
        /// <summary><p><em>Sets <see cref="Nunit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings SetX86(this Nunit3Settings toolSettings, bool? x86)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = x86;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings ResetX86(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings EnableX86(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings DisableX86(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.X86"/>.</em></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleX86(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.X86 = !toolSettings.X86;
            return toolSettings;
        }
        #endregion
        #region DisposeRunners
        /// <summary><p><em>Sets <see cref="Nunit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings SetDisposeRunners(this Nunit3Settings toolSettings, bool? disposeRunners)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = disposeRunners;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings ResetDisposeRunners(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings EnableDisposeRunners(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings DisableDisposeRunners(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.DisposeRunners"/>.</em></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings ToggleDisposeRunners(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeRunners = !toolSettings.DisposeRunners;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Timeout"/>.</em></p><p>Set timeout for each test case in milliseconds.</p></summary>
        [Pure]
        public static Nunit3Settings SetTimeout(this Nunit3Settings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Timeout"/>.</em></p><p>Set timeout for each test case in milliseconds.</p></summary>
        [Pure]
        public static Nunit3Settings ResetTimeout(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Seed
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Seed"/>.</em></p><p>Set the random seed used to generate test cases.</p></summary>
        [Pure]
        public static Nunit3Settings SetSeed(this Nunit3Settings toolSettings, int? seed)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Seed = seed;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Seed"/>.</em></p><p>Set the random seed used to generate test cases.</p></summary>
        [Pure]
        public static Nunit3Settings ResetSeed(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Seed = null;
            return toolSettings;
        }
        #endregion
        #region Workers
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Workers"/>.</em></p><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        [Pure]
        public static Nunit3Settings SetWorkers(this Nunit3Settings toolSettings, int? workers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Workers = workers;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Workers"/>.</em></p><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        [Pure]
        public static Nunit3Settings ResetWorkers(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Workers = null;
            return toolSettings;
        }
        #endregion
        #region StopOnError
        /// <summary><p><em>Sets <see cref="Nunit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings SetStopOnError(this Nunit3Settings toolSettings, bool? stopOnError)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = stopOnError;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings ResetStopOnError(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings EnableStopOnError(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings DisableStopOnError(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.StopOnError"/>.</em></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleStopOnError(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnError = !toolSettings.StopOnError;
            return toolSettings;
        }
        #endregion
        #region SkipNonTestAssemblies
        /// <summary><p><em>Sets <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings SetSkipNonTestAssemblies(this Nunit3Settings toolSettings, bool? skipNonTestAssemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = skipNonTestAssemblies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings ResetSkipNonTestAssemblies(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings EnableSkipNonTestAssemblies(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings DisableSkipNonTestAssemblies(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</em></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleSkipNonTestAssemblies(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipNonTestAssemblies = !toolSettings.SkipNonTestAssemblies;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings SetDebug(this Nunit3Settings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings ResetDebug(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings EnableDebug(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings DisableDebug(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.Debug"/>.</em></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleDebug(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region DebugAgent
        /// <summary><p><em>Sets <see cref="Nunit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings SetDebugAgent(this Nunit3Settings toolSettings, bool? debugAgent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = debugAgent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings ResetDebugAgent(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings EnableDebugAgent(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings DisableDebugAgent(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.DebugAgent"/>.</em></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleDebugAgent(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DebugAgent = !toolSettings.DebugAgent;
            return toolSettings;
        }
        #endregion
        #region Pause
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings SetPause(this Nunit3Settings toolSettings, bool? pause)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = pause;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings ResetPause(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings EnablePause(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings DisablePause(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.Pause"/>.</em></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings TogglePause(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = !toolSettings.Pause;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings SetWait(this Nunit3Settings toolSettings, bool? wait)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings ResetWait(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings EnableWait(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings DisableWait(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.Wait"/>.</em></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleWait(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region WorkPath
        /// <summary><p><em>Sets <see cref="Nunit3Settings.WorkPath"/>.</em></p><p>Path of the directory to use for output files.</p></summary>
        [Pure]
        public static Nunit3Settings SetWorkPath(this Nunit3Settings toolSettings, string workPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkPath = workPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.WorkPath"/>.</em></p><p>Path of the directory to use for output files.</p></summary>
        [Pure]
        public static Nunit3Settings ResetWorkPath(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkPath = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary><p><em>Sets <see cref="Nunit3Settings.OutputFile"/>.</em></p><p>File path to contain text output from the tests.</p></summary>
        [Pure]
        public static Nunit3Settings SetOutputFile(this Nunit3Settings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.OutputFile"/>.</em></p><p>File path to contain text output from the tests.</p></summary>
        [Pure]
        public static Nunit3Settings ResetOutputFile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ErrorFile
        /// <summary><p><em>Sets <see cref="Nunit3Settings.ErrorFile"/>.</em></p><p>File path to contain error output from the tests.</p></summary>
        [Pure]
        public static Nunit3Settings SetErrorFile(this Nunit3Settings toolSettings, string errorFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorFile = errorFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.ErrorFile"/>.</em></p><p>File path to contain error output from the tests.</p></summary>
        [Pure]
        public static Nunit3Settings ResetErrorFile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorFile = null;
            return toolSettings;
        }
        #endregion
        #region Results
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Results"/> to a new list.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetResults(this Nunit3Settings toolSettings, params string[] results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal = results.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Results"/> to a new list.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetResults(this Nunit3Settings toolSettings, IEnumerable<string> results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal = results.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddResults(this Nunit3Settings toolSettings, params string[] results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.AddRange(results);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddResults(this Nunit3Settings toolSettings, IEnumerable<string> results)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.AddRange(results);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Nunit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings ClearResults(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveResults(this Nunit3Settings toolSettings, params string[] results)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(results);
            toolSettings.ResultsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.Results"/>.</em></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveResults(this Nunit3Settings toolSettings, IEnumerable<string> results)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(results);
            toolSettings.ResultsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Explores
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Explores"/> to a new list.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetExplores(this Nunit3Settings toolSettings, params string[] explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal = explores.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Explores"/> to a new list.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetExplores(this Nunit3Settings toolSettings, IEnumerable<string> explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal = explores.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddExplores(this Nunit3Settings toolSettings, params string[] explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.AddRange(explores);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Nunit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddExplores(this Nunit3Settings toolSettings, IEnumerable<string> explores)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.AddRange(explores);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Nunit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings ClearExplores(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExploresInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveExplores(this Nunit3Settings toolSettings, params string[] explores)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(explores);
            toolSettings.ExploresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Nunit3Settings.Explores"/>.</em></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveExplores(this Nunit3Settings toolSettings, IEnumerable<string> explores)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(explores);
            toolSettings.ExploresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoResults
        /// <summary><p><em>Sets <see cref="Nunit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings SetNoResults(this Nunit3Settings toolSettings, bool? noResults)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = noResults;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings ResetNoResults(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings EnableNoResults(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings DisableNoResults(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.NoResults"/>.</em></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleNoResults(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoResults = !toolSettings.NoResults;
            return toolSettings;
        }
        #endregion
        #region Labels
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Labels"/>.</em></p><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        [Pure]
        public static Nunit3Settings SetLabels(this Nunit3Settings toolSettings, NunitLabelType labels)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Labels = labels;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Labels"/>.</em></p><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        [Pure]
        public static Nunit3Settings ResetLabels(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Labels = null;
            return toolSettings;
        }
        #endregion
        #region Trace
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Trace"/>.</em></p><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        [Pure]
        public static Nunit3Settings SetTrace(this Nunit3Settings toolSettings, NunitTraceLevel trace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = trace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Trace"/>.</em></p><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        [Pure]
        public static Nunit3Settings ResetTrace(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trace = null;
            return toolSettings;
        }
        #endregion
        #region Encoding
        /// <summary><p><em>Sets <see cref="Nunit3Settings.Encoding"/>.</em></p><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        [Pure]
        public static Nunit3Settings SetEncoding(this Nunit3Settings toolSettings, string encoding)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Encoding = encoding;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.Encoding"/>.</em></p><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        [Pure]
        public static Nunit3Settings ResetEncoding(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Encoding = null;
            return toolSettings;
        }
        #endregion
        #region ShadowCopy
        /// <summary><p><em>Sets <see cref="Nunit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings SetShadowCopy(this Nunit3Settings toolSettings, bool? shadowCopy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = shadowCopy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings ResetShadowCopy(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings EnableShadowCopy(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings DisableShadowCopy(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.ShadowCopy"/>.</em></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleShadowCopy(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShadowCopy = !toolSettings.ShadowCopy;
            return toolSettings;
        }
        #endregion
        #region TeamCity
        /// <summary><p><em>Sets <see cref="Nunit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings SetTeamCity(this Nunit3Settings toolSettings, bool? teamCity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = teamCity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings ResetTeamCity(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings EnableTeamCity(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings DisableTeamCity(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.TeamCity"/>.</em></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleTeamCity(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = !toolSettings.TeamCity;
            return toolSettings;
        }
        #endregion
        #region LoadUserProfile
        /// <summary><p><em>Sets <see cref="Nunit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings SetLoadUserProfile(this Nunit3Settings toolSettings, bool? loadUserProfile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = loadUserProfile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings ResetLoadUserProfile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings EnableLoadUserProfile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings DisableLoadUserProfile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.LoadUserProfile"/>.</em></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleLoadUserProfile(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadUserProfile = !toolSettings.LoadUserProfile;
            return toolSettings;
        }
        #endregion
        #region ListExtensions
        /// <summary><p><em>Sets <see cref="Nunit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings SetListExtensions(this Nunit3Settings toolSettings, bool? listExtensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = listExtensions;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings ResetListExtensions(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings EnableListExtensions(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings DisableListExtensions(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.ListExtensions"/>.</em></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleListExtensions(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListExtensions = !toolSettings.ListExtensions;
            return toolSettings;
        }
        #endregion
        #region SetPrincipalPolicy
        /// <summary><p><em>Sets <see cref="Nunit3Settings.SetPrincipalPolicy"/>.</em></p><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        [Pure]
        public static Nunit3Settings SetSetPrincipalPolicy(this Nunit3Settings toolSettings, NunitPrincipalPolicy setPrincipalPolicy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetPrincipalPolicy = setPrincipalPolicy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.SetPrincipalPolicy"/>.</em></p><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        [Pure]
        public static Nunit3Settings ResetSetPrincipalPolicy(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetPrincipalPolicy = null;
            return toolSettings;
        }
        #endregion
        #region NoHeader
        /// <summary><p><em>Sets <see cref="Nunit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings SetNoHeader(this Nunit3Settings toolSettings, bool? noHeader)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = noHeader;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings ResetNoHeader(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings EnableNoHeader(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings DisableNoHeader(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.NoHeader"/>.</em></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleNoHeader(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHeader = !toolSettings.NoHeader;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary><p><em>Sets <see cref="Nunit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings SetNoColor(this Nunit3Settings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Nunit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings ResetNoColor(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Nunit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings EnableNoColor(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Nunit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings DisableNoColor(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Nunit3Settings.NoColor"/>.</em></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleNoColor(this Nunit3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NunitProcessType
    /// <summary><p>Used within <see cref="NunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class NunitProcessType : Enumeration
    {
        public static NunitProcessType Single = new NunitProcessType { Value = "Single" };
        public static NunitProcessType Separate = new NunitProcessType { Value = "Separate" };
        public static NunitProcessType Multiple = new NunitProcessType { Value = "Multiple" };
    }
    #endregion
    #region NunitPrincipalPolicy
    /// <summary><p>Used within <see cref="NunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class NunitPrincipalPolicy : Enumeration
    {
        public static NunitPrincipalPolicy UnauthenticatedPrincipal = new NunitPrincipalPolicy { Value = "UnauthenticatedPrincipal" };
        public static NunitPrincipalPolicy NoPrincipal = new NunitPrincipalPolicy { Value = "NoPrincipal" };
        public static NunitPrincipalPolicy WindowsPrincipal = new NunitPrincipalPolicy { Value = "WindowsPrincipal" };
    }
    #endregion
    #region NunitLabelType
    /// <summary><p>Used within <see cref="NunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class NunitLabelType : Enumeration
    {
        public static NunitLabelType Off = new NunitLabelType { Value = "Off" };
        public static NunitLabelType On = new NunitLabelType { Value = "On" };
        public static NunitLabelType All = new NunitLabelType { Value = "All" };
    }
    #endregion
    #region NunitTraceLevel
    /// <summary><p>Used within <see cref="NunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class NunitTraceLevel : Enumeration
    {
        public static NunitTraceLevel Off = new NunitTraceLevel { Value = "Off" };
        public static NunitTraceLevel Error = new NunitTraceLevel { Value = "Error" };
        public static NunitTraceLevel Warning = new NunitTraceLevel { Value = "Warning" };
        public static NunitTraceLevel Info = new NunitTraceLevel { Value = "Info" };
        public static NunitTraceLevel Verbose = new NunitTraceLevel { Value = "Verbose" };
    }
    #endregion
}
