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

namespace Nuke.Common.Tools.CodeMetrics;

/// <summary><p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class CodeMetricsTasks : ToolTasks, IRequireNuGetPackage
{
    public static string CodeMetricsPath => new CodeMetricsTasks().GetToolPath();
    public const string PackageId = "Microsoft.CodeAnalysis.Metrics";
    public const string PackageExecutable = "Metrics.exe";
    /// <summary><p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> CodeMetrics(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new CodeMetricsTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/out</c> via <see cref="CodeMetricsSettings.OutputFile"/></li><li><c>/project</c> via <see cref="CodeMetricsSettings.Project"/></li><li><c>/solution</c> via <see cref="CodeMetricsSettings.Solution"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> CodeMetrics(CodeMetricsSettings options = null) => new CodeMetricsTasks().Run(options);
    /// <summary><p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/out</c> via <see cref="CodeMetricsSettings.OutputFile"/></li><li><c>/project</c> via <see cref="CodeMetricsSettings.Project"/></li><li><c>/solution</c> via <see cref="CodeMetricsSettings.Solution"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> CodeMetrics(Configure<CodeMetricsSettings> configurator) => new CodeMetricsTasks().Run(configurator.Invoke(new CodeMetricsSettings()));
    /// <summary><p>Code metrics is a set of software measures that provide developers better insight into the code they are developing. By taking advantage of code metrics, developers can understand which types and/or methods should be reworked or more thoroughly tested. Development teams can identify potential risks, understand the current state of a project, and track progress during software development.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/out</c> via <see cref="CodeMetricsSettings.OutputFile"/></li><li><c>/project</c> via <see cref="CodeMetricsSettings.Project"/></li><li><c>/solution</c> via <see cref="CodeMetricsSettings.Solution"/></li></ul></remarks>
    public static IEnumerable<(CodeMetricsSettings Settings, IReadOnlyCollection<Output> Output)> CodeMetrics(CombinatorialConfigure<CodeMetricsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(CodeMetrics, degreeOfParallelism, completeOnFailure);
}
#region CodeMetricsSettings
/// <summary>Used within <see cref="CodeMetricsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<CodeMetricsSettings>))]
[Command(Type = typeof(CodeMetricsTasks), Command = nameof(CodeMetricsTasks.CodeMetrics))]
public partial class CodeMetricsSettings : ToolOptions
{
    /// <summary>Project to analyze.</summary>
    [Argument(Format = "/project:{value}")] public string Project => Get<string>(() => Project);
    /// <summary>Solution to analyze.</summary>
    [Argument(Format = "/solution:{value}")] public string Solution => Get<string>(() => Solution);
    /// <summary>Metrics results XML output file.</summary>
    [Argument(Format = "/out:{value}")] public string OutputFile => Get<string>(() => OutputFile);
}
#endregion
#region CodeMetricsSettingsExtensions
/// <summary>Used within <see cref="CodeMetricsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class CodeMetricsSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="CodeMetricsSettings.Project"/>
    [Pure] [Builder(Type = typeof(CodeMetricsSettings), Property = nameof(CodeMetricsSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : CodeMetricsSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="CodeMetricsSettings.Project"/>
    [Pure] [Builder(Type = typeof(CodeMetricsSettings), Property = nameof(CodeMetricsSettings.Project))]
    public static T ResetProject<T>(this T o) where T : CodeMetricsSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region Solution
    /// <inheritdoc cref="CodeMetricsSettings.Solution"/>
    [Pure] [Builder(Type = typeof(CodeMetricsSettings), Property = nameof(CodeMetricsSettings.Solution))]
    public static T SetSolution<T>(this T o, string v) where T : CodeMetricsSettings => o.Modify(b => b.Set(() => o.Solution, v));
    /// <inheritdoc cref="CodeMetricsSettings.Solution"/>
    [Pure] [Builder(Type = typeof(CodeMetricsSettings), Property = nameof(CodeMetricsSettings.Solution))]
    public static T ResetSolution<T>(this T o) where T : CodeMetricsSettings => o.Modify(b => b.Remove(() => o.Solution));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="CodeMetricsSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(CodeMetricsSettings), Property = nameof(CodeMetricsSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : CodeMetricsSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="CodeMetricsSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(CodeMetricsSettings), Property = nameof(CodeMetricsSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : CodeMetricsSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
}
#endregion
