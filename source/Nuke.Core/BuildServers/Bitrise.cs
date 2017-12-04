// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="http://devcenter.bitrise.io/faq/available-environment-variables/#exposed-by-bitriseio">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    public class Bitrise
    {
        [CanBeNull]
        public static Bitrise Instance { get; } = NukeBuild.Instance?.Host == HostType.Bitrise ? new Bitrise() : null;

        internal static bool IsRunningBitrise => Variable("BITRISE_BUILD_URL") != null;

        private static DateTime ConvertUnixTimestamp (long timestamp)
        {
            return new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc)
                    .AddSeconds(value: 1501444668)
                    .ToLocalTime();
        }

        internal Bitrise ()
        {
        }

        public string BuildUrl => EnsureVariable("BITRISE_BUILD_URL");
        public long BuildNumber => EnsureVariable<long>("BITRISE_BUILD_NUMBER");
        public string AppTitle => EnsureVariable("BITRISE_APP_TITLE");
        public string AppUrl => EnsureVariable("BITRISE_APP_URL");
        public string AppSlug => EnsureVariable("BITRISE_APP_SLUG");
        public string BuildSlug => EnsureVariable("BITRISE_BUILD_SLUG");
        public DateTime BuildTriggerTimestamp => ConvertUnixTimestamp(EnsureVariable<long>("BITRISE_BUILD_TRIGGER_TIMESTAMP"));
        public string RepositoryUrl => EnsureVariable("GIT_REPOSITORY_URL");
        public string GitBranch => EnsureVariable("BITRISE_GIT_BRANCH");
        [CanBeNull] public string GitTag => Variable("BITRISE_GIT_TAG");
        [CanBeNull] public string GitCommit => Variable("BITRISE_GIT_COMMIT");
        [CanBeNull] public string GitMessage => Variable("BITRISE_GIT_MESSAGE");
        [CanBeNull] public string PullRequest => Variable("BITRISE_PULL_REQUEST");
        public string ProvisionUrl => EnsureVariable("BITRISE_PROVISION_URL");
        public string CertificateUrl => EnsureVariable("BITRISE_CERTIFICATE_URL");
        public string CertificatePassphrase => EnsureVariable("BITRISE_CERTIFICATE_PASSPHRASE");
    }
}
