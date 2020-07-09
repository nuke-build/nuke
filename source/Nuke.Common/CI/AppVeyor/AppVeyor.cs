// Copyright 2019 Maintainers of NUKE.
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
    [CI]
    [ExcludeFromCodeCoverage]
    public class AppVeyor
    {
        private static Lazy<AppVeyor> s_instance = new Lazy<AppVeyor>(() => new AppVeyor());

        public static AppVeyor Instance => NukeBuild.Host == HostType.AppVeyor ? s_instance.Value : null;

        internal static bool IsRunningAppVeyor => !Environment.GetEnvironmentVariable("APPVEYOR").IsNullOrEmpty();

        internal AppVeyor()
        {
            _cli = ToolResolver.GetPathTool("appveyor");
        }

        private readonly Tool _cli;

        public string Url => EnvironmentInfo.GetVariable<string>("APPVEYOR_URL");
        public string ApiUrl => EnvironmentInfo.GetVariable<string>("APPVEYOR_API_URL");
        public string AccountName => EnvironmentInfo.GetVariable<string>("APPVEYOR_ACCOUNT_NAME");
        public int ProjectId => EnvironmentInfo.GetVariable<int>("APPVEYOR_PROJECT_ID");
        public string ProjectName => EnvironmentInfo.GetVariable<string>("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => EnvironmentInfo.GetVariable<string>("APPVEYOR_PROJECT_SLUG");
        public string BuildFolder => EnvironmentInfo.GetVariable<string>("APPVEYOR_BUILD_FOLDER");
        public int BuildId => EnvironmentInfo.GetVariable<int>("APPVEYOR_BUILD_ID");
        public int BuildNumber => EnvironmentInfo.GetVariable<int>("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => EnvironmentInfo.GetVariable<string>("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => EnvironmentInfo.GetVariable<string>("APPVEYOR_BUILD_WORKER_IMAGE");
        public int PullRequestNumber => EnvironmentInfo.GetVariable<int>("APPVEYOR_PULL_REQUEST_NUMBER");
        [CanBeNull] public string PullRequestTitle => EnvironmentInfo.GetVariable<string>("APPVEYOR_PULL_REQUEST_TITLE");
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
        [CanBeNull] public string Platform => EnvironmentInfo.GetVariable<string>("PLATFORM");
        [CanBeNull] public string Configuration => EnvironmentInfo.GetVariable<string>("CONFIGURATION");

        public void UpdateBuildVersion(string version)
        {
            _cli.Invoke($"UpdateBuild -Version {version.DoubleQuote()}");
            EnvironmentInfo.SetVariable("APPVEYOR_BUILD_VERSION", version);
        }

        public void PushArtifact(string path, string name = null)
        {
            name ??= Path.GetFileName(path);
            _cli.Invoke($"PushArtifact {path} -FileName {name}");
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
            _cli.Invoke($"AddMessage {message.DoubleQuote()} -Category {category} -Details {details.DoubleQuote()}",
                logInvocation: false,
                logOutput: false);
        }
    }
}
