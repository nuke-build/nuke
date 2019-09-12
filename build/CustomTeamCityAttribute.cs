// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.CI.TeamCity.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

partial class Build
{
    public class CustomTeamCityAttribute : TeamCityAttribute
    {
        public CustomTeamCityAttribute(TeamCityAgentPlatform platform)
            : base(platform)
        {
        }

        protected override IEnumerable<TeamCityBuildType> GetBuildTypes(
            NukeBuild build,
            ExecutableTarget executableTarget,
            TeamCityVcsRoot vcsRoot,
            LookupTable<ExecutableTarget, TeamCityBuildType> buildTypes)
        {
            var dictionary = new Dictionary<string, string>
                             {
                                 { nameof(Compile), "⚙️" },
                                 { nameof(Test), "🚦" },
                                 { nameof(Pack), "📦" },
                                 { nameof(Publish), "🚚" },
                                 { nameof(Announce), "🗣" }
                             };
            return base.GetBuildTypes(build, executableTarget, vcsRoot, buildTypes)
                .ForEachLazy(x =>
                {
                    if (dictionary.TryGetValue(x.Name, out var prefix))
                        x.Name = $"{prefix} {x.Name}";
                    else if (dictionary.TryGetValue(x.PartitionTarget, out var prefix2))
                        x.Name = $"{prefix2} {x.PartitionTarget} 🧩 {x.Partition}";
                });
        }
    }
}
