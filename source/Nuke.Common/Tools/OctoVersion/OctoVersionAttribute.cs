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
using Nuke.Common.Utilities;
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
        /// Whether to update the build number and output octoversion attributes into the CI platform
        /// Supports AzurePipelines, TeamCity, AppVeyor and GitHubActions
        /// </summary>
        public bool UpdateBuildNumber { get; set; } = NukeBuild.IsServerBuild;

        /// <summary>
        /// Automatically detect the branch to pass to OctoVersion, based on the git worktree
        /// </summary>
        public bool AutoDetectBranch { get; set; } = true;

        /// <summary>
        /// The branch to pass to OctoVersion
        /// </summary>
        [CanBeNull] public string Branch { get; set; }
        
        /// <summary>
        /// The name of a Nuke parameter containing the branch to be passed to OctoVersion
        /// </summary>
        [CanBeNull] public string BranchParameter { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            // We support 3 mutually exclusive approaches to determining the branch to pass to OctoVersion
            // - auto detecting the branch here in Nuke
            // - pass the branch directly via Branch attribute
            // - pass the name of a Nuke parameter BranchParameter that contains the branch
            if (AutoDetectBranch)
            {
                ControlFlow.Assert(string.IsNullOrEmpty(Branch), $"If {nameof(AutoDetectBranch)} is enabled, then {nameof(Branch)} should not be specified.");
                ControlFlow.Assert(string.IsNullOrEmpty(BranchParameter), $"If {nameof(AutoDetectBranch)} is enabled, then {nameof(BranchParameter)} should not be specified.");
            }
            if (string.IsNullOrEmpty(Branch))
            {
                ControlFlow.Assert(!AutoDetectBranch, $"If {nameof(Branch)} is specified, then {nameof(AutoDetectBranch)} should not be enabled.");
                ControlFlow.Assert(string.IsNullOrEmpty(BranchParameter), $"If {nameof(Branch)} is specified, then {nameof(BranchParameter)} should not be specified.");
            }
            if (string.IsNullOrEmpty(BranchParameter))
            {
                ControlFlow.Assert(!AutoDetectBranch, $"If {nameof(BranchParameter)} is specified, then {nameof(AutoDetectBranch)} should not be enabled.");
                ControlFlow.Assert(string.IsNullOrEmpty(Branch), $"If {nameof(BranchParameter)} is specified, then {nameof(Branch)} should not be specified.");
            }

            var tempOutputFile = NukeBuild.TemporaryDirectory / $"octoversion.{Guid.NewGuid()}.json";
            var version = OctoVersionTasks.OctoVersionGetVersion(s => s
                    .SetFramework(Framework)
                    .SetOutputJsonFile(tempOutputFile)
                    .When(UpdateBuildNumber, x => x.EnableDetectEnvironment())
                    .When(!UpdateBuildNumber, x => x.SetOutputFormats("JsonFile"))
                    .When(!string.IsNullOrEmpty(Branch), x=> x.SetCurrentBranch(Branch))
                    .When(!string.IsNullOrEmpty(BranchParameter), 
                        x =>
                        {
                            var branchValue = instance.GetType().GetMember(BranchParameter).FirstOrDefault()?.GetValue<string>();
                            ControlFlow.Assert(string.IsNullOrEmpty(branchValue), $"{nameof(BranchParameter)} '{BranchParameter}' was specified but no parameter was provided");
                            return x.SetCurrentBranch(branchValue);
                        })
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
                //this also happens inside OctoVersion when running in TeamCity and EnableDetectEnvironment was set (based on UpdateBuildNumber)
                TeamCity.Instance?.SetBuildNumber(version.FullSemVer);
                AppVeyor.Instance?.UpdateBuildVersion(version.FullSemVer);
            }

            return version;
        }
    }
}
