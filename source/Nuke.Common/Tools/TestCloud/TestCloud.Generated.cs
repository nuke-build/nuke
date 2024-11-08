// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/TestCloud/TestCloud.json

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

namespace Nuke.Common.Tools.TestCloud;

/// <summary><p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p><p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class TestCloudTasks : ToolTasks, IRequireNuGetPackage
{
    public static string TestCloudPath => new TestCloudTasks().GetToolPath();
    public const string PackageId = "Xamarin.UITest";
    public const string PackageExecutable = "test-cloud.exe";
    /// <summary><p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p><p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> TestCloud(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new TestCloudTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p><p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assembly-dir</c> via <see cref="TestCloudSettings.AssemblyDirectory"/></li><li><c>--data</c> via <see cref="TestCloudSettings.DataPaths"/></li><li><c>--devices</c> via <see cref="TestCloudSettings.Devices"/></li><li><c>--dsym</c> via <see cref="TestCloudSettings.DsymFile"/></li><li><c>--exclude</c> via <see cref="TestCloudSettings.ExcludeCategories"/></li><li><c>--fixture</c> via <see cref="TestCloudSettings.Fixtures"/></li><li><c>--fixture-chunk</c> via <see cref="TestCloudSettings.FixtureChunk"/></li><li><c>--include</c> via <see cref="TestCloudSettings.IncludeCategories"/></li><li><c>--nunit-xml</c> via <see cref="TestCloudSettings.NunitResultsFile"/></li><li><c>--sign-info</c> via <see cref="TestCloudSettings.SignInfoFile"/></li><li><c>--test-chunk</c> via <see cref="TestCloudSettings.TestChunk"/></li><li><c>--user</c> via <see cref="TestCloudSettings.UserEmail"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> TestCloud(TestCloudSettings options = null) => new TestCloudTasks().Run(options);
    /// <summary><p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p><p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assembly-dir</c> via <see cref="TestCloudSettings.AssemblyDirectory"/></li><li><c>--data</c> via <see cref="TestCloudSettings.DataPaths"/></li><li><c>--devices</c> via <see cref="TestCloudSettings.Devices"/></li><li><c>--dsym</c> via <see cref="TestCloudSettings.DsymFile"/></li><li><c>--exclude</c> via <see cref="TestCloudSettings.ExcludeCategories"/></li><li><c>--fixture</c> via <see cref="TestCloudSettings.Fixtures"/></li><li><c>--fixture-chunk</c> via <see cref="TestCloudSettings.FixtureChunk"/></li><li><c>--include</c> via <see cref="TestCloudSettings.IncludeCategories"/></li><li><c>--nunit-xml</c> via <see cref="TestCloudSettings.NunitResultsFile"/></li><li><c>--sign-info</c> via <see cref="TestCloudSettings.SignInfoFile"/></li><li><c>--test-chunk</c> via <see cref="TestCloudSettings.TestChunk"/></li><li><c>--user</c> via <see cref="TestCloudSettings.UserEmail"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> TestCloud(Configure<TestCloudSettings> configurator) => new TestCloudTasks().Run(configurator.Invoke(new TestCloudSettings()));
    /// <summary><p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p><p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assembly-dir</c> via <see cref="TestCloudSettings.AssemblyDirectory"/></li><li><c>--data</c> via <see cref="TestCloudSettings.DataPaths"/></li><li><c>--devices</c> via <see cref="TestCloudSettings.Devices"/></li><li><c>--dsym</c> via <see cref="TestCloudSettings.DsymFile"/></li><li><c>--exclude</c> via <see cref="TestCloudSettings.ExcludeCategories"/></li><li><c>--fixture</c> via <see cref="TestCloudSettings.Fixtures"/></li><li><c>--fixture-chunk</c> via <see cref="TestCloudSettings.FixtureChunk"/></li><li><c>--include</c> via <see cref="TestCloudSettings.IncludeCategories"/></li><li><c>--nunit-xml</c> via <see cref="TestCloudSettings.NunitResultsFile"/></li><li><c>--sign-info</c> via <see cref="TestCloudSettings.SignInfoFile"/></li><li><c>--test-chunk</c> via <see cref="TestCloudSettings.TestChunk"/></li><li><c>--user</c> via <see cref="TestCloudSettings.UserEmail"/></li></ul></remarks>
    public static IEnumerable<(TestCloudSettings Settings, IReadOnlyCollection<Output> Output)> TestCloud(CombinatorialConfigure<TestCloudSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(TestCloud, degreeOfParallelism, completeOnFailure);
}
#region TestCloudSettings
/// <summary>Used within <see cref="TestCloudTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<TestCloudSettings>))]
[Command(Type = typeof(TestCloudTasks), Command = nameof(TestCloudTasks.TestCloud), Arguments = "submit")]
public partial class TestCloudSettings : ToolOptions
{
    /// <summary>The path to the folder holding the test assemblies.</summary>
    [Argument(Format = "--assembly-dir {value}")] public string AssemblyDirectory => Get<string>(() => AssemblyDirectory);
    /// <summary>The device ID that was provided in the Test Cloud Upload dialog.</summary>
    [Argument(Format = "--devices {value}")] public string Devices => Get<string>(() => Devices);
    /// <summary>The e-mail address of the team member submitting the tests.</summary>
    [Argument(Format = "--user {value}")] public string UserEmail => Get<string>(() => UserEmail);
    /// <summary>The filename to which test results are exported, formatted as NUnit results XML. Optional.</summary>
    [Argument(Format = "--nunit-xml {value}")] public string NunitResultsFile => Get<string>(() => NunitResultsFile);
    /// <summary>Android only. Supply a signing information file that will be used to sign the Test Server APK. See the section below for more details. Optional.</summary>
    [Argument(Format = "--sign-info {value}")] public string SignInfoFile => Get<string>(() => SignInfoFile);
    /// <summary>iOS only. Will upload the dSYM files along with the application and tests. This allows for more detail in the log files. Optional.</summary>
    [Argument(Format = "--dsym {value}")] public string DsymFile => Get<string>(() => DsymFile);
    /// <summary>NUnit fixture / namespace to run. (Can be used multiple times).</summary>
    [Argument(Format = "--fixture {value}")] public IReadOnlyList<string> Fixtures => Get<List<string>>(() => Fixtures);
    /// <summary>Identifies the NUnit test categories that should only be included in the test run.</summary>
    [Argument(Format = "--include {value}")] public IReadOnlyList<string> IncludeCategories => Get<List<string>>(() => IncludeCategories);
    /// <summary>Identifies the NUnit test categories that should be excluded from the test run.</summary>
    [Argument(Format = "--exclude {value}")] public IReadOnlyList<string> ExcludeCategories => Get<List<string>>(() => ExcludeCategories);
    /// <summary>Run tests in parallel by method.</summary>
    [Argument(Format = "--test-chunk")] public bool? TestChunk => Get<bool?>(() => TestChunk);
    /// <summary>Run tests in parallel by fixture.</summary>
    [Argument(Format = "--fixture-chunk")] public bool? FixtureChunk => Get<bool?>(() => FixtureChunk);
    /// <summary>Uploads file or directory along with assemblies. (Can be used multiple times).</summary>
    [Argument(Format = "--data {value}")] public IReadOnlyList<string> DataPaths => Get<List<string>>(() => DataPaths);
}
#endregion
#region TestCloudSettingsExtensions
/// <summary>Used within <see cref="TestCloudTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class TestCloudSettingsExtensions
{
    #region AssemblyDirectory
    /// <inheritdoc cref="TestCloudSettings.AssemblyDirectory"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.AssemblyDirectory))]
    public static T SetAssemblyDirectory<T>(this T o, string v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.AssemblyDirectory, v));
    /// <inheritdoc cref="TestCloudSettings.AssemblyDirectory"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.AssemblyDirectory))]
    public static T ResetAssemblyDirectory<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.AssemblyDirectory));
    #endregion
    #region Devices
    /// <inheritdoc cref="TestCloudSettings.Devices"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Devices))]
    public static T SetDevices<T>(this T o, string v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.Devices, v));
    /// <inheritdoc cref="TestCloudSettings.Devices"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Devices))]
    public static T ResetDevices<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.Devices));
    #endregion
    #region UserEmail
    /// <inheritdoc cref="TestCloudSettings.UserEmail"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.UserEmail))]
    public static T SetUserEmail<T>(this T o, string v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.UserEmail, v));
    /// <inheritdoc cref="TestCloudSettings.UserEmail"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.UserEmail))]
    public static T ResetUserEmail<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.UserEmail));
    #endregion
    #region NunitResultsFile
    /// <inheritdoc cref="TestCloudSettings.NunitResultsFile"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.NunitResultsFile))]
    public static T SetNunitResultsFile<T>(this T o, string v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.NunitResultsFile, v));
    /// <inheritdoc cref="TestCloudSettings.NunitResultsFile"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.NunitResultsFile))]
    public static T ResetNunitResultsFile<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.NunitResultsFile));
    #endregion
    #region SignInfoFile
    /// <inheritdoc cref="TestCloudSettings.SignInfoFile"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.SignInfoFile))]
    public static T SetSignInfoFile<T>(this T o, string v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.SignInfoFile, v));
    /// <inheritdoc cref="TestCloudSettings.SignInfoFile"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.SignInfoFile))]
    public static T ResetSignInfoFile<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.SignInfoFile));
    #endregion
    #region DsymFile
    /// <inheritdoc cref="TestCloudSettings.DsymFile"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DsymFile))]
    public static T SetDsymFile<T>(this T o, string v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.DsymFile, v));
    /// <inheritdoc cref="TestCloudSettings.DsymFile"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DsymFile))]
    public static T ResetDsymFile<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.DsymFile));
    #endregion
    #region Fixtures
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T SetFixtures<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.Fixtures, v));
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T SetFixtures<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.Fixtures, v));
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T AddFixtures<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.Fixtures, v));
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T AddFixtures<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.Fixtures, v));
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T RemoveFixtures<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.Fixtures, v));
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T RemoveFixtures<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.Fixtures, v));
    /// <inheritdoc cref="TestCloudSettings.Fixtures"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.Fixtures))]
    public static T ClearFixtures<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.ClearCollection(() => o.Fixtures));
    #endregion
    #region IncludeCategories
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T SetIncludeCategories<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.IncludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T SetIncludeCategories<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.IncludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T AddIncludeCategories<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.IncludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T AddIncludeCategories<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.IncludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T RemoveIncludeCategories<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.IncludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T RemoveIncludeCategories<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.IncludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.IncludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.IncludeCategories))]
    public static T ClearIncludeCategories<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.ClearCollection(() => o.IncludeCategories));
    #endregion
    #region ExcludeCategories
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T SetExcludeCategories<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.ExcludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T SetExcludeCategories<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.ExcludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T AddExcludeCategories<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.ExcludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T AddExcludeCategories<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.ExcludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T RemoveExcludeCategories<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T RemoveExcludeCategories<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeCategories, v));
    /// <inheritdoc cref="TestCloudSettings.ExcludeCategories"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.ExcludeCategories))]
    public static T ClearExcludeCategories<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeCategories));
    #endregion
    #region TestChunk
    /// <inheritdoc cref="TestCloudSettings.TestChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.TestChunk))]
    public static T SetTestChunk<T>(this T o, bool? v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.TestChunk, v));
    /// <inheritdoc cref="TestCloudSettings.TestChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.TestChunk))]
    public static T ResetTestChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.TestChunk));
    /// <inheritdoc cref="TestCloudSettings.TestChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.TestChunk))]
    public static T EnableTestChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.TestChunk, true));
    /// <inheritdoc cref="TestCloudSettings.TestChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.TestChunk))]
    public static T DisableTestChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.TestChunk, false));
    /// <inheritdoc cref="TestCloudSettings.TestChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.TestChunk))]
    public static T ToggleTestChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.TestChunk, !o.TestChunk));
    #endregion
    #region FixtureChunk
    /// <inheritdoc cref="TestCloudSettings.FixtureChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.FixtureChunk))]
    public static T SetFixtureChunk<T>(this T o, bool? v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.FixtureChunk, v));
    /// <inheritdoc cref="TestCloudSettings.FixtureChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.FixtureChunk))]
    public static T ResetFixtureChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Remove(() => o.FixtureChunk));
    /// <inheritdoc cref="TestCloudSettings.FixtureChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.FixtureChunk))]
    public static T EnableFixtureChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.FixtureChunk, true));
    /// <inheritdoc cref="TestCloudSettings.FixtureChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.FixtureChunk))]
    public static T DisableFixtureChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.FixtureChunk, false));
    /// <inheritdoc cref="TestCloudSettings.FixtureChunk"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.FixtureChunk))]
    public static T ToggleFixtureChunk<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.FixtureChunk, !o.FixtureChunk));
    #endregion
    #region DataPaths
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T SetDataPaths<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.DataPaths, v));
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T SetDataPaths<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.Set(() => o.DataPaths, v));
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T AddDataPaths<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.DataPaths, v));
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T AddDataPaths<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.AddCollection(() => o.DataPaths, v));
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T RemoveDataPaths<T>(this T o, params string[] v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.DataPaths, v));
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T RemoveDataPaths<T>(this T o, IEnumerable<string> v) where T : TestCloudSettings => o.Modify(b => b.RemoveCollection(() => o.DataPaths, v));
    /// <inheritdoc cref="TestCloudSettings.DataPaths"/>
    [Pure] [Builder(Type = typeof(TestCloudSettings), Property = nameof(TestCloudSettings.DataPaths))]
    public static T ClearDataPaths<T>(this T o) where T : TestCloudSettings => o.Modify(b => b.ClearCollection(() => o.DataPaths));
    #endregion
}
#endregion
