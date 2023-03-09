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
    public class TeamCityBuildTypeVcsRoot : ConfigurationEntity
    {
        public TeamCityVcsRoot Root { get; set; }
        public bool ShowDependenciesChanges { get; set; }
        public bool CleanCheckoutDirectory { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("vcs"))
            {
                writer.WriteLine($"root({Root.Id})");
                if (CleanCheckoutDirectory)
                    writer.WriteLine("cleanCheckout = true");
                if (ShowDependenciesChanges)
                    writer.WriteLine("showDependenciesChanges = true");
            }
        }
    }
}
