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

namespace Nuke.Common.Tools.Xunit;

/// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId)]
public partial class XunitTasks : ToolTasks, IRequireNuGetPackage
{
    public static string XunitPath => new XunitTasks().GetToolPath();
    public const string PackageId = "xunit.runner.console";
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Xunit(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new XunitTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetAssemblyWithConfigs&gt;</c> via <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></li><li><c>-</c> via <see cref="Xunit2Settings.Reporter"/></li><li><c>-</c> via <see cref="Xunit2Settings.ResultReports"/></li><li><c>-appdomains</c> via <see cref="Xunit2Settings.AppDomainMode"/></li><li><c>-class</c> via <see cref="Xunit2Settings.Classes"/></li><li><c>-debug</c> via <see cref="Xunit2Settings.Debug"/></li><li><c>-diagnostics</c> via <see cref="Xunit2Settings.Diagnostics"/></li><li><c>-failskips</c> via <see cref="Xunit2Settings.FailSkips"/></li><li><c>-maxthreads</c> via <see cref="Xunit2Settings.MaxThreads"/></li><li><c>-method</c> via <see cref="Xunit2Settings.Methods"/></li><li><c>-namespace</c> via <see cref="Xunit2Settings.Namespaces"/></li><li><c>-noautoreporters</c> via <see cref="Xunit2Settings.NoAutoReporters"/></li><li><c>-nocolor</c> via <see cref="Xunit2Settings.NoColor"/></li><li><c>-nologo</c> via <see cref="Xunit2Settings.NoLogo"/></li><li><c>-noshadow</c> via <see cref="Xunit2Settings.NoShadowCopying"/></li><li><c>-notrait</c> via <see cref="Xunit2Settings.ExcludedTraits"/></li><li><c>-parallel</c> via <see cref="Xunit2Settings.Parallel"/></li><li><c>-pause</c> via <see cref="Xunit2Settings.Pause"/></li><li><c>-serialize</c> via <see cref="Xunit2Settings.Serialization"/></li><li><c>-stoponfail</c> via <see cref="Xunit2Settings.StopOnFail"/></li><li><c>-trait</c> via <see cref="Xunit2Settings.Traits"/></li><li><c>-wait</c> via <see cref="Xunit2Settings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Xunit2(Xunit2Settings options = null) => new XunitTasks().Run(options);
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetAssemblyWithConfigs&gt;</c> via <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></li><li><c>-</c> via <see cref="Xunit2Settings.Reporter"/></li><li><c>-</c> via <see cref="Xunit2Settings.ResultReports"/></li><li><c>-appdomains</c> via <see cref="Xunit2Settings.AppDomainMode"/></li><li><c>-class</c> via <see cref="Xunit2Settings.Classes"/></li><li><c>-debug</c> via <see cref="Xunit2Settings.Debug"/></li><li><c>-diagnostics</c> via <see cref="Xunit2Settings.Diagnostics"/></li><li><c>-failskips</c> via <see cref="Xunit2Settings.FailSkips"/></li><li><c>-maxthreads</c> via <see cref="Xunit2Settings.MaxThreads"/></li><li><c>-method</c> via <see cref="Xunit2Settings.Methods"/></li><li><c>-namespace</c> via <see cref="Xunit2Settings.Namespaces"/></li><li><c>-noautoreporters</c> via <see cref="Xunit2Settings.NoAutoReporters"/></li><li><c>-nocolor</c> via <see cref="Xunit2Settings.NoColor"/></li><li><c>-nologo</c> via <see cref="Xunit2Settings.NoLogo"/></li><li><c>-noshadow</c> via <see cref="Xunit2Settings.NoShadowCopying"/></li><li><c>-notrait</c> via <see cref="Xunit2Settings.ExcludedTraits"/></li><li><c>-parallel</c> via <see cref="Xunit2Settings.Parallel"/></li><li><c>-pause</c> via <see cref="Xunit2Settings.Pause"/></li><li><c>-serialize</c> via <see cref="Xunit2Settings.Serialization"/></li><li><c>-stoponfail</c> via <see cref="Xunit2Settings.StopOnFail"/></li><li><c>-trait</c> via <see cref="Xunit2Settings.Traits"/></li><li><c>-wait</c> via <see cref="Xunit2Settings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Xunit2(Configure<Xunit2Settings> configurator) => new XunitTasks().Run(configurator.Invoke(new Xunit2Settings()));
    /// <summary><p>xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href="https://www.dotnetfoundation.org/">.NET Foundation</a>, and operates under their <a href="https://www.dotnetfoundation.org/code-of-conduct">code of conduct</a>. It is licensed under <a href="https://opensource.org/licenses/Apache-2.0">Apache 2</a> (an OSI approved license).</p><p>For more details, visit the <a href="https://xunit.github.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetAssemblyWithConfigs&gt;</c> via <see cref="Xunit2Settings.TargetAssemblyWithConfigs"/></li><li><c>-</c> via <see cref="Xunit2Settings.Reporter"/></li><li><c>-</c> via <see cref="Xunit2Settings.ResultReports"/></li><li><c>-appdomains</c> via <see cref="Xunit2Settings.AppDomainMode"/></li><li><c>-class</c> via <see cref="Xunit2Settings.Classes"/></li><li><c>-debug</c> via <see cref="Xunit2Settings.Debug"/></li><li><c>-diagnostics</c> via <see cref="Xunit2Settings.Diagnostics"/></li><li><c>-failskips</c> via <see cref="Xunit2Settings.FailSkips"/></li><li><c>-maxthreads</c> via <see cref="Xunit2Settings.MaxThreads"/></li><li><c>-method</c> via <see cref="Xunit2Settings.Methods"/></li><li><c>-namespace</c> via <see cref="Xunit2Settings.Namespaces"/></li><li><c>-noautoreporters</c> via <see cref="Xunit2Settings.NoAutoReporters"/></li><li><c>-nocolor</c> via <see cref="Xunit2Settings.NoColor"/></li><li><c>-nologo</c> via <see cref="Xunit2Settings.NoLogo"/></li><li><c>-noshadow</c> via <see cref="Xunit2Settings.NoShadowCopying"/></li><li><c>-notrait</c> via <see cref="Xunit2Settings.ExcludedTraits"/></li><li><c>-parallel</c> via <see cref="Xunit2Settings.Parallel"/></li><li><c>-pause</c> via <see cref="Xunit2Settings.Pause"/></li><li><c>-serialize</c> via <see cref="Xunit2Settings.Serialization"/></li><li><c>-stoponfail</c> via <see cref="Xunit2Settings.StopOnFail"/></li><li><c>-trait</c> via <see cref="Xunit2Settings.Traits"/></li><li><c>-wait</c> via <see cref="Xunit2Settings.Wait"/></li></ul></remarks>
    public static IEnumerable<(Xunit2Settings Settings, IReadOnlyCollection<Output> Output)> Xunit2(CombinatorialConfigure<Xunit2Settings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Xunit2, degreeOfParallelism, completeOnFailure);
}
#region Xunit2Settings
/// <summary>Used within <see cref="XunitTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<Xunit2Settings>))]
[Command(Type = typeof(XunitTasks), Command = nameof(XunitTasks.Xunit2))]
public partial class Xunit2Settings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Argument(Format = "{key} {value}", Position = 1)] public ILookup<string, string> TargetAssemblyWithConfigs => Get<LookupTable<string, string>>(() => TargetAssemblyWithConfigs);
    /// <summary>Do not show the copyright message.</summary>
    [Argument(Format = "-nologo")] public bool? NoLogo => Get<bool?>(() => NoLogo);
    /// <summary>Do not output results with colors.</summary>
    [Argument(Format = "-nocolor")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Convert skipped tests into failures.</summary>
    [Argument(Format = "-failskips")] public bool? FailSkips => Get<bool?>(() => FailSkips);
    /// <summary>Stop on first test failure.</summary>
    [Argument(Format = "-stoponfail")] public bool? StopOnFail => Get<bool?>(() => StopOnFail);
    /// <summary>Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul></summary>
    [Argument(Format = "-parallel {value}")] public Xunit2ParallelOption Parallel => Get<Xunit2ParallelOption>(() => Parallel);
    /// <summary>Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul></summary>
    [Argument(Format = "-maxthreads {value}")] public int? MaxThreads => Get<int?>(() => MaxThreads);
    /// <summary>AppDomain modes:<ul><li><c>-ifavailable</c>: choose based on library type</li><li><c>-required</c>: force app domains on</li><li><c>-denied</c>: force app domains off</li></ul></summary>
    [Argument(Format = "-appdomains {value}")] public Xunit2AppDomainMode AppDomainMode => Get<Xunit2AppDomainMode>(() => AppDomainMode);
    /// <summary>Do not shadow copy assemblies.</summary>
    [Argument(Format = "-noshadow")] public bool? NoShadowCopying => Get<bool?>(() => NoShadowCopying);
    /// <summary>Wait for input after completion.</summary>
    [Argument(Format = "-wait")] public bool? Wait => Get<bool?>(() => Wait);
    /// <summary>Enable diagnostics messages for all test assemblies.</summary>
    [Argument(Format = "-diagnostics")] public bool? Diagnostics => Get<bool?>(() => Diagnostics);
    /// <summary>Pause before doing any work, to help attach a debugger.</summary>
    [Argument(Format = "-pause")] public bool? Pause => Get<bool?>(() => Pause);
    /// <summary>Launch the debugger to debug the tests.</summary>
    [Argument(Format = "-debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Serialize all test cases (for diagnostic purposes only).</summary>
    [Argument(Format = "-serialize")] public bool? Serialization => Get<bool?>(() => Serialization);
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Argument(Format = "-trait {key}={value}")] public ILookup<string, string> Traits => Get<LookupTable<string, string>>(() => Traits);
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Argument(Format = "-notrait {key}={value}")] public ILookup<string, string> ExcludedTraits => Get<LookupTable<string, string>>(() => ExcludedTraits);
    /// <summary>Run a given test method (can be fully specified or use a wildcard; i.e., 'MyNamespace.MyClass.MyTestMethod' or '*.MyTestMethod').</summary>
    [Argument(Format = "-method {value}")] public IReadOnlyList<string> Methods => Get<List<string>>(() => Methods);
    /// <summary>Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass').</summary>
    [Argument(Format = "-class {value}")] public IReadOnlyList<string> Classes => Get<List<string>>(() => Classes);
    /// <summary>Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace').</summary>
    [Argument(Format = "-namespace {value}")] public IReadOnlyList<string> Namespaces => Get<List<string>>(() => Namespaces);
    /// <summary>Do not allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor).</summary>
    [Argument(Format = "-noautoreporters")] public bool? NoAutoReporters => Get<bool?>(() => NoAutoReporters);
    /// <summary>Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul></summary>
    [Argument(Format = "-{value}")] public Xunit2ReporterType Reporter => Get<Xunit2ReporterType>(() => Reporter);
    /// <summary>Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul></summary>
    [Argument(Format = "-{key} {value}")] public IReadOnlyDictionary<Xunit2ResultFormat, string> ResultReports => Get<Dictionary<Xunit2ResultFormat, string>>(() => ResultReports);
}
#endregion
#region Xunit2SettingsExtensions
/// <summary>Used within <see cref="XunitTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class Xunit2SettingsExtensions
{
    #region TargetAssemblyWithConfigs
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T SetTargetAssemblyWithConfigs<T>(this T o, string k, params string[] v) where T : Xunit2Settings => o.Modify(b => b.SetLookup(() => o.TargetAssemblyWithConfigs, k, v));
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T SetTargetAssemblyWithConfigs<T>(this T o, string k, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.SetLookup(() => o.TargetAssemblyWithConfigs, k, v));
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T AddTargetAssemblyWithConfigs<T>(this T o, string k, params string[] v) where T : Xunit2Settings => o.Modify(b => b.AddLookup(() => o.TargetAssemblyWithConfigs, k, v));
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T AddTargetAssemblyWithConfigs<T>(this T o, string k, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.AddLookup(() => o.TargetAssemblyWithConfigs, k, v));
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T RemoveTargetAssemblyWithConfigs<T>(this T o, string k) where T : Xunit2Settings => o.Modify(b => b.RemoveLookup(() => o.TargetAssemblyWithConfigs, k));
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T RemoveTargetAssemblyWithConfigs<T>(this T o, string k, string v) where T : Xunit2Settings => o.Modify(b => b.RemoveLookup(() => o.TargetAssemblyWithConfigs, k, v));
    /// <summary>Assemblies to test, and their related related configuration files (ending with .json or .config).</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.TargetAssemblyWithConfigs))]
    public static T ResetTargetAssemblyWithConfigs<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearLookup(() => o.TargetAssemblyWithConfigs));
    #endregion
    #region NoLogo
    /// <inheritdoc cref="Xunit2Settings.NoLogo"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoLogo))]
    public static T SetNoLogo<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoLogo, v));
    /// <inheritdoc cref="Xunit2Settings.NoLogo"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoLogo))]
    public static T ResetNoLogo<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.NoLogo));
    /// <inheritdoc cref="Xunit2Settings.NoLogo"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoLogo))]
    public static T EnableNoLogo<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoLogo, true));
    /// <inheritdoc cref="Xunit2Settings.NoLogo"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoLogo))]
    public static T DisableNoLogo<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoLogo, false));
    /// <inheritdoc cref="Xunit2Settings.NoLogo"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoLogo))]
    public static T ToggleNoLogo<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoLogo, !o.NoLogo));
    #endregion
    #region NoColor
    /// <inheritdoc cref="Xunit2Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="Xunit2Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="Xunit2Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="Xunit2Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="Xunit2Settings.NoColor"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region FailSkips
    /// <inheritdoc cref="Xunit2Settings.FailSkips"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.FailSkips))]
    public static T SetFailSkips<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.FailSkips, v));
    /// <inheritdoc cref="Xunit2Settings.FailSkips"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.FailSkips))]
    public static T ResetFailSkips<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.FailSkips));
    /// <inheritdoc cref="Xunit2Settings.FailSkips"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.FailSkips))]
    public static T EnableFailSkips<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.FailSkips, true));
    /// <inheritdoc cref="Xunit2Settings.FailSkips"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.FailSkips))]
    public static T DisableFailSkips<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.FailSkips, false));
    /// <inheritdoc cref="Xunit2Settings.FailSkips"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.FailSkips))]
    public static T ToggleFailSkips<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.FailSkips, !o.FailSkips));
    #endregion
    #region StopOnFail
    /// <inheritdoc cref="Xunit2Settings.StopOnFail"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.StopOnFail))]
    public static T SetStopOnFail<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.StopOnFail, v));
    /// <inheritdoc cref="Xunit2Settings.StopOnFail"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.StopOnFail))]
    public static T ResetStopOnFail<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.StopOnFail));
    /// <inheritdoc cref="Xunit2Settings.StopOnFail"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.StopOnFail))]
    public static T EnableStopOnFail<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.StopOnFail, true));
    /// <inheritdoc cref="Xunit2Settings.StopOnFail"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.StopOnFail))]
    public static T DisableStopOnFail<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.StopOnFail, false));
    /// <inheritdoc cref="Xunit2Settings.StopOnFail"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.StopOnFail))]
    public static T ToggleStopOnFail<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.StopOnFail, !o.StopOnFail));
    #endregion
    #region Parallel
    /// <inheritdoc cref="Xunit2Settings.Parallel"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Parallel))]
    public static T SetParallel<T>(this T o, Xunit2ParallelOption v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="Xunit2Settings.Parallel"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Parallel));
    #endregion
    #region MaxThreads
    /// <inheritdoc cref="Xunit2Settings.MaxThreads"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.MaxThreads))]
    public static T SetMaxThreads<T>(this T o, int? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.MaxThreads, v));
    /// <inheritdoc cref="Xunit2Settings.MaxThreads"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.MaxThreads))]
    public static T ResetMaxThreads<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.MaxThreads));
    #endregion
    #region AppDomainMode
    /// <inheritdoc cref="Xunit2Settings.AppDomainMode"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.AppDomainMode))]
    public static T SetAppDomainMode<T>(this T o, Xunit2AppDomainMode v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.AppDomainMode, v));
    /// <inheritdoc cref="Xunit2Settings.AppDomainMode"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.AppDomainMode))]
    public static T ResetAppDomainMode<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.AppDomainMode));
    #endregion
    #region NoShadowCopying
    /// <inheritdoc cref="Xunit2Settings.NoShadowCopying"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoShadowCopying))]
    public static T SetNoShadowCopying<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoShadowCopying, v));
    /// <inheritdoc cref="Xunit2Settings.NoShadowCopying"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoShadowCopying))]
    public static T ResetNoShadowCopying<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.NoShadowCopying));
    /// <inheritdoc cref="Xunit2Settings.NoShadowCopying"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoShadowCopying))]
    public static T EnableNoShadowCopying<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoShadowCopying, true));
    /// <inheritdoc cref="Xunit2Settings.NoShadowCopying"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoShadowCopying))]
    public static T DisableNoShadowCopying<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoShadowCopying, false));
    /// <inheritdoc cref="Xunit2Settings.NoShadowCopying"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoShadowCopying))]
    public static T ToggleNoShadowCopying<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoShadowCopying, !o.NoShadowCopying));
    #endregion
    #region Wait
    /// <inheritdoc cref="Xunit2Settings.Wait"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Wait))]
    public static T SetWait<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Wait, v));
    /// <inheritdoc cref="Xunit2Settings.Wait"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Wait))]
    public static T ResetWait<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Wait));
    /// <inheritdoc cref="Xunit2Settings.Wait"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Wait))]
    public static T EnableWait<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Wait, true));
    /// <inheritdoc cref="Xunit2Settings.Wait"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Wait))]
    public static T DisableWait<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Wait, false));
    /// <inheritdoc cref="Xunit2Settings.Wait"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Wait))]
    public static T ToggleWait<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Wait, !o.Wait));
    #endregion
    #region Diagnostics
    /// <inheritdoc cref="Xunit2Settings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Diagnostics))]
    public static T SetDiagnostics<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Diagnostics, v));
    /// <inheritdoc cref="Xunit2Settings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Diagnostics))]
    public static T ResetDiagnostics<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Diagnostics));
    /// <inheritdoc cref="Xunit2Settings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Diagnostics))]
    public static T EnableDiagnostics<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Diagnostics, true));
    /// <inheritdoc cref="Xunit2Settings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Diagnostics))]
    public static T DisableDiagnostics<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Diagnostics, false));
    /// <inheritdoc cref="Xunit2Settings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Diagnostics))]
    public static T ToggleDiagnostics<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Diagnostics, !o.Diagnostics));
    #endregion
    #region Pause
    /// <inheritdoc cref="Xunit2Settings.Pause"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Pause))]
    public static T SetPause<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Pause, v));
    /// <inheritdoc cref="Xunit2Settings.Pause"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Pause))]
    public static T ResetPause<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Pause));
    /// <inheritdoc cref="Xunit2Settings.Pause"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Pause))]
    public static T EnablePause<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Pause, true));
    /// <inheritdoc cref="Xunit2Settings.Pause"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Pause))]
    public static T DisablePause<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Pause, false));
    /// <inheritdoc cref="Xunit2Settings.Pause"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Pause))]
    public static T TogglePause<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Pause, !o.Pause));
    #endregion
    #region Debug
    /// <inheritdoc cref="Xunit2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="Xunit2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Debug))]
    public static T ResetDebug<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="Xunit2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Debug))]
    public static T EnableDebug<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="Xunit2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Debug))]
    public static T DisableDebug<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="Xunit2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Serialization
    /// <inheritdoc cref="Xunit2Settings.Serialization"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Serialization))]
    public static T SetSerialization<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Serialization, v));
    /// <inheritdoc cref="Xunit2Settings.Serialization"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Serialization))]
    public static T ResetSerialization<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Serialization));
    /// <inheritdoc cref="Xunit2Settings.Serialization"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Serialization))]
    public static T EnableSerialization<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Serialization, true));
    /// <inheritdoc cref="Xunit2Settings.Serialization"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Serialization))]
    public static T DisableSerialization<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Serialization, false));
    /// <inheritdoc cref="Xunit2Settings.Serialization"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Serialization))]
    public static T ToggleSerialization<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Serialization, !o.Serialization));
    #endregion
    #region Traits
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T SetTraits<T>(this T o, string k, params string[] v) where T : Xunit2Settings => o.Modify(b => b.SetLookup(() => o.Traits, k, v));
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T SetTraits<T>(this T o, string k, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.SetLookup(() => o.Traits, k, v));
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T AddTraits<T>(this T o, string k, params string[] v) where T : Xunit2Settings => o.Modify(b => b.AddLookup(() => o.Traits, k, v));
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T AddTraits<T>(this T o, string k, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.AddLookup(() => o.Traits, k, v));
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T RemoveTraits<T>(this T o, string k) where T : Xunit2Settings => o.Modify(b => b.RemoveLookup(() => o.Traits, k));
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T RemoveTraits<T>(this T o, string k, string v) where T : Xunit2Settings => o.Modify(b => b.RemoveLookup(() => o.Traits, k, v));
    /// <summary>Only run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Traits))]
    public static T ResetTraits<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearLookup(() => o.Traits));
    #endregion
    #region ExcludedTraits
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T SetExcludedTraits<T>(this T o, string k, params string[] v) where T : Xunit2Settings => o.Modify(b => b.SetLookup(() => o.ExcludedTraits, k, v));
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T SetExcludedTraits<T>(this T o, string k, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.SetLookup(() => o.ExcludedTraits, k, v));
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T AddExcludedTraits<T>(this T o, string k, params string[] v) where T : Xunit2Settings => o.Modify(b => b.AddLookup(() => o.ExcludedTraits, k, v));
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T AddExcludedTraits<T>(this T o, string k, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.AddLookup(() => o.ExcludedTraits, k, v));
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T RemoveExcludedTraits<T>(this T o, string k) where T : Xunit2Settings => o.Modify(b => b.RemoveLookup(() => o.ExcludedTraits, k));
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T RemoveExcludedTraits<T>(this T o, string k, string v) where T : Xunit2Settings => o.Modify(b => b.RemoveLookup(() => o.ExcludedTraits, k, v));
    /// <summary>Do not run tests with matching name/value traits.</summary>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ExcludedTraits))]
    public static T ResetExcludedTraits<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearLookup(() => o.ExcludedTraits));
    #endregion
    #region Methods
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T SetMethods<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Methods, v));
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T SetMethods<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Methods, v));
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T AddMethods<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.AddCollection(() => o.Methods, v));
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T AddMethods<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.AddCollection(() => o.Methods, v));
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T RemoveMethods<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.RemoveCollection(() => o.Methods, v));
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T RemoveMethods<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.RemoveCollection(() => o.Methods, v));
    /// <inheritdoc cref="Xunit2Settings.Methods"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Methods))]
    public static T ClearMethods<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearCollection(() => o.Methods));
    #endregion
    #region Classes
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T SetClasses<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Classes, v));
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T SetClasses<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Classes, v));
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T AddClasses<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.AddCollection(() => o.Classes, v));
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T AddClasses<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.AddCollection(() => o.Classes, v));
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T RemoveClasses<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.RemoveCollection(() => o.Classes, v));
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T RemoveClasses<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.RemoveCollection(() => o.Classes, v));
    /// <inheritdoc cref="Xunit2Settings.Classes"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Classes))]
    public static T ClearClasses<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearCollection(() => o.Classes));
    #endregion
    #region Namespaces
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T SetNamespaces<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Namespaces, v));
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T SetNamespaces<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Namespaces, v));
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T AddNamespaces<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.AddCollection(() => o.Namespaces, v));
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T AddNamespaces<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.AddCollection(() => o.Namespaces, v));
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T RemoveNamespaces<T>(this T o, params string[] v) where T : Xunit2Settings => o.Modify(b => b.RemoveCollection(() => o.Namespaces, v));
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T RemoveNamespaces<T>(this T o, IEnumerable<string> v) where T : Xunit2Settings => o.Modify(b => b.RemoveCollection(() => o.Namespaces, v));
    /// <inheritdoc cref="Xunit2Settings.Namespaces"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Namespaces))]
    public static T ClearNamespaces<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearCollection(() => o.Namespaces));
    #endregion
    #region NoAutoReporters
    /// <inheritdoc cref="Xunit2Settings.NoAutoReporters"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoAutoReporters))]
    public static T SetNoAutoReporters<T>(this T o, bool? v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoAutoReporters, v));
    /// <inheritdoc cref="Xunit2Settings.NoAutoReporters"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoAutoReporters))]
    public static T ResetNoAutoReporters<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.NoAutoReporters));
    /// <inheritdoc cref="Xunit2Settings.NoAutoReporters"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoAutoReporters))]
    public static T EnableNoAutoReporters<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoAutoReporters, true));
    /// <inheritdoc cref="Xunit2Settings.NoAutoReporters"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoAutoReporters))]
    public static T DisableNoAutoReporters<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoAutoReporters, false));
    /// <inheritdoc cref="Xunit2Settings.NoAutoReporters"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.NoAutoReporters))]
    public static T ToggleNoAutoReporters<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.NoAutoReporters, !o.NoAutoReporters));
    #endregion
    #region Reporter
    /// <inheritdoc cref="Xunit2Settings.Reporter"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Reporter))]
    public static T SetReporter<T>(this T o, Xunit2ReporterType v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.Reporter, v));
    /// <inheritdoc cref="Xunit2Settings.Reporter"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.Reporter))]
    public static T ResetReporter<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.Remove(() => o.Reporter));
    #endregion
    #region ResultReports
    /// <inheritdoc cref="Xunit2Settings.ResultReports"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ResultReports))]
    public static T SetResultReports<T>(this T o, IDictionary<Xunit2ResultFormat, string> v) where T : Xunit2Settings => o.Modify(b => b.Set(() => o.ResultReports, v.ToDictionary(x => x.Key, x => x.Value, EqualityComparer<Xunit2ResultFormat>.Default)));
    /// <inheritdoc cref="Xunit2Settings.ResultReports"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ResultReports))]
    public static T SetResultReport<T>(this T o, Xunit2ResultFormat k, string v) where T : Xunit2Settings => o.Modify(b => b.SetDictionary(() => o.ResultReports, k, v));
    /// <inheritdoc cref="Xunit2Settings.ResultReports"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ResultReports))]
    public static T AddResultReport<T>(this T o, Xunit2ResultFormat k, string v) where T : Xunit2Settings => o.Modify(b => b.AddDictionary(() => o.ResultReports, k, v));
    /// <inheritdoc cref="Xunit2Settings.ResultReports"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ResultReports))]
    public static T RemoveResultReport<T>(this T o, Xunit2ResultFormat k) where T : Xunit2Settings => o.Modify(b => b.RemoveDictionary(() => o.ResultReports, k));
    /// <inheritdoc cref="Xunit2Settings.ResultReports"/>
    [Pure] [Builder(Type = typeof(Xunit2Settings), Property = nameof(Xunit2Settings.ResultReports))]
    public static T ClearResultReports<T>(this T o) where T : Xunit2Settings => o.Modify(b => b.ClearDictionary(() => o.ResultReports));
    #endregion
}
#endregion
#region Xunit2ReporterType
/// <summary>Used within <see cref="XunitTasks"/>.</summary>
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
/// <summary>Used within <see cref="XunitTasks"/>.</summary>
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
/// <summary>Used within <see cref="XunitTasks"/>.</summary>
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
/// <summary>Used within <see cref="XunitTasks"/>.</summary>
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
