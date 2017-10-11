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
        public static TeamServices Instance { get; } =
            Variable("TF_BUILD") != null
                ? new TeamServices(Console.WriteLine)
                : null;

        private readonly Action<string> _messageSink;

        private TeamServices (Action<string> messageSink)
        {
            _messageSink = messageSink;
        }

        /// <summary>
        /// The local path on the agent where all folders for a given build definition are created.
        /// For example: c:\agent\_work\1.
        /// </summary>
        public string AgentBuildDirectory => EnsureVariable("AGENT_BUILDDIRECTORY");

        /// <summary>
        /// The directory the agent is installed into. This contains the agent software. For example: c:\agent.
        /// </summary>
        public string AgentHomeDirectory => EnsureVariable("AGENT_HOMEDIRECTORY");

        /// <summary>The ID of the agent.</summary>
        public long AgentId => EnsureVariable<long>("AGENT_ID");

        /// <summary>The status of the build.</summary>
        public TeamServicesJobStatus AgentJobStatus => EnsureVariable<TeamServicesJobStatus>("AGENT_JOBSTATUS");

        /// <summary>The name of the machine on which the agent is installed.  </summary>
        public string AgentMachineName => EnsureVariable("AGENT_MACHINENAME");

        /// <summary>The name of the agent that is registered with the pool.</summary>
        public string AgentName => EnsureVariable("AGENT_NAME");

        /// <summary>The working directory for this agent. For example: c:\agent\_work.</summary>
        public string AgentWorkFolder => EnsureVariable("AGENT_WORKFOLDER");

        /// <summary>
        /// The local path on the agent where any artifacts are copied to before being pushed to their destination. For
        /// example: c:\agent\_work\1\a.
        /// </summary>
        public string ArtifactStagingDirectory => EnsureVariable("BUILD_ARTIFACTSTAGINGDIRECTORY");

        /// <summary>The ID of the record for the completed build.  </summary>
        public long BuildId => EnsureVariable<long>("BUILD_BUILDID");

        /// <summary>
        /// The name of the completed build. Specified in the definition options.
        /// 
        /// A typical use of this variable is to make it part of the label format, which you specify on the repository
        /// tab.
        /// </summary>
        public long BuildNumber => EnsureVariable<long>("BUILD_BUILDNUMBER");

        /// <summary>The URI for the build. For example: vstfs:///Build/Build/1430.</summary>
        public string BuildUri => EnsureVariable("BUILD_BUILDURI");

        /// <summary>
        /// The local path on the agent you can use as an output folder for compiled binaries.
        /// For example: c:\agent\_work\1\b.
        /// </summary>
        public string BinariesDirectory => EnsureVariable("BUILD_BINARIESDIRECTORY");

        /// <summary>The name of the build definition.</summary>
        public string DefinitionName => EnsureVariable("BUILD_DEFINITIONNAME");

        /// <summary>The version of the build definition.  </summary>
        public long DefinitionVersion => EnsureVariable<long>("BUILD_DEFINITIONVERSION");
        
        /// <summary>The person who checked in the changes or the system identity or the person who clicked queue build.</summary>
        public string QueuedBy => EnsureVariable("BUILD_QUEUEDBY");

        public Guid QueuedById => EnsureVariable<Guid>("BUILD_QUEUEDBYID");

        /// <summary>VSTS Only! The event that caused the build to run.  </summary>
        public TeamServicesBuildReason BuildReason => EnsureVariable<TeamServicesBuildReason>("BUILD_REASON");

        /// <summary>The value you've selected for Clean on the repository tab.</summary>
        public bool RepositoryClean => EnsureVariable<bool>("BUILD_REPOSITORY_CLEAN");

        /// <summary>
        /// The local path on the agent where your source code files are downloaded. For example: c:\agent\_work\1\s.
        /// </summary>
        public string RepositoryLocalPath => EnsureVariable("BUILD_REPOSITORY_LOCALPATH");

        /// <summary>The name of the repository.</summary>
        public string RepositoryName => EnsureVariable("BUILD_REPOSITORY_NAME");

        /// <summary>The type of repository you selected.</summary>
        public TeamServicesRepositoryType RepositoryProvider => EnsureVariable<TeamServicesRepositoryType>("BUILD_REPOSITORY_PROVIDER");

        /// <summary>
        /// Defined if your repository is Team Foundation Version Control. The name of the TFVC workspace used by the
        /// build agent.
        /// 
        /// For example, if the Agent.BuildDirectory is c:\agent\_work\12 and the Agent.Id is 8, the workspace name could
        /// be: ws_12_8.
        /// </summary>
        public string RepositoryTfvcWorkspace => Variable("BUILD_REPOSITORY_TFVC_WORKSPACE");

        /// <summary>
        /// The URL for the repository. For example:
        /// 
        /// Git: https://fabrikamfiber.visualstudio.com/_git/Scripts TFVC: https://fabrikamfiber.visualstudio.com/.
        /// </summary>
        public string RepositoryUri => EnsureVariable("BUILD_REPOSITORY_URI");

        /// <summary>The person who pushed or checked in the changes or the system identity for scheduled triggers.</summary>
        public string RequestedFor => EnsureVariable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnsureVariable("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => EnsureVariable<Guid>("BUILD_REQUESTEDFORID");

        /// <summary>
        /// The branch the build was queued for. Some examples:
        /// 
        /// Git repo branch: refs/heads/master
        /// Git repo pull request: refs/pull/1/merge
        /// TFVC repo branch: $/teamproject/main
        /// TFVC repo gated check-in: Gated_2016-06-06_05.20.51.4369;username @live.com
        /// TFVC repo shelveset build: myshelveset; username @live.com
        /// 
        /// When you use this variable in your build number format, the forward slash characters (/) are replaced with
        /// underscore characters _).
        /// 
        /// Note: In TFVC, if you are running a gated check-in build or manually building a shelveset, you cannot use
        /// this variable in your build number format.
        /// </summary>
        public string SourceBranch => EnsureVariable("BUILD_SOURCEBRANCH");

        /// <summary>The name of the branch the build was queued for.  </summary>
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

        /// <summary>
        /// The local path on the agent where the test results are created. For example: c:\agent\_work\1\TestResults.
        /// </summary>
        public string TestResultsDirectory => EnsureVariable("COMMON_TESTRESULTSDIRECTORY");

        /// <summary>OAuth token used to access the REST API.  </summary>
        [CanBeNull] public string AccessToken => Variable("SYSTEM_ACCESSTOKEN");

        /// <summary>The GUID of the team foundation collection.</summary>
        public Guid CollectionId => EnsureVariable<Guid>("SYSTEM_COLLECTIONID");

        /// <summary>
        /// The local path on the agent where your source code files are downloaded.
        /// For example: c:\agent\_work\1\s.
        /// </summary>
        public string DefaultWorkingDirectory => EnsureVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");

        /// <summary>The ID of the build definition.  </summary>
        public long DefinitionId => EnsureVariable<long>("SYSTEM_DEFINITIONID");

        /// <summary>
        /// The ID of the pull request that caused this build. For example: 17. (This variable is initialized only if the
        /// build ran because of a Git PR affected by a branch policy.)
        /// </summary>
        [CanBeNull] public string PullRequestId => Variable("SYSTEM_PULLREQUEST_PULLREQUESTID");

        /// <summary>
        /// The branch that is being revewiewed in a pull request. For example: refs/heads/users/raisa/new-feature. (This
        /// variable is initialized only if the build ran because of a Git PR affected by a branch policy.)
        /// </summary>
        [CanBeNull] public string PullRequestSourceBranch => Variable("SYSTEM_PULLREQUEST_SOURCEBRANCH");

        /// <summary>
        /// The branch that is the target of a pull request. For example: refs/heads/master. (This variable is
        /// initialized only if the build ran because of a Git PR affected by a branch policy.)
        /// </summary>
        [CanBeNull] public string PullRequestTargetBranch => Variable("SYSTEM_PULLREQUEST_TARGETBRANCH");

        /// <summary>
        /// The URI of the team foundation collection. For example: https://fabrikamfiber.visualstudio.com/.
        /// </summary>
        public string TeamFoundationCollectionUri => EnsureVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");

        /// <summary>The name of the team project that contains this build.</summary>
        public string TeamProject => EnsureVariable("SYSTEM_TEAMPROJECT");

        /// <summary>The ID of the team project that this build belongs to.  </summary>
        public Guid TeamProjectId => EnsureVariable<Guid>("SYSTEM_TEAMPROJECTID");

        /// <summary>
        /// Upload user interested log to build’s container “logs\tool” folder. For example: c:\msbuild.log.
        /// </summary>
        /// <param name="localFilePath"> Full path to the local file. </param>
        public void UploadLog(string localFilePath)
        { 
            _messageSink($"##vso[build.uploadlog]{localFilePath}");
        }

        /// <summary>Update build number for current build.</summary>
        /// <param name="buildNumber"> New build number to apply. </param>
        public void UpdateBuildNumber(string buildNumber)
        { 
            _messageSink($"##vso[build.updatebuildnumber]{buildNumber}");
        }

        /// <summary>Adds a build tag for the current build.</summary>
        /// <param name="buildTag"> The build tag. </param>
        public void AddBuildTag(string buildTag)
        { 
            _messageSink($"##vso[build.addbuildtag]{buildTag}");
        }

        /// <summary>Log error or warning issue to timeline record of current task.</summary>
        /// <param name="type">         Error or Warning. </param>
        /// <param name="message">      The message to log. </param>
        /// <param name="sourcePath">   (Optional) source file location. </param>
        /// <param name="lineNumber">   (Optional) The line number. </param>
        /// <param name="columnNumber"> (Optional) The column number. </param>
        /// <param name="code">         (Optional) Error or warning code. </param>
        public void LogIssue(TeamServicesIssueType type, string message, string sourcePath = null, string lineNumber = null, string columnNumber = null, string code = null)
        {
            string properties = $"type={(type == TeamServicesIssueType.Error ? "error" : "warning")};";
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
    }
}
