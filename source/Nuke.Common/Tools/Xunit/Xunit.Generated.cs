// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Xunit/Xunit.json

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

namespace Nuke.Common.Tools.Xunit
{
    /// <summary>
    ///   <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
    ///   <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(XunitPackageId)]
    public partial class XunitTasks
        : IRequireNuGetPackage
    {
        public const string XunitPackageId = "xunit.runner.console";
        /// <summary>
        ///   Path to the Xunit executable.
        /// </summary>
        public static string XunitPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("XUNIT_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> XunitLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
        ///   <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Xunit(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(XunitPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? XunitLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
        ///   <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetAssemblyWithConfigs&gt;</c> via <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></li>
        ///     <li><c>-</c> via <see cref="Xunit2Settings.Reporter"/></li>
        ///     <li><c>-</c> via <see cref="Xunit2Settings.ResultReports"/></li>
        ///     <li><c>-appdomains</c> via <see cref="Xunit2Settings.AppDomainMode"/></li>
        ///     <li><c>-class</c> via <see cref="Xunit2Settings.Classes"/></li>
        ///     <li><c>-debug</c> via <see cref="Xunit2Settings.Debug"/></li>
        ///     <li><c>-diagnostics</c> via <see cref="Xunit2Settings.Diagnostics"/></li>
        ///     <li><c>-failskips</c> via <see cref="Xunit2Settings.FailSkips"/></li>
        ///     <li><c>-maxthreads</c> via <see cref="Xunit2Settings.MaxThreads"/></li>
        ///     <li><c>-method</c> via <see cref="Xunit2Settings.Methods"/></li>
        ///     <li><c>-namespace</c> via <see cref="Xunit2Settings.Namespaces"/></li>
        ///     <li><c>-noautoreporters</c> via <see cref="Xunit2Settings.NoAutoReporters"/></li>
        ///     <li><c>-nocolor</c> via <see cref="Xunit2Settings.NoColor"/></li>
        ///     <li><c>-nologo</c> via <see cref="Xunit2Settings.NoLogo"/></li>
        ///     <li><c>-noshadow</c> via <see cref="Xunit2Settings.NoShadowCopying"/></li>
        ///     <li><c>-notrait</c> via <see cref="Xunit2Settings.ExcludedTraits"/></li>
        ///     <li><c>-parallel</c> via <see cref="Xunit2Settings.Parallel"/></li>
        ///     <li><c>-pause</c> via <see cref="Xunit2Settings.Pause"/></li>
        ///     <li><c>-serialize</c> via <see cref="Xunit2Settings.Serialization"/></li>
        ///     <li><c>-stoponfail</c> via <see cref="Xunit2Settings.StopOnFail"/></li>
        ///     <li><c>-trait</c> via <see cref="Xunit2Settings.Traits"/></li>
        ///     <li><c>-wait</c> via <see cref="Xunit2Settings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Xunit2(Xunit2Settings toolSettings = null)
        {
            toolSettings = toolSettings ?? new Xunit2Settings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            AssertProcess(process, toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
        ///   <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetAssemblyWithConfigs&gt;</c> via <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></li>
        ///     <li><c>-</c> via <see cref="Xunit2Settings.Reporter"/></li>
        ///     <li><c>-</c> via <see cref="Xunit2Settings.ResultReports"/></li>
        ///     <li><c>-appdomains</c> via <see cref="Xunit2Settings.AppDomainMode"/></li>
        ///     <li><c>-class</c> via <see cref="Xunit2Settings.Classes"/></li>
        ///     <li><c>-debug</c> via <see cref="Xunit2Settings.Debug"/></li>
        ///     <li><c>-diagnostics</c> via <see cref="Xunit2Settings.Diagnostics"/></li>
        ///     <li><c>-failskips</c> via <see cref="Xunit2Settings.FailSkips"/></li>
        ///     <li><c>-maxthreads</c> via <see cref="Xunit2Settings.MaxThreads"/></li>
        ///     <li><c>-method</c> via <see cref="Xunit2Settings.Methods"/></li>
        ///     <li><c>-namespace</c> via <see cref="Xunit2Settings.Namespaces"/></li>
        ///     <li><c>-noautoreporters</c> via <see cref="Xunit2Settings.NoAutoReporters"/></li>
        ///     <li><c>-nocolor</c> via <see cref="Xunit2Settings.NoColor"/></li>
        ///     <li><c>-nologo</c> via <see cref="Xunit2Settings.NoLogo"/></li>
        ///     <li><c>-noshadow</c> via <see cref="Xunit2Settings.NoShadowCopying"/></li>
        ///     <li><c>-notrait</c> via <see cref="Xunit2Settings.ExcludedTraits"/></li>
        ///     <li><c>-parallel</c> via <see cref="Xunit2Settings.Parallel"/></li>
        ///     <li><c>-pause</c> via <see cref="Xunit2Settings.Pause"/></li>
        ///     <li><c>-serialize</c> via <see cref="Xunit2Settings.Serialization"/></li>
        ///     <li><c>-stoponfail</c> via <see cref="Xunit2Settings.StopOnFail"/></li>
        ///     <li><c>-trait</c> via <see cref="Xunit2Settings.Traits"/></li>
        ///     <li><c>-wait</c> via <see cref="Xunit2Settings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Xunit2(Configure<Xunit2Settings> configurator)
        {
            return Xunit2(configurator(new Xunit2Settings()));
        }
        /// <summary>
        ///   <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
        ///   <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetAssemblyWithConfigs&gt;</c> via <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></li>
        ///     <li><c>-</c> via <see cref="Xunit2Settings.Reporter"/></li>
        ///     <li><c>-</c> via <see cref="Xunit2Settings.ResultReports"/></li>
        ///     <li><c>-appdomains</c> via <see cref="Xunit2Settings.AppDomainMode"/></li>
        ///     <li><c>-class</c> via <see cref="Xunit2Settings.Classes"/></li>
        ///     <li><c>-debug</c> via <see cref="Xunit2Settings.Debug"/></li>
        ///     <li><c>-diagnostics</c> via <see cref="Xunit2Settings.Diagnostics"/></li>
        ///     <li><c>-failskips</c> via <see cref="Xunit2Settings.FailSkips"/></li>
        ///     <li><c>-maxthreads</c> via <see cref="Xunit2Settings.MaxThreads"/></li>
        ///     <li><c>-method</c> via <see cref="Xunit2Settings.Methods"/></li>
        ///     <li><c>-namespace</c> via <see cref="Xunit2Settings.Namespaces"/></li>
        ///     <li><c>-noautoreporters</c> via <see cref="Xunit2Settings.NoAutoReporters"/></li>
        ///     <li><c>-nocolor</c> via <see cref="Xunit2Settings.NoColor"/></li>
        ///     <li><c>-nologo</c> via <see cref="Xunit2Settings.NoLogo"/></li>
        ///     <li><c>-noshadow</c> via <see cref="Xunit2Settings.NoShadowCopying"/></li>
        ///     <li><c>-notrait</c> via <see cref="Xunit2Settings.ExcludedTraits"/></li>
        ///     <li><c>-parallel</c> via <see cref="Xunit2Settings.Parallel"/></li>
        ///     <li><c>-pause</c> via <see cref="Xunit2Settings.Pause"/></li>
        ///     <li><c>-serialize</c> via <see cref="Xunit2Settings.Serialization"/></li>
        ///     <li><c>-stoponfail</c> via <see cref="Xunit2Settings.StopOnFail"/></li>
        ///     <li><c>-trait</c> via <see cref="Xunit2Settings.Traits"/></li>
        ///     <li><c>-wait</c> via <see cref="Xunit2Settings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(Xunit2Settings Settings, IReadOnlyCollection<Output> Output)> Xunit2(CombinatorialConfigure<Xunit2Settings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Xunit2, XunitLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region Xunit2Settings
    /// <summary>
    ///   Used within <see cref="XunitTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Xunit2Settings : ToolSettings
    {
        /// <summary>
        ///   Path to the Xunit executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? XunitTasks.XunitLogger;
        /// <summary>
        ///   Assemblies to test, and their related related configuration files (ending with .json or .config).
        /// </summary>
        public virtual ILookup<string, string> TargetAssemblyWithConfigs => TargetAssemblyWithConfigsInternal.AsReadOnly();
        internal LookupTable<string, string> TargetAssemblyWithConfigsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Do not show the copyright message.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Do not output results with colors.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Convert skipped tests into failures.
        /// </summary>
        public virtual bool? FailSkips { get; internal set; }
        /// <summary>
        ///   Stop on first test failure.
        /// </summary>
        public virtual bool? StopOnFail { get; internal set; }
        /// <summary>
        ///   Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul>
        /// </summary>
        public virtual Xunit2ParallelOption Parallel { get; internal set; }
        /// <summary>
        ///   Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul>
        /// </summary>
        public virtual int? MaxThreads { get; internal set; }
        /// <summary>
        ///   AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul>
        /// </summary>
        public virtual Xunit2AppDomainMode AppDomainMode { get; internal set; }
        /// <summary>
        ///   Do not shadow copy assemblies.
        /// </summary>
        public virtual bool? NoShadowCopying { get; internal set; }
        /// <summary>
        ///   Wait for input after completion.
        /// </summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary>
        ///   Enable diagnostics messages for all test assemblies.
        /// </summary>
        public virtual bool? Diagnostics { get; internal set; }
        /// <summary>
        ///   Pause before doing any work, to help attach a debugger.
        /// </summary>
        public virtual bool? Pause { get; internal set; }
        /// <summary>
        ///   Launch the debugger to debug the tests.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Serialize all test cases (for diagnostic purposes only).
        /// </summary>
        public virtual bool? Serialization { get; internal set; }
        /// <summary>
        ///   Only run tests with matching name/value traits.
        /// </summary>
        public virtual ILookup<string, string> Traits => TraitsInternal.AsReadOnly();
        internal LookupTable<string, string> TraitsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Do not run tests with matching name/value traits.
        /// </summary>
        public virtual ILookup<string, string> ExcludedTraits => ExcludedTraitsInternal.AsReadOnly();
        internal LookupTable<string, string> ExcludedTraitsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').
        /// </summary>
        public virtual IReadOnlyList<string> Methods => MethodsInternal.AsReadOnly();
        internal List<string> MethodsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').
        /// </summary>
        public virtual IReadOnlyList<string> Classes => ClassesInternal.AsReadOnly();
        internal List<string> ClassesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').
        /// </summary>
        public virtual IReadOnlyList<string> Namespaces => NamespacesInternal.AsReadOnly();
        internal List<string> NamespacesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).
        /// </summary>
        public virtual bool? NoAutoReporters { get; internal set; }
        /// <summary>
        ///   Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul>
        /// </summary>
        public virtual Xunit2ReporterType Reporter { get; internal set; }
        /// <summary>
        ///   Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul>
        /// </summary>
        public virtual IReadOnlyDictionary<Xunit2ResultFormat, string> ResultReports => ResultReportsInternal.AsReadOnly();
        internal Dictionary<Xunit2ResultFormat, string> ResultReportsInternal { get; set; } = new Dictionary<Xunit2ResultFormat, string>(EqualityComparer<Xunit2ResultFormat>.Default);
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetAssemblyWithConfigs, "{key} {value}")
              .Add("-nologo", NoLogo)
              .Add("-nocolor", NoColor)
              .Add("-failskips", FailSkips)
              .Add("-stoponfail", StopOnFail)
              .Add("-parallel {value}", Parallel)
              .Add("-maxthreads {value}", MaxThreads)
              .Add("-appdomains {value}", AppDomainMode)
              .Add("-noshadow", NoShadowCopying)
              .Add("-wait", Wait)
              .Add("-diagnostics", Diagnostics)
              .Add("-pause", Pause)
              .Add("-debug", Debug)
              .Add("-serialize", Serialization)
              .Add("-trait {value}", Traits, "{key}={value}")
              .Add("-notrait {value}", ExcludedTraits, "{key}={value}")
              .Add("-method {value}", Methods)
              .Add("-class {value}", Classes)
              .Add("-namespace {value}", Namespaces)
              .Add("-noautoreporters", NoAutoReporters)
              .Add("-{value}", Reporter)
              .Add("-{value}", ResultReports, "{key} {value}");
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region Xunit2SettingsExtensions
    /// <summary>
    ///   Used within <see cref="XunitTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class Xunit2SettingsExtensions
    {
        #region TargetAssemblyWithConfigs
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/> to a new lookup table</em></p>
        ///   <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static T SetTargetAssemblyWithConfigs<T>(this T toolSettings, ILookup<string, string> targetAssemblyWithConfigs) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal = targetAssemblyWithConfigs.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></em></p>
        ///   <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static T ClearTargetAssemblyWithConfigs<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds new values for the given key to <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></em></p>
        ///   <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static T AddTargetAssemblyWithConfigs<T>(this T toolSettings, string targetAssemblyWithConfigsKey, params string[] targetAssemblyWithConfigsValues) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.AddRange(targetAssemblyWithConfigsKey, targetAssemblyWithConfigsValues);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds new values for the given key to <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></em></p>
        ///   <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static T AddTargetAssemblyWithConfigs<T>(this T toolSettings, string targetAssemblyWithConfigsKey, IEnumerable<string> targetAssemblyWithConfigsValues) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.AddRange(targetAssemblyWithConfigsKey, targetAssemblyWithConfigsValues);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a single targetAssemblyWithConfig from <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></em></p>
        ///   <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static T RemoveTargetAssemblyWithConfig<T>(this T toolSettings, string targetAssemblyWithConfigsKey, string targetAssemblyWithConfigsValue) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Remove(targetAssemblyWithConfigsKey, targetAssemblyWithConfigsValue);
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.NoLogo"/></em></p>
        ///   <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.NoLogo"/></em></p>
        ///   <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.NoLogo"/></em></p>
        ///   <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.NoLogo"/></em></p>
        ///   <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.NoLogo"/></em></p>
        ///   <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.NoColor"/></em></p>
        ///   <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.NoColor"/></em></p>
        ///   <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.NoColor"/></em></p>
        ///   <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.NoColor"/></em></p>
        ///   <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.NoColor"/></em></p>
        ///   <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region FailSkips
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.FailSkips"/></em></p>
        ///   <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static T SetFailSkips<T>(this T toolSettings, bool? failSkips) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = failSkips;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.FailSkips"/></em></p>
        ///   <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static T ResetFailSkips<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.FailSkips"/></em></p>
        ///   <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static T EnableFailSkips<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.FailSkips"/></em></p>
        ///   <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static T DisableFailSkips<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.FailSkips"/></em></p>
        ///   <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailSkips<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = !toolSettings.FailSkips;
            return toolSettings;
        }
        #endregion
        #region StopOnFail
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.StopOnFail"/></em></p>
        ///   <p>Stop on first test failure.</p>
        /// </summary>
        [Pure]
        public static T SetStopOnFail<T>(this T toolSettings, bool? stopOnFail) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = stopOnFail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.StopOnFail"/></em></p>
        ///   <p>Stop on first test failure.</p>
        /// </summary>
        [Pure]
        public static T ResetStopOnFail<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.StopOnFail"/></em></p>
        ///   <p>Stop on first test failure.</p>
        /// </summary>
        [Pure]
        public static T EnableStopOnFail<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.StopOnFail"/></em></p>
        ///   <p>Stop on first test failure.</p>
        /// </summary>
        [Pure]
        public static T DisableStopOnFail<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.StopOnFail"/></em></p>
        ///   <p>Stop on first test failure.</p>
        /// </summary>
        [Pure]
        public static T ToggleStopOnFail<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = !toolSettings.StopOnFail;
            return toolSettings;
        }
        #endregion
        #region Parallel
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Parallel"/></em></p>
        ///   <p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetParallel<T>(this T toolSettings, Xunit2ParallelOption parallel) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = parallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Parallel"/></em></p>
        ///   <p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetParallel<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = null;
            return toolSettings;
        }
        #endregion
        #region MaxThreads
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.MaxThreads"/></em></p>
        ///   <p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetMaxThreads<T>(this T toolSettings, int? maxThreads) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxThreads = maxThreads;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.MaxThreads"/></em></p>
        ///   <p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetMaxThreads<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxThreads = null;
            return toolSettings;
        }
        #endregion
        #region AppDomainMode
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.AppDomainMode"/></em></p>
        ///   <p>AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetAppDomainMode<T>(this T toolSettings, Xunit2AppDomainMode appDomainMode) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppDomainMode = appDomainMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.AppDomainMode"/></em></p>
        ///   <p>AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetAppDomainMode<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppDomainMode = null;
            return toolSettings;
        }
        #endregion
        #region NoShadowCopying
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.NoShadowCopying"/></em></p>
        ///   <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static T SetNoShadowCopying<T>(this T toolSettings, bool? noShadowCopying) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = noShadowCopying;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.NoShadowCopying"/></em></p>
        ///   <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static T ResetNoShadowCopying<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.NoShadowCopying"/></em></p>
        ///   <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static T EnableNoShadowCopying<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.NoShadowCopying"/></em></p>
        ///   <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static T DisableNoShadowCopying<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.NoShadowCopying"/></em></p>
        ///   <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoShadowCopying<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = !toolSettings.NoShadowCopying;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Wait"/></em></p>
        ///   <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static T SetWait<T>(this T toolSettings, bool? wait) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Wait"/></em></p>
        ///   <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static T ResetWait<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.Wait"/></em></p>
        ///   <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static T EnableWait<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.Wait"/></em></p>
        ///   <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static T DisableWait<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.Wait"/></em></p>
        ///   <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static T ToggleWait<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region Diagnostics
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Diagnostics"/></em></p>
        ///   <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static T SetDiagnostics<T>(this T toolSettings, bool? diagnostics) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = diagnostics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Diagnostics"/></em></p>
        ///   <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static T ResetDiagnostics<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.Diagnostics"/></em></p>
        ///   <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static T EnableDiagnostics<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.Diagnostics"/></em></p>
        ///   <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static T DisableDiagnostics<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.Diagnostics"/></em></p>
        ///   <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiagnostics<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = !toolSettings.Diagnostics;
            return toolSettings;
        }
        #endregion
        #region Pause
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Pause"/></em></p>
        ///   <p>Pause before doing any work, to help attach a debugger.</p>
        /// </summary>
        [Pure]
        public static T SetPause<T>(this T toolSettings, bool? pause) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = pause;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Pause"/></em></p>
        ///   <p>Pause before doing any work, to help attach a debugger.</p>
        /// </summary>
        [Pure]
        public static T ResetPause<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.Pause"/></em></p>
        ///   <p>Pause before doing any work, to help attach a debugger.</p>
        /// </summary>
        [Pure]
        public static T EnablePause<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.Pause"/></em></p>
        ///   <p>Pause before doing any work, to help attach a debugger.</p>
        /// </summary>
        [Pure]
        public static T DisablePause<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.Pause"/></em></p>
        ///   <p>Pause before doing any work, to help attach a debugger.</p>
        /// </summary>
        [Pure]
        public static T TogglePause<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = !toolSettings.Pause;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Debug"/></em></p>
        ///   <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Debug"/></em></p>
        ///   <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.Debug"/></em></p>
        ///   <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.Debug"/></em></p>
        ///   <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.Debug"/></em></p>
        ///   <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Serialization
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Serialization"/></em></p>
        ///   <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static T SetSerialization<T>(this T toolSettings, bool? serialization) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = serialization;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Serialization"/></em></p>
        ///   <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static T ResetSerialization<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.Serialization"/></em></p>
        ///   <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static T EnableSerialization<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.Serialization"/></em></p>
        ///   <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static T DisableSerialization<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.Serialization"/></em></p>
        ///   <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static T ToggleSerialization<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = !toolSettings.Serialization;
            return toolSettings;
        }
        #endregion
        #region Traits
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Traits"/> to a new lookup table</em></p>
        ///   <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T SetTraits<T>(this T toolSettings, ILookup<string, string> traits) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal = traits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.Traits"/></em></p>
        ///   <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T ClearTraits<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds new values for the given key to <see cref="Xunit2Settings.Traits"/></em></p>
        ///   <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T AddTraits<T>(this T toolSettings, string traitsKey, params string[] traitsValues) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.AddRange(traitsKey, traitsValues);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds new values for the given key to <see cref="Xunit2Settings.Traits"/></em></p>
        ///   <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T AddTraits<T>(this T toolSettings, string traitsKey, IEnumerable<string> traitsValues) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.AddRange(traitsKey, traitsValues);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a single trait from <see cref="Xunit2Settings.Traits"/></em></p>
        ///   <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T RemoveTrait<T>(this T toolSettings, string traitsKey, string traitsValue) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Remove(traitsKey, traitsValue);
            return toolSettings;
        }
        #endregion
        #region ExcludedTraits
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.ExcludedTraits"/> to a new lookup table</em></p>
        ///   <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T SetExcludedTraits<T>(this T toolSettings, ILookup<string, string> excludedTraits) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal = excludedTraits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.ExcludedTraits"/></em></p>
        ///   <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludedTraits<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds new values for the given key to <see cref="Xunit2Settings.ExcludedTraits"/></em></p>
        ///   <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T AddExcludedTraits<T>(this T toolSettings, string excludedTraitsKey, params string[] excludedTraitsValues) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.AddRange(excludedTraitsKey, excludedTraitsValues);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds new values for the given key to <see cref="Xunit2Settings.ExcludedTraits"/></em></p>
        ///   <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T AddExcludedTraits<T>(this T toolSettings, string excludedTraitsKey, IEnumerable<string> excludedTraitsValues) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.AddRange(excludedTraitsKey, excludedTraitsValues);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a single excludedTrait from <see cref="Xunit2Settings.ExcludedTraits"/></em></p>
        ///   <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludedTrait<T>(this T toolSettings, string excludedTraitsKey, string excludedTraitsValue) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Remove(excludedTraitsKey, excludedTraitsValue);
            return toolSettings;
        }
        #endregion
        #region Methods
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Methods"/> to a new list</em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T SetMethods<T>(this T toolSettings, params string[] methods) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Methods"/> to a new list</em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T SetMethods<T>(this T toolSettings, IEnumerable<string> methods) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="Xunit2Settings.Methods"/></em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T AddMethods<T>(this T toolSettings, params string[] methods) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="Xunit2Settings.Methods"/></em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T AddMethods<T>(this T toolSettings, IEnumerable<string> methods) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.Methods"/></em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T ClearMethods<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="Xunit2Settings.Methods"/></em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T RemoveMethods<T>(this T toolSettings, params string[] methods) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(methods);
            toolSettings.MethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="Xunit2Settings.Methods"/></em></p>
        ///   <p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static T RemoveMethods<T>(this T toolSettings, IEnumerable<string> methods) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(methods);
            toolSettings.MethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Classes
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Classes"/> to a new list</em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T SetClasses<T>(this T toolSettings, params string[] classes) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal = classes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Classes"/> to a new list</em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T SetClasses<T>(this T toolSettings, IEnumerable<string> classes) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal = classes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="Xunit2Settings.Classes"/></em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T AddClasses<T>(this T toolSettings, params string[] classes) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.AddRange(classes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="Xunit2Settings.Classes"/></em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T AddClasses<T>(this T toolSettings, IEnumerable<string> classes) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.AddRange(classes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.Classes"/></em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T ClearClasses<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="Xunit2Settings.Classes"/></em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T RemoveClasses<T>(this T toolSettings, params string[] classes) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classes);
            toolSettings.ClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="Xunit2Settings.Classes"/></em></p>
        ///   <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static T RemoveClasses<T>(this T toolSettings, IEnumerable<string> classes) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classes);
            toolSettings.ClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Namespaces
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Namespaces"/> to a new list</em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T SetNamespaces<T>(this T toolSettings, params string[] namespaces) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal = namespaces.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Namespaces"/> to a new list</em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T SetNamespaces<T>(this T toolSettings, IEnumerable<string> namespaces) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal = namespaces.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="Xunit2Settings.Namespaces"/></em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T AddNamespaces<T>(this T toolSettings, params string[] namespaces) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.AddRange(namespaces);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="Xunit2Settings.Namespaces"/></em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T AddNamespaces<T>(this T toolSettings, IEnumerable<string> namespaces) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.AddRange(namespaces);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.Namespaces"/></em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T ClearNamespaces<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="Xunit2Settings.Namespaces"/></em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T RemoveNamespaces<T>(this T toolSettings, params string[] namespaces) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(namespaces);
            toolSettings.NamespacesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="Xunit2Settings.Namespaces"/></em></p>
        ///   <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static T RemoveNamespaces<T>(this T toolSettings, IEnumerable<string> namespaces) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(namespaces);
            toolSettings.NamespacesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoAutoReporters
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.NoAutoReporters"/></em></p>
        ///   <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static T SetNoAutoReporters<T>(this T toolSettings, bool? noAutoReporters) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = noAutoReporters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.NoAutoReporters"/></em></p>
        ///   <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static T ResetNoAutoReporters<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="Xunit2Settings.NoAutoReporters"/></em></p>
        ///   <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static T EnableNoAutoReporters<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="Xunit2Settings.NoAutoReporters"/></em></p>
        ///   <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static T DisableNoAutoReporters<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="Xunit2Settings.NoAutoReporters"/></em></p>
        ///   <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static T ToggleNoAutoReporters<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = !toolSettings.NoAutoReporters;
            return toolSettings;
        }
        #endregion
        #region Reporter
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Reporter"/></em></p>
        ///   <p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetReporter<T>(this T toolSettings, Xunit2ReporterType reporter) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reporter = reporter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Reporter"/></em></p>
        ///   <p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetReporter<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reporter = null;
            return toolSettings;
        }
        #endregion
        #region ResultReports
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.ResultReports"/> to a new dictionary</em></p>
        ///   <p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetResultReports<T>(this T toolSettings, IDictionary<Xunit2ResultFormat, string> resultReports) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal = resultReports.ToDictionary(x => x.Key, x => x.Value, EqualityComparer<Xunit2ResultFormat>.Default);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="Xunit2Settings.ResultReports"/></em></p>
        ///   <p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p>
        /// </summary>
        [Pure]
        public static T ClearResultReports<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="Xunit2Settings.ResultReports"/></em></p>
        ///   <p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p>
        /// </summary>
        [Pure]
        public static T AddResultReport<T>(this T toolSettings, Xunit2ResultFormat resultReportKey, string resultReportValue) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal.Add(resultReportKey, resultReportValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="Xunit2Settings.ResultReports"/></em></p>
        ///   <p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p>
        /// </summary>
        [Pure]
        public static T RemoveResultReport<T>(this T toolSettings, Xunit2ResultFormat resultReportKey) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal.Remove(resultReportKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="Xunit2Settings.ResultReports"/></em></p>
        ///   <p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetResultReport<T>(this T toolSettings, Xunit2ResultFormat resultReportKey, string resultReportValue) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal[resultReportKey] = resultReportValue;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="Xunit2Settings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="Xunit2Settings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : Xunit2Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region Xunit2ReporterType
    /// <summary>
    ///   Used within <see cref="XunitTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2ReporterType>))]
    public partial class Xunit2ReporterType : Enumeration
    {
        public static Xunit2ReporterType AppVeyor = (Xunit2ReporterType) "AppVeyor";
        public static Xunit2ReporterType JSON = (Xunit2ReporterType) "JSON";
        public static Xunit2ReporterType Quiet = (Xunit2ReporterType) "Quiet";
        public static Xunit2ReporterType TeamCity = (Xunit2ReporterType) "TeamCity";
        public static Xunit2ReporterType Verbose = (Xunit2ReporterType) "Verbose";
        public static implicit operator Xunit2ReporterType(string value)
        {
            return new Xunit2ReporterType { Value = value };
        }
    }
    #endregion
    #region Xunit2ResultFormat
    /// <summary>
    ///   Used within <see cref="XunitTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2ResultFormat>))]
    public partial class Xunit2ResultFormat : Enumeration
    {
        public static Xunit2ResultFormat Xml = (Xunit2ResultFormat) "Xml";
        public static Xunit2ResultFormat XmlV1 = (Xunit2ResultFormat) "XmlV1";
        public static Xunit2ResultFormat NUnit = (Xunit2ResultFormat) "NUnit";
        public static Xunit2ResultFormat HTML = (Xunit2ResultFormat) "HTML";
        public static implicit operator Xunit2ResultFormat(string value)
        {
            return new Xunit2ResultFormat { Value = value };
        }
    }
    #endregion
    #region Xunit2ParallelOption
    /// <summary>
    ///   Used within <see cref="XunitTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2ParallelOption>))]
    public partial class Xunit2ParallelOption : Enumeration
    {
        public static Xunit2ParallelOption none = (Xunit2ParallelOption) "none";
        public static Xunit2ParallelOption collections = (Xunit2ParallelOption) "collections";
        public static Xunit2ParallelOption assemblies = (Xunit2ParallelOption) "assemblies";
        public static Xunit2ParallelOption all = (Xunit2ParallelOption) "all";
        public static implicit operator Xunit2ParallelOption(string value)
        {
            return new Xunit2ParallelOption { Value = value };
        }
    }
    #endregion
    #region Xunit2AppDomainMode
    /// <summary>
    ///   Used within <see cref="XunitTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2AppDomainMode>))]
    public partial class Xunit2AppDomainMode : Enumeration
    {
        public static Xunit2AppDomainMode IfAvailable = (Xunit2AppDomainMode) "IfAvailable";
        public static Xunit2AppDomainMode Required = (Xunit2AppDomainMode) "Required";
        public static Xunit2AppDomainMode Denied = (Xunit2AppDomainMode) "Denied";
        public static implicit operator Xunit2AppDomainMode(string value)
        {
            return new Xunit2AppDomainMode { Value = value };
        }
    }
    #endregion
}
