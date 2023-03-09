// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AppVeyor;
using Nuke.Components;

[AppVeyor(
    suffix: null,
    AppVeyorImage.VisualStudio2022,
    Submodules = true,
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
            nameof(GitterAuthToken),
            nameof(SlackWebhook),
            nameof(DiscordWebhook),
            nameof(MastodonAccessToken)
        })]
[AppVeyor(
    suffix: "continuous",
    AppVeyorImage.VisualStudioLatest,
    AppVeyorImage.UbuntuLatest,
    AppVeyorImage.MacOsLatest,
    Submodules = true,
    BranchesExcept = new[] { MasterBranch, $"/{ReleaseBranchPrefix}\\/*/" },
    SkipTags = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    Secrets = new string[0])]
[AppVeyorSecret(nameof(PublicNuGetApiKey), "hgiwc3jsX4mUWkALWzpYY/VwN5AX/K3Pzev7D+//V0PshWdWs9CYiDNVrDlFUp9q")]
[AppVeyorSecret(ISignPackages.SignPath + nameof(ISignPackages.ApiToken), "uQTH2MxpqiqWTy7EJkjtNc43ipG17EUOQN99QsODRNgtNEcikDaP0t4ylekK/ibn")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerKey), "BY+J0NeFwJrIk/IcLlApwCrhwPFYbs17ryopOEU8S80=")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerSecret), "LzY8VaBdbjdHtbCIJusREn5foh6wOEKqwBqsmBgpyhulQs21PkgYs2tilSL+SowcJw3p4QH6QKLOEp3uGwTj8g==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessToken), "nnv1h5nkNm4MS50soQHiYXVUf0UR+gx54imrggateey6oA+rdCdna0TaUCH1vsDwHEitHDPRdx39xjJMBzwRxA==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret), "OGFEkW5fHl0YJzKnTTWJ3oHhQfjMs9RWGJMjeQ2HMIG+yUwy0NQGVUY4qOCRgrXW")]
[AppVeyorSecret(nameof(GitterAuthToken), "Fy//YC4mL9IipkXG3OENTpC9g2qOtU32/5WU6PHw/HLty8YjvHXHsnTkk0HWJJMw")]
[AppVeyorSecret(nameof(SlackWebhook), "xENxLITTR28hBLEY51YWMeHhxkhg1h1tLY1zGre1/hkmagda0rH4ZxOTbJ1bcmC3D6uhvJKLtSHqY7TK/48Nw3EbvN9wNFEt97HWYc9FE+g=")]
[AppVeyorSecret(nameof(DiscordWebhook), "K5WG8m71vcB56C75b0ErFPLYTsqywhPy8hSn49uqc5XBE7txUnZqWBHfbWCuU9AdFkm3TNgSYLoejjF59OgiACEn45fghVe7XCwAXo2l54ZXl08MZyBkJ8by9HsZirL9W+SeysNdw/Cfc0sxKrWcpDkn1IH2zZ+iXAgqBsW2CNY=")]
[AppVeyorSecret(nameof(MastodonAccessToken), "pD/C1TvhUnFtb0oLUvlf2NtjkWeZQcrUVvYJE/LgZb8nxagK8Lwk+OR7TUqOh+Nn")]
partial class Build
{
}
