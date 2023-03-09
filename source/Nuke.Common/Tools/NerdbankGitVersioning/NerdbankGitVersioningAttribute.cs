// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Tooling;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.NerdbankGitVersioning
{
    /// <summary>
    /// Injects an instance of <see cref="NerdbankGitVersioning"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class NerdbankGitVersioningAttribute : ValueInjectionAttributeBase
    {
        public bool UpdateBuildNumber { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var version = NerdbankGitVersioningTasks.NerdbankGitVersioningGetVersion(s => s
                    .DisableProcessLogOutput()
                    .SetFormat(NerdbankGitVersioningFormat.json))
                .Result;

            if (UpdateBuildNumber)
            {
                AzurePipelines.Instance?.UpdateBuildNumber(version.SemVer2);
                TeamCity.Instance?.SetBuildNumber(version.SemVer2);
                AppVeyor.Instance?.UpdateBuildVersion($"{version.SemVer2}.build.{AppVeyor.Instance.BuildNumber}");
            }

            return version;
        }
    }
}
