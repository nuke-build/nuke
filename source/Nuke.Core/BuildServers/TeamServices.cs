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
    /// Interface according to the <a href="https://www.visualstudio.com/en-us/docs/build/define/variables">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    public class TeamServices
    {
        [CanBeNull]
        public static TeamServices Instance { get; } = NukeBuild.Instance?.Host == HostType.TeamServices ? new TeamServices() : null;

        internal static bool IsRunningTeamServices => Variable("TF_BUILD") != null;

        private readonly Action<string> _messageSink;

        internal TeamServices (Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        /// <summary>
        /// The local path on the agent where all folders for a given build definition are created.
        /// For example: <c>C:\agent\_work\1</c>.
        /// </summary>
        public string AgentBuildDirectory => EnsureVariable("AGENT_BUILDDIRECTORY");

        /// <summary>
        /// The directory the agent is installed into. This contains the agent software.
        /// For example: <c>C:\agent</c>. If you are using an on-premises agent, this directory is specified by you.
        /// See <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/agents/agents">Agents</a>.
        /// </summary>
        public string AgentHomeDirectory => EnsureVariable("AGENT_HOMEDIRECTORY");

        /// <summary>
        /// The ID of the agent.
        /// </summary>
        public long AgentId => EnsureVariable<long>("AGENT_ID");

        /// <summary>
        /// The status of the build.
        /// </summary>
        public TeamServicesJobStatus AgentJobStatus => EnsureVariable<TeamServicesJobStatus>("AGENT_JOBSTATUS");

        /// <summary>
        /// The name of the machine on which the agent is installed.
        /// </summary>
        public string AgentMachineName => EnsureVariable("AGENT_MACHINENAME");

        /// <summary>
        /// The name of the agent that is registered with the pool.
        /// If you are using an on-premises agent, this directory is specified by you.
        /// See <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/agents/agents">Agents</a>.
        /// </summary>
        public string AgentName => EnsureVariable("AGENT_NAME");

        /// <summary>
        /// The working directory for this agent. For example: <c>C:\agent\_work</c>.
        /// </summary>
        public string AgentWorkFolder => EnsureVariable("AGENT_WORKFOLDER");

        /// <summary>
        /// The local path on the agent where any artifacts are copied to before being pushed to their destination.
        /// For example: <c>c:\agent\_work\1\a</c>.
        /// <para/>
        /// A typical way to use this folder is to publish your build artifacts with the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/tasks/utility/copy-files">Copy files</a> and
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/tasks/utility/publish-build-artifacts">Publish build artifacts</a> steps.
        /// <para/>
        /// <b>Note:</b> This directory is purged before each new build, so you don't have to clean it up yourself.
        /// <para/>
        /// <see cref="ArtifactStagingDirectory"/> and <see cref="StagingDirectory"/> are interchangeable.
        /// <para/>
        /// See <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/artifacts">Artifacts in Team Build</a>.
        /// </summary>
        public string ArtifactStagingDirectory => EnsureVariable("BUILD_ARTIFACTSTAGINGDIRECTORY");

        /// <summary>
        /// The ID of the record for the completed build.
        /// </summary>
        public long BuildId => EnsureVariable<long>("BUILD_BUILDID");

        /// <summary>
        /// The name of the completed build. You can specify the build number format that generates this value in the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/options">definition options</a>.
        /// <para/>
        /// A typical use of this variable is to make it part of the label format, which you specify on the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">repository tab</a>.
        /// <para/>
        /// <b>Note:</b> This value can contain whitespace or other invalid label characters. In these cases, the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">label format</a> will fail.
        /// </summary>
        public long BuildNumber => EnsureVariable<long>("BUILD_BUILDNUMBER");

        /// <summary>
        /// The URI for the build. For example: <c>vstfs:///Build/Build/1430</c>.
        /// </summary>
        public string BuildUri => EnsureVariable("BUILD_BUILDURI");

        /// <summary>
        /// The local path on the agent you can use as an output folder for compiled binaries. For example: <c>C:\agent\_work\1\b</c>.
        /// <para/>
        /// By default, new build definitions are not set up to clean this directory. You can define your build to clean it up on the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">Repository tab</a>.
        /// </summary>
        public string BinariesDirectory => EnsureVariable("BUILD_BINARIESDIRECTORY");

        /// <summary>
        /// The name of the build definition.
        /// <para/>
        /// <b>Note:</b> This value can contain whitespace or other invalid label characters. In these cases, the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">label format</a> will fail.
        /// </summary>
        public string DefinitionName => EnsureVariable("BUILD_DEFINITIONNAME");

        /// <summary>
        /// The version of the build definition.
        /// </summary>
        public long DefinitionVersion => EnsureVariable<long>("BUILD_DEFINITIONVERSION");

        /// <summary>
        /// The person who checked in the changes or the system identity or the person who clicked queue build.
        /// <para/>
        /// <b>Note:</b> This value can contain whitespace or other invalid label characters. In these cases, the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">label format</a> will fail.
        /// </summary>
        public string QueuedBy => EnsureVariable("BUILD_QUEUEDBY");

        /// <summary>
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/variables?tabs=batch#identity_values">How are the identity variables set?</a>
        /// </summary>
        public Guid QueuedById => EnsureVariable<Guid>("BUILD_QUEUEDBYID");

        /// <summary>
        /// <b>VSTS Only.</b>
        /// <para/>
        /// The event that caused the build to run.
        /// <para/>
        /// See <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/triggers">Build definition triggers</a>,
        /// <a href="https://docs.microsoft.com/en-us/vsts/git/branch-policies">Improve code quality with branch policies</a>.
        /// </summary>
        public TeamServicesBuildReason BuildReason => EnsureVariable<TeamServicesBuildReason>("BUILD_REASON");

        /// <summary>
        /// The value you've selected for <b>Clean</b> in the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">source repository settings</a>.
        /// </summary>
        public bool RepositoryClean => EnsureVariable<bool>("BUILD_REPOSITORY_CLEAN");

        /// <summary>
        /// The local path on the agent where your source code files are downloaded. For example: <c>C:\agent\_work\1\s</c>.
        /// <para/>
        /// By default, new build definitions update only the changed files.You can modify how files are downloaded on the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">Repository tab</a>.
        /// </summary>
        public string RepositoryLocalPath => EnsureVariable("BUILD_REPOSITORY_LOCALPATH");

        /// <summary>
        /// The name of the <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">repository</a>.
        /// </summary>
        public string RepositoryName => EnsureVariable("BUILD_REPOSITORY_NAME");

        /// <summary>
        /// The type of <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">repository you selected</a>.
        /// </summary>
        public TeamServicesRepositoryType RepositoryProvider => EnsureVariable<TeamServicesRepositoryType>("BUILD_REPOSITORY_PROVIDER");

        /// <summary>
        /// Defined if your <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">repository</a>
        /// is Team Foundation Version Control. The name of the <a href="https://docs.microsoft.com/en-us/vsts/tfvc/create-work-workspaces">TFVC workspace</a>
        /// used by the build agent.
        /// <para/>
        /// For example, if the Agent.BuildDirectory is <c>C:\agent\_work\12</c> and the Agent.Id is <c>8</c>, the workspace name could be: <c>ws_12_8</c>.
        /// </summary>
        [CanBeNull]
        public string RepositoryTfvcWorkspace => Variable("BUILD_REPOSITORY_TFVC_WORKSPACE");

        /// <summary>
        /// The URL for the repository. For example:
        /// <ul>
        ///   <li><b>Git:</b> <c>https://fabrikamfiber.visualstudio.com/_git/Scripts</c></li>
        ///   <li><b>TFVC:</b> <c>https://fabrikamfiber.visualstudio.com/</c></li>
        /// </ul>
        /// </summary>
        public string RepositoryUri => EnsureVariable("BUILD_REPOSITORY_URI");

        /// <summary>
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/variables?tabs=batch#identity_values">How are the identity variables set?</a>
        /// <para/>
        /// <b>Note:</b> This value can contain whitespace or other invalid label characters. In these cases, the
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/repository">label format</a> will fail.
        /// </summary>
        public string RequestedFor => EnsureVariable("BUILD_REQUESTEDFOR");

        /// <summary>
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/variables?tabs=batch#identity_values">How are the identity variables set?</a>
        /// </summary>
        public string RequestedForEmail => EnsureVariable("BUILD_REQUESTEDFOREMAIL");

        /// <summary>
        /// <a href="https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/variables?tabs=batch#identity_values">How are the identity variables set?</a>
        /// </summary>
        public Guid RequestedForId => EnsureVariable<Guid>("BUILD_REQUESTEDFORID");

        /// <summary>
        /// The branch the build was queued for. Some examples:
        /// <ul>
        ///   <li>Git repo branch: <c>refs/heads/master</c></li>
        ///   <li>Git repo pull request: <c>refs/pull/1/merge</c></li>
        ///   <li>TFVC repo branch: <c>$/teamproject/main</c></li>
        ///   <li>TFVC repo gated check-in: <c>Gated_2016-06-06_05.20.51.4369;username@live.com</c></li>
        ///   <li>TFVC repo shelveset build: <c>myshelveset;username@live.com</c></li>
        /// </ul>
        /// When you use this variable in your build number format, the forward slash characters (<c>/</c>) are replaced with underscore characters <c>_</c>).
        /// <para/>
        /// <b>Note:</b> In TFVC, if you are running a gated check-in build or manually building a shelveset, you cannot use this variable in your build number format.
        /// </summary>
        public string SourceBranch => EnsureVariable("BUILD_SOURCEBRANCH");

        /// <summary>
        /// The name of the branch the build was queued for.
        /// <ul>
        ///   <li>Git repo branch or pull request: The last path segment in the ref. For example, in <c>refs/heads/master</c> this value is <c>master</c>.</li>
        ///   <li>TFVC repo branch: The last path segment in the root server path for the workspace. For example in <c>$/teamproject/main</c> this value is <c>main</c>.</li>
        ///   <li>TFVC repo gated check-in or shelveset build is the name of the shelveset. For example, <c>Gated_2016-06-06_05.20.51.4369;username@live.com</c> or <c>myshelveset;username@live.com</c>.</li>
        /// </ul>
        /// <b>Note:</b> In TFVC, if you are running a gated check-in build or manually building a shelveset, you cannot use this variable in your build number format.
        /// </summary>
        public string SourceBranchName => EnsureVariable("BUILD_SOURCEBRANCHNAME");

        /// <summary>The local path on the agent where your source code files are downloaded. For example: c:\agent\_work\1\s </summary>
        public string SourceDirectory => EnsureVariable("BUILD_SOURCESDIRECTORY");

        /// <summary>
        /// The latest version control change that is included in this build.
        /// 
        /// Git: The commit ID.
        /// TFVC: the changeset.
        /// </summary>
        public string SourceVersion => EnsureVariable("BUILD_SOURCEVERSION");

        /// <summary>
        /// The local path on the agent where any artifacts are copied to before being pushed to their destination. For
        /// example: c:\agent\_work\1\a
        /// 
        /// A typical way to use this folder is to publish your build artifacts with the Copy files and Publish build
        /// artifacts steps.
        /// </summary>
        public string StagingDirectory => EnsureVariable("BUILD_STAGINGDIRECTORY");

        /// <summary>The value you've selected for Checkout submodules on the repository tab.</summary>
        public bool RepositoryGitSubmoduleCheckout => EnsureVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");

        /// <summary>
        /// Defined if your repository is Team Foundation Version Control.
        /// 
        /// If you are running a gated build or a shelveset build, this is set to the name of the shelveset you are
        /// building.
        /// </summary>
        [CanBeNull] public string SourceTfvcShelveset => Variable("BUILD_SOURCETFVCSHELVESET");

        /// <summary>The local path on the agent where the test results are created. For example: <c>C:\agent\_work\1\TestResults</c>.</summary>
        public string TestResultsDirectory => EnsureVariable("COMMON_TESTRESULTSDIRECTORY");

        /// <summary>OAuth token used to access the REST API.</summary>
        [CanBeNull]
        public string AccessToken => Variable("SYSTEM_ACCESSTOKEN");

        /// <summary>The GUID of the team foundation collection.</summary>
        public Guid CollectionId => EnsureVariable<Guid>("SYSTEM_COLLECTIONID");

        /// <summary>The local path on the agent where your source code files are downloaded. For example: <c>C:\agent\_work\1\s</c>.</summary>
        public string DefaultWorkingDirectory => EnsureVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");

        /// <summary>The ID of the build definition.  </summary>
        public long DefinitionId => EnsureVariable<long>("SYSTEM_DEFINITIONID");

        /// <summary>The ID of the pull request that caused this build. For example: 17.</summary>
        /// <remarks>This variable is initialized only if the build ran because of a Git PR affected by a branch policy.</remarks>
        [CanBeNull] public string PullRequestId => Variable("SYSTEM_PULLREQUEST_PULLREQUESTID");

        /// <summary>The branch that is being revewiewed in a pull request. For example: refs/heads/users/raisa/new-feature.</summary>
        /// <remarks>This variable is initialized only if the build ran because of a Git PR affected by a branch policy.</remarks>
        [CanBeNull] public string PullRequestSourceBranch => Variable("SYSTEM_PULLREQUEST_SOURCEBRANCH");

        /// <summary>The branch that is the target of a pull request. For example: refs/heads/master.</summary>
        /// <remarks>This variable is initialized only if the build ran because of a Git PR affected by a branch policy.</remarks>
        [CanBeNull] public string PullRequestTargetBranch => Variable("SYSTEM_PULLREQUEST_TARGETBRANCH");

        /// <summary>The URI of the team foundation collection. For example: <c>https://fabrikamfiber.visualstudio.com/</c>.</summary>
        public string TeamFoundationCollectionUri => EnsureVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");

        /// <summary>The name of the team project that contains this build.</summary>
        public string TeamProject => EnsureVariable("SYSTEM_TEAMPROJECT");

        /// <summary>The ID of the team project that this build belongs to. </summary>
        public Guid TeamProjectId => EnsureVariable<Guid>("SYSTEM_TEAMPROJECTID");

        /// <summary>Upload user interested log to build’s container “logs\tool” folder. For example: c:\msbuild.log.</summary>
        public void UploadLog(string localFilePath)
        { 
            _messageSink($"##vso[build.uploadlog]{localFilePath}");
        }

        /// <summary>Update build number for current build.</summary>
        public void UpdateBuildNumber(string buildNumber)
        { 
            _messageSink($"##vso[build.updatebuildnumber]{buildNumber}");
        }

        /// <summary>Adds a build tag for the current build.</summary>
        public void AddBuildTag(string buildTag)
        { 
            _messageSink($"##vso[build.addbuildtag]{buildTag}");
        }

        /// <summary>Log error issue to timeline record of current task.</summary>
        public void LogError (
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(TeamServicesIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        /// <summary>Log warning issue to timeline record of current task.</summary>
        public void LogWarning (
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(TeamServicesIssueType.Warning, message, sourcePath, lineNumber, columnNumber, code);
        }

        /// <summary>Log issue to timeline record of current task.</summary>
        public void LogIssue (
            TeamServicesIssueType type,
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            var properties = $"type={GetText(type)};";
            if (!string.IsNullOrEmpty(sourcePath))
                properties += $"sourcepath={sourcePath};";

            if (!string.IsNullOrEmpty(lineNumber))
                properties += $"linenumber={lineNumber};";

            if (!string.IsNullOrEmpty(columnNumber))
                properties += $"columnnumber={columnNumber};";

            if (!string.IsNullOrEmpty(code))
                properties += $"code={code};";

            _messageSink($"##vso[task.logissue {properties}]{message}");
        }

        private string GetText(TeamServicesIssueType type)
        {
            switch (type)
            {
                case TeamServicesIssueType.Warning:
                    return "warning";
                case TeamServicesIssueType.Error:
                    return "error";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, message: null);
            }
        }
    }
}
