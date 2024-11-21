// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/OpenCover/OpenCover.json

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

namespace Nuke.Common.Tools.OpenCover;

/// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class OpenCoverTasks : ToolTasks, IRequireNuGetPackage
{
    public static string OpenCoverPath => new OpenCoverTasks().GetToolPath();
    public const string PackageId = "OpenCover";
    public const string PackageExecutable = "OpenCover.Console.exe";
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> OpenCover(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new OpenCoverTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-coverbytest</c> via <see cref="OpenCoverSettings.CoverByTests"/></li><li><c>-enableperformancecounters</c> via <see cref="OpenCoverSettings.PerformanceCounters"/></li><li><c>-excludebyattribute</c> via <see cref="OpenCoverSettings.ExcludeByAttributes"/></li><li><c>-excludebyfile</c> via <see cref="OpenCoverSettings.ExcludeByFile"/></li><li><c>-excludedirs</c> via <see cref="OpenCoverSettings.ExcludeDirectories"/></li><li><c>-filter</c> via <see cref="OpenCoverSettings.Filters"/></li><li><c>-hideskipped</c> via <see cref="OpenCoverSettings.HideSkippedKinds"/></li><li><c>-log</c> via <see cref="OpenCoverSettings.Verbosity"/></li><li><c>-mergebyhash</c> via <see cref="OpenCoverSettings.MergeByHash"/></li><li><c>-mergeoutput</c> via <see cref="OpenCoverSettings.MergeOutput"/></li><li><c>-nodefaultfilters</c> via <see cref="OpenCoverSettings.NoDefaultFilters"/></li><li><c>-oldStyle</c> via <see cref="OpenCoverSettings.OldStyle"/></li><li><c>-output</c> via <see cref="OpenCoverSettings.Output"/></li><li><c>-register</c> via <see cref="OpenCoverSettings.Registration"/></li><li><c>-returntargetcode</c> via <see cref="OpenCoverSettings.TargetExitCodeOffset"/></li><li><c>-safemode</c> via <see cref="OpenCoverSettings.SafeMode"/></li><li><c>-searchdirs</c> via <see cref="OpenCoverSettings.SearchDirectories"/></li><li><c>-service</c> via <see cref="OpenCoverSettings.Service"/></li><li><c>-showunvisited</c> via <see cref="OpenCoverSettings.ShowUnvisited"/></li><li><c>-skipautoprops</c> via <see cref="OpenCoverSettings.SkipAutoProperties"/></li><li><c>-target</c> via <see cref="OpenCoverSettings.TargetPath"/></li><li><c>-targetargs</c> via <see cref="OpenCoverSettings.TargetArguments"/></li><li><c>-targetdir</c> via <see cref="OpenCoverSettings.TargetDirectory"/></li><li><c>-threshold</c> via <see cref="OpenCoverSettings.MaximumVisitCount"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OpenCover(OpenCoverSettings options = null) => new OpenCoverTasks().Run(options);
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-coverbytest</c> via <see cref="OpenCoverSettings.CoverByTests"/></li><li><c>-enableperformancecounters</c> via <see cref="OpenCoverSettings.PerformanceCounters"/></li><li><c>-excludebyattribute</c> via <see cref="OpenCoverSettings.ExcludeByAttributes"/></li><li><c>-excludebyfile</c> via <see cref="OpenCoverSettings.ExcludeByFile"/></li><li><c>-excludedirs</c> via <see cref="OpenCoverSettings.ExcludeDirectories"/></li><li><c>-filter</c> via <see cref="OpenCoverSettings.Filters"/></li><li><c>-hideskipped</c> via <see cref="OpenCoverSettings.HideSkippedKinds"/></li><li><c>-log</c> via <see cref="OpenCoverSettings.Verbosity"/></li><li><c>-mergebyhash</c> via <see cref="OpenCoverSettings.MergeByHash"/></li><li><c>-mergeoutput</c> via <see cref="OpenCoverSettings.MergeOutput"/></li><li><c>-nodefaultfilters</c> via <see cref="OpenCoverSettings.NoDefaultFilters"/></li><li><c>-oldStyle</c> via <see cref="OpenCoverSettings.OldStyle"/></li><li><c>-output</c> via <see cref="OpenCoverSettings.Output"/></li><li><c>-register</c> via <see cref="OpenCoverSettings.Registration"/></li><li><c>-returntargetcode</c> via <see cref="OpenCoverSettings.TargetExitCodeOffset"/></li><li><c>-safemode</c> via <see cref="OpenCoverSettings.SafeMode"/></li><li><c>-searchdirs</c> via <see cref="OpenCoverSettings.SearchDirectories"/></li><li><c>-service</c> via <see cref="OpenCoverSettings.Service"/></li><li><c>-showunvisited</c> via <see cref="OpenCoverSettings.ShowUnvisited"/></li><li><c>-skipautoprops</c> via <see cref="OpenCoverSettings.SkipAutoProperties"/></li><li><c>-target</c> via <see cref="OpenCoverSettings.TargetPath"/></li><li><c>-targetargs</c> via <see cref="OpenCoverSettings.TargetArguments"/></li><li><c>-targetdir</c> via <see cref="OpenCoverSettings.TargetDirectory"/></li><li><c>-threshold</c> via <see cref="OpenCoverSettings.MaximumVisitCount"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OpenCover(Configure<OpenCoverSettings> configurator) => new OpenCoverTasks().Run(configurator.Invoke(new OpenCoverSettings()));
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-coverbytest</c> via <see cref="OpenCoverSettings.CoverByTests"/></li><li><c>-enableperformancecounters</c> via <see cref="OpenCoverSettings.PerformanceCounters"/></li><li><c>-excludebyattribute</c> via <see cref="OpenCoverSettings.ExcludeByAttributes"/></li><li><c>-excludebyfile</c> via <see cref="OpenCoverSettings.ExcludeByFile"/></li><li><c>-excludedirs</c> via <see cref="OpenCoverSettings.ExcludeDirectories"/></li><li><c>-filter</c> via <see cref="OpenCoverSettings.Filters"/></li><li><c>-hideskipped</c> via <see cref="OpenCoverSettings.HideSkippedKinds"/></li><li><c>-log</c> via <see cref="OpenCoverSettings.Verbosity"/></li><li><c>-mergebyhash</c> via <see cref="OpenCoverSettings.MergeByHash"/></li><li><c>-mergeoutput</c> via <see cref="OpenCoverSettings.MergeOutput"/></li><li><c>-nodefaultfilters</c> via <see cref="OpenCoverSettings.NoDefaultFilters"/></li><li><c>-oldStyle</c> via <see cref="OpenCoverSettings.OldStyle"/></li><li><c>-output</c> via <see cref="OpenCoverSettings.Output"/></li><li><c>-register</c> via <see cref="OpenCoverSettings.Registration"/></li><li><c>-returntargetcode</c> via <see cref="OpenCoverSettings.TargetExitCodeOffset"/></li><li><c>-safemode</c> via <see cref="OpenCoverSettings.SafeMode"/></li><li><c>-searchdirs</c> via <see cref="OpenCoverSettings.SearchDirectories"/></li><li><c>-service</c> via <see cref="OpenCoverSettings.Service"/></li><li><c>-showunvisited</c> via <see cref="OpenCoverSettings.ShowUnvisited"/></li><li><c>-skipautoprops</c> via <see cref="OpenCoverSettings.SkipAutoProperties"/></li><li><c>-target</c> via <see cref="OpenCoverSettings.TargetPath"/></li><li><c>-targetargs</c> via <see cref="OpenCoverSettings.TargetArguments"/></li><li><c>-targetdir</c> via <see cref="OpenCoverSettings.TargetDirectory"/></li><li><c>-threshold</c> via <see cref="OpenCoverSettings.MaximumVisitCount"/></li></ul></remarks>
    public static IEnumerable<(OpenCoverSettings Settings, IReadOnlyCollection<Output> Output)> OpenCover(CombinatorialConfigure<OpenCoverSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OpenCover, degreeOfParallelism, completeOnFailure);
}
#region OpenCoverSettings
/// <summary>Used within <see cref="OpenCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OpenCoverSettings>))]
[Command(Type = typeof(OpenCoverTasks), Command = nameof(OpenCoverTasks.OpenCover))]
public partial class OpenCoverSettings : ToolOptions
{
    /// <summary>The name of the target application or service that will be started; this can also be a path to the target application.</summary>
    [Argument(Format = "-target:{value}")] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>Arguments to be passed to the target process.</summary>
    [Argument(Format = "-targetargs:{value}")] public string TargetArguments => Get<string>(() => TargetArguments);
    /// <summary>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</summary>
    [Argument(Format = "-targetdir:{value}")] public string TargetDirectory => Get<string>(() => TargetDirectory);
    /// <summary>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</summary>
    [Argument(Format = "-coverbytest:{value}", Separator = ";")] public IReadOnlyList<string> CoverByTests => Get<List<string>>(() => CoverByTests);
    /// <summary><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></summary>
    [Argument(Format = "-enableperformancecounters")] public bool? PerformanceCounters => Get<bool?>(() => PerformanceCounters);
    /// <summary>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</summary>
    [Argument(Format = "-excludebyattribute:{value}", Separator = ";")] public IReadOnlyList<string> ExcludeByAttributes => Get<List<string>>(() => ExcludeByAttributes);
    /// <summary>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</summary>
    [Argument(Format = "-excludebyfile:{value}", Separator = ";")] public IReadOnlyList<string> ExcludeByFile => Get<List<string>>(() => ExcludeByFile);
    /// <summary>Assemblies being loaded from these locations will be ignored.</summary>
    [Argument(Format = "-excludedirs:{value}", Separator = ";")] public IReadOnlyList<string> ExcludeDirectories => Get<List<string>>(() => ExcludeDirectories);
    /// <summary><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
    [Argument(Format = "-filter:{value}", Separator = " ", QuoteMultiple = true)] public IReadOnlyList<string> Filters => Get<List<string>>(() => Filters);
    /// <summary>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></summary>
    [Argument(Format = "-hideskipped:{value}", Separator = ";")] public IReadOnlyList<OpenCoverSkipping> HideSkippedKinds => Get<List<OpenCoverSkipping>>(() => HideSkippedKinds);
    /// <summary>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</summary>
    [Argument(Format = "-log:{value}")] public OpenCoverVerbosity Verbosity => Get<OpenCoverVerbosity>(() => Verbosity);
    /// <summary>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</summary>
    [Argument(Format = "-mergebyhash")] public bool? MergeByHash => Get<bool?>(() => MergeByHash);
    /// <summary>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</summary>
    [Argument(Format = "-mergeoutput")] public bool? MergeOutput => Get<bool?>(() => MergeOutput);
    /// <summary>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></summary>
    [Argument(Format = "-nodefaultfilters")] public bool? NoDefaultFilters => Get<bool?>(() => NoDefaultFilters);
    /// <summary>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</summary>
    [Argument(Format = "-oldStyle")] public bool? OldStyle => Get<bool?>(() => OldStyle);
    /// <summary>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</summary>
    [Argument(Format = "-output:{value}")] public string Output => Get<string>(() => Output);
    /// <summary>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</summary>
    [Argument(Format = "-safemode:{value}")] public bool? SafeMode => Get<bool?>(() => SafeMode);
    /// <summary>Alternative locations to look for PDBs.</summary>
    [Argument(Format = "-searchdirs:{value}", Separator = ";")] public IReadOnlyList<string> SearchDirectories => Get<List<string>>(() => SearchDirectories);
    /// <summary>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</summary>
    [Argument(Format = "-service")] public bool? Service => Get<bool?>(() => Service);
    /// <summary>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</summary>
    [Argument(Format = "-showunvisited")] public bool? ShowUnvisited => Get<bool?>(() => ShowUnvisited);
    /// <summary>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></summary>
    [Argument(Format = "-skipautoprops")] public bool? SkipAutoProperties => Get<bool?>(() => SkipAutoProperties);
    /// <summary>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</summary>
    [Argument(Format = "-threshold:{value}")] public int? MaximumVisitCount => Get<int?>(() => MaximumVisitCount);
    /// <summary>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</summary>
    [Argument(Format = "-register:{value}")] public RegistrationType Registration => Get<RegistrationType>(() => Registration);
    /// <summary>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</summary>
    [Argument(Format = "-returntargetcode:{value}")] public int? TargetExitCodeOffset => Get<int?>(() => TargetExitCodeOffset);
}
#endregion
#region OpenCoverSettingsExtensions
/// <summary>Used within <see cref="OpenCoverTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OpenCoverSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="OpenCoverSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="OpenCoverSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region TargetArguments
    /// <inheritdoc cref="OpenCoverSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetArguments))]
    public static T SetTargetArguments<T>(this T o, string v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.TargetArguments, v));
    /// <inheritdoc cref="OpenCoverSettings.TargetArguments"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetArguments))]
    public static T ResetTargetArguments<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.TargetArguments));
    #endregion
    #region TargetDirectory
    /// <inheritdoc cref="OpenCoverSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetDirectory))]
    public static T SetTargetDirectory<T>(this T o, string v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.TargetDirectory, v));
    /// <inheritdoc cref="OpenCoverSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetDirectory))]
    public static T ResetTargetDirectory<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.TargetDirectory));
    #endregion
    #region CoverByTests
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T SetCoverByTests<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.CoverByTests, v));
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T SetCoverByTests<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.CoverByTests, v));
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T AddCoverByTests<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.CoverByTests, v));
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T AddCoverByTests<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.CoverByTests, v));
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T RemoveCoverByTests<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.CoverByTests, v));
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T RemoveCoverByTests<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.CoverByTests, v));
    /// <inheritdoc cref="OpenCoverSettings.CoverByTests"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.CoverByTests))]
    public static T ClearCoverByTests<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.CoverByTests));
    #endregion
    #region PerformanceCounters
    /// <inheritdoc cref="OpenCoverSettings.PerformanceCounters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.PerformanceCounters))]
    public static T SetPerformanceCounters<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.PerformanceCounters, v));
    /// <inheritdoc cref="OpenCoverSettings.PerformanceCounters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.PerformanceCounters))]
    public static T ResetPerformanceCounters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.PerformanceCounters));
    /// <inheritdoc cref="OpenCoverSettings.PerformanceCounters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.PerformanceCounters))]
    public static T EnablePerformanceCounters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.PerformanceCounters, true));
    /// <inheritdoc cref="OpenCoverSettings.PerformanceCounters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.PerformanceCounters))]
    public static T DisablePerformanceCounters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.PerformanceCounters, false));
    /// <inheritdoc cref="OpenCoverSettings.PerformanceCounters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.PerformanceCounters))]
    public static T TogglePerformanceCounters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.PerformanceCounters, !o.PerformanceCounters));
    #endregion
    #region ExcludeByAttributes
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T SetExcludeByAttributes<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ExcludeByAttributes, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T SetExcludeByAttributes<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ExcludeByAttributes, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T AddExcludeByAttributes<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.ExcludeByAttributes, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T AddExcludeByAttributes<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.ExcludeByAttributes, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T RemoveExcludeByAttributes<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeByAttributes, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T RemoveExcludeByAttributes<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeByAttributes, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByAttributes"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByAttributes))]
    public static T ClearExcludeByAttributes<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeByAttributes));
    #endregion
    #region ExcludeByFile
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T SetExcludeByFile<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T SetExcludeByFile<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T AddExcludeByFile<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T AddExcludeByFile<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T RemoveExcludeByFile<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T RemoveExcludeByFile<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeByFile))]
    public static T ClearExcludeByFile<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeByFile));
    #endregion
    #region ExcludeDirectories
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T SetExcludeDirectories<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ExcludeDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T SetExcludeDirectories<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ExcludeDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T AddExcludeDirectories<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.ExcludeDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T AddExcludeDirectories<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.ExcludeDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T RemoveExcludeDirectories<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T RemoveExcludeDirectories<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.ExcludeDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ExcludeDirectories))]
    public static T ClearExcludeDirectories<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeDirectories));
    #endregion
    #region Filters
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T SetFilters<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T SetFilters<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T AddFilters<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T AddFilters<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T RemoveFilters<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T RemoveFilters<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="OpenCoverSettings.Filters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Filters))]
    public static T ClearFilters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.Filters));
    #endregion
    #region HideSkippedKinds
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T SetHideSkippedKinds<T>(this T o, params OpenCoverSkipping[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.HideSkippedKinds, v));
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T SetHideSkippedKinds<T>(this T o, IEnumerable<OpenCoverSkipping> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.HideSkippedKinds, v));
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T AddHideSkippedKinds<T>(this T o, params OpenCoverSkipping[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.HideSkippedKinds, v));
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T AddHideSkippedKinds<T>(this T o, IEnumerable<OpenCoverSkipping> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.HideSkippedKinds, v));
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T RemoveHideSkippedKinds<T>(this T o, params OpenCoverSkipping[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.HideSkippedKinds, v));
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T RemoveHideSkippedKinds<T>(this T o, IEnumerable<OpenCoverSkipping> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.HideSkippedKinds, v));
    /// <inheritdoc cref="OpenCoverSettings.HideSkippedKinds"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.HideSkippedKinds))]
    public static T ClearHideSkippedKinds<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.HideSkippedKinds));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="OpenCoverSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, OpenCoverVerbosity v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="OpenCoverSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region MergeByHash
    /// <inheritdoc cref="OpenCoverSettings.MergeByHash"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeByHash))]
    public static T SetMergeByHash<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeByHash, v));
    /// <inheritdoc cref="OpenCoverSettings.MergeByHash"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeByHash))]
    public static T ResetMergeByHash<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.MergeByHash));
    /// <inheritdoc cref="OpenCoverSettings.MergeByHash"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeByHash))]
    public static T EnableMergeByHash<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeByHash, true));
    /// <inheritdoc cref="OpenCoverSettings.MergeByHash"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeByHash))]
    public static T DisableMergeByHash<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeByHash, false));
    /// <inheritdoc cref="OpenCoverSettings.MergeByHash"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeByHash))]
    public static T ToggleMergeByHash<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeByHash, !o.MergeByHash));
    #endregion
    #region MergeOutput
    /// <inheritdoc cref="OpenCoverSettings.MergeOutput"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeOutput))]
    public static T SetMergeOutput<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeOutput, v));
    /// <inheritdoc cref="OpenCoverSettings.MergeOutput"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeOutput))]
    public static T ResetMergeOutput<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.MergeOutput));
    /// <inheritdoc cref="OpenCoverSettings.MergeOutput"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeOutput))]
    public static T EnableMergeOutput<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeOutput, true));
    /// <inheritdoc cref="OpenCoverSettings.MergeOutput"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeOutput))]
    public static T DisableMergeOutput<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeOutput, false));
    /// <inheritdoc cref="OpenCoverSettings.MergeOutput"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MergeOutput))]
    public static T ToggleMergeOutput<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MergeOutput, !o.MergeOutput));
    #endregion
    #region NoDefaultFilters
    /// <inheritdoc cref="OpenCoverSettings.NoDefaultFilters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.NoDefaultFilters))]
    public static T SetNoDefaultFilters<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.NoDefaultFilters, v));
    /// <inheritdoc cref="OpenCoverSettings.NoDefaultFilters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.NoDefaultFilters))]
    public static T ResetNoDefaultFilters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.NoDefaultFilters));
    /// <inheritdoc cref="OpenCoverSettings.NoDefaultFilters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.NoDefaultFilters))]
    public static T EnableNoDefaultFilters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.NoDefaultFilters, true));
    /// <inheritdoc cref="OpenCoverSettings.NoDefaultFilters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.NoDefaultFilters))]
    public static T DisableNoDefaultFilters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.NoDefaultFilters, false));
    /// <inheritdoc cref="OpenCoverSettings.NoDefaultFilters"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.NoDefaultFilters))]
    public static T ToggleNoDefaultFilters<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.NoDefaultFilters, !o.NoDefaultFilters));
    #endregion
    #region OldStyle
    /// <inheritdoc cref="OpenCoverSettings.OldStyle"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.OldStyle))]
    public static T SetOldStyle<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.OldStyle, v));
    /// <inheritdoc cref="OpenCoverSettings.OldStyle"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.OldStyle))]
    public static T ResetOldStyle<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.OldStyle));
    /// <inheritdoc cref="OpenCoverSettings.OldStyle"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.OldStyle))]
    public static T EnableOldStyle<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.OldStyle, true));
    /// <inheritdoc cref="OpenCoverSettings.OldStyle"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.OldStyle))]
    public static T DisableOldStyle<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.OldStyle, false));
    /// <inheritdoc cref="OpenCoverSettings.OldStyle"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.OldStyle))]
    public static T ToggleOldStyle<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.OldStyle, !o.OldStyle));
    #endregion
    #region Output
    /// <inheritdoc cref="OpenCoverSettings.Output"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="OpenCoverSettings.Output"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region SafeMode
    /// <inheritdoc cref="OpenCoverSettings.SafeMode"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SafeMode))]
    public static T SetSafeMode<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SafeMode, v));
    /// <inheritdoc cref="OpenCoverSettings.SafeMode"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SafeMode))]
    public static T ResetSafeMode<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.SafeMode));
    /// <inheritdoc cref="OpenCoverSettings.SafeMode"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SafeMode))]
    public static T EnableSafeMode<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SafeMode, true));
    /// <inheritdoc cref="OpenCoverSettings.SafeMode"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SafeMode))]
    public static T DisableSafeMode<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SafeMode, false));
    /// <inheritdoc cref="OpenCoverSettings.SafeMode"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SafeMode))]
    public static T ToggleSafeMode<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SafeMode, !o.SafeMode));
    #endregion
    #region SearchDirectories
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T SetSearchDirectories<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SearchDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T SetSearchDirectories<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SearchDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T AddSearchDirectories<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.SearchDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T AddSearchDirectories<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.AddCollection(() => o.SearchDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T RemoveSearchDirectories<T>(this T o, params string[] v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.SearchDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T RemoveSearchDirectories<T>(this T o, IEnumerable<string> v) where T : OpenCoverSettings => o.Modify(b => b.RemoveCollection(() => o.SearchDirectories, v));
    /// <inheritdoc cref="OpenCoverSettings.SearchDirectories"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SearchDirectories))]
    public static T ClearSearchDirectories<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.ClearCollection(() => o.SearchDirectories));
    #endregion
    #region Service
    /// <inheritdoc cref="OpenCoverSettings.Service"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Service))]
    public static T SetService<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Service, v));
    /// <inheritdoc cref="OpenCoverSettings.Service"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Service))]
    public static T ResetService<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.Service));
    /// <inheritdoc cref="OpenCoverSettings.Service"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Service))]
    public static T EnableService<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Service, true));
    /// <inheritdoc cref="OpenCoverSettings.Service"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Service))]
    public static T DisableService<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Service, false));
    /// <inheritdoc cref="OpenCoverSettings.Service"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Service))]
    public static T ToggleService<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Service, !o.Service));
    #endregion
    #region ShowUnvisited
    /// <inheritdoc cref="OpenCoverSettings.ShowUnvisited"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ShowUnvisited))]
    public static T SetShowUnvisited<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ShowUnvisited, v));
    /// <inheritdoc cref="OpenCoverSettings.ShowUnvisited"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ShowUnvisited))]
    public static T ResetShowUnvisited<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.ShowUnvisited));
    /// <inheritdoc cref="OpenCoverSettings.ShowUnvisited"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ShowUnvisited))]
    public static T EnableShowUnvisited<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ShowUnvisited, true));
    /// <inheritdoc cref="OpenCoverSettings.ShowUnvisited"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ShowUnvisited))]
    public static T DisableShowUnvisited<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ShowUnvisited, false));
    /// <inheritdoc cref="OpenCoverSettings.ShowUnvisited"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.ShowUnvisited))]
    public static T ToggleShowUnvisited<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.ShowUnvisited, !o.ShowUnvisited));
    #endregion
    #region SkipAutoProperties
    /// <inheritdoc cref="OpenCoverSettings.SkipAutoProperties"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SkipAutoProperties))]
    public static T SetSkipAutoProperties<T>(this T o, bool? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SkipAutoProperties, v));
    /// <inheritdoc cref="OpenCoverSettings.SkipAutoProperties"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SkipAutoProperties))]
    public static T ResetSkipAutoProperties<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.SkipAutoProperties));
    /// <inheritdoc cref="OpenCoverSettings.SkipAutoProperties"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SkipAutoProperties))]
    public static T EnableSkipAutoProperties<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SkipAutoProperties, true));
    /// <inheritdoc cref="OpenCoverSettings.SkipAutoProperties"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SkipAutoProperties))]
    public static T DisableSkipAutoProperties<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SkipAutoProperties, false));
    /// <inheritdoc cref="OpenCoverSettings.SkipAutoProperties"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.SkipAutoProperties))]
    public static T ToggleSkipAutoProperties<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.SkipAutoProperties, !o.SkipAutoProperties));
    #endregion
    #region MaximumVisitCount
    /// <inheritdoc cref="OpenCoverSettings.MaximumVisitCount"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MaximumVisitCount))]
    public static T SetMaximumVisitCount<T>(this T o, int? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.MaximumVisitCount, v));
    /// <inheritdoc cref="OpenCoverSettings.MaximumVisitCount"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.MaximumVisitCount))]
    public static T ResetMaximumVisitCount<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.MaximumVisitCount));
    #endregion
    #region Registration
    /// <inheritdoc cref="OpenCoverSettings.Registration"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Registration))]
    public static T SetRegistration<T>(this T o, RegistrationType v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.Registration, v));
    /// <inheritdoc cref="OpenCoverSettings.Registration"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.Registration))]
    public static T ResetRegistration<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.Registration));
    #endregion
    #region TargetExitCodeOffset
    /// <inheritdoc cref="OpenCoverSettings.TargetExitCodeOffset"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetExitCodeOffset))]
    public static T SetTargetExitCodeOffset<T>(this T o, int? v) where T : OpenCoverSettings => o.Modify(b => b.Set(() => o.TargetExitCodeOffset, v));
    /// <inheritdoc cref="OpenCoverSettings.TargetExitCodeOffset"/>
    [Pure] [Builder(Type = typeof(OpenCoverSettings), Property = nameof(OpenCoverSettings.TargetExitCodeOffset))]
    public static T ResetTargetExitCodeOffset<T>(this T o) where T : OpenCoverSettings => o.Modify(b => b.Remove(() => o.TargetExitCodeOffset));
    #endregion
}
#endregion
#region OpenCoverVerbosity
/// <summary>Used within <see cref="OpenCoverTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OpenCoverVerbosity>))]
public partial class OpenCoverVerbosity : Enumeration
{
    public static OpenCoverVerbosity Off = (OpenCoverVerbosity) "Off";
    public static OpenCoverVerbosity Fatal = (OpenCoverVerbosity) "Fatal";
    public static OpenCoverVerbosity Error = (OpenCoverVerbosity) "Error";
    public static OpenCoverVerbosity Warn = (OpenCoverVerbosity) "Warn";
    public static OpenCoverVerbosity Info = (OpenCoverVerbosity) "Info";
    public static OpenCoverVerbosity Debug = (OpenCoverVerbosity) "Debug";
    public static OpenCoverVerbosity Verbose = (OpenCoverVerbosity) "Verbose";
    public static OpenCoverVerbosity All = (OpenCoverVerbosity) "All";
    public static implicit operator OpenCoverVerbosity(string value)
    {
        return new OpenCoverVerbosity { Value = value };
    }
}
#endregion
#region OpenCoverSkipping
/// <summary>Used within <see cref="OpenCoverTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OpenCoverSkipping>))]
public partial class OpenCoverSkipping : Enumeration
{
    public static OpenCoverSkipping File = (OpenCoverSkipping) "File";
    public static OpenCoverSkipping Filter = (OpenCoverSkipping) "Filter";
    public static OpenCoverSkipping Attribute = (OpenCoverSkipping) "Attribute";
    public static OpenCoverSkipping MissingPdb = (OpenCoverSkipping) "MissingPdb";
    public static implicit operator OpenCoverSkipping(string value)
    {
        return new OpenCoverSkipping { Value = value };
    }
}
#endregion
#region RegistrationType
/// <summary>Used within <see cref="OpenCoverTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<RegistrationType>))]
public partial class RegistrationType : Enumeration
{
    public static RegistrationType User = (RegistrationType) "User";
    public static RegistrationType Path32 = (RegistrationType) "Path32";
    public static RegistrationType Path64 = (RegistrationType) "Path64";
    public static implicit operator RegistrationType(string value)
    {
        return new RegistrationType { Value = value };
    }
}
#endregion
