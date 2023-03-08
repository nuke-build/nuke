// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Coverlet/Coverlet.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Tools.DotNet;
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
    [NuGetPackageRequirement(CoverletPackageId)]
    public partial class CoverletTasks
        : IRequireNuGetPackage
    {
        public const string CoverletPackageId = "coverlet.console";
        /// <summary>
        ///   Path to the Coverlet executable.
        /// </summary>
        public static string CoverletPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("COVERLET_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("coverlet.console", "coverlet.console.dll");
        public static Action<OutputType, string> CoverletLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Coverlet(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(CoverletPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? CoverletLogger);
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
            using var process = ProcessTasks.StartProcess(toolSettings);
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
        public override string ProcessToolPath => base.ProcessToolPath ?? CoverletTasks.CoverletPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? CoverletTasks.CoverletLogger;
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
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
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
            return base.ConfigureProcessArguments(arguments);
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
        public static T SetAssembly<T>(this T toolSettings, string assembly) where T : CoverletSettings
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
        public static T ResetAssembly<T>(this T toolSettings) where T : CoverletSettings
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
        public static T SetTarget<T>(this T toolSettings, string target) where T : CoverletSettings
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
        public static T ResetTarget<T>(this T toolSettings) where T : CoverletSettings
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
        public static T SetTargetArgs<T>(this T toolSettings, params string[] targetArgs) where T : CoverletSettings
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
        public static T SetTargetArgs<T>(this T toolSettings, IEnumerable<string> targetArgs) where T : CoverletSettings
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
        public static T AddTargetArgs<T>(this T toolSettings, params string[] targetArgs) where T : CoverletSettings
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
        public static T AddTargetArgs<T>(this T toolSettings, IEnumerable<string> targetArgs) where T : CoverletSettings
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
        public static T ClearTargetArgs<T>(this T toolSettings) where T : CoverletSettings
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
        public static T RemoveTargetArgs<T>(this T toolSettings, params string[] targetArgs) where T : CoverletSettings
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
        public static T RemoveTargetArgs<T>(this T toolSettings, IEnumerable<string> targetArgs) where T : CoverletSettings
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
        public static T SetOutput<T>(this T toolSettings, string output) where T : CoverletSettings
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
        public static T ResetOutput<T>(this T toolSettings) where T : CoverletSettings
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
        public static T SetFormat<T>(this T toolSettings, params CoverletOutputFormat[] format) where T : CoverletSettings
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
        public static T SetFormat<T>(this T toolSettings, IEnumerable<CoverletOutputFormat> format) where T : CoverletSettings
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
        public static T AddFormat<T>(this T toolSettings, params CoverletOutputFormat[] format) where T : CoverletSettings
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
        public static T AddFormat<T>(this T toolSettings, IEnumerable<CoverletOutputFormat> format) where T : CoverletSettings
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
        public static T ClearFormat<T>(this T toolSettings) where T : CoverletSettings
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
        public static T RemoveFormat<T>(this T toolSettings, params CoverletOutputFormat[] format) where T : CoverletSettings
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
        public static T RemoveFormat<T>(this T toolSettings, IEnumerable<CoverletOutputFormat> format) where T : CoverletSettings
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
        public static T SetThreshold<T>(this T toolSettings, int? threshold) where T : CoverletSettings
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
        public static T ResetThreshold<T>(this T toolSettings) where T : CoverletSettings
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
        public static T SetThresholdType<T>(this T toolSettings, CoverletThresholdType thresholdType) where T : CoverletSettings
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
        public static T ResetThresholdType<T>(this T toolSettings) where T : CoverletSettings
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
        public static T SetExclude<T>(this T toolSettings, params string[] exclude) where T : CoverletSettings
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
        public static T SetExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : CoverletSettings
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
        public static T AddExclude<T>(this T toolSettings, params string[] exclude) where T : CoverletSettings
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
        public static T AddExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : CoverletSettings
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
        public static T ClearExclude<T>(this T toolSettings) where T : CoverletSettings
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
        public static T RemoveExclude<T>(this T toolSettings, params string[] exclude) where T : CoverletSettings
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
        public static T RemoveExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : CoverletSettings
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
        public static T SetInclude<T>(this T toolSettings, params string[] include) where T : CoverletSettings
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
        public static T SetInclude<T>(this T toolSettings, IEnumerable<string> include) where T : CoverletSettings
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
        public static T AddInclude<T>(this T toolSettings, params string[] include) where T : CoverletSettings
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
        public static T AddInclude<T>(this T toolSettings, IEnumerable<string> include) where T : CoverletSettings
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
        public static T ClearInclude<T>(this T toolSettings) where T : CoverletSettings
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
        public static T RemoveInclude<T>(this T toolSettings, params string[] include) where T : CoverletSettings
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
        public static T RemoveInclude<T>(this T toolSettings, IEnumerable<string> include) where T : CoverletSettings
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
        public static T SetExcludeByFile<T>(this T toolSettings, params string[] excludeByFile) where T : CoverletSettings
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
        public static T SetExcludeByFile<T>(this T toolSettings, IEnumerable<string> excludeByFile) where T : CoverletSettings
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
        public static T AddExcludeByFile<T>(this T toolSettings, params string[] excludeByFile) where T : CoverletSettings
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
        public static T AddExcludeByFile<T>(this T toolSettings, IEnumerable<string> excludeByFile) where T : CoverletSettings
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
        public static T ClearExcludeByFile<T>(this T toolSettings) where T : CoverletSettings
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
        public static T RemoveExcludeByFile<T>(this T toolSettings, params string[] excludeByFile) where T : CoverletSettings
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
        public static T RemoveExcludeByFile<T>(this T toolSettings, IEnumerable<string> excludeByFile) where T : CoverletSettings
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
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : CoverletSettings
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
        public static T ResetVersion<T>(this T toolSettings) where T : CoverletSettings
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
        public static T EnableVersion<T>(this T toolSettings) where T : CoverletSettings
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
        public static T DisableVersion<T>(this T toolSettings) where T : CoverletSettings
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
        public static T ToggleVersion<T>(this T toolSettings) where T : CoverletSettings
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
        public static T SetMergeWith<T>(this T toolSettings, string mergeWith) where T : CoverletSettings
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
        public static T ResetMergeWith<T>(this T toolSettings) where T : CoverletSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MergeWith = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetTestSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CoverletTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTestSettingsExtensions
    {
        #region Properties
        #region CollectCoverage
        /// <summary>
        ///   <p><em>Sets <c>CollectCoverage</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCollectCoverage<T>(this T toolSettings, bool? collectCoverage) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["CollectCoverage"] = collectCoverage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>CollectCoverage</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCollectCoverage<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("CollectCoverage");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>CollectCoverage</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableCollectCoverage<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["CollectCoverage"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>CollectCoverage</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableCollectCoverage<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["CollectCoverage"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>CollectCoverage</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleCollectCoverage<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "CollectCoverage");
            return toolSettings;
        }
        #endregion
        #region CoverletOutputFormat
        /// <summary>
        ///   <p><em>Sets <c>CoverletOutputFormat</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCoverletOutputFormat<T>(this T toolSettings, CoverletOutputFormat coverletOutputFormat) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["CoverletOutputFormat"] = coverletOutputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>CoverletOutputFormat</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCoverletOutputFormat<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("CoverletOutputFormat");
            return toolSettings;
        }
        #endregion
        #region ExcludeByFile
        /// <summary>
        ///   <p><em>Sets <c>ExcludeByFile</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetExcludeByFile<T>(this T toolSettings, string excludeByFile) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["ExcludeByFile"] = excludeByFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>ExcludeByFile</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetExcludeByFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("ExcludeByFile");
            return toolSettings;
        }
        #endregion
        #region CoverletOutput
        /// <summary>
        ///   <p><em>Sets <c>CoverletOutput</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCoverletOutput<T>(this T toolSettings, string coverletOutput) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["CoverletOutput"] = coverletOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>CoverletOutput</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCoverletOutput<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("CoverletOutput");
            return toolSettings;
        }
        #endregion
        #region UseSourceLink
        /// <summary>
        ///   <p><em>Sets <c>UseSourceLink</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetUseSourceLink<T>(this T toolSettings, bool? useSourceLink) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["UseSourceLink"] = useSourceLink;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>UseSourceLink</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetUseSourceLink<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("UseSourceLink");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>UseSourceLink</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableUseSourceLink<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["UseSourceLink"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>UseSourceLink</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableUseSourceLink<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["UseSourceLink"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>UseSourceLink</c> in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleUseSourceLink<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "UseSourceLink");
            return toolSettings;
        }
        #endregion
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
        public static CoverletOutputFormat lcov = (CoverletOutputFormat) "lcov";
        public static CoverletOutputFormat opencover = (CoverletOutputFormat) "opencover";
        public static CoverletOutputFormat cobertura = (CoverletOutputFormat) "cobertura";
        public static CoverletOutputFormat teamcity = (CoverletOutputFormat) "teamcity";
        public static implicit operator CoverletOutputFormat(string value)
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
        public static implicit operator CoverletThresholdType(string value)
        {
            return new CoverletThresholdType { Value = value };
        }
    }
    #endregion
}
