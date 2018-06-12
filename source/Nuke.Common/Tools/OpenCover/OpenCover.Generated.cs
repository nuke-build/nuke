// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/OpenCover.json.

using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.OpenCover
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OpenCoverTasks
    {
        /// <summary><p>Path to the OpenCover executable.</p></summary>
        public static string OpenCoverPath => ToolPathResolver.GetPackageExecutable("OpenCover", "OpenCover.Console.exe");
        /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
        public static IEnumerable<string> OpenCover(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool redirectOutput = false, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(OpenCoverPath, arguments, workingDirectory, environmentVariables, timeout, redirectOutput, outputFilter);
            process.AssertZeroExitCode();
            return process.HasOutput ? process.Output.Select(x => x.Text) : null;
        }
        static partial void PreProcess(OpenCoverSettings toolSettings);
        static partial void PostProcess(OpenCoverSettings toolSettings);
        /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
        public static void OpenCover(Configure<OpenCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new OpenCoverSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region OpenCoverSettings
    /// <summary><p>Used within <see cref="OpenCoverTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OpenCoverSettings : ToolSettings
    {
        /// <summary><p>Path to the OpenCover executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? OpenCoverTasks.OpenCoverPath;
        /// <summary><p>The name of the target application or service that will be started; this can also be a path to the target application.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Arguments to be passed to the target process.</p></summary>
        public virtual string TargetArguments { get; internal set; }
        /// <summary><p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p></summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        public virtual IReadOnlyList<string> CoverByTests => CoverByTestsInternal.AsReadOnly();
        internal List<string> CoverByTestsInternal { get; set; } = new List<string>();
        /// <summary><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        public virtual bool? PerformanceCounters { get; internal set; }
        /// <summary><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        public virtual IReadOnlyList<string> ExcludeByAttributes => ExcludeByAttributesInternal.AsReadOnly();
        internal List<string> ExcludeByAttributesInternal { get; set; } = new List<string>();
        /// <summary><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        public virtual IReadOnlyList<string> ExcludeByFile => ExcludeByFileInternal.AsReadOnly();
        internal List<string> ExcludeByFileInternal { get; set; } = new List<string>();
        /// <summary><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        public virtual IReadOnlyList<string> ExcludeDirectories => ExcludeDirectoriesInternal.AsReadOnly();
        internal List<string> ExcludeDirectoriesInternal { get; set; } = new List<string>();
        /// <summary><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        public virtual IReadOnlyList<OpenCoverSkipping> HideSkippedKinds => HideSkippedKindsInternal.AsReadOnly();
        internal List<OpenCoverSkipping> HideSkippedKindsInternal { get; set; } = new List<OpenCoverSkipping>();
        /// <summary><p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p></summary>
        public virtual OpenCoverVerbosity Verbosity { get; internal set; }
        /// <summary><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        public virtual bool? MergeByHash { get; internal set; }
        /// <summary><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        public virtual bool? MergeOutput { get; internal set; }
        /// <summary><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        public virtual bool? NoDefaultFilters { get; internal set; }
        /// <summary><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        public virtual bool? OldStyle { get; internal set; }
        /// <summary><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        public virtual bool? SafeMode { get; internal set; }
        /// <summary><p>Alternative locations to look for PDBs.</p></summary>
        public virtual IReadOnlyList<string> SearchDirectories => SearchDirectoriesInternal.AsReadOnly();
        internal List<string> SearchDirectoriesInternal { get; set; } = new List<string>();
        /// <summary><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        public virtual bool? Service { get; internal set; }
        /// <summary><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        public virtual bool? ShowUnvisited { get; internal set; }
        /// <summary><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        public virtual bool? SkipAutoProperties { get; internal set; }
        /// <summary><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        public virtual int? MaximumVisitCount { get; internal set; }
        /// <summary><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p></summary>
        public virtual RegistrationType Registration { get; internal set; }
        /// <summary><p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p></summary>
        public virtual int? TargetExitCodeOffset { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), "File.Exists(TargetPath)");
            ControlFlow.Assert(Directory.Exists(TargetDirectory) || TargetDirectory == null, "Directory.Exists(TargetDirectory) || TargetDirectory == null");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region OpenCoverSettingsExtensions
    /// <summary><p>Used within <see cref="OpenCoverTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OpenCoverSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.TargetPath"/>.</em></p><p>The name of the target application or service that will be started; this can also be a path to the target application.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetPath(this OpenCoverSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.TargetPath"/>.</em></p><p>The name of the target application or service that will be started; this can also be a path to the target application.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetTargetPath(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region TargetArguments
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.TargetArguments"/>.</em></p><p>Arguments to be passed to the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetArguments(this OpenCoverSettings toolSettings, string targetArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.TargetArguments"/>.</em></p><p>Arguments to be passed to the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetTargetArguments(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.TargetDirectory"/>.</em></p><p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetDirectory(this OpenCoverSettings toolSettings, string targetDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.TargetDirectory"/>.</em></p><p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetTargetDirectory(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region CoverByTests
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.CoverByTests"/> to a new list.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings SetCoverByTests(this OpenCoverSettings toolSettings, params string[] coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal = coverByTests.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.CoverByTests"/> to a new list.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings SetCoverByTests(this OpenCoverSettings toolSettings, IEnumerable<string> coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal = coverByTests.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.CoverByTests"/>.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTests(this OpenCoverSettings toolSettings, params string[] coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.AddRange(coverByTests);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.CoverByTests"/>.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTests(this OpenCoverSettings toolSettings, IEnumerable<string> coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.AddRange(coverByTests);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.CoverByTests"/>.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearCoverByTests(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.CoverByTests"/>.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveCoverByTests(this OpenCoverSettings toolSettings, params string[] coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverByTests);
            toolSettings.CoverByTestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.CoverByTests"/>.</em></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveCoverByTests(this OpenCoverSettings toolSettings, IEnumerable<string> coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverByTests);
            toolSettings.CoverByTestsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PerformanceCounters
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.PerformanceCounters"/>.</em></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings SetPerformanceCounters(this OpenCoverSettings toolSettings, bool? performanceCounters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = performanceCounters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.PerformanceCounters"/>.</em></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings ResetPerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.PerformanceCounters"/>.</em></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings EnablePerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.PerformanceCounters"/>.</em></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings DisablePerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.PerformanceCounters"/>.</em></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings TogglePerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = !toolSettings.PerformanceCounters;
            return toolSettings;
        }
        #endregion
        #region ExcludeByAttributes
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByAttributes(this OpenCoverSettings toolSettings, params string[] excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByAttributes(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttributes(this OpenCoverSettings toolSettings, params string[] excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttributes(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeByAttributes(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByAttributes(this OpenCoverSettings toolSettings, params string[] excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByAttributes);
            toolSettings.ExcludeByAttributesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</em></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByAttributes(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByAttributes);
            toolSettings.ExcludeByAttributesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeByFile
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByFile(this OpenCoverSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByFile(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByFile"/>.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.ExcludeByFile"/>.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.ExcludeByFile"/>.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeByFile(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByFile"/>.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByFile(this OpenCoverSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByFile);
            toolSettings.ExcludeByFileInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.ExcludeByFile"/>.</em></p><p>Exclude a class (or methods) by file-filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByFile(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByFile);
            toolSettings.ExcludeByFileInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeDirectories
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeDirectories(this OpenCoverSettings toolSettings, params string[] excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.ExcludeDirectories"/>.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectories(this OpenCoverSettings toolSettings, params string[] excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.ExcludeDirectories"/>.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.ExcludeDirectories"/>.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeDirectories(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.ExcludeDirectories"/>.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeDirectories(this OpenCoverSettings toolSettings, params string[] excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeDirectories);
            toolSettings.ExcludeDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.ExcludeDirectories"/>.</em></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeDirectories);
            toolSettings.ExcludeDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.Filters"/> to a new list.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings SetFilters(this OpenCoverSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.Filters"/> to a new list.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings SetFilters(this OpenCoverSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.Filters"/>.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilters(this OpenCoverSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.Filters"/>.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilters(this OpenCoverSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.Filters"/>.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings ClearFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.Filters"/>.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings RemoveFilters(this OpenCoverSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.Filters"/>.</em></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings RemoveFilters(this OpenCoverSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HideSkippedKinds
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.HideSkippedKinds"/> to a new list.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetHideSkippedKinds(this OpenCoverSettings toolSettings, params OpenCoverSkipping[] hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal = hideSkippedKinds.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.HideSkippedKinds"/> to a new list.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetHideSkippedKinds(this OpenCoverSettings toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal = hideSkippedKinds.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.HideSkippedKinds"/>.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings AddHideSkippedKinds(this OpenCoverSettings toolSettings, params OpenCoverSkipping[] hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.AddRange(hideSkippedKinds);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.HideSkippedKinds"/>.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings AddHideSkippedKinds(this OpenCoverSettings toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.AddRange(hideSkippedKinds);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.HideSkippedKinds"/>.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings ClearHideSkippedKinds(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.HideSkippedKinds"/>.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings RemoveHideSkippedKinds(this OpenCoverSettings toolSettings, params OpenCoverSkipping[] hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OpenCoverSkipping>(hideSkippedKinds);
            toolSettings.HideSkippedKindsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.HideSkippedKinds"/>.</em></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings RemoveHideSkippedKinds(this OpenCoverSettings toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OpenCoverSkipping>(hideSkippedKinds);
            toolSettings.HideSkippedKindsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.Verbosity"/>.</em></p><p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p></summary>
        [Pure]
        public static OpenCoverSettings SetVerbosity(this OpenCoverSettings toolSettings, OpenCoverVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.Verbosity"/>.</em></p><p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetVerbosity(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region MergeByHash
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.MergeByHash"/>.</em></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings SetMergeByHash(this OpenCoverSettings toolSettings, bool? mergeByHash)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = mergeByHash;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.MergeByHash"/>.</em></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.MergeByHash"/>.</em></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.MergeByHash"/>.</em></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.MergeByHash"/>.</em></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = !toolSettings.MergeByHash;
            return toolSettings;
        }
        #endregion
        #region MergeOutput
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.MergeOutput"/>.</em></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings SetMergeOutput(this OpenCoverSettings toolSettings, bool? mergeOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = mergeOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.MergeOutput"/>.</em></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings ResetMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.MergeOutput"/>.</em></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings EnableMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.MergeOutput"/>.</em></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings DisableMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.MergeOutput"/>.</em></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = !toolSettings.MergeOutput;
            return toolSettings;
        }
        #endregion
        #region NoDefaultFilters
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.NoDefaultFilters"/>.</em></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings SetNoDefaultFilters(this OpenCoverSettings toolSettings, bool? noDefaultFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = noDefaultFilters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.NoDefaultFilters"/>.</em></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings ResetNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.NoDefaultFilters"/>.</em></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings EnableNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.NoDefaultFilters"/>.</em></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings DisableNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.NoDefaultFilters"/>.</em></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings ToggleNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = !toolSettings.NoDefaultFilters;
            return toolSettings;
        }
        #endregion
        #region OldStyle
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.OldStyle"/>.</em></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings SetOldStyle(this OpenCoverSettings toolSettings, bool? oldStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = oldStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.OldStyle"/>.</em></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.OldStyle"/>.</em></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.OldStyle"/>.</em></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.OldStyle"/>.</em></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = !toolSettings.OldStyle;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.Output"/>.</em></p><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        [Pure]
        public static OpenCoverSettings SetOutput(this OpenCoverSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.Output"/>.</em></p><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region SafeMode
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.SafeMode"/>.</em></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSafeMode(this OpenCoverSettings toolSettings, bool? safeMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = safeMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.SafeMode"/>.</em></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.SafeMode"/>.</em></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.SafeMode"/>.</em></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.SafeMode"/>.</em></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = !toolSettings.SafeMode;
            return toolSettings;
        }
        #endregion
        #region SearchDirectories
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.SearchDirectories"/> to a new list.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSearchDirectories(this OpenCoverSettings toolSettings, params string[] searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.SearchDirectories"/> to a new list.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSearchDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.SearchDirectories"/>.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectories(this OpenCoverSettings toolSettings, params string[] searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OpenCoverSettings.SearchDirectories"/>.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OpenCoverSettings.SearchDirectories"/>.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearSearchDirectories(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.SearchDirectories"/>.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveSearchDirectories(this OpenCoverSettings toolSettings, params string[] searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(searchDirectories);
            toolSettings.SearchDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OpenCoverSettings.SearchDirectories"/>.</em></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveSearchDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(searchDirectories);
            toolSettings.SearchDirectoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Service
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.Service"/>.</em></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings SetService(this OpenCoverSettings toolSettings, bool? service)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = service;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.Service"/>.</em></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.Service"/>.</em></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.Service"/>.</em></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.Service"/>.</em></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = !toolSettings.Service;
            return toolSettings;
        }
        #endregion
        #region ShowUnvisited
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.ShowUnvisited"/>.</em></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings SetShowUnvisited(this OpenCoverSettings toolSettings, bool? showUnvisited)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = showUnvisited;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.ShowUnvisited"/>.</em></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.ShowUnvisited"/>.</em></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.ShowUnvisited"/>.</em></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.ShowUnvisited"/>.</em></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = !toolSettings.ShowUnvisited;
            return toolSettings;
        }
        #endregion
        #region SkipAutoProperties
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.SkipAutoProperties"/>.</em></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetSkipAutoProperties(this OpenCoverSettings toolSettings, bool? skipAutoProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = skipAutoProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.SkipAutoProperties"/>.</em></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings ResetSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OpenCoverSettings.SkipAutoProperties"/>.</em></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings EnableSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OpenCoverSettings.SkipAutoProperties"/>.</em></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings DisableSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OpenCoverSettings.SkipAutoProperties"/>.</em></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings ToggleSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = !toolSettings.SkipAutoProperties;
            return toolSettings;
        }
        #endregion
        #region MaximumVisitCount
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.MaximumVisitCount"/>.</em></p><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        [Pure]
        public static OpenCoverSettings SetMaximumVisitCount(this OpenCoverSettings toolSettings, int? maximumVisitCount)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaximumVisitCount = maximumVisitCount;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.MaximumVisitCount"/>.</em></p><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetMaximumVisitCount(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaximumVisitCount = null;
            return toolSettings;
        }
        #endregion
        #region Registration
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.Registration"/>.</em></p><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p></summary>
        [Pure]
        public static OpenCoverSettings SetRegistration(this OpenCoverSettings toolSettings, RegistrationType registration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Registration = registration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.Registration"/>.</em></p><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetRegistration(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Registration = null;
            return toolSettings;
        }
        #endregion
        #region TargetExitCodeOffset
        /// <summary><p><em>Sets <see cref="OpenCoverSettings.TargetExitCodeOffset"/>.</em></p><p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetExitCodeOffset(this OpenCoverSettings toolSettings, int? targetExitCodeOffset)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExitCodeOffset = targetExitCodeOffset;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OpenCoverSettings.TargetExitCodeOffset"/>.</em></p><p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings ResetTargetExitCodeOffset(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExitCodeOffset = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OpenCoverVerbosity
    /// <summary><p>Used within <see cref="OpenCoverTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class OpenCoverVerbosity : Enumeration
    {
        public static OpenCoverVerbosity Off = new OpenCoverVerbosity { Value = "Off" };
        public static OpenCoverVerbosity Fatal = new OpenCoverVerbosity { Value = "Fatal" };
        public static OpenCoverVerbosity Error = new OpenCoverVerbosity { Value = "Error" };
        public static OpenCoverVerbosity Warn = new OpenCoverVerbosity { Value = "Warn" };
        public static OpenCoverVerbosity Info = new OpenCoverVerbosity { Value = "Info" };
        public static OpenCoverVerbosity Debug = new OpenCoverVerbosity { Value = "Debug" };
        public static OpenCoverVerbosity Verbose = new OpenCoverVerbosity { Value = "Verbose" };
        public static OpenCoverVerbosity All = new OpenCoverVerbosity { Value = "All" };
    }
    #endregion
    #region OpenCoverSkipping
    /// <summary><p>Used within <see cref="OpenCoverTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class OpenCoverSkipping : Enumeration
    {
        public static OpenCoverSkipping File = new OpenCoverSkipping { Value = "File" };
        public static OpenCoverSkipping Filter = new OpenCoverSkipping { Value = "Filter" };
        public static OpenCoverSkipping Attribute = new OpenCoverSkipping { Value = "Attribute" };
        public static OpenCoverSkipping MissingPdb = new OpenCoverSkipping { Value = "MissingPdb" };
    }
    #endregion
    #region RegistrationType
    /// <summary><p>Used within <see cref="OpenCoverTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class RegistrationType : Enumeration
    {
        public static RegistrationType User = new RegistrationType { Value = "User" };
        public static RegistrationType Path32 = new RegistrationType { Value = "Path32" };
        public static RegistrationType Path64 = new RegistrationType { Value = "Path64" };
    }
    #endregion
}
