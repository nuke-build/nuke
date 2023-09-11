// Generated from https://github.com/candoumbe/nuke/blob/master/source/Nuke.Common/Tools/Stryker/Stryker.json

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

namespace Nuke.Common.Tools.Stryker;

/// <summary>
///   <p>Stryker.NET offers you mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs. Stryker.NET is installed using NuGet.  New to Stryker.NET? Begin with our guide on <a href='https://stryker-mutator.io/docs/stryker-net/Getting-started'>getting started</a></p>
///   <p>For more details, visit the <a href="https://stryker-mutator.io/docs/stryker-net">official website</a>.</p>
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(StrykerPackageId)]
public partial class StrykerTasks
    : IRequireNuGetPackage
{
    public const string StrykerPackageId = "dotnet-stryker";
    /// <summary>
    ///   Path to the Stryker executable.
    /// </summary>
    public static string StrykerPath =>
        ToolPathResolver.TryGetEnvironmentExecutable("STRYKER_EXE") ??
        NuGetToolPathResolver.GetPackageExecutable("dotnet-stryker", "Stryker.CLI.dll");
    public static Action<OutputType, string> StrykerLogger { get; set; } = CustomLogger;
    public static Action<ToolSettings, IProcess> StrykerExitHandler { get; set; } = ProcessTasks.DefaultExitHandler;
    /// <summary>
    ///   <p>Stryker.NET offers you mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs. Stryker.NET is installed using NuGet.  New to Stryker.NET? Begin with our guide on <a href='https://stryker-mutator.io/docs/stryker-net/Getting-started'>getting started</a></p>
    ///   <p>For more details, visit the <a href="https://stryker-mutator.io/docs/stryker-net">official website</a>.</p>
    /// </summary>
    public static IReadOnlyCollection<Output> Stryker(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Action<IProcess> exitHandler = null)
    {
        using var process = ProcessTasks.StartProcess(StrykerPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger ?? StrykerLogger);
        (exitHandler ?? (p => StrykerExitHandler.Invoke(null, p))).Invoke(process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Stryker.NET offers you mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs. Stryker.NET is installed using NuGet.  New to Stryker.NET? Begin with our guide on <a href='https://stryker-mutator.io/docs/stryker-net/Getting-started'>getting started</a></p>
    ///   <p>For more details, visit the <a href="https://stryker-mutator.io/docs/stryker-net">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--break-at</c> via <see cref="StrykerSettings.BreakAt"/></li>
    ///     <li><c>--break-on-initial-test-failure</c> via <see cref="StrykerSettings.BreakOnInitialTestFailure"/></li>
    ///     <li><c>--concurrency</c> via <see cref="StrykerSettings.Concurrency"/></li>
    ///     <li><c>--config-file</c> via <see cref="StrykerSettings.ConfigFile"/></li>
    ///     <li><c>--dashboard-api-key</c> via <see cref="StrykerSettings.DashboardApiKey"/></li>
    ///     <li><c>--dev-mode</c> via <see cref="StrykerSettings.DevMode"/></li>
    ///     <li><c>--disable-bail</c> via <see cref="StrykerSettings.DisableBail"/></li>
    ///     <li><c>--log-to-file</c> via <see cref="StrykerSettings.LogToFile"/></li>
    ///     <li><c>--msbuild-path</c> via <see cref="StrykerSettings.MsBuildPath"/></li>
    ///     <li><c>--mutate</c> via <see cref="StrykerSettings.Mutate"/></li>
    ///     <li><c>--open-report</c> via <see cref="StrykerSettings.OpenReport"/></li>
    ///     <li><c>--output</c> via <see cref="StrykerSettings.Output"/></li>
    ///     <li><c>--project</c> via <see cref="StrykerSettings.Project"/></li>
    ///     <li><c>--reporter</c> via <see cref="StrykerSettings.Reporters"/></li>
    ///     <li><c>--since</c> via <see cref="StrykerSettings.Since"/></li>
    ///     <li><c>--solution</c> via <see cref="StrykerSettings.Solution"/></li>
    ///     <li><c>--target-framework</c> via <see cref="StrykerSettings.TargetFramework"/></li>
    ///     <li><c>--test-project</c> via <see cref="StrykerSettings.TestProjects"/></li>
    ///     <li><c>--threshold-high</c> via <see cref="StrykerSettings.ThresholdHigh"/></li>
    ///     <li><c>--threshold-low</c> via <see cref="StrykerSettings.ThresholdLow"/></li>
    ///     <li><c>--verbosity</c> via <see cref="StrykerSettings.Verbosity"/></li>
    ///     <li><c>--version</c> via <see cref="StrykerSettings.ProjectInfoVersion"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> Stryker(StrykerSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new StrykerSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Stryker.NET offers you mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs. Stryker.NET is installed using NuGet.  New to Stryker.NET? Begin with our guide on <a href='https://stryker-mutator.io/docs/stryker-net/Getting-started'>getting started</a></p>
    ///   <p>For more details, visit the <a href="https://stryker-mutator.io/docs/stryker-net">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--break-at</c> via <see cref="StrykerSettings.BreakAt"/></li>
    ///     <li><c>--break-on-initial-test-failure</c> via <see cref="StrykerSettings.BreakOnInitialTestFailure"/></li>
    ///     <li><c>--concurrency</c> via <see cref="StrykerSettings.Concurrency"/></li>
    ///     <li><c>--config-file</c> via <see cref="StrykerSettings.ConfigFile"/></li>
    ///     <li><c>--dashboard-api-key</c> via <see cref="StrykerSettings.DashboardApiKey"/></li>
    ///     <li><c>--dev-mode</c> via <see cref="StrykerSettings.DevMode"/></li>
    ///     <li><c>--disable-bail</c> via <see cref="StrykerSettings.DisableBail"/></li>
    ///     <li><c>--log-to-file</c> via <see cref="StrykerSettings.LogToFile"/></li>
    ///     <li><c>--msbuild-path</c> via <see cref="StrykerSettings.MsBuildPath"/></li>
    ///     <li><c>--mutate</c> via <see cref="StrykerSettings.Mutate"/></li>
    ///     <li><c>--open-report</c> via <see cref="StrykerSettings.OpenReport"/></li>
    ///     <li><c>--output</c> via <see cref="StrykerSettings.Output"/></li>
    ///     <li><c>--project</c> via <see cref="StrykerSettings.Project"/></li>
    ///     <li><c>--reporter</c> via <see cref="StrykerSettings.Reporters"/></li>
    ///     <li><c>--since</c> via <see cref="StrykerSettings.Since"/></li>
    ///     <li><c>--solution</c> via <see cref="StrykerSettings.Solution"/></li>
    ///     <li><c>--target-framework</c> via <see cref="StrykerSettings.TargetFramework"/></li>
    ///     <li><c>--test-project</c> via <see cref="StrykerSettings.TestProjects"/></li>
    ///     <li><c>--threshold-high</c> via <see cref="StrykerSettings.ThresholdHigh"/></li>
    ///     <li><c>--threshold-low</c> via <see cref="StrykerSettings.ThresholdLow"/></li>
    ///     <li><c>--verbosity</c> via <see cref="StrykerSettings.Verbosity"/></li>
    ///     <li><c>--version</c> via <see cref="StrykerSettings.ProjectInfoVersion"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> Stryker(Configure<StrykerSettings> configurator)
    {
        return Stryker(configurator(new StrykerSettings()));
    }
    /// <summary>
    ///   <p>Stryker.NET offers you mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs. Stryker.NET is installed using NuGet.  New to Stryker.NET? Begin with our guide on <a href='https://stryker-mutator.io/docs/stryker-net/Getting-started'>getting started</a></p>
    ///   <p>For more details, visit the <a href="https://stryker-mutator.io/docs/stryker-net">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--break-at</c> via <see cref="StrykerSettings.BreakAt"/></li>
    ///     <li><c>--break-on-initial-test-failure</c> via <see cref="StrykerSettings.BreakOnInitialTestFailure"/></li>
    ///     <li><c>--concurrency</c> via <see cref="StrykerSettings.Concurrency"/></li>
    ///     <li><c>--config-file</c> via <see cref="StrykerSettings.ConfigFile"/></li>
    ///     <li><c>--dashboard-api-key</c> via <see cref="StrykerSettings.DashboardApiKey"/></li>
    ///     <li><c>--dev-mode</c> via <see cref="StrykerSettings.DevMode"/></li>
    ///     <li><c>--disable-bail</c> via <see cref="StrykerSettings.DisableBail"/></li>
    ///     <li><c>--log-to-file</c> via <see cref="StrykerSettings.LogToFile"/></li>
    ///     <li><c>--msbuild-path</c> via <see cref="StrykerSettings.MsBuildPath"/></li>
    ///     <li><c>--mutate</c> via <see cref="StrykerSettings.Mutate"/></li>
    ///     <li><c>--open-report</c> via <see cref="StrykerSettings.OpenReport"/></li>
    ///     <li><c>--output</c> via <see cref="StrykerSettings.Output"/></li>
    ///     <li><c>--project</c> via <see cref="StrykerSettings.Project"/></li>
    ///     <li><c>--reporter</c> via <see cref="StrykerSettings.Reporters"/></li>
    ///     <li><c>--since</c> via <see cref="StrykerSettings.Since"/></li>
    ///     <li><c>--solution</c> via <see cref="StrykerSettings.Solution"/></li>
    ///     <li><c>--target-framework</c> via <see cref="StrykerSettings.TargetFramework"/></li>
    ///     <li><c>--test-project</c> via <see cref="StrykerSettings.TestProjects"/></li>
    ///     <li><c>--threshold-high</c> via <see cref="StrykerSettings.ThresholdHigh"/></li>
    ///     <li><c>--threshold-low</c> via <see cref="StrykerSettings.ThresholdLow"/></li>
    ///     <li><c>--verbosity</c> via <see cref="StrykerSettings.Verbosity"/></li>
    ///     <li><c>--version</c> via <see cref="StrykerSettings.ProjectInfoVersion"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(StrykerSettings Settings, IReadOnlyCollection<Output> Output)> Stryker(CombinatorialConfigure<StrykerSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(Stryker, StrykerLogger, degreeOfParallelism, completeOnFailure);
    }
}
#region StrykerSettings
/// <summary>
///   Used within <see cref="StrykerTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class StrykerSettings : ToolSettings
{
    /// <summary>
    ///   Path to the Stryker executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? StrykerTasks.StrykerPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? StrykerTasks.StrykerLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? StrykerTasks.StrykerExitHandler;
    /// <summary>
    ///   Path / Name of the configuration file. You can specify a custom path to the config file. For example if you want to add the stryker config section to your appsettings file. The section should still be called <c>stryker-config</c>.
    /// </summary>
    public virtual string ConfigFile { get; internal set; } = "stryker-config.json";
    /// <summary>
    ///   The solution path can be supplied to help with dependency resolution. If stryker is ran from the solution file location the solution file will be analyzed and all projects in the solution will be tested by stryker.
    /// </summary>
    public virtual string Solution { get; internal set; }
    /// <summary>
    ///   The project file name is required when your test project has more than one project reference. Stryker can currently mutate one project under test for 1..N test projects but not 1..N projects under test for one test project.<br /><i>Do not pass a path to this option. Pass the project file <strong>name</strong> as it appears in your test project's references</i>
    /// </summary>
    public virtual string Project { get; internal set; }
    /// <summary>
    ///   When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.
    /// </summary>
    public virtual IReadOnlyList<string> TestProjects => TestProjectsInternal.AsReadOnly();
    internal List<string> TestProjectsInternal { get; set; } = new List<string>();
    /// <summary>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    public virtual IReadOnlyList<string> Mutate => MutateInternal.AsReadOnly();
    internal List<string> MutateInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Randomly selected. If the project targets multiple frameworks, this way you can specify the particular framework to build against. If you specify a non-existent target, Stryker will build the project against a random one (or the only one if so).
    /// </summary>
    public virtual string TargetFramework { get; internal set; }
    /// <summary>
    ///   The version of the report. This should be filled with the branch name, git tag or git sha (although no validation is done). You can override a report of a specific version, like docker tags. Slashes in the version should not be encoded. For example, it's valid to use "feat/logging".
    /// </summary>
    public virtual string ProjectInfoVersion { get; internal set; }
    /// <summary>
    ///   Stryker supports multiple <a href="https://stryker-mutator.io/docs/stryker-net/configuration/#mutation-level-level">mutation level</a>s. Each level comes with a specific set of mutations. Each level contains the mutations of the levels below it. By setting the level to Complete you will get all possible mutations and thus the strictest mutation test. This comes at the price of longer runtime as more mutations will be generated and tested.
    /// </summary>
    public virtual StrykerMutationLevel MutationLevel { get; internal set; } = Standard;
    public virtual IReadOnlyList<StrykerReporter> Reporters => ReportersInternal.AsReadOnly();
    internal List<StrykerReporter> ReportersInternal { get; set; } = new List<StrykerReporter>();
    /// <summary>
    ///   When this option is passed, generated reports should open in the browser automatically once Stryker starts testing mutants, and will update the report till Stryker is done. Both html and dashboard reports can be opened automatically.
    /// </summary>
    public virtual StrykerOpenReport OpenReport { get; internal set; } = StrykerOpenReport.Html;
    /// <summary>
    ///   Change the amount of concurrent workers Stryker uses for the mutation testrun. Defaults to using half your logical (virtual) processor count.<p><strong>Example<strong>: an intel i7 quad-core with hyperthreading has 8 logical cores and 4 physical cores. Stryker will use 4 concurrent workers when using the default.</p>
    /// </summary>
    public virtual uint? Concurrency { get; internal set; }
    /// <summary>
    ///   Must be less than or equal to threshold low. When threshold break is set to anything other than 0 and the mutation score is lower than the threshold Stryker will exit with a non-zero code. This can be used in a CI pipeline to fail the pipeline when your mutation score is not sufficient.
    /// </summary>
    public virtual uint? BreakAt { get; internal set; } = 0;
    /// <summary>
    ///   Minimum good mutation score. Must be higher than or equal to threshold low. Must be higher than 0.
    /// </summary>
    public virtual short? ThresholdHigh { get; internal set; } = 80;
    /// <summary>
    ///   Minimum acceptable mutation score. Must be less than or equal to threshold high and more than or equal to threshold break.
    /// </summary>
    public virtual short? ThresholdLow { get; internal set; } = 60;
    /// <summary>
    ///   Changes the output path for Stryker logs and reports. This can be an absolute or relative path.
    /// </summary>
    public virtual string Output { get; internal set; }
    /// <summary>
    ///   Stryker aborts a unit testrun for a mutant as soon as one test fails because this is enough to confirm the mutant is killed. This can reduce the total runtime but also means you miss information about individual unit tests (e.g. if a unit test does not kill any mutants and is therefore useless). You can disable this behavior and run all unit tests for a mutant to completion. This can be especially useful when you want to find useless unit tests.
    /// </summary>
    public virtual bool? DisableBail { get; internal set; }
    /// <summary>
    ///   <p>Use git information to test only code changes since the given target. Stryker will only report on mutants within the changed code. All other mutants will not have a result.</p><p>If you wish to test only changed sources and tests but would like to have a complete mutation report see with-baseline.</p><p>Set the diffing target on the command line by passing a committish with the since flag in the format <c>--since:<committish></c>. Set the diffing target in the config file by setting the since target option.</p><p><i>* For changes on test project files all mutants covered by tests in that file will be seen as changed.</i></p>
    /// </summary>
    public virtual string Since { get; internal set; }
    /// <summary>
    ///   Change the console <c>verbosity</c> of Stryker when you want more or less details about the mutation testrun.
    /// </summary>
    public virtual StrykerVerbosity Verbosity { get; internal set; } = StrykerVerbosity.Trace;
    /// <summary>
    ///   When creating an issue on github you can include a logfile so the issue can be diagnosed easier.<p><i>File logging always uses loglevel trace.</i></p>
    /// </summary>
    public virtual bool? LogToFile { get; internal set; }
    /// <summary>
    ///   Stryker will not gracefully recover from compilation errors, but instead crash immediately. Used during development to quickly diagnose errors.<p>Also enables more debug logs not generally useful to normal users.</p>
    /// </summary>
    public virtual bool? DevMode { get; internal set; }
    /// <summary>
    ///   The API key for authentication with the Stryker dashboard.<br />Get your api key at the <a href="https://dashboard.stryker-mutator.io/">stryker dashboard</a>. To keep your api key safe, store it in an encrypted variable in your pipeline.
    /// </summary>
    public virtual string DashboardApiKey { get; internal set; }
    /// <summary>
    ///   By default, Stryker tries to auto-discover msbuild on your system. If Stryker fails to discover msbuild you may supply the path to msbuild manually with this option.
    /// </summary>
    public virtual string MsBuildPath { get; internal set; }
    /// <summary>
    ///   Instruct Stryker to break execution when at least one test failed on initial test run.
    /// </summary>
    public virtual bool? BreakOnInitialTestFailure { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("--config-file {value}", ConfigFile)
          .Add("--solution {value}", Solution)
          .Add("--project {value}", Project)
          .Add("--test-project {value}", TestProjects)
          .Add("--mutate {value}", Mutate)
          .Add("--target-framework {value}", TargetFramework)
          .Add("--version {value}", ProjectInfoVersion)
          .Add("--reporter {value}", Reporters)
          .Add("--open-report:{value}", OpenReport)
          .Add("--concurrency {value}", Concurrency)
          .Add("--break-at {value}", BreakAt)
          .Add("--threshold-high {value}", ThresholdHigh)
          .Add("--threshold-low {value}", ThresholdLow)
          .Add("--output {value}", Output)
          .Add("--disable-bail", DisableBail)
          .Add("--since:{value}", Since)
          .Add("--verbosity {value}", Verbosity)
          .Add("--log-to-file", LogToFile)
          .Add("--dev-mode", DevMode)
          .Add("--dashboard-api-key {value}", DashboardApiKey)
          .Add("--msbuild-path {value}", MsBuildPath)
          .Add("--break-on-initial-test-failure", BreakOnInitialTestFailure);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region StrykerSettingsExtensions
/// <summary>
///   Used within <see cref="StrykerTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class StrykerSettingsExtensions
{
    #region ConfigFile
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.ConfigFile"/></em></p>
    ///   <p>Path / Name of the configuration file. You can specify a custom path to the config file. For example if you want to add the stryker config section to your appsettings file. The section should still be called <c>stryker-config</c>.</p>
    /// </summary>
    [Pure]
    public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigFile = configFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.ConfigFile"/></em></p>
    ///   <p>Path / Name of the configuration file. You can specify a custom path to the config file. For example if you want to add the stryker config section to your appsettings file. The section should still be called <c>stryker-config</c>.</p>
    /// </summary>
    [Pure]
    public static T ResetConfigFile<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigFile = null;
        return toolSettings;
    }
    #endregion
    #region Solution
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Solution"/></em></p>
    ///   <p>The solution path can be supplied to help with dependency resolution. If stryker is ran from the solution file location the solution file will be analyzed and all projects in the solution will be tested by stryker.</p>
    /// </summary>
    [Pure]
    public static T SetSolution<T>(this T toolSettings, string solution) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Solution = solution;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.Solution"/></em></p>
    ///   <p>The solution path can be supplied to help with dependency resolution. If stryker is ran from the solution file location the solution file will be analyzed and all projects in the solution will be tested by stryker.</p>
    /// </summary>
    [Pure]
    public static T ResetSolution<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Solution = null;
        return toolSettings;
    }
    #endregion
    #region Project
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Project"/></em></p>
    ///   <p>The project file name is required when your test project has more than one project reference. Stryker can currently mutate one project under test for 1..N test projects but not 1..N projects under test for one test project.<br /><i>Do not pass a path to this option. Pass the project file <strong>name</strong> as it appears in your test project's references</i></p>
    /// </summary>
    [Pure]
    public static T SetProject<T>(this T toolSettings, string project) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Project = project;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.Project"/></em></p>
    ///   <p>The project file name is required when your test project has more than one project reference. Stryker can currently mutate one project under test for 1..N test projects but not 1..N projects under test for one test project.<br /><i>Do not pass a path to this option. Pass the project file <strong>name</strong> as it appears in your test project's references</i></p>
    /// </summary>
    [Pure]
    public static T ResetProject<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Project = null;
        return toolSettings;
    }
    #endregion
    #region TestProjects
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.TestProjects"/> to a new list</em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T SetTestProjects<T>(this T toolSettings, params string[] testProjects) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestProjectsInternal = testProjects.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.TestProjects"/> to a new list</em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T SetTestProjects<T>(this T toolSettings, IEnumerable<string> testProjects) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestProjectsInternal = testProjects.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="StrykerSettings.TestProjects"/></em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T AddTestProjects<T>(this T toolSettings, params string[] testProjects) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestProjectsInternal.AddRange(testProjects);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="StrykerSettings.TestProjects"/></em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T AddTestProjects<T>(this T toolSettings, IEnumerable<string> testProjects) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestProjectsInternal.AddRange(testProjects);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="StrykerSettings.TestProjects"/></em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T ClearTestProjects<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestProjectsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="StrykerSettings.TestProjects"/></em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T RemoveTestProjects<T>(this T toolSettings, params string[] testProjects) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(testProjects);
        toolSettings.TestProjectsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="StrykerSettings.TestProjects"/></em></p>
    ///   <p>When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.</p>
    /// </summary>
    [Pure]
    public static T RemoveTestProjects<T>(this T toolSettings, IEnumerable<string> testProjects) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(testProjects);
        toolSettings.TestProjectsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Mutate
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Mutate"/> to a new list</em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T SetMutate<T>(this T toolSettings, params string[] mutate) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutateInternal = mutate.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Mutate"/> to a new list</em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T SetMutate<T>(this T toolSettings, IEnumerable<string> mutate) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutateInternal = mutate.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="StrykerSettings.Mutate"/></em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T AddMutate<T>(this T toolSettings, params string[] mutate) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutateInternal.AddRange(mutate);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="StrykerSettings.Mutate"/></em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T AddMutate<T>(this T toolSettings, IEnumerable<string> mutate) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutateInternal.AddRange(mutate);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="StrykerSettings.Mutate"/></em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T ClearMutate<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutateInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="StrykerSettings.Mutate"/></em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T RemoveMutate<T>(this T toolSettings, params string[] mutate) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(mutate);
        toolSettings.MutateInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="StrykerSettings.Mutate"/></em></p>
    ///   <p>With <c>mutate</c> you configure the subset of files to use for mutation testing. Only source files part of your project will be taken into account. When this option is not specified the whole project will be mutated. You can add an <c>!</c> in front of the pattern to exclude instead of include matching files. This can be used to for example ignore generated files while mutating.</p><p>When only exclude patterns are provided, all files will be included that do not match any exclude pattern. If both include and exclude patterns are provided, only the files that match an include pattern but not also an exclude pattern will be included. The order of the patterns is irrelevant.</p><p>The patterns support <a href="https://en.wikipedia.org/wiki/Glob_(programming)">globbing syntax</a> to allow wildcards.</p><p><strong>Example</strong> :</p><table><thead><tr><th>Patterns</th><th>File</th><th>Will be mutated</th></tr></thead><tbody><tr><td>null</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'**/*.*'</td><td>MyFolder/MyFactory.cs</td><td>Yes</td></tr><tr><td>'!**/MyFactory.cs'</td><td>MyFolder/MyFactory.cs</td><td>No</td></tr></tbody></table><p>To allow more fine-grained filtering you can also specify the span of text that should be in- or excluded. A span is defined by the indices of the first character and the last character. <code>dotnet stryker -m "MyFolder/MyService.cs{10..100}"</code></p>
    /// </summary>
    [Pure]
    public static T RemoveMutate<T>(this T toolSettings, IEnumerable<string> mutate) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(mutate);
        toolSettings.MutateInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region TargetFramework
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.TargetFramework"/></em></p>
    ///   <p>Randomly selected. If the project targets multiple frameworks, this way you can specify the particular framework to build against. If you specify a non-existent target, Stryker will build the project against a random one (or the only one if so).</p>
    /// </summary>
    [Pure]
    public static T SetTargetFramework<T>(this T toolSettings, string targetFramework) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TargetFramework = targetFramework;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.TargetFramework"/></em></p>
    ///   <p>Randomly selected. If the project targets multiple frameworks, this way you can specify the particular framework to build against. If you specify a non-existent target, Stryker will build the project against a random one (or the only one if so).</p>
    /// </summary>
    [Pure]
    public static T ResetTargetFramework<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TargetFramework = null;
        return toolSettings;
    }
    #endregion
    #region ProjectInfoVersion
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.ProjectInfoVersion"/></em></p>
    ///   <p>The version of the report. This should be filled with the branch name, git tag or git sha (although no validation is done). You can override a report of a specific version, like docker tags. Slashes in the version should not be encoded. For example, it's valid to use "feat/logging".</p>
    /// </summary>
    [Pure]
    public static T SetProjectInfoVersion<T>(this T toolSettings, string projectInfoVersion) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ProjectInfoVersion = projectInfoVersion;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.ProjectInfoVersion"/></em></p>
    ///   <p>The version of the report. This should be filled with the branch name, git tag or git sha (although no validation is done). You can override a report of a specific version, like docker tags. Slashes in the version should not be encoded. For example, it's valid to use "feat/logging".</p>
    /// </summary>
    [Pure]
    public static T ResetProjectInfoVersion<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ProjectInfoVersion = null;
        return toolSettings;
    }
    #endregion
    #region MutationLevel
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.MutationLevel"/></em></p>
    ///   <p>Stryker supports multiple <a href="https://stryker-mutator.io/docs/stryker-net/configuration/#mutation-level-level">mutation level</a>s. Each level comes with a specific set of mutations. Each level contains the mutations of the levels below it. By setting the level to Complete you will get all possible mutations and thus the strictest mutation test. This comes at the price of longer runtime as more mutations will be generated and tested.</p>
    /// </summary>
    [Pure]
    public static T SetMutationLevel<T>(this T toolSettings, StrykerMutationLevel mutationLevel) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutationLevel = mutationLevel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.MutationLevel"/></em></p>
    ///   <p>Stryker supports multiple <a href="https://stryker-mutator.io/docs/stryker-net/configuration/#mutation-level-level">mutation level</a>s. Each level comes with a specific set of mutations. Each level contains the mutations of the levels below it. By setting the level to Complete you will get all possible mutations and thus the strictest mutation test. This comes at the price of longer runtime as more mutations will be generated and tested.</p>
    /// </summary>
    [Pure]
    public static T ResetMutationLevel<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MutationLevel = null;
        return toolSettings;
    }
    #endregion
    #region Reporters
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Reporters"/> to a new list</em></p>
    /// </summary>
    [Pure]
    public static T SetReporters<T>(this T toolSettings, params StrykerReporter[] reporters) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReportersInternal = reporters.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Reporters"/> to a new list</em></p>
    /// </summary>
    [Pure]
    public static T SetReporters<T>(this T toolSettings, IEnumerable<StrykerReporter> reporters) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReportersInternal = reporters.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="StrykerSettings.Reporters"/></em></p>
    /// </summary>
    [Pure]
    public static T AddReporters<T>(this T toolSettings, params StrykerReporter[] reporters) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReportersInternal.AddRange(reporters);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="StrykerSettings.Reporters"/></em></p>
    /// </summary>
    [Pure]
    public static T AddReporters<T>(this T toolSettings, IEnumerable<StrykerReporter> reporters) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReportersInternal.AddRange(reporters);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="StrykerSettings.Reporters"/></em></p>
    /// </summary>
    [Pure]
    public static T ClearReporters<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReportersInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="StrykerSettings.Reporters"/></em></p>
    /// </summary>
    [Pure]
    public static T RemoveReporters<T>(this T toolSettings, params StrykerReporter[] reporters) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<StrykerReporter>(reporters);
        toolSettings.ReportersInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="StrykerSettings.Reporters"/></em></p>
    /// </summary>
    [Pure]
    public static T RemoveReporters<T>(this T toolSettings, IEnumerable<StrykerReporter> reporters) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<StrykerReporter>(reporters);
        toolSettings.ReportersInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region OpenReport
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.OpenReport"/></em></p>
    ///   <p>When this option is passed, generated reports should open in the browser automatically once Stryker starts testing mutants, and will update the report till Stryker is done. Both html and dashboard reports can be opened automatically.</p>
    /// </summary>
    [Pure]
    public static T SetOpenReport<T>(this T toolSettings, StrykerOpenReport openReport) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OpenReport = openReport;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.OpenReport"/></em></p>
    ///   <p>When this option is passed, generated reports should open in the browser automatically once Stryker starts testing mutants, and will update the report till Stryker is done. Both html and dashboard reports can be opened automatically.</p>
    /// </summary>
    [Pure]
    public static T ResetOpenReport<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OpenReport = null;
        return toolSettings;
    }
    #endregion
    #region Concurrency
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Concurrency"/></em></p>
    ///   <p>Change the amount of concurrent workers Stryker uses for the mutation testrun. Defaults to using half your logical (virtual) processor count.<p><strong>Example<strong>: an intel i7 quad-core with hyperthreading has 8 logical cores and 4 physical cores. Stryker will use 4 concurrent workers when using the default.</p></p>
    /// </summary>
    [Pure]
    public static T SetConcurrency<T>(this T toolSettings, uint? concurrency) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Concurrency = concurrency;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.Concurrency"/></em></p>
    ///   <p>Change the amount of concurrent workers Stryker uses for the mutation testrun. Defaults to using half your logical (virtual) processor count.<p><strong>Example<strong>: an intel i7 quad-core with hyperthreading has 8 logical cores and 4 physical cores. Stryker will use 4 concurrent workers when using the default.</p></p>
    /// </summary>
    [Pure]
    public static T ResetConcurrency<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Concurrency = null;
        return toolSettings;
    }
    #endregion
    #region BreakAt
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.BreakAt"/></em></p>
    ///   <p>Must be less than or equal to threshold low. When threshold break is set to anything other than 0 and the mutation score is lower than the threshold Stryker will exit with a non-zero code. This can be used in a CI pipeline to fail the pipeline when your mutation score is not sufficient.</p>
    /// </summary>
    [Pure]
    public static T SetBreakAt<T>(this T toolSettings, uint? breakAt) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakAt = breakAt;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.BreakAt"/></em></p>
    ///   <p>Must be less than or equal to threshold low. When threshold break is set to anything other than 0 and the mutation score is lower than the threshold Stryker will exit with a non-zero code. This can be used in a CI pipeline to fail the pipeline when your mutation score is not sufficient.</p>
    /// </summary>
    [Pure]
    public static T ResetBreakAt<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakAt = null;
        return toolSettings;
    }
    #endregion
    #region ThresholdHigh
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.ThresholdHigh"/></em></p>
    ///   <p>Minimum good mutation score. Must be higher than or equal to threshold low. Must be higher than 0.</p>
    /// </summary>
    [Pure]
    public static T SetThresholdHigh<T>(this T toolSettings, short? thresholdHigh) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ThresholdHigh = thresholdHigh;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.ThresholdHigh"/></em></p>
    ///   <p>Minimum good mutation score. Must be higher than or equal to threshold low. Must be higher than 0.</p>
    /// </summary>
    [Pure]
    public static T ResetThresholdHigh<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ThresholdHigh = null;
        return toolSettings;
    }
    #endregion
    #region ThresholdLow
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.ThresholdLow"/></em></p>
    ///   <p>Minimum acceptable mutation score. Must be less than or equal to threshold high and more than or equal to threshold break.</p>
    /// </summary>
    [Pure]
    public static T SetThresholdLow<T>(this T toolSettings, short? thresholdLow) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ThresholdLow = thresholdLow;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.ThresholdLow"/></em></p>
    ///   <p>Minimum acceptable mutation score. Must be less than or equal to threshold high and more than or equal to threshold break.</p>
    /// </summary>
    [Pure]
    public static T ResetThresholdLow<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ThresholdLow = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Output"/></em></p>
    ///   <p>Changes the output path for Stryker logs and reports. This can be an absolute or relative path.</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, string output) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.Output"/></em></p>
    ///   <p>Changes the output path for Stryker logs and reports. This can be an absolute or relative path.</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region DisableBail
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.DisableBail"/></em></p>
    ///   <p>Stryker aborts a unit testrun for a mutant as soon as one test fails because this is enough to confirm the mutant is killed. This can reduce the total runtime but also means you miss information about individual unit tests (e.g. if a unit test does not kill any mutants and is therefore useless). You can disable this behavior and run all unit tests for a mutant to completion. This can be especially useful when you want to find useless unit tests.</p>
    /// </summary>
    [Pure]
    public static T SetDisableBail<T>(this T toolSettings, bool? disableBail) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DisableBail = disableBail;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.DisableBail"/></em></p>
    ///   <p>Stryker aborts a unit testrun for a mutant as soon as one test fails because this is enough to confirm the mutant is killed. This can reduce the total runtime but also means you miss information about individual unit tests (e.g. if a unit test does not kill any mutants and is therefore useless). You can disable this behavior and run all unit tests for a mutant to completion. This can be especially useful when you want to find useless unit tests.</p>
    /// </summary>
    [Pure]
    public static T ResetDisableBail<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DisableBail = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="StrykerSettings.DisableBail"/></em></p>
    ///   <p>Stryker aborts a unit testrun for a mutant as soon as one test fails because this is enough to confirm the mutant is killed. This can reduce the total runtime but also means you miss information about individual unit tests (e.g. if a unit test does not kill any mutants and is therefore useless). You can disable this behavior and run all unit tests for a mutant to completion. This can be especially useful when you want to find useless unit tests.</p>
    /// </summary>
    [Pure]
    public static T EnableDisableBail<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DisableBail = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="StrykerSettings.DisableBail"/></em></p>
    ///   <p>Stryker aborts a unit testrun for a mutant as soon as one test fails because this is enough to confirm the mutant is killed. This can reduce the total runtime but also means you miss information about individual unit tests (e.g. if a unit test does not kill any mutants and is therefore useless). You can disable this behavior and run all unit tests for a mutant to completion. This can be especially useful when you want to find useless unit tests.</p>
    /// </summary>
    [Pure]
    public static T DisableDisableBail<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DisableBail = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="StrykerSettings.DisableBail"/></em></p>
    ///   <p>Stryker aborts a unit testrun for a mutant as soon as one test fails because this is enough to confirm the mutant is killed. This can reduce the total runtime but also means you miss information about individual unit tests (e.g. if a unit test does not kill any mutants and is therefore useless). You can disable this behavior and run all unit tests for a mutant to completion. This can be especially useful when you want to find useless unit tests.</p>
    /// </summary>
    [Pure]
    public static T ToggleDisableBail<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DisableBail = !toolSettings.DisableBail;
        return toolSettings;
    }
    #endregion
    #region Since
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Since"/></em></p>
    ///   <p>Use git information to test only code changes since the given target. Stryker will only report on mutants within the changed code. All other mutants will not have a result.</p><p>If you wish to test only changed sources and tests but would like to have a complete mutation report see with-baseline.</p><p>Set the diffing target on the command line by passing a committish with the since flag in the format <c>--since:<committish></c>. Set the diffing target in the config file by setting the since target option.</p><p><i>* For changes on test project files all mutants covered by tests in that file will be seen as changed.</i></p>
    /// </summary>
    [Pure]
    public static T SetSince<T>(this T toolSettings, string since) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Since = since;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.Since"/></em></p>
    ///   <p>Use git information to test only code changes since the given target. Stryker will only report on mutants within the changed code. All other mutants will not have a result.</p><p>If you wish to test only changed sources and tests but would like to have a complete mutation report see with-baseline.</p><p>Set the diffing target on the command line by passing a committish with the since flag in the format <c>--since:<committish></c>. Set the diffing target in the config file by setting the since target option.</p><p><i>* For changes on test project files all mutants covered by tests in that file will be seen as changed.</i></p>
    /// </summary>
    [Pure]
    public static T ResetSince<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Since = null;
        return toolSettings;
    }
    #endregion
    #region Verbosity
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.Verbosity"/></em></p>
    ///   <p>Change the console <c>verbosity</c> of Stryker when you want more or less details about the mutation testrun.</p>
    /// </summary>
    [Pure]
    public static T SetVerbosity<T>(this T toolSettings, StrykerVerbosity verbosity) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verbosity = verbosity;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.Verbosity"/></em></p>
    ///   <p>Change the console <c>verbosity</c> of Stryker when you want more or less details about the mutation testrun.</p>
    /// </summary>
    [Pure]
    public static T ResetVerbosity<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verbosity = null;
        return toolSettings;
    }
    #endregion
    #region LogToFile
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.LogToFile"/></em></p>
    ///   <p>When creating an issue on github you can include a logfile so the issue can be diagnosed easier.<p><i>File logging always uses loglevel trace.</i></p></p>
    /// </summary>
    [Pure]
    public static T SetLogToFile<T>(this T toolSettings, bool? logToFile) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LogToFile = logToFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.LogToFile"/></em></p>
    ///   <p>When creating an issue on github you can include a logfile so the issue can be diagnosed easier.<p><i>File logging always uses loglevel trace.</i></p></p>
    /// </summary>
    [Pure]
    public static T ResetLogToFile<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LogToFile = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="StrykerSettings.LogToFile"/></em></p>
    ///   <p>When creating an issue on github you can include a logfile so the issue can be diagnosed easier.<p><i>File logging always uses loglevel trace.</i></p></p>
    /// </summary>
    [Pure]
    public static T EnableLogToFile<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LogToFile = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="StrykerSettings.LogToFile"/></em></p>
    ///   <p>When creating an issue on github you can include a logfile so the issue can be diagnosed easier.<p><i>File logging always uses loglevel trace.</i></p></p>
    /// </summary>
    [Pure]
    public static T DisableLogToFile<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LogToFile = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="StrykerSettings.LogToFile"/></em></p>
    ///   <p>When creating an issue on github you can include a logfile so the issue can be diagnosed easier.<p><i>File logging always uses loglevel trace.</i></p></p>
    /// </summary>
    [Pure]
    public static T ToggleLogToFile<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LogToFile = !toolSettings.LogToFile;
        return toolSettings;
    }
    #endregion
    #region DevMode
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.DevMode"/></em></p>
    ///   <p>Stryker will not gracefully recover from compilation errors, but instead crash immediately. Used during development to quickly diagnose errors.<p>Also enables more debug logs not generally useful to normal users.</p></p>
    /// </summary>
    [Pure]
    public static T SetDevMode<T>(this T toolSettings, bool? devMode) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DevMode = devMode;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.DevMode"/></em></p>
    ///   <p>Stryker will not gracefully recover from compilation errors, but instead crash immediately. Used during development to quickly diagnose errors.<p>Also enables more debug logs not generally useful to normal users.</p></p>
    /// </summary>
    [Pure]
    public static T ResetDevMode<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DevMode = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="StrykerSettings.DevMode"/></em></p>
    ///   <p>Stryker will not gracefully recover from compilation errors, but instead crash immediately. Used during development to quickly diagnose errors.<p>Also enables more debug logs not generally useful to normal users.</p></p>
    /// </summary>
    [Pure]
    public static T EnableDevMode<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DevMode = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="StrykerSettings.DevMode"/></em></p>
    ///   <p>Stryker will not gracefully recover from compilation errors, but instead crash immediately. Used during development to quickly diagnose errors.<p>Also enables more debug logs not generally useful to normal users.</p></p>
    /// </summary>
    [Pure]
    public static T DisableDevMode<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DevMode = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="StrykerSettings.DevMode"/></em></p>
    ///   <p>Stryker will not gracefully recover from compilation errors, but instead crash immediately. Used during development to quickly diagnose errors.<p>Also enables more debug logs not generally useful to normal users.</p></p>
    /// </summary>
    [Pure]
    public static T ToggleDevMode<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DevMode = !toolSettings.DevMode;
        return toolSettings;
    }
    #endregion
    #region DashboardApiKey
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.DashboardApiKey"/></em></p>
    ///   <p>The API key for authentication with the Stryker dashboard.<br />Get your api key at the <a href="https://dashboard.stryker-mutator.io/">stryker dashboard</a>. To keep your api key safe, store it in an encrypted variable in your pipeline.</p>
    /// </summary>
    [Pure]
    public static T SetDashboardApiKey<T>(this T toolSettings, string dashboardApiKey) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DashboardApiKey = dashboardApiKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.DashboardApiKey"/></em></p>
    ///   <p>The API key for authentication with the Stryker dashboard.<br />Get your api key at the <a href="https://dashboard.stryker-mutator.io/">stryker dashboard</a>. To keep your api key safe, store it in an encrypted variable in your pipeline.</p>
    /// </summary>
    [Pure]
    public static T ResetDashboardApiKey<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DashboardApiKey = null;
        return toolSettings;
    }
    #endregion
    #region MsBuildPath
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.MsBuildPath"/></em></p>
    ///   <p>By default, Stryker tries to auto-discover msbuild on your system. If Stryker fails to discover msbuild you may supply the path to msbuild manually with this option.</p>
    /// </summary>
    [Pure]
    public static T SetMsBuildPath<T>(this T toolSettings, string msBuildPath) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MsBuildPath = msBuildPath;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.MsBuildPath"/></em></p>
    ///   <p>By default, Stryker tries to auto-discover msbuild on your system. If Stryker fails to discover msbuild you may supply the path to msbuild manually with this option.</p>
    /// </summary>
    [Pure]
    public static T ResetMsBuildPath<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MsBuildPath = null;
        return toolSettings;
    }
    #endregion
    #region BreakOnInitialTestFailure
    /// <summary>
    ///   <p><em>Sets <see cref="StrykerSettings.BreakOnInitialTestFailure"/></em></p>
    ///   <p>Instruct Stryker to break execution when at least one test failed on initial test run.</p>
    /// </summary>
    [Pure]
    public static T SetBreakOnInitialTestFailure<T>(this T toolSettings, bool? breakOnInitialTestFailure) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakOnInitialTestFailure = breakOnInitialTestFailure;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="StrykerSettings.BreakOnInitialTestFailure"/></em></p>
    ///   <p>Instruct Stryker to break execution when at least one test failed on initial test run.</p>
    /// </summary>
    [Pure]
    public static T ResetBreakOnInitialTestFailure<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakOnInitialTestFailure = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="StrykerSettings.BreakOnInitialTestFailure"/></em></p>
    ///   <p>Instruct Stryker to break execution when at least one test failed on initial test run.</p>
    /// </summary>
    [Pure]
    public static T EnableBreakOnInitialTestFailure<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakOnInitialTestFailure = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="StrykerSettings.BreakOnInitialTestFailure"/></em></p>
    ///   <p>Instruct Stryker to break execution when at least one test failed on initial test run.</p>
    /// </summary>
    [Pure]
    public static T DisableBreakOnInitialTestFailure<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakOnInitialTestFailure = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="StrykerSettings.BreakOnInitialTestFailure"/></em></p>
    ///   <p>Instruct Stryker to break execution when at least one test failed on initial test run.</p>
    /// </summary>
    [Pure]
    public static T ToggleBreakOnInitialTestFailure<T>(this T toolSettings) where T : StrykerSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.BreakOnInitialTestFailure = !toolSettings.BreakOnInitialTestFailure;
        return toolSettings;
    }
    #endregion
}
#endregion
#region StrykerMutationLevel
/// <summary>
///   Used within <see cref="StrykerTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<StrykerMutationLevel>))]
public partial class StrykerMutationLevel : Enumeration
{
    public static StrykerMutationLevel Basic = (StrykerMutationLevel) "Basic";
    public static StrykerMutationLevel Standard = (StrykerMutationLevel) "Standard";
    public static StrykerMutationLevel Advanced = (StrykerMutationLevel) "Advanced";
    public static StrykerMutationLevel Complete = (StrykerMutationLevel) "Complete";
    public static implicit operator StrykerMutationLevel(string value)
    {
        return new StrykerMutationLevel { Value = value };
    }
}
#endregion
#region StrykerReporter
/// <summary>
///   Used within <see cref="StrykerTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<StrykerReporter>))]
public partial class StrykerReporter : Enumeration
{
    public static StrykerReporter All = (StrykerReporter) "All";
    public static StrykerReporter Html = (StrykerReporter) "Html";
    public static StrykerReporter Progress = (StrykerReporter) "Progress";
    public static StrykerReporter Dashboard = (StrykerReporter) "Dashboard";
    public static StrykerReporter Cleartext = (StrykerReporter) "Cleartext";
    public static StrykerReporter CleartextTree = (StrykerReporter) "CleartextTree";
    public static StrykerReporter Dots = (StrykerReporter) "Dots";
    public static StrykerReporter Json = (StrykerReporter) "Json";
    public static implicit operator StrykerReporter(string value)
    {
        return new StrykerReporter { Value = value };
    }
}
#endregion
#region StrykerOpenReport
/// <summary>
///   Used within <see cref="StrykerTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<StrykerOpenReport>))]
public partial class StrykerOpenReport : Enumeration
{
    public static StrykerOpenReport Html = (StrykerOpenReport) "Html";
    public static StrykerOpenReport Dashboard = (StrykerOpenReport) "Dashboard";
    public static implicit operator StrykerOpenReport(string value)
    {
        return new StrykerOpenReport { Value = value };
    }
}
#endregion
#region StrykerVerbosity
/// <summary>
///   Used within <see cref="StrykerTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<StrykerVerbosity>))]
public partial class StrykerVerbosity : Enumeration
{
    public static StrykerVerbosity Error = (StrykerVerbosity) "Error";
    public static StrykerVerbosity Warning = (StrykerVerbosity) "Warning";
    public static StrykerVerbosity Info = (StrykerVerbosity) "Info";
    public static StrykerVerbosity Debug = (StrykerVerbosity) "Debug";
    public static StrykerVerbosity Trace = (StrykerVerbosity) "Trace";
    public static implicit operator StrykerVerbosity(string value)
    {
        return new StrykerVerbosity { Value = value };
    }
}
#endregion
