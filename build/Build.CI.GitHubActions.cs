// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.GitHubActions;
using Nuke.Components;

[GitHubActions(
    "windows-latest",
    GitHubActionsImage.WindowsLatest,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MasterBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    PublishArtifacts = false)]
[GitHubActions(
    "macos-latest",
    GitHubActionsImage.MacOsLatest,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MasterBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    PublishArtifacts = false)]
[GitHubActions(
    "ubuntu-latest",
    GitHubActionsImage.UbuntuLatest,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MasterBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    PublishArtifacts = false)]
[GitHubActions(
    AlphaDeployment,
    GitHubActionsImage.UbuntuLatest,
    FetchDepth = 0,
    OnPushBranches = new[] { DevelopBranch },
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack), nameof(IPublish.Publish) },
    EnableGitHubToken = true,
    PublishArtifacts = false,
    ImportSecrets = new[] { nameof(FeedzNuGetApiKey) })]
partial class Build
{
    const string AlphaDeployment = "alpha-deployment";
}
