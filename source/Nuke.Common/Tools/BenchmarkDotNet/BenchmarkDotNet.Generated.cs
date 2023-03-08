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

namespace Nuke.Common.Tools.BenchmarkDotNet
{
    /// <summary>
    ///   <p>Powerful .NET library for benchmarking</p>
    ///   <p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(BenchmarkDotNetPackageId)]
    public partial class BenchmarkDotNetTasks
        : IRequireNuGetPackage
    {
        public const string BenchmarkDotNetPackageId = "benchmarkdotnet.tool";
        /// <summary>
        ///   Path to the BenchmarkDotNet executable.
        /// </summary>
        public static string BenchmarkDotNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("BENCHMARKDOTNET_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("benchmarkdotnet.tool", "BenchmarkDotNet.Tool.dll");
        public static Action<OutputType, string> BenchmarkDotNetLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking</p>
        ///   <p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> BenchmarkDotNet(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(BenchmarkDotNetPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? BenchmarkDotNetLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking</p>
        ///   <p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li>
        ///     <li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li>
        ///     <li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li>
        ///     <li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></li>
        ///     <li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li>
        ///     <li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></li>
        ///     <li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.AttributeNames"/></li>
        ///     <li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li>
        ///     <li><c>--cli</c> via <see cref="BenchmarkDotNetSettings.CliPath"/></li>
        ///     <li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li>
        ///     <li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li>
        ///     <li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></li>
        ///     <li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li>
        ///     <li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li>
        ///     <li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disassembly"/></li>
        ///     <li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></li>
        ///     <li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></li>
        ///     <li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li>
        ///     <li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li>
        ///     <li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.CoreRtPath"/></li>
        ///     <li><c>--info</c> via <see cref="BenchmarkDotNetSettings.PrintInformation"/></li>
        ///     <li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li>
        ///     <li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li>
        ///     <li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li>
        ///     <li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li>
        ///     <li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li>
        ///     <li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li>
        ///     <li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></li>
        ///     <li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li>
        ///     <li><c>--list</c> via <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></li>
        ///     <li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li>
        ///     <li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li>
        ///     <li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></li>
        ///     <li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.MemoryStats"/></li>
        ///     <li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li>
        ///     <li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li>
        ///     <li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li>
        ///     <li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></li>
        ///     <li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.OutlierMode"/></li>
        ///     <li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.RestorePath"/></li>
        ///     <li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li>
        ///     <li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li>
        ///     <li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li>
        ///     <li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></li>
        ///     <li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li>
        ///     <li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.RunStrategy"/></li>
        ///     <li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.ThreadingStats"/></li>
        ///     <li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li>
        ///     <li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> BenchmarkDotNet(BenchmarkDotNetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new BenchmarkDotNetSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking</p>
        ///   <p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li>
        ///     <li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li>
        ///     <li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li>
        ///     <li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></li>
        ///     <li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li>
        ///     <li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></li>
        ///     <li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.AttributeNames"/></li>
        ///     <li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li>
        ///     <li><c>--cli</c> via <see cref="BenchmarkDotNetSettings.CliPath"/></li>
        ///     <li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li>
        ///     <li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li>
        ///     <li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></li>
        ///     <li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li>
        ///     <li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li>
        ///     <li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disassembly"/></li>
        ///     <li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></li>
        ///     <li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></li>
        ///     <li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li>
        ///     <li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li>
        ///     <li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.CoreRtPath"/></li>
        ///     <li><c>--info</c> via <see cref="BenchmarkDotNetSettings.PrintInformation"/></li>
        ///     <li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li>
        ///     <li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li>
        ///     <li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li>
        ///     <li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li>
        ///     <li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li>
        ///     <li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li>
        ///     <li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></li>
        ///     <li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li>
        ///     <li><c>--list</c> via <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></li>
        ///     <li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li>
        ///     <li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li>
        ///     <li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></li>
        ///     <li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.MemoryStats"/></li>
        ///     <li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li>
        ///     <li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li>
        ///     <li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li>
        ///     <li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></li>
        ///     <li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.OutlierMode"/></li>
        ///     <li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.RestorePath"/></li>
        ///     <li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li>
        ///     <li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li>
        ///     <li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li>
        ///     <li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></li>
        ///     <li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li>
        ///     <li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.RunStrategy"/></li>
        ///     <li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.ThreadingStats"/></li>
        ///     <li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li>
        ///     <li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> BenchmarkDotNet(Configure<BenchmarkDotNetSettings> configurator)
        {
            return BenchmarkDotNet(configurator(new BenchmarkDotNetSettings()));
        }
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking</p>
        ///   <p>For more details, visit the <a href="https://benchmarkdotnet.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li>
        ///     <li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li>
        ///     <li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li>
        ///     <li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></li>
        ///     <li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li>
        ///     <li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></li>
        ///     <li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.AttributeNames"/></li>
        ///     <li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li>
        ///     <li><c>--cli</c> via <see cref="BenchmarkDotNetSettings.CliPath"/></li>
        ///     <li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li>
        ///     <li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li>
        ///     <li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></li>
        ///     <li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li>
        ///     <li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li>
        ///     <li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disassembly"/></li>
        ///     <li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></li>
        ///     <li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></li>
        ///     <li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li>
        ///     <li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li>
        ///     <li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.CoreRtPath"/></li>
        ///     <li><c>--info</c> via <see cref="BenchmarkDotNetSettings.PrintInformation"/></li>
        ///     <li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li>
        ///     <li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li>
        ///     <li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li>
        ///     <li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li>
        ///     <li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li>
        ///     <li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li>
        ///     <li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></li>
        ///     <li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li>
        ///     <li><c>--list</c> via <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></li>
        ///     <li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li>
        ///     <li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li>
        ///     <li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></li>
        ///     <li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.MemoryStats"/></li>
        ///     <li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li>
        ///     <li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li>
        ///     <li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li>
        ///     <li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></li>
        ///     <li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.OutlierMode"/></li>
        ///     <li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.RestorePath"/></li>
        ///     <li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li>
        ///     <li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li>
        ///     <li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li>
        ///     <li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></li>
        ///     <li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li>
        ///     <li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.RunStrategy"/></li>
        ///     <li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.ThreadingStats"/></li>
        ///     <li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li>
        ///     <li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(BenchmarkDotNetSettings Settings, IReadOnlyCollection<Output> Output)> BenchmarkDotNet(CombinatorialConfigure<BenchmarkDotNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(BenchmarkDotNet, BenchmarkDotNetLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region BenchmarkDotNetSettings
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class BenchmarkDotNetSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the BenchmarkDotNet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? BenchmarkDotNetTasks.BenchmarkDotNetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? BenchmarkDotNetTasks.BenchmarkDotNetLogger;
        /// <summary>
        ///   The assembly with the benchmarks (required).
        /// </summary>
        public virtual string AssemblyFile { get; internal set; }
        /// <summary>
        ///   Dry/Short/Medium/Long or Default
        /// </summary>
        public virtual BenchmarkDotNetJob Job { get; internal set; }
        /// <summary>
        ///   Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!
        /// </summary>
        public virtual IReadOnlyList<string> Runtimes => RuntimesInternal.AsReadOnly();
        internal List<string> RuntimesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML
        /// </summary>
        public virtual IReadOnlyList<BenchmarkDotNetExporter> Exporters => ExportersInternal.AsReadOnly();
        internal List<BenchmarkDotNetExporter> ExportersInternal { get; set; } = new List<BenchmarkDotNetExporter>();
        /// <summary>
        ///   Prints memory statistics
        /// </summary>
        public virtual bool? MemoryStats { get; internal set; }
        /// <summary>
        ///   Prints threading statistics
        /// </summary>
        public virtual bool? ThreadingStats { get; internal set; }
        /// <summary>
        ///   Gets disassembly of benchmarked code
        /// </summary>
        public virtual bool? Disassembly { get; internal set; }
        /// <summary>
        ///   Profiles benchmarked code using selected profiler.
        /// </summary>
        public virtual BenchmarkDotNetProfiler Profiler { get; internal set; }
        /// <summary>
        ///   Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c>
        /// </summary>
        public virtual IReadOnlyList<string> Filter => FilterInternal.AsReadOnly();
        internal List<string> FilterInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Run benchmarks in Process
        /// </summary>
        public virtual bool? RunInProcess { get; internal set; }
        /// <summary>
        ///   Valid path to accessible directory
        /// </summary>
        public virtual string ArtifactsDirecory { get; internal set; }
        /// <summary>
        ///   DontRemove/RemoveUpper/RemoveLower/RemoveAll
        /// </summary>
        public virtual BenchmarkDotNetOutlierMode OutlierMode { get; internal set; }
        /// <summary>
        ///   Affinity mask to set for the benchmark process
        /// </summary>
        public virtual int? Affinity { get; internal set; }
        /// <summary>
        ///   Displays all statistics (min, max &amp; more)
        /// </summary>
        public virtual bool? DisplayAllStatistics { get; internal set; }
        /// <summary>
        ///   Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed
        /// </summary>
        public virtual IReadOnlyList<string> AllCategories => AllCategoriesInternal.AsReadOnly();
        internal List<string> AllCategoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Any Categories to run
        /// </summary>
        public virtual IReadOnlyList<string> AnyCategories => AnyCategoriesInternal.AsReadOnly();
        internal List<string> AnyCategoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Run all methods with given attribute (applied to class or method)
        /// </summary>
        public virtual IReadOnlyList<string> AttributeNames => AttributeNamesInternal.AsReadOnly();
        internal List<string> AttributeNamesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Prints single table with results for all benchmarks
        /// </summary>
        public virtual bool? Join { get; internal set; }
        /// <summary>
        ///   Determines if all auto-generated files should be kept or removed after running the benchmarks.
        /// </summary>
        public virtual bool? KeepBenchmarkFiles { get; internal set; }
        /// <summary>
        ///   Determines if the exported result files should not be overwritten (by default they are overwritten).
        /// </summary>
        public virtual bool? DontOverwriteResults { get; internal set; }
        /// <summary>
        ///   Hardware Counters
        /// </summary>
        public virtual IReadOnlyList<string> HardwareCounters => HardwareCountersInternal.AsReadOnly();
        internal List<string> HardwareCountersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Path to dotnet CLI (optional).
        /// </summary>
        public virtual string CliPath { get; internal set; }
        /// <summary>
        ///   The directory to restore packages to (optional).
        /// </summary>
        public virtual string RestorePath { get; internal set; }
        /// <summary>
        ///   Path(s) to CoreRun (optional).
        /// </summary>
        public virtual IReadOnlyList<string> CoreRunPaths => CoreRunPathsInternal.AsReadOnly();
        internal List<string> CoreRunPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Optional path to Mono which should be used for running benchmarks.
        /// </summary>
        public virtual string MonoPath { get; internal set; }
        /// <summary>
        ///   Optional version of private CLR build used as the value of <c>COMPLUS_Version</c> env var.
        /// </summary>
        public virtual string ClrVersion { get; internal set; }
        /// <summary>
        ///   Optional version of <c>Microsoft.DotNet.ILCompiler</c> which should be used to run with CoreRT. Example: <c>1.0.0-alpha-26414-01</c>
        /// </summary>
        public virtual string CoreRtVersion { get; internal set; }
        /// <summary>
        ///   Optional IlcPath which should be used to run with private CoreRT build.
        /// </summary>
        public virtual string CoreRtPath { get; internal set; }
        /// <summary>
        ///   How many times we should launch process with target benchmark. The default is <c>1</c>.
        /// </summary>
        public virtual int? LaunchCount { get; internal set; }
        /// <summary>
        ///   How many warmup iterations should be performed. If you set it, the <c>minWarmupCount</c> and <c>maxWarmupCount</c> are ignored. By default calculated by the heuristic.
        /// </summary>
        public virtual int? WarmupCount { get; internal set; }
        /// <summary>
        ///   Minimum count of warmup iterations that should be performed. The default is <c>6</c>.
        /// </summary>
        public virtual int? MinWarmupCount { get; internal set; }
        /// <summary>
        ///   Maximum count of warmup iterations that should be performed. The default is <c>50</c>.
        /// </summary>
        public virtual int? MaxWarmupCount { get; internal set; }
        /// <summary>
        ///   Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. The default is <c>500</c> milliseconds.
        /// </summary>
        public virtual int? IterationTime { get; internal set; }
        /// <summary>
        ///   How many target iterations should be performed. By default calculated by the heuristic.
        /// </summary>
        public virtual int? IterationCount { get; internal set; }
        /// <summary>
        ///   Minimum number of iterations to run. The default is <c>15</c>.
        /// </summary>
        public virtual int? MinIterationCount { get; internal set; }
        /// <summary>
        ///   Maximum number of iterations to run. The default is <c>100</c>.
        /// </summary>
        public virtual int? MaxIterationCount { get; internal set; }
        /// <summary>
        ///   Invocation count in a single iteration. By default calculated by the heuristic.
        /// </summary>
        public virtual int? InvocationCount { get; internal set; }
        /// <summary>
        ///   How many times the benchmark method will be invoked per one iteration of a generated loop. The default is <c>16</c>.
        /// </summary>
        public virtual int? UnrollFactor { get; internal set; }
        /// <summary>
        ///   The run strategy that should be used. Throughput/ColdStart/Monitoring.
        /// </summary>
        public virtual BenchmarkDotNetRunStrategy RunStrategy { get; internal set; }
        /// <summary>
        ///   Run the benchmark exactly once per iteration.
        /// </summary>
        public virtual bool? RunOncePerIteration { get; internal set; }
        /// <summary>
        ///   Print environment information.
        /// </summary>
        public virtual bool? PrintInformation { get; internal set; }
        /// <summary>
        ///   Prints all of the available benchmark names. Flat/Tree
        /// </summary>
        public virtual BenchmarkDotNetCaseMode ListBenchmarkCaseMode { get; internal set; }
        /// <summary>
        ///   Sets the recursive depth for the disassembler.
        /// </summary>
        public virtual int? DisassemblyRecursiveDepth { get; internal set; }
        /// <summary>
        ///   Generates diff reports for the disassembler.
        /// </summary>
        public virtual bool? DisassemblyDiff { get; internal set; }
        /// <summary>
        ///   Build timeout in seconds.
        /// </summary>
        public virtual int? BuildTimeout { get; internal set; }
        /// <summary>
        ///   Stop on first error.
        /// </summary>
        public virtual bool? StopOnFirstError { get; internal set; }
        /// <summary>
        ///   Threshold for Mann–Whitney U Test. Examples: <c>5%</c>, <c>10ms</c>, <c>100ns</c>, <c>1s</c>
        /// </summary>
        public virtual string StatisticalTestThreshold { get; internal set; }
        /// <summary>
        ///   Disables the logfile.
        /// </summary>
        public virtual bool? DisableLogFile { get; internal set; }
        /// <summary>
        ///   Max paramter column width, the default is <c>20</c>.
        /// </summary>
        public virtual int? MaxParameterColumnWidth { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", AssemblyFile)
              .Add("--job {value}", Job)
              .Add("--runtimes {value}", Runtimes, separator: ' ')
              .Add("--exporters {value}", Exporters, separator: ' ')
              .Add("--memory", MemoryStats)
              .Add("--threading", ThreadingStats)
              .Add("--disasm", Disassembly)
              .Add("--profiler {value}", Profiler)
              .Add("--filter {value}", Filter)
              .Add("--inProcess", RunInProcess)
              .Add("--artifacts {value}", ArtifactsDirecory)
              .Add("--outliers {value}", OutlierMode)
              .Add("--affinity {value}", Affinity)
              .Add("--allStats", DisplayAllStatistics)
              .Add("--allCategories {value}", AllCategories, separator: ' ')
              .Add("--anyCategories {value}", AnyCategories, separator: ' ')
              .Add("--attribute {value}", AttributeNames, separator: ' ')
              .Add("--join {value}", Join)
              .Add("--keepFiles", KeepBenchmarkFiles)
              .Add("--noOverwrite", DontOverwriteResults)
              .Add("--counters {value}", HardwareCounters, separator: '+')
              .Add("--cli {value}", CliPath)
              .Add("--packages {value}", RestorePath)
              .Add("--coreRun {value}", CoreRunPaths, separator: ' ', quoteMultiple: true)
              .Add("--monoPath {value}", MonoPath)
              .Add("--clrVersion {value}", ClrVersion)
              .Add("--coreRtVersion {value}", CoreRtVersion)
              .Add("--ilcPath {value}", CoreRtPath)
              .Add("--launchCount {value}", LaunchCount)
              .Add("--warmupCount {value}", WarmupCount)
              .Add("--minWarmupCount {value}", MinWarmupCount)
              .Add("--maxWarmupCount {value}", MaxWarmupCount)
              .Add("--iterationTime {value}", IterationTime)
              .Add("--iterationCount {value}", IterationCount)
              .Add("--minIterationCount {value}", MinIterationCount)
              .Add("--maxIterationCount {value}", MaxIterationCount)
              .Add("--invocationCount {value}", InvocationCount)
              .Add("--unrollFactor {value}", UnrollFactor)
              .Add("--strategy {value}", RunStrategy)
              .Add("--runOncePerIteration", RunOncePerIteration)
              .Add("--info", PrintInformation)
              .Add("--list {value}", ListBenchmarkCaseMode)
              .Add("--disasmDepth {value}", DisassemblyRecursiveDepth)
              .Add("--disasmDiff", DisassemblyDiff)
              .Add("--buildTimeout {value}", BuildTimeout)
              .Add("--stopOnFirstError", StopOnFirstError)
              .Add("--statisticalTest {value}", StatisticalTestThreshold)
              .Add("--disableLogFile", DisableLogFile)
              .Add("--maxWidth {value}", MaxParameterColumnWidth);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region BenchmarkDotNetSettingsExtensions
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class BenchmarkDotNetSettingsExtensions
    {
        #region AssemblyFile
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AssemblyFile"/></em></p>
        ///   <p>The assembly with the benchmarks (required).</p>
        /// </summary>
        [Pure]
        public static T SetAssemblyFile<T>(this T toolSettings, string assemblyFile) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFile = assemblyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.AssemblyFile"/></em></p>
        ///   <p>The assembly with the benchmarks (required).</p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyFile<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyFile = null;
            return toolSettings;
        }
        #endregion
        #region Job
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Job"/></em></p>
        ///   <p>Dry/Short/Medium/Long or Default</p>
        /// </summary>
        [Pure]
        public static T SetJob<T>(this T toolSettings, BenchmarkDotNetJob job) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Job = job;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Job"/></em></p>
        ///   <p>Dry/Short/Medium/Long or Default</p>
        /// </summary>
        [Pure]
        public static T ResetJob<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Job = null;
            return toolSettings;
        }
        #endregion
        #region Runtimes
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Runtimes"/> to a new list</em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T SetRuntimes<T>(this T toolSettings, params string[] runtimes) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal = runtimes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Runtimes"/> to a new list</em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T SetRuntimes<T>(this T toolSettings, IEnumerable<string> runtimes) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal = runtimes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.Runtimes"/></em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T AddRuntimes<T>(this T toolSettings, params string[] runtimes) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal.AddRange(runtimes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.Runtimes"/></em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T AddRuntimes<T>(this T toolSettings, IEnumerable<string> runtimes) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal.AddRange(runtimes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.Runtimes"/></em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T ClearRuntimes<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Runtimes"/></em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T RemoveRuntimes<T>(this T toolSettings, params string[] runtimes) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(runtimes);
            toolSettings.RuntimesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Runtimes"/></em></p>
        ///   <p>Full target framework moniker for .NET Core and .NET. For Mono just 'Mono', for CoreRT just 'CoreRT'. First one will be marked as baseline!</p>
        /// </summary>
        [Pure]
        public static T RemoveRuntimes<T>(this T toolSettings, IEnumerable<string> runtimes) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(runtimes);
            toolSettings.RuntimesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Exporters
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Exporters"/> to a new list</em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T SetExporters<T>(this T toolSettings, params BenchmarkDotNetExporter[] exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportersInternal = exporters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Exporters"/> to a new list</em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T SetExporters<T>(this T toolSettings, IEnumerable<BenchmarkDotNetExporter> exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportersInternal = exporters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.Exporters"/></em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T AddExporters<T>(this T toolSettings, params BenchmarkDotNetExporter[] exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportersInternal.AddRange(exporters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.Exporters"/></em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T AddExporters<T>(this T toolSettings, IEnumerable<BenchmarkDotNetExporter> exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportersInternal.AddRange(exporters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.Exporters"/></em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T ClearExporters<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Exporters"/></em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T RemoveExporters<T>(this T toolSettings, params BenchmarkDotNetExporter[] exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<BenchmarkDotNetExporter>(exporters);
            toolSettings.ExportersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Exporters"/></em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T RemoveExporters<T>(this T toolSettings, IEnumerable<BenchmarkDotNetExporter> exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<BenchmarkDotNetExporter>(exporters);
            toolSettings.ExportersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region MemoryStats
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T SetMemoryStats<T>(this T toolSettings, bool? memoryStats) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MemoryStats = memoryStats;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T ResetMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MemoryStats = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.MemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T EnableMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MemoryStats = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.MemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T DisableMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MemoryStats = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.MemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T ToggleMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MemoryStats = !toolSettings.MemoryStats;
            return toolSettings;
        }
        #endregion
        #region ThreadingStats
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.ThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T SetThreadingStats<T>(this T toolSettings, bool? threadingStats) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThreadingStats = threadingStats;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.ThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T ResetThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThreadingStats = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.ThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T EnableThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThreadingStats = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.ThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T DisableThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThreadingStats = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.ThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T ToggleThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThreadingStats = !toolSettings.ThreadingStats;
            return toolSettings;
        }
        #endregion
        #region Disassembly
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Disassembly"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T SetDisassembly<T>(this T toolSettings, bool? disassembly) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disassembly = disassembly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Disassembly"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T ResetDisassembly<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disassembly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.Disassembly"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T EnableDisassembly<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disassembly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.Disassembly"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T DisableDisassembly<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disassembly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.Disassembly"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T ToggleDisassembly<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disassembly = !toolSettings.Disassembly;
            return toolSettings;
        }
        #endregion
        #region Profiler
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Profiler"/></em></p>
        ///   <p>Profiles benchmarked code using selected profiler.</p>
        /// </summary>
        [Pure]
        public static T SetProfiler<T>(this T toolSettings, BenchmarkDotNetProfiler profiler) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profiler = profiler;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Profiler"/></em></p>
        ///   <p>Profiles benchmarked code using selected profiler.</p>
        /// </summary>
        [Pure]
        public static T ResetProfiler<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profiler = null;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Filter"/> to a new list</em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, params string[] filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterInternal = filter.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Filter"/> to a new list</em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, IEnumerable<string> filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterInternal = filter.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T AddFilter<T>(this T toolSettings, params string[] filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterInternal.AddRange(filter);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T AddFilter<T>(this T toolSettings, IEnumerable<string> filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterInternal.AddRange(filter);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T ClearFilter<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T RemoveFilter<T>(this T toolSettings, params string[] filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filter);
            toolSettings.FilterInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. <c>*</c>, <c>*.ClassA.*</c>, <c>*.ClassB.*</c></p>
        /// </summary>
        [Pure]
        public static T RemoveFilter<T>(this T toolSettings, IEnumerable<string> filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filter);
            toolSettings.FilterInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region RunInProcess
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.RunInProcess"/></em></p>
        ///   <p>Run benchmarks in Process</p>
        /// </summary>
        [Pure]
        public static T SetRunInProcess<T>(this T toolSettings, bool? runInProcess) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunInProcess = runInProcess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.RunInProcess"/></em></p>
        ///   <p>Run benchmarks in Process</p>
        /// </summary>
        [Pure]
        public static T ResetRunInProcess<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunInProcess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.RunInProcess"/></em></p>
        ///   <p>Run benchmarks in Process</p>
        /// </summary>
        [Pure]
        public static T EnableRunInProcess<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunInProcess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.RunInProcess"/></em></p>
        ///   <p>Run benchmarks in Process</p>
        /// </summary>
        [Pure]
        public static T DisableRunInProcess<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunInProcess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.RunInProcess"/></em></p>
        ///   <p>Run benchmarks in Process</p>
        /// </summary>
        [Pure]
        public static T ToggleRunInProcess<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunInProcess = !toolSettings.RunInProcess;
            return toolSettings;
        }
        #endregion
        #region ArtifactsDirecory
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></em></p>
        ///   <p>Valid path to accessible directory</p>
        /// </summary>
        [Pure]
        public static T SetArtifactsDirecory<T>(this T toolSettings, string artifactsDirecory) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArtifactsDirecory = artifactsDirecory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.ArtifactsDirecory"/></em></p>
        ///   <p>Valid path to accessible directory</p>
        /// </summary>
        [Pure]
        public static T ResetArtifactsDirecory<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArtifactsDirecory = null;
            return toolSettings;
        }
        #endregion
        #region OutlierMode
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.OutlierMode"/></em></p>
        ///   <p>DontRemove/RemoveUpper/RemoveLower/RemoveAll</p>
        /// </summary>
        [Pure]
        public static T SetOutlierMode<T>(this T toolSettings, BenchmarkDotNetOutlierMode outlierMode) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutlierMode = outlierMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.OutlierMode"/></em></p>
        ///   <p>DontRemove/RemoveUpper/RemoveLower/RemoveAll</p>
        /// </summary>
        [Pure]
        public static T ResetOutlierMode<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutlierMode = null;
            return toolSettings;
        }
        #endregion
        #region Affinity
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Affinity"/></em></p>
        ///   <p>Affinity mask to set for the benchmark process</p>
        /// </summary>
        [Pure]
        public static T SetAffinity<T>(this T toolSettings, int? affinity) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Affinity = affinity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Affinity"/></em></p>
        ///   <p>Affinity mask to set for the benchmark process</p>
        /// </summary>
        [Pure]
        public static T ResetAffinity<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Affinity = null;
            return toolSettings;
        }
        #endregion
        #region DisplayAllStatistics
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T SetDisplayAllStatistics<T>(this T toolSettings, bool? displayAllStatistics) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStatistics = displayAllStatistics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T ResetDisplayAllStatistics<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStatistics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T EnableDisplayAllStatistics<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStatistics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T DisableDisplayAllStatistics<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStatistics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.DisplayAllStatistics"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T ToggleDisplayAllStatistics<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStatistics = !toolSettings.DisplayAllStatistics;
            return toolSettings;
        }
        #endregion
        #region AllCategories
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AllCategories"/> to a new list</em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T SetAllCategories<T>(this T toolSettings, params string[] allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategoriesInternal = allCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AllCategories"/> to a new list</em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T SetAllCategories<T>(this T toolSettings, IEnumerable<string> allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategoriesInternal = allCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T AddAllCategories<T>(this T toolSettings, params string[] allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategoriesInternal.AddRange(allCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T AddAllCategories<T>(this T toolSettings, IEnumerable<string> allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategoriesInternal.AddRange(allCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T ClearAllCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T RemoveAllCategories<T>(this T toolSettings, params string[] allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(allCategories);
            toolSettings.AllCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T RemoveAllCategories<T>(this T toolSettings, IEnumerable<string> allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(allCategories);
            toolSettings.AllCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AnyCategories
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AnyCategories"/> to a new list</em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T SetAnyCategories<T>(this T toolSettings, params string[] anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategoriesInternal = anyCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AnyCategories"/> to a new list</em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T SetAnyCategories<T>(this T toolSettings, IEnumerable<string> anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategoriesInternal = anyCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T AddAnyCategories<T>(this T toolSettings, params string[] anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategoriesInternal.AddRange(anyCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T AddAnyCategories<T>(this T toolSettings, IEnumerable<string> anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategoriesInternal.AddRange(anyCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T ClearAnyCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T RemoveAnyCategories<T>(this T toolSettings, params string[] anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(anyCategories);
            toolSettings.AnyCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T RemoveAnyCategories<T>(this T toolSettings, IEnumerable<string> anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(anyCategories);
            toolSettings.AnyCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AttributeNames
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AttributeNames"/> to a new list</em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T SetAttributeNames<T>(this T toolSettings, params string[] attributeNames) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeNamesInternal = attributeNames.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AttributeNames"/> to a new list</em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T SetAttributeNames<T>(this T toolSettings, IEnumerable<string> attributeNames) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeNamesInternal = attributeNames.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.AttributeNames"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T AddAttributeNames<T>(this T toolSettings, params string[] attributeNames) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeNamesInternal.AddRange(attributeNames);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.AttributeNames"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T AddAttributeNames<T>(this T toolSettings, IEnumerable<string> attributeNames) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeNamesInternal.AddRange(attributeNames);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.AttributeNames"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T ClearAttributeNames<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AttributeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.AttributeNames"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeNames<T>(this T toolSettings, params string[] attributeNames) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeNames);
            toolSettings.AttributeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.AttributeNames"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T RemoveAttributeNames<T>(this T toolSettings, IEnumerable<string> attributeNames) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(attributeNames);
            toolSettings.AttributeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Join
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Join"/></em></p>
        ///   <p>Prints single table with results for all benchmarks</p>
        /// </summary>
        [Pure]
        public static T SetJoin<T>(this T toolSettings, bool? join) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Join = join;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Join"/></em></p>
        ///   <p>Prints single table with results for all benchmarks</p>
        /// </summary>
        [Pure]
        public static T ResetJoin<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Join = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.Join"/></em></p>
        ///   <p>Prints single table with results for all benchmarks</p>
        /// </summary>
        [Pure]
        public static T EnableJoin<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Join = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.Join"/></em></p>
        ///   <p>Prints single table with results for all benchmarks</p>
        /// </summary>
        [Pure]
        public static T DisableJoin<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Join = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.Join"/></em></p>
        ///   <p>Prints single table with results for all benchmarks</p>
        /// </summary>
        [Pure]
        public static T ToggleJoin<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Join = !toolSettings.Join;
            return toolSettings;
        }
        #endregion
        #region KeepBenchmarkFiles
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T SetKeepBenchmarkFiles<T>(this T toolSettings, bool? keepBenchmarkFiles) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepBenchmarkFiles = keepBenchmarkFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T ResetKeepBenchmarkFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepBenchmarkFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T EnableKeepBenchmarkFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepBenchmarkFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T DisableKeepBenchmarkFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepBenchmarkFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.KeepBenchmarkFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeepBenchmarkFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepBenchmarkFiles = !toolSettings.KeepBenchmarkFiles;
            return toolSettings;
        }
        #endregion
        #region DontOverwriteResults
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (by default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T SetDontOverwriteResults<T>(this T toolSettings, bool? dontOverwriteResults) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DontOverwriteResults = dontOverwriteResults;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (by default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T ResetDontOverwriteResults<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DontOverwriteResults = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (by default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T EnableDontOverwriteResults<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DontOverwriteResults = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (by default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T DisableDontOverwriteResults<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DontOverwriteResults = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.DontOverwriteResults"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (by default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T ToggleDontOverwriteResults<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DontOverwriteResults = !toolSettings.DontOverwriteResults;
            return toolSettings;
        }
        #endregion
        #region HardwareCounters
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.HardwareCounters"/> to a new list</em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T SetHardwareCounters<T>(this T toolSettings, params string[] hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCountersInternal = hardwareCounters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.HardwareCounters"/> to a new list</em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T SetHardwareCounters<T>(this T toolSettings, IEnumerable<string> hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCountersInternal = hardwareCounters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T AddHardwareCounters<T>(this T toolSettings, params string[] hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCountersInternal.AddRange(hardwareCounters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T AddHardwareCounters<T>(this T toolSettings, IEnumerable<string> hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCountersInternal.AddRange(hardwareCounters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T ClearHardwareCounters<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCountersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T RemoveHardwareCounters<T>(this T toolSettings, params string[] hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(hardwareCounters);
            toolSettings.HardwareCountersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T RemoveHardwareCounters<T>(this T toolSettings, IEnumerable<string> hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(hardwareCounters);
            toolSettings.HardwareCountersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CliPath
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CliPath"/></em></p>
        ///   <p>Path to dotnet CLI (optional).</p>
        /// </summary>
        [Pure]
        public static T SetCliPath<T>(this T toolSettings, string cliPath) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CliPath = cliPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.CliPath"/></em></p>
        ///   <p>Path to dotnet CLI (optional).</p>
        /// </summary>
        [Pure]
        public static T ResetCliPath<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CliPath = null;
            return toolSettings;
        }
        #endregion
        #region RestorePath
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.RestorePath"/></em></p>
        ///   <p>The directory to restore packages to (optional).</p>
        /// </summary>
        [Pure]
        public static T SetRestorePath<T>(this T toolSettings, string restorePath) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RestorePath = restorePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.RestorePath"/></em></p>
        ///   <p>The directory to restore packages to (optional).</p>
        /// </summary>
        [Pure]
        public static T ResetRestorePath<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RestorePath = null;
            return toolSettings;
        }
        #endregion
        #region CoreRunPaths
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CoreRunPaths"/> to a new list</em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T SetCoreRunPaths<T>(this T toolSettings, params string[] coreRunPaths) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunPathsInternal = coreRunPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CoreRunPaths"/> to a new list</em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T SetCoreRunPaths<T>(this T toolSettings, IEnumerable<string> coreRunPaths) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunPathsInternal = coreRunPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T AddCoreRunPaths<T>(this T toolSettings, params string[] coreRunPaths) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunPathsInternal.AddRange(coreRunPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T AddCoreRunPaths<T>(this T toolSettings, IEnumerable<string> coreRunPaths) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunPathsInternal.AddRange(coreRunPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T ClearCoreRunPaths<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T RemoveCoreRunPaths<T>(this T toolSettings, params string[] coreRunPaths) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coreRunPaths);
            toolSettings.CoreRunPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.CoreRunPaths"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T RemoveCoreRunPaths<T>(this T toolSettings, IEnumerable<string> coreRunPaths) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coreRunPaths);
            toolSettings.CoreRunPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region MonoPath
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MonoPath"/></em></p>
        ///   <p>Optional path to Mono which should be used for running benchmarks.</p>
        /// </summary>
        [Pure]
        public static T SetMonoPath<T>(this T toolSettings, string monoPath) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = monoPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MonoPath"/></em></p>
        ///   <p>Optional path to Mono which should be used for running benchmarks.</p>
        /// </summary>
        [Pure]
        public static T ResetMonoPath<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = null;
            return toolSettings;
        }
        #endregion
        #region ClrVersion
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.ClrVersion"/></em></p>
        ///   <p>Optional version of private CLR build used as the value of <c>COMPLUS_Version</c> env var.</p>
        /// </summary>
        [Pure]
        public static T SetClrVersion<T>(this T toolSettings, string clrVersion) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClrVersion = clrVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.ClrVersion"/></em></p>
        ///   <p>Optional version of private CLR build used as the value of <c>COMPLUS_Version</c> env var.</p>
        /// </summary>
        [Pure]
        public static T ResetClrVersion<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClrVersion = null;
            return toolSettings;
        }
        #endregion
        #region CoreRtVersion
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></em></p>
        ///   <p>Optional version of <c>Microsoft.DotNet.ILCompiler</c> which should be used to run with CoreRT. Example: <c>1.0.0-alpha-26414-01</c></p>
        /// </summary>
        [Pure]
        public static T SetCoreRtVersion<T>(this T toolSettings, string coreRtVersion) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRtVersion = coreRtVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></em></p>
        ///   <p>Optional version of <c>Microsoft.DotNet.ILCompiler</c> which should be used to run with CoreRT. Example: <c>1.0.0-alpha-26414-01</c></p>
        /// </summary>
        [Pure]
        public static T ResetCoreRtVersion<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRtVersion = null;
            return toolSettings;
        }
        #endregion
        #region CoreRtPath
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CoreRtPath"/></em></p>
        ///   <p>Optional IlcPath which should be used to run with private CoreRT build.</p>
        /// </summary>
        [Pure]
        public static T SetCoreRtPath<T>(this T toolSettings, string coreRtPath) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRtPath = coreRtPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.CoreRtPath"/></em></p>
        ///   <p>Optional IlcPath which should be used to run with private CoreRT build.</p>
        /// </summary>
        [Pure]
        public static T ResetCoreRtPath<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRtPath = null;
            return toolSettings;
        }
        #endregion
        #region LaunchCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.LaunchCount"/></em></p>
        ///   <p>How many times we should launch process with target benchmark. The default is <c>1</c>.</p>
        /// </summary>
        [Pure]
        public static T SetLaunchCount<T>(this T toolSettings, int? launchCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LaunchCount = launchCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.LaunchCount"/></em></p>
        ///   <p>How many times we should launch process with target benchmark. The default is <c>1</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetLaunchCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LaunchCount = null;
            return toolSettings;
        }
        #endregion
        #region WarmupCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.WarmupCount"/></em></p>
        ///   <p>How many warmup iterations should be performed. If you set it, the <c>minWarmupCount</c> and <c>maxWarmupCount</c> are ignored. By default calculated by the heuristic.</p>
        /// </summary>
        [Pure]
        public static T SetWarmupCount<T>(this T toolSettings, int? warmupCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarmupCount = warmupCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.WarmupCount"/></em></p>
        ///   <p>How many warmup iterations should be performed. If you set it, the <c>minWarmupCount</c> and <c>maxWarmupCount</c> are ignored. By default calculated by the heuristic.</p>
        /// </summary>
        [Pure]
        public static T ResetWarmupCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarmupCount = null;
            return toolSettings;
        }
        #endregion
        #region MinWarmupCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></em></p>
        ///   <p>Minimum count of warmup iterations that should be performed. The default is <c>6</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMinWarmupCount<T>(this T toolSettings, int? minWarmupCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinWarmupCount = minWarmupCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></em></p>
        ///   <p>Minimum count of warmup iterations that should be performed. The default is <c>6</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMinWarmupCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinWarmupCount = null;
            return toolSettings;
        }
        #endregion
        #region MaxWarmupCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></em></p>
        ///   <p>Maximum count of warmup iterations that should be performed. The default is <c>50</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMaxWarmupCount<T>(this T toolSettings, int? maxWarmupCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxWarmupCount = maxWarmupCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></em></p>
        ///   <p>Maximum count of warmup iterations that should be performed. The default is <c>50</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMaxWarmupCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxWarmupCount = null;
            return toolSettings;
        }
        #endregion
        #region IterationTime
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.IterationTime"/></em></p>
        ///   <p>Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. The default is <c>500</c> milliseconds.</p>
        /// </summary>
        [Pure]
        public static T SetIterationTime<T>(this T toolSettings, int? iterationTime) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IterationTime = iterationTime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.IterationTime"/></em></p>
        ///   <p>Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. The default is <c>500</c> milliseconds.</p>
        /// </summary>
        [Pure]
        public static T ResetIterationTime<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IterationTime = null;
            return toolSettings;
        }
        #endregion
        #region IterationCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.IterationCount"/></em></p>
        ///   <p>How many target iterations should be performed. By default calculated by the heuristic.</p>
        /// </summary>
        [Pure]
        public static T SetIterationCount<T>(this T toolSettings, int? iterationCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IterationCount = iterationCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.IterationCount"/></em></p>
        ///   <p>How many target iterations should be performed. By default calculated by the heuristic.</p>
        /// </summary>
        [Pure]
        public static T ResetIterationCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IterationCount = null;
            return toolSettings;
        }
        #endregion
        #region MinIterationCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MinIterationCount"/></em></p>
        ///   <p>Minimum number of iterations to run. The default is <c>15</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMinIterationCount<T>(this T toolSettings, int? minIterationCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinIterationCount = minIterationCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MinIterationCount"/></em></p>
        ///   <p>Minimum number of iterations to run. The default is <c>15</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMinIterationCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinIterationCount = null;
            return toolSettings;
        }
        #endregion
        #region MaxIterationCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></em></p>
        ///   <p>Maximum number of iterations to run. The default is <c>100</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMaxIterationCount<T>(this T toolSettings, int? maxIterationCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxIterationCount = maxIterationCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></em></p>
        ///   <p>Maximum number of iterations to run. The default is <c>100</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMaxIterationCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxIterationCount = null;
            return toolSettings;
        }
        #endregion
        #region InvocationCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.InvocationCount"/></em></p>
        ///   <p>Invocation count in a single iteration. By default calculated by the heuristic.</p>
        /// </summary>
        [Pure]
        public static T SetInvocationCount<T>(this T toolSettings, int? invocationCount) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InvocationCount = invocationCount;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.InvocationCount"/></em></p>
        ///   <p>Invocation count in a single iteration. By default calculated by the heuristic.</p>
        /// </summary>
        [Pure]
        public static T ResetInvocationCount<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InvocationCount = null;
            return toolSettings;
        }
        #endregion
        #region UnrollFactor
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.UnrollFactor"/></em></p>
        ///   <p>How many times the benchmark method will be invoked per one iteration of a generated loop. The default is <c>16</c>.</p>
        /// </summary>
        [Pure]
        public static T SetUnrollFactor<T>(this T toolSettings, int? unrollFactor) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnrollFactor = unrollFactor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.UnrollFactor"/></em></p>
        ///   <p>How many times the benchmark method will be invoked per one iteration of a generated loop. The default is <c>16</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetUnrollFactor<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnrollFactor = null;
            return toolSettings;
        }
        #endregion
        #region RunStrategy
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.RunStrategy"/></em></p>
        ///   <p>The run strategy that should be used. Throughput/ColdStart/Monitoring.</p>
        /// </summary>
        [Pure]
        public static T SetRunStrategy<T>(this T toolSettings, BenchmarkDotNetRunStrategy runStrategy) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunStrategy = runStrategy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.RunStrategy"/></em></p>
        ///   <p>The run strategy that should be used. Throughput/ColdStart/Monitoring.</p>
        /// </summary>
        [Pure]
        public static T ResetRunStrategy<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunStrategy = null;
            return toolSettings;
        }
        #endregion
        #region RunOncePerIteration
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></em></p>
        ///   <p>Run the benchmark exactly once per iteration.</p>
        /// </summary>
        [Pure]
        public static T SetRunOncePerIteration<T>(this T toolSettings, bool? runOncePerIteration) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunOncePerIteration = runOncePerIteration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></em></p>
        ///   <p>Run the benchmark exactly once per iteration.</p>
        /// </summary>
        [Pure]
        public static T ResetRunOncePerIteration<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunOncePerIteration = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></em></p>
        ///   <p>Run the benchmark exactly once per iteration.</p>
        /// </summary>
        [Pure]
        public static T EnableRunOncePerIteration<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunOncePerIteration = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></em></p>
        ///   <p>Run the benchmark exactly once per iteration.</p>
        /// </summary>
        [Pure]
        public static T DisableRunOncePerIteration<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunOncePerIteration = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></em></p>
        ///   <p>Run the benchmark exactly once per iteration.</p>
        /// </summary>
        [Pure]
        public static T ToggleRunOncePerIteration<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunOncePerIteration = !toolSettings.RunOncePerIteration;
            return toolSettings;
        }
        #endregion
        #region PrintInformation
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.PrintInformation"/></em></p>
        ///   <p>Print environment information.</p>
        /// </summary>
        [Pure]
        public static T SetPrintInformation<T>(this T toolSettings, bool? printInformation) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintInformation = printInformation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.PrintInformation"/></em></p>
        ///   <p>Print environment information.</p>
        /// </summary>
        [Pure]
        public static T ResetPrintInformation<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintInformation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.PrintInformation"/></em></p>
        ///   <p>Print environment information.</p>
        /// </summary>
        [Pure]
        public static T EnablePrintInformation<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintInformation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.PrintInformation"/></em></p>
        ///   <p>Print environment information.</p>
        /// </summary>
        [Pure]
        public static T DisablePrintInformation<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintInformation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.PrintInformation"/></em></p>
        ///   <p>Print environment information.</p>
        /// </summary>
        [Pure]
        public static T TogglePrintInformation<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintInformation = !toolSettings.PrintInformation;
            return toolSettings;
        }
        #endregion
        #region ListBenchmarkCaseMode
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></em></p>
        ///   <p>Prints all of the available benchmark names. Flat/Tree</p>
        /// </summary>
        [Pure]
        public static T SetListBenchmarkCaseMode<T>(this T toolSettings, BenchmarkDotNetCaseMode listBenchmarkCaseMode) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListBenchmarkCaseMode = listBenchmarkCaseMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.ListBenchmarkCaseMode"/></em></p>
        ///   <p>Prints all of the available benchmark names. Flat/Tree</p>
        /// </summary>
        [Pure]
        public static T ResetListBenchmarkCaseMode<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListBenchmarkCaseMode = null;
            return toolSettings;
        }
        #endregion
        #region DisassemblyRecursiveDepth
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></em></p>
        ///   <p>Sets the recursive depth for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T SetDisassemblyRecursiveDepth<T>(this T toolSettings, int? disassemblyRecursiveDepth) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyRecursiveDepth = disassemblyRecursiveDepth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisassemblyRecursiveDepth"/></em></p>
        ///   <p>Sets the recursive depth for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T ResetDisassemblyRecursiveDepth<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyRecursiveDepth = null;
            return toolSettings;
        }
        #endregion
        #region DisassemblyDiff
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T SetDisassemblyDiff<T>(this T toolSettings, bool? disassemblyDiff) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyDiff = disassemblyDiff;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T ResetDisassemblyDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyDiff = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T EnableDisassemblyDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyDiff = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T DisableDisassemblyDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyDiff = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.DisassemblyDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisassemblyDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisassemblyDiff = !toolSettings.DisassemblyDiff;
            return toolSettings;
        }
        #endregion
        #region BuildTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.BuildTimeout"/></em></p>
        ///   <p>Build timeout in seconds.</p>
        /// </summary>
        [Pure]
        public static T SetBuildTimeout<T>(this T toolSettings, int? buildTimeout) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildTimeout = buildTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.BuildTimeout"/></em></p>
        ///   <p>Build timeout in seconds.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildTimeout<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildTimeout = null;
            return toolSettings;
        }
        #endregion
        #region StopOnFirstError
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></em></p>
        ///   <p>Stop on first error.</p>
        /// </summary>
        [Pure]
        public static T SetStopOnFirstError<T>(this T toolSettings, bool? stopOnFirstError) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFirstError = stopOnFirstError;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></em></p>
        ///   <p>Stop on first error.</p>
        /// </summary>
        [Pure]
        public static T ResetStopOnFirstError<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFirstError = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></em></p>
        ///   <p>Stop on first error.</p>
        /// </summary>
        [Pure]
        public static T EnableStopOnFirstError<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFirstError = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></em></p>
        ///   <p>Stop on first error.</p>
        /// </summary>
        [Pure]
        public static T DisableStopOnFirstError<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFirstError = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></em></p>
        ///   <p>Stop on first error.</p>
        /// </summary>
        [Pure]
        public static T ToggleStopOnFirstError<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StopOnFirstError = !toolSettings.StopOnFirstError;
            return toolSettings;
        }
        #endregion
        #region StatisticalTestThreshold
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></em></p>
        ///   <p>Threshold for Mann–Whitney U Test. Examples: <c>5%</c>, <c>10ms</c>, <c>100ns</c>, <c>1s</c></p>
        /// </summary>
        [Pure]
        public static T SetStatisticalTestThreshold<T>(this T toolSettings, string statisticalTestThreshold) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StatisticalTestThreshold = statisticalTestThreshold;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.StatisticalTestThreshold"/></em></p>
        ///   <p>Threshold for Mann–Whitney U Test. Examples: <c>5%</c>, <c>10ms</c>, <c>100ns</c>, <c>1s</c></p>
        /// </summary>
        [Pure]
        public static T ResetStatisticalTestThreshold<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StatisticalTestThreshold = null;
            return toolSettings;
        }
        #endregion
        #region DisableLogFile
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisableLogFile"/></em></p>
        ///   <p>Disables the logfile.</p>
        /// </summary>
        [Pure]
        public static T SetDisableLogFile<T>(this T toolSettings, bool? disableLogFile) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableLogFile = disableLogFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisableLogFile"/></em></p>
        ///   <p>Disables the logfile.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableLogFile<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableLogFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.DisableLogFile"/></em></p>
        ///   <p>Disables the logfile.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableLogFile<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableLogFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.DisableLogFile"/></em></p>
        ///   <p>Disables the logfile.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableLogFile<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableLogFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.DisableLogFile"/></em></p>
        ///   <p>Disables the logfile.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableLogFile<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableLogFile = !toolSettings.DisableLogFile;
            return toolSettings;
        }
        #endregion
        #region MaxParameterColumnWidth
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></em></p>
        ///   <p>Max paramter column width, the default is <c>20</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMaxParameterColumnWidth<T>(this T toolSettings, int? maxParameterColumnWidth) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxParameterColumnWidth = maxParameterColumnWidth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MaxParameterColumnWidth"/></em></p>
        ///   <p>Max paramter column width, the default is <c>20</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMaxParameterColumnWidth<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxParameterColumnWidth = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region BenchmarkDotNetJob
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
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
}
