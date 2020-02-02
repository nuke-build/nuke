// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityFinishBuildTrigger : TeamCityTrigger
    {
        public TeamCityBuildType BuildType { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("finishBuildTrigger"))
            {
                writer.WriteLine($"buildType = {$"${{{BuildType.Id}.id}}".DoubleQuote()}");
            }
        }
    }
}
