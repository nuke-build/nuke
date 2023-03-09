// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    [PublicAPI]
    public class TeamCityScheduledTrigger : TeamCityTrigger
    {
        public string[] BranchFilters { get; set; }
        public string[] TriggerRules { get; set; }
        public bool TriggerBuildAlways { get; set; }
        public bool WithPendingChangesOnly { get; set; }
        public bool EnableQueueOptimization { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("schedule"))
            {
                using (writer.WriteBlock("schedulingPolicy = daily"))
                {
                    writer.WriteLine("hour = 3");
                }

                writer.WriteArray("branchFilter", BranchFilters);
                writer.WriteArray("triggerRules", TriggerRules);

                if (TriggerBuildAlways)
                    writer.WriteLine("triggerBuild = always()");

                writer.WriteLine("withPendingChangesOnly = false");
                writer.WriteLine($"enableQueueOptimization = {EnableQueueOptimization.ToString().ToLowerInvariant()}");
                writer.WriteLine("param(\"cronExpression_min\", \"3\")");
            }
        }
    }
}
