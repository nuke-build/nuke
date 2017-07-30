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
    public class TeamFoundationServer
    {
        public static TeamFoundationServer Instance { get; } =
            Variable("SYSTEM_TEAMPROJECTID") != null
                ? new TeamFoundationServer()
                : null;

        private TeamFoundationServer ()
        {
        }

        public string AgentBuildDirectory => EnsureVariable("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => EnsureVariable("AGENT_HOMEDIRECTORY");
        public long AgentId => EnsureVariable<long>("AGENT_ID");
        public TeamFoundationServerJobStatus AgentJobStatus => EnsureVariable<TeamFoundationServerJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => EnsureVariable("AGENT_MACHINENAME");
        public string AgentName => EnsureVariable("AGENT_NAME");
        public string AgentWorkFolder => EnsureVariable("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => EnsureVariable("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => EnsureVariable<long>("BUILD_BUILDID");
        public string BuildNumber => EnsureVariable("BUILD_BUILDNUMBER");
        public string BuildUri => EnsureVariable("BUILD_BUILDURI");
        public string BinariesDirectory => EnsureVariable("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => EnsureVariable("BUILD_DEFINITIONNAME");
        public string DefinitionVersion => EnsureVariable("BUILD_DEFINITIONVERSION");
        public string QueuedBy => EnsureVariable("BUILD_QUEUEDBY");
        public long QueuedById => EnsureVariable<long>("BUILD_QUEUEDBYID");
        public TeamFoundationServerBuildReason BuildReason => EnsureVariable<TeamFoundationServerBuildReason>("BUILD_REASON");
        public bool RepositoryClean => EnsureVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => EnsureVariable("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => EnsureVariable("BUILD_REPOSITORY_NAME");
        public TeamFoundationServerRepositoryType RepositoryProvider => EnsureVariable<TeamFoundationServerRepositoryType>("BUILD_REPOSITORY_PROVIDER");
        public string RepositoryTfvcWorkspace => EnsureVariable("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => EnsureVariable("BUILD_REPOSITORY_URI");
        public string RequestedFor => EnsureVariable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnsureVariable("BUILD_REQUESTEDFOREMAIL");
        public long RequestedForId => EnsureVariable<long>("BUILD_REQUESTEDFORID");
        public string SourceBranch => EnsureVariable("BUILD_SOURCEBRANCH");
        public string SourceBranchName => EnsureVariable("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => EnsureVariable("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => EnsureVariable("BUILD_SOURCEVERSION");
        public string StagingDirectory => EnsureVariable("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => EnsureVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        public string SourceTfvcShelveset => EnsureVariable("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => EnsureVariable("COMMON_TESTRESULTSDIRECTORY");
        public string AccessToken => EnsureVariable("SYSTEM_ACCESSTOKEN");
        public long CollectionId => EnsureVariable<long>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => EnsureVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => EnsureVariable<long>("SYSTEM_DEFINITIONID");
        public long PullRequestId => EnsureVariable<long>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        public string PullRequestSourceBranch => EnsureVariable("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        public string PullRequestTargetBranch => EnsureVariable("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string TeamFoundationCollectionUri => EnsureVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => EnsureVariable("SYSTEM_TEAMPROJECT");
        public long TeamProjectId => EnsureVariable<long>("SYSTEM_TEAMPROJECTID");
        public bool Build => EnsureVariable<bool>("TF_BUILD");
    }
}
