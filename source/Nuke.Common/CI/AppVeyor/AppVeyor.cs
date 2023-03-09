// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

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

    [PublicAPI]
    public enum AppVeyorMessageCategory
    {
        Information,
        Warning,
        Error
    }

    /// <summary>
    /// Interface according to the <a href="https://www.appveyor.com/docs/environment-variables/">official website</a>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public partial class AppVeyor : Host, IBuildServer
    {
        public new static AppVeyor Instance => Host.Instance as AppVeyor;

        public static int MessageLimit = 500;

        internal static bool IsRunningAppVeyor => EnvironmentInfo.HasVariable("APPVEYOR");

        private readonly Lazy<Tool> _cli = Lazy.Create(() => IsRunningAppVeyor ? ToolResolver.GetEnvironmentOrPathTool("appveyor") : null);
        private int _messageCount;

        internal AppVeyor()
        {
        }

        string IBuildServer.Branch => RepositoryBranch;
        string IBuildServer.Commit => RepositoryCommitSha;

        public Tool Cli => _cli.Value;

        public string Url => EnvironmentInfo.GetVariable("APPVEYOR_URL");
        public string ApiUrl => EnvironmentInfo.GetVariable("APPVEYOR_API_URL");
        public string AccountName => EnvironmentInfo.GetVariable("APPVEYOR_ACCOUNT_NAME");
        public int ProjectId => EnvironmentInfo.GetVariable<int>("APPVEYOR_PROJECT_ID");
        public string ProjectName => EnvironmentInfo.GetVariable("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => EnvironmentInfo.GetVariable("APPVEYOR_PROJECT_SLUG");
        public string BuildFolder => EnvironmentInfo.GetVariable("APPVEYOR_BUILD_FOLDER");
        public int BuildId => EnvironmentInfo.GetVariable<int>("APPVEYOR_BUILD_ID");
        public int BuildNumber => EnvironmentInfo.GetVariable<int>("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => EnvironmentInfo.GetVariable("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => EnvironmentInfo.GetVariable("APPVEYOR_BUILD_WORKER_IMAGE");
        [CanBeNull] public int? PullRequestNumber => EnvironmentInfo.GetVariable<int?>("APPVEYOR_PULL_REQUEST_NUMBER");
        [CanBeNull] public string PullRequestTitle => EnvironmentInfo.GetVariable("APPVEYOR_PULL_REQUEST_TITLE");
        public string JobId => EnvironmentInfo.GetVariable("APPVEYOR_JOB_ID");
        [CanBeNull] public string JobName => EnvironmentInfo.GetVariable("APPVEYOR_JOB_NAME");
        public int JobNumber => EnvironmentInfo.GetVariable<int>("APPVEYOR_JOB_NUMBER");
        public string RepositoryProvider => EnvironmentInfo.GetVariable("APPVEYOR_REPO_PROVIDER");
        public string RepositoryScm => EnvironmentInfo.GetVariable("APPVEYOR_REPO_SCM");
        public string RepositoryName => EnvironmentInfo.GetVariable("APPVEYOR_REPO_NAME");
        public string RepositoryBranch => EnvironmentInfo.GetVariable("APPVEYOR_REPO_BRANCH");
        public bool RepositoryTag => EnvironmentInfo.GetVariable<bool>("APPVEYOR_REPO_TAG");
        [CanBeNull] public string RepositoryTagName => EnvironmentInfo.GetVariable("APPVEYOR_REPO_TAG_NAME");
        public string RepositoryCommitSha => EnvironmentInfo.GetVariable("APPVEYOR_REPO_COMMIT");
        public string RepositoryCommitAuthor => EnvironmentInfo.GetVariable("APPVEYOR_REPO_COMMIT_AUTHOR");
        public string RepositoryCommitAuthorEmail => EnvironmentInfo.GetVariable("APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL");
        public DateTime RepositoryCommitTimestamp => EnvironmentInfo.GetVariable<DateTime>("APPVEYOR_REPO_COMMIT_TIMESTAMP");
        public string RepositoryCommitMessage => EnvironmentInfo.GetVariable("APPVEYOR_REPO_COMMIT_MESSAGE");
        [CanBeNull] public string RepositoryCommitMessageExtended => EnvironmentInfo.GetVariable("APPVEYOR_REPO_COMMIT_MESSAGE_EXTENDED");
        public bool ScheduledBuild => EnvironmentInfo.GetVariable<bool>("APPVEYOR_SCHEDULED_BUILD");
        public bool ForcedBuild => EnvironmentInfo.GetVariable<bool>("APPVEYOR_FORCED_BUILD");
        public bool Rebuild => EnvironmentInfo.GetVariable<bool>("APPVEYOR_RE_BUILD");
        [CanBeNull] public string Platform => EnvironmentInfo.GetVariable("PLATFORM");
        [CanBeNull] public string Configuration => EnvironmentInfo.GetVariable("CONFIGURATION");

        public void UpdateBuildVersion(string version)
        {
            Cli?.Invoke($"UpdateBuild -Version {version.DoubleQuote()}");
            EnvironmentInfo.SetVariable("APPVEYOR_BUILD_VERSION", version);
        }

        public void PushArtifact(string path, string name = null)
        {
            name ??= Path.GetFileName(path);
            Cli?.Invoke($"PushArtifact {path} -FileName {name}");
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

        private void WriteMessage(AppVeyorMessageCategory category, string message, string details)
        {
            if (_messageCount == MessageLimit)
            {
                Theme.WriteWarning(
                    $"AppVeyor has a default limit of {MessageLimit} messages. " +
                    "If you're getting an exception from 'appveyor.exe' after this message, " +
                    "contact https://appveyor.com/support to resolve this issue for your account.");
            }

            _messageCount++;
            Cli?.Invoke($"AddMessage {message.DoubleQuote()} -Category {category} -Details {details.DoubleQuote()}",
                logInvocation: false,
                logOutput: false);
        }
    }
}
