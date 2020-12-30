// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.CI.TeamCity.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

partial class Build
{
    public class TeamCityAttribute : Nuke.Common.CI.TeamCity.TeamCityAttribute
    {
        public TeamCityAttribute(TeamCityAgentPlatform platform)
            : base(platform)
        {
        }

        public override IConfigurationGenerator GetConfigurationGenerator()
        {
            return new TeamCityConfigurationGenerator(Platform)
                   {
                       AutoGenerate = AutoGenerate,
                       NonEntryTargets = NonEntryTargets,
                       ExcludedTargets = ExcludedTargets,
                       Version = Version,
                       Description = Description,
                       CleanCheckoutDirectory = CleanCheckoutDirectory,
                       VcsTriggerBranchFilters = VcsTriggerBranchFilters,
                       VcsTriggerRules = VcsTriggerRules,
                       VcsTriggeredTargets = VcsTriggeredTargets,
                       NightlyBuildAlways = NightlyBuildAlways,
                       NightlyTriggerBranchFilters = NightlyTriggerBranchFilters,
                       NightlyTriggerRules = NightlyTriggerRules,
                       NightlyTriggeredTargets = NightlyTriggeredTargets,
                       ManuallyTriggeredTargets = ManuallyTriggeredTargets
                   };
        }

        private class TeamCityConfigurationGenerator : Nuke.Common.CI.TeamCity.TeamCityConfigurationGenerator
        {
            public TeamCityConfigurationGenerator(TeamCityAgentPlatform platform)
                : base(platform)
            {
            }

            protected override IEnumerable<TeamCityBuildType> GetBuildTypes(
                NukeBuild build,
                ExecutableTarget executableTarget,
                TeamCityVcsRoot vcsRoot,
                LookupTable<ExecutableTarget, TeamCityBuildType> buildTypes,
                IReadOnlyCollection<ExecutableTarget> relevantTargets)
            {
                var dictionary = new Dictionary<string, string>
                                 {
                                     { nameof(Compile), "⚙️" },
                                     { nameof(Test), "🚦" },
                                     { nameof(Pack), "📦" },
                                     { nameof(Coverage), "📊" },
                                     { nameof(Publish), "🚚" },
                                     { nameof(Announce), "🗣" }
                                 };
                return base.GetBuildTypes(build, executableTarget, vcsRoot, buildTypes, relevantTargets)
                    .ForEachLazy(x =>
                    {
                        var symbol = dictionary.GetValueOrDefault(x.InvokedTargets.Last()).NotNull("symbol != null");
                        x.Name = x.PartitionName == null
                            ? $"{symbol} {x.Name}"
                            : $"{symbol} {x.InvokedTargets.Last()} 🧩 {x.Partition}";
                    });
            }
        }
    }
}
