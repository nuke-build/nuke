// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AppVeyor;
using Nuke.Components;
#if ENTERPRISE
using Nuke.Enterprise.Notifications;
#endif

[AppVeyor(
    suffix: null,
    AppVeyorImage.VisualStudio2019,
    BranchesOnly = new[] { MasterBranch, "/" + ReleaseBranchPrefix + "\\/*/" },
    SkipTags = true,
    InvokedTargets = new[] { nameof(IPack.Pack), nameof(ITest.Test), nameof(ISignPackages.SignPackages) },
    Secrets =
        new string[]
        {
            AppVeyorSecrets.EnterpriseAccessToken,
            AppVeyorSecrets.NuGetApiKey,
            AppVeyorSecrets.SignPathApiToken,
            // AppVeyorSecrets.TwitterConsumerKey,
            // AppVeyorSecrets.TwitterConsumerSecret,
            // AppVeyorSecrets.TwitterAccessToken,
            // AppVeyorSecrets.TwitterAccessTokenSecret,
            // AppVeyorSecrets.GitterAuthToken,
#if ENTERPRISE
            AppVeyorSecrets.SlackUserAccessToken
#endif
        })]
[AppVeyor(
    suffix: "continuous",
    AppVeyorImage.VisualStudio2019,
    AppVeyorImage.Ubuntu1804,
    BranchesExcept = new[] { MasterBranch, "/" + ReleaseBranchPrefix + "\\/*/" },
    SkipTags = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    Secrets =
        new string[]
        {
            AppVeyorSecrets.EnterpriseAccessToken,
#if ENTERPRISE
            AppVeyorSecrets.SlackUserAccessToken
#endif
        })]
partial class Build
{
    public static class AppVeyorSecrets
    {
        public const string EnterpriseAccessToken = EnterpriseAccessTokenName + ":" + EnterpriseAccessTokenValue;
        const string EnterpriseAccessTokenName = nameof(Build.EnterpriseAccessToken);
        const string EnterpriseAccessTokenValue = "YLojRV4xp5V+aZTpuu4rrXvLi4IG+b+wdOMnzTwM0A/s/HBndTYjqFn/Q33WhnnQ";

        public const string NuGetApiKey = NuGetApiKeyName + ":" + NuGetApiKeyValue;
        const string NuGetApiKeyName = nameof(IPublish.NuGetApiKey);
        const string NuGetApiKeyValue = "eeJb0U4UaZ7VnH8mfrei0NMxm3MPahOI7gLfxzGgoKLRBXKlr+8/2ayCY+uwdg7T";

        public const string SignPathApiToken = SignPathApiTokenName + ":" + SignPathApiTokenValue;
        const string SignPathApiTokenName = ISignPackages.SignPath + nameof(ISignPackages.ApiToken);
        const string SignPathApiTokenValue = "uQTH2MxpqiqWTy7EJkjtNc43ipG17EUOQN99QsODRNgtNEcikDaP0t4ylekK/ibn";

        public const string TwitterConsumerKey = TwitterConsumerKeyName + ":" + TwitterConsumerKeyValue;
        const string TwitterConsumerKeyName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerKey);
        const string TwitterConsumerKeyValue = "TODO";

        public const string TwitterConsumerSecret = TwitterConsumerSecretName + ":" + TwitterConsumerSecretValue;
        const string TwitterConsumerSecretName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerSecret);
        const string TwitterConsumerSecretValue = "TODO";

        public const string TwitterAccessToken = TwitterAccessTokenName + ":" + TwitterAccessTokenValue;
        const string TwitterAccessTokenName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessToken);
        const string TwitterAccessTokenValue = "TODO";

        public const string TwitterAccessTokenSecret = TwitterAccessTokenSecretName + ":" + TwitterAccessTokenSecretValue;
        const string TwitterAccessTokenSecretName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret);
        const string TwitterAccessTokenSecretValue = "TODO";

        public const string GitterAuthToken = GitterAuthTokenName + ":" + GitterAuthTokenValue;
        const string GitterAuthTokenName = nameof(Build.GitterAuthToken);
        const string GitterAuthTokenValue = "TODO";

#if ENTERPRISE
        public const string SlackUserAccessToken = SlackUserAccessTokenName + ":" + SlackUserAccessTokenValue;
        const string SlackUserAccessTokenName = IHazSlackCredentials.Slack + nameof(IHazSlackCredentials.UserAccessToken);
        const string SlackUserAccessTokenValue = "cMArtN7cGnW6zI9ryMiQZSfcv2y+6Ads8KPvZIN18IQnpTBY6zzBEyCL+1i8v4OF08HW7oY3BDIXWEMT6PdeSQ==";
#endif
    }
}
