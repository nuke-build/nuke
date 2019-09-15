// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityBuildTypeVcsRoot : TeamCityConfigurationEntity
    {
        public TeamCityVcsRoot Root { get; set; }
        public bool ShowDependenciesChanges { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("vcs"))
            {
                writer.WriteLine($"root({Root.Id})");
                if (ShowDependenciesChanges)
                    writer.WriteLine("showDependenciesChanges = true");
            }
        }
    }
}
