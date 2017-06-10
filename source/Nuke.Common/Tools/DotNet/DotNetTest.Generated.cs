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

namespace Nuke.Common.Tools.DotNet
{
    public static partial class DotNetTasks
    {
        static partial void PreProcess (DotNetTestSettings dotNetTestSettings);
        static partial void PostProcess (DotNetTestSettings dotNetTestSettings);
        /// <summary>
        /// <p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run">official website</a>.</p>
        /// </summary>
        public static void DotNetTest (Configure<DotNetTestSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetTestSettings = new DotNetTestSettings();
            dotNetTestSettings = configurator(dotNetTestSettings);
            PreProcess(dotNetTestSettings);
            var process = ProcessTasks.StartProcess(dotNetTestSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetTestSettings);
        }
    }
    /// <summary>
    /// <p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetTestSettings : DotNetSettings
    {
        /// <summary><p>Specifies a path to the test project. If omitted, it defaults to current directory.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Settings to use when running tests.</p></summary>
        public virtual string SettingsFile { get; internal set; }
        /// <summary><p>List all of the discovered tests in the current project.</p></summary>
        public virtual bool ListTests { get; internal set; }
        /// <summary><p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p></summary>
        public virtual string Filter { get; internal set; }
        /// <summary><p>Use the custom test adapters from the specified path in the test run.</p></summary>
        public virtual string TestAdapterPath { get; internal set; }
        /// <summary><p>Specifies a logger for test results.</p></summary>
        public virtual string Logger { get; internal set; }
        /// <summary><p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Directory in which to find the binaries to run.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p></summary>
        public virtual string DiagnosticsFile { get; internal set; }
        /// <summary><p>Does not build the test project prior to running it.</p></summary>
        public virtual bool NoBuild { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity? Verbosity { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add($"test")
              .Add("{value}", ProjectFile)
              .Add("--settings {value}", SettingsFile)
              .Add("--list-tests", ListTests)
              .Add("--filter {value}", Filter)
              .Add("--test-adapter-path {value}", TestAdapterPath)
              .Add("--logger {value}", Logger)
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--output {value}", Output)
              .Add("--diag {value}", DiagnosticsFile)
              .Add("--no-build", NoBuild)
              .Add("--verbosity {value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTestSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.ProjectFile"/>.</i></p>
        /// <p>Specifies a path to the test project. If omitted, it defaults to current directory.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetProjectFile(this DotNetTestSettings dotNetTestSettings, string projectFile)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ProjectFile = projectFile;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.SettingsFile"/>.</i></p>
        /// <p>Settings to use when running tests.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetSettingsFile(this DotNetTestSettings dotNetTestSettings, string settingsFile)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.SettingsFile = settingsFile;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.ListTests"/>.</i></p>
        /// <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetListTests(this DotNetTestSettings dotNetTestSettings, bool listTests)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = listTests;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetTestSettings.ListTests"/>.</i></p>
        /// <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings EnableListTests(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = true;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetTestSettings.ListTests"/>.</i></p>
        /// <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings DisableListTests(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = false;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetTestSettings.ListTests"/>.</i></p>
        /// <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings ToggleListTests(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = !dotNetTestSettings.ListTests;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.Filter"/>.</i></p>
        /// <p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetFilter(this DotNetTestSettings dotNetTestSettings, string filter)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Filter = filter;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.TestAdapterPath"/>.</i></p>
        /// <p>Use the custom test adapters from the specified path in the test run.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetTestAdapterPath(this DotNetTestSettings dotNetTestSettings, string testAdapterPath)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.TestAdapterPath = testAdapterPath;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.Logger"/>.</i></p>
        /// <p>Specifies a logger for test results.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetLogger(this DotNetTestSettings dotNetTestSettings, string logger)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Logger = logger;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.Configuration"/>.</i></p>
        /// <p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetConfiguration(this DotNetTestSettings dotNetTestSettings, string configuration)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Configuration = configuration;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.Framework"/>.</i></p>
        /// <p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetFramework(this DotNetTestSettings dotNetTestSettings, string framework)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Framework = framework;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.Output"/>.</i></p>
        /// <p>Directory in which to find the binaries to run.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetOutput(this DotNetTestSettings dotNetTestSettings, string output)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Output = output;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.DiagnosticsFile"/>.</i></p>
        /// <p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetDiagnosticsFile(this DotNetTestSettings dotNetTestSettings, string diagnosticsFile)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.DiagnosticsFile = diagnosticsFile;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.NoBuild"/>.</i></p>
        /// <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetNoBuild(this DotNetTestSettings dotNetTestSettings, bool noBuild)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = noBuild;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetTestSettings.NoBuild"/>.</i></p>
        /// <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings EnableNoBuild(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = true;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetTestSettings.NoBuild"/>.</i></p>
        /// <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings DisableNoBuild(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = false;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetTestSettings.NoBuild"/>.</i></p>
        /// <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings ToggleNoBuild(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = !dotNetTestSettings.NoBuild;
            return dotNetTestSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetTestSettings.Verbosity"/>.</i></p>
        /// <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetTestSettings SetVerbosity(this DotNetTestSettings dotNetTestSettings, DotNetVerbosity? verbosity)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Verbosity = verbosity;
            return dotNetTestSettings;
        }
    }
}
