// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.GitHubActions;
using Nuke.Components;

[GitHubActions(
    "windows-latest",
    GitHubActionsImage.WindowsLatest,
    Submodules = GitHubActionsSubmodules.Recursive,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MasterBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    PublishArtifacts = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
    EnableGitHubToken = true)]
[GitHubActions(
    "macos-latest",
    GitHubActionsImage.MacOsLatest,
    Submodules = GitHubActionsSubmodules.Recursive,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MasterBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    PublishArtifacts = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
    EnableGitHubToken = true)]
[GitHubActions(
    "ubuntu-latest",
    GitHubActionsImage.UbuntuLatest,
    Submodules = GitHubActionsSubmodules.Recursive,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MasterBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch },
    PublishArtifacts = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack), nameof(IPublish.Publish) },
    CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
    EnableGitHubToken = true,
    ImportSecrets = new[] { nameof(FeedzNuGetApiKey) })]
partial class Build
{
}
