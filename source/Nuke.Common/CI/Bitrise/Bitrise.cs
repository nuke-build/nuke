// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.Bitrise
{
    /// <summary>
    /// Interface according to the <a href="http://devcenter.bitrise.io/faq/available-environment-variables/#exposed-by-bitriseio">official website</a>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public class Bitrise : Host, IBuildServer
    {
        public new static Bitrise Instance => Host.Instance as Bitrise;

        internal static bool IsRunningBitrise => EnvironmentInfo.HasVariable("BITRISE_BUILD_URL");

        private static DateTime ConvertUnixTimestamp(long timestamp)
        {
            return new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc)
                .AddSeconds(timestamp)
                .ToLocalTime();
        }

        internal Bitrise()
        {
        }

        string IBuildServer.Branch => GitBranch;
        string IBuildServer.Commit => GitCommit;

        public string BuildUrl => EnvironmentInfo.GetVariable("BITRISE_BUILD_URL");
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("BITRISE_BUILD_NUMBER");
        public string AppTitle => EnvironmentInfo.GetVariable("BITRISE_APP_TITLE");
        public string AppUrl => EnvironmentInfo.GetVariable("BITRISE_APP_URL");
        [NoConvert] public string AppSlug => EnvironmentInfo.GetVariable("BITRISE_APP_SLUG");
        [NoConvert] public string BuildSlug => EnvironmentInfo.GetVariable("BITRISE_BUILD_SLUG");
        public DateTime BuildTriggerTimestamp => ConvertUnixTimestamp(EnvironmentInfo.GetVariable<long>("BITRISE_BUILD_TRIGGER_TIMESTAMP"));
        public string RepositoryUrl => EnvironmentInfo.GetVariable("GIT_REPOSITORY_URL");
        public string GitBranch => EnvironmentInfo.GetVariable("BITRISE_GIT_BRANCH");
        [CanBeNull] public string GitTag => EnvironmentInfo.GetVariable("BITRISE_GIT_TAG");
        [CanBeNull] public string GitCommit => EnvironmentInfo.GetVariable("BITRISE_GIT_COMMIT");
        [CanBeNull] public string GitMessage => EnvironmentInfo.GetVariable("BITRISE_GIT_MESSAGE");
        [CanBeNull] public long? PullRequest => EnvironmentInfo.GetVariable<long?>("BITRISE_PULL_REQUEST");
        [CanBeNull] public string ProvisionUrl => EnvironmentInfo.GetVariable("BITRISE_PROVISION_URL");
        [CanBeNull] public string CertificateUrl => EnvironmentInfo.GetVariable("BITRISE_CERTIFICATE_URL");
        [CanBeNull] public string CertificatePassphrase => EnvironmentInfo.GetVariable("BITRISE_CERTIFICATE_PASSPHRASE");
    }
}
