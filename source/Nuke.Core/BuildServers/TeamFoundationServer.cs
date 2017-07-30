// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

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
            EnvironmentInfo.Variable("SYSTEM_TEAMPROJECTID") != null
                ? new TeamFoundationServer()
                : null;

        public string AgentBuildDirectory => EnvironmentInfo.EnsureVariable("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => EnvironmentInfo.EnsureVariable("AGENT_HOMEDIRECTORY");
        public string AgentId => EnvironmentInfo.EnsureVariable("AGENT_ID");
        public TeamFoundationServerJobStatus AgentJobStatus => EnvironmentInfo.EnsureVariable<TeamFoundationServerJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => EnvironmentInfo.EnsureVariable("AGENT_MACHINENAME");
        public string AgentName => EnvironmentInfo.EnsureVariable("AGENT_NAME");
        public string AgentWorkFolder => EnvironmentInfo.EnsureVariable("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => EnvironmentInfo.EnsureVariable("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public string BuildId => EnvironmentInfo.EnsureVariable("BUILD_BUILDID");
        public string BuildNumber => EnvironmentInfo.EnsureVariable("BUILD_BUILDNUMBER");
        public string BuildUri => EnvironmentInfo.EnsureVariable("BUILD_BUILDURI");
        public string BinariesDirectory => EnvironmentInfo.EnsureVariable("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => EnvironmentInfo.EnsureVariable("BUILD_DEFINITIONNAME");
        public string DefinitionVersion => EnvironmentInfo.EnsureVariable("BUILD_DEFINITIONVERSION");
        public string QueuedBy => EnvironmentInfo.EnsureVariable("BUILD_QUEUEDBY");
        public string QueuedById => EnvironmentInfo.EnsureVariable("BUILD_QUEUEDBYID");
        public TeamFoundationServerBuildReason BuildReason => EnvironmentInfo.EnsureVariable<TeamFoundationServerBuildReason>("BUILD_REASON");
        public bool RepositoryClean => EnvironmentInfo.EnsureVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => EnvironmentInfo.EnsureVariable("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => EnvironmentInfo.EnsureVariable("BUILD_REPOSITORY_NAME");
        public TeamFoundationServerRepositoryType RepositoryProvider => EnvironmentInfo.EnsureVariable<TeamFoundationServerRepositoryType>("BUILD_REPOSITORY_PROVIDER");
        public string RepositoryTfvcWorkspace => EnvironmentInfo.EnsureVariable("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => EnvironmentInfo.EnsureVariable("BUILD_REPOSITORY_URI");
        public string RequestedFor => EnvironmentInfo.EnsureVariable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnvironmentInfo.EnsureVariable("BUILD_REQUESTEDFOREMAIL");
        public string RequestedForId => EnvironmentInfo.EnsureVariable("BUILD_REQUESTEDFORID");
        public string SourceBranch => EnvironmentInfo.EnsureVariable("BUILD_SOURCEBRANCH");
        public string SourceBranchName => EnvironmentInfo.EnsureVariable("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => EnvironmentInfo.EnsureVariable("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => EnvironmentInfo.EnsureVariable("BUILD_SOURCEVERSION");
        public string StagingDirectory => EnvironmentInfo.EnsureVariable("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => EnvironmentInfo.EnsureVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        public string SourceTfvcShelveset => EnvironmentInfo.EnsureVariable("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => EnvironmentInfo.EnsureVariable("COMMON_TESTRESULTSDIRECTORY");
        public string AccessToken => EnvironmentInfo.EnsureVariable("SYSTEM_ACCESSTOKEN");
        public string CollectionId => EnvironmentInfo.EnsureVariable("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => EnvironmentInfo.EnsureVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public string DefinitionId => EnvironmentInfo.EnsureVariable("SYSTEM_DEFINITIONID");
        public string PullRequestId => EnvironmentInfo.EnsureVariable("SYSTEM_PULLREQUEST_PULLREQUESTID");
        public string PullRequestSourceBranch => EnvironmentInfo.EnsureVariable("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        public string PullRequestTargetBranch => EnvironmentInfo.EnsureVariable("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string TeamFoundationCollectionUri => EnvironmentInfo.EnsureVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => EnvironmentInfo.EnsureVariable("SYSTEM_TEAMPROJECT");
        public string TeamProjectId => EnvironmentInfo.EnsureVariable("SYSTEM_TEAMPROJECTID");
        public bool Build => EnvironmentInfo.EnsureVariable<bool>("TF_BUILD");
    }
}
