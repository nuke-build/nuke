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
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
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
        /// <summary>
        /// Which framework to use when selecting the OctoVersion library from the package
        /// </summary>
        public string Framework { get; set; } = "net5.0";

        /// <summary>
        /// Whether to update the CI build number.
        /// Supports AzurePipelines, TeamCity and AppVeyor.
        /// </summary>
        public bool UpdateBuildNumber { get; set; }

        /// <summary>
        /// Whether to emit the version number attributes to the host (CI) environment.
        /// Defaults to `true` if running in a CI environment.
        /// </summary>
        public bool EmitToHost { get; set; } = NukeBuild.IsServerBuild;

        public bool AutoDetectBranch { get; set; } = true;

        [CanBeNull] public string Branch { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            if (AutoDetectBranch)
                ControlFlow.Assert(string.IsNullOrEmpty(Branch), $"If {nameof(AutoDetectBranch)} is enabled, then {nameof(Branch)} should not be specified.");
            if (!AutoDetectBranch)
                ControlFlow.Assert(!string.IsNullOrEmpty(Branch), $"If {nameof(AutoDetectBranch)} is disabled, then {nameof(Branch)} should be specified.");

            var tempOutputFile = NukeBuild.TemporaryDirectory / $"octoversion.{Guid.NewGuid()}.json";
            var version = OctoVersionTasks.OctoVersionGetVersion(s => s
                    .SetFramework(Framework)
                    .SetOutputJsonFile(tempOutputFile)
                    .When(EmitToHost, x => x.EnableDetectEnvironment())
                    .When(!EmitToHost, x => x.SetOutputFormats("JsonFile", "Console"))
                    .When(!string.IsNullOrEmpty(Branch), x=> x.SetCurrentBranch(Branch))
                    .When(AutoDetectBranch,
                        x =>
                        {
                            var gitRepository = GitRepository.FromLocalDirectory(NukeBuild.RootDirectory);
                            return x.SetCurrentBranch(gitRepository.Branch);
                        }))
                .Result;
            FileSystemTasks.DeleteFile(tempOutputFile);

            if (UpdateBuildNumber)
            {
                AzurePipelines.Instance?.UpdateBuildNumber(version.FullSemVer);
                //this also happens inside OctoVersion for TeamCity, when EmitToHost is set
                TeamCity.Instance?.SetBuildNumber(version.FullSemVer);
                AppVeyor.Instance?.UpdateBuildVersion(version.FullSemVer);
            }

            return version;
        }
    }
}
