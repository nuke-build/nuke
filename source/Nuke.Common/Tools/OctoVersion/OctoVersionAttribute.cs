// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Git;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.OctoVersion
{
    /// <summary>
    /// Injects an instance of <see cref="OctoVersion"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class OctoVersionAttribute : ValueInjectionAttributeBase
    {
        public string Framework { get; set; } = "net5.0";
        public bool UpdateBuildNumber { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var version = OctoVersionTasks.OctoVersionGetVersion(s => s
                .DisableProcessLogOutput()
                .SetOutputFormats(OctoVersionOutputFormatter.Json)
                .SetFramework(Framework)
                .When(NukeBuild.IsLocalBuild, s => s
                    .SetCurrentBranch(GitTasks.GitCurrentBranch())))
                .Result;

            if (UpdateBuildNumber)
            {
                AzurePipelines.Instance?.UpdateBuildNumber(version.FullSemVer);
                TeamCity.Instance?.SetBuildNumber(version.FullSemVer);
                AppVeyor.Instance?.UpdateBuildVersion(version.FullSemVer);
            }

            return version;
        }
    }
}
