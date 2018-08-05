// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.EnvironmentInfo;

namespace Nuke.Common.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://www.visualstudio.com/en-us/docs/build/define/variables">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    [ExcludeFromCodeCoverage]
    public class TeamServices
    {
        private static Lazy<TeamServices> s_instance = new Lazy<TeamServices>(() => new TeamServices());

        public static TeamServices Instance => NukeBuild.Instance?.Host == HostType.TeamServices ? s_instance.Value : null;

        internal static bool IsRunningTeamServices => Environment.GetEnvironmentVariable("TF_BUILD") != null;

        private readonly Action<string> _messageSink;

        internal TeamServices(Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        public string AgentBuildDirectory => Variable("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => Variable("AGENT_HOMEDIRECTORY");
        public long AgentId => Variable<long>("AGENT_ID");
        public TeamServicesJobStatus AgentJobStatus => Variable<TeamServicesJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => Variable("AGENT_MACHINENAME");
        public string AgentName => Variable("AGENT_NAME");
        public string AgentWorkFolder => Variable("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => Variable("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => Variable<long>("BUILD_BUILDID");
        public long BuildNumber => Variable<long>("BUILD_BUILDNUMBER");
        public string BuildUri => Variable("BUILD_BUILDURI");
        public string BinariesDirectory => Variable("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => Variable("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => Variable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => Variable("BUILD_QUEUEDBY");
        public Guid QueuedById => Variable<Guid>("BUILD_QUEUEDBYID");
        public TeamServicesBuildReason BuildReason => Variable<TeamServicesBuildReason>("BUILD_REASON");
        public bool RepositoryClean => Variable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => Variable("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => Variable("BUILD_REPOSITORY_NAME");
        public TeamServicesRepositoryType RepositoryProvider => Variable<TeamServicesRepositoryType>("BUILD_REPOSITORY_PROVIDER");
        [CanBeNull] public string RepositoryTfvcWorkspace => Variable("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => Variable("BUILD_REPOSITORY_URI");
        public string RequestedFor => Variable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => Variable("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => Variable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => Variable("BUILD_SOURCEBRANCH");
        public string SourceBranchName => Variable("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => Variable("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => Variable("BUILD_SOURCEVERSION");
        public string StagingDirectory => Variable("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => Variable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => Variable("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => Variable("COMMON_TESTRESULTSDIRECTORY");
        [CanBeNull] public string AccessToken => Variable("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => Variable<Guid>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => Variable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => Variable<long>("SYSTEM_DEFINITIONID");
        [CanBeNull] public long? PullRequestId => Variable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public string PullRequestSourceBranch => Variable("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestTargetBranch => Variable("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string TeamFoundationCollectionUri => Variable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => Variable("SYSTEM_TEAMPROJECT");
        public Guid TeamProjectId => Variable<Guid>("SYSTEM_TEAMPROJECTID");

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

        public void LogError(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(TeamServicesIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogWarning(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(TeamServicesIssueType.Warning, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogIssue(
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
