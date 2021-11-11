// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.GitLab;
using Nuke.Common.CI.SpaceAutomation;
using Nuke.Common.CI.TeamCity;
using Nuke.Components;
using Nuke.Notifications;

[CustomNotifications(VersionParameter = nameof(MajorMinorPatchVersion))]
partial class Build
{
    public class CustomNotificationsAttribute : NotificationsAttribute
    {
        public override bool SendStatus => Host is
            GitHubActions { Workflow: "continuous", Job: "ubuntu-latest" } or
            AppVeyor { ProjectSlug: "nuke-continuous", JobName: "Image: Visual Studio 2019" } or
            TeamCity { BuildTypeId: "Nuke_Test_P1T2" or "Nuke_Test_P2T2" } or
            AzurePipelines { StageName: "macOS_latest", PhaseName: nameof(IPack.Pack) } or
            GitLab or
            SpaceAutomation;

        public override bool EnableCancellation => true;

        public override IEnumerable<BuildAction> Actions
        {
            get
            {
                // if (Build.RunningTargets.Any(x => x.Name == "Compile"))
                //     yield return CreateLinkAction("Approve", "https://google.com", BuildActionStyle.Primary);

                yield break;
            }
        }
    }
}
