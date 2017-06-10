// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    [BuildServer]
    public class AppVeyor
    {
        [CanBeNull]
        public static AppVeyor Instance => EnvironmentInfo.Variable("APPVEYOR") != null ? new AppVeyor() : null;

        private AppVeyor ()
        {
        }

        // TODO: more typing

        public string ApiUrl => EnvironmentInfo.EnsureVariable("APPVEYOR_API_URL");
        public string AccountName => EnvironmentInfo.EnsureVariable("APPVEYOR_ACCOUNT_NAME");
        public string ProjectId => EnvironmentInfo.EnsureVariable("APPVEYOR_PROJECT_ID");
        public string ProjectName => EnvironmentInfo.EnsureVariable("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => EnvironmentInfo.EnsureVariable("APPVEYOR_PROJECT_SLUG");
        public string BuildFolder => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_FOLDER");
        public string BuildId => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_ID");
        public string BuildNumber => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => EnvironmentInfo.EnsureVariable("APPVEYOR_BUILD_WORKER_IMAGE");
        public string PullRequestNumber => EnvironmentInfo.EnsureVariable("APPVEYOR_PULL_REQUEST_NUMBER");
        public string PullRequestTitle => EnvironmentInfo.EnsureVariable("APPVEYOR_PULL_REQUEST_TITLE");
        public string JobId => EnvironmentInfo.EnsureVariable("APPVEYOR_JOB_ID");
        public string JobName => EnvironmentInfo.EnsureVariable("APPVEYOR_JOB_NAME");
        public string JobNumber => EnvironmentInfo.EnsureVariable("APPVEYOR_JOB_NUMBER");
        public string RepositoryProvider => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_PROVIDER");
        public string RepositoryScm => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_SCM");
        public string RepositoryName => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_NAME");
        public string RepositoryBranch => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_BRANCH");
        public string RepositoryTag => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_TAG");
        public string RepositoryTagName => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_TAG_NAME");
        public string RepositoryCommitSha => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT");
        public string RepositoryCommitAuthor => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_AUTHOR");
        public string RepositoryCommitAuthorEmail => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL");
        public string RepositoryCommitTimestamp => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_TIMESTAMP");
        public string RepositoryCommitMessage => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_MESSAGE");
        public string RepositoryCommitMessageExtended => EnvironmentInfo.EnsureVariable("APPVEYOR_REPO_COMMIT_MESSAGE_EXTENDED");
        public string ScheduledBuild => EnvironmentInfo.EnsureVariable("APPVEYOR_SCHEDULED_BUILD");
        public string ForcedBuild => EnvironmentInfo.EnsureVariable("APPVEYOR_FORCED_BUILD");
        public string Rebuild => EnvironmentInfo.EnsureVariable("APPVEYOR_RE_BUILD");
        public string Platform => EnvironmentInfo.EnsureVariable("PLATFORM");
        public string Configuration => EnvironmentInfo.EnsureVariable("CONFIGURATION");
    }
}
