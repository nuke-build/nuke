// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

#if ENTERPRISE

using System;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Utilities;
using Nuke.Enterprise.Auditing;
using Nuke.Enterprise.Notifications;

[AuditBuildMembers(
    DeclaringTypes = new[] { typeof(Build) },
    Members = new[] { nameof(RootDirectory), nameof(Host), nameof(Verbosity) })]
[CustomNotifySlack(ReportAllBuilds = true, ShowPassed = true, ShowSkipped = true)]
partial class Build : IHazSlackCredentials, IHazAzurePipelinesAccessToken
{
    const string SlackGeneral = "C9Q99MFU0";

    const string SlackGitHubActionsWindows = "C01NDCGA12M";
    const string SlackGitHubActionsMacOs = "C01ML0NMPAB";
    const string SlackGitHubActionsUbuntu = "C01N6UACLG4";
    const string SlackAppVeyorWindows = "C01ML0PRVST";
    const string SlackAppVeyorUbuntu = "C01N0PFG73L";
    const string SlackAzurePipelinesWindows = "C01NDV8HVNV";
    const string SlackAzurePipelinesMacOs = "C01MUHCL03Y";
    const string SlackAzurePipelinesUbuntu = "C01N7FNN9E0";
    const string SlackTeamCity = "C01NR66S62U";

    public class CustomNotifySlackAttribute : NotifySlackAttribute
    {
        public override string ReceiverId => Host switch
        {
            AppVeyor appveyor => appveyor.JobName.TrimStart("Image: ") switch
            {
                "Visual Studio 2019" => SlackAppVeyorWindows,
                "Ubuntu1804" => SlackAppVeyorUbuntu,
                _ => throw new Exception(appveyor.JobName)
            },
            GitHubActions actions => actions.GitHubJob switch
            {
                "windows-latest" => SlackGitHubActionsWindows,
                "macOS-latest" => SlackGitHubActionsMacOs,
                "ubuntu-latest" => SlackGitHubActionsUbuntu,
                _ => throw new Exception(actions.GitHubJob)
            },
            AzurePipelines pipelines => pipelines.StageName switch
            {
                "windows_latest" => SlackAzurePipelinesWindows,
                "macOS_latest" => SlackAzurePipelinesMacOs,
                "ubuntu_latest" => SlackAzurePipelinesUbuntu,
                _ => throw new Exception(pipelines.StageName)
            },
            TeamCity teamcity => SlackTeamCity,
            _ => null
        };

        public override bool Distributed => Host is
            Nuke.Common.CI.TeamCity.TeamCity or
            Nuke.Common.CI.AzurePipelines.AzurePipelines;
    }
}
#endif
