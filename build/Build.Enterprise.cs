// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

#if ENTERPRISE

using System;
using Nuke.Common;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Git;
using Nuke.Enterprise.Auditing;
using Nuke.Enterprise.Notifications;

[AuditBuildMembers(
    DeclaringTypes = new[] { typeof(Build) },
    Members = new[] { nameof(RootDirectory), nameof(Host), nameof(Verbosity) })]
[DeploymentSlackNotification]
[BuildStatusSlackNotification]
partial class Build : IHazSlackCredentials, IHazAzurePipelinesAccessToken, IHazGitHubAccessToken
{
    string IHazGitHubAccessToken.AccessToken => GitHubToken;

    public class DeploymentSlackNotificationAttribute : SlackNotificationAttribute
    {
        public override bool ReportBuildAlways => Host is AppVeyor { ProjectSlug: "nuke-deployment" };

        public override string ReceiverId => Host switch
        {
            AppVeyor { ProjectSlug: "nuke-deployment", RepositoryBranch: "master" } => "C01SNUZL50V",
            AppVeyor { ProjectSlug: "nuke-deployment" } => "G01HT7MCQ2D",
            _ => null
        };
    }

    public class BuildStatusSlackNotificationAttribute : SlackNotificationAttribute
    {
        public override bool ReportBuildAlways => true;
        public override string ReceiverId => Host is GitHubActions _ or AppVeyor _ ? "U9S0MU8A3" : null;
        public override bool ShowCommits => false;
        public override bool ShowTargets => false;

        public override string Timestamp => Host switch
        {
            AppVeyor { ProjectSlug: "nuke-continuous", JobName: "Image: Visual Studio 2019" } => "1617073137.006600",
            AppVeyor { ProjectSlug: "nuke-continuous", JobName: "Image: Ubuntu1804" } => "1617073148.007000",
            GitHubActions { GitHubJob: "windows-latest" } => "1617073157.007100",
            GitHubActions { GitHubJob: "macOS-latest" } => "1617073163.007200",
            GitHubActions { GitHubJob: "ubuntu-latest" } => "1617073169.007300",
            _ => throw new NotSupportedException(Host.ToString())
        };

        public override bool ShouldNotify(NukeBuild build) => ((Build) build).GitRepository.IsOnDevelopBranch();
    }
}
#endif
