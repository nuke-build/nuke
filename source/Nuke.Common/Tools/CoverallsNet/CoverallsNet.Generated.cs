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

namespace Nuke.Common.Tools.CoverallsNet
{
    /// <summary>
    ///   <p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p>
    ///   <p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(CoverallsNetPackageId)]
    public partial class CoverallsNetTasks
        : IRequireNuGetPackage
    {
        public const string CoverallsNetPackageId = "coveralls.net";
        /// <summary>
        ///   Path to the CoverallsNet executable.
        /// </summary>
        public static string CoverallsNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("COVERALLSNET_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("coveralls.net", "csmacnz.Coveralls.dll");
        public static Action<OutputType, string> CoverallsNetLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p>
        ///   <p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> CoverallsNet(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(CoverallsNetPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? CoverallsNetLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p>
        ///   <p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--basePath</c> via <see cref="CoverallsNetSettings.BasePath"/></li>
        ///     <li><c>--commitAuthor</c> via <see cref="CoverallsNetSettings.CommitAuthor"/></li>
        ///     <li><c>--commitBranch</c> via <see cref="CoverallsNetSettings.CommitBranch"/></li>
        ///     <li><c>--commitEmail</c> via <see cref="CoverallsNetSettings.CommitEmail"/></li>
        ///     <li><c>--commitId</c> via <see cref="CoverallsNetSettings.CommitId"/></li>
        ///     <li><c>--commitMessage</c> via <see cref="CoverallsNetSettings.CommitMessage"/></li>
        ///     <li><c>--dryrun</c> via <see cref="CoverallsNetSettings.DryRun"/></li>
        ///     <li><c>--dynamiccodecoverage</c> via <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></li>
        ///     <li><c>--exportcodecoverage</c> via <see cref="CoverallsNetSettings.ExportCodeCoverage"/></li>
        ///     <li><c>--input</c> via <see cref="CoverallsNetSettings.Input"/></li>
        ///     <li><c>--jobId</c> via <see cref="CoverallsNetSettings.JobId"/></li>
        ///     <li><c>--monocov</c> via <see cref="CoverallsNetSettings.Monocov"/></li>
        ///     <li><c>--opencover</c> via <see cref="CoverallsNetSettings.OpenCover"/></li>
        ///     <li><c>--output</c> via <see cref="CoverallsNetSettings.Output"/></li>
        ///     <li><c>--pullRequest</c> via <see cref="CoverallsNetSettings.PullRequest"/></li>
        ///     <li><c>--repoToken</c> via <see cref="CoverallsNetSettings.RepoToken"/></li>
        ///     <li><c>--repoTokenVariable</c> via <see cref="CoverallsNetSettings.RepoTokenVariable"/></li>
        ///     <li><c>--serviceName</c> via <see cref="CoverallsNetSettings.ServiceName"/></li>
        ///     <li><c>--useRelativePaths</c> via <see cref="CoverallsNetSettings.UserRelativePaths"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CoverallsNet(CoverallsNetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CoverallsNetSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p>
        ///   <p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--basePath</c> via <see cref="CoverallsNetSettings.BasePath"/></li>
        ///     <li><c>--commitAuthor</c> via <see cref="CoverallsNetSettings.CommitAuthor"/></li>
        ///     <li><c>--commitBranch</c> via <see cref="CoverallsNetSettings.CommitBranch"/></li>
        ///     <li><c>--commitEmail</c> via <see cref="CoverallsNetSettings.CommitEmail"/></li>
        ///     <li><c>--commitId</c> via <see cref="CoverallsNetSettings.CommitId"/></li>
        ///     <li><c>--commitMessage</c> via <see cref="CoverallsNetSettings.CommitMessage"/></li>
        ///     <li><c>--dryrun</c> via <see cref="CoverallsNetSettings.DryRun"/></li>
        ///     <li><c>--dynamiccodecoverage</c> via <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></li>
        ///     <li><c>--exportcodecoverage</c> via <see cref="CoverallsNetSettings.ExportCodeCoverage"/></li>
        ///     <li><c>--input</c> via <see cref="CoverallsNetSettings.Input"/></li>
        ///     <li><c>--jobId</c> via <see cref="CoverallsNetSettings.JobId"/></li>
        ///     <li><c>--monocov</c> via <see cref="CoverallsNetSettings.Monocov"/></li>
        ///     <li><c>--opencover</c> via <see cref="CoverallsNetSettings.OpenCover"/></li>
        ///     <li><c>--output</c> via <see cref="CoverallsNetSettings.Output"/></li>
        ///     <li><c>--pullRequest</c> via <see cref="CoverallsNetSettings.PullRequest"/></li>
        ///     <li><c>--repoToken</c> via <see cref="CoverallsNetSettings.RepoToken"/></li>
        ///     <li><c>--repoTokenVariable</c> via <see cref="CoverallsNetSettings.RepoTokenVariable"/></li>
        ///     <li><c>--serviceName</c> via <see cref="CoverallsNetSettings.ServiceName"/></li>
        ///     <li><c>--useRelativePaths</c> via <see cref="CoverallsNetSettings.UserRelativePaths"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CoverallsNet(Configure<CoverallsNetSettings> configurator)
        {
            return CoverallsNet(configurator(new CoverallsNetSettings()));
        }
        /// <summary>
        ///   <p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p>
        ///   <p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--basePath</c> via <see cref="CoverallsNetSettings.BasePath"/></li>
        ///     <li><c>--commitAuthor</c> via <see cref="CoverallsNetSettings.CommitAuthor"/></li>
        ///     <li><c>--commitBranch</c> via <see cref="CoverallsNetSettings.CommitBranch"/></li>
        ///     <li><c>--commitEmail</c> via <see cref="CoverallsNetSettings.CommitEmail"/></li>
        ///     <li><c>--commitId</c> via <see cref="CoverallsNetSettings.CommitId"/></li>
        ///     <li><c>--commitMessage</c> via <see cref="CoverallsNetSettings.CommitMessage"/></li>
        ///     <li><c>--dryrun</c> via <see cref="CoverallsNetSettings.DryRun"/></li>
        ///     <li><c>--dynamiccodecoverage</c> via <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></li>
        ///     <li><c>--exportcodecoverage</c> via <see cref="CoverallsNetSettings.ExportCodeCoverage"/></li>
        ///     <li><c>--input</c> via <see cref="CoverallsNetSettings.Input"/></li>
        ///     <li><c>--jobId</c> via <see cref="CoverallsNetSettings.JobId"/></li>
        ///     <li><c>--monocov</c> via <see cref="CoverallsNetSettings.Monocov"/></li>
        ///     <li><c>--opencover</c> via <see cref="CoverallsNetSettings.OpenCover"/></li>
        ///     <li><c>--output</c> via <see cref="CoverallsNetSettings.Output"/></li>
        ///     <li><c>--pullRequest</c> via <see cref="CoverallsNetSettings.PullRequest"/></li>
        ///     <li><c>--repoToken</c> via <see cref="CoverallsNetSettings.RepoToken"/></li>
        ///     <li><c>--repoTokenVariable</c> via <see cref="CoverallsNetSettings.RepoTokenVariable"/></li>
        ///     <li><c>--serviceName</c> via <see cref="CoverallsNetSettings.ServiceName"/></li>
        ///     <li><c>--useRelativePaths</c> via <see cref="CoverallsNetSettings.UserRelativePaths"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CoverallsNetSettings Settings, IReadOnlyCollection<Output> Output)> CoverallsNet(CombinatorialConfigure<CoverallsNetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CoverallsNet, CoverallsNetLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CoverallsNetSettings
    /// <summary>
    ///   Used within <see cref="CoverallsNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CoverallsNetSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CoverallsNet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? CoverallsNetTasks.CoverallsNetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? CoverallsNetTasks.CoverallsNetLogger;
        /// <summary>
        ///   The coverage source file location.
        /// </summary>
        public virtual string Input { get; internal set; }
        /// <summary>
        ///   The coverage results json will be written to this file it provided.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.
        /// </summary>
        public virtual bool? UserRelativePaths { get; internal set; }
        /// <summary>
        ///   When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.
        /// </summary>
        public virtual string BasePath { get; internal set; }
        /// <summary>
        ///   Reads input as OpenCover data.
        /// </summary>
        public virtual bool? OpenCover { get; internal set; }
        /// <summary>
        ///   Reads input as the CodeCoverage.exe xml format.
        /// </summary>
        public virtual bool? DynamicCodeCoverage { get; internal set; }
        /// <summary>
        ///   Reads input as the Visual Studio Coverage Export xml format.
        /// </summary>
        public virtual bool? ExportCodeCoverage { get; internal set; }
        /// <summary>
        ///   Reads input as monocov results folder.
        /// </summary>
        public virtual bool? Monocov { get; internal set; }
        /// <summary>
        ///   The coveralls.io repository token.
        /// </summary>
        public virtual string RepoToken { get; internal set; }
        /// <summary>
        ///   The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.
        /// </summary>
        public virtual string RepoTokenVariable { get; internal set; }
        /// <summary>
        ///   The git commit hash for the coverage report.
        /// </summary>
        public virtual string CommitId { get; internal set; }
        /// <summary>
        ///   The git branch for the coverage report.
        /// </summary>
        public virtual string CommitBranch { get; internal set; }
        /// <summary>
        ///   The git commit author for the coverage report.
        /// </summary>
        public virtual string CommitAuthor { get; internal set; }
        /// <summary>
        ///   The git commit author email for the coverage report.
        /// </summary>
        public virtual string CommitEmail { get; internal set; }
        /// <summary>
        ///   The git commit message for the coverage report.
        /// </summary>
        public virtual string CommitMessage { get; internal set; }
        /// <summary>
        ///   The job Id to provide to coveralls.io. Default is <c>0</c>.
        /// </summary>
        public virtual int? JobId { get; internal set; }
        /// <summary>
        ///   The service-name for the coverage report. Default is <c>coveralls.net</c>.
        /// </summary>
        public virtual string ServiceName { get; internal set; }
        /// <summary>
        ///   The github pull request id. Used for updating status on github PRs.
        /// </summary>
        public virtual int? PullRequest { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--input {value}", Input)
              .Add("--output {value}", Output)
              .Add("--dryrun", DryRun)
              .Add("--useRelativePaths", UserRelativePaths)
              .Add("--basePath {value}", BasePath)
              .Add("--opencover", OpenCover)
              .Add("--dynamiccodecoverage", DynamicCodeCoverage)
              .Add("--exportcodecoverage", ExportCodeCoverage)
              .Add("--monocov", Monocov)
              .Add("--repoToken {value}", RepoToken, secret: true)
              .Add("--repoTokenVariable {value}", RepoTokenVariable)
              .Add("--commitId {value}", CommitId)
              .Add("--commitBranch {value}", CommitBranch)
              .Add("--commitAuthor {value}", CommitAuthor)
              .Add("--commitEmail {value}", CommitEmail)
              .Add("--commitMessage {value}", CommitMessage)
              .Add("--jobId {value}", JobId)
              .Add("--serviceName {value}", ServiceName)
              .Add("--pullRequest {value}", PullRequest);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region CoverallsNetSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CoverallsNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CoverallsNetSettingsExtensions
    {
        #region Input
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.Input"/></em></p>
        ///   <p>The coverage source file location.</p>
        /// </summary>
        [Pure]
        public static T SetInput<T>(this T toolSettings, string input) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.Input"/></em></p>
        ///   <p>The coverage source file location.</p>
        /// </summary>
        [Pure]
        public static T ResetInput<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.Output"/></em></p>
        ///   <p>The coverage results json will be written to this file it provided.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.Output"/></em></p>
        ///   <p>The coverage results json will be written to this file it provided.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.DryRun"/></em></p>
        ///   <p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p>
        /// </summary>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.DryRun"/></em></p>
        ///   <p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverallsNetSettings.DryRun"/></em></p>
        ///   <p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverallsNetSettings.DryRun"/></em></p>
        ///   <p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverallsNetSettings.DryRun"/></em></p>
        ///   <p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region UserRelativePaths
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.UserRelativePaths"/></em></p>
        ///   <p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p>
        /// </summary>
        [Pure]
        public static T SetUserRelativePaths<T>(this T toolSettings, bool? userRelativePaths) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = userRelativePaths;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.UserRelativePaths"/></em></p>
        ///   <p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p>
        /// </summary>
        [Pure]
        public static T ResetUserRelativePaths<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverallsNetSettings.UserRelativePaths"/></em></p>
        ///   <p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p>
        /// </summary>
        [Pure]
        public static T EnableUserRelativePaths<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverallsNetSettings.UserRelativePaths"/></em></p>
        ///   <p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p>
        /// </summary>
        [Pure]
        public static T DisableUserRelativePaths<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverallsNetSettings.UserRelativePaths"/></em></p>
        ///   <p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p>
        /// </summary>
        [Pure]
        public static T ToggleUserRelativePaths<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = !toolSettings.UserRelativePaths;
            return toolSettings;
        }
        #endregion
        #region BasePath
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.BasePath"/></em></p>
        ///   <p>When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.</p>
        /// </summary>
        [Pure]
        public static T SetBasePath<T>(this T toolSettings, string basePath) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.BasePath"/></em></p>
        ///   <p>When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetBasePath<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region OpenCover
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.OpenCover"/></em></p>
        ///   <p>Reads input as OpenCover data.</p>
        /// </summary>
        [Pure]
        public static T SetOpenCover<T>(this T toolSettings, bool? openCover) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = openCover;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.OpenCover"/></em></p>
        ///   <p>Reads input as OpenCover data.</p>
        /// </summary>
        [Pure]
        public static T ResetOpenCover<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverallsNetSettings.OpenCover"/></em></p>
        ///   <p>Reads input as OpenCover data.</p>
        /// </summary>
        [Pure]
        public static T EnableOpenCover<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverallsNetSettings.OpenCover"/></em></p>
        ///   <p>Reads input as OpenCover data.</p>
        /// </summary>
        [Pure]
        public static T DisableOpenCover<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverallsNetSettings.OpenCover"/></em></p>
        ///   <p>Reads input as OpenCover data.</p>
        /// </summary>
        [Pure]
        public static T ToggleOpenCover<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = !toolSettings.OpenCover;
            return toolSettings;
        }
        #endregion
        #region DynamicCodeCoverage
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></em></p>
        ///   <p>Reads input as the CodeCoverage.exe xml format.</p>
        /// </summary>
        [Pure]
        public static T SetDynamicCodeCoverage<T>(this T toolSettings, bool? dynamicCodeCoverage) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = dynamicCodeCoverage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></em></p>
        ///   <p>Reads input as the CodeCoverage.exe xml format.</p>
        /// </summary>
        [Pure]
        public static T ResetDynamicCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></em></p>
        ///   <p>Reads input as the CodeCoverage.exe xml format.</p>
        /// </summary>
        [Pure]
        public static T EnableDynamicCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></em></p>
        ///   <p>Reads input as the CodeCoverage.exe xml format.</p>
        /// </summary>
        [Pure]
        public static T DisableDynamicCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverallsNetSettings.DynamicCodeCoverage"/></em></p>
        ///   <p>Reads input as the CodeCoverage.exe xml format.</p>
        /// </summary>
        [Pure]
        public static T ToggleDynamicCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = !toolSettings.DynamicCodeCoverage;
            return toolSettings;
        }
        #endregion
        #region ExportCodeCoverage
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.ExportCodeCoverage"/></em></p>
        ///   <p>Reads input as the Visual Studio Coverage Export xml format.</p>
        /// </summary>
        [Pure]
        public static T SetExportCodeCoverage<T>(this T toolSettings, bool? exportCodeCoverage) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = exportCodeCoverage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.ExportCodeCoverage"/></em></p>
        ///   <p>Reads input as the Visual Studio Coverage Export xml format.</p>
        /// </summary>
        [Pure]
        public static T ResetExportCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverallsNetSettings.ExportCodeCoverage"/></em></p>
        ///   <p>Reads input as the Visual Studio Coverage Export xml format.</p>
        /// </summary>
        [Pure]
        public static T EnableExportCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverallsNetSettings.ExportCodeCoverage"/></em></p>
        ///   <p>Reads input as the Visual Studio Coverage Export xml format.</p>
        /// </summary>
        [Pure]
        public static T DisableExportCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverallsNetSettings.ExportCodeCoverage"/></em></p>
        ///   <p>Reads input as the Visual Studio Coverage Export xml format.</p>
        /// </summary>
        [Pure]
        public static T ToggleExportCodeCoverage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = !toolSettings.ExportCodeCoverage;
            return toolSettings;
        }
        #endregion
        #region Monocov
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.Monocov"/></em></p>
        ///   <p>Reads input as monocov results folder.</p>
        /// </summary>
        [Pure]
        public static T SetMonocov<T>(this T toolSettings, bool? monocov) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = monocov;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.Monocov"/></em></p>
        ///   <p>Reads input as monocov results folder.</p>
        /// </summary>
        [Pure]
        public static T ResetMonocov<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CoverallsNetSettings.Monocov"/></em></p>
        ///   <p>Reads input as monocov results folder.</p>
        /// </summary>
        [Pure]
        public static T EnableMonocov<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CoverallsNetSettings.Monocov"/></em></p>
        ///   <p>Reads input as monocov results folder.</p>
        /// </summary>
        [Pure]
        public static T DisableMonocov<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CoverallsNetSettings.Monocov"/></em></p>
        ///   <p>Reads input as monocov results folder.</p>
        /// </summary>
        [Pure]
        public static T ToggleMonocov<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = !toolSettings.Monocov;
            return toolSettings;
        }
        #endregion
        #region RepoToken
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.RepoToken"/></em></p>
        ///   <p>The coveralls.io repository token.</p>
        /// </summary>
        [Pure]
        public static T SetRepoToken<T>(this T toolSettings, [Secret] string repoToken) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoToken = repoToken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.RepoToken"/></em></p>
        ///   <p>The coveralls.io repository token.</p>
        /// </summary>
        [Pure]
        public static T ResetRepoToken<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoToken = null;
            return toolSettings;
        }
        #endregion
        #region RepoTokenVariable
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.RepoTokenVariable"/></em></p>
        ///   <p>The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.</p>
        /// </summary>
        [Pure]
        public static T SetRepoTokenVariable<T>(this T toolSettings, string repoTokenVariable) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoTokenVariable = repoTokenVariable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.RepoTokenVariable"/></em></p>
        ///   <p>The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetRepoTokenVariable<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoTokenVariable = null;
            return toolSettings;
        }
        #endregion
        #region CommitId
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.CommitId"/></em></p>
        ///   <p>The git commit hash for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T SetCommitId<T>(this T toolSettings, string commitId) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitId = commitId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.CommitId"/></em></p>
        ///   <p>The git commit hash for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T ResetCommitId<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitId = null;
            return toolSettings;
        }
        #endregion
        #region CommitBranch
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.CommitBranch"/></em></p>
        ///   <p>The git branch for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T SetCommitBranch<T>(this T toolSettings, string commitBranch) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitBranch = commitBranch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.CommitBranch"/></em></p>
        ///   <p>The git branch for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T ResetCommitBranch<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitBranch = null;
            return toolSettings;
        }
        #endregion
        #region CommitAuthor
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.CommitAuthor"/></em></p>
        ///   <p>The git commit author for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T SetCommitAuthor<T>(this T toolSettings, string commitAuthor) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitAuthor = commitAuthor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.CommitAuthor"/></em></p>
        ///   <p>The git commit author for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T ResetCommitAuthor<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitAuthor = null;
            return toolSettings;
        }
        #endregion
        #region CommitEmail
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.CommitEmail"/></em></p>
        ///   <p>The git commit author email for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T SetCommitEmail<T>(this T toolSettings, string commitEmail) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitEmail = commitEmail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.CommitEmail"/></em></p>
        ///   <p>The git commit author email for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T ResetCommitEmail<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitEmail = null;
            return toolSettings;
        }
        #endregion
        #region CommitMessage
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.CommitMessage"/></em></p>
        ///   <p>The git commit message for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T SetCommitMessage<T>(this T toolSettings, string commitMessage) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitMessage = commitMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.CommitMessage"/></em></p>
        ///   <p>The git commit message for the coverage report.</p>
        /// </summary>
        [Pure]
        public static T ResetCommitMessage<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitMessage = null;
            return toolSettings;
        }
        #endregion
        #region JobId
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.JobId"/></em></p>
        ///   <p>The job Id to provide to coveralls.io. Default is <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T SetJobId<T>(this T toolSettings, int? jobId) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JobId = jobId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.JobId"/></em></p>
        ///   <p>The job Id to provide to coveralls.io. Default is <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetJobId<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JobId = null;
            return toolSettings;
        }
        #endregion
        #region ServiceName
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.ServiceName"/></em></p>
        ///   <p>The service-name for the coverage report. Default is <c>coveralls.net</c>.</p>
        /// </summary>
        [Pure]
        public static T SetServiceName<T>(this T toolSettings, string serviceName) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceName = serviceName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.ServiceName"/></em></p>
        ///   <p>The service-name for the coverage report. Default is <c>coveralls.net</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetServiceName<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceName = null;
            return toolSettings;
        }
        #endregion
        #region PullRequest
        /// <summary>
        ///   <p><em>Sets <see cref="CoverallsNetSettings.PullRequest"/></em></p>
        ///   <p>The github pull request id. Used for updating status on github PRs.</p>
        /// </summary>
        [Pure]
        public static T SetPullRequest<T>(this T toolSettings, int? pullRequest) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequest = pullRequest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CoverallsNetSettings.PullRequest"/></em></p>
        ///   <p>The github pull request id. Used for updating status on github PRs.</p>
        /// </summary>
        [Pure]
        public static T ResetPullRequest<T>(this T toolSettings) where T : CoverallsNetSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequest = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
