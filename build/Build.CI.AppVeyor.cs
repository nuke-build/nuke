﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AppVeyor;
using Nuke.Components;

[AppVeyor(
    suffix: null,
    AppVeyorImage.VisualStudio2019,
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
            nameof(SlackWebhook)
        })]
[AppVeyor(
    suffix: "continuous",
    AppVeyorImage.VisualStudioLatest,
    AppVeyorImage.UbuntuLatest,
    AppVeyorImage.MacOsLatest,
    BranchesExcept = new[] { MasterBranch, $"/{ReleaseBranchPrefix}\\/*/" },
    SkipTags = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) })]
[AppVeyorSecret(nameof(PublicNuGetApiKey), "eeJb0U4UaZ7VnH8mfrei0NMxm3MPahOI7gLfxzGgoKLRBXKlr+8/2ayCY+uwdg7T")]
[AppVeyorSecret(ISignPackages.SignPath + nameof(ISignPackages.ApiToken), "uQTH2MxpqiqWTy7EJkjtNc43ipG17EUOQN99QsODRNgtNEcikDaP0t4ylekK/ibn")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerKey), "BY+J0NeFwJrIk/IcLlApwCrhwPFYbs17ryopOEU8S80=")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerSecret), "LzY8VaBdbjdHtbCIJusREn5foh6wOEKqwBqsmBgpyhulQs21PkgYs2tilSL+SowcJw3p4QH6QKLOEp3uGwTj8g==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessToken), "nnv1h5nkNm4MS50soQHiYXVUf0UR+gx54imrggateey6oA+rdCdna0TaUCH1vsDwHEitHDPRdx39xjJMBzwRxA==")]
[AppVeyorSecret(IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret), "OGFEkW5fHl0YJzKnTTWJ3oHhQfjMs9RWGJMjeQ2HMIG+yUwy0NQGVUY4qOCRgrXW")]
[AppVeyorSecret(nameof(GitterAuthToken), "Fy//YC4mL9IipkXG3OENTpC9g2qOtU32/5WU6PHw/HLty8YjvHXHsnTkk0HWJJMw")]
[AppVeyorSecret(nameof(SlackWebhook), "xENxLITTR28hBLEY51YWMeHhxkhg1h1tLY1zGre1/hkn8u/b12lFivnxtTPuMWjAYkoPLlkJ4v39FLYPcxGYbAxRRMcJiHjrNyPtFfK6ddo=")]
partial class Build
{
}
