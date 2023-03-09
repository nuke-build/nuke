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
    public class TeamCityArtifactDependency : TeamCityDependency
    {
        public TeamCityBuildType BuildType { get; set; }
        public string[] ArtifactRules { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"artifacts({BuildType.Id})"))
            {
                writer.WriteArray("artifactRules", ArtifactRules);
            }
        }
    }
}
