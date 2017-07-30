// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated from https://github.com/nuke-build/tools/blob/master/Xunit2.json with Nuke.ToolGenerator.

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
    #region Xunit2Settings
    /// <summary><p>Used within <see cref="Xunit2Tasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class Xunit2Settings : ToolSettings
    {
        /// <summary><p>Path to the Xunit2 executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetPackageExecutable($"xunit.runner.console", $"{GetPackageExecutable()}");
        /// <summary><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        public virtual ILookup<string, string> TargetAssemblyWithConfigs => TargetAssemblyWithConfigsInternal.AsReadOnly();
        internal LookupTable<string, string> TargetAssemblyWithConfigsInternal { get; set; } = new LookupTable<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Do not show the copyright message.</p></summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary><p>Do not output results with colors.</p></summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary><p>Do not use app domains to run test code.</p></summary>
        public virtual bool? NoAppDomain { get; internal set; }
        /// <summary><p>Convert skipped tests into failures.</p></summary>
        public virtual bool? FailSkips { get; internal set; }
        /// <summary><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        public virtual ParallelOption Parallel { get; internal set; }
        /// <summary><p>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></p></summary>
        public virtual int? MaxThreads { get; internal set; }
        /// <summary><p>Do not shadow copy assemblies.</p></summary>
        public virtual bool? NoShadowCopying { get; internal set; }
        /// <summary><p>Wait for input after completion.</p></summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary><p>Enable diagnostics messages for all test assemblies.</p></summary>
        public virtual bool? Diagnostics { get; internal set; }
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
        public virtual bool? NoAutoReporters { get; internal set; }
        /// <summary><p>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></p></summary>
        public virtual ReporterType Reporter { get; internal set; }
        /// <summary><p>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></p></summary>
        public virtual ResultFormat ResultFormat { get; internal set; }
        /// <summary><p>The result file output path.</p></summary>
        public virtual string ResultPath { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", TargetAssemblyWithConfigs, keyValueSeparator: ' ')
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
              .Add("-trait {value}", Traits, keyValueSeparator: '=')
              .Add("-notrait {value}", ExcludedTraits, keyValueSeparator: '=')
              .Add("-method {value}", Methods)
              .Add("-class {value}", Classes)
              .Add("-namespace {value}", Namespaces)
              .Add("-noautoreporters", NoAutoReporters)
              .Add("-{value}", Reporter)
              .Add("-{value}", ResultFormat)
              .Add("{value}", ResultPath);
        }
    }
    #endregion
    #region Xunit2SettingsExtensions
    /// <summary><p>Used within <see cref="Xunit2Tasks"/>.</p></summary>
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
        /// <summary><p><em>Adds a targetAssemblyWithConfig to the existing <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings AddTargetAssemblyWithConfig(this Xunit2Settings toolSettings, string targetAssemblyWithConfigKey, string targetAssemblyWithConfigValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Add(targetAssemblyWithConfigKey, targetAssemblyWithConfigValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single targetAssemblyWithConfig from <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/>.</em></p><p>Assemblies to test, and their related related configuration files (ending with .json or .config).</p></summary>
        [Pure]
        public static Xunit2Settings RemoveTargetAssemblyWithConfig(this Xunit2Settings toolSettings, string targetAssemblyWithConfigKey, string targetAssemblyWithConfigValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetAssemblyWithConfigsInternal.Remove(targetAssemblyWithConfigKey, targetAssemblyWithConfigValue);
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
        #region NoAppDomain
        /// <summary><p><em>Sets <see cref="Xunit2Settings.NoAppDomain"/>.</em></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings SetNoAppDomain(this Xunit2Settings toolSettings, bool? noAppDomain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = noAppDomain;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="Xunit2Settings.NoAppDomain"/>.</em></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings ResetNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="Xunit2Settings.NoAppDomain"/>.</em></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings EnableNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="Xunit2Settings.NoAppDomain"/>.</em></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings DisableNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="Xunit2Settings.NoAppDomain"/>.</em></p><p>Do not use app domains to run test code.</p></summary>
        [Pure]
        public static Xunit2Settings ToggleNoAppDomain(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppDomain = !toolSettings.NoAppDomain;
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
        #region Parallel
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Parallel"/>.</em></p><p>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></p></summary>
        [Pure]
        public static Xunit2Settings SetParallel(this Xunit2Settings toolSettings, ParallelOption parallel)
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
        /// <summary><p><em>Adds a trait to the existing <see cref="Xunit2Settings.Traits"/>.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddTrait(this Xunit2Settings toolSettings, string traitKey, string traitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Add(traitKey, traitValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single trait from <see cref="Xunit2Settings.Traits"/>.</em></p><p>Only run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings RemoveTrait(this Xunit2Settings toolSettings, string traitKey, string traitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TraitsInternal.Remove(traitKey, traitValue);
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
        /// <summary><p><em>Adds a excludedTrait to the existing <see cref="Xunit2Settings.ExcludedTraits"/>.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings AddExcludedTrait(this Xunit2Settings toolSettings, string excludedTraitKey, string excludedTraitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Add(excludedTraitKey, excludedTraitValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single excludedTrait from <see cref="Xunit2Settings.ExcludedTraits"/>.</em></p><p>Do not run tests with matching name/value traits.</p></summary>
        [Pure]
        public static Xunit2Settings RemoveExcludedTrait(this Xunit2Settings toolSettings, string excludedTraitKey, string excludedTraitValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTraitsInternal.Remove(excludedTraitKey, excludedTraitValue);
            return toolSettings;
        }
        #endregion
        #region Methods
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Methods"/> to a new list.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings SetMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="Xunit2Settings.Methods"/> to a new list.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings SetMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal = methods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings AddMethods(this Xunit2Settings toolSettings, IEnumerable<string> methods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.AddRange(methods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings ClearMethods(this Xunit2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
        [Pure]
        public static Xunit2Settings RemoveMethods(this Xunit2Settings toolSettings, params string[] methods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(methods);
            toolSettings.MethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="Xunit2Settings.Methods"/>.</em></p><p>Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod').</p></summary>
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
        public static Xunit2Settings SetReporter(this Xunit2Settings toolSettings, ReporterType reporter)
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
    }
    #endregion
    #region ReporterType
    /// <summary><p>Used within <see cref="Xunit2Tasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class ReporterType : Enumeration
    {
        public static ReporterType AppVeyor = new ReporterType { Value = "AppVeyor" };
        public static ReporterType JSON = new ReporterType { Value = "JSON" };
        public static ReporterType Quiet = new ReporterType { Value = "Quiet" };
        public static ReporterType TeamCity = new ReporterType { Value = "TeamCity" };
        public static ReporterType Verbose = new ReporterType { Value = "Verbose" };
    }
    #endregion
    #region ResultFormat
    /// <summary><p>Used within <see cref="Xunit2Tasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class ResultFormat : Enumeration
    {
        public static ResultFormat Xml = new ResultFormat { Value = "Xml" };
        public static ResultFormat XmlV1 = new ResultFormat { Value = "XmlV1" };
        public static ResultFormat NUnit = new ResultFormat { Value = "NUnit" };
        public static ResultFormat HTML = new ResultFormat { Value = "HTML" };
    }
    #endregion
    #region ParallelOption
    /// <summary><p>Used within <see cref="Xunit2Tasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class ParallelOption : Enumeration
    {
        public static ParallelOption None = new ParallelOption { Value = "None" };
        public static ParallelOption Collections = new ParallelOption { Value = "Collections" };
        public static ParallelOption Assemblies = new ParallelOption { Value = "Assemblies" };
        public static ParallelOption All = new ParallelOption { Value = "All" };
    }
    #endregion
}
