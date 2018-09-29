// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;
using Nuke.Common.OutputSinks;
using Nuke.Common.Tooling;

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
    public abstract partial class NukeBuild
    {
        public const string ConfigurationFile = ".nuke";

        /// <summary>
        /// Currently running build instance.
        /// </summary>
        public static NukeBuild Instance { get; internal set; }

        /// <summary>
        /// Executes the build. The provided expression defines the <em>default</em> target that is invoked,
        /// if no targets have been specified via command-line arguments.
        /// </summary>
        protected static int Execute<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            return BuildExecutor.Execute(defaultTargetExpression);
        }

        internal IReadOnlyCollection<TargetDefinition> TargetDefinitions { get; set; }

        /// <summary>
        /// Logging verbosity while building. Default is <see cref="Nuke.Common.Verbosity.Normal"/>.
        /// </summary>
        [Parameter("Logging verbosity while building. Default is 'Normal'.")]
        public Verbosity Verbosity { get; set; } = Verbosity.Normal;

        /// <summary>
        /// Host for execution. Default is <em>automatic</em>.
        /// </summary>
        [Parameter("Host for execution. Default is 'automatic'.")]
        public HostType Host { get; } = GetHostType();

        /// <summary>
        /// Configuration to build. Default is <em>Debug</em> (local) or <em>Release</em> (server).
        /// </summary>
        [Parameter("Configuration to build. Default is 'Debug' (local) or 'Release' (server).")]
        [Obsolete("Property will be removed in a following version. Please define it yourself, i.e.: "
                  + "[Parameter] readonly string Configuration;")]
        public virtual string Configuration { get; } = GetHostType() == HostType.Console ? "Debug" : "Release";

        /// <summary>
        /// Disables execution of target dependencies.
        /// </summary>
        [Parameter("Disables execution of dependent targets.", Name = "Skip", Separator = "+")]
        public string[] SkippedTargets { get; } = GetSkippedTargets();

        /// <summary>
        /// Enables sanity checks for the <c>PATH</c> environment variable.
        /// </summary>
        [Parameter("Enables sanity checks for the 'PATH' environment variable.")]
        public bool CheckPath { get; }

        /// <summary>
        /// Shows the target dependency graph (HTML).
        /// </summary>
        [Parameter("Shows the target dependency graph (HTML).")]
        public bool Graph { get; }

        /// <summary>
        /// Shows the help text for this build assembly.
        /// </summary>
        [Parameter("Shows the help text for this build assembly.")]
        public bool Help { get; }

        public static bool IsLocalBuild => GetHostType() == HostType.Console;
        public static bool IsServerBuild => GetHostType() != HostType.Console;

        public LogLevel LogLevel => (LogLevel) Verbosity;

        public string[] InvokedTargets { get; } = GetInvokedTargets();
        public string[] ExecutingTargets { get; }
                
        protected internal virtual IOutputSink OutputSink
        {
            get
            {
                IOutputSink innerOutputSink;
                
                switch (Host)
                {
                    case HostType.Bitrise:
                        innerOutputSink = new BitriseOutputSink();
                        break;
                    case HostType.TeamCity:
                        innerOutputSink = new TeamCityOutputSink(new TeamCity());
                        break;
                    case HostType.TeamServices:
                        innerOutputSink = new TeamServicesOutputSink(new TeamServices());
                        break;
                    default:
                        innerOutputSink = new ConsoleOutputSink();
                        break;
                }

                return new SevereMessagesOutputSink(innerOutputSink);
            }
        }

        protected internal virtual string PackagesConfigFile
        {
            get
            {
                ControlFlow.Assert(BuildProjectDirectory != null,
                    "No build project found. Either pass the tool paths directly or override NukeBuild.PackagesConfigFile. ");
                return NuGetPackageResolver.GetPackageConfigFile(BuildProjectDirectory);
            }
        }
    }
}
