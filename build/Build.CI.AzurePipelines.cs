// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Components;
#if NUKE_ENTERPRISE
using Nuke.Enterprise.Notifications;
using static Nuke.Enterprise.Notifications.IHazSlackCredentials;
#endif

[AzurePipelines(
    suffix: null,
    AzurePipelinesImage.UbuntuLatest,
    AzurePipelinesImage.WindowsLatest,
    AzurePipelinesImage.MacOsLatest,
    PullRequestsDisabled = true,
    ImportSecrets = new[]
                    {
                        nameof(EnterpriseAccessToken),
#if NUKE_ENTERPRISE
                        Slack + nameof(IHazSlackCredentials.UserAccessToken),
#endif
                    },
#if NUKE_ENTERPRISE
    ImportSystemAccessTokenAs = IHazAzurePipelinesAccessToken.AzurePipelines + nameof(IHazAzurePipelinesAccessToken.AccessToken),
#endif
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPack.Pack) },
    NonEntryTargets = new[] { nameof(IRestore.Restore), nameof(ICompile.Compile), nameof(InstallFonts), nameof(ReleaseImage) },
    ExcludedTargets = new[] { nameof(Clean), nameof(ISignPackages.SignPackages) },
    CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" })]
partial class Build
{
    public class AzurePipelinesAttribute : Nuke.Common.CI.AzurePipelines.AzurePipelinesAttribute
    {
        public AzurePipelinesAttribute(
            string suffix,
            AzurePipelinesImage image,
            params AzurePipelinesImage[] images)
            : base(suffix, image, images)
        {
        }

        protected override AzurePipelinesJob GetJob(
            ExecutableTarget executableTarget,
            LookupTable<ExecutableTarget, AzurePipelinesJob> jobs,
            IReadOnlyCollection<ExecutableTarget> relevantTargets,
            AzurePipelinesImage image)
        {
            var job = base.GetJob(executableTarget, jobs, relevantTargets, image);

            var symbol = CustomNames.GetValueOrDefault(job.Name).NotNull("symbol != null");
            job.DisplayName = job.Parallel == 0
                ? $"{symbol} {job.DisplayName}"
                : $"{symbol} {job.DisplayName} 🧩";
            return job;
        }
    }
}
