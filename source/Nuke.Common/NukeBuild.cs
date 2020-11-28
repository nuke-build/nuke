// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.ValueInjection;
using static Nuke.Common.Constants;

// ReSharper disable VirtualMemberNeverOverridden.Global

namespace Nuke.Common
{
    /// <summary>
    /// Base class for build definitions. Derived types must declare <c>static int Main</c> which calls
    /// <see cref="Execute{T}"/> for the exit code.
    /// </summary>
    /// <example>
    /// <code>
    /// class DefaultBuild : NukeBuild
    /// {
    ///     public static int Main () => Execute&lt;DefaultBuild&gt;(x => x.Compile);
    ///
    ///     Target Clean =&gt; _ =&gt; _
    ///         .Executes(() =&gt;
    ///         {
    ///             EnsureCleanDirectory(OutputDirectory);
    ///         });
    ///
    ///     Target Compile =&gt; _ =&gt; _
    ///         .DependsOn(Clean)
    ///         .Executes(() =&gt;
    ///         {
    ///             MSBuild(SolutionFile);
    ///         });
    /// }
    /// </code>
    /// </example>
    [PublicAPI]
    // Before logo
    [InjectParameterValues(Priority = 100)]
    [GenerateBuildServerConfigurations(Priority = 50)]
    [InvokeBuildServerConfigurationGeneration(Priority = 45)]
    [HandleShellCompletion(Priority = 40)]
    [UnsetVisualStudioEnvironmentVariables]
    // [SaveBuildProfile(Priority = 30)]
    // [LoadBuildProfiles(Priority = 25)]
    // After logo
    [HandleHelpRequests(Priority = 5)]
    [HandleVisualStudioDebugging]
    [InjectNonParameterValues(Priority = -100)]
    // After finish
    [SerializeBuildServerState]
    public abstract partial class NukeBuild : INukeBuild
    {
        /// <summary>
        /// Executes the build. The provided expression defines the <em>default</em> target that is invoked,
        /// if no targets have been specified via command-line arguments.
        /// </summary>
        protected static int Execute<T>(params Expression<Func<T, Target>>[] defaultTargetExpressions)
            where T : NukeBuild
        {
            return BuildManager.Execute(defaultTargetExpressions);
        }

        internal IReadOnlyCollection<ExecutableTarget> ExecutableTargets { get; set; }
        internal IReadOnlyCollection<ExecutableTarget> ExecutionPlan { get; set; }

        /// <summary>
        /// Gets the list of targets that were invoked.
        /// </summary>
        [Parameter("List of targets to be executed. Default is '{default_target}'.",
            Name = InvokedTargetsParameterName,
            Separator = TargetsSeparator,
            ValueProviderMember = nameof(TargetNames))]
        public IReadOnlyCollection<ExecutableTarget> InvokedTargets => ExecutionPlan.Where(x => x.Invoked).ToList();

        /// <summary>
        /// Gets the list of targets that are skipped.
        /// </summary>
        [Parameter("List of targets to be skipped. Empty list skips all dependencies.",
            Name = SkippedTargetsParameterName,
            Separator = TargetsSeparator,
            ValueProviderMember = nameof(TargetNames))]
        public IReadOnlyCollection<ExecutableTarget> SkippedTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Skipped).ToList();

        /// <summary>
        /// Gets the list of targets that are executing.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> ExecutingTargets => ExecutionPlan.Where(x => x.Status != ExecutionStatus.Skipped).ToList();

        [CanBeNull]
        protected internal virtual string NuGetPackagesConfigFile =>
            BuildProjectDirectory != null
                ? NuGetPackageResolver.GetPackagesConfigFile(BuildProjectDirectory)
                : null;

        [CanBeNull]
        protected internal virtual string NuGetAssetsConfigFile =>
            BuildProjectDirectory != null
                ? BuildProjectDirectory / "obj" / "project.assets.json"
                : null;

        internal IEnumerable<string> TargetNames => ExecutableTargetFactory.GetTargetProperties(GetType()).Select(x => x.Name);
        internal IEnumerable<string> HostNames => Host.AvailableTypes.Select(x => x.Name);

        public bool IsSuccessful => (!ExitCode.HasValue || ExitCode == 0) && ExecutionPlan
            .All(x => x.Status != ExecutionStatus.Failed &&
                      x.Status != ExecutionStatus.NotRun &&
                      x.Status != ExecutionStatus.Aborted);

        /// <summary>
        /// Gets or sets the build exit code.
        /// When set to <value>null</value> (default), <see cref="Execute{T}"/> will return a <em>0</em> exit code on build success; or a <em>-1</em> exit code on build failure.
        /// When set to a non-null value, <see cref="Execute{T}"/> will return the value of <see cref="ExitCode"/>.
        /// </summary>
        public int? ExitCode { get; set; }
    }
}
