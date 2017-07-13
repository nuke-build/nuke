// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

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

[assembly: IconClass(typeof(Nuke.Common.Tools.Xunit2.Xunit2Tasks), "bug2")]

namespace Nuke.Common.Tools.Xunit2
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class Xunit2Tasks
    {
        static partial void PreProcess (Xunit2Settings toolSettings);
        static partial void PostProcess (Xunit2Settings toolSettings);
        /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
        public static void Xunit2 (Configure<Xunit2Settings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new Xunit2Settings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            AssertProcess(process, toolSettings);
            PostProcess(toolSettings);
        }
    }
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Xunit2Settings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"xunit.runner.console", packageExecutable: $"{GetPackageExecutable()}");
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
    public static partial class Xunit2SettingsExtensions
    {
        /// <summary><p><i>Sets <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/> to a new lookup table.</i></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings SetTargetAssemblyWithConfigs(this Xunit2Settings toolSettings, ILookup<string, string> targetAssemblyWithConfigs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal = targetAssemblyWithConfigs.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</i></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings ClearTargetAssemblyWithConfigs(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a targetAssemblyWithConfig to <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</i></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings AddTargetAssemblyWithConfig(this Xunit2Settings toolSettings, string targetAssemblyWithConfigKey, string targetAssemblyWithConfigValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Add(targetAssemblyWithConfigKey, targetAssemblyWithConfigValue);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single targetAssemblyWithConfig entry from <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</i></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings RemoveTargetAssemblyWithConfig(this Xunit2Settings toolSettings, string targetAssemblyWithConfigKey, string targetAssemblyWithConfigValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Remove(targetAssemblyWithConfigKey, targetAssemblyWithConfigValue);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.OutputPath"/>.</i></p><p>The report file output path.</p></summary>
        [Pure]
        public static Xunit2Settings SetOutputPath(this Xunit2Settings toolSettings, string outputPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputPath = outputPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.NoLogo"/>.</i></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoLogo(this Xunit2Settings toolSettings, bool noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.NoLogo"/>.</i></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.NoLogo"/>.</i></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.NoLogo"/>.</i></p><p>Do not show the copyright message.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoLogo(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.NoColor"/>.</i></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoColor(this Xunit2Settings toolSettings, bool noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.NoColor"/>.</i></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.NoColor"/>.</i></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.NoColor"/>.</i></p><p>Do not output results with colors.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoColor(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.NoAppDomain"/>.</i></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoAppDomain(this Xunit2Settings toolSettings, bool noAppDomain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = noAppDomain;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.NoAppDomain"/>.</i></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.NoAppDomain"/>.</i></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.NoAppDomain"/>.</i></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = !toolSettings.NoAppDomain;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.FailSkips"/>.</i></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings SetFailSkips(this Xunit2Settings toolSettings, bool failSkips)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = failSkips;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.FailSkips"/>.</i></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings EnableFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.FailSkips"/>.</i></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings DisableFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.FailSkips"/>.</i></p><p>Convert skipped tests into failures.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleFailSkips(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailSkips = !toolSettings.FailSkips;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Parallel"/>.</i></p><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetParallel(this Xunit2Settings toolSettings, ParallelOption? parallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = parallel;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.MaxThreads"/>.</i></p><p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetMaxThreads(this Xunit2Settings toolSettings, int? maxThreads)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxThreads = maxThreads;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.NoShadowCopying"/>.</i></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoShadowCopying(this Xunit2Settings toolSettings, bool noShadowCopying)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = noShadowCopying;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.NoShadowCopying"/>.</i></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.NoShadowCopying"/>.</i></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.NoShadowCopying"/>.</i></p><p>Do not shadow copy assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoShadowCopying(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShadowCopying = !toolSettings.NoShadowCopying;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Wait"/>.</i></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings SetWait(this Xunit2Settings toolSettings, bool wait)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.Wait"/>.</i></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings EnableWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.Wait"/>.</i></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings DisableWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.Wait"/>.</i></p><p>Wait for input after completion.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleWait(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Diagnostics"/>.</i></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings SetDiagnostics(this Xunit2Settings toolSettings, bool diagnostics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = diagnostics;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.Diagnostics"/>.</i></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings EnableDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.Diagnostics"/>.</i></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings DisableDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.Diagnostics"/>.</i></p><p>Enable diagnostics messages for all test assemblies.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleDiagnostics(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = !toolSettings.Diagnostics;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Debug"/>.</i></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings SetDebug(this Xunit2Settings toolSettings, bool debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.Debug"/>.</i></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings EnableDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.Debug"/>.</i></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings DisableDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.Debug"/>.</i></p><p>Launch the debugger to debug the tests.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleDebug(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Serialization"/>.</i></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings SetSerialization(this Xunit2Settings toolSettings, bool serialization)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = serialization;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.Serialization"/>.</i></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings EnableSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.Serialization"/>.</i></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings DisableSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.Serialization"/>.</i></p><p>Serialize all test cases (for diagnostic purposes only).</p></summary>
        [Pure]
        public static Xunit2Settings ToggleSerialization(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serialization = !toolSettings.Serialization;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Traits"/> to a new lookup table.</i></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings SetTraits(this Xunit2Settings toolSettings, ILookup<string, string> traits)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal = traits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="Xunit2Settings.Traits"/>.</i></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings ClearTraits(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a trait to <see cref="Xunit2Settings.Traits"/>.</i></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddTrait(this Xunit2Settings toolSettings, string traitKey, string traitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Add(traitKey, traitValue);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single trait entry from <see cref="Xunit2Settings.Traits"/>.</i></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings RemoveTrait(this Xunit2Settings toolSettings, string traitKey, string traitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Remove(traitKey, traitValue);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.ExcludedTraits"/> to a new lookup table.</i></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings SetExcludedTraits(this Xunit2Settings toolSettings, ILookup<string, string> excludedTraits)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal = excludedTraits.ToLookupTable(StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="Xunit2Settings.ExcludedTraits"/>.</i></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings ClearExcludedTraits(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a excludedTrait to <see cref="Xunit2Settings.ExcludedTraits"/>.</i></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddExcludedTrait(this Xunit2Settings toolSettings, string excludedTraitKey, string excludedTraitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Add(excludedTraitKey, excludedTraitValue);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single excludedTrait entry from <see cref="Xunit2Settings.ExcludedTraits"/>.</i></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings RemoveExcludedTrait(this Xunit2Settings toolSettings, string excludedTraitKey, string excludedTraitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Remove(excludedTraitKey, excludedTraitValue);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Methods"/> to a new list.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings SetMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Methods"/> to a new list.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings SetMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds new methods to the existing <see cref="Xunit2Settings.Methods"/>.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary><p><i>Adds new methods to the existing <see cref="Xunit2Settings.Methods"/>.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="Xunit2Settings.Methods"/>.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings ClearMethods(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single method to <see cref="Xunit2Settings.Methods"/>.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethod(this Xunit2Settings toolSettings, string method, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (method != null || evenIfNull) toolSettings.MethodsInternal.Add(method);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single method from <see cref="Xunit2Settings.Methods"/>.</i></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveMethod(this Xunit2Settings toolSettings, string method)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.Remove(method);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Classes"/> to a new list.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings SetClasses(this Xunit2Settings toolSettings, params string[] classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal = classes.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Classes"/> to a new list.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings SetClasses(this Xunit2Settings toolSettings, IEnumerable<string> classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal = classes.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds new classes to the existing <see cref="Xunit2Settings.Classes"/>.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings AddClasses(this Xunit2Settings toolSettings, params string[] classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.AddRange(classes);
            return toolSettings;
        }
        /// <summary><p><i>Adds new classes to the existing <see cref="Xunit2Settings.Classes"/>.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings AddClasses(this Xunit2Settings toolSettings, IEnumerable<string> classes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.AddRange(classes);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="Xunit2Settings.Classes"/>.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings ClearClasses(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single classe to <see cref="Xunit2Settings.Classes"/>.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings AddClasse(this Xunit2Settings toolSettings, string classe, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (classe != null || evenIfNull) toolSettings.ClassesInternal.Add(classe);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single classe from <see cref="Xunit2Settings.Classes"/>.</i></p><p>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveClasse(this Xunit2Settings toolSettings, string classe)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassesInternal.Remove(classe);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Namespaces"/> to a new list.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings SetNamespaces(this Xunit2Settings toolSettings, params string[] nss)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal = nss.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Namespaces"/> to a new list.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings SetNamespaces(this Xunit2Settings toolSettings, IEnumerable<string> nss)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal = nss.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds new nss to the existing <see cref="Xunit2Settings.Namespaces"/>.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings AddNamespaces(this Xunit2Settings toolSettings, params string[] nss)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.AddRange(nss);
            return toolSettings;
        }
        /// <summary><p><i>Adds new nss to the existing <see cref="Xunit2Settings.Namespaces"/>.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings AddNamespaces(this Xunit2Settings toolSettings, IEnumerable<string> nss)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.AddRange(nss);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="Xunit2Settings.Namespaces"/>.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings ClearNamespaces(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single ns to <see cref="Xunit2Settings.Namespaces"/>.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings AddNamespace(this Xunit2Settings toolSettings, string ns, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (ns != null || evenIfNull) toolSettings.NamespacesInternal.Add(ns);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single ns from <see cref="Xunit2Settings.Namespaces"/>.</i></p><p>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveNamespace(this Xunit2Settings toolSettings, string ns)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NamespacesInternal.Remove(ns);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.NoAutoReporters"/>.</i></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings SetNoAutoReporters(this Xunit2Settings toolSettings, bool noAutoReporters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = noAutoReporters;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="Xunit2Settings.NoAutoReporters"/>.</i></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="Xunit2Settings.NoAutoReporters"/>.</i></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="Xunit2Settings.NoAutoReporters"/>.</i></p><p>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoAutoReporters(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAutoReporters = !toolSettings.NoAutoReporters;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.Reporter"/>.</i></p><p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetReporter(this Xunit2Settings toolSettings, ReporterType? reporter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reporter = reporter;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="Xunit2Settings.ResultFormat"/>.</i></p><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetResultFormat(this Xunit2Settings toolSettings, ResultFormat? resultFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultFormat = resultFormat;
            return toolSettings;
        }
    }
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p></summary>
    [PublicAPI]
    public enum ReporterType
    {
        AppVeyor,
        JSON,
        Quiet,
        TeamCity,
        Verbose,
    }
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p></summary>
    [PublicAPI]
    public enum ResultFormat
    {
        Xml,
        XmlV1,
        NUnit,
        HTML,
    }
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p></summary>
    [PublicAPI]
    public enum ParallelOption
    {
        None,
        Collections,
        Assemblies,
        All,
    }
}
