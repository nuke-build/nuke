// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/StrykerNet.json

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

namespace Nuke.Common.Tools.StrykerNet
{
    /// <summary>
    ///   <p></p>
    ///   <p>For more details, visit the <a href="https://stryker-mutator.io/stryker-net/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class StrykerNetTasks
    {
        /// <summary>
        ///   Path to the StrykerNet executable.
        /// </summary>
        public static string StrykerNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("STRYKERNET_EXE") ??
            ToolPathResolver.GetPackageExecutable("dotnet-stryker", "Stryker.CLI.dll");
        public static Action<OutputType, string> StrykerNetLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p></p>
        ///   <p>For more details, visit the <a href="https://stryker-mutator.io/stryker-net/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> StrykerNet(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(StrykerNetPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, StrykerNetLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p></p>
        ///   <p>For more details, visit the <a href="https://stryker-mutator.io/stryker-net/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--abort-test-on-fail</c> via <see cref="StrykerNetSettings.AbortTestOnFail"/></li>
        ///     <li><c>--config-file-path</c> via <see cref="StrykerNetSettings.ConfigFilePath"/></li>
        ///     <li><c>--coverage-analysis</c> via <see cref="StrykerNetSettings.CoverageAnalysis"/></li>
        ///     <li><c>--dashboard-api-key</c> via <see cref="StrykerNetSettings.DashboardApiKey"/></li>
        ///     <li><c>--dashboard-module</c> via <see cref="StrykerNetSettings.DashboardModule"/></li>
        ///     <li><c>--dashboard-project</c> via <see cref="StrykerNetSettings.DashboardProject"/></li>
        ///     <li><c>--dashboard-project</c> via <see cref="StrykerNetSettings.DashboardVersion"/></li>
        ///     <li><c>--diff</c> via <see cref="StrykerNetSettings.Diff"/></li>
        ///     <li><c>--excluded-mutations</c> via <see cref="StrykerNetSettings.ExcludedMutations"/></li>
        ///     <li><c>--git-source</c> via <see cref="StrykerNetSettings.GitSource"/></li>
        ///     <li><c>--ignore-methods</c> via <see cref="StrykerNetSettings.IgnoreMethods"/></li>
        ///     <li><c>--log-file</c> via <see cref="StrykerNetSettings.LogFile"/></li>
        ///     <li><c>--log-level</c> via <see cref="StrykerNetSettings.LogLevel"/></li>
        ///     <li><c>--max-concurrent-test-runners</c> via <see cref="StrykerNetSettings.MaxConcurrentTestRunners"/></li>
        ///     <li><c>--mutate</c> via <see cref="StrykerNetSettings.Mutate"/></li>
        ///     <li><c>--project-file</c> via <see cref="StrykerNetSettings.ProjectFile"/></li>
        ///     <li><c>--reporters</c> via <see cref="StrykerNetSettings.Reporters"/></li>
        ///     <li><c>--solution-path</c> via <see cref="StrykerNetSettings.SolutionPath"/></li>
        ///     <li><c>--test-projects</c> via <see cref="StrykerNetSettings.TestProjects"/></li>
        ///     <li><c>--test-runner</c> via <see cref="StrykerNetSettings.TestRunner"/></li>
        ///     <li><c>--threshold-break</c> via <see cref="StrykerNetSettings.ThresholdBreak"/></li>
        ///     <li><c>--threshold-high</c> via <see cref="StrykerNetSettings.ThresholdHigh"/></li>
        ///     <li><c>--threshold-low</c> via <see cref="StrykerNetSettings.ThresholdLow"/></li>
        ///     <li><c>--timeout-ms</c> via <see cref="StrykerNetSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> StrykerNet(StrykerNetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new StrykerNetSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p></p>
        ///   <p>For more details, visit the <a href="https://stryker-mutator.io/stryker-net/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--abort-test-on-fail</c> via <see cref="StrykerNetSettings.AbortTestOnFail"/></li>
        ///     <li><c>--config-file-path</c> via <see cref="StrykerNetSettings.ConfigFilePath"/></li>
        ///     <li><c>--coverage-analysis</c> via <see cref="StrykerNetSettings.CoverageAnalysis"/></li>
        ///     <li><c>--dashboard-api-key</c> via <see cref="StrykerNetSettings.DashboardApiKey"/></li>
        ///     <li><c>--dashboard-module</c> via <see cref="StrykerNetSettings.DashboardModule"/></li>
        ///     <li><c>--dashboard-project</c> via <see cref="StrykerNetSettings.DashboardProject"/></li>
        ///     <li><c>--dashboard-project</c> via <see cref="StrykerNetSettings.DashboardVersion"/></li>
        ///     <li><c>--diff</c> via <see cref="StrykerNetSettings.Diff"/></li>
        ///     <li><c>--excluded-mutations</c> via <see cref="StrykerNetSettings.ExcludedMutations"/></li>
        ///     <li><c>--git-source</c> via <see cref="StrykerNetSettings.GitSource"/></li>
        ///     <li><c>--ignore-methods</c> via <see cref="StrykerNetSettings.IgnoreMethods"/></li>
        ///     <li><c>--log-file</c> via <see cref="StrykerNetSettings.LogFile"/></li>
        ///     <li><c>--log-level</c> via <see cref="StrykerNetSettings.LogLevel"/></li>
        ///     <li><c>--max-concurrent-test-runners</c> via <see cref="StrykerNetSettings.MaxConcurrentTestRunners"/></li>
        ///     <li><c>--mutate</c> via <see cref="StrykerNetSettings.Mutate"/></li>
        ///     <li><c>--project-file</c> via <see cref="StrykerNetSettings.ProjectFile"/></li>
        ///     <li><c>--reporters</c> via <see cref="StrykerNetSettings.Reporters"/></li>
        ///     <li><c>--solution-path</c> via <see cref="StrykerNetSettings.SolutionPath"/></li>
        ///     <li><c>--test-projects</c> via <see cref="StrykerNetSettings.TestProjects"/></li>
        ///     <li><c>--test-runner</c> via <see cref="StrykerNetSettings.TestRunner"/></li>
        ///     <li><c>--threshold-break</c> via <see cref="StrykerNetSettings.ThresholdBreak"/></li>
        ///     <li><c>--threshold-high</c> via <see cref="StrykerNetSettings.ThresholdHigh"/></li>
        ///     <li><c>--threshold-low</c> via <see cref="StrykerNetSettings.ThresholdLow"/></li>
        ///     <li><c>--timeout-ms</c> via <see cref="StrykerNetSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> StrykerNet(Configure<StrykerNetSettings> configurator)
        {
            return StrykerNet(configurator(new StrykerNetSettings()));
        }
        /// <summary>
        ///   <p></p>
        ///   <p>For more details, visit the <a href="https://stryker-mutator.io/stryker-net/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--abort-test-on-fail</c> via <see cref="StrykerNetSettings.AbortTestOnFail"/></li>
        ///     <li><c>--config-file-path</c> via <see cref="StrykerNetSettings.ConfigFilePath"/></li>
        ///     <li><c>--coverage-analysis</c> via <see cref="StrykerNetSettings.CoverageAnalysis"/></li>
        ///     <li><c>--dashboard-api-key</c> via <see cref="StrykerNetSettings.DashboardApiKey"/></li>
        ///     <li><c>--dashboard-module</c> via <see cref="StrykerNetSettings.DashboardModule"/></li>
        ///     <li><c>--dashboard-project</c> via <see cref="StrykerNetSettings.DashboardProject"/></li>
        ///     <li><c>--dashboard-project</c> via <see cref="StrykerNetSettings.DashboardVersion"/></li>
        ///     <li><c>--diff</c> via <see cref="StrykerNetSettings.Diff"/></li>
        ///     <li><c>--excluded-mutations</c> via <see cref="StrykerNetSettings.ExcludedMutations"/></li>
        ///     <li><c>--git-source</c> via <see cref="StrykerNetSettings.GitSource"/></li>
        ///     <li><c>--ignore-methods</c> via <see cref="StrykerNetSettings.IgnoreMethods"/></li>
        ///     <li><c>--log-file</c> via <see cref="StrykerNetSettings.LogFile"/></li>
        ///     <li><c>--log-level</c> via <see cref="StrykerNetSettings.LogLevel"/></li>
        ///     <li><c>--max-concurrent-test-runners</c> via <see cref="StrykerNetSettings.MaxConcurrentTestRunners"/></li>
        ///     <li><c>--mutate</c> via <see cref="StrykerNetSettings.Mutate"/></li>
        ///     <li><c>--project-file</c> via <see cref="StrykerNetSettings.ProjectFile"/></li>
        ///     <li><c>--reporters</c> via <see cref="StrykerNetSettings.Reporters"/></li>
        ///     <li><c>--solution-path</c> via <see cref="StrykerNetSettings.SolutionPath"/></li>
        ///     <li><c>--test-projects</c> via <see cref="StrykerNetSettings.TestProjects"/></li>
        ///     <li><c>--test-runner</c> via <see cref="StrykerNetSettings.TestRunner"/></li>
        ///     <li><c>--threshold-break</c> via <see cref="StrykerNetSettings.ThresholdBreak"/></li>
        ///     <li><c>--threshold-high</c> via <see cref="StrykerNetSettings.ThresholdHigh"/></li>
        ///     <li><c>--threshold-low</c> via <see cref="StrykerNetSettings.ThresholdLow"/></li>
        ///     <li><c>--timeout-ms</c> via <see cref="StrykerNetSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(StrykerNetSettings Settings, IReadOnlyCollection<Output> Output)> StrykerNet(CombinatorialConfigure<StrykerNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(StrykerNet, StrykerNetLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region StrykerNetSettings
    /// <summary>
    ///   Used within <see cref="StrykerNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class StrykerNetSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the StrykerNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? StrykerNetTasks.StrykerNetPath;
        public override Action<OutputType, string> CustomLogger => StrykerNetTasks.StrykerNetLogger;
        /// <summary>
        ///   On .NET Framework projects Stryker needs your .sln file path.
        /// </summary>
        public virtual string SolutionPath { get; internal set; }
        /// <summary>
        ///   When Stryker finds two or more project references inside your test project, it needs to know which project should be mutated. Pass the name of this project.
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///   Stryker supports dotnet test, the commandline testrunner and VsTest, the visual studio testrunner. VsTest is the default because it offers tight integration with all test frameworks (MsTest, xUnit, NUnit etc). Dotnet test can be used if VsTest causes issues for some reason. Please also submit an issue with us if you experience difficulties with VsTest.
        /// </summary>
        public virtual StrykerNetTestRunner TestRunner { get; internal set; }
        /// <summary>
        ///   Some mutations can create endless loops inside your code. To detect and stop these loops, Stryker cancels a unit test run after a set time. Using this parameter you can increase or decrease the time before a test will time out.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null
        /// </summary>
        public virtual IReadOnlyList<string> TestProjects => TestProjectsInternal.AsReadOnly();
        internal List<string> TestProjectsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   To gain more insight in what Stryker does during a mutation testrun you can lower your loglevel.
        /// </summary>
        public virtual StrykerNetLogLevel LogLevel { get; internal set; }
        /// <summary>
        ///   When creating an issue for Stryker.NET on github you can include a logfile. File logging always uses loglevel trace
        /// </summary>
        public virtual bool? LogFile { get; internal set; }
        /// <summary>
        ///   By default Stryker.NET will use as much CPU power as you allow it to use during a mutation testrun. You can lower this setting to lower your CPU usage. This setting can also be used to disable parallel testing. This can be useful if your test project cannot handle parallel testruns. Default: your number of logical processors / 2
        /// </summary>
        public virtual int? MaxConcurrentTestRunners { get; internal set; }
        /// <summary>
        ///   Default: 80. If you want to decide on your own mutation score thresholds.
        /// </summary>
        public virtual int? ThresholdHigh { get; internal set; }
        /// <summary>
        ///   Default: 60. If you want to decide on your own mutation score thresholds.
        /// </summary>
        public virtual int? ThresholdLow { get; internal set; }
        /// <summary>
        ///   Default: 0. If you want to decide on your own mutation score thresholds.
        /// </summary>
        public virtual int? ThresholdBreak { get; internal set; }
        /// <summary>
        ///   If you deem some mutations unwanted for your project you can disable mutations.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludedMutations => ExcludedMutationsInternal.AsReadOnly();
        internal List<string> ExcludedMutationsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.
        /// </summary>
        public virtual IReadOnlyList<string> Mutate => MutateInternal.AsReadOnly();
        internal List<string> MutateInternal { get; set; } = new List<string>();
        /// <summary>
        ///   If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.
        /// </summary>
        public virtual IReadOnlyList<string> IgnoreMethods => IgnoreMethodsInternal.AsReadOnly();
        internal List<string> IgnoreMethodsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Path to configuration file. If you want to integrate these settings in your existing settings json, make sure the section is called stryker-config.
        /// </summary>
        public virtual string ConfigFilePath { get; internal set; }
        /// <summary>
        ///   Use coverage info to speed up execution.
        /// </summary>
        public virtual StrykerNetCoverage CoverageAnalysis { get; internal set; }
        /// <summary>
        ///   Abort unit testrun as soon as any one unit test fails. This can reduce the overall running time.
        /// </summary>
        public virtual bool? AbortTestOnFail { get; internal set; }
        /// <summary>
        ///   Enables the diff feature. It makes sure to only mutate changed files. Gets the diff from git by default.
        /// </summary>
        public virtual bool? Diff { get; internal set; }
        /// <summary>
        ///   Sets the source branch to compare with the current code on file system, used for calculating the difference when --diff is enabled.
        /// </summary>
        public virtual string GitSource { get; internal set; }
        /// <summary>
        ///   During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.
        /// </summary>
        public virtual IReadOnlyList<StrykerNetReporter> Reporters => ReportersInternal.AsReadOnly();
        internal List<StrykerNetReporter> ReportersInternal { get; set; } = new List<StrykerNetReporter>();
        /// <summary>
        ///   Get your api key at stryker dashboard. To keep your api key safe, store it in an encrypted variable in your pipeline.
        /// </summary>
        public virtual string DashboardApiKey { get; internal set; }
        /// <summary>
        ///   The name registered with the dashboard. It is in the form of gitProvider/organization/repository. At the moment the dashboard backend only supports github.com as a git provider, but we will also support gitlab.com/bitbucket.org, etc in the future. It can have an indefinite number of levels. Slashes (/) in this name are not escaped. For example github.com/stryker-mutator/stryker-net.
        /// </summary>
        public virtual string DashboardProject { get; internal set; }
        /// <summary>
        ///   The version of the report. This should be filled with the branch name, git tag or git sha (although no validation is done). You can override a report of a specific version, like docker tags. Slashes in the version should not be encoded. For example, it's valid to use "feat/logging".
        /// </summary>
        public virtual string DashboardVersion { get; internal set; }
        /// <summary>
        ///   Optional. If you want to store multiple reports for a version, you can use this value to separate them logically. For example, in a mono-repo setup where each package (or project or module) delivers a report.
        /// </summary>
        public virtual string DashboardModule { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("--solution-path {value}", SolutionPath)
              .Add("--project-file {value}", ProjectFile)
              .Add("--test-runner {value}", TestRunner)
              .Add("--timeout-ms {value}", Timeout)
              .Add("--test-projects {value}", GetTestProjects(), customValue: true)
              .Add("--log-level {value}", LogLevel)
              .Add("--log-file", LogFile)
              .Add("--max-concurrent-test-runners {value}", MaxConcurrentTestRunners)
              .Add("--threshold-high {value}", ThresholdHigh)
              .Add("--threshold-low {value}", ThresholdLow)
              .Add("--threshold-break {value}", ThresholdBreak)
              .Add("--excluded-mutations {value}", GetExcludedMutations(), customValue: true)
              .Add("--mutate {value}", GetMutate(), customValue: true)
              .Add("--ignore-methods {value}", GetIgnoreMethods(), customValue: true)
              .Add("--config-file-path {value}", ConfigFilePath)
              .Add("--coverage-analysis {value}", CoverageAnalysis)
              .Add("--abort-test-on-fail", AbortTestOnFail)
              .Add("--diff", Diff)
              .Add("--git-source {value}", GitSource)
              .Add("--reporters {value}", GetReporters(), customValue: true)
              .Add("--dashboard-api-key {value}", DashboardApiKey, secret: true)
              .Add("--dashboard-project {value}", DashboardProject)
              .Add("--dashboard-project {value}", DashboardVersion)
              .Add("--dashboard-module {value}", DashboardModule);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region StrykerNetSettingsExtensions
    /// <summary>
    ///   Used within <see cref="StrykerNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class StrykerNetSettingsExtensions
    {
        #region SolutionPath
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.SolutionPath"/></em></p>
        ///   <p>On .NET Framework projects Stryker needs your .sln file path.</p>
        /// </summary>
        [Pure]
        public static T SetSolutionPath<T>(this T toolSettings, string solutionPath) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionPath = solutionPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.SolutionPath"/></em></p>
        ///   <p>On .NET Framework projects Stryker needs your .sln file path.</p>
        /// </summary>
        [Pure]
        public static T ResetSolutionPath<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionPath = null;
            return toolSettings;
        }
        #endregion
        #region ProjectFile
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ProjectFile"/></em></p>
        ///   <p>When Stryker finds two or more project references inside your test project, it needs to know which project should be mutated. Pass the name of this project.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.ProjectFile"/></em></p>
        ///   <p>When Stryker finds two or more project references inside your test project, it needs to know which project should be mutated. Pass the name of this project.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region TestRunner
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.TestRunner"/></em></p>
        ///   <p>Stryker supports dotnet test, the commandline testrunner and VsTest, the visual studio testrunner. VsTest is the default because it offers tight integration with all test frameworks (MsTest, xUnit, NUnit etc). Dotnet test can be used if VsTest causes issues for some reason. Please also submit an issue with us if you experience difficulties with VsTest.</p>
        /// </summary>
        [Pure]
        public static T SetTestRunner<T>(this T toolSettings, StrykerNetTestRunner testRunner) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestRunner = testRunner;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.TestRunner"/></em></p>
        ///   <p>Stryker supports dotnet test, the commandline testrunner and VsTest, the visual studio testrunner. VsTest is the default because it offers tight integration with all test frameworks (MsTest, xUnit, NUnit etc). Dotnet test can be used if VsTest causes issues for some reason. Please also submit an issue with us if you experience difficulties with VsTest.</p>
        /// </summary>
        [Pure]
        public static T ResetTestRunner<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestRunner = null;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.Timeout"/></em></p>
        ///   <p>Some mutations can create endless loops inside your code. To detect and stop these loops, Stryker cancels a unit test run after a set time. Using this parameter you can increase or decrease the time before a test will time out.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.Timeout"/></em></p>
        ///   <p>Some mutations can create endless loops inside your code. To detect and stop these loops, Stryker cancels a unit test run after a set time. Using this parameter you can increase or decrease the time before a test will time out.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region TestProjects
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.TestProjects"/> to a new list</em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T SetTestProjects<T>(this T toolSettings, params string[] testProjects) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestProjectsInternal = testProjects.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.TestProjects"/> to a new list</em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T SetTestProjects<T>(this T toolSettings, IEnumerable<string> testProjects) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestProjectsInternal = testProjects.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.TestProjects"/></em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T AddTestProjects<T>(this T toolSettings, params string[] testProjects) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestProjectsInternal.AddRange(testProjects);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.TestProjects"/></em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T AddTestProjects<T>(this T toolSettings, IEnumerable<string> testProjects) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestProjectsInternal.AddRange(testProjects);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="StrykerNetSettings.TestProjects"/></em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T ClearTestProjects<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestProjectsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.TestProjects"/></em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T RemoveTestProjects<T>(this T toolSettings, params string[] testProjects) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(testProjects);
            toolSettings.TestProjectsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.TestProjects"/></em></p>
        ///   <p>Stryker can also be run from the directory containing the project under test. If you pass a list of test projects that reference the project under test, the tests of all projects will be run while testing the mutants. When running from a test project directory this option is not required. Default: null</p>
        /// </summary>
        [Pure]
        public static T RemoveTestProjects<T>(this T toolSettings, IEnumerable<string> testProjects) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(testProjects);
            toolSettings.TestProjectsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.LogLevel"/></em></p>
        ///   <p>To gain more insight in what Stryker does during a mutation testrun you can lower your loglevel.</p>
        /// </summary>
        [Pure]
        public static T SetLogLevel<T>(this T toolSettings, StrykerNetLogLevel logLevel) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.LogLevel"/></em></p>
        ///   <p>To gain more insight in what Stryker does during a mutation testrun you can lower your loglevel.</p>
        /// </summary>
        [Pure]
        public static T ResetLogLevel<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.LogFile"/></em></p>
        ///   <p>When creating an issue for Stryker.NET on github you can include a logfile. File logging always uses loglevel trace</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, bool? logFile) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.LogFile"/></em></p>
        ///   <p>When creating an issue for Stryker.NET on github you can include a logfile. File logging always uses loglevel trace</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="StrykerNetSettings.LogFile"/></em></p>
        ///   <p>When creating an issue for Stryker.NET on github you can include a logfile. File logging always uses loglevel trace</p>
        /// </summary>
        [Pure]
        public static T EnableLogFile<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="StrykerNetSettings.LogFile"/></em></p>
        ///   <p>When creating an issue for Stryker.NET on github you can include a logfile. File logging always uses loglevel trace</p>
        /// </summary>
        [Pure]
        public static T DisableLogFile<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="StrykerNetSettings.LogFile"/></em></p>
        ///   <p>When creating an issue for Stryker.NET on github you can include a logfile. File logging always uses loglevel trace</p>
        /// </summary>
        [Pure]
        public static T ToggleLogFile<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = !toolSettings.LogFile;
            return toolSettings;
        }
        #endregion
        #region MaxConcurrentTestRunners
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.MaxConcurrentTestRunners"/></em></p>
        ///   <p>By default Stryker.NET will use as much CPU power as you allow it to use during a mutation testrun. You can lower this setting to lower your CPU usage. This setting can also be used to disable parallel testing. This can be useful if your test project cannot handle parallel testruns. Default: your number of logical processors / 2</p>
        /// </summary>
        [Pure]
        public static T SetMaxConcurrentTestRunners<T>(this T toolSettings, int? maxConcurrentTestRunners) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxConcurrentTestRunners = maxConcurrentTestRunners;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.MaxConcurrentTestRunners"/></em></p>
        ///   <p>By default Stryker.NET will use as much CPU power as you allow it to use during a mutation testrun. You can lower this setting to lower your CPU usage. This setting can also be used to disable parallel testing. This can be useful if your test project cannot handle parallel testruns. Default: your number of logical processors / 2</p>
        /// </summary>
        [Pure]
        public static T ResetMaxConcurrentTestRunners<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxConcurrentTestRunners = null;
            return toolSettings;
        }
        #endregion
        #region ThresholdHigh
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ThresholdHigh"/></em></p>
        ///   <p>Default: 80. If you want to decide on your own mutation score thresholds.</p>
        /// </summary>
        [Pure]
        public static T SetThresholdHigh<T>(this T toolSettings, int? thresholdHigh) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdHigh = thresholdHigh;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.ThresholdHigh"/></em></p>
        ///   <p>Default: 80. If you want to decide on your own mutation score thresholds.</p>
        /// </summary>
        [Pure]
        public static T ResetThresholdHigh<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdHigh = null;
            return toolSettings;
        }
        #endregion
        #region ThresholdLow
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ThresholdLow"/></em></p>
        ///   <p>Default: 60. If you want to decide on your own mutation score thresholds.</p>
        /// </summary>
        [Pure]
        public static T SetThresholdLow<T>(this T toolSettings, int? thresholdLow) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdLow = thresholdLow;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.ThresholdLow"/></em></p>
        ///   <p>Default: 60. If you want to decide on your own mutation score thresholds.</p>
        /// </summary>
        [Pure]
        public static T ResetThresholdLow<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdLow = null;
            return toolSettings;
        }
        #endregion
        #region ThresholdBreak
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ThresholdBreak"/></em></p>
        ///   <p>Default: 0. If you want to decide on your own mutation score thresholds.</p>
        /// </summary>
        [Pure]
        public static T SetThresholdBreak<T>(this T toolSettings, int? thresholdBreak) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdBreak = thresholdBreak;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.ThresholdBreak"/></em></p>
        ///   <p>Default: 0. If you want to decide on your own mutation score thresholds.</p>
        /// </summary>
        [Pure]
        public static T ResetThresholdBreak<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdBreak = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedMutations
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ExcludedMutations"/> to a new list</em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T SetExcludedMutations<T>(this T toolSettings, params string[] excludedMutations) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedMutationsInternal = excludedMutations.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ExcludedMutations"/> to a new list</em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T SetExcludedMutations<T>(this T toolSettings, IEnumerable<string> excludedMutations) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedMutationsInternal = excludedMutations.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.ExcludedMutations"/></em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T AddExcludedMutations<T>(this T toolSettings, params string[] excludedMutations) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedMutationsInternal.AddRange(excludedMutations);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.ExcludedMutations"/></em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T AddExcludedMutations<T>(this T toolSettings, IEnumerable<string> excludedMutations) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedMutationsInternal.AddRange(excludedMutations);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="StrykerNetSettings.ExcludedMutations"/></em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludedMutations<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedMutationsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.ExcludedMutations"/></em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludedMutations<T>(this T toolSettings, params string[] excludedMutations) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedMutations);
            toolSettings.ExcludedMutationsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.ExcludedMutations"/></em></p>
        ///   <p>If you deem some mutations unwanted for your project you can disable mutations.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludedMutations<T>(this T toolSettings, IEnumerable<string> excludedMutations) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedMutations);
            toolSettings.ExcludedMutationsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Mutate
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.Mutate"/> to a new list</em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T SetMutate<T>(this T toolSettings, params string[] mutate) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MutateInternal = mutate.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.Mutate"/> to a new list</em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T SetMutate<T>(this T toolSettings, IEnumerable<string> mutate) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MutateInternal = mutate.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.Mutate"/></em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T AddMutate<T>(this T toolSettings, params string[] mutate) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MutateInternal.AddRange(mutate);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.Mutate"/></em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T AddMutate<T>(this T toolSettings, IEnumerable<string> mutate) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MutateInternal.AddRange(mutate);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="StrykerNetSettings.Mutate"/></em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T ClearMutate<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MutateInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.Mutate"/></em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T RemoveMutate<T>(this T toolSettings, params string[] mutate) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(mutate);
            toolSettings.MutateInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.Mutate"/></em></p>
        ///   <p>To specify which files should be mutated you can use file pattern to in- or excluded files or even only parts of a files. By default all files are included.</p>
        /// </summary>
        [Pure]
        public static T RemoveMutate<T>(this T toolSettings, IEnumerable<string> mutate) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(mutate);
            toolSettings.MutateInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region IgnoreMethods
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.IgnoreMethods"/> to a new list</em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreMethods<T>(this T toolSettings, params string[] ignoreMethods) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreMethodsInternal = ignoreMethods.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.IgnoreMethods"/> to a new list</em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreMethods<T>(this T toolSettings, IEnumerable<string> ignoreMethods) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreMethodsInternal = ignoreMethods.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.IgnoreMethods"/></em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T AddIgnoreMethods<T>(this T toolSettings, params string[] ignoreMethods) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreMethodsInternal.AddRange(ignoreMethods);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.IgnoreMethods"/></em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T AddIgnoreMethods<T>(this T toolSettings, IEnumerable<string> ignoreMethods) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreMethodsInternal.AddRange(ignoreMethods);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="StrykerNetSettings.IgnoreMethods"/></em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearIgnoreMethods<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.IgnoreMethods"/></em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveIgnoreMethods<T>(this T toolSettings, params string[] ignoreMethods) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(ignoreMethods);
            toolSettings.IgnoreMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.IgnoreMethods"/></em></p>
        ///   <p>If you would like to ignore some mutations that are passed as method parameters, you can do so by specifying which methods to ignore. Ignore methods will only affect mutations in directly passed parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveIgnoreMethods<T>(this T toolSettings, IEnumerable<string> ignoreMethods) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(ignoreMethods);
            toolSettings.IgnoreMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ConfigFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.ConfigFilePath"/></em></p>
        ///   <p>Path to configuration file. If you want to integrate these settings in your existing settings json, make sure the section is called stryker-config.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFilePath<T>(this T toolSettings, string configFilePath) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFilePath = configFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.ConfigFilePath"/></em></p>
        ///   <p>Path to configuration file. If you want to integrate these settings in your existing settings json, make sure the section is called stryker-config.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFilePath<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFilePath = null;
            return toolSettings;
        }
        #endregion
        #region CoverageAnalysis
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.CoverageAnalysis"/></em></p>
        ///   <p>Use coverage info to speed up execution.</p>
        /// </summary>
        [Pure]
        public static T SetCoverageAnalysis<T>(this T toolSettings, StrykerNetCoverage coverageAnalysis) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageAnalysis = coverageAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.CoverageAnalysis"/></em></p>
        ///   <p>Use coverage info to speed up execution.</p>
        /// </summary>
        [Pure]
        public static T ResetCoverageAnalysis<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageAnalysis = null;
            return toolSettings;
        }
        #endregion
        #region AbortTestOnFail
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.AbortTestOnFail"/></em></p>
        ///   <p>Abort unit testrun as soon as any one unit test fails. This can reduce the overall running time.</p>
        /// </summary>
        [Pure]
        public static T SetAbortTestOnFail<T>(this T toolSettings, bool? abortTestOnFail) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbortTestOnFail = abortTestOnFail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.AbortTestOnFail"/></em></p>
        ///   <p>Abort unit testrun as soon as any one unit test fails. This can reduce the overall running time.</p>
        /// </summary>
        [Pure]
        public static T ResetAbortTestOnFail<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbortTestOnFail = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="StrykerNetSettings.AbortTestOnFail"/></em></p>
        ///   <p>Abort unit testrun as soon as any one unit test fails. This can reduce the overall running time.</p>
        /// </summary>
        [Pure]
        public static T EnableAbortTestOnFail<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbortTestOnFail = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="StrykerNetSettings.AbortTestOnFail"/></em></p>
        ///   <p>Abort unit testrun as soon as any one unit test fails. This can reduce the overall running time.</p>
        /// </summary>
        [Pure]
        public static T DisableAbortTestOnFail<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbortTestOnFail = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="StrykerNetSettings.AbortTestOnFail"/></em></p>
        ///   <p>Abort unit testrun as soon as any one unit test fails. This can reduce the overall running time.</p>
        /// </summary>
        [Pure]
        public static T ToggleAbortTestOnFail<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbortTestOnFail = !toolSettings.AbortTestOnFail;
            return toolSettings;
        }
        #endregion
        #region Diff
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.Diff"/></em></p>
        ///   <p>Enables the diff feature. It makes sure to only mutate changed files. Gets the diff from git by default.</p>
        /// </summary>
        [Pure]
        public static T SetDiff<T>(this T toolSettings, bool? diff) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diff = diff;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.Diff"/></em></p>
        ///   <p>Enables the diff feature. It makes sure to only mutate changed files. Gets the diff from git by default.</p>
        /// </summary>
        [Pure]
        public static T ResetDiff<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diff = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="StrykerNetSettings.Diff"/></em></p>
        ///   <p>Enables the diff feature. It makes sure to only mutate changed files. Gets the diff from git by default.</p>
        /// </summary>
        [Pure]
        public static T EnableDiff<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diff = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="StrykerNetSettings.Diff"/></em></p>
        ///   <p>Enables the diff feature. It makes sure to only mutate changed files. Gets the diff from git by default.</p>
        /// </summary>
        [Pure]
        public static T DisableDiff<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diff = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="StrykerNetSettings.Diff"/></em></p>
        ///   <p>Enables the diff feature. It makes sure to only mutate changed files. Gets the diff from git by default.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiff<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diff = !toolSettings.Diff;
            return toolSettings;
        }
        #endregion
        #region GitSource
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.GitSource"/></em></p>
        ///   <p>Sets the source branch to compare with the current code on file system, used for calculating the difference when --diff is enabled.</p>
        /// </summary>
        [Pure]
        public static T SetGitSource<T>(this T toolSettings, string gitSource) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GitSource = gitSource;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.GitSource"/></em></p>
        ///   <p>Sets the source branch to compare with the current code on file system, used for calculating the difference when --diff is enabled.</p>
        /// </summary>
        [Pure]
        public static T ResetGitSource<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GitSource = null;
            return toolSettings;
        }
        #endregion
        #region Reporters
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.Reporters"/> to a new list</em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T SetReporters<T>(this T toolSettings, params StrykerNetReporter[] reporters) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportersInternal = reporters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.Reporters"/> to a new list</em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T SetReporters<T>(this T toolSettings, IEnumerable<StrykerNetReporter> reporters) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportersInternal = reporters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.Reporters"/></em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T AddReporters<T>(this T toolSettings, params StrykerNetReporter[] reporters) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportersInternal.AddRange(reporters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="StrykerNetSettings.Reporters"/></em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T AddReporters<T>(this T toolSettings, IEnumerable<StrykerNetReporter> reporters) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportersInternal.AddRange(reporters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="StrykerNetSettings.Reporters"/></em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T ClearReporters<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.Reporters"/></em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T RemoveReporters<T>(this T toolSettings, params StrykerNetReporter[] reporters) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<StrykerNetReporter>(reporters);
            toolSettings.ReportersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="StrykerNetSettings.Reporters"/></em></p>
        ///   <p>During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.</p>
        /// </summary>
        [Pure]
        public static T RemoveReporters<T>(this T toolSettings, IEnumerable<StrykerNetReporter> reporters) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<StrykerNetReporter>(reporters);
            toolSettings.ReportersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DashboardApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.DashboardApiKey"/></em></p>
        ///   <p>Get your api key at stryker dashboard. To keep your api key safe, store it in an encrypted variable in your pipeline.</p>
        /// </summary>
        [Pure]
        public static T SetDashboardApiKey<T>(this T toolSettings, string dashboardApiKey) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardApiKey = dashboardApiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.DashboardApiKey"/></em></p>
        ///   <p>Get your api key at stryker dashboard. To keep your api key safe, store it in an encrypted variable in your pipeline.</p>
        /// </summary>
        [Pure]
        public static T ResetDashboardApiKey<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardApiKey = null;
            return toolSettings;
        }
        #endregion
        #region DashboardProject
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.DashboardProject"/></em></p>
        ///   <p>The name registered with the dashboard. It is in the form of gitProvider/organization/repository. At the moment the dashboard backend only supports github.com as a git provider, but we will also support gitlab.com/bitbucket.org, etc in the future. It can have an indefinite number of levels. Slashes (/) in this name are not escaped. For example github.com/stryker-mutator/stryker-net.</p>
        /// </summary>
        [Pure]
        public static T SetDashboardProject<T>(this T toolSettings, string dashboardProject) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardProject = dashboardProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.DashboardProject"/></em></p>
        ///   <p>The name registered with the dashboard. It is in the form of gitProvider/organization/repository. At the moment the dashboard backend only supports github.com as a git provider, but we will also support gitlab.com/bitbucket.org, etc in the future. It can have an indefinite number of levels. Slashes (/) in this name are not escaped. For example github.com/stryker-mutator/stryker-net.</p>
        /// </summary>
        [Pure]
        public static T ResetDashboardProject<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardProject = null;
            return toolSettings;
        }
        #endregion
        #region DashboardVersion
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.DashboardVersion"/></em></p>
        ///   <p>The version of the report. This should be filled with the branch name, git tag or git sha (although no validation is done). You can override a report of a specific version, like docker tags. Slashes in the version should not be encoded. For example, it's valid to use "feat/logging".</p>
        /// </summary>
        [Pure]
        public static T SetDashboardVersion<T>(this T toolSettings, string dashboardVersion) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardVersion = dashboardVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.DashboardVersion"/></em></p>
        ///   <p>The version of the report. This should be filled with the branch name, git tag or git sha (although no validation is done). You can override a report of a specific version, like docker tags. Slashes in the version should not be encoded. For example, it's valid to use "feat/logging".</p>
        /// </summary>
        [Pure]
        public static T ResetDashboardVersion<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardVersion = null;
            return toolSettings;
        }
        #endregion
        #region DashboardModule
        /// <summary>
        ///   <p><em>Sets <see cref="StrykerNetSettings.DashboardModule"/></em></p>
        ///   <p>Optional. If you want to store multiple reports for a version, you can use this value to separate them logically. For example, in a mono-repo setup where each package (or project or module) delivers a report.</p>
        /// </summary>
        [Pure]
        public static T SetDashboardModule<T>(this T toolSettings, string dashboardModule) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardModule = dashboardModule;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StrykerNetSettings.DashboardModule"/></em></p>
        ///   <p>Optional. If you want to store multiple reports for a version, you can use this value to separate them logically. For example, in a mono-repo setup where each package (or project or module) delivers a report.</p>
        /// </summary>
        [Pure]
        public static T ResetDashboardModule<T>(this T toolSettings) where T : StrykerNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DashboardModule = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region StrykerNetTestRunner
    /// <summary>
    ///   Used within <see cref="StrykerNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<StrykerNetTestRunner>))]
    public partial class StrykerNetTestRunner : Enumeration
    {
        public static StrykerNetTestRunner vstest = (StrykerNetTestRunner) "vstest";
        public static StrykerNetTestRunner dotnettest = (StrykerNetTestRunner) "dotnettest";
        public static explicit operator StrykerNetTestRunner(string value)
        {
            return new StrykerNetTestRunner { Value = value };
        }
    }
    #endregion
    #region StrykerNetReporter
    /// <summary>
    ///   Used within <see cref="StrykerNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<StrykerNetReporter>))]
    public partial class StrykerNetReporter : Enumeration
    {
        public static StrykerNetReporter html = (StrykerNetReporter) "html";
        public static StrykerNetReporter progress = (StrykerNetReporter) "progress";
        public static StrykerNetReporter dashboard = (StrykerNetReporter) "dashboard";
        public static StrykerNetReporter cleartext = (StrykerNetReporter) "cleartext";
        public static StrykerNetReporter dots = (StrykerNetReporter) "dots";
        public static StrykerNetReporter json = (StrykerNetReporter) "json";
        public static explicit operator StrykerNetReporter(string value)
        {
            return new StrykerNetReporter { Value = value };
        }
    }
    #endregion
    #region StrykerNetCoverage
    /// <summary>
    ///   Used within <see cref="StrykerNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<StrykerNetCoverage>))]
    public partial class StrykerNetCoverage : Enumeration
    {
        public static StrykerNetCoverage off = (StrykerNetCoverage) "off";
        public static StrykerNetCoverage perTest = (StrykerNetCoverage) "perTest";
        public static StrykerNetCoverage all = (StrykerNetCoverage) "all";
        public static StrykerNetCoverage perTestInIsolation = (StrykerNetCoverage) "perTestInIsolation";
        public static explicit operator StrykerNetCoverage(string value)
        {
            return new StrykerNetCoverage { Value = value };
        }
    }
    #endregion
    #region StrykerNetLogLevel
    /// <summary>
    ///   Used within <see cref="StrykerNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<StrykerNetLogLevel>))]
    public partial class StrykerNetLogLevel : Enumeration
    {
        public static StrykerNetLogLevel error = (StrykerNetLogLevel) "error";
        public static StrykerNetLogLevel warning = (StrykerNetLogLevel) "warning";
        public static StrykerNetLogLevel info = (StrykerNetLogLevel) "info";
        public static StrykerNetLogLevel debug = (StrykerNetLogLevel) "debug";
        public static StrykerNetLogLevel trace = (StrykerNetLogLevel) "trace";
        public static explicit operator StrykerNetLogLevel(string value)
        {
            return new StrykerNetLogLevel { Value = value };
        }
    }
    #endregion
}
