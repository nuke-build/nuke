using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
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
    public class AzurePipelines: IBuildServer
    {
        private static Lazy<AzurePipelines> s_instance = new Lazy<AzurePipelines>(() => new AzurePipelines());

        public static AzurePipelines Instance => NukeBuild.Host == Common.HostType.AzurePipelines ? s_instance.Value : null;

        internal static bool IsRunningAzurePipelines => !Environment.GetEnvironmentVariable("TF_BUILD").IsNullOrEmpty();

        private readonly Action<string> _messageSink;

        internal AzurePipelines(Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;
        }

        public string AgentBuildDirectory => EnvironmentInfo.GetVariable<string>("AGENT_BUILDDIRECTORY");
        public AbsolutePath AgentHomeDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("AGENT_HOMEDIRECTORY");
        public long AgentId => EnvironmentInfo.GetVariable<long>("AGENT_ID");
        public string AgentJobName => EnvironmentInfo.GetVariable<string>("AGENT_JOBNAME");
        public AzurePipelinesJobStatus AgentJobStatus => EnvironmentInfo.GetVariable<AzurePipelinesJobStatus>("AGENT_JOBSTATUS");
        public string AgentMachineName => EnvironmentInfo.GetVariable<string>("AGENT_MACHINENAME");
        public string AgentName => EnvironmentInfo.GetVariable<string>("AGENT_NAME");
        public AzurePipelinesOperatingSystem AgentOperatingSystem => AzurePipelinesOperatingSystem.Parse(EnvironmentInfo.GetVariable<string>("AGENT_OS"));
        public AzurePipelinesOperatingSystemArchitecture AgentOperatingSystemArchitecture => EnvironmentInfo.GetVariable<AzurePipelinesOperatingSystemArchitecture>("AGENT_OSARCHITECTURE");
        public AbsolutePath AgentTempDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("AGENT_TEMPDIRECTORY");
        public AbsolutePath AgentToolsDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("AGENT_TOOLSDIRECTORY");
        public AbsolutePath AgentWorkFolder => EnvironmentInfo.GetVariable<AbsolutePath>("AGENT_WORKFOLDER");
        public AbsolutePath ArtifactStagingDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("BUILD_ARTIFACTSTAGINGDIRECTORY");
        public long BuildId => EnvironmentInfo.GetVariable<long>("BUILD_BUILDID");
        [NoConvert] public string BuildNumber => EnvironmentInfo.GetVariable<string>("BUILD_BUILDNUMBER");
        public string BuildUri => EnvironmentInfo.GetVariable<string>("BUILD_BUILDURI");
        public AbsolutePath BinariesDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("BUILD_BINARIESDIRECTORY");
        public long? ContainerId => EnvironmentInfo.GetVariable<long?>("BUILD_CONTAINERID");
        public string DefinitionName => EnvironmentInfo.GetVariable<string>("BUILD_DEFINITIONNAME");
        public long DefinitionVersion => EnvironmentInfo.GetVariable<long>("BUILD_DEFINITIONVERSION");
        public string QueuedBy => EnvironmentInfo.GetVariable<string>("BUILD_QUEUEDBY");
        public Guid QueuedById => EnvironmentInfo.GetVariable<Guid>("BUILD_QUEUEDBYID");
        public AzurePipelinesBuildReason BuildReason => EnvironmentInfo.GetVariable<AzurePipelinesBuildReason>("BUILD_REASON");
        public bool RepositoryClean => EnvironmentInfo.GetVariable<bool>("BUILD_REPOSITORY_CLEAN");
        public AbsolutePath RepositoryLocalPath => EnvironmentInfo.GetVariable<AbsolutePath>("BUILD_REPOSITORY_LOCALPATH");
        public string RepositoryId => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_ID");
        public string RepositoryName => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_NAME");

        public AzurePipelinesRepositoryType RepositoryProvider =>
            EnvironmentInfo.GetVariable<AzurePipelinesRepositoryType>("BUILD_REPOSITORY_PROVIDER");

        [CanBeNull] public string RepositoryTfvcWorkspace => EnvironmentInfo.GetVariable<string>("BUILD_REPOSITORY_TFVC_WORKSPACE");
        public Uri RepositoryUri => EnvironmentInfo.GetVariable<Uri>("BUILD_REPOSITORY_URI");
        public string RequestedFor => EnvironmentInfo.GetVariable<string>("BUILD_REQUESTEDFOR");
        public string RequestedForEmail => EnvironmentInfo.GetVariable<string>("BUILD_REQUESTEDFOREMAIL");
        public Guid RequestedForId => EnvironmentInfo.GetVariable<Guid>("BUILD_REQUESTEDFORID");
        public string SourceBranch => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEBRANCH");
        public string SourceBranchName => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEBRANCHNAME");
        public AbsolutePath SourceDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("BUILD_SOURCESDIRECTORY");
        public string SourceVersion => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEVERSION");
        public string SourceVersionMessage => EnvironmentInfo.GetVariable<string>("BUILD_SOURCEVERSIONMESSAGE");
        public AbsolutePath StagingDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("BUILD_STAGINGDIRECTORY");
        public bool RepositoryGitSubmoduleCheckout => EnvironmentInfo.GetVariable<bool>("BUILD_REPOSITORY_GIT_SUBMODULECHECKOUT");
        [CanBeNull] public string SourceTfvcShelveset => EnvironmentInfo.GetVariable<string>("BUILD_SOURCETFVCSHELVESET");
        [CanBeNull] public int? TriggeredByBuildId => EnvironmentInfo.GetVariable<int?>("BUILD_TRIGGEREDBY_BUILDID");
        [CanBeNull] public int? TriggeredByDefinitionId => EnvironmentInfo.GetVariable<int?>("BUILD_TRIGGEREDBY_DEFINITIONID");
        [CanBeNull] public string TriggeredByDefinitionName => EnvironmentInfo.GetVariable<string>("BUILD_TRIGGEREDBY_DEFINITIONNAME");
        [CanBeNull] public string TriggeredByBuildNumber => EnvironmentInfo.GetVariable<string>("BUILD_TRIGGEREDBY_BUILDNUMBER");
        [CanBeNull] public Guid? TriggeredByProjectID => EnvironmentInfo.GetVariable<Guid?>("BUILD_TRIGGEREDBY_PROJECTID");
        public AbsolutePath TestResultsDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("COMMON_TESTRESULTSDIRECTORY");
        public AbsolutePath PipelineWorkspace => EnvironmentInfo.GetVariable<AbsolutePath>("PIPELINE_WORKSPACE");
        [CanBeNull] public string EnvironmentName => EnvironmentInfo.GetVariable<string>("ENVIRONMENT_NAME");
        [CanBeNull] public int? EnvironmentId => EnvironmentInfo.GetVariable<int?>("ENVIRONMENT_ID");
        [CanBeNull] public string EnvironmentResourceName => EnvironmentInfo.GetVariable<string>("ENVIRONMENT_RESOURCENAME");
        [CanBeNull] public int? EnvironmentResourceId => EnvironmentInfo.GetVariable<int?>("ENVIRONMENT_RESOURCEID");
        [CanBeNull] public string AccessToken => EnvironmentInfo.GetVariable<string>("SYSTEM_ACCESSTOKEN");
        public Guid CollectionId => EnvironmentInfo.GetVariable<Guid>("SYSTEM_COLLECTIONID");
        public Uri CollectionUri => EnvironmentInfo.GetVariable<Uri>("SYSTEM_COLLECTIONURI");
        public AbsolutePath DefaultWorkingDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("SYSTEM_DEFAULTWORKINGDIRECTORY");
        public long DefinitionId => EnvironmentInfo.GetVariable<long>("SYSTEM_DEFINITIONID");
        public AzurePipelinesHostType HostType => EnvironmentInfo.GetVariable<AzurePipelinesHostType>("SYSTEM_HOSTTYPE");
        public int JobAttempt => EnvironmentInfo.GetVariable<int>("SYSTEM_JOBATTEMPT");
        public string JobDisplayName => EnvironmentInfo.GetVariable<string>("SYSTEM_JOBDISPLAYNAME");
        public Guid? JobId => EnvironmentInfo.GetVariable<Guid?>("SYSTEM_JOBID");
        public string JobName => EnvironmentInfo.GetVariable<string>("SYSTEM_JOBNAME");
        public int PhaseAttempt => EnvironmentInfo.GetVariable<int>("SYSTEM_PHASEATTEMPT");
        public string PhaseDisplayName => EnvironmentInfo.GetVariable<string>("SYSTEM_PHASEDISPLAYNAME");
        public string PhaseName => EnvironmentInfo.GetVariable<string>("SYSTEM_PHASENAME");
        public int StageAttempt => EnvironmentInfo.GetVariable<int>("SYSTEM_STAGEATTEMPT");
        public string StageDisplayName => EnvironmentInfo.GetVariable<string>("SYSTEM_STAGEDISPLAYNAME");
        public string StageName => EnvironmentInfo.GetVariable<string>("SYSTEM_STAGENAME");
        public bool PullRequestIsFork => EnvironmentInfo.GetVariable<bool>("SYSTEM_PULLREQUEST_ISFORK");
        [CanBeNull] public long? PullRequestId => EnvironmentInfo.GetVariable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTID");
        [CanBeNull] public long? PullRequestNumber => EnvironmentInfo.GetVariable<long?>("SYSTEM_PULLREQUEST_PULLREQUESTNUMBER");
        [CanBeNull] public string PullRequestSourceBranch => EnvironmentInfo.GetVariable<string>("SYSTEM_PULLREQUEST_SOURCEBRANCH");
        [CanBeNull] public string PullRequestSourceRepositoryURI => EnvironmentInfo.GetVariable<string>("SYSTEM_PULLREQUEST_SOURCEREPOSITORYURI");
        [CanBeNull] public string PullRequestTargetBranch => EnvironmentInfo.GetVariable<string>("SYSTEM_PULLREQUEST_TARGETBRANCH");
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
                    .AddPair("containerfolder", containerDirectory)
                    .AddPair("artifactname", artifactName));
        }

        public void LogError(
            string message,
            string sourcePath = null,
            int? lineNumber = null,
            int? columnNumber = null,
            string code = null)
        {
            LogIssue(AzurePipelinesIssueType.Error, message, sourcePath, lineNumber, columnNumber, code);
        }

        public void LogWarning(
            string message,
            string sourcePath = null,
            int? lineNumber = null,
            int? columnNumber = null,
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
                    .AddPair("additionalCodeCoverageFiles", additionalCodeCoverageFiles.Join(",")));
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
                    .AddPair("resultFiles", files.Join(","))
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
            int? lineNumber = null,
            int? columnNumber = null,
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
        
        
        public void SetProgress(int percentage, string currentOperation = null)
        {
            WriteCommand(
                "task.setprogress",
                currentOperation,
                o => o.AddPair("value", percentage)
            );
        }

        public void SetVariable(
            string variable,
            string value,
            bool? isSecret = null,
            bool? isOutput = null,
            bool? isReadOnly = null
        )
        {
            WriteCommand(
                "task.setvariable",
                value,
                o => o.AddPair(nameof(variable), variable)
                    .AddPairWhenValueNotNull(nameof(isSecret).ToLower(), isSecret?.ToString().ToLower())
                    .AddPairWhenValueNotNull(nameof(isOutput).ToLower(), isOutput?.ToString().ToLower())
                    .AddPairWhenValueNotNull(nameof(isReadOnly).ToLower(), isReadOnly?.ToString().ToLower())
            );
        }

        public void UploadSummary(AbsolutePath path)
        {
            WriteCommand("task.uploadsummary", path);
        }

        public void UploadFile(AbsolutePath path)
        {
            WriteCommand("task.uploadfile", path);
        }

        public void AddPath(AbsolutePath path)
        {
            WriteCommand("task.prependpath", path);
        }

        public void AssociateArtifact(
            string artifactName,
            AzurePipelinesArtifactType artifactType,
            string path
        )
        {
            WriteCommand(
                "artifact.associate",
                path,
                x => x
                    .AddPair(nameof(artifactName).ToLower(), artifactName)
                    .AddPair("type", artifactType.ToString().ToLower())
            );
        }

        public void UploadArtifact(
            AbsolutePath packageDirectory,
            string containerFolder = null,
            string artifactName = null
        )
        {
            WriteCommand(
                "artifact.upload",
                packageDirectory,
                dictionaryConfigurator: x => x
                    .AddPairWhenValueNotNull(nameof(containerFolder).ToLower(), containerFolder ?? Path.GetDirectoryName(packageDirectory))
                    .AddPairWhenValueNotNull(nameof(artifactName).ToLower(), artifactName)
            );
        }

        public void UploadArtifact(
            string glob,
            string containerFolder = null,
            string artifactName = null
        )
        {
            WriteCommand(
                "artifact.upload",
                glob,
                dictionaryConfigurator: x => x
                    .AddPairWhenValueNotNull(nameof(containerFolder).ToLower(), containerFolder)
                    .AddPairWhenValueNotNull(nameof(artifactName).ToLower(), artifactName)
            );
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

        #region IBuildServer
        HostType IBuildServer.Host => Common.HostType.AzurePipelines;
        string IBuildServer.BuildNumber => BuildNumber;
        AbsolutePath IBuildServer.SourceDirectory => SourceDirectory;
        AbsolutePath IBuildServer.OutputDirectory => ArtifactStagingDirectory;
        string IBuildServer.SourceBranch => string.IsNullOrWhiteSpace(PullRequestSourceBranch) ? SourceBranchName : PullRequestSourceBranch;
        string IBuildServer.TargetBranch => PullRequestTargetBranch;

        void IBuildServer.IssueWarning(string message, string file, int? line, int? column, string code)
        {
            LogIssue(AzurePipelinesIssueType.Warning, message, file, line, column, code);
        }

        void IBuildServer.IssueError(string message, string file, int? line, int? column, string code)
        {
            LogIssue(AzurePipelinesIssueType.Warning, message, file, line, column, code);
        }

        void IBuildServer.SetEnvironmentVariable(string name, string value)
        {
            SetVariable(name.Replace("_", "."), value);
        }

        void IBuildServer.SetOutputParameter(string name, string value)
        {
            SetVariable(name, value, isOutput: true);
        }

        void IBuildServer.PublishArtifact(AbsolutePath artifactPath)
        {
            UploadArtifact(artifactPath);
        }

        void IBuildServer.UpdateBuildNumber(string buildNumber)
        {
            UpdateBuildNumber($"{buildNumber}.build.{BuildNumber}");
        }
        #endregion
    }
}
