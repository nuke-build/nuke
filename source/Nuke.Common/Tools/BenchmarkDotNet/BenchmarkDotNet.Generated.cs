// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/BenchmarkDotNet.json

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

namespace Nuke.Common.Tools.BenchmarkDotNet
{
    /// <summary>
    ///   <p>Powerful .NET library for benchmarking https://benchmarkdotnet.org/</p>
    ///   <p>For more details, visit the <a href="https://github.com/dotnet/BenchmarkDotNet">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class BenchmarkDotNetTasks
    {
        /// <summary>
        ///   Path to the BenchmarkDotNet executable.
        /// </summary>
        public static string BenchmarkDotNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("BENCHMARKDOTNET_EXE") ??
            ToolPathResolver.GetPackageExecutable("benchmarkdotnet.tool", "BenchmarkDotNet.Tool.dll");
        public static Action<OutputType, string> BenchmarkDotNetLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking https://benchmarkdotnet.org/</p>
        ///   <p>For more details, visit the <a href="https://github.com/dotnet/BenchmarkDotNet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> BenchmarkDotNet(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(BenchmarkDotNetPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, BenchmarkDotNetLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking https://benchmarkdotnet.org/</p>
        ///   <p>For more details, visit the <a href="https://github.com/dotnet/BenchmarkDotNet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li>
        ///     <li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li>
        ///     <li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li>
        ///     <li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></li>
        ///     <li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li>
        ///     <li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsPath"/></li>
        ///     <li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.Attribute"/></li>
        ///     <li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li>
        ///     <li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li>
        ///     <li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li>
        ///     <li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRun"/></li>
        ///     <li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li>
        ///     <li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li>
        ///     <li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disasm"/></li>
        ///     <li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisasmDepth"/></li>
        ///     <li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisasmDiff"/></li>
        ///     <li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li>
        ///     <li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li>
        ///     <li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.IlcPath"/></li>
        ///     <li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li>
        ///     <li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li>
        ///     <li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li>
        ///     <li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li>
        ///     <li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li>
        ///     <li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li>
        ///     <li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepFiles"/></li>
        ///     <li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li>
        ///     <li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li>
        ///     <li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li>
        ///     <li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxWidth"/></li>
        ///     <li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></li>
        ///     <li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li>
        ///     <li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li>
        ///     <li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li>
        ///     <li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.NoOverwrite"/></li>
        ///     <li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.Outliers"/></li>
        ///     <li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.Packages"/></li>
        ///     <li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li>
        ///     <li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li>
        ///     <li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li>
        ///     <li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTest"/></li>
        ///     <li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li>
        ///     <li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.Strategy"/></li>
        ///     <li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></li>
        ///     <li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li>
        ///     <li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> BenchmarkDotNet(BenchmarkDotNetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new BenchmarkDotNetSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking https://benchmarkdotnet.org/</p>
        ///   <p>For more details, visit the <a href="https://github.com/dotnet/BenchmarkDotNet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li>
        ///     <li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li>
        ///     <li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li>
        ///     <li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></li>
        ///     <li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li>
        ///     <li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsPath"/></li>
        ///     <li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.Attribute"/></li>
        ///     <li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li>
        ///     <li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li>
        ///     <li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li>
        ///     <li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRun"/></li>
        ///     <li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li>
        ///     <li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li>
        ///     <li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disasm"/></li>
        ///     <li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisasmDepth"/></li>
        ///     <li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisasmDiff"/></li>
        ///     <li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li>
        ///     <li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li>
        ///     <li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.IlcPath"/></li>
        ///     <li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li>
        ///     <li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li>
        ///     <li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li>
        ///     <li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li>
        ///     <li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li>
        ///     <li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li>
        ///     <li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepFiles"/></li>
        ///     <li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li>
        ///     <li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li>
        ///     <li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li>
        ///     <li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxWidth"/></li>
        ///     <li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></li>
        ///     <li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li>
        ///     <li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li>
        ///     <li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li>
        ///     <li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.NoOverwrite"/></li>
        ///     <li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.Outliers"/></li>
        ///     <li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.Packages"/></li>
        ///     <li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li>
        ///     <li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li>
        ///     <li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li>
        ///     <li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTest"/></li>
        ///     <li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li>
        ///     <li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.Strategy"/></li>
        ///     <li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></li>
        ///     <li><c>--unrollFactor</c> via <see cref="BenchmarkDotNetSettings.UnrollFactor"/></li>
        ///     <li><c>--warmupCount</c> via <see cref="BenchmarkDotNetSettings.WarmupCount"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> BenchmarkDotNet(Configure<BenchmarkDotNetSettings> configurator)
        {
            return BenchmarkDotNet(configurator(new BenchmarkDotNetSettings()));
        }
        /// <summary>
        ///   <p>Powerful .NET library for benchmarking https://benchmarkdotnet.org/</p>
        ///   <p>For more details, visit the <a href="https://github.com/dotnet/BenchmarkDotNet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblyFile&gt;</c> via <see cref="BenchmarkDotNetSettings.AssemblyFile"/></li>
        ///     <li><c>--affinity</c> via <see cref="BenchmarkDotNetSettings.Affinity"/></li>
        ///     <li><c>--allCategories</c> via <see cref="BenchmarkDotNetSettings.AllCategories"/></li>
        ///     <li><c>--allStats</c> via <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></li>
        ///     <li><c>--anyCategories</c> via <see cref="BenchmarkDotNetSettings.AnyCategories"/></li>
        ///     <li><c>--artifacts</c> via <see cref="BenchmarkDotNetSettings.ArtifactsPath"/></li>
        ///     <li><c>--attribute</c> via <see cref="BenchmarkDotNetSettings.Attribute"/></li>
        ///     <li><c>--buildTimeout</c> via <see cref="BenchmarkDotNetSettings.BuildTimeout"/></li>
        ///     <li><c>--clrVersion</c> via <see cref="BenchmarkDotNetSettings.ClrVersion"/></li>
        ///     <li><c>--coreRtVersion</c> via <see cref="BenchmarkDotNetSettings.CoreRtVersion"/></li>
        ///     <li><c>--coreRun</c> via <see cref="BenchmarkDotNetSettings.CoreRun"/></li>
        ///     <li><c>--counters</c> via <see cref="BenchmarkDotNetSettings.HardwareCounters"/></li>
        ///     <li><c>--disableLogFile</c> via <see cref="BenchmarkDotNetSettings.DisableLogFile"/></li>
        ///     <li><c>--disasm</c> via <see cref="BenchmarkDotNetSettings.Disasm"/></li>
        ///     <li><c>--disasmDepth</c> via <see cref="BenchmarkDotNetSettings.DisasmDepth"/></li>
        ///     <li><c>--disasmDiff</c> via <see cref="BenchmarkDotNetSettings.DisasmDiff"/></li>
        ///     <li><c>--exporters</c> via <see cref="BenchmarkDotNetSettings.Exporters"/></li>
        ///     <li><c>--filter</c> via <see cref="BenchmarkDotNetSettings.Filter"/></li>
        ///     <li><c>--ilcPath</c> via <see cref="BenchmarkDotNetSettings.IlcPath"/></li>
        ///     <li><c>--inProcess</c> via <see cref="BenchmarkDotNetSettings.RunInProcess"/></li>
        ///     <li><c>--invocationCount</c> via <see cref="BenchmarkDotNetSettings.InvocationCount"/></li>
        ///     <li><c>--iterationCount</c> via <see cref="BenchmarkDotNetSettings.IterationCount"/></li>
        ///     <li><c>--iterationTime</c> via <see cref="BenchmarkDotNetSettings.IterationTime"/></li>
        ///     <li><c>--job</c> via <see cref="BenchmarkDotNetSettings.Job"/></li>
        ///     <li><c>--join</c> via <see cref="BenchmarkDotNetSettings.Join"/></li>
        ///     <li><c>--keepFiles</c> via <see cref="BenchmarkDotNetSettings.KeepFiles"/></li>
        ///     <li><c>--launchCount</c> via <see cref="BenchmarkDotNetSettings.LaunchCount"/></li>
        ///     <li><c>--maxIterationCount</c> via <see cref="BenchmarkDotNetSettings.MaxIterationCount"/></li>
        ///     <li><c>--maxWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MaxWarmupCount"/></li>
        ///     <li><c>--maxWidth</c> via <see cref="BenchmarkDotNetSettings.MaxWidth"/></li>
        ///     <li><c>--memory</c> via <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></li>
        ///     <li><c>--minIterationCount</c> via <see cref="BenchmarkDotNetSettings.MinIterationCount"/></li>
        ///     <li><c>--minWarmupCount</c> via <see cref="BenchmarkDotNetSettings.MinWarmupCount"/></li>
        ///     <li><c>--monoPath</c> via <see cref="BenchmarkDotNetSettings.MonoPath"/></li>
        ///     <li><c>--noOverwrite</c> via <see cref="BenchmarkDotNetSettings.NoOverwrite"/></li>
        ///     <li><c>--outliers</c> via <see cref="BenchmarkDotNetSettings.Outliers"/></li>
        ///     <li><c>--packages</c> via <see cref="BenchmarkDotNetSettings.Packages"/></li>
        ///     <li><c>--profiler</c> via <see cref="BenchmarkDotNetSettings.Profiler"/></li>
        ///     <li><c>--runOncePerIteration</c> via <see cref="BenchmarkDotNetSettings.RunOncePerIteration"/></li>
        ///     <li><c>--runtimes</c> via <see cref="BenchmarkDotNetSettings.Runtimes"/></li>
        ///     <li><c>--statisticalTest</c> via <see cref="BenchmarkDotNetSettings.StatisticalTest"/></li>
        ///     <li><c>--stopOnFirstError</c> via <see cref="BenchmarkDotNetSettings.StopOnFirstError"/></li>
        ///     <li><c>--strategy</c> via <see cref="BenchmarkDotNetSettings.Strategy"/></li>
        ///     <li><c>--threading</c> via <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></li>
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
        public override string ToolPath => base.ToolPath ?? BenchmarkDotNetTasks.BenchmarkDotNetPath;
        public override Action<OutputType, string> CustomLogger => BenchmarkDotNetTasks.BenchmarkDotNetLogger;
        /// <summary>
        ///   The assembly with the benchmarks (required).
        /// </summary>
        public virtual string AssemblyFile { get; internal set; }
        /// <summary>
        ///   Dry/Short/Medium/Long or Default
        /// </summary>
        public virtual Job Job { get; internal set; } = Job.Default;
        /// <summary>
        ///   The assembly with the benchmarks (required).
        /// </summary>
        public virtual IReadOnlyList<string> Runtimes => RuntimesInternal.AsReadOnly();
        internal List<string> RuntimesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML
        /// </summary>
        public virtual IReadOnlyList<Exporter> Exporters => ExportersInternal.AsReadOnly();
        internal List<Exporter> ExportersInternal { get; set; } = new List<Exporter>();
        /// <summary>
        ///   Prints memory statistics
        /// </summary>
        public virtual bool? PrintMemoryStats { get; internal set; } = false;
        /// <summary>
        ///   Prints threading statistics
        /// </summary>
        public virtual bool? PrintThreadingStats { get; internal set; } = false;
        /// <summary>
        ///   Gets disassembly of benchmarked code
        /// </summary>
        public virtual bool? Disasm { get; internal set; } = false;
        /// <summary>
        ///   Profiles benchmarked code using selected profiler. Currently the only available is "ETW" for Windows.
        /// </summary>
        public virtual string Profiler { get; internal set; }
        /// <summary>
        ///   Glob patterns, e.g. *, '*.ClassA.*' '*.ClassB.*'
        /// </summary>
        public virtual string Filter { get; internal set; }
        /// <summary>
        ///   Run benchmarks in Process
        /// </summary>
        public virtual bool? RunInProcess { get; internal set; } = false;
        /// <summary>
        ///   Valid path to accessible directory
        /// </summary>
        public virtual string ArtifactsPath { get; internal set; }
        /// <summary>
        ///   DontRemove/RemoveUpper/RemoveLower/RemoveAll
        /// </summary>
        public virtual OutlierRemoval Outliers { get; internal set; } = OutlierRemoval.RemoveUpper;
        /// <summary>
        ///   Affinity mask to set for the benchmark process
        /// </summary>
        public virtual string Affinity { get; internal set; }
        /// <summary>
        ///   Displays all statistics (min, max &amp; more)
        /// </summary>
        public virtual bool? DisplayAllStats { get; internal set; } = false;
        /// <summary>
        ///   Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed
        /// </summary>
        public virtual bool? AllCategories { get; internal set; }
        /// <summary>
        ///   Any Categories to run
        /// </summary>
        public virtual bool? AnyCategories { get; internal set; }
        /// <summary>
        ///   Run all methods with given attribute (applied to class or method)
        /// </summary>
        public virtual bool? Attribute { get; internal set; }
        /// <summary>
        ///   Prints single table with results for all benchmarks
        /// </summary>
        public virtual bool? Join { get; internal set; } = false;
        /// <summary>
        ///   Determines if all auto-generated files should be kept or removed after running the benchmarks.
        /// </summary>
        public virtual bool? KeepFiles { get; internal set; }
        /// <summary>
        ///   Determines if the exported result files should not be overwritten (be default they are overwritten).
        /// </summary>
        public virtual bool? NoOverwrite { get; internal set; }
        /// <summary>
        ///   Hardware Counters
        /// </summary>
        public virtual bool? HardwareCounters { get; internal set; }
        /// <summary>
        ///   The directory to restore packages to (optional).
        /// </summary>
        public virtual string Packages { get; internal set; }
        /// <summary>
        ///   Path(s) to CoreRun (optional).
        /// </summary>
        public virtual IReadOnlyList<string> CoreRun => CoreRunInternal.AsReadOnly();
        internal List<string> CoreRunInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Optional path to Mono which should be used for running benchmarks.
        /// </summary>
        public virtual string MonoPath { get; internal set; }
        /// <summary>
        ///   Optional version of private CLR build used as the value of COMPLUS_Version env var.
        /// </summary>
        public virtual string ClrVersion { get; internal set; }
        /// <summary>
        ///   Optional version of Microsoft.DotNet.ILCompiler which should be used to run with CoreRT. Example: "1.0.0-alpha-26414-01"
        /// </summary>
        public virtual string CoreRtVersion { get; internal set; }
        /// <summary>
        ///   Optional IlcPath which should be used to run with private CoreRT build.
        /// </summary>
        public virtual string IlcPath { get; internal set; }
        /// <summary>
        ///   How many times we should launch process with target benchmark. The default is 1.
        /// </summary>
        public virtual int? LaunchCount { get; internal set; } = 1;
        /// <summary>
        ///   How many warmup iterations should be performed. If you set it, the minWarmupCount and maxWarmupCount are ignored. By default calculated by the heuristic.
        /// </summary>
        public virtual int? WarmupCount { get; internal set; }
        /// <summary>
        ///   Minimum count of warmup iterations that should be performed. The default is 6.
        /// </summary>
        public virtual int? MinWarmupCount { get; internal set; } = 6;
        /// <summary>
        ///   Maximum count of warmup iterations that should be performed. The default is 50.
        /// </summary>
        public virtual int? MaxWarmupCount { get; internal set; } = 50;
        /// <summary>
        ///   Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. 500ms by default
        /// </summary>
        public virtual string IterationTime { get; internal set; }
        /// <summary>
        ///   How many target iterations should be performed. By default calculated by the heuristic.
        /// </summary>
        public virtual int? IterationCount { get; internal set; }
        /// <summary>
        ///   Minimum number of iterations to run. The default is 15.
        /// </summary>
        public virtual int? MinIterationCount { get; internal set; } = 15;
        /// <summary>
        ///   Maximum number of iterations to run. The default is 100.
        /// </summary>
        public virtual int? MaxIterationCount { get; internal set; } = 15;
        /// <summary>
        ///   Invocation count in a single iteration. By default calculated by the heuristic.
        /// </summary>
        public virtual int? InvocationCount { get; internal set; }
        /// <summary>
        ///   How many times the benchmark method will be invoked per one iteration of a generated loop. 16 by default
        /// </summary>
        public virtual int? UnrollFactor { get; internal set; } = 16;
        /// <summary>
        ///   The RunStrategy that should be used. Throughput/ColdStart/Monitoring.
        /// </summary>
        public virtual RunStrategy Strategy { get; internal set; }
        /// <summary>
        ///   Run the benchmark exactly once per iteration.
        /// </summary>
        public virtual bool? RunOncePerIteration { get; internal set; } = false;
        /// <summary>
        ///   Sets the recursive depth for the disassembler.
        /// </summary>
        public virtual int? DisasmDepth { get; internal set; } = 1;
        /// <summary>
        ///   Generates diff reports for the disassembler.
        /// </summary>
        public virtual bool? DisasmDiff { get; internal set; } = false;
        /// <summary>
        ///   Build timeout in seconds.
        /// </summary>
        public virtual int? BuildTimeout { get; internal set; }
        /// <summary>
        ///   Stop on first error.
        /// </summary>
        public virtual bool? StopOnFirstError { get; internal set; } = false;
        /// <summary>
        ///   Threshold for Mann–Whitney U Test. Examples: 5%, 10ms, 100ns, 1s
        /// </summary>
        public virtual string StatisticalTest { get; internal set; }
        /// <summary>
        ///   Disables the logfile.
        /// </summary>
        public virtual bool? DisableLogFile { get; internal set; }
        /// <summary>
        ///   Max paramter column width, the default is 20.
        /// </summary>
        public virtual int? MaxWidth { get; internal set; } = 20;
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", AssemblyFile)
              .Add("--job {value}", Job)
              .Add("--runtimes {value}", Runtimes, separator: ' ', quoteMultiple: true)
              .Add("--exporters {value}", Exporters, separator: ' ', quoteMultiple: true)
              .Add("--memory {value}", PrintMemoryStats)
              .Add("--threading {value}", PrintThreadingStats)
              .Add("--disasm {value}", Disasm)
              .Add("--profiler {value}", Profiler)
              .Add("--filter {value}", Filter)
              .Add("--inProcess {value}", RunInProcess)
              .Add("--artifacts {value}", ArtifactsPath)
              .Add("--outliers {value}", Outliers)
              .Add("--affinity {value}", Affinity)
              .Add("--allStats {value}", DisplayAllStats)
              .Add("--allCategories {value}", AllCategories)
              .Add("--anyCategories {value}", AnyCategories)
              .Add("--attribute {value}", Attribute)
              .Add("--join {value}", Join)
              .Add("--keepFiles {value}", KeepFiles)
              .Add("--noOverwrite {value}", NoOverwrite)
              .Add("--counters {value}", HardwareCounters)
              .Add("--packages {value}", Packages)
              .Add("--coreRun {value}", CoreRun, separator: ' ', quoteMultiple: true)
              .Add("--monoPath {value}", MonoPath)
              .Add("--clrVersion {value}", ClrVersion)
              .Add("--coreRtVersion {value}", CoreRtVersion)
              .Add("--ilcPath {value}", IlcPath)
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
              .Add("--strategy {value}", Strategy)
              .Add("--runOncePerIteration {value}", RunOncePerIteration)
              .Add("--disasmDepth {value}", DisasmDepth)
              .Add("--disasmDiff {value}", DisasmDiff)
              .Add("--buildTimeout {value}", BuildTimeout)
              .Add("--stopOnFirstError {value}", StopOnFirstError)
              .Add("--statisticalTest {value}", StatisticalTest)
              .Add("--disableLogFile {value}", DisableLogFile)
              .Add("--maxWidth {value}", MaxWidth);
            return base.ConfigureArguments(arguments);
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
        public static T SetJob<T>(this T toolSettings, Job job) where T : BenchmarkDotNetSettings
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        ///   <p>The assembly with the benchmarks (required).</p>
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
        public static T SetExporters<T>(this T toolSettings, params Exporter[] exporters) where T : BenchmarkDotNetSettings
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
        public static T SetExporters<T>(this T toolSettings, IEnumerable<Exporter> exporters) where T : BenchmarkDotNetSettings
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
        public static T AddExporters<T>(this T toolSettings, params Exporter[] exporters) where T : BenchmarkDotNetSettings
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
        public static T AddExporters<T>(this T toolSettings, IEnumerable<Exporter> exporters) where T : BenchmarkDotNetSettings
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
        public static T RemoveExporters<T>(this T toolSettings, params Exporter[] exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<Exporter>(exporters);
            toolSettings.ExportersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.Exporters"/></em></p>
        ///   <p>GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML</p>
        /// </summary>
        [Pure]
        public static T RemoveExporters<T>(this T toolSettings, IEnumerable<Exporter> exporters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<Exporter>(exporters);
            toolSettings.ExportersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PrintMemoryStats
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T SetPrintMemoryStats<T>(this T toolSettings, bool? printMemoryStats) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintMemoryStats = printMemoryStats;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T ResetPrintMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintMemoryStats = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T EnablePrintMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintMemoryStats = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T DisablePrintMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintMemoryStats = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.PrintMemoryStats"/></em></p>
        ///   <p>Prints memory statistics</p>
        /// </summary>
        [Pure]
        public static T TogglePrintMemoryStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintMemoryStats = !toolSettings.PrintMemoryStats;
            return toolSettings;
        }
        #endregion
        #region PrintThreadingStats
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T SetPrintThreadingStats<T>(this T toolSettings, bool? printThreadingStats) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintThreadingStats = printThreadingStats;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T ResetPrintThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintThreadingStats = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T EnablePrintThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintThreadingStats = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T DisablePrintThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintThreadingStats = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.PrintThreadingStats"/></em></p>
        ///   <p>Prints threading statistics</p>
        /// </summary>
        [Pure]
        public static T TogglePrintThreadingStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintThreadingStats = !toolSettings.PrintThreadingStats;
            return toolSettings;
        }
        #endregion
        #region Disasm
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Disasm"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T SetDisasm<T>(this T toolSettings, bool? disasm) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disasm = disasm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Disasm"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T ResetDisasm<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disasm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.Disasm"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T EnableDisasm<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disasm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.Disasm"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T DisableDisasm<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disasm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.Disasm"/></em></p>
        ///   <p>Gets disassembly of benchmarked code</p>
        /// </summary>
        [Pure]
        public static T ToggleDisasm<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disasm = !toolSettings.Disasm;
            return toolSettings;
        }
        #endregion
        #region Profiler
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Profiler"/></em></p>
        ///   <p>Profiles benchmarked code using selected profiler. Currently the only available is "ETW" for Windows.</p>
        /// </summary>
        [Pure]
        public static T SetProfiler<T>(this T toolSettings, string profiler) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profiler = profiler;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Profiler"/></em></p>
        ///   <p>Profiles benchmarked code using selected profiler. Currently the only available is "ETW" for Windows.</p>
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
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. *, '*.ClassA.*' '*.ClassB.*'</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, string filter) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Filter"/></em></p>
        ///   <p>Glob patterns, e.g. *, '*.ClassA.*' '*.ClassB.*'</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
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
        #region ArtifactsPath
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.ArtifactsPath"/></em></p>
        ///   <p>Valid path to accessible directory</p>
        /// </summary>
        [Pure]
        public static T SetArtifactsPath<T>(this T toolSettings, string artifactsPath) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArtifactsPath = artifactsPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.ArtifactsPath"/></em></p>
        ///   <p>Valid path to accessible directory</p>
        /// </summary>
        [Pure]
        public static T ResetArtifactsPath<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArtifactsPath = null;
            return toolSettings;
        }
        #endregion
        #region Outliers
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Outliers"/></em></p>
        ///   <p>DontRemove/RemoveUpper/RemoveLower/RemoveAll</p>
        /// </summary>
        [Pure]
        public static T SetOutliers<T>(this T toolSettings, OutlierRemoval outliers) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Outliers = outliers;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Outliers"/></em></p>
        ///   <p>DontRemove/RemoveUpper/RemoveLower/RemoveAll</p>
        /// </summary>
        [Pure]
        public static T ResetOutliers<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Outliers = null;
            return toolSettings;
        }
        #endregion
        #region Affinity
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Affinity"/></em></p>
        ///   <p>Affinity mask to set for the benchmark process</p>
        /// </summary>
        [Pure]
        public static T SetAffinity<T>(this T toolSettings, string affinity) where T : BenchmarkDotNetSettings
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
        #region DisplayAllStats
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T SetDisplayAllStats<T>(this T toolSettings, bool? displayAllStats) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStats = displayAllStats;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T ResetDisplayAllStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStats = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T EnableDisplayAllStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStats = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T DisableDisplayAllStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStats = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.DisplayAllStats"/></em></p>
        ///   <p>Displays all statistics (min, max &amp; more)</p>
        /// </summary>
        [Pure]
        public static T ToggleDisplayAllStats<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisplayAllStats = !toolSettings.DisplayAllStats;
            return toolSettings;
        }
        #endregion
        #region AllCategories
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T SetAllCategories<T>(this T toolSettings, bool? allCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategories = allCategories;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T ResetAllCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategories = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T EnableAllCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategories = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T DisableAllCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategories = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.AllCategories"/></em></p>
        ///   <p>Categories to run. If few are provided, only the benchmarks which belong to all of them are going to be executed</p>
        /// </summary>
        [Pure]
        public static T ToggleAllCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllCategories = !toolSettings.AllCategories;
            return toolSettings;
        }
        #endregion
        #region AnyCategories
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T SetAnyCategories<T>(this T toolSettings, bool? anyCategories) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategories = anyCategories;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T ResetAnyCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategories = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T EnableAnyCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategories = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T DisableAnyCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategories = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.AnyCategories"/></em></p>
        ///   <p>Any Categories to run</p>
        /// </summary>
        [Pure]
        public static T ToggleAnyCategories<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AnyCategories = !toolSettings.AnyCategories;
            return toolSettings;
        }
        #endregion
        #region Attribute
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Attribute"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T SetAttribute<T>(this T toolSettings, bool? attribute) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attribute = attribute;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Attribute"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T ResetAttribute<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attribute = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.Attribute"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T EnableAttribute<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attribute = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.Attribute"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T DisableAttribute<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attribute = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.Attribute"/></em></p>
        ///   <p>Run all methods with given attribute (applied to class or method)</p>
        /// </summary>
        [Pure]
        public static T ToggleAttribute<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attribute = !toolSettings.Attribute;
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
        #region KeepFiles
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.KeepFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T SetKeepFiles<T>(this T toolSettings, bool? keepFiles) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFiles = keepFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.KeepFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T ResetKeepFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.KeepFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T EnableKeepFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.KeepFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T DisableKeepFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.KeepFiles"/></em></p>
        ///   <p>Determines if all auto-generated files should be kept or removed after running the benchmarks.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeepFiles<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFiles = !toolSettings.KeepFiles;
            return toolSettings;
        }
        #endregion
        #region NoOverwrite
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.NoOverwrite"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (be default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T SetNoOverwrite<T>(this T toolSettings, bool? noOverwrite) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOverwrite = noOverwrite;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.NoOverwrite"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (be default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T ResetNoOverwrite<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOverwrite = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.NoOverwrite"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (be default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T EnableNoOverwrite<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOverwrite = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.NoOverwrite"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (be default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T DisableNoOverwrite<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOverwrite = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.NoOverwrite"/></em></p>
        ///   <p>Determines if the exported result files should not be overwritten (be default they are overwritten).</p>
        /// </summary>
        [Pure]
        public static T ToggleNoOverwrite<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOverwrite = !toolSettings.NoOverwrite;
            return toolSettings;
        }
        #endregion
        #region HardwareCounters
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T SetHardwareCounters<T>(this T toolSettings, bool? hardwareCounters) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCounters = hardwareCounters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T ResetHardwareCounters<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCounters = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T EnableHardwareCounters<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCounters = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T DisableHardwareCounters<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCounters = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.HardwareCounters"/></em></p>
        ///   <p>Hardware Counters</p>
        /// </summary>
        [Pure]
        public static T ToggleHardwareCounters<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HardwareCounters = !toolSettings.HardwareCounters;
            return toolSettings;
        }
        #endregion
        #region Packages
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Packages"/></em></p>
        ///   <p>The directory to restore packages to (optional).</p>
        /// </summary>
        [Pure]
        public static T SetPackages<T>(this T toolSettings, string packages) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Packages = packages;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Packages"/></em></p>
        ///   <p>The directory to restore packages to (optional).</p>
        /// </summary>
        [Pure]
        public static T ResetPackages<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Packages = null;
            return toolSettings;
        }
        #endregion
        #region CoreRun
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CoreRun"/> to a new list</em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T SetCoreRun<T>(this T toolSettings, params string[] coreRun) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunInternal = coreRun.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.CoreRun"/> to a new list</em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T SetCoreRun<T>(this T toolSettings, IEnumerable<string> coreRun) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunInternal = coreRun.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.CoreRun"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T AddCoreRun<T>(this T toolSettings, params string[] coreRun) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunInternal.AddRange(coreRun);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="BenchmarkDotNetSettings.CoreRun"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T AddCoreRun<T>(this T toolSettings, IEnumerable<string> coreRun) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunInternal.AddRange(coreRun);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="BenchmarkDotNetSettings.CoreRun"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T ClearCoreRun<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRunInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.CoreRun"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T RemoveCoreRun<T>(this T toolSettings, params string[] coreRun) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coreRun);
            toolSettings.CoreRunInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="BenchmarkDotNetSettings.CoreRun"/></em></p>
        ///   <p>Path(s) to CoreRun (optional).</p>
        /// </summary>
        [Pure]
        public static T RemoveCoreRun<T>(this T toolSettings, IEnumerable<string> coreRun) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coreRun);
            toolSettings.CoreRunInternal.RemoveAll(x => hashSet.Contains(x));
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
        ///   <p>Optional version of private CLR build used as the value of COMPLUS_Version env var.</p>
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
        ///   <p>Optional version of private CLR build used as the value of COMPLUS_Version env var.</p>
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
        ///   <p>Optional version of Microsoft.DotNet.ILCompiler which should be used to run with CoreRT. Example: "1.0.0-alpha-26414-01"</p>
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
        ///   <p>Optional version of Microsoft.DotNet.ILCompiler which should be used to run with CoreRT. Example: "1.0.0-alpha-26414-01"</p>
        /// </summary>
        [Pure]
        public static T ResetCoreRtVersion<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoreRtVersion = null;
            return toolSettings;
        }
        #endregion
        #region IlcPath
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.IlcPath"/></em></p>
        ///   <p>Optional IlcPath which should be used to run with private CoreRT build.</p>
        /// </summary>
        [Pure]
        public static T SetIlcPath<T>(this T toolSettings, string ilcPath) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IlcPath = ilcPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.IlcPath"/></em></p>
        ///   <p>Optional IlcPath which should be used to run with private CoreRT build.</p>
        /// </summary>
        [Pure]
        public static T ResetIlcPath<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IlcPath = null;
            return toolSettings;
        }
        #endregion
        #region LaunchCount
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.LaunchCount"/></em></p>
        ///   <p>How many times we should launch process with target benchmark. The default is 1.</p>
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
        ///   <p>How many times we should launch process with target benchmark. The default is 1.</p>
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
        ///   <p>How many warmup iterations should be performed. If you set it, the minWarmupCount and maxWarmupCount are ignored. By default calculated by the heuristic.</p>
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
        ///   <p>How many warmup iterations should be performed. If you set it, the minWarmupCount and maxWarmupCount are ignored. By default calculated by the heuristic.</p>
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
        ///   <p>Minimum count of warmup iterations that should be performed. The default is 6.</p>
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
        ///   <p>Minimum count of warmup iterations that should be performed. The default is 6.</p>
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
        ///   <p>Maximum count of warmup iterations that should be performed. The default is 50.</p>
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
        ///   <p>Maximum count of warmup iterations that should be performed. The default is 50.</p>
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
        ///   <p>Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. 500ms by default</p>
        /// </summary>
        [Pure]
        public static T SetIterationTime<T>(this T toolSettings, string iterationTime) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IterationTime = iterationTime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.IterationTime"/></em></p>
        ///   <p>Desired time of execution of an iteration in milliseconds. Used by Pilot stage to estimate the number of invocations per iteration. 500ms by default</p>
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
        ///   <p>Minimum number of iterations to run. The default is 15.</p>
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
        ///   <p>Minimum number of iterations to run. The default is 15.</p>
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
        ///   <p>Maximum number of iterations to run. The default is 100.</p>
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
        ///   <p>Maximum number of iterations to run. The default is 100.</p>
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
        ///   <p>How many times the benchmark method will be invoked per one iteration of a generated loop. 16 by default</p>
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
        ///   <p>How many times the benchmark method will be invoked per one iteration of a generated loop. 16 by default</p>
        /// </summary>
        [Pure]
        public static T ResetUnrollFactor<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnrollFactor = null;
            return toolSettings;
        }
        #endregion
        #region Strategy
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.Strategy"/></em></p>
        ///   <p>The RunStrategy that should be used. Throughput/ColdStart/Monitoring.</p>
        /// </summary>
        [Pure]
        public static T SetStrategy<T>(this T toolSettings, RunStrategy strategy) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strategy = strategy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.Strategy"/></em></p>
        ///   <p>The RunStrategy that should be used. Throughput/ColdStart/Monitoring.</p>
        /// </summary>
        [Pure]
        public static T ResetStrategy<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strategy = null;
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
        #region DisasmDepth
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisasmDepth"/></em></p>
        ///   <p>Sets the recursive depth for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T SetDisasmDepth<T>(this T toolSettings, int? disasmDepth) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDepth = disasmDepth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisasmDepth"/></em></p>
        ///   <p>Sets the recursive depth for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T ResetDisasmDepth<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDepth = null;
            return toolSettings;
        }
        #endregion
        #region DisasmDiff
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.DisasmDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T SetDisasmDiff<T>(this T toolSettings, bool? disasmDiff) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDiff = disasmDiff;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.DisasmDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T ResetDisasmDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDiff = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BenchmarkDotNetSettings.DisasmDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T EnableDisasmDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDiff = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BenchmarkDotNetSettings.DisasmDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T DisableDisasmDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDiff = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BenchmarkDotNetSettings.DisasmDiff"/></em></p>
        ///   <p>Generates diff reports for the disassembler.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisasmDiff<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisasmDiff = !toolSettings.DisasmDiff;
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
        #region StatisticalTest
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.StatisticalTest"/></em></p>
        ///   <p>Threshold for Mann–Whitney U Test. Examples: 5%, 10ms, 100ns, 1s</p>
        /// </summary>
        [Pure]
        public static T SetStatisticalTest<T>(this T toolSettings, string statisticalTest) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StatisticalTest = statisticalTest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.StatisticalTest"/></em></p>
        ///   <p>Threshold for Mann–Whitney U Test. Examples: 5%, 10ms, 100ns, 1s</p>
        /// </summary>
        [Pure]
        public static T ResetStatisticalTest<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StatisticalTest = null;
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
        #region MaxWidth
        /// <summary>
        ///   <p><em>Sets <see cref="BenchmarkDotNetSettings.MaxWidth"/></em></p>
        ///   <p>Max paramter column width, the default is 20.</p>
        /// </summary>
        [Pure]
        public static T SetMaxWidth<T>(this T toolSettings, int? maxWidth) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxWidth = maxWidth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BenchmarkDotNetSettings.MaxWidth"/></em></p>
        ///   <p>Max paramter column width, the default is 20.</p>
        /// </summary>
        [Pure]
        public static T ResetMaxWidth<T>(this T toolSettings) where T : BenchmarkDotNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxWidth = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region Job
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Job>))]
    public partial class Job : Enumeration
    {
        public static Job Dry = (Job) "Dry";
        public static Job Short = (Job) "Short";
        public static Job Medium = (Job) "Medium";
        public static Job Long = (Job) "Long";
        public static Job Default = (Job) "Default";
        public static explicit operator Job(string value)
        {
            return new Job { Value = value };
        }
    }
    #endregion
    #region OutlierRemoval
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<OutlierRemoval>))]
    public partial class OutlierRemoval : Enumeration
    {
        public static OutlierRemoval DontRemove = (OutlierRemoval) "DontRemove";
        public static OutlierRemoval RemoveUpper = (OutlierRemoval) "RemoveUpper";
        public static OutlierRemoval RemoveLower = (OutlierRemoval) "RemoveLower";
        public static OutlierRemoval RemoveAll = (OutlierRemoval) "RemoveAll";
        public static explicit operator OutlierRemoval(string value)
        {
            return new OutlierRemoval { Value = value };
        }
    }
    #endregion
    #region Exporter
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Exporter>))]
    public partial class Exporter : Enumeration
    {
        public static Exporter GitHub = (Exporter) "GitHub";
        public static Exporter StackOverflow = (Exporter) "StackOverflow";
        public static Exporter RPlot = (Exporter) "RPlot";
        public static Exporter CSV = (Exporter) "CSV";
        public static Exporter JSON = (Exporter) "JSON";
        public static Exporter HTML = (Exporter) "HTML";
        public static Exporter XML = (Exporter) "XML";
        public static explicit operator Exporter(string value)
        {
            return new Exporter { Value = value };
        }
    }
    #endregion
    #region RunStrategy
    /// <summary>
    ///   Used within <see cref="BenchmarkDotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<RunStrategy>))]
    public partial class RunStrategy : Enumeration
    {
        public static RunStrategy Throughput = (RunStrategy) "Throughput";
        public static RunStrategy ColdStart = (RunStrategy) "ColdStart";
        public static RunStrategy Monitoring = (RunStrategy) "Monitoring";
        public static explicit operator RunStrategy(string value)
        {
            return new RunStrategy { Value = value };
        }
    }
    #endregion
}
