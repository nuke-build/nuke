// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.OutputSinks;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AppVeyor
{
    // [PublicAPI]
    // [Headers("Accept: application/json")]
    // public interface IAppVeyorRestClient
    // {
    //     [Post("/api/build/messages")]
    //     Task WriteMessage(AppVeyorMessageCategory category, string message, string details = "");
    // }
    //

    /// <summary>
    /// Interface according to the <a href="https://www.appveyor.com/docs/environment-variables/">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class AppVeyor : IBuildServer
    {
        private static Lazy<AppVeyor> s_instance = new Lazy<AppVeyor>(() => new AppVeyor());

        public static AppVeyor Instance => NukeBuild.Host == HostType.AppVeyor ? s_instance.Value : null;

        internal static bool IsRunningAppVeyor => !Environment.GetEnvironmentVariable("APPVEYOR").IsNullOrEmpty();

        internal AppVeyor()
        {
            _cli = ToolResolver.GetPathTool("appveyor");
        }

        private readonly Tool _cli;

        public string ApiUrl => EnvironmentInfo.GetVariable<string>("APPVEYOR_API_URL");
        public string AccountName => EnvironmentInfo.GetVariable<string>("APPVEYOR_ACCOUNT_NAME");
        public int ProjectId => EnvironmentInfo.GetVariable<int>("APPVEYOR_PROJECT_ID");
        public string ProjectName => EnvironmentInfo.GetVariable<string>("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => EnvironmentInfo.GetVariable<string>("APPVEYOR_PROJECT_SLUG");
        public AbsolutePath BuildFolder => EnvironmentInfo.GetVariable<AbsolutePath>("APPVEYOR_BUILD_FOLDER");
        public int BuildId => EnvironmentInfo.GetVariable<int>("APPVEYOR_BUILD_ID");
        [NoConvert] public string BuildNumber => EnvironmentInfo.GetVariable<string>("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => EnvironmentInfo.GetVariable<string>("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => EnvironmentInfo.GetVariable<string>("APPVEYOR_BUILD_WORKER_IMAGE");
        public int? PullRequestNumber => EnvironmentInfo.GetVariable<int?>("APPVEYOR_PULL_REQUEST_NUMBER");
        [CanBeNull] public string PullRequestTitle => EnvironmentInfo.GetVariable<string>("APPVEYOR_PULL_REQUEST_TITLE");
        [CanBeNull] public string PullRequestRepoName  => EnvironmentInfo.GetVariable<string>("APPVEYOR_PULL_REQUEST_HEAD_REPO_NAME");
        [CanBeNull] public string PullRequestRepoBranch  => EnvironmentInfo.GetVariable<string>("APPVEYOR_PULL_REQUEST_HEAD_REPO_BRANCH");
        [CanBeNull] public string PullRequestRepoCommit  => EnvironmentInfo.GetVariable<string>("APPVEYOR_PULL_REQUEST_HEAD_COMMIT");
        public string JobId => EnvironmentInfo.GetVariable<string>("APPVEYOR_JOB_ID");
        [CanBeNull] public string JobName => EnvironmentInfo.GetVariable<string>("APPVEYOR_JOB_NAME");
        public int JobNumber => EnvironmentInfo.GetVariable<int>("APPVEYOR_JOB_NUMBER");
        public string RepositoryProvider => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_PROVIDER");
        public string RepositoryScm => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_SCM");
        public string RepositoryName => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_NAME");
        public string RepositoryBranch => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_BRANCH");
        public bool RepositoryTag => EnvironmentInfo.GetVariable<bool>("APPVEYOR_REPO_TAG");
        [CanBeNull] public string RepositoryTagName => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_TAG_NAME");
        public string RepositoryCommitSha => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_COMMIT");
        public string RepositoryCommitAuthor => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_COMMIT_AUTHOR");
        public string RepositoryCommitAuthorEmail => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL");
        public DateTime RepositoryCommitTimestamp => EnvironmentInfo.GetVariable<DateTime>("APPVEYOR_REPO_COMMIT_TIMESTAMP");
        public string RepositoryCommitMessage => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_COMMIT_MESSAGE");
        [CanBeNull] public string RepositoryCommitMessageExtended => EnvironmentInfo.GetVariable<string>("APPVEYOR_REPO_COMMIT_MESSAGE_EXTENDED");
        public bool ScheduledBuild => EnvironmentInfo.GetVariable<bool>("APPVEYOR_SCHEDULED_BUILD");
        public bool ForcedBuild => EnvironmentInfo.GetVariable<bool>("APPVEYOR_FORCED_BUILD");
        public bool Rebuild => EnvironmentInfo.GetVariable<bool>("APPVEYOR_RE_BUILD");
        public bool RebuildIncomplete => EnvironmentInfo.GetVariable<bool>("APPVEYOR_RE_RUN_INCOMPLETE");
        [CanBeNull] public string Platform => EnvironmentInfo.GetVariable<string>("PLATFORM");
        [CanBeNull] public string Configuration => EnvironmentInfo.GetVariable<string>("CONFIGURATION");

        public void UpdateBuildNumber(string version)
        {
            _cli.Invoke($"UpdateBuild -Version {version.DoubleQuote()}");
        }

        public void WriteInformation(string message, string details = null)
        {
            WriteMessage(AppVeyorMessageCategory.Information, message, details);
        }

        public void WriteWarning(string message, string details = null)
        {
            WriteMessage(AppVeyorMessageCategory.Warning, message, details);
        }

        public void WriteError(string message, string details = null)
        {
            WriteMessage(AppVeyorMessageCategory.Error, message, details);
        }

        public void PushArtifact(AbsolutePath path, string fileName = null, string deploymentName = null, AppVeyorArtifactType? type = null, AppVeyorVerbosity? verbosity = null)
        {
            WriteCommand("PushArtifact", path, o => o
                .AddPairWhenValueNotNull("FileName", fileName)
                .AddPairWhenValueNotNull("DeploymentName", deploymentName)
                .AddPairWhenValueNotNull("Type", type)
                .AddPairWhenValueNotNull("Verbosity", verbosity)
            );
        }

        public void SetEnvironmentVariable(string name, string value)
        {
            WriteCommand("SetVariable", dictionaryConfigurator: o => o
                .AddPair("Name", name)
                .AddPair("Value", value)
            );
        }

        public void WriteCompilationWarning(
            string message,
            string details = null,
            string fileName = null,
            int? line = null,
            int? column = null,
            string projectName = null,
            AbsolutePath projectFileName = null)
        {
            WriteCompilationMessage(AppVeyorMessageCategory.Warning, message, fileName, line, column, projectName, projectFileName);
        }

        public void WriteCompilationError(
            string message,
            string details = null,
            string fileName = null,
            int? line = null,
            int? column = null,
            string projectName = null,
            AbsolutePath projectFileName = null)
        {
            WriteCompilationMessage(AppVeyorMessageCategory.Error, message, fileName, line, column, projectName, projectFileName);
        }

        private void WriteMessage(AppVeyorMessageCategory category, string message, string details = null)
        {
            WriteCommand("AddMessage", dictionaryConfigurator: c => c
                .AddPairWhenValueNotNull("Message", message)
                .AddPairWhenValueNotNull("Details", details)
            );
        }

        private void WriteCompilationMessage(
            AppVeyorMessageCategory category,
            string message,
            string fileName = null,
            int? line = null,
            int? column = null,
            string projectName = null,
            AbsolutePath projectFileName = null
            )
        {
            message = string.IsNullOrWhiteSpace(message) ? null : message;
            fileName = string.IsNullOrWhiteSpace(fileName) ? null : fileName;
            projectName = string.IsNullOrWhiteSpace(projectName) ? null : projectName;
            WriteCommand("AddCompilationMessage", dictionaryConfigurator: c => c
                .AddPairWhenValueNotNull("Message", message)
                .AddPairWhenValueNotNull("FileName", fileName)
                .AddPairWhenValueNotNull("Line", line)
                .AddPairWhenValueNotNull("Column", column)
                .AddPairWhenValueNotNull("ProjectName", projectName)
                .AddPairWhenValueNotNull("ProjectFileName ", projectFileName)
            );
        }

        private void WriteCommand(string command, string arg0 = null, Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator = null)
        {
            var escapedTokens =
                dictionaryConfigurator?
                    .Invoke(new Dictionary<string, object>())
                    .Select(x => $"-{x.Key} {x.Value.ToString()?.DoubleQuote()}").ToArray()
                ?? new string[0];

            var cmd = $"{command} {arg0?.DoubleQuote()}".TrimEnd();
            _cli.Invoke($"{cmd} {escapedTokens.JoinSpace()}",
                logInvocation: true,
                logOutput: true);    
        }

        #region IBuildServer
        HostType IBuildServer.Host => HostType.AppVeyor;
        string IBuildServer.BuildNumber => BuildNumber;
        AbsolutePath IBuildServer.SourceDirectory => BuildFolder;
        AbsolutePath IBuildServer.OutputDirectory => null;
        string IBuildServer.SourceBranch => string.IsNullOrWhiteSpace(PullRequestRepoBranch) ? RepositoryBranch : PullRequestRepoBranch;
        string IBuildServer.TargetBranch => string.IsNullOrWhiteSpace(PullRequestRepoBranch) ? null : RepositoryBranch;

        void IBuildServer.IssueWarning(string message, string file, int? line, int? column, string code)
        {
            WriteCompilationWarning(message, fileName: file, line: line, column: column);
        }

        void IBuildServer.IssueError(string message, string file, int? line, int? column, string code)
        {
            WriteCompilationError(message, fileName: file, line: line, column: column);
        }

        void IBuildServer.SetOutputParameter(string name, string value)
        {
            Logger.Trace("Writing Output Paramteres is not supported by {0}", ((IBuildServer) this ).Host.ToString());
        }

        void IBuildServer.PublishArtifact(AbsolutePath artifactPath)
        {
            PushArtifact(artifactPath);
        }

        void IBuildServer.UpdateBuildNumber(string buildNumber)
        {
            UpdateBuildNumber($"{buildNumber}.build.{BuildNumber}");
        }
        #endregion
    }
}
