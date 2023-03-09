// Copyright 2023 Maintainers of NUKE.
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
        private bool? _autoDetectBranch;
        private int? _major;
        private int? _minor;
        private int? _patch;

        /// <summary>
        /// Framework to use when selecting the OctoVersion library from the package.
        /// </summary>
        public string Framework { get; set; }

        /// <summary>
        /// Whether to update the build number and output OctoVersion results into the CI platform.
        /// Supports AzurePipelines, TeamCity, AppVeyor, and GitHubActions.
        /// </summary>
        public bool UpdateBuildNumber { get; set; } = true;

        /// <summary>
        /// Automatically detect the branch to explicitly pass to OctoVersion, based on the Git working copy.
        /// </summary>
        public bool AutoDetectBranch
        {
            get => throw new NotSupportedException();
            set => _autoDetectBranch = value;
        }

        /// <summary>
        /// Name of the parameter specifying whether to auto detect the branch to explicitly pass to OctoVersion, based on the Git working copy.
        /// If this parameter is provided, it will override any value passed in the AutoDetectBranch property.
        /// </summary>
        [CanBeNull] public string AutoDetectBranchMember { get; set; }

        /// <summary>
        /// branch to pass to OctoVersion.
        /// </summary>
        [CanBeNull] public string Branch { get; set; }

        /// <summary>
        /// Name of the parameter containing the branch to be passed to OctoVersion.
        /// If this parameter is provided, it will override any value passed in the Branch property.
        /// </summary>
        [CanBeNull] public string BranchMember { get; set; }

        /// <summary>
        /// FullSemVer to pass to OctoVersion.
        /// </summary>
        [CanBeNull] public string FullSemVer { get; set; }

        /// <summary>
        /// Name of the parameter containing the FullSemVer to be passed to OctoVersion.
        /// If this parameter is provided, it will override any value passed in the FullSemVer property.
        /// </summary>
        [CanBeNull] public string FullSemVerMember { get; set; }

        /// <summary>
        /// Major version number to pass to OctoVersion..
        /// </summary>
        public int Major
        {
            get => throw new NotSupportedException();
            set => _major = value;
        }

        /// <summary>
        /// Name of the parameter containing the Major version number to be passed to OctoVersion.
        /// If this parameter is provided, it will override any value passed in the Major property.
        /// </summary>
        [CanBeNull] public string MajorMember { get; set; }

        /// <summary>
        /// Minor version number to pass to OctoVersion.
        /// </summary>
        public int Minor
        {
            get => throw new NotSupportedException();
            set => _minor = value;
        }

        /// <summary>
        /// Name of the parameter containing the Minor version number to be passed to OctoVersion.
        /// If this parameter is provided, it will override any value passed in the Minor property.
        /// </summary>
        [CanBeNull] public string MinorMember { get; set; }

        /// <summary>
        /// Patch version number to pass to OctoVersion.
        /// </summary>
        public int Patch
        {
            get => throw new NotSupportedException();
            set => _patch = value;
        }

        /// <summary>
        /// Name of the parameter containing the Patch version number to be passed to OctoVersion.
        /// If this parameter is provided, it will override any value passed in the Patch property
        /// </summary>
        [CanBeNull] public string PatchMember { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var autoDetectBranch = GetMemberValueOrNull<bool?>(AutoDetectBranchMember, instance) ?? _autoDetectBranch;
            var branch = GetMemberValueOrNull<string>(BranchMember, instance) ?? Branch;
            var fullSemVer = GetMemberValueOrNull<string>(FullSemVerMember, instance) ?? FullSemVer;
            var majorVersion = GetMemberValueOrNull<int?>(MajorMember, instance) ?? _major;
            var minorVersion = GetMemberValueOrNull<int?>(MinorMember, instance) ?? _minor;
            var patchVersion = GetMemberValueOrNull<int?>(PatchMember, instance) ?? _patch;

            Assert.False(autoDetectBranch.HasValue && autoDetectBranch.Value && !branch.IsNullOrEmpty(),
                $"Branch cannot be specified via {nameof(Branch)} or {nameof(BranchMember)} properties when {nameof(AutoDetectBranch)} is enabled");
            Assert.True(autoDetectBranch.HasValue && autoDetectBranch.Value || !branch.IsNullOrEmpty(),
                $"Branch must either be provided via {nameof(Branch)} or {nameof(BranchMember)} properties, or {nameof(AutoDetectBranch)} must be enabled");
            branch ??= GitRepository.FromLocalDirectory(Build.RootDirectory).Branch;

            var outputFile = NukeBuild.TemporaryDirectory / $"octoversion.{Guid.NewGuid()}.json";
            var version = OctoVersionTasks.OctoVersionGetVersion(_ => _
                    .SetFramework(Framework)
                    .SetOutputJsonFile(outputFile)
                    .When(UpdateBuildNumber, _ => _
                        .EnableDetectEnvironment())
                    .When(!UpdateBuildNumber, _ => _
                        .SetOutputFormats(OctoVersionOutputFormatter.Json))
                    .SetCurrentBranch(branch)
                    .SetFullSemVer(fullSemVer)
                    .SetMajor(majorVersion)
                    .SetMinor(minorVersion)
                    .SetPatch(patchVersion))
                .Result;
            outputFile.DeleteFile();

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
