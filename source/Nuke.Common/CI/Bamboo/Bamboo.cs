// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Bamboo
{
    /// <summary>
    /// Interface according to the <a href="https://confluence.atlassian.com/bamboo/bamboo-variables-289277087.html">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class Bamboo : IBuildServer
    {
        private static Lazy<Bamboo> s_instance = new Lazy<Bamboo>(() => new Bamboo());

        public static Bamboo Instance => NukeBuild.Host == HostType.Bamboo ? s_instance.Value : null;

        internal static bool IsRunningBamboo => !Environment.GetEnvironmentVariable("BAMBOO_SERVER").IsNullOrEmpty();

        internal Bamboo()
        {
        }

        public long AgentId => EnvironmentInfo.GetVariable<long>("bamboo_agentId");
        public AbsolutePath AgentWorkingDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("bamboo_agentWorkingDirectory");
        public string AgentHome => EnvironmentInfo.GetVariable<string>("BAMBOO_AGENT_HOME");
        public string BuildKey => EnvironmentInfo.GetVariable<string>("bamboo_buildKey");
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("bamboo_buildNumber");
        public string BuildPlanName => EnvironmentInfo.GetVariable<string>("bamboo_buildPlanName");
        public string BuildResultsKey => EnvironmentInfo.GetVariable<string>("bamboo_buildResultKey");
        public string BuildResultsUrl => EnvironmentInfo.GetVariable<string>("bamboo_buildResultsUrl");
        public DateTime BuildTimeStamp => DateTime.Parse(EnvironmentInfo.GetVariable<string>("bamboo_buildTimeStamp"));
        public AbsolutePath BuildWorkingDirectory => EnvironmentInfo.GetVariable<AbsolutePath>("bamboo_build_working_directory");
        public bool BuildFailed => EnvironmentInfo.GetVariable<bool>("bamboo_buildFailed");
        public string PlanKey => EnvironmentInfo.GetVariable<string>("bamboo_planKey");
        public string ShortPlanKey => EnvironmentInfo.GetVariable<string>("bamboo_shortPlanKey");
        public string PlanName => EnvironmentInfo.GetVariable<string>("bamboo_planName");
        public string ShortPlanName => EnvironmentInfo.GetVariable<string>("bamboo_shortPlanName");
        public string PlanStorageTag => EnvironmentInfo.GetVariable<string>("bamboo_plan_storageTag");
        public string PlanResultsUrl => EnvironmentInfo.GetVariable<string>("bamboo_resultsUrl");
        public string ShortJobKey => EnvironmentInfo.GetVariable<string>("bamboo_shortJobKey");
        public string ShortJobName => EnvironmentInfo.GetVariable<string>("bamboo_shortJobName");
        [CanBeNull] public string PlanRepositoryBranchName => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.branchName");
        [CanBeNull] public string PlanRepositoryName => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.name");
        [CanBeNull] public string PlanRepositoryRevision => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.revision");
        [CanBeNull] public string PlanRepositoryBranch => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.branch");
        [CanBeNull] public string PlanRepositoryRepositoryUrl => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.repositoryUrl");
        [CanBeNull] public string PlanRepositoryPreviousRevision => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.previousRevision");
        [CanBeNull] public string PlanRepositoryType => EnvironmentInfo.GetVariable<string>("bamboo.planRepository.type");
        [CanBeNull] public string RepositoryPullRequestKey => EnvironmentInfo.GetVariable<string>("bamboo.repository.pr.key");
        [CanBeNull] public string RepositoryPullSourceBranch => EnvironmentInfo.GetVariable<string>("bamboo.repository.pr.sourceBranch");
        [CanBeNull] public string RepositoryPullTargetBranch => EnvironmentInfo.GetVariable<string>("bamboo.repository.pr.targetBranch");

        #region IBuildServer
        HostType IBuildServer.Host => HostType.Bamboo;
        string IBuildServer.BuildNumber => BuildNumber.ToString();
        AbsolutePath IBuildServer.SourceDirectory => BuildWorkingDirectory;
        AbsolutePath IBuildServer.OutputDirectory => null;
        string IBuildServer.SourceBranch => string.IsNullOrWhiteSpace(RepositoryPullSourceBranch) ? PlanRepositoryBranch : RepositoryPullSourceBranch;
        string IBuildServer.TargetBranch => RepositoryPullTargetBranch;

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
