// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;
using Nuke.Common.OutputSinks;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

// ReSharper disable VirtualMemberNeverOverridden.Global

namespace Nuke.Common
{
    /// <summary>
    /// Base class for build definitions. Derived types must declare <c>static int Main</c> which calls
    /// <see cref="Execute{T}(System.Linq.Expressions.Expression{System.Func{T,Nuke.Common.Target}})"/> for the exit code.
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
    [HandleHelpRequests]
    [HandleShellCompletion]
    [HandleVisualStudioDebugging]
    public abstract partial class NukeBuild
    {
        /// <summary>
        /// Executes the build. The provided expression defines the <em>default</em> target that is invoked,
        /// if no targets have been specified via command-line arguments.
        /// </summary>
        protected static int Execute<T>(Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            return BuildManager.Execute(defaultTargetExpression);
        }
        
        internal static IReadOnlyCollection<ExecutableTarget> ExecutableTargets { get; set; }
        internal static IReadOnlyCollection<ExecutableTarget> ExecutionPlan { get; set; }

        internal void Execute<T>()
            where T : IBuildExtension
        {
            GetType().GetCustomAttributes().OfType<T>().ForEach(x => x.Execute(this));
        }

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
        
        [CanBeNull]
        protected internal virtual string NuGetPackagesConfigFile =>
            BuildProjectDirectory != null
                ? NuGetPackageResolver.GetPackagesConfigFile(BuildProjectDirectory)
                : null;
    }
}
