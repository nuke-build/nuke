// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/Xunit.json
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

namespace Nuke.Common.Tools.Xunit
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class XunitTasks
    {
        /// <summary><p>Path to the Xunit executable.</p></summary>
        public static string XunitPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("XUNIT_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> XunitLogger { get; set; } = ProcessManager.DefaultLogger;
        /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p></summary>
        public static IReadOnlyCollection<Output> Xunit(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(XunitPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, XunitLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Xunit2(Xunit2Settings toolSettings = null)
        {
            toolSettings = toolSettings ?? new Xunit2Settings();
            var process = ProcessTasks.StartProcess(toolSettings);
            AssertProcess(process, toolSettings);
            return process.Output;
        }
        /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Xunit2(Configure<Xunit2Settings> configurator)
        {
            return Xunit2(configurator(new Xunit2Settings()));
        }
        /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
        public static IEnumerable<(Xunit2Settings Settings, IReadOnlyCollection<Output> Output)> Xunit2(CombinatorialConfigure<Xunit2Settings> configurator, int degreeOfParallelism = 1, bool stopOnFirstError = false)
        {
            return configurator.Execute(Xunit2, XunitLogger, degreeOfParallelism, stopOnFirstError);
        }
    }
    #region Xunit2Settings
    /// <summary><p>Used within <see cref="XunitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Xunit2Settings : ToolSettings
    {
        /// <summary><p>Path to the Xunit executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => XunitTasks.XunitLogger;
        /// <summary><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        public virtual ILookup<string, string> TargetAssemblyWithConfigs => TargetAssemblyWithConfigsInternal.AsReadOnly();
        internal LookupTable<string, string> TargetAssemblyWithConfigsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Do not show the copyright message.</p></summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary><p>Do not output results with colors.</p></summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary><p>Convert skipped tests into failures.</p></summary>
        public virtual bool? FailSkips { get; internal set; }
        /// <summary><p>Stop on first test failure.</p></summary>
        public virtual bool? StopOnFail { get; internal set; }
        /// <summary><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        public virtual Xunit2ParallelOption Parallel { get; internal set; }
        /// <summary><p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p></summary>
        public virtual int? MaxThreads { get; internal set; }
        /// <summary><p>AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul></p></summary>
        public virtual Xunit2AppDomainMode AppDomainMode { get; internal set; }
        /// <summary><p>Do not shadow copy assemblies.</p></summary>
        public virtual bool? NoShadowCopying { get; internal set; }
        /// <summary><p>Wait for input after completion.</p></summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary><p>Enable diagnostics messages for all test assemblies.</p></summary>
        public virtual bool? Diagnostics { get; internal set; }
        /// <summary><p>Pause before doing any work, to help attach a debugger.</p></summary>
        public virtual bool? Pause { get; internal set; }
        /// <summary><p>Launch the debugger to debug the tests.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        public virtual bool? Serialization { get; internal set; }
        /// <summary><p>Only run tests with matching name/value traits.</p></summary>
        public virtual ILookup<string, string> Traits => TraitsInternal.AsReadOnly();
        internal LookupTable<string, string> TraitsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Do not run tests with matching name/value traits.</p></summary>
        public virtual ILookup<string, string> ExcludedTraits => ExcludedTraitsInternal.AsReadOnly();
        internal LookupTable<string, string> ExcludedTraitsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        public virtual IReadOnlyList<string> Methods => MethodsInternal.AsReadOnly();
        internal List<string> MethodsInternal { get; set; } = new List<string>();
        /// <summary><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        public virtual IReadOnlyList<string> Classes => ClassesInternal.AsReadOnly();
        internal List<string> ClassesInternal { get; set; } = new List<string>();
        /// <summary><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        public virtual IReadOnlyList<string> Namespaces => NamespacesInternal.AsReadOnly();
        internal List<string> NamespacesInternal { get; set; } = new List<string>();
        /// <summary><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        public virtual bool? NoAutoReporters { get; internal set; }
        /// <summary><p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p></summary>
        public virtual Xunit2ReporterType Reporter { get; internal set; }
        /// <summary><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        public virtual IReadOnlyDictionary<Xunit2ResultFormat, string> ResultReports => ResultReportsInternal.AsReadOnly();
        internal Dictionary<Xunit2ResultFormat, string> ResultReportsInternal { get; set; } = new Dictionary<Xunit2ResultFormat, string>(EqualityComparer<Xunit2ResultFormat>.Default);
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region Xunit2SettingsExtensions
    /// <summary><p>Used within <see cref="XunitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class Xunit2SettingsExtensions
    {
        #region TargetAssemblyWithConfigs
        /// <summary><p><em>Sets <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/> to a new lookup table.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings SetTargetAssemblyWithConfigs(this Xunit2Settings toolSettings, ILookup<string, string> targetAssemblyWithConfigs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal = targetAssemblyWithConfigs.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings ClearTargetAssemblyWithConfigs(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds new values for the given key to <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings AddTargetAssemblyWithConfigs(this Xunit2Settings toolSettings, string targetAssemblyWithConfigsKey, params string[] targetAssemblyWithConfigsValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.AddRange(targetAssemblyWithConfigsKey, targetAssemblyWithConfigsValues);
            return toolSettings;
        }
        /// <summary><p><em>Adds new values for the given key to <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings AddTargetAssemblyWithConfigs(this Xunit2Settings toolSettings, string targetAssemblyWithConfigsKey, IEnumerable<string> targetAssemblyWithConfigsValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.AddRange(targetAssemblyWithConfigsKey, targetAssemblyWithConfigsValues);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single targetAssemblyWithConfig from <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings RemoveTargetAssemblyWithConfig(this Xunit2Settings toolSettings, string targetAssemblyWithConfigsKey, string targetAssemblyWithConfigsValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Remove(targetAssemblyWithConfigsKey, targetAssemblyWithConfigsValue);
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary><p><em>Sets <see cref="Xunit2Settings.NoLogo"/>.</em></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoLogo(this Xunit2Settings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.NoLogo"/>.</em></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings ResetNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.NoLogo"/>.</em></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.NoLogo"/>.</em></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.NoLogo"/>.</em></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary><p><em>Sets <see cref="Xunit2Settings.NoColor"/>.</em></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoColor(this Xunit2Settings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.NoColor"/>.</em></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings ResetNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.NoColor"/>.</em></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.NoColor"/>.</em></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.NoColor"/>.</em></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region FailSkips
        /// <summary><p><em>Sets <see cref="Xunit2Settings.FailSkips"/>.</em></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings SetFailSkips(this Xunit2Settings toolSettings, bool? failSkips)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = failSkips;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.FailSkips"/>.</em></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings ResetFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.FailSkips"/>.</em></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings EnableFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.FailSkips"/>.</em></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings DisableFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.FailSkips"/>.</em></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = !toolSettings.FailSkips;
            return toolSettings;
        }
        #endregion
        #region StopOnFail
        /// <summary><p><em>Sets <see cref="Xunit2Settings.StopOnFail"/>.</em></p><p>Stop on first test failure.</p></summary>
        [Pure]
        public static Xunit2Settings SetStopOnFail(this Xunit2Settings toolSettings, bool? stopOnFail)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = stopOnFail;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.StopOnFail"/>.</em></p><p>Stop on first test failure.</p></summary>
        [Pure]
        public static Xunit2Settings ResetStopOnFail(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.StopOnFail"/>.</em></p><p>Stop on first test failure.</p></summary>
        [Pure]
        public static Xunit2Settings EnableStopOnFail(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.StopOnFail"/>.</em></p><p>Stop on first test failure.</p></summary>
        [Pure]
        public static Xunit2Settings DisableStopOnFail(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.StopOnFail"/>.</em></p><p>Stop on first test failure.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleStopOnFail(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFail = !toolSettings.StopOnFail;
            return toolSettings;
        }
        #endregion
        #region Parallel
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Parallel"/>.</em></p><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetParallel(this Xunit2Settings toolSettings, Xunit2ParallelOption parallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = parallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Parallel"/>.</em></p><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings ResetParallel(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = null;
            return toolSettings;
        }
        #endregion
        #region MaxThreads
        /// <summary><p><em>Sets <see cref="Xunit2Settings.MaxThreads"/>.</em></p><p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetMaxThreads(this Xunit2Settings toolSettings, int? maxThreads)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxThreads = maxThreads;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.MaxThreads"/>.</em></p><p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings ResetMaxThreads(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxThreads = null;
            return toolSettings;
        }
        #endregion
        #region AppDomainMode
        /// <summary><p><em>Sets <see cref="Xunit2Settings.AppDomainMode"/>.</em></p><p>AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetAppDomainMode(this Xunit2Settings toolSettings, Xunit2AppDomainMode appDomainMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppDomainMode = appDomainMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.AppDomainMode"/>.</em></p><p>AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings ResetAppDomainMode(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppDomainMode = null;
            return toolSettings;
        }
        #endregion
        #region NoShadowCopying
        /// <summary><p><em>Sets <see cref="Xunit2Settings.NoShadowCopying"/>.</em></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoShadowCopying(this Xunit2Settings toolSettings, bool? noShadowCopying)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = noShadowCopying;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.NoShadowCopying"/>.</em></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings ResetNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.NoShadowCopying"/>.</em></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.NoShadowCopying"/>.</em></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.NoShadowCopying"/>.</em></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = !toolSettings.NoShadowCopying;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Wait"/>.</em></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings SetWait(this Xunit2Settings toolSettings, bool? wait)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Wait"/>.</em></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings ResetWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.Wait"/>.</em></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings EnableWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.Wait"/>.</em></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings DisableWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.Wait"/>.</em></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region Diagnostics
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Diagnostics"/>.</em></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings SetDiagnostics(this Xunit2Settings toolSettings, bool? diagnostics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = diagnostics;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Diagnostics"/>.</em></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings ResetDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.Diagnostics"/>.</em></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings EnableDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.Diagnostics"/>.</em></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings DisableDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.Diagnostics"/>.</em></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = !toolSettings.Diagnostics;
            return toolSettings;
        }
        #endregion
        #region Pause
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Pause"/>.</em></p><p>Pause before doing any work, to help attach a debugger.</p></summary>
        [Pure]
        public static Xunit2Settings SetPause(this Xunit2Settings toolSettings, bool? pause)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = pause;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Pause"/>.</em></p><p>Pause before doing any work, to help attach a debugger.</p></summary>
        [Pure]
        public static Xunit2Settings ResetPause(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.Pause"/>.</em></p><p>Pause before doing any work, to help attach a debugger.</p></summary>
        [Pure]
        public static Xunit2Settings EnablePause(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.Pause"/>.</em></p><p>Pause before doing any work, to help attach a debugger.</p></summary>
        [Pure]
        public static Xunit2Settings DisablePause(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.Pause"/>.</em></p><p>Pause before doing any work, to help attach a debugger.</p></summary>
        [Pure]
        public static Xunit2Settings TogglePause(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = !toolSettings.Pause;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Debug"/>.</em></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings SetDebug(this Xunit2Settings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Debug"/>.</em></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings ResetDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.Debug"/>.</em></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings EnableDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.Debug"/>.</em></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings DisableDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.Debug"/>.</em></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Serialization
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Serialization"/>.</em></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings SetSerialization(this Xunit2Settings toolSettings, bool? serialization)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = serialization;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Serialization"/>.</em></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings ResetSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.Serialization"/>.</em></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings EnableSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.Serialization"/>.</em></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings DisableSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.Serialization"/>.</em></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings ToggleSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = !toolSettings.Serialization;
            return toolSettings;
        }
        #endregion
        #region Traits
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Traits"/> to a new lookup table.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings SetTraits(this Xunit2Settings toolSettings, ILookup<string, string> traits)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal = traits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.Traits"/>.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings ClearTraits(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds new values for the given key to <see cref="Xunit2Settings.Traits"/>.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddTraits(this Xunit2Settings toolSettings, string traitsKey, params string[] traitsValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.AddRange(traitsKey, traitsValues);
            return toolSettings;
        }
        /// <summary><p><em>Adds new values for the given key to <see cref="Xunit2Settings.Traits"/>.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddTraits(this Xunit2Settings toolSettings, string traitsKey, IEnumerable<string> traitsValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.AddRange(traitsKey, traitsValues);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single trait from <see cref="Xunit2Settings.Traits"/>.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings RemoveTrait(this Xunit2Settings toolSettings, string traitsKey, string traitsValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Remove(traitsKey, traitsValue);
            return toolSettings;
        }
        #endregion
        #region ExcludedTraits
        /// <summary><p><em>Sets <see cref="Xunit2Settings.ExcludedTraits"/> to a new lookup table.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings SetExcludedTraits(this Xunit2Settings toolSettings, ILookup<string, string> excludedTraits)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal = excludedTraits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.ExcludedTraits"/>.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings ClearExcludedTraits(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds new values for the given key to <see cref="Xunit2Settings.ExcludedTraits"/>.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddExcludedTraits(this Xunit2Settings toolSettings, string excludedTraitsKey, params string[] excludedTraitsValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.AddRange(excludedTraitsKey, excludedTraitsValues);
            return toolSettings;
        }
        /// <summary><p><em>Adds new values for the given key to <see cref="Xunit2Settings.ExcludedTraits"/>.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddExcludedTraits(this Xunit2Settings toolSettings, string excludedTraitsKey, IEnumerable<string> excludedTraitsValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.AddRange(excludedTraitsKey, excludedTraitsValues);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single excludedTrait from <see cref="Xunit2Settings.ExcludedTraits"/>.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings RemoveExcludedTrait(this Xunit2Settings toolSettings, string excludedTraitsKey, string excludedTraitsValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Remove(excludedTraitsKey, excludedTraitsValue);
            return toolSettings;
        }
        #endregion
        #region Methods
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Methods"/> to a new list.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings SetMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Methods"/> to a new list.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings SetMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings ClearMethods(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(methods);
            toolSettings.MethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(methods);
            toolSettings.MethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Classes
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Classes"/> to a new list.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings SetClasses(this Xunit2Settings toolSettings, params string[] classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal = classes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Classes"/> to a new list.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings SetClasses(this Xunit2Settings toolSettings, IEnumerable<string> classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal = classes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Classes"/>.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings AddClasses(this Xunit2Settings toolSettings, params string[] classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.AddRange(classes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Classes"/>.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings AddClasses(this Xunit2Settings toolSettings, IEnumerable<string> classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.AddRange(classes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.Classes"/>.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings ClearClasses(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Classes"/>.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveClasses(this Xunit2Settings toolSettings, params string[] classes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classes);
            toolSettings.ClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Classes"/>.</em></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveClasses(this Xunit2Settings toolSettings, IEnumerable<string> classes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classes);
            toolSettings.ClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Namespaces
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Namespaces"/> to a new list.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings SetNamespaces(this Xunit2Settings toolSettings, params string[] namespaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal = namespaces.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Namespaces"/> to a new list.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings SetNamespaces(this Xunit2Settings toolSettings, IEnumerable<string> namespaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal = namespaces.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Namespaces"/>.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings AddNamespaces(this Xunit2Settings toolSettings, params string[] namespaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.AddRange(namespaces);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Namespaces"/>.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings AddNamespaces(this Xunit2Settings toolSettings, IEnumerable<string> namespaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.AddRange(namespaces);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.Namespaces"/>.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings ClearNamespaces(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Namespaces"/>.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveNamespaces(this Xunit2Settings toolSettings, params string[] namespaces)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(namespaces);
            toolSettings.NamespacesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Namespaces"/>.</em></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveNamespaces(this Xunit2Settings toolSettings, IEnumerable<string> namespaces)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(namespaces);
            toolSettings.NamespacesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoAutoReporters
        /// <summary><p><em>Sets <see cref="Xunit2Settings.NoAutoReporters"/>.</em></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings SetNoAutoReporters(this Xunit2Settings toolSettings, bool? noAutoReporters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = noAutoReporters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.NoAutoReporters"/>.</em></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings ResetNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.NoAutoReporters"/>.</em></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.NoAutoReporters"/>.</em></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.NoAutoReporters"/>.</em></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = !toolSettings.NoAutoReporters;
            return toolSettings;
        }
        #endregion
        #region Reporter
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Reporter"/>.</em></p><p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetReporter(this Xunit2Settings toolSettings, Xunit2ReporterType reporter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reporter = reporter;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Reporter"/>.</em></p><p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings ResetReporter(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reporter = null;
            return toolSettings;
        }
        #endregion
        #region ResultReports
        /// <summary><p><em>Sets <see cref="Xunit2Settings.ResultReports"/> to a new dictionary.</em></p><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetResultReports(this Xunit2Settings toolSettings, IDictionary<Xunit2ResultFormat, string> resultReports)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal = resultReports.ToDictionary(x => x.Key, x => x.Value, EqualityComparer<Xunit2ResultFormat>.Default);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.ResultReports"/>.</em></p><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings ClearResultReports(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="Xunit2Settings.ResultReports"/>.</em></p><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings AddResultReport(this Xunit2Settings toolSettings, Xunit2ResultFormat resultReportKey, string resultReportValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal.Add(resultReportKey, resultReportValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="Xunit2Settings.ResultReports"/>.</em></p><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings RemoveResultReport(this Xunit2Settings toolSettings, Xunit2ResultFormat resultReportKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal.Remove(resultReportKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="Xunit2Settings.ResultReports"/>.</em></p><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetResultReport(this Xunit2Settings toolSettings, Xunit2ResultFormat resultReportKey, string resultReportValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultReportsInternal[resultReportKey] = resultReportValue;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Framework"/>.</em></p></summary>
        [Pure]
        public static Xunit2Settings SetFramework(this Xunit2Settings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.Framework"/>.</em></p></summary>
        [Pure]
        public static Xunit2Settings ResetFramework(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region Xunit2ReporterType
    /// <summary><p>Used within <see cref="XunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2ReporterType>))]
    public partial class Xunit2ReporterType : Enumeration
    {
        public static Xunit2ReporterType AppVeyor = new Xunit2ReporterType { Value = "AppVeyor" };
        public static Xunit2ReporterType JSON = new Xunit2ReporterType { Value = "JSON" };
        public static Xunit2ReporterType Quiet = new Xunit2ReporterType { Value = "Quiet" };
        public static Xunit2ReporterType TeamCity = new Xunit2ReporterType { Value = "TeamCity" };
        public static Xunit2ReporterType Verbose = new Xunit2ReporterType { Value = "Verbose" };
    }
    #endregion
    #region Xunit2ResultFormat
    /// <summary><p>Used within <see cref="XunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2ResultFormat>))]
    public partial class Xunit2ResultFormat : Enumeration
    {
        public static Xunit2ResultFormat Xml = new Xunit2ResultFormat { Value = "Xml" };
        public static Xunit2ResultFormat XmlV1 = new Xunit2ResultFormat { Value = "XmlV1" };
        public static Xunit2ResultFormat NUnit = new Xunit2ResultFormat { Value = "NUnit" };
        public static Xunit2ResultFormat HTML = new Xunit2ResultFormat { Value = "HTML" };
    }
    #endregion
    #region Xunit2ParallelOption
    /// <summary><p>Used within <see cref="XunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2ParallelOption>))]
    public partial class Xunit2ParallelOption : Enumeration
    {
        public static Xunit2ParallelOption None = new Xunit2ParallelOption { Value = "None" };
        public static Xunit2ParallelOption Collections = new Xunit2ParallelOption { Value = "Collections" };
        public static Xunit2ParallelOption Assemblies = new Xunit2ParallelOption { Value = "Assemblies" };
        public static Xunit2ParallelOption All = new Xunit2ParallelOption { Value = "All" };
    }
    #endregion
    #region Xunit2AppDomainMode
    /// <summary><p>Used within <see cref="XunitTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Xunit2AppDomainMode>))]
    public partial class Xunit2AppDomainMode : Enumeration
    {
        public static Xunit2AppDomainMode IfAvailable = new Xunit2AppDomainMode { Value = "IfAvailable" };
        public static Xunit2AppDomainMode Required = new Xunit2AppDomainMode { Value = "Required" };
        public static Xunit2AppDomainMode Denied = new Xunit2AppDomainMode { Value = "Denied" };
    }
    #endregion
}
