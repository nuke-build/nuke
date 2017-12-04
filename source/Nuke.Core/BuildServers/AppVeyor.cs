// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://www.appveyor.com/docs/environment-variables/">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    public class AppVeyor
    {
        [CanBeNull]
        public static AppVeyor Instance { get; } = NukeBuild.Instance?.Host == HostType.AppVeyor ? new AppVeyor() : null;

        internal static bool IsRunningAppVeyor => Variable("APPVEYOR") != null;

        internal AppVeyor ()
        {
        }

        public string ApiUrl => EnsureVariable("APPVEYOR_API_URL");
        public string AccountName => EnsureVariable("APPVEYOR_ACCOUNT_NAME");
        public int ProjectId => EnsureVariable<int>("APPVEYOR_PROJECT_ID");
        public string ProjectName => EnsureVariable("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => EnsureVariable("APPVEYOR_PROJECT_SLUG");
        public string BuildFolder => EnsureVariable("APPVEYOR_BUILD_FOLDER");
        public int BuildId => EnsureVariable<int>("APPVEYOR_BUILD_ID");
        public int BuildNumber => EnsureVariable<int>("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => EnsureVariable("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => EnsureVariable("APPVEYOR_BUILD_WORKER_IMAGE");
        public int PullRequestNumber => EnsureVariable<int>("APPVEYOR_PULL_REQUEST_NUMBER");
        public string PullRequestTitle => EnsureVariable("APPVEYOR_PULL_REQUEST_TITLE");
        public int JobId => EnsureVariable<int>("APPVEYOR_JOB_ID");
        public string JobName => EnsureVariable("APPVEYOR_JOB_NAME");
        public string JobNumber => EnsureVariable("APPVEYOR_JOB_NUMBER");
        public string RepositoryProvider => EnsureVariable("APPVEYOR_REPO_PROVIDER");
        public string RepositoryScm => EnsureVariable("APPVEYOR_REPO_SCM");
        public string RepositoryName => EnsureVariable("APPVEYOR_REPO_NAME");
        public string RepositoryBranch => EnsureVariable("APPVEYOR_REPO_BRANCH");
        public bool RepositoryTag => EnsureVariable<bool>("APPVEYOR_REPO_TAG");
        public string RepositoryTagName => EnsureVariable("APPVEYOR_REPO_TAG_NAME");
        public string RepositoryCommitSha => EnsureVariable("APPVEYOR_REPO_COMMIT");
        public string RepositoryCommitAuthor => EnsureVariable("APPVEYOR_REPO_COMMIT_AUTHOR");
        public string RepositoryCommitAuthorEmail => EnsureVariable("APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL");
        public string RepositoryCommitTimestamp => EnsureVariable("APPVEYOR_REPO_COMMIT_TIMESTAMP");
        public string RepositoryCommitMessage => EnsureVariable("APPVEYOR_REPO_COMMIT_MESSAGE");
        public string RepositoryCommitMessageExtended => EnsureVariable("APPVEYOR_REPO_COMMIT_MESSAGE_EXTENDED");
        public bool ScheduledBuild => EnsureVariable<bool>("APPVEYOR_SCHEDULED_BUILD");
        public bool ForcedBuild => EnsureVariable<bool>("APPVEYOR_FORCED_BUILD");
        public bool Rebuild => EnsureVariable<bool>("APPVEYOR_RE_BUILD");
        public string Platform => EnsureVariable("PLATFORM");
        public string Configuration => EnsureVariable("CONFIGURATION");
    }
}
