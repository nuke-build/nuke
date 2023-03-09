// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitLab
{
    /// <summary>
    ///     Interface according to the <a href="https://docs.gitlab.com/ce/ci/variables/README.html">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public partial class GitLab : Host, IBuildServer
    {
        public new static GitLab Instance => Host.Instance as GitLab;

        internal static bool IsRunningGitLab => EnvironmentInfo.HasVariable("GITLAB_CI");

        private const string SectionStartSequence = "\u001b[0K";
        private const string SectionResetSequence = "\r\u001b[0K";

        private readonly Action<string> _messageSink;

        internal GitLab()
            : this(messageSink: null)
        {
        }

        internal GitLab(Action<string> messageSink)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        string IBuildServer.Branch => CommitRefName;
        string IBuildServer.Commit => CommitSha;

        public void BeginSection(string text, bool collapsed = true)
        {
            var sectionId = GetSectionId(text);
            var unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            _messageSink($"{SectionStartSequence}section_start:{unixTimestamp}:{sectionId}[collapsed={collapsed.ToString().ToLowerInvariant()}]{SectionResetSequence}{text}");
        }

        public void EndSection(string text)
        {
            var sectionId = GetSectionId(text);
            var unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            _messageSink($"{SectionStartSequence}section_end:{unixTimestamp}:{sectionId}{SectionResetSequence}");
        }

        private string GetSectionId(string text)
        {
            return text.GetMD5Hash();
        }

        /// <summary>
        /// Mark that job is executed in CI environment.
        /// </summary>
        public bool Ci => EnvironmentInfo.GetVariable<bool>("CI");

        /// <summary>
        /// The branch or tag name for which project is built.
        /// </summary>
        public string CommitRefName => EnvironmentInfo.GetVariable("CI_COMMIT_REF_NAME");

        /// <summary>
        /// <c>$CI_COMMIT_REF_NAME</c> lowercased, shortened to 63 bytes, and with everything except <c>0-9</c> and <c>a-z</c> replaced with <c>-</c>. No leading / trailing <c>-</c>. Use in URLs, host names and domain names.
        /// </summary>
        public string CommitRefSlug => EnvironmentInfo.GetVariable("CI_COMMIT_REF_SLUG");

        /// <summary>
        /// The commit revision for which project is built.
        /// </summary>
        public string CommitSha => EnvironmentInfo.GetVariable("CI_COMMIT_SHA");

        /// <summary>
        /// The commit tag name. Present only when building tags.
        /// </summary>
        [CanBeNull] public string CommitTag => EnvironmentInfo.GetVariable("CI_COMMIT_TAG");

        /// <summary>
        /// The path to CI config file. Defaults to <c>.gitlab-ci.yml</c>.
        /// </summary>
        public string ConfigPath => EnvironmentInfo.GetVariable("CI_CONFIG_PATH");

        /// <summary>
        /// Marks that the job is executed in a disposable environment (something that is created only for this job and disposed of/destroyed after the execution - all executors except <c>shell</c> and <c>ssh</c>). If the environment is disposable, it is set to true, otherwise it is not defined at all.
        /// </summary>
        public bool DisposableEnvironment => EnvironmentInfo.GetVariable<bool>("CI_DISPOSABLE_ENVIRONMENT");

        /// <summary>
        /// The unique id of the current job that GitLab CI uses internally.
        /// </summary>
        public long JobId => EnvironmentInfo.GetVariable<long>("CI_JOB_ID");

        /// <summary>
        /// The flag to indicate that job was manually started.
        /// </summary>
        public bool JobManual => EnvironmentInfo.GetVariable<bool>("CI_JOB_MANUAL");

        /// <summary>
        /// The name of the job as defined in <c>.gitlab-ci.yml</c>.
        /// </summary>
        public string JobName => EnvironmentInfo.GetVariable("CI_JOB_NAME");

        /// <summary>
        /// The name of the stage as defined in <c>.gitlab-ci.yml</c>.
        /// </summary>
        public string JobStage => EnvironmentInfo.GetVariable("CI_JOB_STAGE");

        /// <summary>
        /// Token used for authenticating with the GitLab Container Registry.
        /// </summary>
        public string JobToken => EnvironmentInfo.GetVariable("CI_JOB_TOKEN");

        /// <summary>
        /// The URL to clone the Git repository.
        /// </summary>
        public string RepositoryUrl => EnvironmentInfo.GetVariable("CI_REPOSITORY_URL");

        /// <summary>
        /// The description of the runner as saved in GitLab.
        /// </summary>
        public string RunnerDescription => EnvironmentInfo.GetVariable("CI_RUNNER_DESCRIPTION");

        /// <summary>
        /// The unique id of runner being used.
        /// </summary>
        public long RunnerId => EnvironmentInfo.GetVariable<long>("CI_RUNNER_ID");

        /// <summary>
        /// The defined runner tags.
        /// </summary>
        public string RunnerTags => EnvironmentInfo.GetVariable("CI_RUNNER_TAGS");

        /// <summary>
        /// The unique id of the current pipeline that GitLab CI uses internally.
        /// </summary>
        public long PipelineId => EnvironmentInfo.GetVariable<long>("CI_PIPELINE_ID");

        /// <summary>
        /// The flag to indicate that job was <a href="https://docs.gitlab.com/ce/ci/triggers/README.html">triggered</a>.
        /// </summary>
        public bool PipelineTriggered => EnvironmentInfo.GetVariable<bool>("CI_PIPELINE_TRIGGERED");

        /// <summary>
        /// The source for this pipeline, one of: push, web, trigger, schedule, api, external. Pipelines created before 9.5 will have unknown as source.
        /// </summary>
        public string PipelineSource => EnvironmentInfo.GetVariable("CI_PIPELINE_SOURCE");

        /// <summary>
        /// The full path where the repository is cloned and where the job is run.
        /// </summary>
        public string ProjectDirectory => EnvironmentInfo.GetVariable("CI_PROJECT_DIR");

        /// <summary>
        /// The unique id of the current project that GitLab CI uses internally.
        /// </summary>
        public long ProjectId => EnvironmentInfo.GetVariable<long>("CI_PROJECT_ID");

        /// <summary>
        /// The project name that is currently being built (actually it is project folder name).
        /// </summary>
        public string ProjectName => EnvironmentInfo.GetVariable("CI_PROJECT_NAME");

        /// <summary>
        /// The project namespace (username or groupname) that is currently being built.
        /// </summary>
        public string ProjectNamespace => EnvironmentInfo.GetVariable("CI_PROJECT_NAMESPACE");

        /// <summary>
        /// The namespace with project name.
        /// </summary>
        public string ProjectPath => EnvironmentInfo.GetVariable("CI_PROJECT_PATH");

        /// <summary>
        /// <c>$CI_PROJECT_PATH</c> lowercased and with everything except <c>0-9</c> and <c>a-z</c> replaced with <c>-</c>. Use in URLs and domain names.
        /// </summary>
        public string ProjectPathSlug => EnvironmentInfo.GetVariable("CI_PROJECT_PATH_SLUG");

        /// <summary>
        /// The HTTP address to access project.
        /// </summary>
        public string ProjectUrl => EnvironmentInfo.GetVariable("CI_PROJECT_URL");

        /// <summary>
        /// The project visibility (internal, private, public).
        /// </summary>
        public GitLabProjectVisibility ProjectVisibility => EnvironmentInfo.GetVariable<GitLabProjectVisibility>("CI_PROJECT_VISIBILITY");

        /// <summary>
        /// If the Container Registry is enabled it returns the address of GitLab's Container Registry.
        /// </summary>
        public string Registry => EnvironmentInfo.GetVariable("CI_REGISTRY");

        /// <summary>
        /// If the Container Registry is enabled for the project it returns the address of the registry tied to the specific project.
        /// </summary>
        public string RegistryImage => EnvironmentInfo.GetVariable("CI_REGISTRY_IMAGE");

        /// <summary>
        /// The password to use to push containers to the GitLab Container Registry.
        /// </summary>
        public string RegistryPassword => EnvironmentInfo.GetVariable("CI_REGISTRY_PASSWORD");

        /// <summary>
        /// The username to use to push containers to the GitLab Container Registry.
        /// </summary>
        public string RegistryUser => EnvironmentInfo.GetVariable("CI_REGISTRY_USER");

        /// <summary>
        /// The name of CI server that is used to coordinate jobs.
        /// </summary>
        public string ServerName => EnvironmentInfo.GetVariable("CI_SERVER_NAME");

        /// <summary>
        /// GitLab revision that is used to schedule jobs.
        /// </summary>
        public string ServerRevision => EnvironmentInfo.GetVariable("CI_SERVER_REVISION");

        /// <summary>
        /// GitLab version that is used to schedule jobs.
        /// </summary>
        public string ServerVersion => EnvironmentInfo.GetVariable("CI_SERVER_VERSION");

        /// <summary>
        /// The id of the user who started the job.
        /// </summary>
        public long GitLabUserId => EnvironmentInfo.GetVariable<long>("GITLAB_USER_ID");

        /// <summary>
        /// The email of the user who started the job.
        /// </summary>
        public string GitLabUserEmail => EnvironmentInfo.GetVariable("GITLAB_USER_EMAIL");

        /// <summary>
        /// The login username of the user who started the job.
        /// </summary>
        public string GitLabUserLogin => EnvironmentInfo.GetVariable("GITLAB_USER_LOGIN");

        /// <summary>
        /// The real name of the user who started the job.
        /// </summary>
        public string GitLabUserName => EnvironmentInfo.GetVariable("GITLAB_USER_NAME");
    }
}
