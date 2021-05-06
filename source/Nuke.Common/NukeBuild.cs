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
using Nuke.Common.Utilities;
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
    [ArgumentsFromParametersFile(Priority = 150)]
    [InjectParameterValues(Priority = 100)]
    [GenerateBuildServerConfigurations(Priority = 50)]
    [InvokeBuildServerConfigurationGeneration(Priority = 45)]
    [HandleShellCompletion(Priority = 40)]
    [UnsetVisualStudioEnvironmentVariables]
    // [SaveBuildProfile(Priority = 30)]
    // [LoadBuildProfiles(Priority = 25)]
    // After logo
    [HandleHelpRequests(Priority = 5)]
    [Telemetry]
    [HandleVisualStudioDebugging]
    [InjectNonParameterValues(Priority = -100)]
    // After finish
    [ShowSponsorship(Priority = 50)]
    [UpdateNotification(Priority = 10)]
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
        [Parameter("List of targets to be invoked. Default is '{default_target}'.",
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
        /// Gets the list of targets that are scheduled.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> ScheduledTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Scheduled).ToList();

        /// <summary>
        /// Gets the list of targets that are running.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> RunningTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Running).ToList();

        /// <summary>
        /// Gets the list of targets that were aborted.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> AbortedTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Aborted).ToList();

        /// <summary>
        /// Gets the list of targets that have failed.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> FailedTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Failed).ToList();

        /// <summary>
        /// Gets the list of targets that have succeeded.
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> SucceededTargets => ExecutionPlan.Where(x => x.Status == ExecutionStatus.Succeeded).ToList();

        /// <summary>
        /// Gets the list of targets that have been finished (failed or succeeded).
        /// </summary>
        public IReadOnlyCollection<ExecutableTarget> FinishedTargets => FailedTargets.Concat(SucceededTargets).ToList();

        /// <summary>
        /// Gets a value whether to show the execution plan (HTML).
        /// </summary>
        [Parameter("Shows the execution plan (HTML).")]
        public bool Plan { get; }

        /// <summary>
        /// Gets a value whether to show the help text for this build assembly.
        /// </summary>
        [Parameter("Shows the help text for this build assembly.")]
        public bool Help { get; }

        /// <summary>
        /// Gets a value whether to display the NUKE logo.
        /// </summary>
        [Parameter("Disables displaying the NUKE logo.")]
        public bool NoLogo { get; set; }

        /// <summary>
        /// Gets a value whether a previous failed build should be continued.
        /// </summary>
        [Parameter("Indicates to continue a previously failed build attempt.")]
        public bool Continue { get; internal set; }

        [Parameter("Partition to use on CI.", List = false)]
        public Partition Partition { get; internal set; } = Partition.Single;

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

        internal IEnumerable<string> TargetNames => ExecutableTargetFactory.GetTargetProperties(GetType()).Select(x => x.GetDisplayShortName());
        internal IEnumerable<string> HostNames => Host.AvailableTypes.Select(x => x.Name);

        public bool IsSuccessful => ExecutionPlan.All(x => x.Status is
            ExecutionStatus.Succeeded or
            ExecutionStatus.Skipped or
            ExecutionStatus.Collective);

        public bool IsFailing => ExecutionPlan.Any(x => x.Status is
            ExecutionStatus.Failed or
            ExecutionStatus.Aborted or
            ExecutionStatus.NotRun);

        public bool IsFinished => !ScheduledTargets.Concat(RunningTargets).Any();

        /// <summary>
        /// Gets or sets the build exit code.
        /// When set to <value>null</value> (default), <see cref="Execute{T}"/> will return a <em>0</em> exit code on build success; or a <em>-1</em> exit code on build failure.
        /// When set to a non-null value, <see cref="Execute{T}"/> will return the value of <see cref="ExitCode"/>.
        /// </summary>
        public int? ExitCode { get; set; }

        public void ReportSummary(Configure<IDictionary<string, string>> configurator = null)
        {
            var target = ExecutionPlan.Single(x => x.Status == ExecutionStatus.Running);
            target.SummaryInformation = configurator.InvokeSafe(new Dictionary<string, string>()).ToDictionary(x => x.Key, x => x.Value);
            ExecuteExtension<IOnTargetSummaryUpdated>(x => x.OnTargetSummaryUpdated(this, target));
        }
    }
}
