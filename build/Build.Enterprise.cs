// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

#if ENTERPRISE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Git;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
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

    public class DeploymentSlackNotificationAttribute : CustomSlackNotificationAttribute
    {
        public override bool ReportBuildAlways => Host is AppVeyor { ProjectSlug: "nuke-deployment" };

        public override string ReceiverId => Host switch
        {
            AppVeyor { ProjectSlug: "nuke-deployment", RepositoryBranch: "master" } => "C01SNUZL50V",
            AppVeyor { ProjectSlug: "nuke-deployment" } => "G01HT7MCQ2D",
            _ => null
        };
    }

    public class BuildStatusSlackNotificationAttribute : CustomSlackNotificationAttribute
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

    public abstract class CustomSlackNotificationAttribute : SlackNotificationAttribute
    {
        protected override string GetMessage(NukeBuild build, (string Sha, string Message, string Author, string Email, string UserId) lastCommitData)
        {
            var gitVersion = ((Build) build).GitVersion;
            if (gitVersion == null)
                return base.GetMessage(build, lastCommitData);

            var header = new[] { (Text: $"#{gitVersion.FullSemVer}", BuildServer.CommonUrls.First().Url) }
                .Concat(BuildServer.CommonUrls.Last())
                .Select(x => $"*<{x.Url}|{x.Text}>*").Join(" | ");

            return $":{GetIcon()}: {header}";
        }
    }
}
#endif
