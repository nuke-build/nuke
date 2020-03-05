// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Bitrise
{
    /// <summary>
    /// Interface according to the <a href="http://devcenter.bitrise.io/faq/available-environment-variables/#exposed-by-bitriseio">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class Bitrise
    {
        private static Lazy<Bitrise> s_instance = new Lazy<Bitrise>(() => new Bitrise());

        public static Bitrise Instance => NukeBuild.Host == HostType.Bitrise ? s_instance.Value : null;

        internal static bool IsRunningBitrise => !Environment.GetEnvironmentVariable("BITRISE_BUILD_URL").IsNullOrEmpty();

        private static DateTime ConvertUnixTimestamp(long timestamp)
        {
            return new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc)
                .AddSeconds(timestamp)
                .ToLocalTime();
        }

        internal Bitrise()
        {
        }

        public string BuildUrl => EnvironmentInfo.GetVariable<string>("BITRISE_BUILD_URL");
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("BITRISE_BUILD_NUMBER");
        public string AppTitle => EnvironmentInfo.GetVariable<string>("BITRISE_APP_TITLE");
        public string AppUrl => EnvironmentInfo.GetVariable<string>("BITRISE_APP_URL");
        public string AppSlug => EnvironmentInfo.GetVariable<string>("BITRISE_APP_SLUG");
        public string BuildSlug => EnvironmentInfo.GetVariable<string>("BITRISE_BUILD_SLUG");
        public DateTime BuildTriggerTimestamp => ConvertUnixTimestamp(EnvironmentInfo.GetVariable<long>("BITRISE_BUILD_TRIGGER_TIMESTAMP"));
        public string RepositoryUrl => EnvironmentInfo.GetVariable<string>("GIT_REPOSITORY_URL");
        public string GitBranch => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_BRANCH");
        [CanBeNull] public string GitTag => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_TAG");
        [CanBeNull] public string GitCommit => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_COMMIT");
        [CanBeNull] public string GitMessage => EnvironmentInfo.GetVariable<string>("BITRISE_GIT_MESSAGE");
        [CanBeNull] public long? PullRequest => EnvironmentInfo.GetVariable<long?>("BITRISE_PULL_REQUEST");
        [CanBeNull] public string ProvisionUrl => EnvironmentInfo.GetVariable<string>("BITRISE_PROVISION_URL");
        [CanBeNull] public string CertificateUrl => EnvironmentInfo.GetVariable<string>("BITRISE_CERTIFICATE_URL");
        [CanBeNull] public string CertificatePassphrase => EnvironmentInfo.GetVariable<string>("BITRISE_CERTIFICATE_PASSPHRASE");
    }
}
