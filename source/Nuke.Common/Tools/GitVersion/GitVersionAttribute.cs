// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.GitVersion
{
    /// <summary>
    /// Injects an instance of <see cref="GitVersion"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : ValueInjectionAttributeBase
    {
        public string Framework { get; set; } = "netcoreapp3.0";
        public bool DisableOnUnix { get; set; }
        public bool UpdateAssemblyInfo { get; set; }
        public bool UpdateBuildNumber { get; set; } = true;
        public bool NoFetch { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            // TODO: https://github.com/GitTools/GitVersion/issues/1097
            if (EnvironmentInfo.IsUnix && DisableOnUnix)
            {
                Logger.Warn($"{nameof(GitVersion)} is disabled on UNIX environment.");
                return null;
            }

            var gitVersion = GitVersionTasks.GitVersion(s => s
                    .SetFramework(Framework)
                    .SetNoFetch(NoFetch)
                    .DisableLogOutput()
                    .SetUpdateAssemblyInfo(UpdateAssemblyInfo))
                .Result;

            if (UpdateBuildNumber)
            {
                AzurePipelines.Instance?.UpdateBuildNumber(gitVersion.FullSemVer);
                TeamCity.Instance?.SetBuildNumber(gitVersion.FullSemVer);
                AppVeyor.Instance?.UpdateBuildNumber($"{gitVersion.FullSemVer}.build.{AppVeyor.Instance.BuildNumber}");
            }

            return gitVersion;
        }
    }
}
