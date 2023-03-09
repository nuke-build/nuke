// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.Bitbucket
{
    /// <summary>
    /// Interface according to the <a href="https://support.atlassian.com/bitbucket-cloud/docs/variables-and-secrets/">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class Bitbucket : Host, IBuildServer
    {
        public new static Bitbucket Instance => Host.Instance as Bitbucket;

        internal static bool IsRunningBitbucket => EnvironmentInfo.HasVariable("BITBUCKET_PIPELINE_UUID");

        internal Bitbucket()
        {
        }

        string IBuildServer.Branch => Branch;
        string IBuildServer.Commit => Commit;

        /// <summary>
        /// The unique identifier for a build. It increments with each build and can be used to create unique artifact names.
        /// </summary>
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("BITBUCKET_BUILD_NUMBER");

        /// <summary>
        /// The absolute path of the directory that the repository is cloned into within the Docker container.
        /// </summary>
        public string CloneDirectory => EnvironmentInfo.GetVariable("BITBUCKET_CLONE_DIR");

        /// <summary>
        /// The commit hash of a commit that kicked off the build.
        /// </summary>
        public string Commit => EnvironmentInfo.GetVariable("BITBUCKET_COMMIT");

        /// <summary>
        /// The name of the workspace in which the repository lives.
        /// </summary>
        public string Workspace => EnvironmentInfo.GetVariable("BITBUCKET_WORKSPACE");

        /// <summary>
        /// The URL-friendly version of a repository name.
        /// </summary>
        public string RepositorySlug => EnvironmentInfo.GetVariable("BITBUCKET_REPO_SLUG");

        /// <summary>
        /// The UUID of the repository.
        /// </summary>
        public string RepositoryUuid => EnvironmentInfo.GetVariable("BITBUCKET_REPO_UUID");

        /// <summary>
        /// The full name of the repository (everything that comes after http://bitbucket.org/).
        /// </summary>
        public string RepositoryFullName => EnvironmentInfo.GetVariable("BITBUCKET_REPO_FULL_NAME");

        /// <summary>
        /// The source branch. This value is only available on branches. Not available for builds against tags, or custom pipelines.
        /// </summary>
        public string Branch => EnvironmentInfo.GetVariable("BITBUCKET_BRANCH");

        /// <summary>
        /// The tag of a commit that kicked off the build. This value is only available on tags. Not available for builds against branches.
        /// </summary>
        public string Tag => EnvironmentInfo.GetVariable("BITBUCKET_TAG");

        /// <summary>
        /// For use with Mercurial projects.
        /// </summary>
        public string Bookmark => EnvironmentInfo.GetVariable("BITBUCKET_BOOKMARK");

        /// <summary>
        /// Zero-based index of the current step in the group, for example: 0, 1, 2, … Not available outside a parallel step.
        /// </summary>
        public int ParallelStep => EnvironmentInfo.GetVariable<int>("BITBUCKET_PARALLEL_STEP");

        /// <summary>
        /// Total number of steps in the group, for example: 5. Not available outside a parallel step.
        /// </summary>
        public int ParallelStepCount => EnvironmentInfo.GetVariable<int>("BITBUCKET_PARALLEL_STEP_COUNT");

        /// <summary>
        /// The pull request ID. Only available on a pull request triggered build.
        /// </summary>
        public int PullRequestId => EnvironmentInfo.GetVariable<int>("BITBUCKET_PR_ID");

        /// <summary>
        /// The pull request destination branch (used in combination with BITBUCKET_BRANCH). Only available on a pull request triggered build.
        /// </summary>
        public string PullRequestDestinationBranch => EnvironmentInfo.GetVariable("BITBUCKET_PR_DESTINATION_BRANCH");

        /// <summary>
        /// The URL for the origin, for example: http://bitbucket.org/&lt;account&gt;/&lt;repo&gt;
        /// </summary>
        public string GitHttpOrigin => EnvironmentInfo.GetVariable("BITBUCKET_GIT_HTTP_ORIGIN");

        /// <summary>
        /// Your SSH origin, for example: git@bitbucket.org:/&lt;account&gt;/&lt;repo&gt;.git
        /// </summary>
        public string GitSshOrigin => EnvironmentInfo.GetVariable("BITBUCKET_GIT_SSH_ORIGIN");

        /// <summary>
        /// The exit code of a step, can be used in after-script sections. Values can be 0 (success) or 1 (failed)
        /// </summary>
        public string ExitCode => EnvironmentInfo.GetVariable("BITBUCKET_EXIT_CODE");

        /// <summary>
        /// The UUID of the step.
        /// </summary>
        public string StepUuid => EnvironmentInfo.GetVariable("BITBUCKET_STEP_UUID");

        /// <summary>
        ///  The UUID of the pipeline.
        /// </summary>
        public string PipelineUuid => EnvironmentInfo.GetVariable("BITBUCKET_PIPELINE_UUID");

        /// <summary>
        /// The URL friendly version of the environment name.
        /// </summary>
        public string DeploymentEnvironment => EnvironmentInfo.GetVariable("BITBUCKET_DEPLOYMENT_ENVIRONMENT");

        /// <summary>
        /// The UUID of the environment to access environments via the REST API.
        /// </summary>
        public string DeploymentEnvironmentUuid => EnvironmentInfo.GetVariable("BITBUCKET_DEPLOYMENT_ENVIRONMENT_UUID");

        /// <summary>
        /// The key of the project the current pipeline belongs to.
        /// </summary>
        public string ProjectKey => EnvironmentInfo.GetVariable("BITBUCKET_PROJECT_KEY");

        /// <summary>
        /// The UUID of the project the current pipeline belongs to.
        /// </summary>
        public string ProjectUuid => EnvironmentInfo.GetVariable("BITBUCKET_PROJECT_UUID");

        /// <summary>
        /// The person who kicked off the build ( by doing a push, merge etc), and for scheduled builds, the uuid of the pipelines user.
        /// </summary>
        public string StepTriggererUuid => EnvironmentInfo.GetVariable("BITBUCKET_STEP_TRIGGERER_UUID");

        /// <summary>
        /// The 'ID Token' generated by the Bitbucket OIDC provider that identifies the step. This token can be used to access resource servers, such as AWS and GCP without using credentials.
        /// </summary>
        public string StepOidcToken => EnvironmentInfo.GetVariable("BITBUCKET_STEP_OIDC_TOKEN");
    }
}
