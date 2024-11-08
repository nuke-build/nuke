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

namespace Nuke.Common.Tools.Coverlet;

/// <summary><p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class CoverletTasks : ToolTasks, IRequireNuGetPackage
{
    public static string CoverletPath => new CoverletTasks().GetToolPath();
    public const string PackageId = "coverlet.console";
    public const string PackageExecutable = "coverlet.console.dll";
    /// <summary><p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Coverlet(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new CoverletTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assembly&gt;</c> via <see cref="CoverletSettings.Assembly"/></li><li><c>--exclude</c> via <see cref="CoverletSettings.Exclude"/></li><li><c>--exclude-by-file</c> via <see cref="CoverletSettings.ExcludeByFile"/></li><li><c>--format</c> via <see cref="CoverletSettings.Format"/></li><li><c>--include</c> via <see cref="CoverletSettings.Include"/></li><li><c>--merge-with</c> via <see cref="CoverletSettings.MergeWith"/></li><li><c>--output</c> via <see cref="CoverletSettings.Output"/></li><li><c>--target</c> via <see cref="CoverletSettings.Target"/></li><li><c>--targetargs</c> via <see cref="CoverletSettings.TargetArgs"/></li><li><c>--threshold</c> via <see cref="CoverletSettings.Threshold"/></li><li><c>--threshold-type</c> via <see cref="CoverletSettings.ThresholdType"/></li><li><c>--version</c> via <see cref="CoverletSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Coverlet(CoverletSettings options = null) => new CoverletTasks().Run(options);
    /// <summary><p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assembly&gt;</c> via <see cref="CoverletSettings.Assembly"/></li><li><c>--exclude</c> via <see cref="CoverletSettings.Exclude"/></li><li><c>--exclude-by-file</c> via <see cref="CoverletSettings.ExcludeByFile"/></li><li><c>--format</c> via <see cref="CoverletSettings.Format"/></li><li><c>--include</c> via <see cref="CoverletSettings.Include"/></li><li><c>--merge-with</c> via <see cref="CoverletSettings.MergeWith"/></li><li><c>--output</c> via <see cref="CoverletSettings.Output"/></li><li><c>--target</c> via <see cref="CoverletSettings.Target"/></li><li><c>--targetargs</c> via <see cref="CoverletSettings.TargetArgs"/></li><li><c>--threshold</c> via <see cref="CoverletSettings.Threshold"/></li><li><c>--threshold-type</c> via <see cref="CoverletSettings.ThresholdType"/></li><li><c>--version</c> via <see cref="CoverletSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Coverlet(Configure<CoverletSettings> configurator) => new CoverletTasks().Run(configurator.Invoke(new CoverletSettings()));
    /// <summary><p><c>Coverlet</c> is a cross platform code coverage library for .NET Core, with support for line, branch and method coverage.The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://github.com/tonerdo/coverlet/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assembly&gt;</c> via <see cref="CoverletSettings.Assembly"/></li><li><c>--exclude</c> via <see cref="CoverletSettings.Exclude"/></li><li><c>--exclude-by-file</c> via <see cref="CoverletSettings.ExcludeByFile"/></li><li><c>--format</c> via <see cref="CoverletSettings.Format"/></li><li><c>--include</c> via <see cref="CoverletSettings.Include"/></li><li><c>--merge-with</c> via <see cref="CoverletSettings.MergeWith"/></li><li><c>--output</c> via <see cref="CoverletSettings.Output"/></li><li><c>--target</c> via <see cref="CoverletSettings.Target"/></li><li><c>--targetargs</c> via <see cref="CoverletSettings.TargetArgs"/></li><li><c>--threshold</c> via <see cref="CoverletSettings.Threshold"/></li><li><c>--threshold-type</c> via <see cref="CoverletSettings.ThresholdType"/></li><li><c>--version</c> via <see cref="CoverletSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(CoverletSettings Settings, IReadOnlyCollection<Output> Output)> Coverlet(CombinatorialConfigure<CoverletSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Coverlet, degreeOfParallelism, completeOnFailure);
}
#region CoverletSettings
/// <summary>Used within <see cref="CoverletTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<CoverletSettings>))]
[Command(Type = typeof(CoverletTasks), Command = nameof(CoverletTasks.Coverlet))]
public partial class CoverletSettings : ToolOptions
{
    /// <summary>Path to the test assembly.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Assembly => Get<string>(() => Assembly);
    /// <summary>Path to the test runner application.</summary>
    [Argument(Format = "--target {value}")] public string Target => Get<string>(() => Target);
    /// <summary>Arguments to be passed to the test runner.</summary>
    [Argument(Format = "--targetargs {value}", Separator = " ", QuoteMultiple = true)] public IReadOnlyList<string> TargetArgs => Get<List<string>>(() => TargetArgs);
    /// <summary>Output of the generated coverage report</summary>
    [Argument(Format = "--output {value}")] public string Output => Get<string>(() => Output);
    /// <summary>Format of the generated coverage report.Can be specified multiple times to output multiple formats in a single run.</summary>
    [Argument(Format = "--format {value}")] public IReadOnlyList<CoverletOutputFormat> Format => Get<List<CoverletOutputFormat>>(() => Format);
    /// <summary>Exits with error if the coverage % is below value.</summary>
    [Argument(Format = "--threshold {value}")] public int? Threshold => Get<int?>(() => Threshold);
    /// <summary>Coverage type to apply the threshold to.</summary>
    [Argument(Format = "--threshold-type {value}")] public CoverletThresholdType ThresholdType => Get<CoverletThresholdType>(() => ThresholdType);
    /// <summary>Filter expressions to exclude specific modules and types.</summary>
    [Argument(Format = "--exclude {value}")] public IReadOnlyList<string> Exclude => Get<List<string>>(() => Exclude);
    /// <summary>Filter expressions to include specific modules and types.</summary>
    [Argument(Format = "--include {value}")] public IReadOnlyList<string> Include => Get<List<string>>(() => Include);
    /// <summary>Glob patterns specifying source files to exclude.</summary>
    [Argument(Format = "--exclude-by-file {value}")] public IReadOnlyList<string> ExcludeByFile => Get<List<string>>(() => ExcludeByFile);
    /// <summary>Show version information.</summary>
    [Argument(Format = "--version")] public bool? Version => Get<bool?>(() => Version);
    /// <summary>Path to existing coverage result to merge.</summary>
    [Argument(Format = "--merge-with {value}")] public string MergeWith => Get<string>(() => MergeWith);
}
#endregion
#region CoverletSettingsExtensions
/// <summary>Used within <see cref="CoverletTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class CoverletSettingsExtensions
{
    #region Assembly
    /// <inheritdoc cref="CoverletSettings.Assembly"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Assembly))]
    public static T SetAssembly<T>(this T o, string v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Assembly, v));
    /// <inheritdoc cref="CoverletSettings.Assembly"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Assembly))]
    public static T ResetAssembly<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.Assembly));
    #endregion
    #region Target
    /// <inheritdoc cref="CoverletSettings.Target"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Target))]
    public static T SetTarget<T>(this T o, string v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="CoverletSettings.Target"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Target))]
    public static T ResetTarget<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.Target));
    #endregion
    #region TargetArgs
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T SetTargetArgs<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.TargetArgs, v));
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T SetTargetArgs<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.TargetArgs, v));
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T AddTargetArgs<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.TargetArgs, v));
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T AddTargetArgs<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.TargetArgs, v));
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T RemoveTargetArgs<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.TargetArgs, v));
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T RemoveTargetArgs<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.TargetArgs, v));
    /// <inheritdoc cref="CoverletSettings.TargetArgs"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.TargetArgs))]
    public static T ClearTargetArgs<T>(this T o) where T : CoverletSettings => o.Modify(b => b.ClearCollection(() => o.TargetArgs));
    #endregion
    #region Output
    /// <inheritdoc cref="CoverletSettings.Output"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="CoverletSettings.Output"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Format
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T SetFormat<T>(this T o, params CoverletOutputFormat[] v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T SetFormat<T>(this T o, IEnumerable<CoverletOutputFormat> v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T AddFormat<T>(this T o, params CoverletOutputFormat[] v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.Format, v));
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T AddFormat<T>(this T o, IEnumerable<CoverletOutputFormat> v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.Format, v));
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T RemoveFormat<T>(this T o, params CoverletOutputFormat[] v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.Format, v));
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T RemoveFormat<T>(this T o, IEnumerable<CoverletOutputFormat> v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.Format, v));
    /// <inheritdoc cref="CoverletSettings.Format"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Format))]
    public static T ClearFormat<T>(this T o) where T : CoverletSettings => o.Modify(b => b.ClearCollection(() => o.Format));
    #endregion
    #region Threshold
    /// <inheritdoc cref="CoverletSettings.Threshold"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Threshold))]
    public static T SetThreshold<T>(this T o, int? v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Threshold, v));
    /// <inheritdoc cref="CoverletSettings.Threshold"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Threshold))]
    public static T ResetThreshold<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.Threshold));
    #endregion
    #region ThresholdType
    /// <inheritdoc cref="CoverletSettings.ThresholdType"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ThresholdType))]
    public static T SetThresholdType<T>(this T o, CoverletThresholdType v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.ThresholdType, v));
    /// <inheritdoc cref="CoverletSettings.ThresholdType"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ThresholdType))]
    public static T ResetThresholdType<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.ThresholdType));
    #endregion
    #region Exclude
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T SetExclude<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T SetExclude<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T AddExclude<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T AddExclude<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="CoverletSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Exclude))]
    public static T ClearExclude<T>(this T o) where T : CoverletSettings => o.Modify(b => b.ClearCollection(() => o.Exclude));
    #endregion
    #region Include
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T SetInclude<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T SetInclude<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T AddInclude<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T AddInclude<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T RemoveInclude<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T RemoveInclude<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="CoverletSettings.Include"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Include))]
    public static T ClearInclude<T>(this T o) where T : CoverletSettings => o.Modify(b => b.ClearCollection(() => o.Include));
    #endregion
    #region ExcludeByFile
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T SetExcludeByFile<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T SetExcludeByFile<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T AddExcludeByFile<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T AddExcludeByFile<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.AddCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T RemoveExcludeByFile<T>(this T o, params string[] v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T RemoveExcludeByFile<T>(this T o, IEnumerable<string> v) where T : CoverletSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeByFile, v));
    /// <inheritdoc cref="CoverletSettings.ExcludeByFile"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.ExcludeByFile))]
    public static T ClearExcludeByFile<T>(this T o) where T : CoverletSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeByFile));
    #endregion
    #region Version
    /// <inheritdoc cref="CoverletSettings.Version"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Version))]
    public static T SetVersion<T>(this T o, bool? v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="CoverletSettings.Version"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.Version));
    /// <inheritdoc cref="CoverletSettings.Version"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Version))]
    public static T EnableVersion<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Version, true));
    /// <inheritdoc cref="CoverletSettings.Version"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Version))]
    public static T DisableVersion<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Version, false));
    /// <inheritdoc cref="CoverletSettings.Version"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.Version))]
    public static T ToggleVersion<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Set(() => o.Version, !o.Version));
    #endregion
    #region MergeWith
    /// <inheritdoc cref="CoverletSettings.MergeWith"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.MergeWith))]
    public static T SetMergeWith<T>(this T o, string v) where T : CoverletSettings => o.Modify(b => b.Set(() => o.MergeWith, v));
    /// <inheritdoc cref="CoverletSettings.MergeWith"/>
    [Pure] [Builder(Type = typeof(CoverletSettings), Property = nameof(CoverletSettings.MergeWith))]
    public static T ResetMergeWith<T>(this T o) where T : CoverletSettings => o.Modify(b => b.Remove(() => o.MergeWith));
    #endregion
}
#endregion
#region DotNetTestSettingsExtensions
/// <summary>Used within <see cref="CoverletTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotNetTestSettingsExtensions
{
    #region Properties
    #region CollectCoverage
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T SetCollectCoverage<T>(this T o, bool? v) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "CollectCoverage", v));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ResetCollectCoverage<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "CollectCoverage"));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T EnableCollectCoverage<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "CollectCoverage", true));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T DisableCollectCoverage<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "CollectCoverage", false));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ToggleCollectCoverage<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "CollectCoverage")));
    #endregion
    #region CoverletOutputFormat
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T SetCoverletOutputFormat<T>(this T o, CoverletOutputFormat v) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "CoverletOutputFormat", v));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ResetCoverletOutputFormat<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "CoverletOutputFormat"));
    #endregion
    #region ExcludeByFile
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T SetExcludeByFile<T>(this T o, string v) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "ExcludeByFile", v));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ResetExcludeByFile<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "ExcludeByFile"));
    #endregion
    #region CoverletOutput
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T SetCoverletOutput<T>(this T o, string v) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "CoverletOutput", v));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ResetCoverletOutput<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "CoverletOutput"));
    #endregion
    #region UseSourceLink
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T SetUseSourceLink<T>(this T o, bool? v) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "UseSourceLink", v));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ResetUseSourceLink<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "UseSourceLink"));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T EnableUseSourceLink<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "UseSourceLink", true));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T DisableUseSourceLink<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "UseSourceLink", false));
    /// <inheritdoc cref="DotNetTestSettings.Properties"/>
    [Pure] [Builder(Type = typeof(DotNetTestSettings), Property = nameof(DotNetTestSettings.Properties))]
    public static T ToggleUseSourceLink<T>(this T o) where T : DotNetTestSettings => o.Modify(b => b.Set(() => o.Properties, DelegateHelper.Toggle(o.Properties, "UseSourceLink")));
    #endregion
    #endregion
}
#endregion
#region CoverletOutputFormat
/// <summary>Used within <see cref="CoverletTasks"/>.</summary>
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
/// <summary>Used within <see cref="CoverletTasks"/>.</summary>
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
