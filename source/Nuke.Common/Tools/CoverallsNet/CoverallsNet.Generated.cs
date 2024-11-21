// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/CoverallsNet/CoverallsNet.json

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

namespace Nuke.Common.Tools.CoverallsNet;

/// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class CoverallsNetTasks : ToolTasks, IRequireNuGetPackage
{
    public static string CoverallsNetPath => new CoverallsNetTasks().GetToolPath();
    public const string PackageId = "coveralls.net";
    public const string PackageExecutable = "csmacnz.Coveralls.dll";
    /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> CoverallsNet(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new CoverallsNetTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--basePath</c> via <see cref="CoverallsNetSettings.BasePath"/></li><li><c>--commitAuthor</c> via <see cref="CoverallsNetSettings.CommitAuthor"/></li><li><c>--commitBranch</c> via <see cref="CoverallsNetSettings.CommitBranch"/></li><li><c>--commitEmail</c> via <see cref="CoverallsNetSettings.CommitEmail"/></li><li><c>--commitId</c> via <see cref="CoverallsNetSettings.CommitId"/></li><li><c>--commitMessage</c> via <see cref="CoverallsNetSettings.CommitMessage"/></li><li><c>--dryrun</c> via <see cref="CoverallsNetSettings.DryRun"/></li><li><c>--dynamiccodecoverage</c> via <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></li><li><c>--exportcodecoverage</c> via <see cref="CoverallsNetSettings.ExportCodeCoverage"/></li><li><c>--input</c> via <see cref="CoverallsNetSettings.Input"/></li><li><c>--jobId</c> via <see cref="CoverallsNetSettings.JobId"/></li><li><c>--monocov</c> via <see cref="CoverallsNetSettings.Monocov"/></li><li><c>--opencover</c> via <see cref="CoverallsNetSettings.OpenCover"/></li><li><c>--output</c> via <see cref="CoverallsNetSettings.Output"/></li><li><c>--pullRequest</c> via <see cref="CoverallsNetSettings.PullRequest"/></li><li><c>--repoToken</c> via <see cref="CoverallsNetSettings.RepoToken"/></li><li><c>--repoTokenVariable</c> via <see cref="CoverallsNetSettings.RepoTokenVariable"/></li><li><c>--serviceName</c> via <see cref="CoverallsNetSettings.ServiceName"/></li><li><c>--useRelativePaths</c> via <see cref="CoverallsNetSettings.UserRelativePaths"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> CoverallsNet(CoverallsNetSettings options = null) => new CoverallsNetTasks().Run(options);
    /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--basePath</c> via <see cref="CoverallsNetSettings.BasePath"/></li><li><c>--commitAuthor</c> via <see cref="CoverallsNetSettings.CommitAuthor"/></li><li><c>--commitBranch</c> via <see cref="CoverallsNetSettings.CommitBranch"/></li><li><c>--commitEmail</c> via <see cref="CoverallsNetSettings.CommitEmail"/></li><li><c>--commitId</c> via <see cref="CoverallsNetSettings.CommitId"/></li><li><c>--commitMessage</c> via <see cref="CoverallsNetSettings.CommitMessage"/></li><li><c>--dryrun</c> via <see cref="CoverallsNetSettings.DryRun"/></li><li><c>--dynamiccodecoverage</c> via <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></li><li><c>--exportcodecoverage</c> via <see cref="CoverallsNetSettings.ExportCodeCoverage"/></li><li><c>--input</c> via <see cref="CoverallsNetSettings.Input"/></li><li><c>--jobId</c> via <see cref="CoverallsNetSettings.JobId"/></li><li><c>--monocov</c> via <see cref="CoverallsNetSettings.Monocov"/></li><li><c>--opencover</c> via <see cref="CoverallsNetSettings.OpenCover"/></li><li><c>--output</c> via <see cref="CoverallsNetSettings.Output"/></li><li><c>--pullRequest</c> via <see cref="CoverallsNetSettings.PullRequest"/></li><li><c>--repoToken</c> via <see cref="CoverallsNetSettings.RepoToken"/></li><li><c>--repoTokenVariable</c> via <see cref="CoverallsNetSettings.RepoTokenVariable"/></li><li><c>--serviceName</c> via <see cref="CoverallsNetSettings.ServiceName"/></li><li><c>--useRelativePaths</c> via <see cref="CoverallsNetSettings.UserRelativePaths"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> CoverallsNet(Configure<CoverallsNetSettings> configurator) => new CoverallsNetTasks().Run(configurator.Invoke(new CoverallsNetSettings()));
    /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--basePath</c> via <see cref="CoverallsNetSettings.BasePath"/></li><li><c>--commitAuthor</c> via <see cref="CoverallsNetSettings.CommitAuthor"/></li><li><c>--commitBranch</c> via <see cref="CoverallsNetSettings.CommitBranch"/></li><li><c>--commitEmail</c> via <see cref="CoverallsNetSettings.CommitEmail"/></li><li><c>--commitId</c> via <see cref="CoverallsNetSettings.CommitId"/></li><li><c>--commitMessage</c> via <see cref="CoverallsNetSettings.CommitMessage"/></li><li><c>--dryrun</c> via <see cref="CoverallsNetSettings.DryRun"/></li><li><c>--dynamiccodecoverage</c> via <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></li><li><c>--exportcodecoverage</c> via <see cref="CoverallsNetSettings.ExportCodeCoverage"/></li><li><c>--input</c> via <see cref="CoverallsNetSettings.Input"/></li><li><c>--jobId</c> via <see cref="CoverallsNetSettings.JobId"/></li><li><c>--monocov</c> via <see cref="CoverallsNetSettings.Monocov"/></li><li><c>--opencover</c> via <see cref="CoverallsNetSettings.OpenCover"/></li><li><c>--output</c> via <see cref="CoverallsNetSettings.Output"/></li><li><c>--pullRequest</c> via <see cref="CoverallsNetSettings.PullRequest"/></li><li><c>--repoToken</c> via <see cref="CoverallsNetSettings.RepoToken"/></li><li><c>--repoTokenVariable</c> via <see cref="CoverallsNetSettings.RepoTokenVariable"/></li><li><c>--serviceName</c> via <see cref="CoverallsNetSettings.ServiceName"/></li><li><c>--useRelativePaths</c> via <see cref="CoverallsNetSettings.UserRelativePaths"/></li></ul></remarks>
    public static IEnumerable<(CoverallsNetSettings Settings, IReadOnlyCollection<Output> Output)> CoverallsNet(CombinatorialConfigure<CoverallsNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(CoverallsNet, degreeOfParallelism, completeOnFailure);
}
#region CoverallsNetSettings
/// <summary>Used within <see cref="CoverallsNetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<CoverallsNetSettings>))]
[Command(Type = typeof(CoverallsNetTasks), Command = nameof(CoverallsNetTasks.CoverallsNet))]
public partial class CoverallsNetSettings : ToolOptions
{
    /// <summary>The coverage source file location.</summary>
    [Argument(Format = "--input {value}")] public string Input => Get<string>(() => Input);
    /// <summary>The coverage results json will be written to this file it provided.</summary>
    [Argument(Format = "--output {value}")] public string Output => Get<string>(() => Output);
    /// <summary>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</summary>
    [Argument(Format = "--dryrun")] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</summary>
    [Argument(Format = "--useRelativePaths")] public bool? UserRelativePaths => Get<bool?>(() => UserRelativePaths);
    /// <summary>When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.</summary>
    [Argument(Format = "--basePath {value}")] public string BasePath => Get<string>(() => BasePath);
    /// <summary>Reads input as OpenCover data.</summary>
    [Argument(Format = "--opencover")] public bool? OpenCover => Get<bool?>(() => OpenCover);
    /// <summary>Reads input as the CodeCoverage.exe xml format.</summary>
    [Argument(Format = "--dynamiccodecoverage")] public bool? DynamicCodeCoverage => Get<bool?>(() => DynamicCodeCoverage);
    /// <summary>Reads input as the Visual Studio Coverage Export xml format.</summary>
    [Argument(Format = "--exportcodecoverage")] public bool? ExportCodeCoverage => Get<bool?>(() => ExportCodeCoverage);
    /// <summary>Reads input as monocov results folder.</summary>
    [Argument(Format = "--monocov")] public bool? Monocov => Get<bool?>(() => Monocov);
    /// <summary>The coveralls.io repository token.</summary>
    [Argument(Format = "--repoToken {value}", Secret = true)] public string RepoToken => Get<string>(() => RepoToken);
    /// <summary>The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.</summary>
    [Argument(Format = "--repoTokenVariable {value}", Secret = false)] public string RepoTokenVariable => Get<string>(() => RepoTokenVariable);
    /// <summary>The git commit hash for the coverage report.</summary>
    [Argument(Format = "--commitId {value}")] public string CommitId => Get<string>(() => CommitId);
    /// <summary>The git branch for the coverage report.</summary>
    [Argument(Format = "--commitBranch {value}")] public string CommitBranch => Get<string>(() => CommitBranch);
    /// <summary>The git commit author for the coverage report.</summary>
    [Argument(Format = "--commitAuthor {value}")] public string CommitAuthor => Get<string>(() => CommitAuthor);
    /// <summary>The git commit author email for the coverage report.</summary>
    [Argument(Format = "--commitEmail {value}")] public string CommitEmail => Get<string>(() => CommitEmail);
    /// <summary>The git commit message for the coverage report.</summary>
    [Argument(Format = "--commitMessage {value}")] public string CommitMessage => Get<string>(() => CommitMessage);
    /// <summary>The job Id to provide to coveralls.io. Default is <c>0</c>.</summary>
    [Argument(Format = "--jobId {value}")] public string JobId => Get<string>(() => JobId);
    /// <summary>The service-name for the coverage report. Default is <c>coveralls.net</c>.</summary>
    [Argument(Format = "--serviceName {value}")] public string ServiceName => Get<string>(() => ServiceName);
    /// <summary>The github pull request id. Used for updating status on github PRs.</summary>
    [Argument(Format = "--pullRequest {value}")] public int? PullRequest => Get<int?>(() => PullRequest);
}
#endregion
#region CoverallsNetSettingsExtensions
/// <summary>Used within <see cref="CoverallsNetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class CoverallsNetSettingsExtensions
{
    #region Input
    /// <inheritdoc cref="CoverallsNetSettings.Input"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Input))]
    public static T SetInput<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.Input, v));
    /// <inheritdoc cref="CoverallsNetSettings.Input"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Input))]
    public static T ResetInput<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.Input));
    #endregion
    #region Output
    /// <inheritdoc cref="CoverallsNetSettings.Output"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="CoverallsNetSettings.Output"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region DryRun
    /// <inheritdoc cref="CoverallsNetSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="CoverallsNetSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="CoverallsNetSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="CoverallsNetSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="CoverallsNetSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region UserRelativePaths
    /// <inheritdoc cref="CoverallsNetSettings.UserRelativePaths"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.UserRelativePaths))]
    public static T SetUserRelativePaths<T>(this T o, bool? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.UserRelativePaths, v));
    /// <inheritdoc cref="CoverallsNetSettings.UserRelativePaths"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.UserRelativePaths))]
    public static T ResetUserRelativePaths<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.UserRelativePaths));
    /// <inheritdoc cref="CoverallsNetSettings.UserRelativePaths"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.UserRelativePaths))]
    public static T EnableUserRelativePaths<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.UserRelativePaths, true));
    /// <inheritdoc cref="CoverallsNetSettings.UserRelativePaths"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.UserRelativePaths))]
    public static T DisableUserRelativePaths<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.UserRelativePaths, false));
    /// <inheritdoc cref="CoverallsNetSettings.UserRelativePaths"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.UserRelativePaths))]
    public static T ToggleUserRelativePaths<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.UserRelativePaths, !o.UserRelativePaths));
    #endregion
    #region BasePath
    /// <inheritdoc cref="CoverallsNetSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.BasePath))]
    public static T SetBasePath<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.BasePath, v));
    /// <inheritdoc cref="CoverallsNetSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.BasePath))]
    public static T ResetBasePath<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.BasePath));
    #endregion
    #region OpenCover
    /// <inheritdoc cref="CoverallsNetSettings.OpenCover"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.OpenCover))]
    public static T SetOpenCover<T>(this T o, bool? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.OpenCover, v));
    /// <inheritdoc cref="CoverallsNetSettings.OpenCover"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.OpenCover))]
    public static T ResetOpenCover<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.OpenCover));
    /// <inheritdoc cref="CoverallsNetSettings.OpenCover"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.OpenCover))]
    public static T EnableOpenCover<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.OpenCover, true));
    /// <inheritdoc cref="CoverallsNetSettings.OpenCover"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.OpenCover))]
    public static T DisableOpenCover<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.OpenCover, false));
    /// <inheritdoc cref="CoverallsNetSettings.OpenCover"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.OpenCover))]
    public static T ToggleOpenCover<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.OpenCover, !o.OpenCover));
    #endregion
    #region DynamicCodeCoverage
    /// <inheritdoc cref="CoverallsNetSettings.DynamicCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DynamicCodeCoverage))]
    public static T SetDynamicCodeCoverage<T>(this T o, bool? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DynamicCodeCoverage, v));
    /// <inheritdoc cref="CoverallsNetSettings.DynamicCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DynamicCodeCoverage))]
    public static T ResetDynamicCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.DynamicCodeCoverage));
    /// <inheritdoc cref="CoverallsNetSettings.DynamicCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DynamicCodeCoverage))]
    public static T EnableDynamicCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DynamicCodeCoverage, true));
    /// <inheritdoc cref="CoverallsNetSettings.DynamicCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DynamicCodeCoverage))]
    public static T DisableDynamicCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DynamicCodeCoverage, false));
    /// <inheritdoc cref="CoverallsNetSettings.DynamicCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.DynamicCodeCoverage))]
    public static T ToggleDynamicCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.DynamicCodeCoverage, !o.DynamicCodeCoverage));
    #endregion
    #region ExportCodeCoverage
    /// <inheritdoc cref="CoverallsNetSettings.ExportCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ExportCodeCoverage))]
    public static T SetExportCodeCoverage<T>(this T o, bool? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.ExportCodeCoverage, v));
    /// <inheritdoc cref="CoverallsNetSettings.ExportCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ExportCodeCoverage))]
    public static T ResetExportCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.ExportCodeCoverage));
    /// <inheritdoc cref="CoverallsNetSettings.ExportCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ExportCodeCoverage))]
    public static T EnableExportCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.ExportCodeCoverage, true));
    /// <inheritdoc cref="CoverallsNetSettings.ExportCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ExportCodeCoverage))]
    public static T DisableExportCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.ExportCodeCoverage, false));
    /// <inheritdoc cref="CoverallsNetSettings.ExportCodeCoverage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ExportCodeCoverage))]
    public static T ToggleExportCodeCoverage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.ExportCodeCoverage, !o.ExportCodeCoverage));
    #endregion
    #region Monocov
    /// <inheritdoc cref="CoverallsNetSettings.Monocov"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Monocov))]
    public static T SetMonocov<T>(this T o, bool? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.Monocov, v));
    /// <inheritdoc cref="CoverallsNetSettings.Monocov"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Monocov))]
    public static T ResetMonocov<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.Monocov));
    /// <inheritdoc cref="CoverallsNetSettings.Monocov"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Monocov))]
    public static T EnableMonocov<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.Monocov, true));
    /// <inheritdoc cref="CoverallsNetSettings.Monocov"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Monocov))]
    public static T DisableMonocov<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.Monocov, false));
    /// <inheritdoc cref="CoverallsNetSettings.Monocov"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.Monocov))]
    public static T ToggleMonocov<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.Monocov, !o.Monocov));
    #endregion
    #region RepoToken
    /// <inheritdoc cref="CoverallsNetSettings.RepoToken"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.RepoToken))]
    public static T SetRepoToken<T>(this T o, [Secret] string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.RepoToken, v));
    /// <inheritdoc cref="CoverallsNetSettings.RepoToken"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.RepoToken))]
    public static T ResetRepoToken<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.RepoToken));
    #endregion
    #region RepoTokenVariable
    /// <inheritdoc cref="CoverallsNetSettings.RepoTokenVariable"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.RepoTokenVariable))]
    public static T SetRepoTokenVariable<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.RepoTokenVariable, v));
    /// <inheritdoc cref="CoverallsNetSettings.RepoTokenVariable"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.RepoTokenVariable))]
    public static T ResetRepoTokenVariable<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.RepoTokenVariable));
    #endregion
    #region CommitId
    /// <inheritdoc cref="CoverallsNetSettings.CommitId"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitId))]
    public static T SetCommitId<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.CommitId, v));
    /// <inheritdoc cref="CoverallsNetSettings.CommitId"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitId))]
    public static T ResetCommitId<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.CommitId));
    #endregion
    #region CommitBranch
    /// <inheritdoc cref="CoverallsNetSettings.CommitBranch"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitBranch))]
    public static T SetCommitBranch<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.CommitBranch, v));
    /// <inheritdoc cref="CoverallsNetSettings.CommitBranch"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitBranch))]
    public static T ResetCommitBranch<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.CommitBranch));
    #endregion
    #region CommitAuthor
    /// <inheritdoc cref="CoverallsNetSettings.CommitAuthor"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitAuthor))]
    public static T SetCommitAuthor<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.CommitAuthor, v));
    /// <inheritdoc cref="CoverallsNetSettings.CommitAuthor"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitAuthor))]
    public static T ResetCommitAuthor<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.CommitAuthor));
    #endregion
    #region CommitEmail
    /// <inheritdoc cref="CoverallsNetSettings.CommitEmail"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitEmail))]
    public static T SetCommitEmail<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.CommitEmail, v));
    /// <inheritdoc cref="CoverallsNetSettings.CommitEmail"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitEmail))]
    public static T ResetCommitEmail<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.CommitEmail));
    #endregion
    #region CommitMessage
    /// <inheritdoc cref="CoverallsNetSettings.CommitMessage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitMessage))]
    public static T SetCommitMessage<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.CommitMessage, v));
    /// <inheritdoc cref="CoverallsNetSettings.CommitMessage"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.CommitMessage))]
    public static T ResetCommitMessage<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.CommitMessage));
    #endregion
    #region JobId
    /// <inheritdoc cref="CoverallsNetSettings.JobId"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.JobId))]
    public static T SetJobId<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.JobId, v));
    /// <inheritdoc cref="CoverallsNetSettings.JobId"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.JobId))]
    public static T ResetJobId<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.JobId));
    #endregion
    #region ServiceName
    /// <inheritdoc cref="CoverallsNetSettings.ServiceName"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ServiceName))]
    public static T SetServiceName<T>(this T o, string v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.ServiceName, v));
    /// <inheritdoc cref="CoverallsNetSettings.ServiceName"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.ServiceName))]
    public static T ResetServiceName<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.ServiceName));
    #endregion
    #region PullRequest
    /// <inheritdoc cref="CoverallsNetSettings.PullRequest"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.PullRequest))]
    public static T SetPullRequest<T>(this T o, int? v) where T : CoverallsNetSettings => o.Modify(b => b.Set(() => o.PullRequest, v));
    /// <inheritdoc cref="CoverallsNetSettings.PullRequest"/>
    [Pure] [Builder(Type = typeof(CoverallsNetSettings), Property = nameof(CoverallsNetSettings.PullRequest))]
    public static T ResetPullRequest<T>(this T o) where T : CoverallsNetSettings => o.Modify(b => b.Remove(() => o.PullRequest));
    #endregion
}
#endregion
