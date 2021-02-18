// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.GitHubActions;
using Nuke.Components;
using static Nuke.Components.IHazTwitterCredentials;
using static Nuke.Enterprise.Notifications.IHazSlackCredentials;
#if ENTERPRISE
using Nuke.Enterprise.Notifications;

#endif

[GitHubActions(
    "continuous",
    GitHubActionsImage.WindowsLatest,
    GitHubActionsImage.UbuntuLatest,
    GitHubActionsImage.MacOsLatest,
    OnPushBranchesIgnore = new[] { MasterBranch, ReleaseBranchPrefix + "/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    PublishArtifacts = false,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    ImportSecrets = new[]
                    {
                        nameof(IReportTestCoverage.CodecovToken),
                        nameof(EnterpriseAccessToken),
#if ENTERPRISE
                        Slack + nameof(IHazSlackCredentials.AppAccessToken),
                        Slack + nameof(IHazSlackCredentials.UserAccessToken),
#endif
                    })]
[GitHubActions(
    "deployment",
    GitHubActionsImage.MacOsLatest,
    OnPushBranches = new[] { MasterBranch },
    InvokedTargets = new[] { nameof(IPublish.Publish) },
    ImportGitHubTokenAs = nameof(GitHubToken),
    ImportSecrets =
        new[]
        {
            nameof(IPublish.NuGetApiKey),
            nameof(SlackWebhook),
            nameof(GitterAuthToken),
            Twitter + nameof(IHazTwitterCredentials.ConsumerKey),
            Twitter + nameof(IHazTwitterCredentials.ConsumerSecret),
            Twitter + nameof(IHazTwitterCredentials.AccessToken),
            Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret)
        })]
partial class Build
{
}
