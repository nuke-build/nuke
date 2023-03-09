// Copyright 2023 Maintainers of NUKE.
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
    [ExcludeFromCodeCoverage]
    public partial class AzurePipelines : Host, IBuildServer
    {
        public new static AzurePipelines Instance => Host.Instance as AzurePipelines;

        internal static bool IsRunningAzurePipelines => EnvironmentInfo.HasVariable("TF_BUILD");

        private readonly Action<string> _messageSink;

        internal AzurePipelines()
            : this(messageSink: null)
        {
        }

        internal AzurePipelines(Action<string> messageSink)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        string IBuildServer.Branch => SourceBranch;
        string IBuildServer.Commit => SourceVersion;

        public string AgentBuildDirectory => EnvironmentInfo.GetVariable("AGENT_BUILDDIRECTORY");
        public string AgentHomeDirectory => EnvironmentInfo.GetVariable("AGENT_HOMEDIRECTORY");
        public long AgentId => EnvironmentInfo.GetVariable<long>("AGENT_ID");
        public AzurePipelinesJobStatus AgentJobStatus => EnvironmentInfo.GetVariable<AzurePipelinesJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => EnvironmentInfo.GetVariable("AGENT_MACHINENAME");
        public string AgentName => EnvironmentInfo.GetVariable("AGENT_NAME");
        public string AgentWorkFolder => EnvironmentInfo.GetVariable("AGENT_WORKFOLDER");
        public string ArtifactStagingDirectory => EnvironmentInfo.GetVariable("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => EnvironmentInfo.GetVariable<long>("BUILD_BUILDID");
        [NoConvert] public string BuildNumber => EnvironmentInfo.GetVariable("BUILD_BUILDNUMBER");
        public string BuildUri => EnvironmentInfo.GetVariable("BUILD_BUILDURI");
        public string BinariesDirectory => EnvironmentInfo.GetVariable("BUILD_BINARIESDIRECTORY");
        public string DefinitionName => EnvironmentInfo.GetVariable("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => EnvironmentInfo.GetVariable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => EnvironmentInfo.GetVariable("BUILD_QUEUEDBY");
        public Guid QueuedById => EnvironmentInfo.GetVariable<Guid>("BUILD_QUEUEDBYID");
        public AzurePipelinesBuildReason BuildReason => EnvironmentInfo.GetVariable<AzurePipelinesBuildReason>("BUILD_REASON");
        public bool RepositoryClean => EnvironmentInfo.GetVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public string RepositoryLocalPath => EnvironmentInfo.GetVariable("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryName => EnvironmentInfo.GetVariable("BUILD_REPOSITORY_NAME");

        public AzurePipelinesRepositoryType RepositoryProvider =>
            EnvironmentInfo.GetVariable<AzurePipelinesRepositoryType>("BUILD_REPOSITORY_PROVIDER");

        [CanBeNull] public string RepositoryTfvcWorkspace => EnvironmentInfo.GetVariable("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public string RepositoryUri => EnvironmentInfo.GetVariable("BUILD_REPOSITORY_URI");
        public string RequestedFor => EnvironmentInfo.GetVariable("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnvironmentInfo.GetVariable("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => EnvironmentInfo.GetVariable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => EnvironmentInfo.GetVariable("BUILD_SOURCEBRANCH");
        public string SourceBranchName => EnvironmentInfo.GetVariable("BUILD_SOURCEBRANCHNAME");
        public string SourceDirectory => EnvironmentInfo.GetVariable("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => EnvironmentInfo.GetVariable("BUILD_SOURCEVERSION");
        public string StagingDirectory => EnvironmentInfo.GetVariable("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => EnvironmentInfo.GetVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => EnvironmentInfo.GetVariable("BUILD_SOURCETFVCSHELVESET");
        public string TestResultsDirectory => EnvironmentInfo.GetVariable("COMMON_TESTRESULTSDIRECTORY");
        [CanBeNull] public string AccessToken => EnvironmentInfo.GetVariable("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_COLLECTIONID");
        public string DefaultWorkingDirectory => EnvironmentInfo.GetVariable("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => EnvironmentInfo.GetVariable<long>("SYSTEM_DEFINITIONID");
        [CanBeNull] public long? PullRequestId => EnvironmentInfo.GetVariable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public string PullRequestSourceBranch => EnvironmentInfo.GetVariable("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestTargetBranch => EnvironmentInfo.GetVariable("SYSTEM_PULLREQUEST_TARGETBRANCH");
        public string StageName => EnvironmentInfo.GetVariable("SYSTEM_STAGENAME");
        public string StageDisplayName => EnvironmentInfo.GetVariable("SYSTEM_STAGEDISPLAYNAME");
        public string TeamFoundationCollectionUri => EnvironmentInfo.GetVariable("SYSTEM_TEAMFOUNDATIONCOLLECTIONURI");
        public string TeamProject => EnvironmentInfo.GetVariable("SYSTEM_TEAMPROJECT");
        public Guid TeamProjectId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_TEAMPROJECTID");
        public string JobDisplayName => EnvironmentInfo.GetVariable("SYSTEM_JOBDISPLAYNAME");
        public Guid JobId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_JOBID");
        public Guid TaskInstanceId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_TASKINSTANCEID");
        public string PhaseName => EnvironmentInfo.GetVariable("SYSTEM_PHASENAME");

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
            EnvironmentInfo.SetVariable("BUILD_BUILDNUMBER", buildNumber);
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
                    .AddPair("containerfolder", containerDirectory)
                    .AddPair("artifactname", artifactName));
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
            // Taken from https://github.com/microsoft/azure-pipelines-tasks/blob/master/Tests-Legacy/L0/PublishCodeCoverageResults/_suite.ts#L45-L46
            WriteCommand(
                "codecoverage.publish",
                dictionaryConfigurator: x => x
                    .AddPair("codeCoverageTool", coverageTool)
                    .AddPair("summaryFile", summaryFile)
                    .AddPair("reportDirectory", reportDirectory)
                    .AddPair("additionalCodeCoverageFiles", additionalCodeCoverageFiles.JoinComma()));
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
                    .AddPair("type", type)
                    .AddPair("resultFiles", files.JoinComma())
                    .AddPairWhenValueNotNull("mergeResults", mergeResults)
                    .AddPairWhenValueNotNull("platform", platform)
                    .AddPairWhenValueNotNull("config", configuration)
                    .AddPairWhenValueNotNull("runTitle", title.SingleQuote())
                    .AddPairWhenValueNotNull("publishRunAttachments", publishRunAttachments));
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
                    .AddPair("type", GetText(type))
                    .AddPairWhenValueNotNull("sourcepath", sourcePath)
                    .AddPairWhenValueNotNull("linenumber", lineNumber)
                    .AddPairWhenValueNotNull("columnnumber", columnNumber)
                    .AddPairWhenValueNotNull("code", code));
        }

        public void SetVariable(string name, string value, bool? isSecret = null)
        {
            WriteCommand(
                "task.setvariable",
                value,
                dictionaryConfigurator: x => x
                    .AddPair("variable", name)
                    .AddPairWhenValueNotNull("issecret", isSecret));
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

        // https://github.com/microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md
        public void WriteCommand(
            string command,
            string message = null,
            Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator = null)
        {
            var escapedTokens =
                dictionaryConfigurator?
                    .Invoke(new Dictionary<string, object>())
                    .Select(x => $"{x.Key}={EscapeValue(x.Value.ToString())}").ToArray()
                ?? new string[0];

            Write(command, escapedTokens, message);
        }

        private void Write(string command, string[] escapedTokens, [CanBeNull] string message)
        {
            _messageSink.Invoke($"##vso[{command} {escapedTokens.JoinSemicolon()}]{EscapeMessage(message)}");
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
