// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    [PublicAPI]
    public class TeamCityConfiguration : ConfigurationEntity
    {
        public virtual string[] Header =>
            new[]
            {
                "import jetbrains.buildServer.configs.kotlin.v2018_1.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.buildFeatures.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.buildSteps.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.triggers.*",
                "import jetbrains.buildServer.configs.kotlin.v2018_1.vcs.*",
                "",
                $"version = {Version.DoubleQuote()}",
                ""
            };

        public string Version { get; set; }
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
