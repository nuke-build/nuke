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
        // Backing fields to support the attribute parameters that need to allow nullable value types
        private bool? _autoDetectBranch;
        private int? _major;
        private int? _minor;
        private int? _patch;

        /// <summary>
        /// Which framework to use when selecting the OctoVersion library from the package
        /// </summary>
        public string Framework { get; set; } = "net5.0";

        /// <summary>
        /// Whether to update the build number and output octoversion attributes into the CI platform
        /// Supports AzurePipelines, TeamCity, AppVeyor and GitHubActions
        /// </summary>
        public bool UpdateBuildNumber { get; set; } = true;

        /// <summary>
        /// Automatically detect the branch to explicitly pass to OctoVersion, based on the git worktree
        /// </summary>
        public bool AutoDetectBranch { get { return _autoDetectBranch.GetValueOrDefault(); } set { _autoDetectBranch = value; } }

        /// <summary>
        /// The name of a Nuke parameter specifying whether to auto detect the branch to explicitly pass to Octoversion, based on the git worktree
        /// If this parameter is provided, it will override any value passed in the AutoDetectBranch property
        /// </summary>
        [CanBeNull] public string AutoDetectBranchParameter { get; set; }

        /// <summary>
        /// The branch to pass to OctoVersion
        /// </summary>
        [CanBeNull] public string Branch { get; set; }

        /// <summary>
        /// The name of a Nuke parameter containing the branch to be passed to OctoVersion
        /// If this parameter is provided, it will override any value passed in the Branch property
        /// </summary>
        [CanBeNull] public string BranchParameter { get; set; }

        /// <summary>
        /// The FullSemVer to pass to OctoVersion
        /// </summary>
        [CanBeNull] public string FullSemVer { get; set; }

        /// <summary>
        /// The name of a Nuke parameter containing the FullSemVer to be passed to OctoVersion
        /// If this parameter is provided, it will override any value passed in the FullSemVer property
        /// </summary>
        [CanBeNull] public string FullSemVerParameter { get; set; }

        /// <summary>
        /// The Major version number to pass to OctoVersion
        /// </summary>
        [CanBeNull] public int Major { get { return _major.GetValueOrDefault(); } set { _major = value; } }

        /// <summary>
        /// The name of a Nuke parameter containing the Major version number to be passed to OctoVersion
        /// If this parameter is provided, it will override any value passed in the Major property
        /// </summary>
        [CanBeNull] public string MajorParameter { get; set; }

        /// <summary>
        /// The Minor version number to pass to OctoVersion
        /// </summary>
        [CanBeNull] public int Minor { get { return _minor.GetValueOrDefault(); } set { _minor = value; } }

        /// <summary>
        /// The name of a Nuke parameter containing the Minor version number to be passed to OctoVersion
        /// If this parameter is provided, it will override any value passed in the Minor property
        /// </summary>
        [CanBeNull] public string MinorParameter { get; set; }

        /// <summary>
        /// The Patch version number to pass to OctoVersion
        /// </summary>
        [CanBeNull] public int Patch { get { return _patch.GetValueOrDefault(); } set { _patch = value; } }

        /// <summary>
        /// The name of a Nuke parameter containing the Patch version number to be passed to OctoVersion
        /// If this parameter is provided, it will override any value passed in the Patch property
        /// </summary>
        [CanBeNull] public string PatchParameter { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            // Wrap log output in an [OctoVersion] Log Block
            using (Logger.Block("[OctoVersion]"))
            {
                // Gather the OctoVersion tool execution options

                // Any named parameter will override those specified via the attribute properties
                var octoVersionAutoDetectBranch = GetParameterValueFromBuild<bool?>(AutoDetectBranchParameter, instance) ?? _autoDetectBranch;
                var octoVersionBranch = GetParameterValueFromBuild<string>(BranchParameter, instance) ?? Branch;
                var octoVersionFullSemVer = GetParameterValueFromBuild<string>(FullSemVerParameter, instance) ?? FullSemVer;
                var octoVersionMajor = GetParameterValueFromBuild<int?>(MajorParameter, instance) ?? _major;
                var octoVersionMinor = GetParameterValueFromBuild<int?>(MinorParameter, instance) ?? _minor;
                var octoVersionPatch = GetParameterValueFromBuild<int?>(PatchParameter, instance) ?? _patch;

                // Auto Detect branch
                if (octoVersionAutoDetectBranch.HasValue && octoVersionAutoDetectBranch.Value)
                {
                    // Don't allow auto detect if an expicit Branch was provided via parameter or property
                    ControlFlow.Assert(string.IsNullOrEmpty(octoVersionBranch), $"If {nameof(AutoDetectBranch)} is enabled, then a branch can not be specified via {nameof(Branch)} or {nameof(BranchParameter)}.");

                    Logger.Info($"{nameof(AutoDetectBranch)} is enabled, detecting current branch from the local git directory.");
                    var gitRepository = GitRepository.FromLocalDirectory(NukeBuild.RootDirectory);
                    octoVersionBranch = gitRepository.Branch;
                    Logger.Info($"Current branch '{octoVersionBranch}' will be explicitly passed to OctoVersion.");
                }

                var tempOutputFile = NukeBuild.TemporaryDirectory / $"octoversion.{Guid.NewGuid()}.json";
                var version = OctoVersionTasks.OctoVersionGetVersion(s => s
                        .SetFramework(Framework)
                        .SetOutputJsonFile(tempOutputFile)
                        .When(UpdateBuildNumber, x => x.EnableDetectEnvironment())
                        .When(!UpdateBuildNumber, x => x.SetOutputFormats("JsonFile"))
                        .When(!string.IsNullOrEmpty(octoVersionBranch), x => x.SetCurrentBranch(octoVersionBranch))
                        .When(!string.IsNullOrEmpty(octoVersionFullSemVer), x => x.SetFullSemVer(octoVersionFullSemVer))
                        .When(octoVersionMajor != null, x => x.SetMajor(octoVersionMajor))
                        .When(octoVersionMinor != null, x => x.SetMinor(octoVersionMinor))
                        .When(octoVersionPatch != null, x => x.SetPatch(octoVersionPatch)))
                    .Result;
                FileSystemTasks.DeleteFile(tempOutputFile);

                if (UpdateBuildNumber)
                {
                    Logger.Info("Updating BuildNumber in supported CI systems");
                    AzurePipelines.Instance?.UpdateBuildNumber(version.FullSemVer);
                    //this also happens inside OctoVersion when running in TeamCity and EnableDetectEnvironment was set (based on UpdateBuildNumber)
                    TeamCity.Instance?.SetBuildNumber(version.FullSemVer);
                    AppVeyor.Instance?.UpdateBuildVersion(version.FullSemVer);
                }

                return version;
            }
        }

        private static T GetParameterValueFromBuild<T>(string parameterName, object target)
        {
            if (string.IsNullOrEmpty(parameterName))
            {
                // If no parameter was named, return
                return default;
            }

            var parameter = target.GetType().GetMember(parameterName, ReflectionUtility.All).FirstOrDefault();
            if (parameter != null)
            {
                // As long as the named parameter exists on the Build, return it's value (including a null value for when it was not specified)
                return parameter.GetValue<T>(target);
            }

            // If the named parameter doesn't exist on the Build class, throw an error as something has been misconfigured
            throw new Exception($"Parameter Name '{parameterName}' was specified but no parameter value could be read.");
        }
    }
}
