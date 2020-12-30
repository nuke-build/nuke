// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TeamCityAttribute : ConfigurationGeneratorAttributeBase
    {
        public TeamCityAttribute(TeamCityAgentPlatform platform)
        {
            Platform = platform;
        }

        public string[] NonEntryTargets { get; set; } = new string[0];
        public string[] ExcludedTargets { get; set; } = new string[0];

        public string Version { get; set; } = "2018.2";

        public TeamCityAgentPlatform Platform { get; }
        public string Description { get; set; }
        public bool CleanCheckoutDirectory { get; set; } = true;

        public string[] VcsTriggerBranchFilters { get; set; } = new string[0];
        public string[] VcsTriggerRules { get; set; } = { "+:**" };
        public string[] VcsTriggeredTargets { get; set; } = new string[0];

        public bool NightlyBuildAlways { get; set; } = true;
        public string[] NightlyTriggerBranchFilters { get; set; } = new string[0];
        public string[] NightlyTriggerRules { get; set; } = { "+:**" };
        public string[] NightlyTriggeredTargets { get; set; } = new string[0];

        public string[] ManuallyTriggeredTargets { get; set; } = new string[0];

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
    }
}
