// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

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
        internal static bool IsRunningBamboo => !Environment.GetEnvironmentVariable("BAMBOO_SERVER").IsNullOrEmpty();

        internal Bamboo()
        {
        }

        string IBuildServer.Branch => null;
        string IBuildServer.Commit => null;

        public long AgentId => EnvironmentInfo.GetVariable<long>("bamboo_agentId");
        public string AgentWorkingDirectory => EnvironmentInfo.GetVariable<string>("bamboo_agentWorkingDirectory");
        public string AgentHome => EnvironmentInfo.GetVariable<string>("BAMBOO_AGENT_HOME");
        public string BuildKey => EnvironmentInfo.GetVariable<string>("bamboo_buildKey");
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("bamboo_buildNumber");
        public string BuildPlanName => EnvironmentInfo.GetVariable<string>("bamboo_buildPlanName");
        public string BuildResultsKey => EnvironmentInfo.GetVariable<string>("bamboo_buildResultKey");
        public string BuildResultsUrl => EnvironmentInfo.GetVariable<string>("bamboo_buildResultsUrl");
        public DateTime BuildTimeStamp => DateTime.Parse(EnvironmentInfo.GetVariable<string>("bamboo_buildTimeStamp"));
        public string BuildWorkingDirectory => EnvironmentInfo.GetVariable<string>("bamboo_build_working_directory");
        public bool BuildFailed => EnvironmentInfo.GetVariable<bool>("bamboo_buildFailed");
        public string PlanKey => EnvironmentInfo.GetVariable<string>("bamboo_planKey");
        public string ShortPlanKey => EnvironmentInfo.GetVariable<string>("bamboo_shortPlanKey");
        public string PlanName => EnvironmentInfo.GetVariable<string>("bamboo_planName");
        public string ShortPlanName => EnvironmentInfo.GetVariable<string>("bamboo_shortPlanName");
        public string PlanStorageTag => EnvironmentInfo.GetVariable<string>("bamboo_plan_storageTag");
        public string PlanResultsUrl => EnvironmentInfo.GetVariable<string>("bamboo_resultsUrl");
        public string ShortJobKey => EnvironmentInfo.GetVariable<string>("bamboo_shortJobKey");
        public string ShortJobName => EnvironmentInfo.GetVariable<string>("bamboo_shortJobName");
    }
}
