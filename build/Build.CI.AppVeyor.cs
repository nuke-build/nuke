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
[AppVeyorSecret(nameof(PublicNuGetApiKey), "dSaquYHVNEAZO+hhGGoGqeHaVP99BP8koHTTqcD3WInWBTmB7yE4CzxZ1pWypnX2")]
[AppVeyorSecret(ISignPackages.SignPath + nameof(ISignPackages.ApiToken), "uQTH2MxpqiqWTy7EJkjtNc43ipG17EUOQN99QsODRNgtNEcikDaP0t4ylekK/ibn")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerKey), "C+ETCF4nwvdQjX00z613rtdBfLePQnoU+KDajdxuUJM=")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerSecret), "KtMo935mJ2UmINXevKZyr1cmin1Ho7g8f/+VMxAQKvvw0eLSKqJHHfZNqhg/dMWc+Sh6BxzDlW+MGWkDGvSTSA==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessToken), "nnv1h5nkNm4MS50soQHiYV0sAK3Jpmc3RqRNiCWmBJc1iS8bYmOTSmaUVcjUbY/U2wJ2SpeNgZffswsaKY3qVw==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret), "RlLDa3WfOftTieTJ30hY8jM54FrA/z6FPxv5QmowPlgTuxRCGxKiEXcux5DQO9fx")]
[AppVeyorSecret(nameof(SlackWebhook), "xENxLITTR28hBLEY51YWMeHhxkhg1h1tLY1zGre1/hmM/XDRPsJCxvZvTHFhtfLsQ3cF7GQi3xDaShkVVR7zoXHsIYT+KT0zLnq9FSEvr5c=")]
[AppVeyorSecret(nameof(DiscordWebhook), "K5WG8m71vcB56C75b0ErFPLYTsqywhPy8hSn49uqc5XBE7txUnZqWBHfbWCuU9AdFkm3TNgSYLoejjF59OgiACEn45fghVe7XCwAXo2l54ZXl08MZyBkJ8by9HsZirL9W+SeysNdw/Cfc0sxKrWcpDkn1IH2zZ+iXAgqBsW2CNY=")]
[AppVeyorSecret(nameof(MastodonAccessToken), "pD/C1TvhUnFtb0oLUvlf2NtjkWeZQcrUVvYJE/LgZb8nxagK8Lwk+OR7TUqOh+Nn")]
partial class Build
{
}
