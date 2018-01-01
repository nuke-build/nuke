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
        private static Lazy<TeamServices> s_instance = new Lazy<TeamServices>(() => new TeamServices());

        [CanBeNull]
        public static TeamServices Instance => NukeBuild.Instance?.Host == HostType.TeamServices ? s_instance.Value : null;

        internal static bool IsRunningTeamServices => Variable("TF_BUILD") != null;

        private readonly Action<string> _messageSink;

        internal TeamServices (Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        public string AgentBuildDirectory => EnsureVariable("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => EnsureVariable("AGENT_HOMEDIRECTORY");
        public long AgentId => EnsureVariable<long>("AGENT_ID");
        public TeamServicesJobStatus AgentJobStatus => EnsureVariable<TeamServicesJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => EnsureVariable("AGENT_MACHINENAME");
        public string AgentName => EnsureVariable("AGENT_NAME");
        public string AgentWorkFolder => EnsureVariable("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => EnsureVariable("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => EnsureVariable<long>("BUILD_BUILDID");
        public long BuildNumber => EnsureVariable<long>("BUILD_BUILDNUMBER");
        public string BuildUri => EnsureVariable("BUILD_BUILDURI");
        public string BinariesDirectory => EnsureVariable("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => EnsureVariable("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => EnsureVariable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => EnsureVariable("BUILD_QUEUEDBY");
        public Guid QueuedById => EnsureVariable<Guid>("BUILD_QUEUEDBYID");
        public TeamServicesBuildReason BuildReason => EnsureVariable<TeamServicesBuildReason>("BUILD_REASON");
        public bool RepositoryClean => EnsureVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => EnsureVariable("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => EnsureVariable("BUILD_REPOSITORY_NAME");
        public TeamServicesRepositoryType RepositoryProvider => EnsureVariable<TeamServicesRepositoryType>("BUILD_REPOSITORY_PROVIDER");
        [CanBeNull] public string RepositoryTfvcWorkspace => Variable("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => EnsureVariable("BUILD_REPOSITORY_URI");
        public string RequestedFor => EnsureVariable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnsureVariable("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => EnsureVariable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => EnsureVariable("BUILD_SOURCEBRANCH");
        public string SourceBranchName => EnsureVariable("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => EnsureVariable("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => EnsureVariable("BUILD_SOURCEVERSION");
        public string StagingDirectory => EnsureVariable("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => EnsureVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => Variable("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => EnsureVariable("COMMON_TESTRESULTSDIRECTORY");
        [CanBeNull] public string AccessToken => Variable("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => EnsureVariable<Guid>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => EnsureVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => EnsureVariable<long>("SYSTEM_DEFINITIONID");
        [CanBeNull] public string PullRequestId => Variable("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public string PullRequestSourceBranch => Variable("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestTargetBranch => Variable("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string TeamFoundationCollectionUri => EnsureVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => EnsureVariable("SYSTEM_TEAMPROJECT");
        public Guid TeamProjectId => EnsureVariable<Guid>("SYSTEM_TEAMPROJECTID");

        public void UploadLog(string localFilePath)
        { 
            _messageSink($"##vso[build.uploadlog]{localFilePath}");
        }

        public void UpdateBuildNumber(string buildNumber)
        { 
            _messageSink($"##vso[build.updatebuildnumber]{buildNumber}");
        }

        public void AddBuildTag(string buildTag)
        { 
            _messageSink($"##vso[build.addbuildtag]{buildTag}");
        }

        public void LogError (
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(TeamServicesIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogWarning (
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(TeamServicesIssueType.Warning, message, sourcePath, lineNumber, columnNumber, code);
        }

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
