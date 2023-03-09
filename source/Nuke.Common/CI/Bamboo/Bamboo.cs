// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Nuke.Common.CI.Bamboo
{
    /// <summary>
    /// Interface according to the <a href="https://confluence.atlassian.com/bamboo/bamboo-variables-289277087.html">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class Bamboo : Host, IBuildServer
    {
        public new static Bamboo Instance => Host.Instance as Bamboo;

        internal static bool IsRunningBamboo => EnvironmentInfo.HasVariable("bamboo_planKey");

        internal Bamboo()
        {
        }

        string IBuildServer.Branch => null;
        string IBuildServer.Commit => null;

        public long AgentId => EnvironmentInfo.GetVariable<long>("bamboo_agentId");
        public string AgentWorkingDirectory => EnvironmentInfo.GetVariable("bamboo_agentWorkingDirectory");
        public string AgentHome => EnvironmentInfo.GetVariable("BAMBOO_AGENT_HOME");
        public string BuildKey => EnvironmentInfo.GetVariable("bamboo_buildKey");
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("bamboo_buildNumber");
        public string BuildPlanName => EnvironmentInfo.GetVariable("bamboo_buildPlanName");
        public string BuildResultsKey => EnvironmentInfo.GetVariable("bamboo_buildResultKey");
        public string BuildResultsUrl => EnvironmentInfo.GetVariable("bamboo_buildResultsUrl");
        public DateTime BuildTimeStamp => DateTime.Parse(EnvironmentInfo.GetVariable("bamboo_buildTimeStamp"));
        public string BuildWorkingDirectory => EnvironmentInfo.GetVariable("bamboo_build_working_directory");
        public bool BuildFailed => EnvironmentInfo.GetVariable<bool>("bamboo_buildFailed");
        public string PlanKey => EnvironmentInfo.GetVariable("bamboo_planKey");
        public string ShortPlanKey => EnvironmentInfo.GetVariable("bamboo_shortPlanKey");
        public string PlanName => EnvironmentInfo.GetVariable("bamboo_planName");
        public string ShortPlanName => EnvironmentInfo.GetVariable("bamboo_shortPlanName");
        public string PlanStorageTag => EnvironmentInfo.GetVariable("bamboo_plan_storageTag");
        public string PlanResultsUrl => EnvironmentInfo.GetVariable("bamboo_resultsUrl");
        public string ShortJobKey => EnvironmentInfo.GetVariable("bamboo_shortJobKey");
        public string ShortJobName => EnvironmentInfo.GetVariable("bamboo_shortJobName");
    }
}
