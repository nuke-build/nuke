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

namespace Nuke.Common.Tools.OpenCover
{
    /// <summary>
    ///   <p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p>
    ///   <p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(OpenCoverPackageId)]
    public partial class OpenCoverTasks
        : IRequireNuGetPackage
    {
        public const string OpenCoverPackageId = "OpenCover";
        /// <summary>
        ///   Path to the OpenCover executable.
        /// </summary>
        public static string OpenCoverPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("OPENCOVER_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("OpenCover", "OpenCover.Console.exe");
        public static Action<OutputType, string> OpenCoverLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> OpenCover(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(OpenCoverPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? OpenCoverLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-coverbytest</c> via <see cref="OpenCoverSettings.CoverByTests"/></li>
        ///     <li><c>-enableperformancecounters</c> via <see cref="OpenCoverSettings.PerformanceCounters"/></li>
        ///     <li><c>-excludebyattribute</c> via <see cref="OpenCoverSettings.ExcludeByAttributes"/></li>
        ///     <li><c>-excludebyfile</c> via <see cref="OpenCoverSettings.ExcludeByFile"/></li>
        ///     <li><c>-excludedirs</c> via <see cref="OpenCoverSettings.ExcludeDirectories"/></li>
        ///     <li><c>-filter</c> via <see cref="OpenCoverSettings.Filters"/></li>
        ///     <li><c>-hideskipped</c> via <see cref="OpenCoverSettings.HideSkippedKinds"/></li>
        ///     <li><c>-log</c> via <see cref="OpenCoverSettings.Verbosity"/></li>
        ///     <li><c>-mergebyhash</c> via <see cref="OpenCoverSettings.MergeByHash"/></li>
        ///     <li><c>-mergeoutput</c> via <see cref="OpenCoverSettings.MergeOutput"/></li>
        ///     <li><c>-nodefaultfilters</c> via <see cref="OpenCoverSettings.NoDefaultFilters"/></li>
        ///     <li><c>-oldStyle</c> via <see cref="OpenCoverSettings.OldStyle"/></li>
        ///     <li><c>-output</c> via <see cref="OpenCoverSettings.Output"/></li>
        ///     <li><c>-register</c> via <see cref="OpenCoverSettings.Registration"/></li>
        ///     <li><c>-returntargetcode</c> via <see cref="OpenCoverSettings.TargetExitCodeOffset"/></li>
        ///     <li><c>-safemode</c> via <see cref="OpenCoverSettings.SafeMode"/></li>
        ///     <li><c>-searchdirs</c> via <see cref="OpenCoverSettings.SearchDirectories"/></li>
        ///     <li><c>-service</c> via <see cref="OpenCoverSettings.Service"/></li>
        ///     <li><c>-showunvisited</c> via <see cref="OpenCoverSettings.ShowUnvisited"/></li>
        ///     <li><c>-skipautoprops</c> via <see cref="OpenCoverSettings.SkipAutoProperties"/></li>
        ///     <li><c>-target</c> via <see cref="OpenCoverSettings.TargetPath"/></li>
        ///     <li><c>-targetargs</c> via <see cref="OpenCoverSettings.TargetArguments"/></li>
        ///     <li><c>-targetdir</c> via <see cref="OpenCoverSettings.TargetDirectory"/></li>
        ///     <li><c>-threshold</c> via <see cref="OpenCoverSettings.MaximumVisitCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OpenCover(OpenCoverSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OpenCoverSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-coverbytest</c> via <see cref="OpenCoverSettings.CoverByTests"/></li>
        ///     <li><c>-enableperformancecounters</c> via <see cref="OpenCoverSettings.PerformanceCounters"/></li>
        ///     <li><c>-excludebyattribute</c> via <see cref="OpenCoverSettings.ExcludeByAttributes"/></li>
        ///     <li><c>-excludebyfile</c> via <see cref="OpenCoverSettings.ExcludeByFile"/></li>
        ///     <li><c>-excludedirs</c> via <see cref="OpenCoverSettings.ExcludeDirectories"/></li>
        ///     <li><c>-filter</c> via <see cref="OpenCoverSettings.Filters"/></li>
        ///     <li><c>-hideskipped</c> via <see cref="OpenCoverSettings.HideSkippedKinds"/></li>
        ///     <li><c>-log</c> via <see cref="OpenCoverSettings.Verbosity"/></li>
        ///     <li><c>-mergebyhash</c> via <see cref="OpenCoverSettings.MergeByHash"/></li>
        ///     <li><c>-mergeoutput</c> via <see cref="OpenCoverSettings.MergeOutput"/></li>
        ///     <li><c>-nodefaultfilters</c> via <see cref="OpenCoverSettings.NoDefaultFilters"/></li>
        ///     <li><c>-oldStyle</c> via <see cref="OpenCoverSettings.OldStyle"/></li>
        ///     <li><c>-output</c> via <see cref="OpenCoverSettings.Output"/></li>
        ///     <li><c>-register</c> via <see cref="OpenCoverSettings.Registration"/></li>
        ///     <li><c>-returntargetcode</c> via <see cref="OpenCoverSettings.TargetExitCodeOffset"/></li>
        ///     <li><c>-safemode</c> via <see cref="OpenCoverSettings.SafeMode"/></li>
        ///     <li><c>-searchdirs</c> via <see cref="OpenCoverSettings.SearchDirectories"/></li>
        ///     <li><c>-service</c> via <see cref="OpenCoverSettings.Service"/></li>
        ///     <li><c>-showunvisited</c> via <see cref="OpenCoverSettings.ShowUnvisited"/></li>
        ///     <li><c>-skipautoprops</c> via <see cref="OpenCoverSettings.SkipAutoProperties"/></li>
        ///     <li><c>-target</c> via <see cref="OpenCoverSettings.TargetPath"/></li>
        ///     <li><c>-targetargs</c> via <see cref="OpenCoverSettings.TargetArguments"/></li>
        ///     <li><c>-targetdir</c> via <see cref="OpenCoverSettings.TargetDirectory"/></li>
        ///     <li><c>-threshold</c> via <see cref="OpenCoverSettings.MaximumVisitCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OpenCover(Configure<OpenCoverSettings> configurator)
        {
            return OpenCover(configurator(new OpenCoverSettings()));
        }
        /// <summary>
        ///   <p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-coverbytest</c> via <see cref="OpenCoverSettings.CoverByTests"/></li>
        ///     <li><c>-enableperformancecounters</c> via <see cref="OpenCoverSettings.PerformanceCounters"/></li>
        ///     <li><c>-excludebyattribute</c> via <see cref="OpenCoverSettings.ExcludeByAttributes"/></li>
        ///     <li><c>-excludebyfile</c> via <see cref="OpenCoverSettings.ExcludeByFile"/></li>
        ///     <li><c>-excludedirs</c> via <see cref="OpenCoverSettings.ExcludeDirectories"/></li>
        ///     <li><c>-filter</c> via <see cref="OpenCoverSettings.Filters"/></li>
        ///     <li><c>-hideskipped</c> via <see cref="OpenCoverSettings.HideSkippedKinds"/></li>
        ///     <li><c>-log</c> via <see cref="OpenCoverSettings.Verbosity"/></li>
        ///     <li><c>-mergebyhash</c> via <see cref="OpenCoverSettings.MergeByHash"/></li>
        ///     <li><c>-mergeoutput</c> via <see cref="OpenCoverSettings.MergeOutput"/></li>
        ///     <li><c>-nodefaultfilters</c> via <see cref="OpenCoverSettings.NoDefaultFilters"/></li>
        ///     <li><c>-oldStyle</c> via <see cref="OpenCoverSettings.OldStyle"/></li>
        ///     <li><c>-output</c> via <see cref="OpenCoverSettings.Output"/></li>
        ///     <li><c>-register</c> via <see cref="OpenCoverSettings.Registration"/></li>
        ///     <li><c>-returntargetcode</c> via <see cref="OpenCoverSettings.TargetExitCodeOffset"/></li>
        ///     <li><c>-safemode</c> via <see cref="OpenCoverSettings.SafeMode"/></li>
        ///     <li><c>-searchdirs</c> via <see cref="OpenCoverSettings.SearchDirectories"/></li>
        ///     <li><c>-service</c> via <see cref="OpenCoverSettings.Service"/></li>
        ///     <li><c>-showunvisited</c> via <see cref="OpenCoverSettings.ShowUnvisited"/></li>
        ///     <li><c>-skipautoprops</c> via <see cref="OpenCoverSettings.SkipAutoProperties"/></li>
        ///     <li><c>-target</c> via <see cref="OpenCoverSettings.TargetPath"/></li>
        ///     <li><c>-targetargs</c> via <see cref="OpenCoverSettings.TargetArguments"/></li>
        ///     <li><c>-targetdir</c> via <see cref="OpenCoverSettings.TargetDirectory"/></li>
        ///     <li><c>-threshold</c> via <see cref="OpenCoverSettings.MaximumVisitCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OpenCoverSettings Settings, IReadOnlyCollection<Output> Output)> OpenCover(CombinatorialConfigure<OpenCoverSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OpenCover, OpenCoverLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region OpenCoverSettings
    /// <summary>
    ///   Used within <see cref="OpenCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OpenCoverSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the OpenCover executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? OpenCoverTasks.OpenCoverPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OpenCoverTasks.OpenCoverLogger;
        /// <summary>
        ///   The name of the target application or service that will be started; this can also be a path to the target application.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Arguments to be passed to the target process.
        /// </summary>
        public virtual string TargetArguments { get; internal set; }
        /// <summary>
        ///   The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.
        /// </summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary>
        ///   Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.
        /// </summary>
        public virtual IReadOnlyList<string> CoverByTests => CoverByTestsInternal.AsReadOnly();
        internal List<string> CoverByTestsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   <em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul>
        /// </summary>
        public virtual bool? PerformanceCounters { get; internal set; }
        /// <summary>
        ///   Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeByAttributes => ExcludeByAttributesInternal.AsReadOnly();
        internal List<string> ExcludeByAttributesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeByFile => ExcludeByFileInternal.AsReadOnly();
        internal List<string> ExcludeByFileInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Assemblies being loaded from these locations will be ignored.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeDirectories => ExcludeDirectoriesInternal.AsReadOnly();
        internal List<string> ExcludeDirectoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   <p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul>
        /// </summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c>
        /// </summary>
        public virtual IReadOnlyList<OpenCoverSkipping> HideSkippedKinds => HideSkippedKindsInternal.AsReadOnly();
        internal List<OpenCoverSkipping> HideSkippedKindsInternal { get; set; } = new List<OpenCoverSkipping>();
        /// <summary>
        ///   Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.
        /// </summary>
        public virtual OpenCoverVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.
        /// </summary>
        public virtual bool? MergeByHash { get; internal set; }
        /// <summary>
        ///   Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).
        /// </summary>
        public virtual bool? MergeOutput { get; internal set; }
        /// <summary>
        ///   A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul>
        /// </summary>
        public virtual bool? NoDefaultFilters { get; internal set; }
        /// <summary>
        ///   Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.
        /// </summary>
        public virtual bool? OldStyle { get; internal set; }
        /// <summary>
        ///   The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.
        /// </summary>
        public virtual bool? SafeMode { get; internal set; }
        /// <summary>
        ///   Alternative locations to look for PDBs.
        /// </summary>
        public virtual IReadOnlyList<string> SearchDirectories => SearchDirectoriesInternal.AsReadOnly();
        internal List<string> SearchDirectoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.
        /// </summary>
        public virtual bool? Service { get; internal set; }
        /// <summary>
        ///   Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.
        /// </summary>
        public virtual bool? ShowUnvisited { get; internal set; }
        /// <summary>
        ///   Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c>
        /// </summary>
        public virtual bool? SkipAutoProperties { get; internal set; }
        /// <summary>
        ///   Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.
        /// </summary>
        public virtual int? MaximumVisitCount { get; internal set; }
        /// <summary>
        ///   Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.
        /// </summary>
        public virtual RegistrationType Registration { get; internal set; }
        /// <summary>
        ///   Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.
        /// </summary>
        public virtual int? TargetExitCodeOffset { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("-target:{value}", TargetPath)
              .Add("-targetargs:{value}", TargetArguments)
              .Add("-targetdir:{value}", TargetDirectory)
              .Add("-coverbytest:{value}", CoverByTests, separator: ';')
              .Add("-enableperformancecounters", PerformanceCounters)
              .Add("-excludebyattribute:{value}", ExcludeByAttributes, separator: ';')
              .Add("-excludebyfile:{value}", ExcludeByFile, separator: ';')
              .Add("-excludedirs:{value}", ExcludeDirectories, separator: ';')
              .Add("-filter:{value}", Filters, separator: ' ', quoteMultiple: true)
              .Add("-hideskipped:{value}", HideSkippedKinds, separator: ';')
              .Add("-log:{value}", Verbosity)
              .Add("-mergebyhash", MergeByHash)
              .Add("-mergeoutput", MergeOutput)
              .Add("-nodefaultfilters", NoDefaultFilters)
              .Add("-oldStyle", OldStyle)
              .Add("-output:{value}", Output)
              .Add("-safemode:{value}", SafeMode)
              .Add("-searchdirs:{value}", SearchDirectories, separator: ';')
              .Add("-service", Service)
              .Add("-showunvisited", ShowUnvisited)
              .Add("-skipautoprops", SkipAutoProperties)
              .Add("-threshold:{value}", MaximumVisitCount)
              .Add("-register:{value}", Registration)
              .Add("-returntargetcode:{value}", TargetExitCodeOffset);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OpenCoverSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OpenCoverTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OpenCoverSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.TargetPath"/></em></p>
        ///   <p>The name of the target application or service that will be started; this can also be a path to the target application.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.TargetPath"/></em></p>
        ///   <p>The name of the target application or service that will be started; this can also be a path to the target application.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region TargetArguments
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.TargetArguments"/></em></p>
        ///   <p>Arguments to be passed to the target process.</p>
        /// </summary>
        [Pure]
        public static T SetTargetArguments<T>(this T toolSettings, string targetArguments) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.TargetArguments"/></em></p>
        ///   <p>Arguments to be passed to the target process.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetArguments<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.TargetDirectory"/></em></p>
        ///   <p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p>
        /// </summary>
        [Pure]
        public static T SetTargetDirectory<T>(this T toolSettings, string targetDirectory) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.TargetDirectory"/></em></p>
        ///   <p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetDirectory<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region CoverByTests
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.CoverByTests"/> to a new list</em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T SetCoverByTests<T>(this T toolSettings, params string[] coverByTests) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal = coverByTests.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.CoverByTests"/> to a new list</em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T SetCoverByTests<T>(this T toolSettings, IEnumerable<string> coverByTests) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal = coverByTests.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.CoverByTests"/></em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T AddCoverByTests<T>(this T toolSettings, params string[] coverByTests) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.AddRange(coverByTests);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.CoverByTests"/></em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T AddCoverByTests<T>(this T toolSettings, IEnumerable<string> coverByTests) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.AddRange(coverByTests);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.CoverByTests"/></em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T ClearCoverByTests<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.CoverByTests"/></em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T RemoveCoverByTests<T>(this T toolSettings, params string[] coverByTests) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverByTests);
            toolSettings.CoverByTestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.CoverByTests"/></em></p>
        ///   <p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p>
        /// </summary>
        [Pure]
        public static T RemoveCoverByTests<T>(this T toolSettings, IEnumerable<string> coverByTests) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverByTests);
            toolSettings.CoverByTestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PerformanceCounters
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.PerformanceCounters"/></em></p>
        ///   <p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetPerformanceCounters<T>(this T toolSettings, bool? performanceCounters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = performanceCounters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.PerformanceCounters"/></em></p>
        ///   <p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetPerformanceCounters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.PerformanceCounters"/></em></p>
        ///   <p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p>
        /// </summary>
        [Pure]
        public static T EnablePerformanceCounters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.PerformanceCounters"/></em></p>
        ///   <p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p>
        /// </summary>
        [Pure]
        public static T DisablePerformanceCounters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.PerformanceCounters"/></em></p>
        ///   <p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p>
        /// </summary>
        [Pure]
        public static T TogglePerformanceCounters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = !toolSettings.PerformanceCounters;
            return toolSettings;
        }
        #endregion
        #region ExcludeByAttributes
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list</em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeByAttributes<T>(this T toolSettings, params string[] excludeByAttributes) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list</em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeByAttributes<T>(this T toolSettings, IEnumerable<string> excludeByAttributes) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByAttributes"/></em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeByAttributes<T>(this T toolSettings, params string[] excludeByAttributes) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByAttributes"/></em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeByAttributes<T>(this T toolSettings, IEnumerable<string> excludeByAttributes) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.ExcludeByAttributes"/></em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeByAttributes<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByAttributes"/></em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeByAttributes<T>(this T toolSettings, params string[] excludeByAttributes) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByAttributes);
            toolSettings.ExcludeByAttributesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByAttributes"/></em></p>
        ///   <p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeByAttributes<T>(this T toolSettings, IEnumerable<string> excludeByAttributes) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByAttributes);
            toolSettings.ExcludeByAttributesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeByFile
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list</em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeByFile<T>(this T toolSettings, params string[] excludeByFile) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list</em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeByFile<T>(this T toolSettings, IEnumerable<string> excludeByFile) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByFile"/></em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeByFile<T>(this T toolSettings, params string[] excludeByFile) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByFile"/></em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeByFile<T>(this T toolSettings, IEnumerable<string> excludeByFile) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.ExcludeByFile"/></em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeByFile<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByFile"/></em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeByFile<T>(this T toolSettings, params string[] excludeByFile) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByFile);
            toolSettings.ExcludeByFileInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByFile"/></em></p>
        ///   <p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeByFile<T>(this T toolSettings, IEnumerable<string> excludeByFile) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByFile);
            toolSettings.ExcludeByFileInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeDirectories
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list</em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeDirectories<T>(this T toolSettings, params string[] excludeDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list</em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeDirectories<T>(this T toolSettings, IEnumerable<string> excludeDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.ExcludeDirectories"/></em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeDirectories<T>(this T toolSettings, params string[] excludeDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.ExcludeDirectories"/></em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeDirectories<T>(this T toolSettings, IEnumerable<string> excludeDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.ExcludeDirectories"/></em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeDirectories<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.ExcludeDirectories"/></em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeDirectories<T>(this T toolSettings, params string[] excludeDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeDirectories);
            toolSettings.ExcludeDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.ExcludeDirectories"/></em></p>
        ///   <p>Assemblies being loaded from these locations will be ignored.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeDirectories<T>(this T toolSettings, IEnumerable<string> excludeDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeDirectories);
            toolSettings.ExcludeDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.Filters"/> to a new list</em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, params string[] filters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.Filters"/> to a new list</em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.Filters"/></em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, params string[] filters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.Filters"/></em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.Filters"/></em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T ClearFilters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.Filters"/></em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, params string[] filters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.Filters"/></em></p>
        ///   <p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HideSkippedKinds
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.HideSkippedKinds"/> to a new list</em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T SetHideSkippedKinds<T>(this T toolSettings, params OpenCoverSkipping[] hideSkippedKinds) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal = hideSkippedKinds.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.HideSkippedKinds"/> to a new list</em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T SetHideSkippedKinds<T>(this T toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal = hideSkippedKinds.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.HideSkippedKinds"/></em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T AddHideSkippedKinds<T>(this T toolSettings, params OpenCoverSkipping[] hideSkippedKinds) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.AddRange(hideSkippedKinds);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.HideSkippedKinds"/></em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T AddHideSkippedKinds<T>(this T toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.AddRange(hideSkippedKinds);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.HideSkippedKinds"/></em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T ClearHideSkippedKinds<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.HideSkippedKinds"/></em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T RemoveHideSkippedKinds<T>(this T toolSettings, params OpenCoverSkipping[] hideSkippedKinds) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OpenCoverSkipping>(hideSkippedKinds);
            toolSettings.HideSkippedKindsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.HideSkippedKinds"/></em></p>
        ///   <p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p>
        /// </summary>
        [Pure]
        public static T RemoveHideSkippedKinds<T>(this T toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OpenCoverSkipping>(hideSkippedKinds);
            toolSettings.HideSkippedKindsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.Verbosity"/></em></p>
        ///   <p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, OpenCoverVerbosity verbosity) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.Verbosity"/></em></p>
        ///   <p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region MergeByHash
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.MergeByHash"/></em></p>
        ///   <p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p>
        /// </summary>
        [Pure]
        public static T SetMergeByHash<T>(this T toolSettings, bool? mergeByHash) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = mergeByHash;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.MergeByHash"/></em></p>
        ///   <p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p>
        /// </summary>
        [Pure]
        public static T ResetMergeByHash<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.MergeByHash"/></em></p>
        ///   <p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p>
        /// </summary>
        [Pure]
        public static T EnableMergeByHash<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.MergeByHash"/></em></p>
        ///   <p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p>
        /// </summary>
        [Pure]
        public static T DisableMergeByHash<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.MergeByHash"/></em></p>
        ///   <p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p>
        /// </summary>
        [Pure]
        public static T ToggleMergeByHash<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = !toolSettings.MergeByHash;
            return toolSettings;
        }
        #endregion
        #region MergeOutput
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.MergeOutput"/></em></p>
        ///   <p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p>
        /// </summary>
        [Pure]
        public static T SetMergeOutput<T>(this T toolSettings, bool? mergeOutput) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = mergeOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.MergeOutput"/></em></p>
        ///   <p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p>
        /// </summary>
        [Pure]
        public static T ResetMergeOutput<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.MergeOutput"/></em></p>
        ///   <p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p>
        /// </summary>
        [Pure]
        public static T EnableMergeOutput<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.MergeOutput"/></em></p>
        ///   <p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p>
        /// </summary>
        [Pure]
        public static T DisableMergeOutput<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.MergeOutput"/></em></p>
        ///   <p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p>
        /// </summary>
        [Pure]
        public static T ToggleMergeOutput<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = !toolSettings.MergeOutput;
            return toolSettings;
        }
        #endregion
        #region NoDefaultFilters
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.NoDefaultFilters"/></em></p>
        ///   <p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p>
        /// </summary>
        [Pure]
        public static T SetNoDefaultFilters<T>(this T toolSettings, bool? noDefaultFilters) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = noDefaultFilters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.NoDefaultFilters"/></em></p>
        ///   <p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetNoDefaultFilters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.NoDefaultFilters"/></em></p>
        ///   <p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p>
        /// </summary>
        [Pure]
        public static T EnableNoDefaultFilters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.NoDefaultFilters"/></em></p>
        ///   <p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p>
        /// </summary>
        [Pure]
        public static T DisableNoDefaultFilters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.NoDefaultFilters"/></em></p>
        ///   <p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p>
        /// </summary>
        [Pure]
        public static T ToggleNoDefaultFilters<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = !toolSettings.NoDefaultFilters;
            return toolSettings;
        }
        #endregion
        #region OldStyle
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.OldStyle"/></em></p>
        ///   <p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p>
        /// </summary>
        [Pure]
        public static T SetOldStyle<T>(this T toolSettings, bool? oldStyle) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = oldStyle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.OldStyle"/></em></p>
        ///   <p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p>
        /// </summary>
        [Pure]
        public static T ResetOldStyle<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.OldStyle"/></em></p>
        ///   <p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p>
        /// </summary>
        [Pure]
        public static T EnableOldStyle<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.OldStyle"/></em></p>
        ///   <p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p>
        /// </summary>
        [Pure]
        public static T DisableOldStyle<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.OldStyle"/></em></p>
        ///   <p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p>
        /// </summary>
        [Pure]
        public static T ToggleOldStyle<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = !toolSettings.OldStyle;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.Output"/></em></p>
        ///   <p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.Output"/></em></p>
        ///   <p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region SafeMode
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.SafeMode"/></em></p>
        ///   <p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p>
        /// </summary>
        [Pure]
        public static T SetSafeMode<T>(this T toolSettings, bool? safeMode) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = safeMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.SafeMode"/></em></p>
        ///   <p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p>
        /// </summary>
        [Pure]
        public static T ResetSafeMode<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.SafeMode"/></em></p>
        ///   <p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p>
        /// </summary>
        [Pure]
        public static T EnableSafeMode<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.SafeMode"/></em></p>
        ///   <p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p>
        /// </summary>
        [Pure]
        public static T DisableSafeMode<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.SafeMode"/></em></p>
        ///   <p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p>
        /// </summary>
        [Pure]
        public static T ToggleSafeMode<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = !toolSettings.SafeMode;
            return toolSettings;
        }
        #endregion
        #region SearchDirectories
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.SearchDirectories"/> to a new list</em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T SetSearchDirectories<T>(this T toolSettings, params string[] searchDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.SearchDirectories"/> to a new list</em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T SetSearchDirectories<T>(this T toolSettings, IEnumerable<string> searchDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.SearchDirectories"/></em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T AddSearchDirectories<T>(this T toolSettings, params string[] searchDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OpenCoverSettings.SearchDirectories"/></em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T AddSearchDirectories<T>(this T toolSettings, IEnumerable<string> searchDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OpenCoverSettings.SearchDirectories"/></em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T ClearSearchDirectories<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.SearchDirectories"/></em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T RemoveSearchDirectories<T>(this T toolSettings, params string[] searchDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(searchDirectories);
            toolSettings.SearchDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OpenCoverSettings.SearchDirectories"/></em></p>
        ///   <p>Alternative locations to look for PDBs.</p>
        /// </summary>
        [Pure]
        public static T RemoveSearchDirectories<T>(this T toolSettings, IEnumerable<string> searchDirectories) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(searchDirectories);
            toolSettings.SearchDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Service
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.Service"/></em></p>
        ///   <p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p>
        /// </summary>
        [Pure]
        public static T SetService<T>(this T toolSettings, bool? service) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = service;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.Service"/></em></p>
        ///   <p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p>
        /// </summary>
        [Pure]
        public static T ResetService<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.Service"/></em></p>
        ///   <p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p>
        /// </summary>
        [Pure]
        public static T EnableService<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.Service"/></em></p>
        ///   <p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p>
        /// </summary>
        [Pure]
        public static T DisableService<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.Service"/></em></p>
        ///   <p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p>
        /// </summary>
        [Pure]
        public static T ToggleService<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = !toolSettings.Service;
            return toolSettings;
        }
        #endregion
        #region ShowUnvisited
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.ShowUnvisited"/></em></p>
        ///   <p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p>
        /// </summary>
        [Pure]
        public static T SetShowUnvisited<T>(this T toolSettings, bool? showUnvisited) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = showUnvisited;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.ShowUnvisited"/></em></p>
        ///   <p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p>
        /// </summary>
        [Pure]
        public static T ResetShowUnvisited<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.ShowUnvisited"/></em></p>
        ///   <p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p>
        /// </summary>
        [Pure]
        public static T EnableShowUnvisited<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.ShowUnvisited"/></em></p>
        ///   <p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p>
        /// </summary>
        [Pure]
        public static T DisableShowUnvisited<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.ShowUnvisited"/></em></p>
        ///   <p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowUnvisited<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = !toolSettings.ShowUnvisited;
            return toolSettings;
        }
        #endregion
        #region SkipAutoProperties
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.SkipAutoProperties"/></em></p>
        ///   <p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p>
        /// </summary>
        [Pure]
        public static T SetSkipAutoProperties<T>(this T toolSettings, bool? skipAutoProperties) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = skipAutoProperties;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.SkipAutoProperties"/></em></p>
        ///   <p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p>
        /// </summary>
        [Pure]
        public static T ResetSkipAutoProperties<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OpenCoverSettings.SkipAutoProperties"/></em></p>
        ///   <p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p>
        /// </summary>
        [Pure]
        public static T EnableSkipAutoProperties<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OpenCoverSettings.SkipAutoProperties"/></em></p>
        ///   <p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p>
        /// </summary>
        [Pure]
        public static T DisableSkipAutoProperties<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OpenCoverSettings.SkipAutoProperties"/></em></p>
        ///   <p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p>
        /// </summary>
        [Pure]
        public static T ToggleSkipAutoProperties<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = !toolSettings.SkipAutoProperties;
            return toolSettings;
        }
        #endregion
        #region MaximumVisitCount
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.MaximumVisitCount"/></em></p>
        ///   <p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p>
        /// </summary>
        [Pure]
        public static T SetMaximumVisitCount<T>(this T toolSettings, int? maximumVisitCount) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaximumVisitCount = maximumVisitCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.MaximumVisitCount"/></em></p>
        ///   <p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p>
        /// </summary>
        [Pure]
        public static T ResetMaximumVisitCount<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaximumVisitCount = null;
            return toolSettings;
        }
        #endregion
        #region Registration
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.Registration"/></em></p>
        ///   <p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p>
        /// </summary>
        [Pure]
        public static T SetRegistration<T>(this T toolSettings, RegistrationType registration) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Registration = registration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.Registration"/></em></p>
        ///   <p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetRegistration<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Registration = null;
            return toolSettings;
        }
        #endregion
        #region TargetExitCodeOffset
        /// <summary>
        ///   <p><em>Sets <see cref="OpenCoverSettings.TargetExitCodeOffset"/></em></p>
        ///   <p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p>
        /// </summary>
        [Pure]
        public static T SetTargetExitCodeOffset<T>(this T toolSettings, int? targetExitCodeOffset) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExitCodeOffset = targetExitCodeOffset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OpenCoverSettings.TargetExitCodeOffset"/></em></p>
        ///   <p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetExitCodeOffset<T>(this T toolSettings) where T : OpenCoverSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExitCodeOffset = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OpenCoverVerbosity
    /// <summary>
    ///   Used within <see cref="OpenCoverTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="OpenCoverTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="OpenCoverTasks"/>.
    /// </summary>
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
}
