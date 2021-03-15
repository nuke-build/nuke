// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

#if ENTERPRISE

using System;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Enterprise.Auditing;
using Nuke.Enterprise.Notifications;

[AuditBuildMembers(
    DeclaringTypes = new[] { typeof(Build) },
    Members = new[] { nameof(RootDirectory), nameof(Host), nameof(Verbosity) })]
[CustomNotifySlack(ReportBuildFailed = true, ReportBuildStatusChanged = true)]
partial class Build : IHazSlackCredentials, IHazAzurePipelinesAccessToken
{
    public class CustomNotifySlackAttribute : NotifySlackAttribute
    {
        public override bool ReportBuildSucceeded => Host is AppVeyor { ProjectSlug: "nuke-deployment" };

        public override string ReceiverId => Host switch
        {
            AppVeyor { ProjectSlug: "nuke-deployment" } => "C9Q99MFU0",
            AppVeyor { ProjectSlug: "nuke-continuous", JobName: "Image: Visual Studio 2019" } => "C01ML0PRVST",
            AppVeyor { ProjectSlug: "nuke-continuous", JobName: "Image: Ubuntu1804" } => "C01N0PFG73L",
            GitHubActions { GitHubJob: "windows-latest" } => "C01NDCGA12M",
            GitHubActions { GitHubJob: "macOS-latest" } => "C01ML0NMPAB",
            GitHubActions { GitHubJob: "ubuntu-latest" } => "C01N6UACLG4",
            AzurePipelines { StageName: "windows_latest" } => "C01NDV8HVNV",
            AzurePipelines { StageName: "macOS_latest" } => "C01MUHCL03Y",
            AzurePipelines { StageName: "ubuntu_latest" } => "C01N7FNN9E0",
            TeamCity _ => "C01NR66S62U",
            _ => throw new NotSupportedException(Host.ToString())
        };

        public override bool Distributed => Host is
            TeamCity _ or
            AzurePipelines _;
    }
}
#endif
