// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines
{
    /// <summary>
    /// Interface according to the <a href="https://docs.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&amp;tabs=yaml">official website</a>.
    /// <a href="https://github.com/Microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md">Azure Pipeline Tasks Documentation</a>
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class AzurePipelines
    {
        private static Lazy<AzurePipelines> s_instance = new Lazy<AzurePipelines>(() => new AzurePipelines());

        public static AzurePipelines Instance => NukeBuild.Host == HostType.AzurePipelines ? s_instance.Value : null;

        internal static bool IsRunningAzurePipelines => Environment.GetEnvironmentVariable("TF_BUILD") != null;

        private readonly Action<string> _messageSink;

        internal AzurePipelines(Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        public string AgentBuildDirectory => EnvironmentInfo.GetVariable<string>("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => EnvironmentInfo.GetVariable<string>("AGENT_HOMEDIRECTORY");
        public long AgentId => EnvironmentInfo.GetVariable<long>("AGENT_ID");
        public AzurePipelinesJobStatus AgentJobStatus => EnvironmentInfo.GetVariable<AzurePipelinesJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => EnvironmentInfo.GetVariable<string>("AGENT_MACHINENAME");
        public string AgentName => EnvironmentInfo.GetVariable<string>("AGENT_NAME");
        public string AgentWorkFolder => EnvironmentInfo.GetVariable<string>("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => EnvironmentInfo.GetVariable<string>("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => EnvironmentInfo.GetVariable<long>("BUILD_BUILDID");
        [NoConvert] public string BuildNumber => EnvironmentInfo.GetVariable<string>("BUILD_BUILDNUMBER");
        public string BuildUri => EnvironmentInfo.GetVariable<string>("BUILD_BUILDURI");
        public string BinariesDirectory => EnvironmentInfo.GetVariable<string>("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => EnvironmentInfo.GetVariable<string>("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => EnvironmentInfo.GetVariable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => EnvironmentInfo.GetVariable<string>("BUILD_QUEUEDBY");
        public Guid QueuedById => EnvironmentInfo.GetVariable<Guid>("BUILD_QUEUEDBYID");
        public AzurePipelinesBuildReason BuildReason => EnvironmentInfo.GetVariable<AzurePipelinesBuildReason>("BUILD_REASON");
        public bool RepositoryClean => EnvironmentInfo.GetVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_NAME");

        public AzurePipelinesRepositoryType RepositoryProvider =>
            EnvironmentInfo.GetVariable<AzurePipelinesRepositoryType>("BUILD_REPOSITORY_PROVIDER");

        [CanBeNull] public string RepositoryTfvcWorkspace => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_URI");
        public string RequestedFor => EnvironmentInfo.GetVariable<string>("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnvironmentInfo.GetVariable<string>("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => EnvironmentInfo.GetVariable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEBRANCH");
        public string SourceBranchName => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => EnvironmentInfo.GetVariable<string>("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEVERSION");
        public string StagingDirectory => EnvironmentInfo.GetVariable<string>("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => EnvironmentInfo.GetVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => EnvironmentInfo.GetVariable<string>("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => EnvironmentInfo.GetVariable<string>("COMMON_TESTRESULTSDIRECTORY");
        [CanBeNull] public string AccessToken => EnvironmentInfo.GetVariable<string>("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => EnvironmentInfo.GetVariable<string>("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => EnvironmentInfo.GetVariable<long>("SYSTEM_DEFINITIONID");
        [CanBeNull] public long? PullRequestId => EnvironmentInfo.GetVariable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public string PullRequestSourceBranch => EnvironmentInfo.GetVariable<string>("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestTargetBranch => EnvironmentInfo.GetVariable<string>("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string StageName => EnvironmentInfo.GetVariable<string>("SYSTEM_STAGENAME");
        public string StageDisplayName => EnvironmentInfo.GetVariable<string>("SYSTEM_STAGEDISPLAYNAME");
        public string TeamFoundationCollectionUri => EnvironmentInfo.GetVariable<string>("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => EnvironmentInfo.GetVariable<string>("SYSTEM_TEAMPROJECT");
        public Guid TeamProjectId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_TEAMPROJECTID");

        public void Group(string group)
        {
            _messageSink($"##[group]{group}");
        }

        public void EndGroup(string group)
        {
            _messageSink($"##[endgroup]{group}");
        }

        public void UploadLog(string path)
        {
            WriteCommand("build.uploadlog", path);
        }

        public void UpdateBuildNumber(string buildNumber)
        {
            WriteCommand("build.updatebuildnumber", buildNumber);
        }

        public void AddBuildTag(string buildTag)
        {
            WriteCommand("build.addbuildtag", buildTag);
        }

        public void UploadArtifacts(string containerDirectory, string artifactName, string packageDirectory)
        {
            WriteCommand("artifact.upload",
                packageDirectory,
                dictionaryConfigurator: x => x
                    .AddKeyValue("containerfolder", containerDirectory)
                    .AddKeyValue("artifactname", artifactName));
        }

        public void LogError(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(AzurePipelinesIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogWarning(
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            LogIssue(AzurePipelinesIssueType.Warning, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void PublishCodeCoverage(
            AzurePipelinesCodeCoverageToolType coverageTool,
            string summaryFile,
            string reportDirectory,
            params string[] additionalCodeCoverageFiles)
        {
            WriteCommand(
                "codecoverage.publish",
                dictionaryConfigurator: x => x
                    .AddKeyValue("coverageTool", coverageTool)
                    .AddKeyValue("summaryFile", summaryFile)
                    .AddKeyValue("reportDirectory", reportDirectory)
                    .AddKeyValue("additionalCodeCoverageFiles", additionalCodeCoverageFiles.JoinComma()));
        }

        public void PublishTestResults(
            string title,
            AzurePipelinesTestResultsType type,
            IEnumerable<string> files,
            bool? mergeResults = null,
            string platform = null,
            string configuration = null,
            bool? publishRunAttachments = null)
        {
            WriteCommand(
                "results.publish",
                dictionaryConfigurator: x => x
                    .AddKeyValue("type", type)
                    .AddKeyValue("resultFiles", files.JoinComma())
                    .AddKeyValue("mergeResults", mergeResults)
                    .AddKeyValue("platform", platform)
                    .AddKeyValue("config", configuration)
                    .AddKeyValue("runTitle", title.SingleQuote())
                    .AddKeyValue("publishRunAttachments", publishRunAttachments));
        }

        public void LogIssue(
            AzurePipelinesIssueType type,
            string message,
            string sourcePath = null,
            string lineNumber = null,
            string columnNumber = null,
            string code = null)
        {
            WriteCommand(
                "task.logissue",
                message,
                dictionaryConfigurator: x => x
                    .AddKeyValue("type", GetText(type))
                    .AddKeyValue("sourcepath", sourcePath)
                    .AddKeyValue("linenumber", lineNumber)
                    .AddKeyValue("columnnumber", columnNumber)
                    .AddKeyValue("code", code));
        }

        private string GetText(AzurePipelinesIssueType type)
        {
            return type switch
            {
                AzurePipelinesIssueType.Warning => "warning",
                AzurePipelinesIssueType.Error => "error",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, message: null)
            };
        }

        public void WriteCommand(
            string command,
            string message = null,
            Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator = null)
        {
            var escapedTokens =
                dictionaryConfigurator?
                    .Invoke(new Dictionary<string, object>())
                    .Where(x => x.Value != null)
                    .Select(x => $"{x.Key}={EscapeValue(x.Value.ToString())}").ToArray()
                ?? new string[0];

            Write(command, escapedTokens, message);
        }

        private void Write(string command, string[] escapedTokens, [CanBeNull] string message)
        {
            _messageSink.Invoke($"##vso[{command} {escapedTokens.Join(";")}]{EscapeMessage(message)}");
        }

        private string EscapeMessage([CanBeNull] string data)
        {
            return data?
                .Replace("\r", "%0D")
                .Replace("\n", "%0A");
        }

        private string EscapeValue(string value)
        {
            return value
                .Replace("\r", "%0D")
                .Replace("\n", "%0A")
                .Replace("]", "%5D")
                .Replace(";", "%3B");
        }
    }
}
