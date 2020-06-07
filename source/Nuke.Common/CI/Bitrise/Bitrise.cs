// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Bitrise
{
    /// <summary>
    /// Interface according to the <a href="http://devcenter.bitrise.io/faq/available-environment-variables/#exposed-by-bitriseio">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class Bitrise: IBuildServer
    {
        private static Lazy<Bitrise> s_instance = new Lazy<Bitrise>(() => new Bitrise());

        public static Bitrise Instance => NukeBuild.Host == HostType.Bitrise ? s_instance.Value : null;
        

        internal static bool IsRunningBitrise => !Environment.GetEnvironmentVariable("BITRISE_BUILD_URL").IsNullOrEmpty();

        private static DateTime ConvertUnixTimestamp(long timestamp)
        {
            return new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc)
                .AddSeconds(timestamp)
                .ToLocalTime();
        }

        internal Bitrise()
        {
        }

        public string TriggeredWorkflowID => EnvironmentInfo.GetVariable<string>("BITRISE_TRIGGERED_WORKFLOW_ID");
        public string TriggeredWorkflowTitle => EnvironmentInfo.GetVariable<string>("BITRISE_TRIGGERED_WORKFLOW_TITLE");
        public int BuildStatus => EnvironmentInfo.GetVariable<int>("BITRISE_BUILD_STATUS");
        public AbsolutePath SourceDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("BITRISE_SOURCE_DIR");
        public AbsolutePath DeployDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("BITRISE_DEPLOY_DIR");
        [CanBeNull] public string GitBranchDest => EnvironmentInfo.GetVariable<string>("BITRISEIO_GIT_BRANCH_DEST");
        public string GitRepositoryOwner => EnvironmentInfo.GetVariable<string>("BITRISEIO_GIT_REPOSITORY_OWNER");
        public string GitRepositorySlug => EnvironmentInfo.GetVariable<string>("BITRISEIO_GIT_REPOSITORY_SLUG");
        [CanBeNull] public string PullRequestRepositoryUrl => EnvironmentInfo.GetVariable<string>("BITRISEIO_PULL_REQUEST_REPOSITORY_URL");
        [CanBeNull]public string PullRequestMergeBranch => EnvironmentInfo.GetVariable<string>("BITRISEIO_PULL_REQUEST_MERGE_BRANCH");
        [CanBeNull]public string PullRequestHeadBranch => EnvironmentInfo.GetVariable<string>("BITRISEIO_PULL_REQUEST_HEAD_BRANCH");
        public Uri BuildUrl => EnvironmentInfo.GetVariable<Uri>("BITRISE_BUILD_URL");
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("BITRISE_BUILD_NUMBER");
        public string AppTitle => EnvironmentInfo.GetVariable<string>("BITRISE_APP_TITLE");
        public Uri AppUrl => EnvironmentInfo.GetVariable<Uri>("BITRISE_APP_URL");
        public string AppSlug => EnvironmentInfo.GetVariable<string>("BITRISE_APP_SLUG");
        public string BuildSlug => EnvironmentInfo.GetVariable<string>("BITRISE_BUILD_SLUG");
        public DateTime BuildTriggerTimestamp => ConvertUnixTimestamp(EnvironmentInfo.GetVariable<long>("BITRISE_BUILD_TRIGGER_TIMESTAMP"));
        public Uri RepositoryUrl => EnvironmentInfo.GetVariable<Uri>("GIT_REPOSITORY_URL");
        public string GitBranch => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_BRANCH");
        [CanBeNull] public string GitTag => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_TAG");
        [CanBeNull] public string GitCommit => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_COMMIT");
        [CanBeNull] public string GitMessage => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_MESSAGE");
        [CanBeNull] public long? PullRequest => EnvironmentInfo.GetVariable<long?>("BITRISE_PULL_REQUEST");
        [CanBeNull] public string ProvisionUrl => EnvironmentInfo.GetVariable<string>("BITRISE_PROVISION_URL");
        [CanBeNull] public string CertificateUrl => EnvironmentInfo.GetVariable<string>("BITRISE_CERTIFICATE_URL");
        [CanBeNull] public string CertificatePassphrase => EnvironmentInfo.GetVariable<string>("BITRISE_CERTIFICATE_PASSPHRASE");

        #region IBuildServer
        HostType IBuildServer.Host => HostType.Bitrise;
        string IBuildServer.BuildNumber => BuildNumber.ToString();
        AbsolutePath IBuildServer.SourceDirectory => SourceDirectory;
        AbsolutePath IBuildServer.OutputDirectory => DeployDirectory;
        string IBuildServer.SourceBranch => GitBranch;
        string IBuildServer.TargetBranch => GitBranchDest;

        void IBuildServer.IssueWarning(string message, string file, int? line, int? column, string code)
        {
            Logger.Warn(message);
        }

        void IBuildServer.IssueError(string message, string file, int? line, int? column, string code)
        {
            Logger.Error(message);
        }

        void IBuildServer.SetEnvironmentVariable(string name, string value)
        {
            Logger.Trace("Setting environment variables are not supported by {0}", ((IBuildServer) this ).Host.ToString());
        }

        void IBuildServer.SetOutputParameter(string name, string value)
        {
            Logger.Trace("Setting output parameters are not supported by {0}", ((IBuildServer) this ).Host.ToString());
        }

        void IBuildServer.PublishArtifact(AbsolutePath artifactPath)
        {
            Logger.Trace("publishing artifacts are not supported by {0}", ((IBuildServer) this ).Host.ToString());
        }

        void IBuildServer.UpdateBuildNumber(string buildNumber) { }
        #endregion
    }
}
