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
    InvokedTargets = new[] { nameof(IPack.Pack), nameof(ITest.Test), nameof(ISignPackages.SignPackages), nameof(IPublish.Publish) },
    Secrets =
        new string[]
        {
            AppVeyorSecrets.EnterpriseAccessToken,
            AppVeyorSecrets.NuGetApiKey,
            AppVeyorSecrets.SignPathApiToken,
            AppVeyorSecrets.TwitterConsumerKey,
            AppVeyorSecrets.TwitterConsumerSecret,
            AppVeyorSecrets.TwitterAccessToken,
            AppVeyorSecrets.TwitterAccessTokenSecret,
            AppVeyorSecrets.GitterAuthToken,
            AppVeyorSecrets.SlackWebhook,
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
        const string EnterpriseAccessTokenValue = "xN0u4hko5f9nZKV8l87oQpE5awbItu1NaGgw2m2lX+5diHwjcCbJNKyOMP3quZm4";

        public const string NuGetApiKey = NuGetApiKeyName + ":" + NuGetApiKeyValue;
        const string NuGetApiKeyName = nameof(PublicNuGetApiKey);
        const string NuGetApiKeyValue = "eeJb0U4UaZ7VnH8mfrei0NMxm3MPahOI7gLfxzGgoKLRBXKlr+8/2ayCY+uwdg7T";

        public const string SignPathApiToken = SignPathApiTokenName + ":" + SignPathApiTokenValue;
        const string SignPathApiTokenName = ISignPackages.SignPath + nameof(ISignPackages.ApiToken);
        const string SignPathApiTokenValue = "uQTH2MxpqiqWTy7EJkjtNc43ipG17EUOQN99QsODRNgtNEcikDaP0t4ylekK/ibn";

        public const string TwitterConsumerKey = TwitterConsumerKeyName + ":" + TwitterConsumerKeyValue;
        const string TwitterConsumerKeyName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerKey);
        const string TwitterConsumerKeyValue = "g9xYsdPVSbFnEXt2QBsZabR624Cfi5E7k76rnL2ujNo=";

        public const string TwitterConsumerSecret = TwitterConsumerSecretName + ":" + TwitterConsumerSecretValue;
        const string TwitterConsumerSecretName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.ConsumerSecret);
        const string TwitterConsumerSecretValue = "Hl5jVyh3PLXLc12WVdeuDLOM2yPaCGSkrukmvPkg9ZTrWw5GPrMkPWNKByNNxPTiRPJ+8aWZtgotaH9kbT/IkA==";

        public const string TwitterAccessToken = TwitterAccessTokenName + ":" + TwitterAccessTokenValue;
        const string TwitterAccessTokenName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessToken);
        const string TwitterAccessTokenValue = "nnv1h5nkNm4MS50soQHiYeWM0nW3SDJlE2EOW1IGnqL7i13rfycZ+Mc4tCGFtWLyhwy/8D/A2mudAxNlsaJ8cQ==";

        public const string TwitterAccessTokenSecret = TwitterAccessTokenSecretName + ":" + TwitterAccessTokenSecretValue;
        const string TwitterAccessTokenSecretName = IHazTwitterCredentials.Twitter + nameof(IHazTwitterCredentials.AccessTokenSecret);
        const string TwitterAccessTokenSecretValue = "apNpXzxTpZ5CSrmzVGTCuJTeBUtNlNVgKmQsscXdpS59B5tqZLkUZXMW2XYQIcR6";

        public const string GitterAuthToken = GitterAuthTokenName + ":" + GitterAuthTokenValue;
        const string GitterAuthTokenName = nameof(Build.GitterAuthToken);
        const string GitterAuthTokenValue = "Fy//YC4mL9IipkXG3OENTpC9g2qOtU32/5WU6PHw/HLty8YjvHXHsnTkk0HWJJMw";

        public const string SlackWebhook = SlackWebhookName + ":" + SlackWebhookValue;
        const string SlackWebhookName = nameof(Build.SlackWebhook);
        const string SlackWebhookValue = "xENxLITTR28hBLEY51YWMeHhxkhg1h1tLY1zGre1/hkn8u/b12lFivnxtTPuMWjAYkoPLlkJ4v39FLYPcxGYbAxRRMcJiHjrNyPtFfK6ddo=";

#if ENTERPRISE
        public const string SlackUserAccessToken = SlackUserAccessTokenName + ":" + SlackUserAccessTokenValue;
        const string SlackUserAccessTokenName = IHazSlackCredentials.Slack + nameof(IHazSlackCredentials.UserAccessToken);
        const string SlackUserAccessTokenValue = "cMArtN7cGnW6zI9ryMiQZSfcv2y+6Ads8KPvZIN18IQnpTBY6zzBEyCL+1i8v4OF08HW7oY3BDIXWEMT6PdeSQ==";
#endif
    }
}
