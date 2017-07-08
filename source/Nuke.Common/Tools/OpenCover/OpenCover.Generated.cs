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
        static partial void PreProcess (OpenCoverSettings openCoverSettings);
        static partial void PostProcess (OpenCoverSettings openCoverSettings);
        /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p><p>For more details, visit the <a href="https://github.com/OpenCover/opencover">official website</a>.</p></summary>
        public static void OpenCover (Configure<OpenCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var openCoverSettings = configurator.InvokeSafe(new OpenCoverSettings());
            PreProcess(openCoverSettings);
            var process = StartProcess(openCoverSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(openCoverSettings);
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
        /// <summary><p><i>Administrator</i> privileges required. Allows the monitoring in <i>Performance Monitor</i> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
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
        /// <summary><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        public virtual OpenCoverSkipping? HideSkipped { get; internal set; }
        /// <summary><p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p></summary>
        public virtual OpenCoverVerbosity? Verbosity { get; internal set; }
        /// <summary><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        public virtual bool MergeByHash { get; internal set; }
        /// <summary><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        public virtual bool MergeOutput { get; internal set; }
        /// <summary><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        public virtual bool NoDefaultFilters { get; internal set; }
        /// <summary><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <i>ONLY</i> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <i>ngen /Profile</i> of the mscorlib which then interferes with the instrumentation.</p></summary>
        public virtual bool OldStyle { get; internal set; }
        /// <summary><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        public virtual bool SafeMode { get; internal set; }
        /// <summary><p>Alternative locations to look for PDBs.</p></summary>
        public virtual IReadOnlyList<string> SearchDirectories => SearchDirectoriesInternal.AsReadOnly();
        internal List<string> SearchDirectoriesInternal { get; set; } = new List<string>();
        /// <summary><p>The value provided in the target parameter is the name of a service rather than a name of a process. <i>Administrator</i> privileges recommended.</p></summary>
        public virtual bool Service { get; internal set; }
        /// <summary><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        public virtual bool ShowUnvisited { get; internal set; }
        /// <summary><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        public virtual bool SkipAutoProperties { get; internal set; }
        /// <summary><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        public virtual int? MaximumVisitCount { get; internal set; }
        /// <summary><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <i>regsvr32</i> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <i>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</i> or <i>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</i>.</p></summary>
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
              .Add("-hideskipped:{value}", HideSkipped)
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
        public static OpenCoverSettings SetTestAction(this OpenCoverSettings openCoverSettings, Action testAction)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.TestAction = testAction;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetPath"/>.</i></p><p>The name of the target application or service that will be started; this can also be a path to the target application.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetPath(this OpenCoverSettings openCoverSettings, string targetPath)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.TargetPath = targetPath;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetArguments"/>.</i></p><p>Arguments to be passed to the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetArguments(this OpenCoverSettings openCoverSettings, string targetArguments)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.TargetArguments = targetArguments;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetDirectory"/>.</i></p><p>The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetDirectory(this OpenCoverSettings openCoverSettings, string targetDirectory)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.TargetDirectory = targetDirectory;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.CoverByTests"/> to a new list.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings SetCoverByTests(this OpenCoverSettings openCoverSettings, params string[] coverByTests)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal = coverByTests.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.CoverByTests"/> to a new list.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings SetCoverByTests(this OpenCoverSettings openCoverSettings, IEnumerable<string> coverByTests)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal = coverByTests.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new coverByTests to the existing <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTests(this OpenCoverSettings openCoverSettings, params string[] coverByTests)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal.AddRange(coverByTests);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new coverByTests to the existing <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTests(this OpenCoverSettings openCoverSettings, IEnumerable<string> coverByTests)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal.AddRange(coverByTests);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearCoverByTests(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal.Clear();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single coverByTest to <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings AddCoverByTest(this OpenCoverSettings openCoverSettings, string coverByTest)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal.Add(coverByTest);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single coverByTest from <see cref="OpenCoverSettings.CoverByTests"/>.</i></p><p>Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveCoverByTest(this OpenCoverSettings openCoverSettings, string coverByTest)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.CoverByTestsInternal.Remove(coverByTest);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><i>Administrator</i> privileges required. Allows the monitoring in <i>Performance Monitor</i> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings SetPerformanceCounters(this OpenCoverSettings openCoverSettings, bool performanceCounters)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.PerformanceCounters = performanceCounters;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><i>Administrator</i> privileges required. Allows the monitoring in <i>Performance Monitor</i> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings EnablePerformanceCounters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.PerformanceCounters = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><i>Administrator</i> privileges required. Allows the monitoring in <i>Performance Monitor</i> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings DisablePerformanceCounters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.PerformanceCounters = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.PerformanceCounters"/>.</i></p><p><i>Administrator</i> privileges required. Allows the monitoring in <i>Performance Monitor</i> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings TogglePerformanceCounters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.PerformanceCounters = !openCoverSettings.PerformanceCounters;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByAttributes(this OpenCoverSettings openCoverSettings, params string[] excludeByAttributes)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByAttributes"/> to a new list.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByAttributes(this OpenCoverSettings openCoverSettings, IEnumerable<string> excludeByAttributes)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal = excludeByAttributes.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByAttributes to the existing <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttributes(this OpenCoverSettings openCoverSettings, params string[] excludeByAttributes)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByAttributes to the existing <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttributes(this OpenCoverSettings openCoverSettings, IEnumerable<string> excludeByAttributes)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal.AddRange(excludeByAttributes);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeByAttributes(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal.Clear();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeByAttribute to <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByAttribute(this OpenCoverSettings openCoverSettings, string excludeByAttribute)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal.Add(excludeByAttribute);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeByAttribute from <see cref="OpenCoverSettings.ExcludeByAttributes"/>.</i></p><p>Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByAttribute(this OpenCoverSettings openCoverSettings, string excludeByAttribute)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByAttributesInternal.Remove(excludeByAttribute);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByFile(this OpenCoverSettings openCoverSettings, params string[] excludeByFile)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeByFile"/> to a new list.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeByFile(this OpenCoverSettings openCoverSettings, IEnumerable<string> excludeByFile)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByFile to the existing <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings openCoverSettings, params string[] excludeByFile)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeByFile to the existing <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings openCoverSettings, IEnumerable<string> excludeByFile)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeByFile(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal.Clear();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeByFile to <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeByFile(this OpenCoverSettings openCoverSettings, string excludeByFile)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal.Add(excludeByFile);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeByFile from <see cref="OpenCoverSettings.ExcludeByFile"/>.</i></p><p>Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeByFile(this OpenCoverSettings openCoverSettings, string excludeByFile)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeByFileInternal.Remove(excludeByFile);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeDirectories(this OpenCoverSettings openCoverSettings, params string[] excludeDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ExcludeDirectories"/> to a new list.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings SetExcludeDirectories(this OpenCoverSettings openCoverSettings, IEnumerable<string> excludeDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal = excludeDirectories.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeDirectories to the existing <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectories(this OpenCoverSettings openCoverSettings, params string[] excludeDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeDirectories to the existing <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectories(this OpenCoverSettings openCoverSettings, IEnumerable<string> excludeDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal.AddRange(excludeDirectories);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearExcludeDirectories(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal.Clear();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeDirectory to <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings AddExcludeDirectory(this OpenCoverSettings openCoverSettings, string excludeDirectory)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal.Add(excludeDirectory);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeDirectory from <see cref="OpenCoverSettings.ExcludeDirectories"/>.</i></p><p>Assemblies being loaded from these locations will be ignored.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveExcludeDirectory(this OpenCoverSettings openCoverSettings, string excludeDirectory)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ExcludeDirectoriesInternal.Remove(excludeDirectory);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Filters"/> to a new list.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings SetFilters(this OpenCoverSettings openCoverSettings, params string[] filters)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal = filters.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Filters"/> to a new list.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings SetFilters(this OpenCoverSettings openCoverSettings, IEnumerable<string> filters)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal = filters.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilters(this OpenCoverSettings openCoverSettings, params string[] filters)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal.AddRange(filters);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new filters to the existing <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilters(this OpenCoverSettings openCoverSettings, IEnumerable<string> filters)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal.AddRange(filters);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings ClearFilters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal.Clear();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single filter to <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings AddFilter(this OpenCoverSettings openCoverSettings, string filter)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal.Add(filter);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single filter from <see cref="OpenCoverSettings.Filters"/>.</i></p><p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:"+[*]* -[A*]Name.*"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul></summary>
        [Pure]
        public static OpenCoverSettings RemoveFilter(this OpenCoverSettings openCoverSettings, string filter)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.FiltersInternal.Remove(filter);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.HideSkipped"/>.</i></p><p>Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetHideSkipped(this OpenCoverSettings openCoverSettings, OpenCoverSkipping? hideSkipped)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.HideSkipped = hideSkipped;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Verbosity"/>.</i></p><p>Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders.</p></summary>
        [Pure]
        public static OpenCoverSettings SetVerbosity(this OpenCoverSettings openCoverSettings, OpenCoverVerbosity? verbosity)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Verbosity = verbosity;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings SetMergeByHash(this OpenCoverSettings openCoverSettings, bool mergeByHash)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeByHash = mergeByHash;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableMergeByHash(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeByHash = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableMergeByHash(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeByHash = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.MergeByHash"/>.</i></p><p>Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleMergeByHash(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeByHash = !openCoverSettings.MergeByHash;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings SetMergeOutput(this OpenCoverSettings openCoverSettings, bool mergeOutput)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeOutput = mergeOutput;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings EnableMergeOutput(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeOutput = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings DisableMergeOutput(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeOutput = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.MergeOutput"/>.</i></p><p>Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists).</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleMergeOutput(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MergeOutput = !openCoverSettings.MergeOutput;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings SetNoDefaultFilters(this OpenCoverSettings openCoverSettings, bool noDefaultFilters)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.NoDefaultFilters = noDefaultFilters;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings EnableNoDefaultFilters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.NoDefaultFilters = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings DisableNoDefaultFilters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.NoDefaultFilters = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.NoDefaultFilters"/>.</i></p><p>A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul></p></summary>
        [Pure]
        public static OpenCoverSettings ToggleNoDefaultFilters(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.NoDefaultFilters = !openCoverSettings.NoDefaultFilters;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <i>ONLY</i> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <i>ngen /Profile</i> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings SetOldStyle(this OpenCoverSettings openCoverSettings, bool oldStyle)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.OldStyle = oldStyle;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <i>ONLY</i> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <i>ngen /Profile</i> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableOldStyle(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.OldStyle = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <i>ONLY</i> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <i>ngen /Profile</i> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableOldStyle(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.OldStyle = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.OldStyle"/>.</i></p><p>Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <i>ONLY</i> use this option if you are encountering <see cref="MissingMethodException"/> like errors when the code is run under OpenCover. The issue could be down to <i>ngen /Profile</i> of the mscorlib which then interferes with the instrumentation.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleOldStyle(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.OldStyle = !openCoverSettings.OldStyle;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Output"/>.</i></p><p>The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>.</p></summary>
        [Pure]
        public static OpenCoverSettings SetOutput(this OpenCoverSettings openCoverSettings, string output)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Output = output;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSafeMode(this OpenCoverSettings openCoverSettings, bool safeMode)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SafeMode = safeMode;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableSafeMode(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SafeMode = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableSafeMode(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SafeMode = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.SafeMode"/>.</i></p><p>Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleSafeMode(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SafeMode = !openCoverSettings.SafeMode;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SearchDirectories"/> to a new list.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSearchDirectories(this OpenCoverSettings openCoverSettings, params string[] searchDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SearchDirectories"/> to a new list.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings SetSearchDirectories(this OpenCoverSettings openCoverSettings, IEnumerable<string> searchDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal = searchDirectories.ToList();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new searchDirectories to the existing <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectories(this OpenCoverSettings openCoverSettings, params string[] searchDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding new searchDirectories to the existing <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectories(this OpenCoverSettings openCoverSettings, IEnumerable<string> searchDirectories)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal.AddRange(searchDirectories);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings ClearSearchDirectories(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal.Clear();
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for adding a single searchDirectory to <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings AddSearchDirectory(this OpenCoverSettings openCoverSettings, string searchDirectory)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal.Add(searchDirectory);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for removing a single searchDirectory from <see cref="OpenCoverSettings.SearchDirectories"/>.</i></p><p>Alternative locations to look for PDBs.</p></summary>
        [Pure]
        public static OpenCoverSettings RemoveSearchDirectory(this OpenCoverSettings openCoverSettings, string searchDirectory)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SearchDirectoriesInternal.Remove(searchDirectory);
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <i>Administrator</i> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings SetService(this OpenCoverSettings openCoverSettings, bool service)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Service = service;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <i>Administrator</i> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableService(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Service = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <i>Administrator</i> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableService(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Service = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.Service"/>.</i></p><p>The value provided in the target parameter is the name of a service rather than a name of a process. <i>Administrator</i> privileges recommended.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleService(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Service = !openCoverSettings.Service;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings SetShowUnvisited(this OpenCoverSettings openCoverSettings, bool showUnvisited)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ShowUnvisited = showUnvisited;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings EnableShowUnvisited(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ShowUnvisited = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings DisableShowUnvisited(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ShowUnvisited = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.ShowUnvisited"/>.</i></p><p>Show a list of unvisited methods and classes after the coverage run is finished and the results are presented.</p></summary>
        [Pure]
        public static OpenCoverSettings ToggleShowUnvisited(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.ShowUnvisited = !openCoverSettings.ShowUnvisited;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings SetSkipAutoProperties(this OpenCoverSettings openCoverSettings, bool skipAutoProperties)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SkipAutoProperties = skipAutoProperties;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings EnableSkipAutoProperties(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SkipAutoProperties = true;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings DisableSkipAutoProperties(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SkipAutoProperties = false;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="OpenCoverSettings.SkipAutoProperties"/>.</i></p><p>Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c></p></summary>
        [Pure]
        public static OpenCoverSettings ToggleSkipAutoProperties(this OpenCoverSettings openCoverSettings)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.SkipAutoProperties = !openCoverSettings.SkipAutoProperties;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.MaximumVisitCount"/>.</i></p><p>Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported.</p></summary>
        [Pure]
        public static OpenCoverSettings SetMaximumVisitCount(this OpenCoverSettings openCoverSettings, int? maximumVisitCount)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.MaximumVisitCount = maximumVisitCount;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.Registration"/>.</i></p><p>Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <i>regsvr32</i> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <i>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</i> or <i>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</i>.</p></summary>
        [Pure]
        public static OpenCoverSettings SetRegistration(this OpenCoverSettings openCoverSettings, RegistrationType? registration)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.Registration = registration;
            return openCoverSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="OpenCoverSettings.TargetExitCodeOffset"/>.</i></p><p>Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process.</p></summary>
        [Pure]
        public static OpenCoverSettings SetTargetExitCodeOffset(this OpenCoverSettings openCoverSettings, int? targetExitCodeOffset)
        {
            openCoverSettings = openCoverSettings.NewInstance();
            openCoverSettings.TargetExitCodeOffset = targetExitCodeOffset;
            return openCoverSettings;
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
        All
    }
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
    [PublicAPI]
    [Flags]
    public enum OpenCoverSkipping
    {
        File,
        Filter,
        Attribute,
        MissingPdb,
        All = File | Filter | Attribute | MissingPdb
    }
    /// <summary><p>OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.</p></summary>
    [PublicAPI]
    public enum RegistrationType
    {
        User,
        Path32,
        Path64
    }
}
