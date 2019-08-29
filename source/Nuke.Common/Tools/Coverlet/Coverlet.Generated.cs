// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/Coverlet.json
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

namespace Nuke.Common.Tools.Coverlet
{
    /// <summary>
    ///   <p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
    ///   <p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CoverletTasks
    {
        /// <summary>
        ///   Path to the Coverlet executable.
        /// </summary>
        public static string CoverletPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("COVERLET_EXE") ??
            ToolPathResolver.GetPackageExecutable("coverlet.console", "coverlet.console.dll");
        public static Action<OutputType, string> CoverletLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Coverlet(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(CoverletPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, CoverletLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assembly&gt;</c> via <see cref="CoverletSettings.Assembly"/></li>
        ///     <li><c>--exclude</c> via <see cref="CoverletSettings.Exclude"/></li>
        ///     <li><c>--exclude-by-file</c> via <see cref="CoverletSettings.ExcludeByFile"/></li>
        ///     <li><c>--format</c> via <see cref="CoverletSettings.Format"/></li>
        ///     <li><c>--include</c> via <see cref="CoverletSettings.Include"/></li>
        ///     <li><c>--merge-with</c> via <see cref="CoverletSettings.MergeWith"/></li>
        ///     <li><c>--output</c> via <see cref="CoverletSettings.Output"/></li>
        ///     <li><c>--target</c> via <see cref="CoverletSettings.Target"/></li>
        ///     <li><c>--targetargs</c> via <see cref="CoverletSettings.TargetArgs"/></li>
        ///     <li><c>--threshold</c> via <see cref="CoverletSettings.Threshold"/></li>
        ///     <li><c>--threshold-type</c> via <see cref="CoverletSettings.ThresholdType"/></li>
        ///     <li><c>--version</c> via <see cref="CoverletSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Coverlet(CoverletSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CoverletSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assembly&gt;</c> via <see cref="CoverletSettings.Assembly"/></li>
        ///     <li><c>--exclude</c> via <see cref="CoverletSettings.Exclude"/></li>
        ///     <li><c>--exclude-by-file</c> via <see cref="CoverletSettings.ExcludeByFile"/></li>
        ///     <li><c>--format</c> via <see cref="CoverletSettings.Format"/></li>
        ///     <li><c>--include</c> via <see cref="CoverletSettings.Include"/></li>
        ///     <li><c>--merge-with</c> via <see cref="CoverletSettings.MergeWith"/></li>
        ///     <li><c>--output</c> via <see cref="CoverletSettings.Output"/></li>
        ///     <li><c>--target</c> via <see cref="CoverletSettings.Target"/></li>
        ///     <li><c>--targetargs</c> via <see cref="CoverletSettings.TargetArgs"/></li>
        ///     <li><c>--threshold</c> via <see cref="CoverletSettings.Threshold"/></li>
        ///     <li><c>--threshold-type</c> via <see cref="CoverletSettings.ThresholdType"/></li>
        ///     <li><c>--version</c> via <see cref="CoverletSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Coverlet(Configure<CoverletSettings> configurator)
        {
            return Coverlet(configurator(new CoverletSettings()));
        }
        /// <summary>
        ///   <p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assembly&gt;</c> via <see cref="CoverletSettings.Assembly"/></li>
        ///     <li><c>--exclude</c> via <see cref="CoverletSettings.Exclude"/></li>
        ///     <li><c>--exclude-by-file</c> via <see cref="CoverletSettings.ExcludeByFile"/></li>
        ///     <li><c>--format</c> via <see cref="CoverletSettings.Format"/></li>
        ///     <li><c>--include</c> via <see cref="CoverletSettings.Include"/></li>
        ///     <li><c>--merge-with</c> via <see cref="CoverletSettings.MergeWith"/></li>
        ///     <li><c>--output</c> via <see cref="CoverletSettings.Output"/></li>
        ///     <li><c>--target</c> via <see cref="CoverletSettings.Target"/></li>
        ///     <li><c>--targetargs</c> via <see cref="CoverletSettings.TargetArgs"/></li>
        ///     <li><c>--threshold</c> via <see cref="CoverletSettings.Threshold"/></li>
        ///     <li><c>--threshold-type</c> via <see cref="CoverletSettings.ThresholdType"/></li>
        ///     <li><c>--version</c> via <see cref="CoverletSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CoverletSettings Settings, IReadOnlyCollection<Output> Output)> Coverlet(CombinatorialConfigure<CoverletSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Coverlet, CoverletLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CoverletSettings
    /// <summary>
    ///   Used within <see cref="CoverletTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CoverletSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Coverlet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CoverletTasks.CoverletPath;
        public override Action<OutputType, string> CustomLogger => CoverletTasks.CoverletLogger;
        /// <summary>
        ///   Path to the test assembly.
        /// </summary>
        public virtual string Assembly { get; internal set; }
        /// <summary>
        ///   Path to the test runner application.
        /// </summary>
        public virtual string Target { get; internal set; }
        /// <summary>
        ///   Arguments to be passed to the test runner.
        /// </summary>
        public virtual IReadOnlyList<string> TargetArgs => TargetArgsInternal.AsReadOnly();
        internal List<string> TargetArgsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Output of the generated coverage report
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.
        /// </summary>
        public virtual IReadOnlyList<CoverletOutputFormat> Format => FormatInternal.AsReadOnly();
        internal List<CoverletOutputFormat> FormatInternal { get; set; } = new List<CoverletOutputFormat>();
        /// <summary>
        ///   Exits with error if the coverage % is below value.
        /// </summary>
        public virtual int? Threshold { get; internal set; }
        /// <summary>
        ///   Coverage type to apply the threshold to.
        /// </summary>
        public virtual CoverletThresholdType ThresholdType { get; internal set; }
        /// <summary>
        ///   Filter expressions to exclude specific modules and types.
        /// </summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Filter expressions to include specific modules and types.
        /// </summary>
        public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
        internal List<string> IncludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Glob patterns specifying source files to exclude.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeByFile => ExcludeByFileInternal.AsReadOnly();
        internal List<string> ExcludeByFileInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Show version information.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        /// <summary>
        ///   Path to existing coverage result to merge.
        /// </summary>
        public virtual string MergeWith { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Assembly)
              .Add("--target {value}", Target)
              .Add("--targetargs {value}", TargetArgs, separator: ' ', quoteMultiple: true)
              .Add("--output {value}", Output)
              .Add("--format {value}", Format)
              .Add("--threshold {value}", Threshold)
              .Add("--threshold-type {value}", ThresholdType)
              .Add("--exclude {value}", Exclude)
              .Add("--include {value}", Include)
              .Add("--exclude-by-file {value}", ExcludeByFile)
              .Add("--version", Version)
              .Add("--merge-with {value}", MergeWith);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CoverletSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CoverletTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CoverletSettingsExtensions
    {
        #region Assembly
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Assembly"/></em></p>
        ///   <p>Path to the test assembly.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetAssembly(this CoverletSettings toolSettings, string assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Assembly = assembly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.Assembly"/></em></p>
        ///   <p>Path to the test assembly.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetAssembly(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Assembly = null;
            return toolSettings;
        }
        #endregion
        #region Target
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Target"/></em></p>
        ///   <p>Path to the test runner application.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetTarget(this CoverletSettings toolSettings, string target)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = target;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.Target"/></em></p>
        ///   <p>Path to the test runner application.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetTarget(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = null;
            return toolSettings;
        }
        #endregion
        #region TargetArgs
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.TargetArgs"/> to a new list</em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetTargetArgs(this CoverletSettings toolSettings, params string[] targetArgs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArgsInternal = targetArgs.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.TargetArgs"/> to a new list</em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetTargetArgs(this CoverletSettings toolSettings, IEnumerable<string> targetArgs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArgsInternal = targetArgs.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.TargetArgs"/></em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddTargetArgs(this CoverletSettings toolSettings, params string[] targetArgs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArgsInternal.AddRange(targetArgs);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.TargetArgs"/></em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddTargetArgs(this CoverletSettings toolSettings, IEnumerable<string> targetArgs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArgsInternal.AddRange(targetArgs);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CoverletSettings.TargetArgs"/></em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ClearTargetArgs(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetArgsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.TargetArgs"/></em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveTargetArgs(this CoverletSettings toolSettings, params string[] targetArgs)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(targetArgs);
            toolSettings.TargetArgsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.TargetArgs"/></em></p>
        ///   <p>Arguments to be passed to the test runner.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveTargetArgs(this CoverletSettings toolSettings, IEnumerable<string> targetArgs)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(targetArgs);
            toolSettings.TargetArgsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Output"/></em></p>
        ///   <p>Output of the generated coverage report</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetOutput(this CoverletSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.Output"/></em></p>
        ///   <p>Output of the generated coverage report</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetOutput(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Format"/> to a new list</em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetFormat(this CoverletSettings toolSettings, params CoverletOutputFormat[] format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FormatInternal = format.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Format"/> to a new list</em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetFormat(this CoverletSettings toolSettings, IEnumerable<CoverletOutputFormat> format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FormatInternal = format.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.Format"/></em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddFormat(this CoverletSettings toolSettings, params CoverletOutputFormat[] format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FormatInternal.AddRange(format);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.Format"/></em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddFormat(this CoverletSettings toolSettings, IEnumerable<CoverletOutputFormat> format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FormatInternal.AddRange(format);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CoverletSettings.Format"/></em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ClearFormat(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FormatInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.Format"/></em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveFormat(this CoverletSettings toolSettings, params CoverletOutputFormat[] format)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<CoverletOutputFormat>(format);
            toolSettings.FormatInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.Format"/></em></p>
        ///   <p>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveFormat(this CoverletSettings toolSettings, IEnumerable<CoverletOutputFormat> format)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<CoverletOutputFormat>(format);
            toolSettings.FormatInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Threshold
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Threshold"/></em></p>
        ///   <p>Exits with error if the coverage % is below value.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetThreshold(this CoverletSettings toolSettings, int? threshold)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Threshold = threshold;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.Threshold"/></em></p>
        ///   <p>Exits with error if the coverage % is below value.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetThreshold(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Threshold = null;
            return toolSettings;
        }
        #endregion
        #region ThresholdType
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.ThresholdType"/></em></p>
        ///   <p>Coverage type to apply the threshold to.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetThresholdType(this CoverletSettings toolSettings, CoverletThresholdType thresholdType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdType = thresholdType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.ThresholdType"/></em></p>
        ///   <p>Coverage type to apply the threshold to.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetThresholdType(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThresholdType = null;
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Exclude"/> to a new list</em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetExclude(this CoverletSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Exclude"/> to a new list</em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetExclude(this CoverletSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.Exclude"/></em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddExclude(this CoverletSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.Exclude"/></em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddExclude(this CoverletSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CoverletSettings.Exclude"/></em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ClearExclude(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.Exclude"/></em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveExclude(this CoverletSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.Exclude"/></em></p>
        ///   <p>Filter expressions to exclude specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveExclude(this CoverletSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Include"/> to a new list</em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetInclude(this CoverletSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Include"/> to a new list</em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetInclude(this CoverletSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.Include"/></em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddInclude(this CoverletSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.Include"/></em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddInclude(this CoverletSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CoverletSettings.Include"/></em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ClearInclude(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.Include"/></em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveInclude(this CoverletSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.Include"/></em></p>
        ///   <p>Filter expressions to include specific modules and types.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveInclude(this CoverletSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeByFile
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.ExcludeByFile"/> to a new list</em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetExcludeByFile(this CoverletSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.ExcludeByFile"/> to a new list</em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetExcludeByFile(this CoverletSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal = excludeByFile.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.ExcludeByFile"/></em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddExcludeByFile(this CoverletSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CoverletSettings.ExcludeByFile"/></em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings AddExcludeByFile(this CoverletSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.AddRange(excludeByFile);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CoverletSettings.ExcludeByFile"/></em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ClearExcludeByFile(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeByFileInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.ExcludeByFile"/></em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveExcludeByFile(this CoverletSettings toolSettings, params string[] excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByFile);
            toolSettings.ExcludeByFileInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CoverletSettings.ExcludeByFile"/></em></p>
        ///   <p>Glob patterns specifying source files to exclude.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings RemoveExcludeByFile(this CoverletSettings toolSettings, IEnumerable<string> excludeByFile)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeByFile);
            toolSettings.ExcludeByFileInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.Version"/></em></p>
        ///   <p>Show version information.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetVersion(this CoverletSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.Version"/></em></p>
        ///   <p>Show version information.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetVersion(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverletSettings.Version"/></em></p>
        ///   <p>Show version information.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings EnableVersion(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverletSettings.Version"/></em></p>
        ///   <p>Show version information.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings DisableVersion(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverletSettings.Version"/></em></p>
        ///   <p>Show version information.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ToggleVersion(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
        #region MergeWith
        /// <summary>
        ///   <p><em>Sets <see cref="CoverletSettings.MergeWith"/></em></p>
        ///   <p>Path to existing coverage result to merge.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings SetMergeWith(this CoverletSettings toolSettings, string mergeWith)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeWith = mergeWith;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverletSettings.MergeWith"/></em></p>
        ///   <p>Path to existing coverage result to merge.</p>
        /// </summary>
        [Pure]
        public static CoverletSettings ResetMergeWith(this CoverletSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeWith = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CoverletOutputFormat
    /// <summary>
    ///   Used within <see cref="CoverletTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CoverletOutputFormat>))]
    public partial class CoverletOutputFormat : Enumeration
    {
        public static CoverletOutputFormat json = (CoverletOutputFormat) "json";
        public static CoverletOutputFormat Icov = (CoverletOutputFormat) "Icov";
        public static CoverletOutputFormat opencover = (CoverletOutputFormat) "opencover";
        public static CoverletOutputFormat cobertura = (CoverletOutputFormat) "cobertura";
        public static explicit operator CoverletOutputFormat(string value)
        {
            return new CoverletOutputFormat { Value = value };
        }
    }
    #endregion
    #region CoverletThresholdType
    /// <summary>
    ///   Used within <see cref="CoverletTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CoverletThresholdType>))]
    public partial class CoverletThresholdType : Enumeration
    {
        public static CoverletThresholdType line = (CoverletThresholdType) "line";
        public static CoverletThresholdType branch = (CoverletThresholdType) "branch";
        public static CoverletThresholdType method = (CoverletThresholdType) "method";
        public static explicit operator CoverletThresholdType(string value)
        {
            return new CoverletThresholdType { Value = value };
        }
    }
    #endregion
}
