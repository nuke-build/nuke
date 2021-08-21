// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.TeamCity.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using Nuke.Components;
#if NUKE_ENTERPRISE
using Nuke.Enterprise.Notifications;
using static Nuke.Enterprise.Notifications.IHazSlackCredentials;
#endif

[TeamCity(
    VcsTriggeredTargets =
        new[]
        {
            nameof(IPack.Pack),
            nameof(ITest.Test),
            nameof(IReportDuplicates.ReportDuplicates),
            nameof(IReportIssues.ReportIssues),
            nameof(IReportCoverage.ReportCoverage)
        },
    NonEntryTargets =
        new[]
        {
            nameof(IRestore.Restore),
            nameof(ICompile.Compile),
            nameof(InstallFonts),
            nameof(ReleaseImage)
        },
    ExcludedTargets = new[] { nameof(Clean), nameof(ISignPackages.SignPackages) },
    ImportSecrets = new[]
                    {
                        nameof(EnterpriseAccessToken),
#if NUKE_ENTERPRISE
                        Slack + nameof(IHazSlackCredentials.UserAccessToken),
#endif
                    })]
partial class Build
{
    public class TeamCityAttribute : Nuke.Common.CI.TeamCity.TeamCityAttribute
    {
        protected override IEnumerable<TeamCityBuildType> GetBuildTypes(
            NukeBuild build,
            ExecutableTarget executableTarget,
            TeamCityVcsRoot vcsRoot,
            LookupTable<ExecutableTarget, TeamCityBuildType> buildTypes,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return base.GetBuildTypes(build, executableTarget, vcsRoot, buildTypes, relevantTargets)
                .ForEachLazy(x =>
                {
                    var symbol = CustomNames.GetValueOrDefault(x.InvokedTargets.Last()).NotNull("symbol != null");
                    x.Name = x.Partition == Partition.Single
                        ? $"{symbol} {x.Name}"
                        : $"{symbol} {x.InvokedTargets.Last()} 🧩 {x.Partition}";
                });
        }
    }
}
