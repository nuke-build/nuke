// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.Bitrise;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.CI.TravisCI;
using Nuke.Common.Execution;
using Nuke.Common.OutputSinks;
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
    [HandleShellCompletion(Priority = 40)]
    [SaveBuildProfile(Priority = 30)]
    [LoadBuildProfiles(Priority = 25)]
    // After logo
    [InvokeBuildServerConfigurationGeneration(Priority = 50)]
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
            Separator = TargetsSeparator)]
        public IReadOnlyCollection<ExecutableTarget> InvokedTargets => ExecutionPlan.Where(x => x.Invoked).ToList();

        /// <summary>
        /// Gets the list of targets that are skipped.
        /// </summary>
        [Parameter("List of targets to be skipped. Empty list skips all dependencies.",
            Name = SkippedTargetsParameterName,
            Separator = TargetsSeparator)]
        public IReadOnlyCollection<ExecutableTarget> SkippedTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Skipped).ToList();

        /// <summary>
        /// Gets the list of targets that are executing.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> ExecutingTargets => ExecutionPlan.Where(x => x.Status != ExecutionStatus.Skipped).ToList();

        protected internal virtual OutputSink OutputSink => Host switch
            {
                HostType.Bitrise => new BitriseOutputSink(),
                HostType.Travis => new TravisCIOutputSink(),
                HostType.TeamCity => new TeamCityOutputSink(new TeamCity()),
                HostType.AzurePipelines => new AzurePipelinesOutputSink(new AzurePipelines()),
                HostType.GitHubActions => new GitHubActionsOutputSink(new GitHubActions()),
                HostType.AppVeyor => new AppVeyorOutputSink(new AppVeyor()),
                _ => OutputSink.Default
            };

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

        public bool IsSuccessful => ExecutionPlan
            .All(x => x.Status != ExecutionStatus.Failed &&
                      x.Status != ExecutionStatus.NotRun &&
                      x.Status != ExecutionStatus.Aborted);
    }
}
