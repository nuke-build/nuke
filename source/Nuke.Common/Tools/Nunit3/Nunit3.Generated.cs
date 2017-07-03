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

[assembly: IconClass(typeof(Nuke.Common.Tools.Nunit3.Nunit3Tasks), "bug2")]

namespace Nuke.Common.Tools.Nunit3
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class Nunit3Tasks
    {
        static partial void PreProcess (Nunit3Settings nunit3Settings);
        static partial void PostProcess (Nunit3Settings nunit3Settings);
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static void Nunit3 (Configure<Nunit3Settings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var nunit3Settings = new Nunit3Settings();
            nunit3Settings = configurator(nunit3Settings);
            PreProcess(nunit3Settings);
            var process = ProcessTasks.StartProcess(nunit3Settings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nunit3Settings);
        }
        /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p><p>For more details, visit the <a href="https://www.nunit.org/">official website</a>.</p></summary>
        public static void Nunit3 (List<string> inputFiles, Configure<Nunit3Settings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            Nunit3(x => configurator(x).SetInputFiles(inputFiles));
        }
    }
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Nunit3Settings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"NUnit.ConsoleRunner", packageExecutable: $"nunit-console.exe");
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
        public virtual NunitProcessType? Process { get; internal set; }
        /// <summary><p>This option is a synonym for --process=Single</p></summary>
        public virtual bool InProcess { get; internal set; }
        /// <summary><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        public virtual int? Agents { get; internal set; }
        /// <summary><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        public virtual string Domain { get; internal set; }
        /// <summary><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        public virtual bool X86 { get; internal set; }
        /// <summary><p>Dispose each test runner after it has finished running its tests</p></summary>
        public virtual bool DisposeRunners { get; internal set; }
        /// <summary><p>Set timeout for each test case in milliseconds.</p></summary>
        public virtual int Timeout { get; internal set; }
        /// <summary><p>Set the random seed used to generate test cases.</p></summary>
        public virtual int Seed { get; internal set; }
        /// <summary><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        public virtual int Workers { get; internal set; }
        /// <summary><p>Stop run immediately upon any test failure or error.</p></summary>
        public virtual bool StopOnError { get; internal set; }
        /// <summary><p>Skip any non-test assemblies specified, without error.</p></summary>
        public virtual bool SkipNonTestAssemblies { get; internal set; }
        /// <summary><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        public virtual bool Debug { get; internal set; }
        /// <summary><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        public virtual bool DebugAgent { get; internal set; }
        /// <summary><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        public virtual bool Pause { get; internal set; }
        /// <summary><p>Wait for input before closing console window.</p></summary>
        public virtual bool Wait { get; internal set; }
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
        public virtual bool NoResults { get; internal set; }
        /// <summary><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        public virtual NunitLabelType? Labels { get; internal set; }
        /// <summary><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        public virtual NunitTraceLevel? Trace { get; internal set; }
        /// <summary><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        public virtual string Encoding { get; internal set; }
        /// <summary><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        public virtual bool ShadowCopy { get; internal set; }
        /// <summary><p>Turns on use of TeamCity service messages.</p></summary>
        public virtual bool TeamCity { get; internal set; }
        /// <summary><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        public virtual bool LoadUserProfile { get; internal set; }
        /// <summary><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        public virtual bool ListExtensions { get; internal set; }
        /// <summary><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        public virtual NunitPrincipalPolicy? SetPrincipalPolicy { get; internal set; }
        /// <summary><p>Suppress display of program information at start of run.</p></summary>
        public virtual bool NoHeader { get; internal set; }
        /// <summary><p>Displays console output without color.</p></summary>
        public virtual bool NoColor { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", InputFiles)
              .Add("--test={value}", Tests, mainSeparator: $",")
              .Add("--testlist={value}", TestListFile)
              .Add("--where={value}", WhereExpression)
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
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class Nunit3SettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.InputFiles"/> to a new list.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings SetInputFiles(this Nunit3Settings nunit3Settings, params string[] inputFiles)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal = inputFiles.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.InputFiles"/> to a new list.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings SetInputFiles(this Nunit3Settings nunit3Settings, IEnumerable<string> inputFiles)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal = inputFiles.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new inputFiles to the existing <see cref="Nunit3Settings.InputFiles"/>.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings AddInputFiles(this Nunit3Settings nunit3Settings, params string[] inputFiles)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal.AddRange(inputFiles);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new inputFiles to the existing <see cref="Nunit3Settings.InputFiles"/>.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings AddInputFiles(this Nunit3Settings nunit3Settings, IEnumerable<string> inputFiles)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal.AddRange(inputFiles);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="Nunit3Settings.InputFiles"/>.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings ClearInputFiles(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal.Clear();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding a single inputFile to <see cref="Nunit3Settings.InputFiles"/>.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings AddInputFile(this Nunit3Settings nunit3Settings, string inputFile)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal.Add(inputFile);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for removing a single inputFile from <see cref="Nunit3Settings.InputFiles"/>.</i></p><p>The console program must always have an assembly or project specified. Assemblies are specified by file name or path, which may be absolute or relative. Relative paths are interpreted based on the current directory.</p><p>In addition to assemblies, you may specify any project type that is understood by NUnit. Out of the box, this includes various Visual Studio project types as well as NUnit (.nunit) test projects (see <a href="https://github.com/nunit/docs/wiki/NUnit-Test-Projects">NUnit Test Projects</a> for a description of NUnit test projects).</p><p>If the NUnit V2 framework driver is installed, test assemblies may be run based on any version of the NUnit framework beginning with 2.0. Without the V2 driver, only version 3.0 and higher tests may be run.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveInputFile(this Nunit3Settings nunit3Settings, string inputFile)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InputFilesInternal.Remove(inputFile);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Tests"/> to a new list.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings SetTests(this Nunit3Settings nunit3Settings, params string[] tests)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal = tests.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Tests"/> to a new list.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings SetTests(this Nunit3Settings nunit3Settings, IEnumerable<string> tests)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal = tests.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new tests to the existing <see cref="Nunit3Settings.Tests"/>.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings AddTests(this Nunit3Settings nunit3Settings, params string[] tests)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal.AddRange(tests);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new tests to the existing <see cref="Nunit3Settings.Tests"/>.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings AddTests(this Nunit3Settings nunit3Settings, IEnumerable<string> tests)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal.AddRange(tests);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="Nunit3Settings.Tests"/>.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings ClearTests(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal.Clear();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding a single test to <see cref="Nunit3Settings.Tests"/>.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings AddTest(this Nunit3Settings nunit3Settings, string test)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal.Add(test);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for removing a single test from <see cref="Nunit3Settings.Tests"/>.</i></p><p>Comma-separated list of names of tests to run or explore. This option may be repeated. Note that this option is retained for backward compatibility. The --where option can now be used instead.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveTest(this Nunit3Settings nunit3Settings, string test)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestsInternal.Remove(test);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.TestListFile"/>.</i></p><p>The name (or path) of a file containing a list of tests to run or explore, one per line.</p></summary>
        [Pure]
        public static Nunit3Settings SetTestListFile(this Nunit3Settings nunit3Settings, string testListFile)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TestListFile = testListFile;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.WhereExpression"/>.</i></p><p>An expression indicating which tests to run. It may specify test names, classes, methods, catgories or properties comparing them to actual values with the operators ==, !=, =~ and !~. See Test Selection Language for a full description of the syntax.</p></summary>
        [Pure]
        public static Nunit3Settings SetWhereExpression(this Nunit3Settings nunit3Settings, string whereExpression)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.WhereExpression = whereExpression;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Parameters"/> to a new dictionary.</i></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings SetParameters(this Nunit3Settings nunit3Settings, IDictionary<string, string> parameters)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ParametersInternal = parameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="Nunit3Settings.Parameters"/>.</i></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings ClearParameters(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ParametersInternal.Clear();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding a parameter to <see cref="Nunit3Settings.Parameters"/>.</i></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings AddParameter(this Nunit3Settings nunit3Settings, string parameterKey, string parameterValue)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ParametersInternal.Add(parameterKey, parameterValue);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for removing a parameter from <see cref="Nunit3Settings.Parameters"/>.</i></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveParameter(this Nunit3Settings nunit3Settings, string parameterKey)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ParametersInternal.Remove(parameterKey);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting a parameter in <see cref="Nunit3Settings.Parameters"/>.</i></p><p>A test parameter specified in the form NAME=VALUE. Multiple parameters may be specified, separated by semicolons or by repeating the --params option multiple times.</p></summary>
        [Pure]
        public static Nunit3Settings SetParameter(this Nunit3Settings nunit3Settings, string parameterKey, string parameterValue)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ParametersInternal[parameterKey] = parameterValue;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Configuration"/>.</i></p><p>Name of a project configuration to load (e.g.: Debug).</p></summary>
        [Pure]
        public static Nunit3Settings SetConfiguration(this Nunit3Settings nunit3Settings, string configuration)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Configuration = configuration;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Process"/>.</i></p><p>Process isolation for test assemblies. Values: Single, Separate, Multiple. If not specified, defaults to Separate for a single assembly or Multiple for more than one. By default, processes are run in parallel.</p></summary>
        [Pure]
        public static Nunit3Settings SetProcess(this Nunit3Settings nunit3Settings, NunitProcessType? process)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Process = process;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.InProcess"/>.</i></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings SetInProcess(this Nunit3Settings nunit3Settings, bool inProcess)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InProcess = inProcess;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.InProcess"/>.</i></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings EnableInProcess(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InProcess = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.InProcess"/>.</i></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings DisableInProcess(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InProcess = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.InProcess"/>.</i></p><p>This option is a synonym for --process=Single</p></summary>
        [Pure]
        public static Nunit3Settings ToggleInProcess(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.InProcess = !nunit3Settings.InProcess;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Agents"/>.</i></p><p>Number of agents that may be allowed to run simultaneously assuming you are not running inprocess. If not specified, all agent processes run tests at the same time, whatever the number of assemblies. This setting is used to control running your assemblies in parallel.</p></summary>
        [Pure]
        public static Nunit3Settings SetAgents(this Nunit3Settings nunit3Settings, int? agents)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Agents = agents;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Domain"/>.</i></p><p>Domain isolation for test assemblies. Values: None, Single, Multiple. If not specified, defaults to Single for a single assembly or Multiple for more than one.</p></summary>
        [Pure]
        public static Nunit3Settings SetDomain(this Nunit3Settings nunit3Settings, string domain)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Domain = domain;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Framework"/>.</i></p><p>Framework type/version to use for tests. Examples: mono, net-4.5, v4.0, 2.0, mono-4.0</p></summary>
        [Pure]
        public static Nunit3Settings SetFramework(this Nunit3Settings nunit3Settings, string framework)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Framework = framework;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.X86"/>.</i></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings SetX86(this Nunit3Settings nunit3Settings, bool x86)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.X86 = x86;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.X86"/>.</i></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings EnableX86(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.X86 = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.X86"/>.</i></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings DisableX86(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.X86 = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.X86"/>.</i></p><p>Run tests in a 32-bit process on 64-bit systems.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleX86(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.X86 = !nunit3Settings.X86;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.DisposeRunners"/>.</i></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings SetDisposeRunners(this Nunit3Settings nunit3Settings, bool disposeRunners)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DisposeRunners = disposeRunners;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.DisposeRunners"/>.</i></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings EnableDisposeRunners(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DisposeRunners = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.DisposeRunners"/>.</i></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings DisableDisposeRunners(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DisposeRunners = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.DisposeRunners"/>.</i></p><p>Dispose each test runner after it has finished running its tests</p></summary>
        [Pure]
        public static Nunit3Settings ToggleDisposeRunners(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DisposeRunners = !nunit3Settings.DisposeRunners;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Timeout"/>.</i></p><p>Set timeout for each test case in milliseconds.</p></summary>
        [Pure]
        public static Nunit3Settings SetTimeout(this Nunit3Settings nunit3Settings, int timeout)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Timeout = timeout;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Seed"/>.</i></p><p>Set the random seed used to generate test cases.</p></summary>
        [Pure]
        public static Nunit3Settings SetSeed(this Nunit3Settings nunit3Settings, int seed)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Seed = seed;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Workers"/>.</i></p><p>Specify the number of worker threads to be used in running tests. This setting is used to control running your tests in parallel and is used in conjunction with the Parallelizable Attribute. If not specified, workers defaults to the number of processors on the machine, or 2, whichever is greater.</p></summary>
        [Pure]
        public static Nunit3Settings SetWorkers(this Nunit3Settings nunit3Settings, int workers)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Workers = workers;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.StopOnError"/>.</i></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings SetStopOnError(this Nunit3Settings nunit3Settings, bool stopOnError)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.StopOnError = stopOnError;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.StopOnError"/>.</i></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings EnableStopOnError(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.StopOnError = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.StopOnError"/>.</i></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings DisableStopOnError(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.StopOnError = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.StopOnError"/>.</i></p><p>Stop run immediately upon any test failure or error.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleStopOnError(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.StopOnError = !nunit3Settings.StopOnError;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</i></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings SetSkipNonTestAssemblies(this Nunit3Settings nunit3Settings, bool skipNonTestAssemblies)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.SkipNonTestAssemblies = skipNonTestAssemblies;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</i></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings EnableSkipNonTestAssemblies(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.SkipNonTestAssemblies = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</i></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings DisableSkipNonTestAssemblies(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.SkipNonTestAssemblies = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.SkipNonTestAssemblies"/>.</i></p><p>Skip any non-test assemblies specified, without error.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleSkipNonTestAssemblies(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.SkipNonTestAssemblies = !nunit3Settings.SkipNonTestAssemblies;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Debug"/>.</i></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings SetDebug(this Nunit3Settings nunit3Settings, bool debug)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Debug = debug;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.Debug"/>.</i></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings EnableDebug(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Debug = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.Debug"/>.</i></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings DisableDebug(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Debug = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.Debug"/>.</i></p><p>Causes NUnit to break into the debugger immediately before it executes your tests. This is particularly useful when the tests are running in a separate process to which you would otherwise have to attach.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleDebug(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Debug = !nunit3Settings.Debug;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.DebugAgent"/>.</i></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings SetDebugAgent(this Nunit3Settings nunit3Settings, bool debugAgent)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DebugAgent = debugAgent;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.DebugAgent"/>.</i></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings EnableDebugAgent(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DebugAgent = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.DebugAgent"/>.</i></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings DisableDebugAgent(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DebugAgent = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.DebugAgent"/>.</i></p><p>Available only in debug builds of NUnit, this option is for use by developers in debugging the nunit-agent itself. It breaks in the agent code immediately upon entry of the process.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleDebugAgent(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.DebugAgent = !nunit3Settings.DebugAgent;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Pause"/>.</i></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings SetPause(this Nunit3Settings nunit3Settings, bool pause)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Pause = pause;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.Pause"/>.</i></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings EnablePause(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Pause = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.Pause"/>.</i></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings DisablePause(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Pause = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.Pause"/>.</i></p><p>Causes NUnit to immediately open a message box, allowing you to attach a debugger. For cases where --debug does not work.</p></summary>
        [Pure]
        public static Nunit3Settings TogglePause(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Pause = !nunit3Settings.Pause;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Wait"/>.</i></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings SetWait(this Nunit3Settings nunit3Settings, bool wait)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Wait = wait;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.Wait"/>.</i></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings EnableWait(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Wait = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.Wait"/>.</i></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings DisableWait(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Wait = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.Wait"/>.</i></p><p>Wait for input before closing console window.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleWait(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Wait = !nunit3Settings.Wait;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.WorkPath"/>.</i></p><p>Path of the directory to use for output files.</p></summary>
        [Pure]
        public static Nunit3Settings SetWorkPath(this Nunit3Settings nunit3Settings, string workPath)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.WorkPath = workPath;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.OutputFile"/>.</i></p><p>File path to contain text output from the tests.</p></summary>
        [Pure]
        public static Nunit3Settings SetOutputFile(this Nunit3Settings nunit3Settings, string outputFile)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.OutputFile = outputFile;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.ErrorFile"/>.</i></p><p>File path to contain error output from the tests.</p></summary>
        [Pure]
        public static Nunit3Settings SetErrorFile(this Nunit3Settings nunit3Settings, string errorFile)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ErrorFile = errorFile;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Results"/> to a new list.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetResults(this Nunit3Settings nunit3Settings, params string[] results)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal = results.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Results"/> to a new list.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetResults(this Nunit3Settings nunit3Settings, IEnumerable<string> results)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal = results.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new results to the existing <see cref="Nunit3Settings.Results"/>.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddResults(this Nunit3Settings nunit3Settings, params string[] results)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal.AddRange(results);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new results to the existing <see cref="Nunit3Settings.Results"/>.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddResults(this Nunit3Settings nunit3Settings, IEnumerable<string> results)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal.AddRange(results);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="Nunit3Settings.Results"/>.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings ClearResults(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal.Clear();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding a single result to <see cref="Nunit3Settings.Results"/>.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddResult(this Nunit3Settings nunit3Settings, string result)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal.Add(result);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for removing a single result from <see cref="Nunit3Settings.Results"/>.</i></p><p>An output spec for saving the test results. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveResult(this Nunit3Settings nunit3Settings, string result)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ResultsInternal.Remove(result);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Explores"/> to a new list.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetExplores(this Nunit3Settings nunit3Settings, params string[] explores)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal = explores.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Explores"/> to a new list.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings SetExplores(this Nunit3Settings nunit3Settings, IEnumerable<string> explores)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal = explores.ToList();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new explores to the existing <see cref="Nunit3Settings.Explores"/>.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddExplores(this Nunit3Settings nunit3Settings, params string[] explores)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal.AddRange(explores);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding new explores to the existing <see cref="Nunit3Settings.Explores"/>.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddExplores(this Nunit3Settings nunit3Settings, IEnumerable<string> explores)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal.AddRange(explores);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="Nunit3Settings.Explores"/>.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings ClearExplores(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal.Clear();
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for adding a single explore to <see cref="Nunit3Settings.Explores"/>.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings AddExplore(this Nunit3Settings nunit3Settings, string explore)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal.Add(explore);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for removing a single explore from <see cref="Nunit3Settings.Explores"/>.</i></p><p>Display or save test info rather than running tests. Optionally provide an output spec for saving the test info. This option may be repeated.</p></summary>
        [Pure]
        public static Nunit3Settings RemoveExplore(this Nunit3Settings nunit3Settings, string explore)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ExploresInternal.Remove(explore);
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.NoResults"/>.</i></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings SetNoResults(this Nunit3Settings nunit3Settings, bool noResults)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoResults = noResults;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.NoResults"/>.</i></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings EnableNoResults(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoResults = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.NoResults"/>.</i></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings DisableNoResults(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoResults = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.NoResults"/>.</i></p><p>Don't save any test results.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleNoResults(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoResults = !nunit3Settings.NoResults;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Labels"/>.</i></p><p>Specify whether to write test case names to the output. Values: Off, On, All</p></summary>
        [Pure]
        public static Nunit3Settings SetLabels(this Nunit3Settings nunit3Settings, NunitLabelType? labels)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Labels = labels;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Trace"/>.</i></p><p>Set internal trace LEVEL. Values: Off, Error, Warning, Info, Verbose (Debug)</p></summary>
        [Pure]
        public static Nunit3Settings SetTrace(this Nunit3Settings nunit3Settings, NunitTraceLevel? trace)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Trace = trace;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.Encoding"/>.</i></p><p>Specify the console codepage, such as utf-8, ascii, etc. This option is not normally needed unless your output includes special characters. The page specified must be available on the system.</p></summary>
        [Pure]
        public static Nunit3Settings SetEncoding(this Nunit3Settings nunit3Settings, string encoding)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.Encoding = encoding;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.ShadowCopy"/>.</i></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings SetShadowCopy(this Nunit3Settings nunit3Settings, bool shadowCopy)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ShadowCopy = shadowCopy;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.ShadowCopy"/>.</i></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings EnableShadowCopy(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ShadowCopy = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.ShadowCopy"/>.</i></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings DisableShadowCopy(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ShadowCopy = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.ShadowCopy"/>.</i></p><p>Tells .NET to copy loaded assemblies to the shadowcopy directory.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleShadowCopy(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ShadowCopy = !nunit3Settings.ShadowCopy;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.TeamCity"/>.</i></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings SetTeamCity(this Nunit3Settings nunit3Settings, bool teamCity)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TeamCity = teamCity;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.TeamCity"/>.</i></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings EnableTeamCity(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TeamCity = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.TeamCity"/>.</i></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings DisableTeamCity(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TeamCity = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.TeamCity"/>.</i></p><p>Turns on use of TeamCity service messages.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleTeamCity(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.TeamCity = !nunit3Settings.TeamCity;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.LoadUserProfile"/>.</i></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings SetLoadUserProfile(this Nunit3Settings nunit3Settings, bool loadUserProfile)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.LoadUserProfile = loadUserProfile;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.LoadUserProfile"/>.</i></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings EnableLoadUserProfile(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.LoadUserProfile = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.LoadUserProfile"/>.</i></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings DisableLoadUserProfile(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.LoadUserProfile = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.LoadUserProfile"/>.</i></p><p>Causes the user profile to be loaded in any separate test processes.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleLoadUserProfile(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.LoadUserProfile = !nunit3Settings.LoadUserProfile;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.ListExtensions"/>.</i></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings SetListExtensions(this Nunit3Settings nunit3Settings, bool listExtensions)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ListExtensions = listExtensions;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.ListExtensions"/>.</i></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings EnableListExtensions(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ListExtensions = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.ListExtensions"/>.</i></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings DisableListExtensions(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ListExtensions = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.ListExtensions"/>.</i></p><p>Lists all extension points and the extensions installed on each of them.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleListExtensions(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.ListExtensions = !nunit3Settings.ListExtensions;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.SetPrincipalPolicy"/>.</i></p><p>Set the principal policy for the test domain to POLICY. Values: UnauthenticatedPrincipal, NoPrincipal, WindowsPrincipal</p></summary>
        [Pure]
        public static Nunit3Settings SetSetPrincipalPolicy(this Nunit3Settings nunit3Settings, NunitPrincipalPolicy? setPrincipalPolicy)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.SetPrincipalPolicy = setPrincipalPolicy;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.NoHeader"/>.</i></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings SetNoHeader(this Nunit3Settings nunit3Settings, bool noHeader)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoHeader = noHeader;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.NoHeader"/>.</i></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings EnableNoHeader(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoHeader = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.NoHeader"/>.</i></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings DisableNoHeader(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoHeader = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.NoHeader"/>.</i></p><p>Suppress display of program information at start of run.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleNoHeader(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoHeader = !nunit3Settings.NoHeader;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for setting <see cref="Nunit3Settings.NoColor"/>.</i></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings SetNoColor(this Nunit3Settings nunit3Settings, bool noColor)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoColor = noColor;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="Nunit3Settings.NoColor"/>.</i></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings EnableNoColor(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoColor = true;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="Nunit3Settings.NoColor"/>.</i></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings DisableNoColor(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoColor = false;
            return nunit3Settings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="Nunit3Settings.NoColor"/>.</i></p><p>Displays console output without color.</p></summary>
        [Pure]
        public static Nunit3Settings ToggleNoColor(this Nunit3Settings nunit3Settings)
        {
            nunit3Settings = nunit3Settings.NewInstance();
            nunit3Settings.NoColor = !nunit3Settings.NoColor;
            return nunit3Settings;
        }
    }
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
    [PublicAPI]
    public enum NunitProcessType
    {
        Single,
        Separate,
        Multiple
    }
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
    [PublicAPI]
    public enum NunitPrincipalPolicy
    {
        UnauthenticatedPrincipal,
        NoPrincipal,
        WindowsPrincipal
    }
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
    [PublicAPI]
    public enum NunitLabelType
    {
        Off,
        On,
        All
    }
    /// <summary><p>NUnit is a unit-testing framework for all .Net languages. Initially ported from <a href="http://www.junit.org/">JUnit</a>, the current production release, version 3.0, has been completely rewritten with many new features and support for a wide range of .NET platforms.</p></summary>
    [PublicAPI]
    public enum NunitTraceLevel
    {
        Off,
        Error,
        Warning,
        Info,
        Verbose
    }
}
