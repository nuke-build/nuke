// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/CodeMetrics/CodeMetrics.json

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

namespace Nuke.Common.Tools.CodeMetrics
{
    /// <summary>
    ///   <p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(CodeMetricsPackageId)]
    public partial class CodeMetricsTasks
        : IRequireNuGetPackage
    {
        public const string CodeMetricsPackageId = "Microsoft.CodeAnalysis.Metrics";
        /// <summary>
        ///   Path to the CodeMetrics executable.
        /// </summary>
        public static string CodeMetricsPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CODEMETRICS_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("Microsoft.CodeAnalysis.Metrics", "Metrics.exe");
        public static Action<OutputType, string> CodeMetricsLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> CodeMetrics(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(CodeMetricsPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? CodeMetricsLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/out</c> via <see cref="CodeMetricsSettings.OutputFile"/></li>
        ///     <li><c>/project</c> via <see cref="CodeMetricsSettings.Project"/></li>
        ///     <li><c>/solution</c> via <see cref="CodeMetricsSettings.Solution"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CodeMetrics(CodeMetricsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CodeMetricsSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/out</c> via <see cref="CodeMetricsSettings.OutputFile"/></li>
        ///     <li><c>/project</c> via <see cref="CodeMetricsSettings.Project"/></li>
        ///     <li><c>/solution</c> via <see cref="CodeMetricsSettings.Solution"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CodeMetrics(Configure<CodeMetricsSettings> configurator)
        {
            return CodeMetrics(configurator(new CodeMetricsSettings()));
        }
        /// <summary>
        ///   <p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/out</c> via <see cref="CodeMetricsSettings.OutputFile"/></li>
        ///     <li><c>/project</c> via <see cref="CodeMetricsSettings.Project"/></li>
        ///     <li><c>/solution</c> via <see cref="CodeMetricsSettings.Solution"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CodeMetricsSettings Settings, IReadOnlyCollection<Output> Output)> CodeMetrics(CombinatorialConfigure<CodeMetricsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CodeMetrics, CodeMetricsLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CodeMetricsSettings
    /// <summary>
    ///   Used within <see cref="CodeMetricsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CodeMetricsSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CodeMetrics executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? CodeMetricsTasks.CodeMetricsPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? CodeMetricsTasks.CodeMetricsLogger;
        /// <summary>
        ///   Project to analyze.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Solution to analyze.
        /// </summary>
        public virtual string Solution { get; internal set; }
        /// <summary>
        ///   Metrics results XML output file.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("/project:{value}", Project)
              .Add("/solution:{value}", Solution)
              .Add("/out:{value}", OutputFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region CodeMetricsSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CodeMetricsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CodeMetricsSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="CodeMetricsSettings.Project"/></em></p>
        ///   <p>Project to analyze.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : CodeMetricsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodeMetricsSettings.Project"/></em></p>
        ///   <p>Project to analyze.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : CodeMetricsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Solution
        /// <summary>
        ///   <p><em>Sets <see cref="CodeMetricsSettings.Solution"/></em></p>
        ///   <p>Solution to analyze.</p>
        /// </summary>
        [Pure]
        public static T SetSolution<T>(this T toolSettings, string solution) where T : CodeMetricsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Solution = solution;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodeMetricsSettings.Solution"/></em></p>
        ///   <p>Solution to analyze.</p>
        /// </summary>
        [Pure]
        public static T ResetSolution<T>(this T toolSettings) where T : CodeMetricsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Solution = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="CodeMetricsSettings.OutputFile"/></em></p>
        ///   <p>Metrics results XML output file.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : CodeMetricsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodeMetricsSettings.OutputFile"/></em></p>
        ///   <p>Metrics results XML output file.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : CodeMetricsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
