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

[assembly: IconClass(typeof(Nuke.Common.Tools.OpenCover.OpenCoverTasks), "shield2")]

namespace Nuke.Common.Tools.OpenCover
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OpenCoverTasks
    {
        static partial void PreProcess (OpenCoverSettings toolSettings);
        static partial void PostProcess (OpenCoverSettings toolSettings);
        /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
        public static void OpenCover (Configure<OpenCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new OpenCoverSettings());
            PreProcess(toolSettings);
            var process = StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
        public static void OpenCover (Action testAction, Configure<OpenCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            OpenCover(x => configurator(x).SetTestAction(testAction));
        }
        /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
        public static void OpenCover (Action testAction, string output, Configure<OpenCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            OpenCover(testAction, x => configurator(x).SetOutput(output));
        }
    }
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OpenCoverSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"OpenCover", packageExecutable: $"OpenCover.Console.exe");
        /// <summary><p>The action that executes tests.</p></summary>
        public virtual Action TestAction { get; internal set; }
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
        public virtual bool PerformanceCounters { get; internal set; }
        /// <summary><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        public virtual IReadOnlyList<string> ExcludeByAttributes => ExcludeByAttributesInternal.AsReadOnly();
        internal List<string> ExcludeByAttributesInternal { get; set; } = new List<string>();
        /// <summary><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
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
        public virtual OpenCoverVerbosity? Verbosity { get; internal set; }
        /// <summary><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        public virtual bool MergeByHash { get; internal set; }
        /// <summary><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        public virtual bool MergeOutput { get; internal set; }
        /// <summary><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        public virtual bool NoDefaultFilters { get; internal set; }
        /// <summary><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        public virtual bool OldStyle { get; internal set; }
        /// <summary><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        public virtual bool SafeMode { get; internal set; }
        /// <summary><p>Alternative locations to look for PDBs.</p></summary>
        public virtual IReadOnlyList<string> SearchDirectories => SearchDirectoriesInternal.AsReadOnly();
        internal List<string> SearchDirectoriesInternal { get; set; } = new List<string>();
        /// <summary><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        public virtual bool Service { get; internal set; }
        /// <summary><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        public virtual bool ShowUnvisited { get; internal set; }
        /// <summary><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        public virtual bool SkipAutoProperties { get; internal set; }
        /// <summary><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        public virtual int? MaximumVisitCount { get; internal set; }
        /// <summary><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p></summary>
        public virtual RegistrationType? Registration { get; internal set; }
        /// <summary><p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p></summary>
        public virtual int? TargetExitCodeOffset { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath)");
            ControlFlow.Assert(Directory.Exists(TargetDirectory) || TargetDirectory == null, $"Directory.Exists(TargetDirectory) || TargetDirectory == null");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("-target:{value}", TargetPath)
              .Add("-targetargs:{value}", TargetArguments)
              .Add("-targetdir:{value}", TargetDirectory)
              .Add("-coverbytest:{value}", CoverByTests, mainSeparator: $";")
              .Add("-enableperformancecounters", PerformanceCounters)
              .Add("-excludebyattribute:{value}", ExcludeByAttributes, mainSeparator: $";")
              .Add("-excludebyfile:{value}", ExcludeByFile, mainSeparator: $";")
              .Add("-excludedirs:{value}", ExcludeDirectories, mainSeparator: $";")
              .Add("-filter:{value}", Filters, mainSeparator: $" ")
              .Add("-hideskipped:{value}", HideSkippedKinds, mainSeparator: $";")
              .Add("-log:{value}", Verbosity)
              .Add("-mergebyhash", MergeByHash)
              .Add("-mergeoutput", MergeOutput)
              .Add("-nodefaultfilters", NoDefaultFilters)
              .Add("-oldStyle", OldStyle)
              .Add("-output:{value}", Output)
              .Add("-safemode:{value}", SafeMode)
              .Add("-searchdirs:{value}", SearchDirectories, mainSeparator: $";")
              .Add("-service", Service)
              .Add("-showunvisited", ShowUnvisited)
              .Add("-skipautoprops", SkipAutoProperties)
              .Add("-threshold:{value}", MaximumVisitCount)
              .Add("-register:{value}", Registration)
              .Add("-returntargetcode:{value}", TargetExitCodeOffset);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OpenCoverSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TestAction"/>.</i></p><p>The action that executes tests.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTestAction(this OpenCoverSettings toolSettings, Action testAction)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestAction = testAction;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetPath"/>.</i></p><p>The name of the target application or service that will be started; this can also be a path to the target application.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetPath(this OpenCoverSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetArguments"/>.</i></p><p>Arguments to be passed to the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetArguments(this OpenCoverSettings toolSettings, string targetArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArguments = targetArguments;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetDirectory"/>.</i></p><p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetDirectory(this OpenCoverSettings toolSettings, string targetDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.CoverByTests"/> to a new list.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings SetCoverByTests(this OpenCoverSettings toolSettings, params string[] coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal = coverByTests.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.CoverByTests"/> to a new list.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings SetCoverByTests(this OpenCoverSettings toolSettings, IEnumerable<string> coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal = coverByTests.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new coverByTests to the existing <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTests(this OpenCoverSettings toolSettings, params string[] coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.AddRange(coverByTests);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new coverByTests to the existing <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTests(this OpenCoverSettings toolSettings, IEnumerable<string> coverByTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.AddRange(coverByTests);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearCoverByTests(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single coverByTest to <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTest(this OpenCoverSettings toolSettings, string coverByTest, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (coverByTest != null || evenIfNull) toolSettings.CoverByTestsInternal.Add(coverByTest);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single coverByTest from <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveCoverByTest(this OpenCoverSettings toolSettings, string coverByTest)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverByTestsInternal.Remove(coverByTest);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings SetPerformanceCounters(this OpenCoverSettings toolSettings, bool performanceCounters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = performanceCounters;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings EnablePerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings DisablePerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><em>Administrator</em> privileges required. Allows the monitoring in <em>Performance Monitor</em> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings TogglePerformanceCounters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PerformanceCounters = !toolSettings.PerformanceCounters;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByAttributes(this OpenCoverSettings toolSettings, params string[] excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByAttributes(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByAttributes to the existing <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttributes(this OpenCoverSettings toolSettings, params string[] excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByAttributes to the existing <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttributes(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByAttributes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeByAttributes(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeByAttribute to <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttribute(this OpenCoverSettings toolSettings, string excludeByAttribute, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (excludeByAttribute != null || evenIfNull) toolSettings.ExcludeByAttributesInternal.Add(excludeByAttribute);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeByAttribute from <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByAttribute(this OpenCoverSettings toolSettings, string excludeByAttribute)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByAttributesInternal.Remove(excludeByAttribute);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByFile(this OpenCoverSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByFile(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByFile to the existing <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByFile to the existing <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeByFile(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeByFile to <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings toolSettings, string excludeByFile, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (excludeByFile != null || evenIfNull) toolSettings.ExcludeByFileInternal.Add(excludeByFile);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeByFile from <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByFile(this OpenCoverSettings toolSettings, string excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.Remove(excludeByFile);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeDirectories(this OpenCoverSettings toolSettings, params string[] excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeDirectories to the existing <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectories(this OpenCoverSettings toolSettings, params string[] excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeDirectories to the existing <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> excludeDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeDirectories(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeDirectory to <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectory(this OpenCoverSettings toolSettings, string excludeDirectory, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (excludeDirectory != null || evenIfNull) toolSettings.ExcludeDirectoriesInternal.Add(excludeDirectory);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeDirectory from <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeDirectory(this OpenCoverSettings toolSettings, string excludeDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeDirectoriesInternal.Remove(excludeDirectory);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Filters"/> to a new list.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings SetFilters(this OpenCoverSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Filters"/> to a new list.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings SetFilters(this OpenCoverSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilters(this OpenCoverSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilters(this OpenCoverSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings ClearFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single filter to <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilter(this OpenCoverSettings toolSettings, string filter, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (filter != null || evenIfNull) toolSettings.FiltersInternal.Add(filter);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single filter from <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <em>Open</em>, <c>-[*]Core.*</c> exclude all types in the <em>Core</em> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings RemoveFilter(this OpenCoverSettings toolSettings, string filter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Remove(filter);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.HideSkippedKinds"/> to a new list.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetHideSkippedKinds(this OpenCoverSettings toolSettings, params OpenCoverSkipping[] hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal = hideSkippedKinds.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.HideSkippedKinds"/> to a new list.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetHideSkippedKinds(this OpenCoverSettings toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal = hideSkippedKinds.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new hideSkippedKinds to the existing <see cref="OpenCoverSettings.HideSkippedKinds"/>.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings AddHideSkippedKinds(this OpenCoverSettings toolSettings, params OpenCoverSkipping[] hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.AddRange(hideSkippedKinds);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new hideSkippedKinds to the existing <see cref="OpenCoverSettings.HideSkippedKinds"/>.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings AddHideSkippedKinds(this OpenCoverSettings toolSettings, IEnumerable<OpenCoverSkipping> hideSkippedKinds)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.AddRange(hideSkippedKinds);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.HideSkippedKinds"/>.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings ClearHideSkippedKinds(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single hideSkippedKind to <see cref="OpenCoverSettings.HideSkippedKinds"/>.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings AddHideSkippedKind(this OpenCoverSettings toolSettings, OpenCoverSkipping hideSkippedKind)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.Add(hideSkippedKind);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single hideSkippedKind from <see cref="OpenCoverSettings.HideSkippedKinds"/>.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings RemoveHideSkippedKind(this OpenCoverSettings toolSettings, OpenCoverSkipping hideSkippedKind)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HideSkippedKindsInternal.Remove(hideSkippedKind);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Verbosity"/>.</i></p><p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p></summary>
        [Pure]
        public static OpenCoverSettings SetVerbosity(this OpenCoverSettings toolSettings, OpenCoverVerbosity? verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings SetMergeByHash(this OpenCoverSettings toolSettings, bool mergeByHash)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = mergeByHash;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleMergeByHash(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeByHash = !toolSettings.MergeByHash;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings SetMergeOutput(this OpenCoverSettings toolSettings, bool mergeOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = mergeOutput;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings EnableMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings DisableMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleMergeOutput(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeOutput = !toolSettings.MergeOutput;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings SetNoDefaultFilters(this OpenCoverSettings toolSettings, bool noDefaultFilters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = noDefaultFilters;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings EnableNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings DisableNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings ToggleNoDefaultFilters(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultFilters = !toolSettings.NoDefaultFilters;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings SetOldStyle(this OpenCoverSettings toolSettings, bool oldStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = oldStyle;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <em>ONLY</em> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <em>ngen /Profile</em> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleOldStyle(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OldStyle = !toolSettings.OldStyle;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Output"/>.</i></p><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        [Pure]
        public static OpenCoverSettings SetOutput(this OpenCoverSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSafeMode(this OpenCoverSettings toolSettings, bool safeMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = safeMode;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleSafeMode(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SafeMode = !toolSettings.SafeMode;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SearchDirectories"/> to a new list.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSearchDirectories(this OpenCoverSettings toolSettings, params string[] searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SearchDirectories"/> to a new list.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSearchDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new searchDirectories to the existing <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectories(this OpenCoverSettings toolSettings, params string[] searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding new searchDirectories to the existing <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectories(this OpenCoverSettings toolSettings, IEnumerable<string> searchDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearSearchDirectories(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Extension method for adding a single searchDirectory to <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectory(this OpenCoverSettings toolSettings, string searchDirectory, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (searchDirectory != null || evenIfNull) toolSettings.SearchDirectoriesInternal.Add(searchDirectory);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for removing a single searchDirectory from <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveSearchDirectory(this OpenCoverSettings toolSettings, string searchDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SearchDirectoriesInternal.Remove(searchDirectory);
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings SetService(this OpenCoverSettings toolSettings, bool service)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = service;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <em>Administrator</em> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleService(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = !toolSettings.Service;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings SetShowUnvisited(this OpenCoverSettings toolSettings, bool showUnvisited)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = showUnvisited;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleShowUnvisited(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowUnvisited = !toolSettings.ShowUnvisited;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetSkipAutoProperties(this OpenCoverSettings toolSettings, bool skipAutoProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = skipAutoProperties;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings EnableSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings DisableSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings ToggleSkipAutoProperties(this OpenCoverSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipAutoProperties = !toolSettings.SkipAutoProperties;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.MaximumVisitCount"/>.</i></p><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        [Pure]
        public static OpenCoverSettings SetMaximumVisitCount(this OpenCoverSettings toolSettings, int? maximumVisitCount)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaximumVisitCount = maximumVisitCount;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Registration"/>.</i></p><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <em>regsvr32</em> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <em>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</em> or <em>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</em>.</p></summary>
        [Pure]
        public static OpenCoverSettings SetRegistration(this OpenCoverSettings toolSettings, RegistrationType? registration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Registration = registration;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetExitCodeOffset"/>.</i></p><p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetExitCodeOffset(this OpenCoverSettings toolSettings, int? targetExitCodeOffset)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetExitCodeOffset = targetExitCodeOffset;
            return toolSettings;
        }
    }
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
    [PublicAPI]
    public enum OpenCoverVerbosity
    {
        Off,
        Fatal,
        Error,
        Warn,
        Info,
        Debug,
        Verbose,
        All,
    }
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
    [PublicAPI]
    public enum OpenCoverSkipping
    {
        File,
        Filter,
        Attribute,
        MissingPdb,
    }
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
    [PublicAPI]
    public enum RegistrationType
    {
        User,
        Path32,
        Path64,
    }
}
