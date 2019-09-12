// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityVcsTrigger : TeamCityTrigger
    {
        public string BranchFilter { get; set; }
        public string TriggerRules { get; set; }

        public override void Write(TeamCityConfigurationWriter writer)
        {
            using (writer.WriteBlock("vcs"))
            {
                writer.WriteLine($"branchFilter = {BranchFilter.DoubleQuote()}");
                writer.WriteLine($"triggerRules = {TriggerRules.DoubleQuote()}");
            }
        }
    }
}
