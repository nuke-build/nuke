// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/VSTest/VSTest.json

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

namespace Nuke.Common.Tools.VSTest;

/// <summary><p>VSTest.Console.exe is the command-line command that is used to run tests. You can specify several options in any order on the VSTest.Console.exe command line.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/jj155796.aspx">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class VSTestTasks : ToolTasks, IRequireNuGetPackage
{
    public static string VSTestPath => new VSTestTasks().GetToolPath();
    public const string PackageId = "Microsoft.TestPlatform";
    public const string PackageExecutable = "vstest.console.exe";
    /// <summary><p>VSTest.Console.exe is the command-line command that is used to run tests. You can specify several options in any order on the VSTest.Console.exe command line.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/jj155796.aspx">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> VSTest(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new VSTestTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>VSTest.Console.exe is the command-line command that is used to run tests. You can specify several options in any order on the VSTest.Console.exe command line.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/jj155796.aspx">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;testAssemblies&gt;</c> via <see cref="VSTestSettings.TestAssemblies"/></li><li><c>/Diag</c> via <see cref="VSTestSettings.DiagnosticsFile"/></li><li><c>/EnableCodeCoverage</c> via <see cref="VSTestSettings.EnableCodeCoverage"/></li><li><c>/Framework</c> via <see cref="VSTestSettings.Framework"/></li><li><c>/InIsolation</c> via <see cref="VSTestSettings.InIsolation"/></li><li><c>/ListDiscoverers</c> via <see cref="VSTestSettings.ListDiscoverers"/></li><li><c>/ListExecutors</c> via <see cref="VSTestSettings.ListExecutors"/></li><li><c>/ListLoggers</c> via <see cref="VSTestSettings.ListLoggers"/></li><li><c>/ListSettingsProviders</c> via <see cref="VSTestSettings.ListSettingsProviders"/></li><li><c>/ListTests</c> via <see cref="VSTestSettings.ListTests"/></li><li><c>/Logger</c> via <see cref="VSTestSettings.Logger"/></li><li><c>/Parallel</c> via <see cref="VSTestSettings.Parallel"/></li><li><c>/Platform</c> via <see cref="VSTestSettings.Platform"/></li><li><c>/Settings</c> via <see cref="VSTestSettings.SettingsFile"/></li><li><c>/TestAdapterPath</c> via <see cref="VSTestSettings.TestAdapterPath"/></li><li><c>/TestCaseFilter</c> via <see cref="VSTestSettings.TestCaseFilters"/></li><li><c>/Tests</c> via <see cref="VSTestSettings.Tests"/></li><li><c>/UseVsixExtensions</c> via <see cref="VSTestSettings.UseVsixExtensions"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> VSTest(VSTestSettings options = null) => new VSTestTasks().Run(options);
    /// <summary><p>VSTest.Console.exe is the command-line command that is used to run tests. You can specify several options in any order on the VSTest.Console.exe command line.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/jj155796.aspx">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;testAssemblies&gt;</c> via <see cref="VSTestSettings.TestAssemblies"/></li><li><c>/Diag</c> via <see cref="VSTestSettings.DiagnosticsFile"/></li><li><c>/EnableCodeCoverage</c> via <see cref="VSTestSettings.EnableCodeCoverage"/></li><li><c>/Framework</c> via <see cref="VSTestSettings.Framework"/></li><li><c>/InIsolation</c> via <see cref="VSTestSettings.InIsolation"/></li><li><c>/ListDiscoverers</c> via <see cref="VSTestSettings.ListDiscoverers"/></li><li><c>/ListExecutors</c> via <see cref="VSTestSettings.ListExecutors"/></li><li><c>/ListLoggers</c> via <see cref="VSTestSettings.ListLoggers"/></li><li><c>/ListSettingsProviders</c> via <see cref="VSTestSettings.ListSettingsProviders"/></li><li><c>/ListTests</c> via <see cref="VSTestSettings.ListTests"/></li><li><c>/Logger</c> via <see cref="VSTestSettings.Logger"/></li><li><c>/Parallel</c> via <see cref="VSTestSettings.Parallel"/></li><li><c>/Platform</c> via <see cref="VSTestSettings.Platform"/></li><li><c>/Settings</c> via <see cref="VSTestSettings.SettingsFile"/></li><li><c>/TestAdapterPath</c> via <see cref="VSTestSettings.TestAdapterPath"/></li><li><c>/TestCaseFilter</c> via <see cref="VSTestSettings.TestCaseFilters"/></li><li><c>/Tests</c> via <see cref="VSTestSettings.Tests"/></li><li><c>/UseVsixExtensions</c> via <see cref="VSTestSettings.UseVsixExtensions"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> VSTest(Configure<VSTestSettings> configurator) => new VSTestTasks().Run(configurator.Invoke(new VSTestSettings()));
    /// <summary><p>VSTest.Console.exe is the command-line command that is used to run tests. You can specify several options in any order on the VSTest.Console.exe command line.</p><p>For more details, visit the <a href="https://msdn.microsoft.com/en-us/library/jj155796.aspx">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;testAssemblies&gt;</c> via <see cref="VSTestSettings.TestAssemblies"/></li><li><c>/Diag</c> via <see cref="VSTestSettings.DiagnosticsFile"/></li><li><c>/EnableCodeCoverage</c> via <see cref="VSTestSettings.EnableCodeCoverage"/></li><li><c>/Framework</c> via <see cref="VSTestSettings.Framework"/></li><li><c>/InIsolation</c> via <see cref="VSTestSettings.InIsolation"/></li><li><c>/ListDiscoverers</c> via <see cref="VSTestSettings.ListDiscoverers"/></li><li><c>/ListExecutors</c> via <see cref="VSTestSettings.ListExecutors"/></li><li><c>/ListLoggers</c> via <see cref="VSTestSettings.ListLoggers"/></li><li><c>/ListSettingsProviders</c> via <see cref="VSTestSettings.ListSettingsProviders"/></li><li><c>/ListTests</c> via <see cref="VSTestSettings.ListTests"/></li><li><c>/Logger</c> via <see cref="VSTestSettings.Logger"/></li><li><c>/Parallel</c> via <see cref="VSTestSettings.Parallel"/></li><li><c>/Platform</c> via <see cref="VSTestSettings.Platform"/></li><li><c>/Settings</c> via <see cref="VSTestSettings.SettingsFile"/></li><li><c>/TestAdapterPath</c> via <see cref="VSTestSettings.TestAdapterPath"/></li><li><c>/TestCaseFilter</c> via <see cref="VSTestSettings.TestCaseFilters"/></li><li><c>/Tests</c> via <see cref="VSTestSettings.Tests"/></li><li><c>/UseVsixExtensions</c> via <see cref="VSTestSettings.UseVsixExtensions"/></li></ul></remarks>
    public static IEnumerable<(VSTestSettings Settings, IReadOnlyCollection<Output> Output)> VSTest(CombinatorialConfigure<VSTestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(VSTest, degreeOfParallelism, completeOnFailure);
}
#region VSTestSettings
/// <summary>Used within <see cref="VSTestTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<VSTestSettings>))]
[Command(Type = typeof(VSTestTasks), Command = nameof(VSTestTasks.VSTest))]
public partial class VSTestSettings : ToolOptions
{
    /// <summary>Run tests from the specified files. Separate multiple test file names with spaces.</summary>
    [Argument(Format = "{value}", Position = 1)] public IReadOnlyList<string> TestAssemblies => Get<List<string>>(() => TestAssemblies);
    /// <summary>Run tests with additional settings such as data collectors.</summary>
    [Argument(Format = "/Settings:{value}")] public string SettingsFile => Get<string>(() => SettingsFile);
    /// <summary>Run tests with names that match the provided values. To provide multiple values, separate them by commas.</summary>
    [Argument(Format = "/Tests:{value}", Separator = ",")] public IReadOnlyList<string> Tests => Get<List<string>>(() => Tests);
    /// <summary>Specifies that the tests be executed in parallel. By default up to all available cores on the machine may be used. The number of cores to use can be configured by using a settings file.</summary>
    [Argument(Format = "/Parallel")] public bool? Parallel => Get<bool?>(() => Parallel);
    /// <summary>Enables data diagnostic adapter CodeCoverage in the test run.</summary>
    [Argument(Format = "/EnableCodeCoverage")] public bool? EnableCodeCoverage => Get<bool?>(() => EnableCodeCoverage);
    /// <summary>Runs the tests in an isolated process.</summary>
    [Argument(Format = "/InIsolation")] public bool? InIsolation => Get<bool?>(() => InIsolation);
    /// <summary>This makes vstest.console.exe process use or skip the VSIX extensions installed (if any) in the test run.</summary>
    [Argument(Format = "/UseVsixExtensions:{value}")] public bool? UseVsixExtensions => Get<bool?>(() => UseVsixExtensions);
    /// <summary>Forces the vstest.console.exe process to use custom test adapters from a specified path (if any) in the test run.</summary>
    [Argument(Format = "/TestAdapterPath:{value}")] public string TestAdapterPath => Get<string>(() => TestAdapterPath);
    /// <summary>Target platform architecture to be used for test execution.</summary>
    [Argument(Format = "/Platform:{value}")] public VsTestPlatform Platform => Get<VsTestPlatform>(() => Platform);
    /// <summary>Target .NET Framework version to be used for test execution.</summary>
    [Argument(Format = "/Framework:{value}")] public VsTestFramework Framework => Get<VsTestFramework>(() => Framework);
    /// <summary>Run tests that match the given expression.<para/><c>&lt;Expression&gt;</c> is of the format <c>&lt;property&gt;=&lt;value&gt;[|&lt;Expression&gt;]</c>.<para/>The <c>/TestCaseFilter</c> command line option cannot be used with the <c>/Tests</c> command line option.<para/>For information about creating and using expressions, see <a href="https://github.com/Microsoft/vstest-docs/blob/master/docs/filter.md">TestCase filter</a>.</summary>
    [Argument(Format = "/TestCaseFilter:{value}", Separator = "|")] public IReadOnlyList<string> TestCaseFilters => Get<List<string>>(() => TestCaseFilters);
    /// <summary>Specify a logger for test results. Example: To log results into a Visual Studio Test Results File (TRX) use <c>/Logger:trx</c>.</summary>
    [Argument(Format = "/Logger:{value}")] public string Logger => Get<string>(() => Logger);
    /// <summary>Lists discovered tests from the given test container.</summary>
    [Argument(Format = "/ListTests:{value}")] public string ListTests => Get<string>(() => ListTests);
    /// <summary>Lists installed test discoverers.</summary>
    [Argument(Format = "/ListDiscoverers")] public bool? ListDiscoverers => Get<bool?>(() => ListDiscoverers);
    /// <summary>Lists installed test executors.</summary>
    [Argument(Format = "/ListExecutors")] public bool? ListExecutors => Get<bool?>(() => ListExecutors);
    /// <summary>Lists installed test loggers.</summary>
    [Argument(Format = "/ListLoggers")] public bool? ListLoggers => Get<bool?>(() => ListLoggers);
    /// <summary>Lists installed test settings providers.</summary>
    [Argument(Format = "/ListSettingsProviders")] public bool? ListSettingsProviders => Get<bool?>(() => ListSettingsProviders);
    /// <summary>Writes diagnostic trace logs to the specified file.</summary>
    [Argument(Format = "/Diag:{value}")] public string DiagnosticsFile => Get<string>(() => DiagnosticsFile);
}
#endregion
#region VSTestSettingsExtensions
/// <summary>Used within <see cref="VSTestTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class VSTestSettingsExtensions
{
    #region TestAssemblies
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T SetTestAssemblies<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.TestAssemblies, v));
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T SetTestAssemblies<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.TestAssemblies, v));
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T AddTestAssemblies<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.AddCollection(() => o.TestAssemblies, v));
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T AddTestAssemblies<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.AddCollection(() => o.TestAssemblies, v));
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T RemoveTestAssemblies<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.RemoveCollection(() => o.TestAssemblies, v));
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T RemoveTestAssemblies<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.RemoveCollection(() => o.TestAssemblies, v));
    /// <inheritdoc cref="VSTestSettings.TestAssemblies"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAssemblies))]
    public static T ClearTestAssemblies<T>(this T o) where T : VSTestSettings => o.Modify(b => b.ClearCollection(() => o.TestAssemblies));
    #endregion
    #region SettingsFile
    /// <inheritdoc cref="VSTestSettings.SettingsFile"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.SettingsFile))]
    public static T SetSettingsFile<T>(this T o, string v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.SettingsFile, v));
    /// <inheritdoc cref="VSTestSettings.SettingsFile"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.SettingsFile))]
    public static T ResetSettingsFile<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.SettingsFile));
    #endregion
    #region Tests
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T SetTests<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Tests, v));
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T SetTests<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Tests, v));
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T AddTests<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.AddCollection(() => o.Tests, v));
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T AddTests<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.AddCollection(() => o.Tests, v));
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T RemoveTests<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.RemoveCollection(() => o.Tests, v));
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T RemoveTests<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.RemoveCollection(() => o.Tests, v));
    /// <inheritdoc cref="VSTestSettings.Tests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Tests))]
    public static T ClearTests<T>(this T o) where T : VSTestSettings => o.Modify(b => b.ClearCollection(() => o.Tests));
    #endregion
    #region Parallel
    /// <inheritdoc cref="VSTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Parallel))]
    public static T SetParallel<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="VSTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.Parallel));
    /// <inheritdoc cref="VSTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Parallel))]
    public static T EnableParallel<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Parallel, true));
    /// <inheritdoc cref="VSTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Parallel))]
    public static T DisableParallel<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Parallel, false));
    /// <inheritdoc cref="VSTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Parallel))]
    public static T ToggleParallel<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Parallel, !o.Parallel));
    #endregion
    #region EnableCodeCoverage
    /// <inheritdoc cref="VSTestSettings.EnableCodeCoverage"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.EnableCodeCoverage))]
    public static T SetEnableCodeCoverage<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.EnableCodeCoverage, v));
    /// <inheritdoc cref="VSTestSettings.EnableCodeCoverage"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.EnableCodeCoverage))]
    public static T ResetEnableCodeCoverage<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.EnableCodeCoverage));
    /// <inheritdoc cref="VSTestSettings.EnableCodeCoverage"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.EnableCodeCoverage))]
    public static T EnableEnableCodeCoverage<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.EnableCodeCoverage, true));
    /// <inheritdoc cref="VSTestSettings.EnableCodeCoverage"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.EnableCodeCoverage))]
    public static T DisableEnableCodeCoverage<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.EnableCodeCoverage, false));
    /// <inheritdoc cref="VSTestSettings.EnableCodeCoverage"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.EnableCodeCoverage))]
    public static T ToggleEnableCodeCoverage<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.EnableCodeCoverage, !o.EnableCodeCoverage));
    #endregion
    #region InIsolation
    /// <inheritdoc cref="VSTestSettings.InIsolation"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.InIsolation))]
    public static T SetInIsolation<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.InIsolation, v));
    /// <inheritdoc cref="VSTestSettings.InIsolation"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.InIsolation))]
    public static T ResetInIsolation<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.InIsolation));
    /// <inheritdoc cref="VSTestSettings.InIsolation"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.InIsolation))]
    public static T EnableInIsolation<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.InIsolation, true));
    /// <inheritdoc cref="VSTestSettings.InIsolation"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.InIsolation))]
    public static T DisableInIsolation<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.InIsolation, false));
    /// <inheritdoc cref="VSTestSettings.InIsolation"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.InIsolation))]
    public static T ToggleInIsolation<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.InIsolation, !o.InIsolation));
    #endregion
    #region UseVsixExtensions
    /// <inheritdoc cref="VSTestSettings.UseVsixExtensions"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.UseVsixExtensions))]
    public static T SetUseVsixExtensions<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.UseVsixExtensions, v));
    /// <inheritdoc cref="VSTestSettings.UseVsixExtensions"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.UseVsixExtensions))]
    public static T ResetUseVsixExtensions<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.UseVsixExtensions));
    /// <inheritdoc cref="VSTestSettings.UseVsixExtensions"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.UseVsixExtensions))]
    public static T EnableUseVsixExtensions<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.UseVsixExtensions, true));
    /// <inheritdoc cref="VSTestSettings.UseVsixExtensions"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.UseVsixExtensions))]
    public static T DisableUseVsixExtensions<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.UseVsixExtensions, false));
    /// <inheritdoc cref="VSTestSettings.UseVsixExtensions"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.UseVsixExtensions))]
    public static T ToggleUseVsixExtensions<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.UseVsixExtensions, !o.UseVsixExtensions));
    #endregion
    #region TestAdapterPath
    /// <inheritdoc cref="VSTestSettings.TestAdapterPath"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAdapterPath))]
    public static T SetTestAdapterPath<T>(this T o, string v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.TestAdapterPath, v));
    /// <inheritdoc cref="VSTestSettings.TestAdapterPath"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestAdapterPath))]
    public static T ResetTestAdapterPath<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.TestAdapterPath));
    #endregion
    #region Platform
    /// <inheritdoc cref="VSTestSettings.Platform"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Platform))]
    public static T SetPlatform<T>(this T o, VsTestPlatform v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Platform, v));
    /// <inheritdoc cref="VSTestSettings.Platform"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Platform))]
    public static T ResetPlatform<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.Platform));
    #endregion
    #region Framework
    /// <inheritdoc cref="VSTestSettings.Framework"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Framework))]
    public static T SetFramework<T>(this T o, VsTestFramework v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Framework, v));
    /// <inheritdoc cref="VSTestSettings.Framework"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Framework))]
    public static T ResetFramework<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.Framework));
    #endregion
    #region TestCaseFilters
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T SetTestCaseFilters<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.TestCaseFilters, v));
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T SetTestCaseFilters<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.TestCaseFilters, v));
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T AddTestCaseFilters<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.AddCollection(() => o.TestCaseFilters, v));
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T AddTestCaseFilters<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.AddCollection(() => o.TestCaseFilters, v));
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T RemoveTestCaseFilters<T>(this T o, params string[] v) where T : VSTestSettings => o.Modify(b => b.RemoveCollection(() => o.TestCaseFilters, v));
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T RemoveTestCaseFilters<T>(this T o, IEnumerable<string> v) where T : VSTestSettings => o.Modify(b => b.RemoveCollection(() => o.TestCaseFilters, v));
    /// <inheritdoc cref="VSTestSettings.TestCaseFilters"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.TestCaseFilters))]
    public static T ClearTestCaseFilters<T>(this T o) where T : VSTestSettings => o.Modify(b => b.ClearCollection(() => o.TestCaseFilters));
    #endregion
    #region Logger
    /// <inheritdoc cref="VSTestSettings.Logger"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Logger))]
    public static T SetLogger<T>(this T o, string v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.Logger, v));
    /// <inheritdoc cref="VSTestSettings.Logger"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.Logger))]
    public static T ResetLogger<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.Logger));
    #endregion
    #region ListTests
    /// <inheritdoc cref="VSTestSettings.ListTests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListTests))]
    public static T SetListTests<T>(this T o, string v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListTests, v));
    /// <inheritdoc cref="VSTestSettings.ListTests"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListTests))]
    public static T ResetListTests<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.ListTests));
    #endregion
    #region ListDiscoverers
    /// <inheritdoc cref="VSTestSettings.ListDiscoverers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListDiscoverers))]
    public static T SetListDiscoverers<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListDiscoverers, v));
    /// <inheritdoc cref="VSTestSettings.ListDiscoverers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListDiscoverers))]
    public static T ResetListDiscoverers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.ListDiscoverers));
    /// <inheritdoc cref="VSTestSettings.ListDiscoverers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListDiscoverers))]
    public static T EnableListDiscoverers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListDiscoverers, true));
    /// <inheritdoc cref="VSTestSettings.ListDiscoverers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListDiscoverers))]
    public static T DisableListDiscoverers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListDiscoverers, false));
    /// <inheritdoc cref="VSTestSettings.ListDiscoverers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListDiscoverers))]
    public static T ToggleListDiscoverers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListDiscoverers, !o.ListDiscoverers));
    #endregion
    #region ListExecutors
    /// <inheritdoc cref="VSTestSettings.ListExecutors"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListExecutors))]
    public static T SetListExecutors<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListExecutors, v));
    /// <inheritdoc cref="VSTestSettings.ListExecutors"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListExecutors))]
    public static T ResetListExecutors<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.ListExecutors));
    /// <inheritdoc cref="VSTestSettings.ListExecutors"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListExecutors))]
    public static T EnableListExecutors<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListExecutors, true));
    /// <inheritdoc cref="VSTestSettings.ListExecutors"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListExecutors))]
    public static T DisableListExecutors<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListExecutors, false));
    /// <inheritdoc cref="VSTestSettings.ListExecutors"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListExecutors))]
    public static T ToggleListExecutors<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListExecutors, !o.ListExecutors));
    #endregion
    #region ListLoggers
    /// <inheritdoc cref="VSTestSettings.ListLoggers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListLoggers))]
    public static T SetListLoggers<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListLoggers, v));
    /// <inheritdoc cref="VSTestSettings.ListLoggers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListLoggers))]
    public static T ResetListLoggers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.ListLoggers));
    /// <inheritdoc cref="VSTestSettings.ListLoggers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListLoggers))]
    public static T EnableListLoggers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListLoggers, true));
    /// <inheritdoc cref="VSTestSettings.ListLoggers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListLoggers))]
    public static T DisableListLoggers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListLoggers, false));
    /// <inheritdoc cref="VSTestSettings.ListLoggers"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListLoggers))]
    public static T ToggleListLoggers<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListLoggers, !o.ListLoggers));
    #endregion
    #region ListSettingsProviders
    /// <inheritdoc cref="VSTestSettings.ListSettingsProviders"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListSettingsProviders))]
    public static T SetListSettingsProviders<T>(this T o, bool? v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListSettingsProviders, v));
    /// <inheritdoc cref="VSTestSettings.ListSettingsProviders"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListSettingsProviders))]
    public static T ResetListSettingsProviders<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.ListSettingsProviders));
    /// <inheritdoc cref="VSTestSettings.ListSettingsProviders"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListSettingsProviders))]
    public static T EnableListSettingsProviders<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListSettingsProviders, true));
    /// <inheritdoc cref="VSTestSettings.ListSettingsProviders"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListSettingsProviders))]
    public static T DisableListSettingsProviders<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListSettingsProviders, false));
    /// <inheritdoc cref="VSTestSettings.ListSettingsProviders"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.ListSettingsProviders))]
    public static T ToggleListSettingsProviders<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Set(() => o.ListSettingsProviders, !o.ListSettingsProviders));
    #endregion
    #region DiagnosticsFile
    /// <inheritdoc cref="VSTestSettings.DiagnosticsFile"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.DiagnosticsFile))]
    public static T SetDiagnosticsFile<T>(this T o, string v) where T : VSTestSettings => o.Modify(b => b.Set(() => o.DiagnosticsFile, v));
    /// <inheritdoc cref="VSTestSettings.DiagnosticsFile"/>
    [Pure] [Builder(Type = typeof(VSTestSettings), Property = nameof(VSTestSettings.DiagnosticsFile))]
    public static T ResetDiagnosticsFile<T>(this T o) where T : VSTestSettings => o.Modify(b => b.Remove(() => o.DiagnosticsFile));
    #endregion
}
#endregion
#region VsTestPlatform
/// <summary>Used within <see cref="VSTestTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<VsTestPlatform>))]
public partial class VsTestPlatform : Enumeration
{
    public static VsTestPlatform x86 = (VsTestPlatform) "x86";
    public static VsTestPlatform x64 = (VsTestPlatform) "x64";
    public static VsTestPlatform ARM = (VsTestPlatform) "ARM";
    public static implicit operator VsTestPlatform(string value)
    {
        return new VsTestPlatform { Value = value };
    }
}
#endregion
#region VsTestFramework
/// <summary>Used within <see cref="VSTestTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<VsTestFramework>))]
public partial class VsTestFramework : Enumeration
{
    public static VsTestFramework Framework35 = (VsTestFramework) "Framework35";
    public static VsTestFramework Framework40 = (VsTestFramework) "Framework40";
    public static VsTestFramework Framework45 = (VsTestFramework) "Framework45";
    public static implicit operator VsTestFramework(string value)
    {
        return new VsTestFramework { Value = value };
    }
}
#endregion
