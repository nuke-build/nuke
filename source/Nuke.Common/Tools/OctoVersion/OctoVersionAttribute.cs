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
        public bool AutoDetectBranch { get { return _autoDetectBranch.GetValueOrDefault(); } set { _autoDetectBranch = value; } }
        private bool? _autoDetectBranch;

        /// <summary>
        /// The name of a Nuke parameter specifying whether to auto detect the branch to pass to Octoversion, based on the git worktree
        /// </summary>
        [CanBeNull] public string AutoDetectBranchParameter { get; set; }

        /// <summary>
        /// The branch to pass to OctoVersion
        /// </summary>
        [CanBeNull] public string Branch { get; set; }
        
        /// <summary>
        /// The name of a Nuke parameter containing the branch to be passed to OctoVersion
        /// </summary>
        [CanBeNull] public string BranchParameter { get; set; }

        /// <summary>
        /// The Major version number to pass to OctoVersion
        /// </summary>
        [CanBeNull] public int Major { get { return _major.GetValueOrDefault(); } set { _major = value; } }
        private int? _major;

        /// <summary>
        /// The name of a Nuke parameter containing the Major version number to be passed to OctoVersion
        /// </summary>
        [CanBeNull] public string MajorParameter { get; set; }

        /// <summary>
        /// The Minor version number to pass to OctoVersion
        /// </summary>
        [CanBeNull] public int Minor { get { return _minor.GetValueOrDefault(); } set { _minor = value; } }
        private int? _minor;

        /// <summary>
        /// The name of a Nuke parameter containing the Minor version number to be passed to OctoVersion
        /// </summary>
        [CanBeNull] public string MinorParameter { get; set; }

        /// <summary>
        /// The Patch version number to pass to OctoVersion
        /// </summary>
        [CanBeNull] public int Patch { get { return _patch.GetValueOrDefault(); } set { _patch = value; } }
        private int? _patch;

        /// <summary>
        /// The name of a Nuke parameter containing the Patch version number to be passed to OctoVersion
        /// </summary>
        [CanBeNull] public string PatchParameter { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            // Wrap log output in a NUKE Section
            using (Logger.Block("[OctoVersion] Injection"))
            {
                LogAttributeProperties();

                return GetValueInternal(member, instance);
            }
        }

        private void LogAttributeProperties()
        {
            Logger.Trace("Defined Properties");
            Logger.Trace($"  Framework:                 {Framework ?? "null"}");
            Logger.Trace($"  UpdateBuildNumber:         {UpdateBuildNumber}");
            Logger.Trace($"  AutoDetectBranch:          {_autoDetectBranch?.ToString() ?? "null"}");
            Logger.Trace($"  Branch:                    {Branch ?? "null"}");
            Logger.Trace($"  Major:                     {_major?.ToString() ?? "null"}");
            Logger.Trace($"  Minor:                     {_minor?.ToString() ?? "null"}");
            Logger.Trace($"  Patch:                     {_patch?.ToString() ?? "null"}");
            Logger.Trace($"  AutoDetectBranchParameter: {AutoDetectBranchParameter ?? "null"}");
            Logger.Trace($"  BranchParameter:           {BranchParameter ?? "null"}");
            Logger.Trace($"  MajorParameter:            {MajorParameter ?? "null"}");
            Logger.Trace($"  MinorParameter:            {MinorParameter ?? "null"}");
            Logger.Trace($"  PatchParameter:            {PatchParameter ?? "null"}");
        }

        private object GetValueInternal(MemberInfo member, object instance)
        {
            // Get AutoDetectBranch / AutoDetectBranchParameter
            bool? octoVersionAutoDetectBranch = null;
            if (_autoDetectBranch != null)
            {
                ControlFlow.Assert(string.IsNullOrEmpty(AutoDetectBranchParameter), $"If {nameof(AutoDetectBranch)} is specified, then {nameof(AutoDetectBranchParameter)} should not be specified.");
                octoVersionAutoDetectBranch = _autoDetectBranch;
            }
            else if (!string.IsNullOrEmpty(AutoDetectBranchParameter))
            {
                ControlFlow.Assert(_major == null, $"If {nameof(AutoDetectBranchParameter)} is specified, then {nameof(AutoDetectBranch)} should not be specified.");
                octoVersionAutoDetectBranch = GetParameterValueFromBuild<bool?>(AutoDetectBranchParameter, instance);
            }

            // Get Branch / BranchParameter
            var octoversionBranch = "";
            if (!string.IsNullOrEmpty(Branch))
            {
                ControlFlow.Assert(string.IsNullOrEmpty(BranchParameter), $"If {nameof(Branch)} is specified, then {nameof(BranchParameter)} should not be specified.");
                octoversionBranch = Branch;
            }
            else if (!string.IsNullOrEmpty(BranchParameter))
            {
                ControlFlow.Assert(string.IsNullOrEmpty(Branch), $"If {nameof(BranchParameter)} is specified, then {nameof(Branch)} should not be specified.");
                octoversionBranch = GetParameterValueFromBuild<string>(BranchParameter, instance);
            }

            // Get Major / MajorParameter
            int? octoVersionMajor = null;
            if (_major != null)
            {
                ControlFlow.Assert(string.IsNullOrEmpty(MajorParameter), $"If {nameof(Major)} is specified, then {nameof(MajorParameter)} should not be specified.");
                octoVersionMajor = _major;
            }
            else if (!string.IsNullOrEmpty(MajorParameter))
            {
                ControlFlow.Assert(_major == null, $"If {nameof(MajorParameter)} is specified, then {nameof(Major)} should not be specified.");
                octoVersionMajor = GetParameterValueFromBuild<int?>(MajorParameter, instance);
            }

            // Get Minor / MinorParameter
            int? octoVersionMinor = null;
            if (_minor != null)
            {
                ControlFlow.Assert(string.IsNullOrEmpty(MinorParameter), $"If {nameof(Minor)} is specified, then {nameof(MinorParameter)} should not be specified.");
                octoVersionMinor = _minor;
            }
            else if (!string.IsNullOrEmpty(MinorParameter))
            {
                ControlFlow.Assert(_minor == null, $"If {nameof(MinorParameter)} is specified, then {nameof(Minor)} should not be specified.");
                octoVersionMinor = GetParameterValueFromBuild<int?>(MinorParameter, instance);
            }

            // Get Patch / PatchParameter
            int? octoVersionPatch = null;
            if (_patch != null)
            {
                ControlFlow.Assert(string.IsNullOrEmpty(PatchParameter), $"If {nameof(Patch)} is specified, then {nameof(PatchParameter)} should not be specified.");
                octoVersionPatch = _patch;
            }
            else if (!string.IsNullOrEmpty(PatchParameter))
            {
                ControlFlow.Assert(_patch == null, $"If {nameof(PatchParameter)} is specified, then {nameof(Patch)} should not be specified.");
                octoVersionPatch = GetParameterValueFromBuild<int?>(PatchParameter, instance);
            }

            // Log actual resolved values of parameters
            Logger.Info("Resolved OctoVersion Properties");
            Logger.Info($"  Framework:                 {Framework ?? "null"}");
            Logger.Info($"  UpdateBuildNumber:         {UpdateBuildNumber}");
            Logger.Info($"  AutoDetectBranch:          {octoVersionAutoDetectBranch?.ToString() ?? "null"}");
            Logger.Info($"  Branch:                    {octoversionBranch ?? "null"}");
            Logger.Info($"  Major:                     {octoVersionMajor?.ToString() ?? "null"}");
            Logger.Info($"  Minor:                     {octoVersionMinor?.ToString() ?? "null"}");
            Logger.Info($"  Patch:                     {octoVersionPatch?.ToString() ?? "null"}");

            // Auto Detect branch
            if (octoVersionAutoDetectBranch.HasValue && octoVersionAutoDetectBranch.Value)
            {
                // Don't allow auto detect if a Branch was set manually via property or parameter
                ControlFlow.Assert(string.IsNullOrEmpty(octoversionBranch), $"If {nameof(AutoDetectBranch)} is enabled, then a branch can not be specified via {nameof(Branch)} or {nameof(BranchParameter)}.");

                Logger.Info($"Detecting current branch from the local git directory.");
                var gitRepository = GitRepository.FromLocalDirectory(NukeBuild.RootDirectory);
                octoversionBranch = gitRepository.Branch;
                Logger.Info($"Current branch is '{octoversionBranch}'.");
            }

            if (string.IsNullOrEmpty(octoversionBranch))
            {
                // If we have ended up with no branch, abort!
                ControlFlow.Fail($"OctoVersion requires the branch to be specified.  Either enable auto detection via {nameof(AutoDetectBranch)} or {nameof(AutoDetectBranchParameter)}, or one of {nameof(Branch)} or {nameof(BranchParameter)} must be specified.");
            }
            
            // Now it's GO TIME
            Logger.Info($"Executing OctoVersion.Tool.");
            var tempOutputFile = NukeBuild.TemporaryDirectory / $"octoversion.{Guid.NewGuid()}.json";
            var version = OctoVersionTasks.OctoVersionGetVersion(s => s
                    .SetFramework(Framework)
                    .SetOutputJsonFile(tempOutputFile)
                    .When(UpdateBuildNumber, x => x.EnableDetectEnvironment())
                    .When(!UpdateBuildNumber, x => x.SetOutputFormats("JsonFile"))
                    .When(!string.IsNullOrEmpty(octoversionBranch), x => x.SetCurrentBranch(octoversionBranch))
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

        private static T GetParameterValueFromBuild<T>(string parameterName, object target)
        {
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
