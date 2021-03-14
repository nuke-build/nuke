// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AppVeyor;
using Nuke.Components;
#if ENTERPRISE
using Nuke.Enterprise.Notifications;
#endif

[AppVeyor(
    "continuous",
    AppVeyorImage.VisualStudio2019,
    AppVeyorImage.Ubuntu1804,
    BranchesOnly = new[] { DevelopBranch },
    SkipTags = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    Secrets =
        new[]
        {
            nameof(EnterpriseAccessToken)
            + ":3nWSVRsMDisi41a6kclhRl7pwacy5zLuWIMZy2J5yD+62uHga2Pquc1SiuIZgu2K",
#if ENTERPRISE
            nameof(IHazSlackCredentials.Slack)
            + nameof(IHazSlackCredentials.AppAccessToken)
            + ":HPPJFlTf6aaHXIbCYTkBIesRrjBIm1X0TijzI7xgI6ATYeAXuXoNiRABh/ORJn8RqX461KG7WgkZcWfxiNaGV4X99tc8SOwBMVAv/qk6INM=",
            nameof(IHazSlackCredentials.Slack)
            + nameof(IHazSlackCredentials.UserAccessToken)
            + ":cMArtN7cGnW6zI9ryMiQZSfcv2y+6Ads8KPvZIN18ITMd3ivAg4/E9JSh0CsFury1vzJ8haKI9lv2E+u4lUT9Q=="
#endif
        })]
[AppVeyor(
    "deployment",
    AppVeyorImage.VisualStudioLatest,
    BranchesOnly = new[]
                   {
                       MasterBranch,
                       "/" + ReleaseBranchPrefix + "\\/*/"
                   },
    InvokedTargets = new[] { nameof(IPublish.Publish) },
    SkipTags = true,
    Secrets =
        new[]
        {
            nameof(ISignPackages.SignPath)
            + nameof(ISignPackages.ApiToken)
            + ":zYFzA/7H1MDXDlpX6SAyv41kiBmu8Vh3kvWC7tPfk7eVdhh9mGQgXC7AzgcGnpsg",
#if ENTERPRISE
            nameof(IHazSlackCredentials.Slack)
            + nameof(IHazSlackCredentials.AppAccessToken)
            + ":HPPJFlTf6aaHXIbCYTkBIesRrjBIm1X0TijzI7xgI6ATYeAXuXoNiRABh/ORJn8RqX461KG7WgkZcWfxiNaGV4X99tc8SOwBMVAv/qk6INM=",
            nameof(IHazSlackCredentials.Slack)
            + nameof(IHazSlackCredentials.UserAccessToken)
            + ":cMArtN7cGnW6zI9ryMiQZSfcv2y+6Ads8KPvZIN18ITMd3ivAg4/E9JSh0CsFury1vzJ8haKI9lv2E+u4lUT9Q==",
#endif
            nameof(EnterpriseAccessToken)
            + ":3nWSVRsMDisi41a6kclhRl7pwacy5zLuWIMZy2J5yD+62uHga2Pquc1SiuIZgu2K",
            nameof(IPublish.NuGetApiKey)
            + ":TODO",
            nameof(GitterAuthToken)
            + ":TODO",
            nameof(IHazTwitterCredentials.Twitter)
            + nameof(IHazTwitterCredentials.ConsumerKey)
            + ":TODO",
            nameof(IHazTwitterCredentials.Twitter)
            + nameof(IHazTwitterCredentials.ConsumerSecret)
            + ":TODO",
            nameof(IHazTwitterCredentials.Twitter)
            + nameof(IHazTwitterCredentials.AccessToken)
            + ":TODO",
            nameof(IHazTwitterCredentials.Twitter)
            + nameof(IHazTwitterCredentials.AccessTokenSecret)
            + ":TODO",
        })]
partial class Build
{
}
