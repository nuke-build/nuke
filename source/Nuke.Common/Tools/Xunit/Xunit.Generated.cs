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

namespace Nuke.Common.Tools.Xunit
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [IconClass("bug2")]
    public static partial class XunitTasks
    {
        static partial void PreProcess (XunitSettings xunitSettings);
        static partial void PostProcess (XunitSettings xunitSettings);
        /// <summary>
        /// <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
        /// <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
        /// </summary>
        public static void Xunit2 (Configure<XunitSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var xunitSettings = new XunitSettings();
            xunitSettings = configurator(xunitSettings);
            PreProcess(xunitSettings);
            var process = ProcessManager.Instance.StartProcess(xunitSettings, processSettings);
            AssertProcess(process, xunitSettings);
            PostProcess(xunitSettings);
        }
    }
    /// <summary>
    /// <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
    /// <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class XunitSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? NuGetPackageResolver.GetToolPath($"xunit.runner.console", $"{GetExecutable()}");
        /// <summary><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        public virtual ILookup<string, string> TargetAssemblyWithConfigs => TargetAssemblyWithConfigsInternal.AsReadOnly();
        internal LookupTable<string, string> TargetAssemblyWithConfigsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>The report file output path.</p></summary>
        public virtual string OutputPath { get; internal set; }
        /// <summary><p>Do not show the copyright message.</p></summary>
        public virtual bool NoLogo { get; internal set; }
        /// <summary><p>Do not output results with colors.</p></summary>
        public virtual bool NoColor { get; internal set; }
        /// <summary><p>Do not use app domains to run test code.</p></summary>
        public virtual bool NoAppDomain { get; internal set; }
        /// <summary><p>Convert skipped tests into failures.</p></summary>
        public virtual bool FailSkips { get; internal set; }
        /// <summary><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        public virtual ParallelOption? Parallel { get; internal set; }
        /// <summary><p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p></summary>
        public virtual int? MaxThreads { get; internal set; }
        /// <summary><p>Do not shadow copy assemblies.</p></summary>
        public virtual bool NoShadowCopying { get; internal set; }
        /// <summary><p>Wait for input after completion.</p></summary>
        public virtual bool Wait { get; internal set; }
        /// <summary><p>Enable diagnostics messages for all test assemblies.</p></summary>
        public virtual bool Diagnostics { get; internal set; }
        /// <summary><p>Launch the debugger to debug the tests.</p></summary>
        public virtual bool Debug { get; internal set; }
        /// <summary><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        public virtual bool Serialization { get; internal set; }
        /// <summary><p>Only run tests with matching name/value traits.</p></summary>
        public virtual ILookup<string, string> Traits => TraitsInternal.AsReadOnly();
        internal LookupTable<string, string> TraitsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Do not run tests with matching name/value traits.</p></summary>
        public virtual ILookup<string, string> ExcludedTraits => ExcludedTraitsInternal.AsReadOnly();
        internal LookupTable<string, string> ExcludedTraitsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        public virtual IReadOnlyList<string> Methods => MethodsInternal.AsReadOnly();
        internal List<string> MethodsInternal { get; set; } = new List<string>();
        /// <summary><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        public virtual IReadOnlyList<string> Classes => ClassesInternal.AsReadOnly();
        internal List<string> ClassesInternal { get; set; } = new List<string>();
        /// <summary><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        public virtual IReadOnlyList<string> Namespaces => NamespacesInternal.AsReadOnly();
        internal List<string> NamespacesInternal { get; set; } = new List<string>();
        /// <summary><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        public virtual bool NoAutoReporters { get; internal set; }
        /// <summary><p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p></summary>
        public virtual ReporterType? Reporter { get; internal set; }
        /// <summary><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        public virtual ResultFormat? ResultFormat { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", TargetAssemblyWithConfigs, keyValueSeparator: $" ")
              .Add("{value}", OutputPath)
              .Add("-nologo", NoLogo)
              .Add("-nocolor", NoColor)
              .Add("-noappdomain", NoAppDomain)
              .Add("-failskips", FailSkips)
              .Add("-parallel {value}", Parallel)
              .Add("-maxthreads {value}", MaxThreads)
              .Add("-noshadow", NoShadowCopying)
              .Add("-wait", Wait)
              .Add("-diagnostics", Diagnostics)
              .Add("-debug", Debug)
              .Add("-serialize", Serialization)
              .Add("-trait {value}", Traits, keyValueSeparator: $"=")
              .Add("-notrait {value}", ExcludedTraits, keyValueSeparator: $"=")
              .Add("-method {value}", Methods)
              .Add("-class {value}", Classes)
              .Add("-namespace {value}", Namespaces)
              .Add("-noautoreporters", NoAutoReporters)
              .Add("-{value}", Reporter)
              .Add("-{value}", ResultFormat);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class XunitSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.TargetAssemblyWithConfigs"/> to a new lookup table.</i></p>
        /// <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetTargetAssemblyWithConfigs(this XunitSettings xunitSettings, ILookup<string, string> targetAssemblyWithConfigs)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TargetAssemblyWithConfigsInternal = targetAssemblyWithConfigs.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="XunitSettings.TargetAssemblyWithConfigs"/>.</i></p>
        /// <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static XunitSettings ClearTargetAssemblyWithConfigs(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TargetAssemblyWithConfigsInternal.Clear();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a targetAssemblyWithConfig to <see cref="XunitSettings.TargetAssemblyWithConfigs"/>.</i></p>
        /// <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddTargetAssemblyWithConfig(this XunitSettings xunitSettings, string targetAssemblyWithConfigKey, string targetAssemblyWithConfigValue)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TargetAssemblyWithConfigsInternal.Add(targetAssemblyWithConfigKey, targetAssemblyWithConfigValue);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single targetAssemblyWithConfig entry from <see cref="XunitSettings.TargetAssemblyWithConfigs"/>.</i></p>
        /// <p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p>
        /// </summary>
        [Pure]
        public static XunitSettings RemoveTargetAssemblyWithConfig(this XunitSettings xunitSettings, string targetAssemblyWithConfigKey, string targetAssemblyWithConfigValue)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TargetAssemblyWithConfigsInternal.Remove(targetAssemblyWithConfigKey, targetAssemblyWithConfigValue);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.OutputPath"/>.</i></p>
        /// <p>The report file output path.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetOutputPath(this XunitSettings xunitSettings, string outputPath)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.OutputPath = outputPath;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.NoLogo"/>.</i></p>
        /// <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNoLogo(this XunitSettings xunitSettings, bool noLogo)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoLogo = noLogo;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.NoLogo"/>.</i></p>
        /// <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableNoLogo(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoLogo = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.NoLogo"/>.</i></p>
        /// <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableNoLogo(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoLogo = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.NoLogo"/>.</i></p>
        /// <p>Do not show the copyright message.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleNoLogo(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoLogo = !xunitSettings.NoLogo;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.NoColor"/>.</i></p>
        /// <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNoColor(this XunitSettings xunitSettings, bool noColor)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoColor = noColor;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.NoColor"/>.</i></p>
        /// <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableNoColor(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoColor = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.NoColor"/>.</i></p>
        /// <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableNoColor(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoColor = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.NoColor"/>.</i></p>
        /// <p>Do not output results with colors.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleNoColor(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoColor = !xunitSettings.NoColor;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.NoAppDomain"/>.</i></p>
        /// <p>Do not use app domains to run test code.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNoAppDomain(this XunitSettings xunitSettings, bool noAppDomain)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAppDomain = noAppDomain;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.NoAppDomain"/>.</i></p>
        /// <p>Do not use app domains to run test code.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableNoAppDomain(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAppDomain = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.NoAppDomain"/>.</i></p>
        /// <p>Do not use app domains to run test code.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableNoAppDomain(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAppDomain = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.NoAppDomain"/>.</i></p>
        /// <p>Do not use app domains to run test code.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleNoAppDomain(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAppDomain = !xunitSettings.NoAppDomain;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.FailSkips"/>.</i></p>
        /// <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetFailSkips(this XunitSettings xunitSettings, bool failSkips)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.FailSkips = failSkips;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.FailSkips"/>.</i></p>
        /// <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableFailSkips(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.FailSkips = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.FailSkips"/>.</i></p>
        /// <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableFailSkips(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.FailSkips = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.FailSkips"/>.</i></p>
        /// <p>Convert skipped tests into failures.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleFailSkips(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.FailSkips = !xunitSettings.FailSkips;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Parallel"/>.</i></p>
        /// <p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p>
        /// </summary>
        [Pure]
        public static XunitSettings SetParallel(this XunitSettings xunitSettings, ParallelOption? parallel)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Parallel = parallel;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.MaxThreads"/>.</i></p>
        /// <p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p>
        /// </summary>
        [Pure]
        public static XunitSettings SetMaxThreads(this XunitSettings xunitSettings, int? maxThreads)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MaxThreads = maxThreads;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.NoShadowCopying"/>.</i></p>
        /// <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNoShadowCopying(this XunitSettings xunitSettings, bool noShadowCopying)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoShadowCopying = noShadowCopying;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.NoShadowCopying"/>.</i></p>
        /// <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableNoShadowCopying(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoShadowCopying = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.NoShadowCopying"/>.</i></p>
        /// <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableNoShadowCopying(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoShadowCopying = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.NoShadowCopying"/>.</i></p>
        /// <p>Do not shadow copy assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleNoShadowCopying(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoShadowCopying = !xunitSettings.NoShadowCopying;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Wait"/>.</i></p>
        /// <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetWait(this XunitSettings xunitSettings, bool wait)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Wait = wait;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.Wait"/>.</i></p>
        /// <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableWait(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Wait = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.Wait"/>.</i></p>
        /// <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableWait(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Wait = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.Wait"/>.</i></p>
        /// <p>Wait for input after completion.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleWait(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Wait = !xunitSettings.Wait;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Diagnostics"/>.</i></p>
        /// <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetDiagnostics(this XunitSettings xunitSettings, bool diagnostics)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Diagnostics = diagnostics;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.Diagnostics"/>.</i></p>
        /// <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableDiagnostics(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Diagnostics = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.Diagnostics"/>.</i></p>
        /// <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableDiagnostics(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Diagnostics = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.Diagnostics"/>.</i></p>
        /// <p>Enable diagnostics messages for all test assemblies.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleDiagnostics(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Diagnostics = !xunitSettings.Diagnostics;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Debug"/>.</i></p>
        /// <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetDebug(this XunitSettings xunitSettings, bool debug)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Debug = debug;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.Debug"/>.</i></p>
        /// <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableDebug(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Debug = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.Debug"/>.</i></p>
        /// <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableDebug(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Debug = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.Debug"/>.</i></p>
        /// <p>Launch the debugger to debug the tests.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleDebug(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Debug = !xunitSettings.Debug;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Serialization"/>.</i></p>
        /// <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetSerialization(this XunitSettings xunitSettings, bool serialization)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Serialization = serialization;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.Serialization"/>.</i></p>
        /// <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableSerialization(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Serialization = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.Serialization"/>.</i></p>
        /// <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableSerialization(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Serialization = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.Serialization"/>.</i></p>
        /// <p>Serialize all test cases (for diagnostic purposes only).</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleSerialization(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Serialization = !xunitSettings.Serialization;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Traits"/> to a new lookup table.</i></p>
        /// <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetTraits(this XunitSettings xunitSettings, ILookup<string, string> traits)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TraitsInternal = traits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="XunitSettings.Traits"/>.</i></p>
        /// <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ClearTraits(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TraitsInternal.Clear();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a trait to <see cref="XunitSettings.Traits"/>.</i></p>
        /// <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddTrait(this XunitSettings xunitSettings, string traitKey, string traitValue)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TraitsInternal.Add(traitKey, traitValue);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single trait entry from <see cref="XunitSettings.Traits"/>.</i></p>
        /// <p>Only run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings RemoveTrait(this XunitSettings xunitSettings, string traitKey, string traitValue)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.TraitsInternal.Remove(traitKey, traitValue);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.ExcludedTraits"/> to a new lookup table.</i></p>
        /// <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetExcludedTraits(this XunitSettings xunitSettings, ILookup<string, string> excludedTraits)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ExcludedTraitsInternal = excludedTraits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="XunitSettings.ExcludedTraits"/>.</i></p>
        /// <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings ClearExcludedTraits(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ExcludedTraitsInternal.Clear();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a excludedTrait to <see cref="XunitSettings.ExcludedTraits"/>.</i></p>
        /// <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddExcludedTrait(this XunitSettings xunitSettings, string excludedTraitKey, string excludedTraitValue)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ExcludedTraitsInternal.Add(excludedTraitKey, excludedTraitValue);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single excludedTrait entry from <see cref="XunitSettings.ExcludedTraits"/>.</i></p>
        /// <p>Do not run tests with matching name/value traits.</p>
        /// </summary>
        [Pure]
        public static XunitSettings RemoveExcludedTrait(this XunitSettings xunitSettings, string excludedTraitKey, string excludedTraitValue)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ExcludedTraitsInternal.Remove(excludedTraitKey, excludedTraitValue);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Methods"/> to a new list.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetMethods(this XunitSettings xunitSettings, params string[] methods)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal = methods.ToList();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Methods"/> to a new list.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetMethods(this XunitSettings xunitSettings, IEnumerable<string> methods)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal = methods.ToList();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new methods to the existing <see cref="XunitSettings.Methods"/>.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddMethods(this XunitSettings xunitSettings, params string[] methods)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal.AddRange(methods);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new methods to the existing <see cref="XunitSettings.Methods"/>.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddMethods(this XunitSettings xunitSettings, IEnumerable<string> methods)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal.AddRange(methods);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="XunitSettings.Methods"/>.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings ClearMethods(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal.Clear();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single method to <see cref="XunitSettings.Methods"/>.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddMethod(this XunitSettings xunitSettings, string method)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal.Add(method);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single method from <see cref="XunitSettings.Methods"/>.</i></p>
        /// <p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p>
        /// </summary>
        [Pure]
        public static XunitSettings RemoveMethod(this XunitSettings xunitSettings, string method)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.MethodsInternal.Remove(method);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Classes"/> to a new list.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetClasses(this XunitSettings xunitSettings, params string[] classes)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal = classes.ToList();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Classes"/> to a new list.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetClasses(this XunitSettings xunitSettings, IEnumerable<string> classes)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal = classes.ToList();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new classes to the existing <see cref="XunitSettings.Classes"/>.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddClasses(this XunitSettings xunitSettings, params string[] classes)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal.AddRange(classes);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new classes to the existing <see cref="XunitSettings.Classes"/>.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddClasses(this XunitSettings xunitSettings, IEnumerable<string> classes)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal.AddRange(classes);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="XunitSettings.Classes"/>.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings ClearClasses(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal.Clear();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single classe to <see cref="XunitSettings.Classes"/>.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddClasse(this XunitSettings xunitSettings, string classe)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal.Add(classe);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single classe from <see cref="XunitSettings.Classes"/>.</i></p>
        /// <p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p>
        /// </summary>
        [Pure]
        public static XunitSettings RemoveClasse(this XunitSettings xunitSettings, string classe)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ClassesInternal.Remove(classe);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Namespaces"/> to a new list.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNamespaces(this XunitSettings xunitSettings, params string[] nss)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal = nss.ToList();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Namespaces"/> to a new list.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNamespaces(this XunitSettings xunitSettings, IEnumerable<string> nss)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal = nss.ToList();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new nss to the existing <see cref="XunitSettings.Namespaces"/>.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddNamespaces(this XunitSettings xunitSettings, params string[] nss)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal.AddRange(nss);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new nss to the existing <see cref="XunitSettings.Namespaces"/>.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddNamespaces(this XunitSettings xunitSettings, IEnumerable<string> nss)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal.AddRange(nss);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="XunitSettings.Namespaces"/>.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings ClearNamespaces(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal.Clear();
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single ns to <see cref="XunitSettings.Namespaces"/>.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings AddNamespace(this XunitSettings xunitSettings, string ns)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal.Add(ns);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single ns from <see cref="XunitSettings.Namespaces"/>.</i></p>
        /// <p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p>
        /// </summary>
        [Pure]
        public static XunitSettings RemoveNamespace(this XunitSettings xunitSettings, string ns)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NamespacesInternal.Remove(ns);
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.NoAutoReporters"/>.</i></p>
        /// <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static XunitSettings SetNoAutoReporters(this XunitSettings xunitSettings, bool noAutoReporters)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAutoReporters = noAutoReporters;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="XunitSettings.NoAutoReporters"/>.</i></p>
        /// <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static XunitSettings EnableNoAutoReporters(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAutoReporters = true;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="XunitSettings.NoAutoReporters"/>.</i></p>
        /// <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static XunitSettings DisableNoAutoReporters(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAutoReporters = false;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="XunitSettings.NoAutoReporters"/>.</i></p>
        /// <p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p>
        /// </summary>
        [Pure]
        public static XunitSettings ToggleNoAutoReporters(this XunitSettings xunitSettings)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.NoAutoReporters = !xunitSettings.NoAutoReporters;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.Reporter"/>.</i></p>
        /// <p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p>
        /// </summary>
        [Pure]
        public static XunitSettings SetReporter(this XunitSettings xunitSettings, ReporterType? reporter)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.Reporter = reporter;
            return xunitSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="XunitSettings.ResultFormat"/>.</i></p>
        /// <p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p>
        /// </summary>
        [Pure]
        public static XunitSettings SetResultFormat(this XunitSettings xunitSettings, ResultFormat? resultFormat)
        {
            xunitSettings = xunitSettings.NewInstance();
            xunitSettings.ResultFormat = resultFormat;
            return xunitSettings;
        }
    }
    /// <summary>
    /// <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
    /// <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum ReporterType
    {
        AppVeyor,
        JSON,
        Quiet,
        TeamCity,
        Verbose
    }
    /// <summary>
    /// <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
    /// <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum ResultFormat
    {
        Xml,
        XmlV1,
        NUnit,
        HTML
    }
    /// <summary>
    /// <p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p>
    /// <p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum ParallelOption
    {
        None,
        Collections,
        Assemblies,
        All
    }
}
