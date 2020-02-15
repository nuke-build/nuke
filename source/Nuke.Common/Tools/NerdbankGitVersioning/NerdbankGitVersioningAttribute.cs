// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.GitVersion;

namespace Nuke.Common.Tools.NerdbankGitVersioning
{
    // <summary>
    /// Injects an instance of <see cref="NerdbankGitVersioning"/> based on the local repository.
    /// </summary>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class NerdbankGitVersioningAttribute : InjectionAttributeBase
    {
        /// <summary>
        /// The path to the project or project directory. The default is the root
        /// </summary>
        public string Project { get; set; }
        public bool UpdateBuildNumber { get; set; }
        public override object GetValue(MemberInfo member, object instance)
        {
            var gitVersion = NerdbankGitVersioningTasks.NerdbankGitVersioningGetVersion(s => s
                    .DisableLogOutput()
                    .SetFormat(Format.Json)
                    .SetProject(Project))
                .Result;
            if (UpdateBuildNumber)
            {
                AzurePipelines.Instance?.UpdateBuildNumber(gitVersion.SemVer2);
                TeamCity.Instance?.SetBuildNumber(gitVersion.SemVer2);
                AppVeyor.Instance?.UpdateBuildNumber(gitVersion.SemVer2);
            }
            return gitVersion;
        }
    }
}