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
// [CustomNotifySlack(ReportBuilds = BuildReporting.OnlyFailing)]
partial class Build : IHazSlackCredentials, IHazAzurePipelinesAccessToken
{
    const string SlackGeneral = "C9Q99MFU0";

    public class CustomNotifySlackAttribute : NotifySlackAttribute
    {
        public override string ReceiverId => Host switch
        {
            AppVeyor appveyor => appveyor.JobName.TrimStart("Image: ") switch
            {
                "Visual Studio 2019" => "C01ML0PRVST",
                "Ubuntu1804" => "C01N0PFG73L",
                _ => throw new Exception(appveyor.JobName)
            },
            GitHubActions actions => actions.GitHubJob switch
            {
                "windows-latest" => "C01NDCGA12M",
                "macOS-latest" => "C01ML0NMPAB",
                "ubuntu-latest" => "C01N6UACLG4",
                _ => throw new Exception(actions.GitHubJob)
            },
            AzurePipelines pipelines => pipelines.StageName switch
            {
                "windows_latest" => "C01NDV8HVNV",
                "macOS_latest" => "C01MUHCL03Y",
                "ubuntu_latest" => "C01N7FNN9E0",
                _ => throw new Exception(pipelines.StageName)
            },
            TeamCity teamcity => "C01NR66S62U",
            _ => null
        };

        public override bool Distributed => Host is
            Nuke.Common.CI.TeamCity.TeamCity or
            Nuke.Common.CI.AzurePipelines.AzurePipelines;
    }
}
#endif
