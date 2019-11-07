// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityConfiguration : ConfigurationEntity
    {
        public virtual string[] Header =>
            new[]
            {
                "// THIS FILE IS AUTO-GENERATED",
                "// ITS CONTENT IS OVERWRITTEN WITH EXCEPTION OF MARKED USER BLOCKS",
                "",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.buildFeatures.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.buildSteps.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.triggers.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.vcs.*",
                "",
                "version = \"2019.1\"",
                ""
            };

        public TeamCityProject Project { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            Header.ForEach(writer.WriteLine);
            Project.Write(writer);
            Project.VcsRoot.Write(writer);
            Project.BuildTypes.ForEach(x => x.Write(writer));
        }
    }
}
