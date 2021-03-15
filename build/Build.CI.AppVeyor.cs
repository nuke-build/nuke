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
    AppVeyorImage.Ubuntu1804,
    SkipTags = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    Secrets =
        new string[]
        {
            // AppVeyorSecrets.EnterpriseAccessToken,
            // AppVeyorSecrets.NuGetApiKey,
            // AppVeyorSecrets.SignPathApiToken,
            // AppVeyorSecrets.TwitterConsumerKey,
            // AppVeyorSecrets.TwitterConsumerSecret,
            // AppVeyorSecrets.TwitterAccessToken,
            // AppVeyorSecrets.TwitterAccessTokenSecret,
            // AppVeyorSecrets.GitterAuthToken,
#if ENTERPRISE
            // AppVeyorSecrets.SlackAppAccessToken,
            // AppVeyorSecrets.SlackUserAccessToken
#endif
        })]
partial class Build
{
    public static class AppVeyorSecrets
    {
        public const string EnterpriseAccessToken = EnterpriseAccessTokenName + ":" + EnterpriseAccessTokenValue;
        const string EnterpriseAccessTokenName = nameof(Build.EnterpriseAccessToken);
        const string EnterpriseAccessTokenValue = "TODO";

        public const string NuGetApiKey = NuGetApiKeyName + ":" + NuGetApiKeyValue;
        const string NuGetApiKeyName = nameof(IPublish.NuGetApiKey);
        const string NuGetApiKeyValue = "TODO";

        public const string SignPathApiToken = SignPathApiTokenName + ":" + SignPathApiTokenValue;
        const string SignPathApiTokenName = ISignPackages.SignPath + nameof(ISignPackages.ApiToken);
        const string SignPathApiTokenValue = "TODO";

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
        public const string SlackAppAccessToken = SlackAppAccessTokenName + ":" + SlackAppAccessTokenValue;
        const string SlackAppAccessTokenName = IHazSlackCredentials.Slack + nameof(IHazSlackCredentials.AppAccessToken);
        const string SlackAppAccessTokenValue = "TODO";

        public const string SlackUserAccessToken = SlackUserAccessTokenName + ":" + SlackUserAccessTokenValue;
        const string SlackUserAccessTokenName = IHazSlackCredentials.Slack + nameof(IHazSlackCredentials.UserAccessToken);
        const string SlackUserAccessTokenValue = "TODO";
#endif
    }
}
