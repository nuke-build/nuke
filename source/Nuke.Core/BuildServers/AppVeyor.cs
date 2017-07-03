// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://www.appveyor.com/docs/environment-variables/">official website</a>.
    /// </summary>
    [BuildServer]
    public class AppVeyor
    {
        [CanBeNull]
        public static AppVeyor Instance => EnvironmentInfo.Variable("APPVEYOR") != null ? new AppVeyor() : null;

        private AppVeyor ()
        {
        }

        public string ApiUrl => EnvironmentInfo.EnsureVariable("APPVEYOR_API_URL");
        public string AccountName => EnvironmentInfo.EnsureVariable("APPVEYOR_ACCOUNT_NAME");
        public int ProjectId => EnvironmentInfo.EnsureVariable<int>("APPVEYOR_PROJECT_ID");
        public string ProjectName => EnvironmentInfo.EnsureVariable("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => EnvironmentInfo.EnsureVariable("APPVEYOR_PROJECT_SLUG");
        public string BuildFolder => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_FOLDER");
        public int BuildId => EnvironmentInfo.EnsureVariable<int>("APPVEYOR_BUILD_ID");
        public int BuildNumber => EnvironmentInfo.EnsureVariable<int>("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_WORKER_IMAGE");
        public int PullRequestNumber => EnvironmentInfo.EnsureVariable<int>("APPVEYOR_PULL_REQUEST_NUMBER");
        public string PullRequestTitle => EnvironmentInfo.EnsureVariable("APPVEYOR_PULL_REQUEST_TITLE");
        public int JobId => EnvironmentInfo.EnsureVariable<int>("APPVEYOR_JOB_ID");
        public string JobName => EnvironmentInfo.EnsureVariable("APPVEYOR_JOB_NAME");
        public string JobNumber => EnvironmentInfo.EnsureVariable("APPVEYOR_JOB_NUMBER");
        public string RepositoryProvider => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_PROVIDER");
        public string RepositoryScm => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_SCM");
        public string RepositoryName => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_NAME");
        public string RepositoryBranch => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_BRANCH");
        public bool RepositoryTag => EnvironmentInfo.EnsureVariable<bool>("APPVEYOR_REPO_TAG");
        public string RepositoryTagName => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_TAG_NAME");
        public string RepositoryCommitSha => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT");
        public string RepositoryCommitAuthor => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_AUTHOR");
        public string RepositoryCommitAuthorEmail => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL");
        public string RepositoryCommitTimestamp => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_TIMESTAMP");
        public string RepositoryCommitMessage => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_MESSAGE");
        public string RepositoryCommitMessageExtended => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_MESSAGE_EXTENDED");
        public bool ScheduledBuild => EnvironmentInfo.EnsureVariable<bool>("APPVEYOR_SCHEDULED_BUILD");
        public bool ForcedBuild => EnvironmentInfo.EnsureVariable<bool>("APPVEYOR_FORCED_BUILD");
        public bool Rebuild => EnvironmentInfo.EnsureVariable<bool>("APPVEYOR_RE_BUILD");
        public string Platform => EnvironmentInfo.EnsureVariable("PLATFORM");
        public string Configuration => EnvironmentInfo.EnsureVariable("CONFIGURATION");
    }
}
