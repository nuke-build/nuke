// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/BenchmarkDotNet/BenchmarkDotNet.json

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

namespace Nuke.Common.Tools.BenchmarkDotNet;

/// <summary><p>Powerful .NET library for benchmarking</p><p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class BenchmarkDotNetTasks : ToolTasks, IRequireNuGetPackage
{
    public static string BenchmarkDotNetPath => new BenchmarkDotNetTasks().GetToolPath();
    public const string PackageId = "benchmarkdotnet.tool";
    public const string PackageExecutable = "BenchmarkDotNet.Tool.dll";
    /// <summary><p>Powerful .NET library for benchmarking</p><p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> BenchmarkDotNet(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new BenchmarkDotNetTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Powerful .NET library for benchmarking</p><p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li><li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li><li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li><li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></li><li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li><li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></li><li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.AttributeNames"/></li><li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li><li><c>--cli</c> via <see cref="BenchmarkDotNetSettings.CliPath"/></li><li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li><li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li><li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></li><li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li><li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li><li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disassembly"/></li><li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></li><li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></li><li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li><li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li><li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.CoreRtPath"/></li><li><c>--info</c> via <see cref="BenchmarkDotNetSettings.PrintInformation"/></li><li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li><li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li><li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li><li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li><li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li><li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li><li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></li><li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li><li><c>--list</c> via <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></li><li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li><li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li><li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></li><li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.MemoryStats"/></li><li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li><li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li><li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li><li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></li><li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.OutlierMode"/></li><li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.RestorePath"/></li><li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li><li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li><li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li><li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></li><li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li><li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.RunStrategy"/></li><li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.ThreadingStats"/></li><li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li><li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> BenchmarkDotNet(BenchmarkDotNetSettings options = null) => new BenchmarkDotNetTasks().Run(options);
    /// <summary><p>Powerful .NET library for benchmarking</p><p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li><li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li><li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li><li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></li><li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li><li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></li><li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.AttributeNames"/></li><li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li><li><c>--cli</c> via <see cref="BenchmarkDotNetSettings.CliPath"/></li><li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li><li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li><li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></li><li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li><li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li><li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disassembly"/></li><li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></li><li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></li><li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li><li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li><li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.CoreRtPath"/></li><li><c>--info</c> via <see cref="BenchmarkDotNetSettings.PrintInformation"/></li><li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li><li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li><li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li><li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li><li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li><li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li><li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></li><li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li><li><c>--list</c> via <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></li><li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li><li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li><li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></li><li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.MemoryStats"/></li><li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li><li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li><li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li><li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></li><li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.OutlierMode"/></li><li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.RestorePath"/></li><li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li><li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li><li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li><li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></li><li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li><li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.RunStrategy"/></li><li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.ThreadingStats"/></li><li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li><li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> BenchmarkDotNet(Configure<BenchmarkDotNetSettings> configurator) => new BenchmarkDotNetTasks().Run(configurator.Invoke(new BenchmarkDotNetSettings()));
    /// <summary><p>Powerful .NET library for benchmarking</p><p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li><li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li><li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li><li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></li><li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li><li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></li><li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.AttributeNames"/></li><li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li><li><c>--cli</c> via <see cref="BenchmarkDotNetSettings.CliPath"/></li><li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li><li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li><li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></li><li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li><li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li><li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disassembly"/></li><li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></li><li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></li><li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li><li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li><li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.CoreRtPath"/></li><li><c>--info</c> via <see cref="BenchmarkDotNetSettings.PrintInformation"/></li><li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li><li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li><li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li><li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li><li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li><li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li><li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></li><li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li><li><c>--list</c> via <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></li><li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li><li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li><li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></li><li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.MemoryStats"/></li><li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li><li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li><li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li><li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></li><li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.OutlierMode"/></li><li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.RestorePath"/></li><li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li><li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li><li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li><li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></li><li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li><li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.RunStrategy"/></li><li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.ThreadingStats"/></li><li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li><li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li></ul></remarks>
    public static IEnumerable<(BenchmarkDotNetSettings Settings, IReadOnlyCollection<Output> Output)> BenchmarkDotNet(CombinatorialConfigure<BenchmarkDotNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(BenchmarkDotNet, degreeOfParallelism, completeOnFailure);
}
#region BenchmarkDotNetSettings
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetSettings>))]
[Command(Type = typeof(BenchmarkDotNetTasks), Command = nameof(BenchmarkDotNetTasks.BenchmarkDotNet))]
public partial class BenchmarkDotNetSettings : ToolOptions
{
    /// <summary>The assembly with the benchmarks (required).</summary>
    [Argument(Format = "{value}", Position = 1)] public string AssemblyFile => Get<string>(() => AssemblyFile);
    /// <summary>Dry/Short/Medium/Long or Default</summary>
    [Argument(Format = "--job {value}")] public BenchmarkDotNetJob Job => Get<BenchmarkDotNetJob>(() => Job);
    /// <summary>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</summary>
    [Argument(Format = "--runtimes {value}", Separator = " ")] public IReadOnlyList<string> Runtimes => Get<List<string>>(() => Runtimes);
    /// <summary>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</summary>
    [Argument(Format = "--exporters {value}", Separator = " ")] public IReadOnlyList<BenchmarkDotNetExporter> Exporters => Get<List<BenchmarkDotNetExporter>>(() => Exporters);
    /// <summary>Prints memory statistics</summary>
    [Argument(Format = "--memory")] public bool? MemoryStats => Get<bool?>(() => MemoryStats);
    /// <summary>Prints threading statistics</summary>
    [Argument(Format = "--threading")] public bool? ThreadingStats => Get<bool?>(() => ThreadingStats);
    /// <summary>Gets disassembly of benchmarked code</summary>
    [Argument(Format = "--disasm")] public bool? Disassembly => Get<bool?>(() => Disassembly);
    /// <summary>Profiles benchmarked code using selected profiler.</summary>
    [Argument(Format = "--profiler {value}")] public BenchmarkDotNetProfiler Profiler => Get<BenchmarkDotNetProfiler>(() => Profiler);
    /// <summary>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></summary>
    [Argument(Format = "--filter {value}")] public IReadOnlyList<string> Filter => Get<List<string>>(() => Filter);
    /// <summary>Run benchmarks in Process</summary>
    [Argument(Format = "--inProcess")] public bool? RunInProcess => Get<bool?>(() => RunInProcess);
    /// <summary>Valid path to accessible directory</summary>
    [Argument(Format = "--artifacts {value}")] public string ArtifactsDirecory => Get<string>(() => ArtifactsDirecory);
    /// <summary>DontRemove/RemoveUpper/RemoveLower/RemoveAll</summary>
    [Argument(Format = "--outliers {value}")] public BenchmarkDotNetOutlierMode OutlierMode => Get<BenchmarkDotNetOutlierMode>(() => OutlierMode);
    /// <summary>Affinity mask to set for the benchmark process</summary>
    [Argument(Format = "--affinity {value}")] public int? Affinity => Get<int?>(() => Affinity);
    /// <summary>Displays all statistics (min, max &amp; more)</summary>
    [Argument(Format = "--allStats")] public bool? DisplayAllStatistics => Get<bool?>(() => DisplayAllStatistics);
    /// <summary>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</summary>
    [Argument(Format = "--allCategories {value}", Separator = " ")] public IReadOnlyList<string> AllCategories => Get<List<string>>(() => AllCategories);
    /// <summary>Any Categories to run</summary>
    [Argument(Format = "--anyCategories {value}", Separator = " ")] public IReadOnlyList<string> AnyCategories => Get<List<string>>(() => AnyCategories);
    /// <summary>Run all methods with given attribute (applied to class or method)</summary>
    [Argument(Format = "--attribute {value}", Separator = " ")] public IReadOnlyList<string> AttributeNames => Get<List<string>>(() => AttributeNames);
    /// <summary>Prints single table with results for all benchmarks</summary>
    [Argument(Format = "--join {value}")] public bool? Join => Get<bool?>(() => Join);
    /// <summary>Determines if all auto-generated files should be kept or removed after running the benchmarks.</summary>
    [Argument(Format = "--keepFiles")] public bool? KeepBenchmarkFiles => Get<bool?>(() => KeepBenchmarkFiles);
    /// <summary>Determines if the exported result files should not be overwritten (by default they are overwritten).</summary>
    [Argument(Format = "--noOverwrite")] public bool? DontOverwriteResults => Get<bool?>(() => DontOverwriteResults);
    /// <summary>Hardware Counters</summary>
    [Argument(Format = "--counters {value}", Separator = "+")] public IReadOnlyList<string> HardwareCounters => Get<List<string>>(() => HardwareCounters);
    /// <summary>Path to dotnet CLI (optional).</summary>
    [Argument(Format = "--cli {value}")] public string CliPath => Get<string>(() => CliPath);
    /// <summary>The directory to restore packages to (optional).</summary>
    [Argument(Format = "--packages {value}")] public string RestorePath => Get<string>(() => RestorePath);
    /// <summary>Path(s) to CoreRun (optional).</summary>
    [Argument(Format = "--coreRun {value}", Separator = " ", QuoteMultiple = true)] public IReadOnlyList<string> CoreRunPaths => Get<List<string>>(() => CoreRunPaths);
    /// <summary>Optional path to Mono which should be used for running benchmarks.</summary>
    [Argument(Format = "--monoPath {value}")] public string MonoPath => Get<string>(() => MonoPath);
    /// <summary>Optional version of private CLR build used as the value of <c>COMPLUS_Version</c> env var.</summary>
    [Argument(Format = "--clrVersion {value}")] public string ClrVersion => Get<string>(() => ClrVersion);
    /// <summary>Optional version of <c>Microsoft.DotNet.ILCompiler</c> which should be used to run with CoreRT. Example: <c>1.0.0-alpha-26414-01</c></summary>
    [Argument(Format = "--coreRtVersion {value}")] public string CoreRtVersion => Get<string>(() => CoreRtVersion);
    /// <summary>Optional IlcPath which should be used to run with private CoreRT build.</summary>
    [Argument(Format = "--ilcPath {value}")] public string CoreRtPath => Get<string>(() => CoreRtPath);
    /// <summary>How many times we should launch process with target benchmark. The default is <c>1</c>.</summary>
    [Argument(Format = "--launchCount {value}")] public int? LaunchCount => Get<int?>(() => LaunchCount);
    /// <summary>How many warmup iterations should be performed. If you set it, the <c>minWarmupCount</c> and <c>maxWarmupCount</c> are ignored. By default calculated by the heuristic.</summary>
    [Argument(Format = "--warmupCount {value}")] public int? WarmupCount => Get<int?>(() => WarmupCount);
    /// <summary>Minimum count of warmup iterations that should be performed. The default is <c>6</c>.</summary>
    [Argument(Format = "--minWarmupCount {value}")] public int? MinWarmupCount => Get<int?>(() => MinWarmupCount);
    /// <summary>Maximum count of warmup iterations that should be performed. The default is <c>50</c>.</summary>
    [Argument(Format = "--maxWarmupCount {value}")] public int? MaxWarmupCount => Get<int?>(() => MaxWarmupCount);
    /// <summary>Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. The default is <c>500</c> milliseconds.</summary>
    [Argument(Format = "--iterationTime {value}")] public int? IterationTime => Get<int?>(() => IterationTime);
    /// <summary>How many target iterations should be performed. By default calculated by the heuristic.</summary>
    [Argument(Format = "--iterationCount {value}")] public int? IterationCount => Get<int?>(() => IterationCount);
    /// <summary>Minimum number of iterations to run. The default is <c>15</c>.</summary>
    [Argument(Format = "--minIterationCount {value}")] public int? MinIterationCount => Get<int?>(() => MinIterationCount);
    /// <summary>Maximum number of iterations to run. The default is <c>100</c>.</summary>
    [Argument(Format = "--maxIterationCount {value}")] public int? MaxIterationCount => Get<int?>(() => MaxIterationCount);
    /// <summary>Invocation count in a single iteration. By default calculated by the heuristic.</summary>
    [Argument(Format = "--invocationCount {value}")] public int? InvocationCount => Get<int?>(() => InvocationCount);
    /// <summary>How many times the benchmark method will be invoked per one iteration of a generated loop. The default is <c>16</c>.</summary>
    [Argument(Format = "--unrollFactor {value}")] public int? UnrollFactor => Get<int?>(() => UnrollFactor);
    /// <summary>The run strategy that should be used. Throughput/ColdStart/Monitoring.</summary>
    [Argument(Format = "--strategy {value}")] public BenchmarkDotNetRunStrategy RunStrategy => Get<BenchmarkDotNetRunStrategy>(() => RunStrategy);
    /// <summary>Run the benchmark exactly once per iteration.</summary>
    [Argument(Format = "--runOncePerIteration")] public bool? RunOncePerIteration => Get<bool?>(() => RunOncePerIteration);
    /// <summary>Print environment information.</summary>
    [Argument(Format = "--info")] public bool? PrintInformation => Get<bool?>(() => PrintInformation);
    /// <summary>Prints all of the available benchmark names. Flat/Tree</summary>
    [Argument(Format = "--list {value}")] public BenchmarkDotNetCaseMode ListBenchmarkCaseMode => Get<BenchmarkDotNetCaseMode>(() => ListBenchmarkCaseMode);
    /// <summary>Sets the recursive depth for the disassembler.</summary>
    [Argument(Format = "--disasmDepth {value}")] public int? DisassemblyRecursiveDepth => Get<int?>(() => DisassemblyRecursiveDepth);
    /// <summary>Generates diff reports for the disassembler.</summary>
    [Argument(Format = "--disasmDiff")] public bool? DisassemblyDiff => Get<bool?>(() => DisassemblyDiff);
    /// <summary>Build timeout in seconds.</summary>
    [Argument(Format = "--buildTimeout {value}")] public int? BuildTimeout => Get<int?>(() => BuildTimeout);
    /// <summary>Stop on first error.</summary>
    [Argument(Format = "--stopOnFirstError")] public bool? StopOnFirstError => Get<bool?>(() => StopOnFirstError);
    /// <summary>Threshold for Mann–Whitney U Test. Examples: <c>5%</c>, <c>10ms</c>, <c>100ns</c>, <c>1s</c></summary>
    [Argument(Format = "--statisticalTest {value}")] public string StatisticalTestThreshold => Get<string>(() => StatisticalTestThreshold);
    /// <summary>Disables the logfile.</summary>
    [Argument(Format = "--disableLogFile")] public bool? DisableLogFile => Get<bool?>(() => DisableLogFile);
    /// <summary>Max paramter column width, the default is <c>20</c>.</summary>
    [Argument(Format = "--maxWidth {value}")] public int? MaxParameterColumnWidth => Get<int?>(() => MaxParameterColumnWidth);
}
#endregion
#region BenchmarkDotNetSettingsExtensions
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class BenchmarkDotNetSettingsExtensions
{
    #region AssemblyFile
    /// <inheritdoc cref="BenchmarkDotNetSettings.AssemblyFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AssemblyFile))]
    public static T SetAssemblyFile<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AssemblyFile, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AssemblyFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AssemblyFile))]
    public static T ResetAssemblyFile<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.AssemblyFile));
    #endregion
    #region Job
    /// <inheritdoc cref="BenchmarkDotNetSettings.Job"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Job))]
    public static T SetJob<T>(this T o, BenchmarkDotNetJob v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Job, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Job"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Job))]
    public static T ResetJob<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.Job));
    #endregion
    #region Runtimes
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T SetRuntimes<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Runtimes, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T SetRuntimes<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Runtimes, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T AddRuntimes<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.Runtimes, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T AddRuntimes<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.Runtimes, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T RemoveRuntimes<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Runtimes, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T RemoveRuntimes<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Runtimes, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Runtimes"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Runtimes))]
    public static T ClearRuntimes<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.Runtimes));
    #endregion
    #region Exporters
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T SetExporters<T>(this T o, params BenchmarkDotNetExporter[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Exporters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T SetExporters<T>(this T o, IEnumerable<BenchmarkDotNetExporter> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Exporters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T AddExporters<T>(this T o, params BenchmarkDotNetExporter[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.Exporters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T AddExporters<T>(this T o, IEnumerable<BenchmarkDotNetExporter> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.Exporters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T RemoveExporters<T>(this T o, params BenchmarkDotNetExporter[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Exporters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T RemoveExporters<T>(this T o, IEnumerable<BenchmarkDotNetExporter> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Exporters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Exporters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Exporters))]
    public static T ClearExporters<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.Exporters));
    #endregion
    #region MemoryStats
    /// <inheritdoc cref="BenchmarkDotNetSettings.MemoryStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MemoryStats))]
    public static T SetMemoryStats<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MemoryStats, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MemoryStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MemoryStats))]
    public static T ResetMemoryStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MemoryStats));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MemoryStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MemoryStats))]
    public static T EnableMemoryStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MemoryStats, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MemoryStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MemoryStats))]
    public static T DisableMemoryStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MemoryStats, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MemoryStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MemoryStats))]
    public static T ToggleMemoryStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MemoryStats, !o.MemoryStats));
    #endregion
    #region ThreadingStats
    /// <inheritdoc cref="BenchmarkDotNetSettings.ThreadingStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ThreadingStats))]
    public static T SetThreadingStats<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ThreadingStats, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ThreadingStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ThreadingStats))]
    public static T ResetThreadingStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.ThreadingStats));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ThreadingStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ThreadingStats))]
    public static T EnableThreadingStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ThreadingStats, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ThreadingStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ThreadingStats))]
    public static T DisableThreadingStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ThreadingStats, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ThreadingStats"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ThreadingStats))]
    public static T ToggleThreadingStats<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ThreadingStats, !o.ThreadingStats));
    #endregion
    #region Disassembly
    /// <inheritdoc cref="BenchmarkDotNetSettings.Disassembly"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Disassembly))]
    public static T SetDisassembly<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Disassembly, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Disassembly"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Disassembly))]
    public static T ResetDisassembly<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.Disassembly));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Disassembly"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Disassembly))]
    public static T EnableDisassembly<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Disassembly, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Disassembly"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Disassembly))]
    public static T DisableDisassembly<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Disassembly, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Disassembly"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Disassembly))]
    public static T ToggleDisassembly<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Disassembly, !o.Disassembly));
    #endregion
    #region Profiler
    /// <inheritdoc cref="BenchmarkDotNetSettings.Profiler"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Profiler))]
    public static T SetProfiler<T>(this T o, BenchmarkDotNetProfiler v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Profiler, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Profiler"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Profiler))]
    public static T ResetProfiler<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.Profiler));
    #endregion
    #region Filter
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T SetFilter<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T SetFilter<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T AddFilter<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.Filter, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T AddFilter<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.Filter, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T RemoveFilter<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Filter, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T RemoveFilter<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.Filter, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Filter"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Filter))]
    public static T ClearFilter<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.Filter));
    #endregion
    #region RunInProcess
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunInProcess"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunInProcess))]
    public static T SetRunInProcess<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunInProcess, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunInProcess"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunInProcess))]
    public static T ResetRunInProcess<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.RunInProcess));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunInProcess"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunInProcess))]
    public static T EnableRunInProcess<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunInProcess, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunInProcess"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunInProcess))]
    public static T DisableRunInProcess<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunInProcess, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunInProcess"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunInProcess))]
    public static T ToggleRunInProcess<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunInProcess, !o.RunInProcess));
    #endregion
    #region ArtifactsDirecory
    /// <inheritdoc cref="BenchmarkDotNetSettings.ArtifactsDirecory"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ArtifactsDirecory))]
    public static T SetArtifactsDirecory<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ArtifactsDirecory, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ArtifactsDirecory"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ArtifactsDirecory))]
    public static T ResetArtifactsDirecory<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.ArtifactsDirecory));
    #endregion
    #region OutlierMode
    /// <inheritdoc cref="BenchmarkDotNetSettings.OutlierMode"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.OutlierMode))]
    public static T SetOutlierMode<T>(this T o, BenchmarkDotNetOutlierMode v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.OutlierMode, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.OutlierMode"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.OutlierMode))]
    public static T ResetOutlierMode<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.OutlierMode));
    #endregion
    #region Affinity
    /// <inheritdoc cref="BenchmarkDotNetSettings.Affinity"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Affinity))]
    public static T SetAffinity<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Affinity, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Affinity"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Affinity))]
    public static T ResetAffinity<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.Affinity));
    #endregion
    #region DisplayAllStatistics
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisplayAllStatistics"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisplayAllStatistics))]
    public static T SetDisplayAllStatistics<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisplayAllStatistics, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisplayAllStatistics"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisplayAllStatistics))]
    public static T ResetDisplayAllStatistics<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.DisplayAllStatistics));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisplayAllStatistics"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisplayAllStatistics))]
    public static T EnableDisplayAllStatistics<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisplayAllStatistics, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisplayAllStatistics"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisplayAllStatistics))]
    public static T DisableDisplayAllStatistics<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisplayAllStatistics, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisplayAllStatistics"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisplayAllStatistics))]
    public static T ToggleDisplayAllStatistics<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisplayAllStatistics, !o.DisplayAllStatistics));
    #endregion
    #region AllCategories
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T SetAllCategories<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AllCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T SetAllCategories<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AllCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T AddAllCategories<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.AllCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T AddAllCategories<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.AllCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T RemoveAllCategories<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AllCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T RemoveAllCategories<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AllCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AllCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AllCategories))]
    public static T ClearAllCategories<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.AllCategories));
    #endregion
    #region AnyCategories
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T SetAnyCategories<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AnyCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T SetAnyCategories<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AnyCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T AddAnyCategories<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.AnyCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T AddAnyCategories<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.AnyCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T RemoveAnyCategories<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AnyCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T RemoveAnyCategories<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AnyCategories, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AnyCategories"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AnyCategories))]
    public static T ClearAnyCategories<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.AnyCategories));
    #endregion
    #region AttributeNames
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T SetAttributeNames<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AttributeNames, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T SetAttributeNames<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.AttributeNames, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T AddAttributeNames<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.AttributeNames, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T AddAttributeNames<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.AttributeNames, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T RemoveAttributeNames<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeNames, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T RemoveAttributeNames<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.AttributeNames, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.AttributeNames"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.AttributeNames))]
    public static T ClearAttributeNames<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.AttributeNames));
    #endregion
    #region Join
    /// <inheritdoc cref="BenchmarkDotNetSettings.Join"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Join))]
    public static T SetJoin<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Join, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Join"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Join))]
    public static T ResetJoin<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.Join));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Join"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Join))]
    public static T EnableJoin<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Join, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Join"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Join))]
    public static T DisableJoin<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Join, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.Join"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.Join))]
    public static T ToggleJoin<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.Join, !o.Join));
    #endregion
    #region KeepBenchmarkFiles
    /// <inheritdoc cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.KeepBenchmarkFiles))]
    public static T SetKeepBenchmarkFiles<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.KeepBenchmarkFiles, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.KeepBenchmarkFiles))]
    public static T ResetKeepBenchmarkFiles<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.KeepBenchmarkFiles));
    /// <inheritdoc cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.KeepBenchmarkFiles))]
    public static T EnableKeepBenchmarkFiles<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.KeepBenchmarkFiles, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.KeepBenchmarkFiles))]
    public static T DisableKeepBenchmarkFiles<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.KeepBenchmarkFiles, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.KeepBenchmarkFiles))]
    public static T ToggleKeepBenchmarkFiles<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.KeepBenchmarkFiles, !o.KeepBenchmarkFiles));
    #endregion
    #region DontOverwriteResults
    /// <inheritdoc cref="BenchmarkDotNetSettings.DontOverwriteResults"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DontOverwriteResults))]
    public static T SetDontOverwriteResults<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DontOverwriteResults, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DontOverwriteResults"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DontOverwriteResults))]
    public static T ResetDontOverwriteResults<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.DontOverwriteResults));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DontOverwriteResults"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DontOverwriteResults))]
    public static T EnableDontOverwriteResults<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DontOverwriteResults, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DontOverwriteResults"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DontOverwriteResults))]
    public static T DisableDontOverwriteResults<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DontOverwriteResults, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DontOverwriteResults"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DontOverwriteResults))]
    public static T ToggleDontOverwriteResults<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DontOverwriteResults, !o.DontOverwriteResults));
    #endregion
    #region HardwareCounters
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T SetHardwareCounters<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.HardwareCounters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T SetHardwareCounters<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.HardwareCounters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T AddHardwareCounters<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.HardwareCounters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T AddHardwareCounters<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.HardwareCounters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T RemoveHardwareCounters<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.HardwareCounters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T RemoveHardwareCounters<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.HardwareCounters, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.HardwareCounters"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.HardwareCounters))]
    public static T ClearHardwareCounters<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.HardwareCounters));
    #endregion
    #region CliPath
    /// <inheritdoc cref="BenchmarkDotNetSettings.CliPath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CliPath))]
    public static T SetCliPath<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.CliPath, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CliPath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CliPath))]
    public static T ResetCliPath<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.CliPath));
    #endregion
    #region RestorePath
    /// <inheritdoc cref="BenchmarkDotNetSettings.RestorePath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RestorePath))]
    public static T SetRestorePath<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RestorePath, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RestorePath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RestorePath))]
    public static T ResetRestorePath<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.RestorePath));
    #endregion
    #region CoreRunPaths
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T SetCoreRunPaths<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.CoreRunPaths, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T SetCoreRunPaths<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.CoreRunPaths, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T AddCoreRunPaths<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.CoreRunPaths, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T AddCoreRunPaths<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.AddCollection(() => o.CoreRunPaths, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T RemoveCoreRunPaths<T>(this T o, params string[] v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.CoreRunPaths, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T RemoveCoreRunPaths<T>(this T o, IEnumerable<string> v) where T : BenchmarkDotNetSettings => o.Modify(b => b.RemoveCollection(() => o.CoreRunPaths, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRunPaths"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRunPaths))]
    public static T ClearCoreRunPaths<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.ClearCollection(() => o.CoreRunPaths));
    #endregion
    #region MonoPath
    /// <inheritdoc cref="BenchmarkDotNetSettings.MonoPath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MonoPath))]
    public static T SetMonoPath<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MonoPath, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MonoPath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MonoPath))]
    public static T ResetMonoPath<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MonoPath));
    #endregion
    #region ClrVersion
    /// <inheritdoc cref="BenchmarkDotNetSettings.ClrVersion"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ClrVersion))]
    public static T SetClrVersion<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ClrVersion, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ClrVersion"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ClrVersion))]
    public static T ResetClrVersion<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.ClrVersion));
    #endregion
    #region CoreRtVersion
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRtVersion"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRtVersion))]
    public static T SetCoreRtVersion<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.CoreRtVersion, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRtVersion"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRtVersion))]
    public static T ResetCoreRtVersion<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.CoreRtVersion));
    #endregion
    #region CoreRtPath
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRtPath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRtPath))]
    public static T SetCoreRtPath<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.CoreRtPath, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.CoreRtPath"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.CoreRtPath))]
    public static T ResetCoreRtPath<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.CoreRtPath));
    #endregion
    #region LaunchCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.LaunchCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.LaunchCount))]
    public static T SetLaunchCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.LaunchCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.LaunchCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.LaunchCount))]
    public static T ResetLaunchCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.LaunchCount));
    #endregion
    #region WarmupCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.WarmupCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.WarmupCount))]
    public static T SetWarmupCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.WarmupCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.WarmupCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.WarmupCount))]
    public static T ResetWarmupCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.WarmupCount));
    #endregion
    #region MinWarmupCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.MinWarmupCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MinWarmupCount))]
    public static T SetMinWarmupCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MinWarmupCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MinWarmupCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MinWarmupCount))]
    public static T ResetMinWarmupCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MinWarmupCount));
    #endregion
    #region MaxWarmupCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.MaxWarmupCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MaxWarmupCount))]
    public static T SetMaxWarmupCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MaxWarmupCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MaxWarmupCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MaxWarmupCount))]
    public static T ResetMaxWarmupCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MaxWarmupCount));
    #endregion
    #region IterationTime
    /// <inheritdoc cref="BenchmarkDotNetSettings.IterationTime"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.IterationTime))]
    public static T SetIterationTime<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.IterationTime, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.IterationTime"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.IterationTime))]
    public static T ResetIterationTime<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.IterationTime));
    #endregion
    #region IterationCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.IterationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.IterationCount))]
    public static T SetIterationCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.IterationCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.IterationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.IterationCount))]
    public static T ResetIterationCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.IterationCount));
    #endregion
    #region MinIterationCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.MinIterationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MinIterationCount))]
    public static T SetMinIterationCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MinIterationCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MinIterationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MinIterationCount))]
    public static T ResetMinIterationCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MinIterationCount));
    #endregion
    #region MaxIterationCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.MaxIterationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MaxIterationCount))]
    public static T SetMaxIterationCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MaxIterationCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MaxIterationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MaxIterationCount))]
    public static T ResetMaxIterationCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MaxIterationCount));
    #endregion
    #region InvocationCount
    /// <inheritdoc cref="BenchmarkDotNetSettings.InvocationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.InvocationCount))]
    public static T SetInvocationCount<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.InvocationCount, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.InvocationCount"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.InvocationCount))]
    public static T ResetInvocationCount<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.InvocationCount));
    #endregion
    #region UnrollFactor
    /// <inheritdoc cref="BenchmarkDotNetSettings.UnrollFactor"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.UnrollFactor))]
    public static T SetUnrollFactor<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.UnrollFactor, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.UnrollFactor"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.UnrollFactor))]
    public static T ResetUnrollFactor<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.UnrollFactor));
    #endregion
    #region RunStrategy
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunStrategy"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunStrategy))]
    public static T SetRunStrategy<T>(this T o, BenchmarkDotNetRunStrategy v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunStrategy, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunStrategy"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunStrategy))]
    public static T ResetRunStrategy<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.RunStrategy));
    #endregion
    #region RunOncePerIteration
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunOncePerIteration"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunOncePerIteration))]
    public static T SetRunOncePerIteration<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunOncePerIteration, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunOncePerIteration"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunOncePerIteration))]
    public static T ResetRunOncePerIteration<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.RunOncePerIteration));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunOncePerIteration"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunOncePerIteration))]
    public static T EnableRunOncePerIteration<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunOncePerIteration, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunOncePerIteration"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunOncePerIteration))]
    public static T DisableRunOncePerIteration<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunOncePerIteration, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.RunOncePerIteration"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.RunOncePerIteration))]
    public static T ToggleRunOncePerIteration<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.RunOncePerIteration, !o.RunOncePerIteration));
    #endregion
    #region PrintInformation
    /// <inheritdoc cref="BenchmarkDotNetSettings.PrintInformation"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.PrintInformation))]
    public static T SetPrintInformation<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.PrintInformation, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.PrintInformation"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.PrintInformation))]
    public static T ResetPrintInformation<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.PrintInformation));
    /// <inheritdoc cref="BenchmarkDotNetSettings.PrintInformation"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.PrintInformation))]
    public static T EnablePrintInformation<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.PrintInformation, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.PrintInformation"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.PrintInformation))]
    public static T DisablePrintInformation<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.PrintInformation, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.PrintInformation"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.PrintInformation))]
    public static T TogglePrintInformation<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.PrintInformation, !o.PrintInformation));
    #endregion
    #region ListBenchmarkCaseMode
    /// <inheritdoc cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ListBenchmarkCaseMode))]
    public static T SetListBenchmarkCaseMode<T>(this T o, BenchmarkDotNetCaseMode v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.ListBenchmarkCaseMode, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.ListBenchmarkCaseMode))]
    public static T ResetListBenchmarkCaseMode<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.ListBenchmarkCaseMode));
    #endregion
    #region DisassemblyRecursiveDepth
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyRecursiveDepth))]
    public static T SetDisassemblyRecursiveDepth<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisassemblyRecursiveDepth, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyRecursiveDepth))]
    public static T ResetDisassemblyRecursiveDepth<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.DisassemblyRecursiveDepth));
    #endregion
    #region DisassemblyDiff
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyDiff"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyDiff))]
    public static T SetDisassemblyDiff<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisassemblyDiff, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyDiff"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyDiff))]
    public static T ResetDisassemblyDiff<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.DisassemblyDiff));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyDiff"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyDiff))]
    public static T EnableDisassemblyDiff<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisassemblyDiff, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyDiff"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyDiff))]
    public static T DisableDisassemblyDiff<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisassemblyDiff, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisassemblyDiff"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisassemblyDiff))]
    public static T ToggleDisassemblyDiff<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisassemblyDiff, !o.DisassemblyDiff));
    #endregion
    #region BuildTimeout
    /// <inheritdoc cref="BenchmarkDotNetSettings.BuildTimeout"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.BuildTimeout))]
    public static T SetBuildTimeout<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.BuildTimeout, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.BuildTimeout"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.BuildTimeout))]
    public static T ResetBuildTimeout<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.BuildTimeout));
    #endregion
    #region StopOnFirstError
    /// <inheritdoc cref="BenchmarkDotNetSettings.StopOnFirstError"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StopOnFirstError))]
    public static T SetStopOnFirstError<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.StopOnFirstError, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.StopOnFirstError"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StopOnFirstError))]
    public static T ResetStopOnFirstError<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.StopOnFirstError));
    /// <inheritdoc cref="BenchmarkDotNetSettings.StopOnFirstError"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StopOnFirstError))]
    public static T EnableStopOnFirstError<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.StopOnFirstError, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.StopOnFirstError"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StopOnFirstError))]
    public static T DisableStopOnFirstError<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.StopOnFirstError, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.StopOnFirstError"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StopOnFirstError))]
    public static T ToggleStopOnFirstError<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.StopOnFirstError, !o.StopOnFirstError));
    #endregion
    #region StatisticalTestThreshold
    /// <inheritdoc cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StatisticalTestThreshold))]
    public static T SetStatisticalTestThreshold<T>(this T o, string v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.StatisticalTestThreshold, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.StatisticalTestThreshold))]
    public static T ResetStatisticalTestThreshold<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.StatisticalTestThreshold));
    #endregion
    #region DisableLogFile
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisableLogFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisableLogFile))]
    public static T SetDisableLogFile<T>(this T o, bool? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisableLogFile, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisableLogFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisableLogFile))]
    public static T ResetDisableLogFile<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.DisableLogFile));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisableLogFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisableLogFile))]
    public static T EnableDisableLogFile<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisableLogFile, true));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisableLogFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisableLogFile))]
    public static T DisableDisableLogFile<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisableLogFile, false));
    /// <inheritdoc cref="BenchmarkDotNetSettings.DisableLogFile"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.DisableLogFile))]
    public static T ToggleDisableLogFile<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.DisableLogFile, !o.DisableLogFile));
    #endregion
    #region MaxParameterColumnWidth
    /// <inheritdoc cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MaxParameterColumnWidth))]
    public static T SetMaxParameterColumnWidth<T>(this T o, int? v) where T : BenchmarkDotNetSettings => o.Modify(b => b.Set(() => o.MaxParameterColumnWidth, v));
    /// <inheritdoc cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/>
    [Pure] [Builder(Type = typeof(BenchmarkDotNetSettings), Property = nameof(BenchmarkDotNetSettings.MaxParameterColumnWidth))]
    public static T ResetMaxParameterColumnWidth<T>(this T o) where T : BenchmarkDotNetSettings => o.Modify(b => b.Remove(() => o.MaxParameterColumnWidth));
    #endregion
}
#endregion
#region BenchmarkDotNetJob
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetJob>))]
public partial class BenchmarkDotNetJob : Enumeration
{
    public static BenchmarkDotNetJob Dry = (BenchmarkDotNetJob) "Dry";
    public static BenchmarkDotNetJob Short = (BenchmarkDotNetJob) "Short";
    public static BenchmarkDotNetJob Medium = (BenchmarkDotNetJob) "Medium";
    public static BenchmarkDotNetJob Long = (BenchmarkDotNetJob) "Long";
    public static BenchmarkDotNetJob Default = (BenchmarkDotNetJob) "Default";
    public static implicit operator BenchmarkDotNetJob(string value)
    {
        return new BenchmarkDotNetJob { Value = value };
    }
}
#endregion
#region BenchmarkDotNetOutlierMode
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetOutlierMode>))]
public partial class BenchmarkDotNetOutlierMode : Enumeration
{
    public static BenchmarkDotNetOutlierMode DontRemove = (BenchmarkDotNetOutlierMode) "DontRemove";
    public static BenchmarkDotNetOutlierMode RemoveUpper = (BenchmarkDotNetOutlierMode) "RemoveUpper";
    public static BenchmarkDotNetOutlierMode RemoveLower = (BenchmarkDotNetOutlierMode) "RemoveLower";
    public static BenchmarkDotNetOutlierMode RemoveAll = (BenchmarkDotNetOutlierMode) "RemoveAll";
    public static implicit operator BenchmarkDotNetOutlierMode(string value)
    {
        return new BenchmarkDotNetOutlierMode { Value = value };
    }
}
#endregion
#region BenchmarkDotNetExporter
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetExporter>))]
public partial class BenchmarkDotNetExporter : Enumeration
{
    public static BenchmarkDotNetExporter GitHub = (BenchmarkDotNetExporter) "GitHub";
    public static BenchmarkDotNetExporter StackOverflow = (BenchmarkDotNetExporter) "StackOverflow";
    public static BenchmarkDotNetExporter RPlot = (BenchmarkDotNetExporter) "RPlot";
    public static BenchmarkDotNetExporter CSV = (BenchmarkDotNetExporter) "CSV";
    public static BenchmarkDotNetExporter JSON = (BenchmarkDotNetExporter) "JSON";
    public static BenchmarkDotNetExporter HTML = (BenchmarkDotNetExporter) "HTML";
    public static BenchmarkDotNetExporter XML = (BenchmarkDotNetExporter) "XML";
    public static implicit operator BenchmarkDotNetExporter(string value)
    {
        return new BenchmarkDotNetExporter { Value = value };
    }
}
#endregion
#region BenchmarkDotNetProfiler
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetProfiler>))]
public partial class BenchmarkDotNetProfiler : Enumeration
{
    public static BenchmarkDotNetProfiler EP = (BenchmarkDotNetProfiler) "EP";
    public static BenchmarkDotNetProfiler ETW = (BenchmarkDotNetProfiler) "ETW";
    public static BenchmarkDotNetProfiler CV = (BenchmarkDotNetProfiler) "CV";
    public static BenchmarkDotNetProfiler NativeMemory = (BenchmarkDotNetProfiler) "NativeMemory";
    public static implicit operator BenchmarkDotNetProfiler(string value)
    {
        return new BenchmarkDotNetProfiler { Value = value };
    }
}
#endregion
#region BenchmarkDotNetRunStrategy
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetRunStrategy>))]
public partial class BenchmarkDotNetRunStrategy : Enumeration
{
    public static BenchmarkDotNetRunStrategy Throughput = (BenchmarkDotNetRunStrategy) "Throughput";
    public static BenchmarkDotNetRunStrategy ColdStart = (BenchmarkDotNetRunStrategy) "ColdStart";
    public static BenchmarkDotNetRunStrategy Monitoring = (BenchmarkDotNetRunStrategy) "Monitoring";
    public static implicit operator BenchmarkDotNetRunStrategy(string value)
    {
        return new BenchmarkDotNetRunStrategy { Value = value };
    }
}
#endregion
#region BenchmarkDotNetCaseMode
/// <summary>Used within <see cref="BenchmarkDotNetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BenchmarkDotNetCaseMode>))]
public partial class BenchmarkDotNetCaseMode : Enumeration
{
    public static BenchmarkDotNetCaseMode Flat = (BenchmarkDotNetCaseMode) "Flat";
    public static BenchmarkDotNetCaseMode Tree = (BenchmarkDotNetCaseMode) "Tree";
    public static implicit operator BenchmarkDotNetCaseMode(string value)
    {
        return new BenchmarkDotNetCaseMode { Value = value };
    }
}
#endregion
