// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AppVeyor;
using Nuke.Components;

[AppVeyor(
    suffix: null,
    AppVeyorImage.VisualStudio2022,
    BranchesOnly = new[] { MasterBranch, $"/{ReleaseBranchPrefix}\\/*/" },
    SkipTags = true,
    InvokedTargets = new[] { nameof(IPack.Pack), nameof(ITest.Test), nameof(ISignPackages.SignPackages), nameof(IPublish.Publish) },
    Secrets =
        new[]
        {
            nameof(PublicNuGetApiKey),
            $"{ISignPackages.SignPath}{nameof(ISignPackages.ApiToken)}",
            $"{ICreateGitHubRelease.GitHubRelease}{nameof(ICreateGitHubRelease.GitHubToken)}",
            $"{IHazTwitterCredentials.Twitter}{nameof(IHazTwitterCredentials.ConsumerKey)}",
            $"{IHazTwitterCredentials.Twitter}{nameof(IHazTwitterCredentials.ConsumerSecret)}",
            $"{IHazTwitterCredentials.Twitter}{nameof(IHazTwitterCredentials.AccessToken)}",
            $"{IHazTwitterCredentials.Twitter}{nameof(IHazTwitterCredentials.AccessTokenSecret)}",
            nameof(SlackWebhook),
            nameof(DiscordWebhook),
            nameof(MastodonAccessToken)
        })]
[AppVeyor(
    suffix: "continuous",
    AppVeyorImage.VisualStudioLatest,
    AppVeyorImage.UbuntuLatest,
    AppVeyorImage.MacOsLatest,
    BranchesExcept = new[] { MasterBranch, $"/{ReleaseBranchPrefix}\\/*/" },
    SkipTags = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    Secrets = new string[0])]
[AppVeyorSecret(nameof(PublicNuGetApiKey), "Fh8WVVqYaEyQutEwTfVrUTEzc287b4utnOzc77wYmOh3kyZ9wyojoncGxytOvt6M")]
[AppVeyorSecret(ICreateGitHubRelease.GitHubRelease + nameof(ICreateGitHubRelease.GitHubToken), "a5UfxXiDEere9GkCCN9TUUq2+8QHAJoeVpZudQZXdWyloZWE5xKOkqzpxdMoYDPSxrVbWxjXbk1Xe9p0OydwuGVnr/3DC//BguNeGtFddbyMWlAiX36XvD1ZGEgP+ZIN")]
[AppVeyorSecret(ISignPackages.SignPath + nameof(ISignPackages.ApiToken), "uQTH2MxpqiqWTy7EJkjtNc43ipG17EUOQN99QsODRNgtNEcikDaP0t4ylekK/ibn")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerKey), "T61zL4r+xtyj7b0aOGYCsyixrXHooXE759T8z3M67Lw=")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerSecret), "CZwdlO4PHT51Xr0Pe/mT6WpfBzQXsL0C3yWfHgXqdYrf22rx8ePEt5qpszWckbHE5Vh5ErtVfIAQgLeFrqe2Gg==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessToken), "nnv1h5nkNm4MS50soQHiYZk9hnPkWEMQP/5cdf6RJfDIL1gUYxLR7uBaAi1M4sswT0TQ7oL4TBIN/yziq33N5A==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret), "/RrBl2p46rlgpzBHweWeD0spt3JNZDsM8vABoI9Ao29+Z9D4rUYvpM5oHUWA8Lb6")]
[AppVeyorSecret(nameof(SlackWebhook), "xENxLITTR28hBLEY51YWMeHhxkhg1h1tLY1zGre1/hl7LyoC3HT+0Ft9rXAZBoUij6kag6PsFaF+7siaJIG7EFgnyXe9uK3sstrgKNl1bk0=")]
[AppVeyorSecret(nameof(DiscordWebhook), "K5WG8m71vcB56C75b0ErFPLYTsqywhPy8hSn49uqc5XBE7txUnZqWBHfbWCuU9AdFkm3TNgSYLoejjF59OgiACEn45fghVe7XCwAXo2l54ZXl08MZyBkJ8by9HsZirL9W+SeysNdw/Cfc0sxKrWcpDkn1IH2zZ+iXAgqBsW2CNY=")]
[AppVeyorSecret(nameof(MastodonAccessToken), "pD/C1TvhUnFtb0oLUvlf2NtjkWeZQcrUVvYJE/LgZb8nxagK8Lwk+OR7TUqOh+Nn")]
partial class Build
{
}
