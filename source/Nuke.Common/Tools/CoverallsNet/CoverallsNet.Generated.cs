// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/CoverallsNet.json
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

namespace Nuke.Common.Tools.CoverallsNet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CoverallsNetTasks
    {
        /// <summary><p>Path to the CoverallsNet executable.</p></summary>
        public static string CoverallsNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("COVERALLSNET_EXE") ??
            ToolPathResolver.GetPackageExecutable("coveralls.net", "csmacnz.Coveralls.exe");
        public static Action<OutputType, string> CoverallsNetLogger { get; set; } = ProcessManager.DefaultLogger;
        /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p></summary>
        public static IReadOnlyCollection<Output> CoverallsNet(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(CoverallsNetPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, CoverallsNetLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> CoverallsNet(CoverallsNetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CoverallsNetSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> CoverallsNet(Configure<CoverallsNetSettings> configurator)
        {
            return CoverallsNet(configurator(new CoverallsNetSettings()));
        }
        /// <summary><p>Coveralls uploader for .Net Code coverage of your C# source code. Should work with any code files that get reported with the supported coverage tools, but the primary focus is CSharp.</p><p>For more details, visit the <a href="https://coverallsnet.readthedocs.io">official website</a>.</p></summary>
        public static IEnumerable<(CoverallsNetSettings Settings, IReadOnlyCollection<Output> Output)> CoverallsNet(CombinatorialConfigure<CoverallsNetSettings> configurator, int degreeOfParallelism = 1, bool stopOnFirstError = false)
        {
            return configurator.Execute(CoverallsNet, CoverallsNetLogger, degreeOfParallelism, stopOnFirstError);
        }
    }
    #region CoverallsNetSettings
    /// <summary><p>Used within <see cref="CoverallsNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CoverallsNetSettings : ToolSettings
    {
        /// <summary><p>Path to the CoverallsNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? CoverallsNetTasks.CoverallsNetPath;
        public override Action<OutputType, string> CustomLogger => CoverallsNetTasks.CoverallsNetLogger;
        /// <summary><p>The coverage source file location.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>The coverage results json will be written to this file it provided.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p></summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary><p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p></summary>
        public virtual bool? UserRelativePaths { get; internal set; }
        /// <summary><p>When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.</p></summary>
        public virtual string BasePath { get; internal set; }
        /// <summary><p>Reads input as OpenCover data.</p></summary>
        public virtual bool? OpenCover { get; internal set; }
        /// <summary><p>Reads input as the CodeCoverage.exe xml format.</p></summary>
        public virtual bool? DynamicCodeCoverage { get; internal set; }
        /// <summary><p>Reads input as the Visual Studio Coverage Export xml format.</p></summary>
        public virtual bool? ExportCodeCoverage { get; internal set; }
        /// <summary><p>Reads input as monocov results folder.</p></summary>
        public virtual bool? Monocov { get; internal set; }
        /// <summary><p>The coveralls.io repository token.</p></summary>
        public virtual string RepoToken { get; internal set; }
        /// <summary><p>The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.</p></summary>
        public virtual string RepoTokenVariable { get; internal set; }
        /// <summary><p>The git commit hash for the coverage report.</p></summary>
        public virtual string CommitId { get; internal set; }
        /// <summary><p>The git branch for the coverage report.</p></summary>
        public virtual string CommitBranch { get; internal set; }
        /// <summary><p>The git commit author for the coverage report.</p></summary>
        public virtual string CommitAuthor { get; internal set; }
        /// <summary><p>The git commit author email for the coverage report.</p></summary>
        public virtual string CommitEmail { get; internal set; }
        /// <summary><p>The git commit message for the coverage report.</p></summary>
        public virtual string CommitMessage { get; internal set; }
        /// <summary><p>The job Id to provide to coveralls.io. Default is <c>0</c>.</p></summary>
        public virtual int? JobId { get; internal set; }
        /// <summary><p>The service-name for the coverage report. Default is <c>coveralls.net</c>.</p></summary>
        public virtual string ServiceName { get; internal set; }
        /// <summary><p>The github pull request id. Used for updating status on github PRs.</p></summary>
        public virtual int? PullRequest { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CoverallsNetSettingsExtensions
    /// <summary><p>Used within <see cref="CoverallsNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CoverallsNetSettingsExtensions
    {
        #region Input
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.Input"/>.</em></p><p>The coverage source file location.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetInput(this CoverallsNetSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.Input"/>.</em></p><p>The coverage source file location.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetInput(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.Output"/>.</em></p><p>The coverage results json will be written to this file it provided.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetOutput(this CoverallsNetSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.Output"/>.</em></p><p>The coverage results json will be written to this file it provided.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetOutput(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.DryRun"/>.</em></p><p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetDryRun(this CoverallsNetSettings toolSettings, bool? dryRun)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.DryRun"/>.</em></p><p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetDryRun(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="CoverallsNetSettings.DryRun"/>.</em></p><p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p></summary>
        [Pure]
        public static CoverallsNetSettings EnableDryRun(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="CoverallsNetSettings.DryRun"/>.</em></p><p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p></summary>
        [Pure]
        public static CoverallsNetSettings DisableDryRun(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="CoverallsNetSettings.DryRun"/>.</em></p><p>This flag will stop coverage results being posted to <a href="https://coveralls.io">coveralls.io</a>.</p></summary>
        [Pure]
        public static CoverallsNetSettings ToggleDryRun(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region UserRelativePaths
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.UserRelativePaths"/>.</em></p><p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetUserRelativePaths(this CoverallsNetSettings toolSettings, bool? userRelativePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = userRelativePaths;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.UserRelativePaths"/>.</em></p><p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetUserRelativePaths(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="CoverallsNetSettings.UserRelativePaths"/>.</em></p><p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p></summary>
        [Pure]
        public static CoverallsNetSettings EnableUserRelativePaths(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="CoverallsNetSettings.UserRelativePaths"/>.</em></p><p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p></summary>
        [Pure]
        public static CoverallsNetSettings DisableUserRelativePaths(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="CoverallsNetSettings.UserRelativePaths"/>.</em></p><p>This flag, when provided, will attempt to strip the current working directory from the beginning of the source file path.</p></summary>
        [Pure]
        public static CoverallsNetSettings ToggleUserRelativePaths(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserRelativePaths = !toolSettings.UserRelativePaths;
            return toolSettings;
        }
        #endregion
        #region BasePath
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.BasePath"/>.</em></p><p>When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetBasePath(this CoverallsNetSettings toolSettings, string basePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.BasePath"/>.</em></p><p>When useRelativePaths and a basePath is provided, this path is used instead of the current working directory.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetBasePath(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region OpenCover
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.OpenCover"/>.</em></p><p>Reads input as OpenCover data.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetOpenCover(this CoverallsNetSettings toolSettings, bool? openCover)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = openCover;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.OpenCover"/>.</em></p><p>Reads input as OpenCover data.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetOpenCover(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="CoverallsNetSettings.OpenCover"/>.</em></p><p>Reads input as OpenCover data.</p></summary>
        [Pure]
        public static CoverallsNetSettings EnableOpenCover(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="CoverallsNetSettings.OpenCover"/>.</em></p><p>Reads input as OpenCover data.</p></summary>
        [Pure]
        public static CoverallsNetSettings DisableOpenCover(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="CoverallsNetSettings.OpenCover"/>.</em></p><p>Reads input as OpenCover data.</p></summary>
        [Pure]
        public static CoverallsNetSettings ToggleOpenCover(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCover = !toolSettings.OpenCover;
            return toolSettings;
        }
        #endregion
        #region DynamicCodeCoverage
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.DynamicCodeCoverage"/>.</em></p><p>Reads input as the CodeCoverage.exe xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetDynamicCodeCoverage(this CoverallsNetSettings toolSettings, bool? dynamicCodeCoverage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = dynamicCodeCoverage;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.DynamicCodeCoverage"/>.</em></p><p>Reads input as the CodeCoverage.exe xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetDynamicCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="CoverallsNetSettings.DynamicCodeCoverage"/>.</em></p><p>Reads input as the CodeCoverage.exe xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings EnableDynamicCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="CoverallsNetSettings.DynamicCodeCoverage"/>.</em></p><p>Reads input as the CodeCoverage.exe xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings DisableDynamicCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="CoverallsNetSettings.DynamicCodeCoverage"/>.</em></p><p>Reads input as the CodeCoverage.exe xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings ToggleDynamicCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicCodeCoverage = !toolSettings.DynamicCodeCoverage;
            return toolSettings;
        }
        #endregion
        #region ExportCodeCoverage
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.ExportCodeCoverage"/>.</em></p><p>Reads input as the Visual Studio Coverage Export xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetExportCodeCoverage(this CoverallsNetSettings toolSettings, bool? exportCodeCoverage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = exportCodeCoverage;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.ExportCodeCoverage"/>.</em></p><p>Reads input as the Visual Studio Coverage Export xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetExportCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="CoverallsNetSettings.ExportCodeCoverage"/>.</em></p><p>Reads input as the Visual Studio Coverage Export xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings EnableExportCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="CoverallsNetSettings.ExportCodeCoverage"/>.</em></p><p>Reads input as the Visual Studio Coverage Export xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings DisableExportCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="CoverallsNetSettings.ExportCodeCoverage"/>.</em></p><p>Reads input as the Visual Studio Coverage Export xml format.</p></summary>
        [Pure]
        public static CoverallsNetSettings ToggleExportCodeCoverage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportCodeCoverage = !toolSettings.ExportCodeCoverage;
            return toolSettings;
        }
        #endregion
        #region Monocov
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.Monocov"/>.</em></p><p>Reads input as monocov results folder.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetMonocov(this CoverallsNetSettings toolSettings, bool? monocov)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = monocov;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.Monocov"/>.</em></p><p>Reads input as monocov results folder.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetMonocov(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="CoverallsNetSettings.Monocov"/>.</em></p><p>Reads input as monocov results folder.</p></summary>
        [Pure]
        public static CoverallsNetSettings EnableMonocov(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="CoverallsNetSettings.Monocov"/>.</em></p><p>Reads input as monocov results folder.</p></summary>
        [Pure]
        public static CoverallsNetSettings DisableMonocov(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="CoverallsNetSettings.Monocov"/>.</em></p><p>Reads input as monocov results folder.</p></summary>
        [Pure]
        public static CoverallsNetSettings ToggleMonocov(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Monocov = !toolSettings.Monocov;
            return toolSettings;
        }
        #endregion
        #region RepoToken
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.RepoToken"/>.</em></p><p>The coveralls.io repository token.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetRepoToken(this CoverallsNetSettings toolSettings, string repoToken)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoToken = repoToken;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.RepoToken"/>.</em></p><p>The coveralls.io repository token.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetRepoToken(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoToken = null;
            return toolSettings;
        }
        #endregion
        #region RepoTokenVariable
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.RepoTokenVariable"/>.</em></p><p>The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetRepoTokenVariable(this CoverallsNetSettings toolSettings, string repoTokenVariable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoTokenVariable = repoTokenVariable;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.RepoTokenVariable"/>.</em></p><p>The Environment Variable name where the coveralls.io repository token is available. Default is <c>COVERALLS_REPO_TOKEN</c>.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetRepoTokenVariable(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoTokenVariable = null;
            return toolSettings;
        }
        #endregion
        #region CommitId
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.CommitId"/>.</em></p><p>The git commit hash for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetCommitId(this CoverallsNetSettings toolSettings, string commitId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitId = commitId;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.CommitId"/>.</em></p><p>The git commit hash for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetCommitId(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitId = null;
            return toolSettings;
        }
        #endregion
        #region CommitBranch
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.CommitBranch"/>.</em></p><p>The git branch for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetCommitBranch(this CoverallsNetSettings toolSettings, string commitBranch)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitBranch = commitBranch;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.CommitBranch"/>.</em></p><p>The git branch for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetCommitBranch(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitBranch = null;
            return toolSettings;
        }
        #endregion
        #region CommitAuthor
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.CommitAuthor"/>.</em></p><p>The git commit author for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetCommitAuthor(this CoverallsNetSettings toolSettings, string commitAuthor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitAuthor = commitAuthor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.CommitAuthor"/>.</em></p><p>The git commit author for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetCommitAuthor(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitAuthor = null;
            return toolSettings;
        }
        #endregion
        #region CommitEmail
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.CommitEmail"/>.</em></p><p>The git commit author email for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetCommitEmail(this CoverallsNetSettings toolSettings, string commitEmail)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitEmail = commitEmail;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.CommitEmail"/>.</em></p><p>The git commit author email for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetCommitEmail(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitEmail = null;
            return toolSettings;
        }
        #endregion
        #region CommitMessage
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.CommitMessage"/>.</em></p><p>The git commit message for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetCommitMessage(this CoverallsNetSettings toolSettings, string commitMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitMessage = commitMessage;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.CommitMessage"/>.</em></p><p>The git commit message for the coverage report.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetCommitMessage(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitMessage = null;
            return toolSettings;
        }
        #endregion
        #region JobId
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.JobId"/>.</em></p><p>The job Id to provide to coveralls.io. Default is <c>0</c>.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetJobId(this CoverallsNetSettings toolSettings, int? jobId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JobId = jobId;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.JobId"/>.</em></p><p>The job Id to provide to coveralls.io. Default is <c>0</c>.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetJobId(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JobId = null;
            return toolSettings;
        }
        #endregion
        #region ServiceName
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.ServiceName"/>.</em></p><p>The service-name for the coverage report. Default is <c>coveralls.net</c>.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetServiceName(this CoverallsNetSettings toolSettings, string serviceName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceName = serviceName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.ServiceName"/>.</em></p><p>The service-name for the coverage report. Default is <c>coveralls.net</c>.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetServiceName(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceName = null;
            return toolSettings;
        }
        #endregion
        #region PullRequest
        /// <summary><p><em>Sets <see cref="CoverallsNetSettings.PullRequest"/>.</em></p><p>The github pull request id. Used for updating status on github PRs.</p></summary>
        [Pure]
        public static CoverallsNetSettings SetPullRequest(this CoverallsNetSettings toolSettings, int? pullRequest)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequest = pullRequest;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="CoverallsNetSettings.PullRequest"/>.</em></p><p>The github pull request id. Used for updating status on github PRs.</p></summary>
        [Pure]
        public static CoverallsNetSettings ResetPullRequest(this CoverallsNetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequest = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
