// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.EnvironmentInfo;

namespace Nuke.Common.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="http://devcenter.bitrise.io/faq/available-environment-variables/#exposed-by-bitriseio">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    [ExcludeFromCodeCoverage]
    public class Bitrise
    {
        private static Lazy<Bitrise> s_instance = new Lazy<Bitrise>(() => new Bitrise());

        public static Bitrise Instance => NukeBuild.Host == HostType.Bitrise ? s_instance.Value : null;

        internal static bool IsRunningBitrise => Environment.GetEnvironmentVariable("BITRISE_BUILD_URL") != null;

        private static DateTime ConvertUnixTimestamp(long timestamp)
        {
            return new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc)
                .AddSeconds(timestamp)
                .ToLocalTime();
        }

        internal Bitrise()
        {
        }

        public string BuildUrl => GetVariable<string>("BITRISE_BUILD_URL");
        public long BuildNumber => GetVariable<long>("BITRISE_BUILD_NUMBER");
        public string AppTitle => GetVariable<string>("BITRISE_APP_TITLE");
        public string AppUrl => GetVariable<string>("BITRISE_APP_URL");
        public string AppSlug => GetVariable<string>("BITRISE_APP_SLUG");
        public string BuildSlug => GetVariable<string>("BITRISE_BUILD_SLUG");
        public DateTime BuildTriggerTimestamp => ConvertUnixTimestamp(GetVariable<long>("BITRISE_BUILD_TRIGGER_TIMESTAMP"));
        public string RepositoryUrl => GetVariable<string>("GIT_REPOSITORY_URL");
        public string GitBranch => GetVariable<string>("BITRISE_GIT_BRANCH");
        [CanBeNull] public string GitTag => GetVariable<string>("BITRISE_GIT_TAG");
        [CanBeNull] public string GitCommit => GetVariable<string>("BITRISE_GIT_COMMIT");
        [CanBeNull] public string GitMessage => GetVariable<string>("BITRISE_GIT_MESSAGE");
        [CanBeNull] public long? PullRequest => GetVariable<long?>("BITRISE_PULL_REQUEST");
        [CanBeNull] public string ProvisionUrl => GetVariable<string>("BITRISE_PROVISION_URL");
        [CanBeNull] public string CertificateUrl => GetVariable<string>("BITRISE_CERTIFICATE_URL");
        [CanBeNull] public string CertificatePassphrase => GetVariable<string>("BITRISE_CERTIFICATE_PASSPHRASE");
    }
}
