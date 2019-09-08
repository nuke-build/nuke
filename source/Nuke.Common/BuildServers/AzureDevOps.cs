// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.EnvironmentInfo;

namespace Nuke.Common.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://docs.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&amp;tabs=yaml">official website</a>.
    /// <a href="https://github.com/Microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md">Azure Pipeline Tasks Documentation</a>
    /// </summary>
    [PublicAPI]
    [BuildServer]
    [ExcludeFromCodeCoverage]
    public class AzureDevOps
    {
        private static Lazy<AzureDevOps> s_instance = new Lazy<AzureDevOps>(() => new AzureDevOps());

        public static AzureDevOps Instance => NukeBuild.Host == HostType.AzureDevOps ? s_instance.Value : null;

        internal static bool IsRunningAzureDevOps => Environment.GetEnvironmentVariable("TF_BUILD") != null;

        private readonly Action<string> _messageSink;

        internal AzureDevOps(Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        public string AgentBuildDirectory => GetVariable<string>("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => GetVariable<string>("AGENT_HOMEDIRECTORY");
        public long AgentId => GetVariable<long>("AGENT_ID");
        public AzureDevOpsJobStatus AgentJobStatus => GetVariable<AzureDevOpsJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => GetVariable<string>("AGENT_MACHINENAME");
        public string AgentName => GetVariable<string>("AGENT_NAME");
        public string AgentWorkFolder => GetVariable<string>("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => GetVariable<string>("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => GetVariable<long>("BUILD_BUILDID");
        [NoConvert] public string BuildNumber => GetVariable<string>("BUILD_BUILDNUMBER");
        public string BuildUri => GetVariable<string>("BUILD_BUILDURI");
        public string BinariesDirectory => GetVariable<string>("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => GetVariable<string>("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => GetVariable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => GetVariable<string>("BUILD_QUEUEDBY");
        public Guid QueuedById => GetVariable<Guid>("BUILD_QUEUEDBYID");
        public AzureDevOpsBuildReason BuildReason => GetVariable<AzureDevOpsBuildReason>("BUILD_REASON");
        public bool RepositoryClean => GetVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => GetVariable<string>("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => GetVariable<string>("BUILD_REPOSITORY_NAME");
        public AzureDevOpsRepositoryType RepositoryProvider => GetVariable<AzureDevOpsRepositoryType>("BUILD_REPOSITORY_PROVIDER");
        [CanBeNull] public string RepositoryTfvcWorkspace => GetVariable<string>("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => GetVariable<string>("BUILD_REPOSITORY_URI");
        public string RequestedFor => GetVariable<string>("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => GetVariable<string>("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => GetVariable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => GetVariable<string>("BUILD_SOURCEBRANCH");
        public string SourceBranchName => GetVariable<string>("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => GetVariable<string>("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => GetVariable<string>("BUILD_SOURCEVERSION");
        public string StagingDirectory => GetVariable<string>("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => GetVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => GetVariable<string>("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => GetVariable<string>("COMMON_TESTRESULTSDIRECTORY");
        [CanBeNull] public string AccessToken => GetVariable<string>("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => GetVariable<Guid>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => GetVariable<string>("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => GetVariable<long>("SYSTEM_DEFINITIONID");
        [CanBeNull] public long? PullRequestId => GetVariable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public string PullRequestSourceBranch => GetVariable<string>("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestTargetBranch => GetVariable<string>("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string TeamFoundationCollectionUri => GetVariable<string>("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => GetVariable<string>("SYSTEM_TEAMPROJECT");
        public Guid TeamProjectId => GetVariable<Guid>("SYSTEM_TEAMPROJECTID");

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

        public void UploadAzureDevOpsArtifacts(string containerFolder, string artifactName, string packageDirectory)
        {
            _messageSink($"##vso[artifact.upload containerfolder={containerFolder};artifactname={artifactName};]{packageDirectory}");
        }

        public void PublishAzureDevOpsTestResults(
            IEnumerable<FileInfo> files,
            string title,
            bool mergeResults = false,
            string platform = "x64",
            string configuration = "Release",
            string testType = "VSTest")
        {
            var resultFiles = string.Join(",", files.Select(x => x.FullName.Replace('\\', Path.DirectorySeparatorChar)));
            _messageSink(
                $"##vso[results.publish type={testType};mergeResults={mergeResults};platform={platform}4;config={configuration};runTitle='{title}';publishRunAttachments=true;resultFiles={resultFiles};]");
        }

        public void LogError(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(AzureDevOpsIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogWarning(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(AzureDevOpsIssueType.Warning, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogIssue(
            AzureDevOpsIssueType type,
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

        private string GetText(AzureDevOpsIssueType type)
        {
            switch (type)
            {
                case AzureDevOpsIssueType.Warning:
                    return "warning";
                case AzureDevOpsIssueType.Error:
                    return "error";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, message: null);
            }
        }
    }
}
