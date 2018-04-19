// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.EnvironmentInfo;

namespace Nuke.Common.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://www.appveyor.com/docs/environment-variables/">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    public class AppVeyor
    {
        private static Lazy<AppVeyor> s_instance = new Lazy<AppVeyor>(() => new AppVeyor());

        public static AppVeyor Instance => NukeBuild.Instance?.Host == HostType.AppVeyor ? s_instance.Value : null;

        internal static bool IsRunningAppVeyor => Variable("APPVEYOR") != null;

        internal AppVeyor()
        {
        }

        public string ApiUrl => Variable("APPVEYOR_API_URL");
        public string AccountName => Variable("APPVEYOR_ACCOUNT_NAME");
        public int ProjectId => Variable<int>("APPVEYOR_PROJECT_ID");
        public string ProjectName => Variable("APPVEYOR_PROJECT_NAME");
        public string ProjectSlug => Variable("APPVEYOR_PROJECT_SLUG");
        public string BuildFolder => Variable("APPVEYOR_BUILD_FOLDER");
        public int BuildId => Variable<int>("APPVEYOR_BUILD_ID");
        public int BuildNumber => Variable<int>("APPVEYOR_BUILD_NUMBER");
        public string BuildVersion => Variable("APPVEYOR_BUILD_VERSION");
        public string BuildWorkerImage => Variable("APPVEYOR_BUILD_WORKER_IMAGE");
        public int PullRequestNumber => Variable<int>("APPVEYOR_PULL_REQUEST_NUMBER");
        public string PullRequestTitle => Variable("APPVEYOR_PULL_REQUEST_TITLE");
        public int JobId => Variable<int>("APPVEYOR_JOB_ID");
        public string JobName => Variable("APPVEYOR_JOB_NAME");
        public string JobNumber => Variable("APPVEYOR_JOB_NUMBER");
        public string RepositoryProvider => Variable("APPVEYOR_REPO_PROVIDER");
        public string RepositoryScm => Variable("APPVEYOR_REPO_SCM");
        public string RepositoryName => Variable("APPVEYOR_REPO_NAME");
        public string RepositoryBranch => Variable("APPVEYOR_REPO_BRANCH");
        public bool RepositoryTag => Variable<bool>("APPVEYOR_REPO_TAG");
        public string RepositoryTagName => Variable("APPVEYOR_REPO_TAG_NAME");
        public string RepositoryCommitSha => Variable("APPVEYOR_REPO_COMMIT");
        public string RepositoryCommitAuthor => Variable("APPVEYOR_REPO_COMMIT_AUTHOR");
        public string RepositoryCommitAuthorEmail => Variable("APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL");
        public string RepositoryCommitTimestamp => Variable("APPVEYOR_REPO_COMMIT_TIMESTAMP");
        public string RepositoryCommitMessage => Variable("APPVEYOR_REPO_COMMIT_MESSAGE");
        public string RepositoryCommitMessageExtended => Variable("APPVEYOR_REPO_COMMIT_MESSAGE_EXTENDED");
        public bool ScheduledBuild => Variable<bool>("APPVEYOR_SCHEDULED_BUILD");
        public bool ForcedBuild => Variable<bool>("APPVEYOR_FORCED_BUILD");
        public bool Rebuild => Variable<bool>("APPVEYOR_RE_BUILD");
        public string Platform => Variable("PLATFORM");
        public string Configuration => Variable("CONFIGURATION");
    }
}
