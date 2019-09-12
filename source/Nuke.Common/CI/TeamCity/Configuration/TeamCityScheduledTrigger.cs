// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityScheduledTrigger : TeamCityTrigger
    {
        public string BranchFilter { get; set; }
        public string TriggerRules { get; set; }
        public bool TriggerBuildAlways { get; set; } //TODO: check
        public bool WithPendingChangesOnly { get; set; }
        public bool EnableQueueOptimization { get; set; }

        public override void Write(TeamCityConfigurationWriter writer)
        {
            using (writer.WriteBlock("schedule"))
            {
                using (writer.WriteBlock("schedulingPolicy = daily"))
                {
                    writer.WriteLine("hour = 3");
                    writer.WriteLine("timezone = \"Europe/Berlin\"");
                }

                writer.WriteLine($"branchFilter = {BranchFilter.DoubleQuote()}");
                writer.WriteLine($"triggerRules = {TriggerRules.DoubleQuote()}");
                writer.WriteLine("triggerBuild = always()");
                writer.WriteLine("withPendingChangesOnly = false");
                writer.WriteLine($"enableQueueOptimization = {EnableQueueOptimization.ToString().ToLowerInvariant()}");
                writer.WriteLine("param(\"cronExpression_min\", \"3\")");
            }
        }
    }
}
