// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/TestCloud.json
// Generated with Nuke.CodeGeneration version LOCAL (Windows,.NETStandard,Version=v2.0)

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

namespace Nuke.Common.Tools.TestCloud
{
    /// <summary>
    ///   <p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p>
    ///   <p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TestCloudTasks
    {
        /// <summary>
        ///   Path to the TestCloud executable.
        /// </summary>
        public static string TestCloudPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("TESTCLOUD_EXE") ??
            ToolPathResolver.GetPackageExecutable("Xamarin.UITest", "test-cloud.exe");
        public static Action<OutputType, string> TestCloudLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p>
        ///   <p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> TestCloud(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(TestCloudPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, TestCloudLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p>
        ///   <p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assembly-dir</c> via <see cref="TestCloudSettings.AssemblyDirectory"/></li>
        ///     <li><c>--data</c> via <see cref="TestCloudSettings.DataPaths"/></li>
        ///     <li><c>--devices</c> via <see cref="TestCloudSettings.Devices"/></li>
        ///     <li><c>--dsym</c> via <see cref="TestCloudSettings.DsymFile"/></li>
        ///     <li><c>--exclude</c> via <see cref="TestCloudSettings.ExcludeCategories"/></li>
        ///     <li><c>--fixture</c> via <see cref="TestCloudSettings.Fixtures"/></li>
        ///     <li><c>--fixture-chunk</c> via <see cref="TestCloudSettings.FixtureChunk"/></li>
        ///     <li><c>--include</c> via <see cref="TestCloudSettings.IncludeCategories"/></li>
        ///     <li><c>--nunit-xml</c> via <see cref="TestCloudSettings.NunitResultsFile"/></li>
        ///     <li><c>--sign-info</c> via <see cref="TestCloudSettings.SignInfoFile"/></li>
        ///     <li><c>--test-chunk</c> via <see cref="TestCloudSettings.TestChunk"/></li>
        ///     <li><c>--user</c> via <see cref="TestCloudSettings.UserEmail"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TestCloud(TestCloudSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TestCloudSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p>
        ///   <p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assembly-dir</c> via <see cref="TestCloudSettings.AssemblyDirectory"/></li>
        ///     <li><c>--data</c> via <see cref="TestCloudSettings.DataPaths"/></li>
        ///     <li><c>--devices</c> via <see cref="TestCloudSettings.Devices"/></li>
        ///     <li><c>--dsym</c> via <see cref="TestCloudSettings.DsymFile"/></li>
        ///     <li><c>--exclude</c> via <see cref="TestCloudSettings.ExcludeCategories"/></li>
        ///     <li><c>--fixture</c> via <see cref="TestCloudSettings.Fixtures"/></li>
        ///     <li><c>--fixture-chunk</c> via <see cref="TestCloudSettings.FixtureChunk"/></li>
        ///     <li><c>--include</c> via <see cref="TestCloudSettings.IncludeCategories"/></li>
        ///     <li><c>--nunit-xml</c> via <see cref="TestCloudSettings.NunitResultsFile"/></li>
        ///     <li><c>--sign-info</c> via <see cref="TestCloudSettings.SignInfoFile"/></li>
        ///     <li><c>--test-chunk</c> via <see cref="TestCloudSettings.TestChunk"/></li>
        ///     <li><c>--user</c> via <see cref="TestCloudSettings.UserEmail"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TestCloud(Configure<TestCloudSettings> configurator)
        {
            return TestCloud(configurator(new TestCloudSettings()));
        }
        /// <summary>
        ///   <p>Test Cloud is a cloud based service consisting of thousands of physical mobile devices. Users upload their apps and tests to Test Cloud, which will install the apps on the devices and run the tests. When the tests are complete, Test Cloud, the results made available to users through an easy to use and informative web-based front end.</p>
        ///   <p>For more details, visit the <a href="https://developer.xamarin.com/guides/testcloud/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assembly-dir</c> via <see cref="TestCloudSettings.AssemblyDirectory"/></li>
        ///     <li><c>--data</c> via <see cref="TestCloudSettings.DataPaths"/></li>
        ///     <li><c>--devices</c> via <see cref="TestCloudSettings.Devices"/></li>
        ///     <li><c>--dsym</c> via <see cref="TestCloudSettings.DsymFile"/></li>
        ///     <li><c>--exclude</c> via <see cref="TestCloudSettings.ExcludeCategories"/></li>
        ///     <li><c>--fixture</c> via <see cref="TestCloudSettings.Fixtures"/></li>
        ///     <li><c>--fixture-chunk</c> via <see cref="TestCloudSettings.FixtureChunk"/></li>
        ///     <li><c>--include</c> via <see cref="TestCloudSettings.IncludeCategories"/></li>
        ///     <li><c>--nunit-xml</c> via <see cref="TestCloudSettings.NunitResultsFile"/></li>
        ///     <li><c>--sign-info</c> via <see cref="TestCloudSettings.SignInfoFile"/></li>
        ///     <li><c>--test-chunk</c> via <see cref="TestCloudSettings.TestChunk"/></li>
        ///     <li><c>--user</c> via <see cref="TestCloudSettings.UserEmail"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TestCloudSettings Settings, IReadOnlyCollection<Output> Output)> TestCloud(CombinatorialConfigure<TestCloudSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TestCloud, TestCloudLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region TestCloudSettings
    /// <summary>
    ///   Used within <see cref="TestCloudTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TestCloudSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the TestCloud executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? TestCloudTasks.TestCloudPath;
        public override Action<OutputType, string> CustomLogger => TestCloudTasks.TestCloudLogger;
        /// <summary>
        ///   The path to the folder holding the test assemblies.
        /// </summary>
        public virtual string AssemblyDirectory { get; internal set; }
        /// <summary>
        ///   The device ID that was provided in the Test Cloud Upload dialog.
        /// </summary>
        public virtual string Devices { get; internal set; }
        /// <summary>
        ///   The e-mail address of the team member submitting the tests.
        /// </summary>
        public virtual string UserEmail { get; internal set; }
        /// <summary>
        ///   The filename to which test results are exported, formatted as NUnit results XML. Optional.
        /// </summary>
        public virtual string NunitResultsFile { get; internal set; }
        /// <summary>
        ///   Android only. Supply a signing information file that will be used to sign the Test Server APK. See the section below for more details. Optional.
        /// </summary>
        public virtual string SignInfoFile { get; internal set; }
        /// <summary>
        ///   iOS only. Will upload the dSYM files along with the application and tests. This allows for more detail in the log files. Optional.
        /// </summary>
        public virtual string DsymFile { get; internal set; }
        /// <summary>
        ///   NUnit fixture / namespace to run. (Can be used multiple times).
        /// </summary>
        public virtual IReadOnlyList<string> Fixtures => FixturesInternal.AsReadOnly();
        internal List<string> FixturesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Identifies the NUnit test categories that should only be included in the test run.
        /// </summary>
        public virtual IReadOnlyList<string> IncludeCategories => IncludeCategoriesInternal.AsReadOnly();
        internal List<string> IncludeCategoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Identifies the NUnit test categories that should be excluded from the test run.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeCategories => ExcludeCategoriesInternal.AsReadOnly();
        internal List<string> ExcludeCategoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Run tests in parallel by method.
        /// </summary>
        public virtual bool? TestChunk { get; internal set; }
        /// <summary>
        ///   Run tests in parallel by fixture.
        /// </summary>
        public virtual bool? FixtureChunk { get; internal set; }
        /// <summary>
        ///   Uploads file or directory along with assemblies. (Can be used multiple times).
        /// </summary>
        public virtual IReadOnlyList<string> DataPaths => DataPathsInternal.AsReadOnly();
        internal List<string> DataPathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("submit")
              .Add("--assembly-dir {value}", AssemblyDirectory)
              .Add("--devices {value}", Devices)
              .Add("--user {value}", UserEmail)
              .Add("--nunit-xml {value}", NunitResultsFile)
              .Add("--sign-info {value}", SignInfoFile)
              .Add("--dsym {value}", DsymFile)
              .Add("--fixture {value}", Fixtures)
              .Add("--include {value}", IncludeCategories)
              .Add("--exclude {value}", ExcludeCategories)
              .Add("--test-chunk", TestChunk)
              .Add("--fixture-chunk", FixtureChunk)
              .Add("--data {value}", DataPaths);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region TestCloudSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TestCloudTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TestCloudSettingsExtensions
    {
        #region AssemblyDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.AssemblyDirectory"/></em></p>
        ///   <p>The path to the folder holding the test assemblies.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetAssemblyDirectory(this TestCloudSettings toolSettings, string assemblyDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyDirectory = assemblyDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.AssemblyDirectory"/></em></p>
        ///   <p>The path to the folder holding the test assemblies.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetAssemblyDirectory(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Devices
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.Devices"/></em></p>
        ///   <p>The device ID that was provided in the Test Cloud Upload dialog.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetDevices(this TestCloudSettings toolSettings, string devices)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devices = devices;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.Devices"/></em></p>
        ///   <p>The device ID that was provided in the Test Cloud Upload dialog.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetDevices(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devices = null;
            return toolSettings;
        }
        #endregion
        #region UserEmail
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.UserEmail"/></em></p>
        ///   <p>The e-mail address of the team member submitting the tests.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetUserEmail(this TestCloudSettings toolSettings, string userEmail)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserEmail = userEmail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.UserEmail"/></em></p>
        ///   <p>The e-mail address of the team member submitting the tests.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetUserEmail(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserEmail = null;
            return toolSettings;
        }
        #endregion
        #region NunitResultsFile
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.NunitResultsFile"/></em></p>
        ///   <p>The filename to which test results are exported, formatted as NUnit results XML. Optional.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetNunitResultsFile(this TestCloudSettings toolSettings, string nunitResultsFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NunitResultsFile = nunitResultsFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.NunitResultsFile"/></em></p>
        ///   <p>The filename to which test results are exported, formatted as NUnit results XML. Optional.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetNunitResultsFile(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NunitResultsFile = null;
            return toolSettings;
        }
        #endregion
        #region SignInfoFile
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.SignInfoFile"/></em></p>
        ///   <p>Android only. Supply a signing information file that will be used to sign the Test Server APK. See the section below for more details. Optional.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetSignInfoFile(this TestCloudSettings toolSettings, string signInfoFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignInfoFile = signInfoFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.SignInfoFile"/></em></p>
        ///   <p>Android only. Supply a signing information file that will be used to sign the Test Server APK. See the section below for more details. Optional.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetSignInfoFile(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignInfoFile = null;
            return toolSettings;
        }
        #endregion
        #region DsymFile
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.DsymFile"/></em></p>
        ///   <p>iOS only. Will upload the dSYM files along with the application and tests. This allows for more detail in the log files. Optional.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetDsymFile(this TestCloudSettings toolSettings, string dsymFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DsymFile = dsymFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.DsymFile"/></em></p>
        ///   <p>iOS only. Will upload the dSYM files along with the application and tests. This allows for more detail in the log files. Optional.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetDsymFile(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DsymFile = null;
            return toolSettings;
        }
        #endregion
        #region Fixtures
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.Fixtures"/> to a new list</em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetFixtures(this TestCloudSettings toolSettings, params string[] fixtures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixturesInternal = fixtures.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.Fixtures"/> to a new list</em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetFixtures(this TestCloudSettings toolSettings, IEnumerable<string> fixtures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixturesInternal = fixtures.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.Fixtures"/></em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddFixtures(this TestCloudSettings toolSettings, params string[] fixtures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixturesInternal.AddRange(fixtures);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.Fixtures"/></em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddFixtures(this TestCloudSettings toolSettings, IEnumerable<string> fixtures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixturesInternal.AddRange(fixtures);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="TestCloudSettings.Fixtures"/></em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ClearFixtures(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixturesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.Fixtures"/></em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveFixtures(this TestCloudSettings toolSettings, params string[] fixtures)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fixtures);
            toolSettings.FixturesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.Fixtures"/></em></p>
        ///   <p>NUnit fixture / namespace to run. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveFixtures(this TestCloudSettings toolSettings, IEnumerable<string> fixtures)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fixtures);
            toolSettings.FixturesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region IncludeCategories
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.IncludeCategories"/> to a new list</em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetIncludeCategories(this TestCloudSettings toolSettings, params string[] includeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCategoriesInternal = includeCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.IncludeCategories"/> to a new list</em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetIncludeCategories(this TestCloudSettings toolSettings, IEnumerable<string> includeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCategoriesInternal = includeCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.IncludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddIncludeCategories(this TestCloudSettings toolSettings, params string[] includeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCategoriesInternal.AddRange(includeCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.IncludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddIncludeCategories(this TestCloudSettings toolSettings, IEnumerable<string> includeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCategoriesInternal.AddRange(includeCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="TestCloudSettings.IncludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ClearIncludeCategories(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCategoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.IncludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveIncludeCategories(this TestCloudSettings toolSettings, params string[] includeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(includeCategories);
            toolSettings.IncludeCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.IncludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should only be included in the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveIncludeCategories(this TestCloudSettings toolSettings, IEnumerable<string> includeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(includeCategories);
            toolSettings.IncludeCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeCategories
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.ExcludeCategories"/> to a new list</em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetExcludeCategories(this TestCloudSettings toolSettings, params string[] excludeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCategoriesInternal = excludeCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.ExcludeCategories"/> to a new list</em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetExcludeCategories(this TestCloudSettings toolSettings, IEnumerable<string> excludeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCategoriesInternal = excludeCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.ExcludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddExcludeCategories(this TestCloudSettings toolSettings, params string[] excludeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCategoriesInternal.AddRange(excludeCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.ExcludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddExcludeCategories(this TestCloudSettings toolSettings, IEnumerable<string> excludeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCategoriesInternal.AddRange(excludeCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="TestCloudSettings.ExcludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ClearExcludeCategories(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCategoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.ExcludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveExcludeCategories(this TestCloudSettings toolSettings, params string[] excludeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeCategories);
            toolSettings.ExcludeCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.ExcludeCategories"/></em></p>
        ///   <p>Identifies the NUnit test categories that should be excluded from the test run.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveExcludeCategories(this TestCloudSettings toolSettings, IEnumerable<string> excludeCategories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeCategories);
            toolSettings.ExcludeCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TestChunk
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.TestChunk"/></em></p>
        ///   <p>Run tests in parallel by method.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetTestChunk(this TestCloudSettings toolSettings, bool? testChunk)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestChunk = testChunk;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.TestChunk"/></em></p>
        ///   <p>Run tests in parallel by method.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetTestChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestChunk = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TestCloudSettings.TestChunk"/></em></p>
        ///   <p>Run tests in parallel by method.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings EnableTestChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestChunk = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TestCloudSettings.TestChunk"/></em></p>
        ///   <p>Run tests in parallel by method.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings DisableTestChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestChunk = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TestCloudSettings.TestChunk"/></em></p>
        ///   <p>Run tests in parallel by method.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ToggleTestChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestChunk = !toolSettings.TestChunk;
            return toolSettings;
        }
        #endregion
        #region FixtureChunk
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.FixtureChunk"/></em></p>
        ///   <p>Run tests in parallel by fixture.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetFixtureChunk(this TestCloudSettings toolSettings, bool? fixtureChunk)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixtureChunk = fixtureChunk;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TestCloudSettings.FixtureChunk"/></em></p>
        ///   <p>Run tests in parallel by fixture.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ResetFixtureChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixtureChunk = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TestCloudSettings.FixtureChunk"/></em></p>
        ///   <p>Run tests in parallel by fixture.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings EnableFixtureChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixtureChunk = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TestCloudSettings.FixtureChunk"/></em></p>
        ///   <p>Run tests in parallel by fixture.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings DisableFixtureChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixtureChunk = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TestCloudSettings.FixtureChunk"/></em></p>
        ///   <p>Run tests in parallel by fixture.</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ToggleFixtureChunk(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FixtureChunk = !toolSettings.FixtureChunk;
            return toolSettings;
        }
        #endregion
        #region DataPaths
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.DataPaths"/> to a new list</em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetDataPaths(this TestCloudSettings toolSettings, params string[] dataPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataPathsInternal = dataPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="TestCloudSettings.DataPaths"/> to a new list</em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings SetDataPaths(this TestCloudSettings toolSettings, IEnumerable<string> dataPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataPathsInternal = dataPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.DataPaths"/></em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddDataPaths(this TestCloudSettings toolSettings, params string[] dataPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataPathsInternal.AddRange(dataPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="TestCloudSettings.DataPaths"/></em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings AddDataPaths(this TestCloudSettings toolSettings, IEnumerable<string> dataPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataPathsInternal.AddRange(dataPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="TestCloudSettings.DataPaths"/></em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings ClearDataPaths(this TestCloudSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.DataPaths"/></em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveDataPaths(this TestCloudSettings toolSettings, params string[] dataPaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(dataPaths);
            toolSettings.DataPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="TestCloudSettings.DataPaths"/></em></p>
        ///   <p>Uploads file or directory along with assemblies. (Can be used multiple times).</p>
        /// </summary>
        [Pure]
        public static TestCloudSettings RemoveDataPaths(this TestCloudSettings toolSettings, IEnumerable<string> dataPaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(dataPaths);
            toolSettings.DataPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
