// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;

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
    ///             .Executes(() =&gt; EnsureCleanDirectory(OutputDirectory));
    /// 
    ///     Target Compile =&gt; _ =&gt; _
    ///             .DependsOn(Clean)
    ///             .Executes(() =&gt; MSBuild(SolutionFile);
    /// }
    /// </code>
    /// </example>
    [PublicAPI]
    public abstract class NukeBuild
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
        /// Logging verbosity while building. Default is <see cref="Core.Verbosity.Normal"/>.
        /// </summary>
        [Parameter("Logging verbosity while building. Default is 'Normal'.")]
        public Verbosity Verbosity { get; set; } = Verbosity.Normal;

        /// <summary>
        /// Host for execution. Default is <em>automatic</em>.
        /// </summary>
        [Parameter("Host for execution. Default is 'automatic'.")]
        public HostType Host { get; } = EnvironmentInfo.HostType;

        /// <summary>
        /// Configuration to build. Default is <em>Debug</em> (local) or <em>Release</em> (server).
        /// </summary>
        [Parameter("Configuration to build. Default is 'Debug' (local) or 'Release' (server).")]
        public virtual string Configuration { get; } = EnvironmentInfo.IsLocalBuild ? "Debug" : "Release";

        /// <summary>
        /// Disables execution of target dependencies.
        /// </summary>
        [Parameter("Disables execution of dependent targets.", Name = "Skip", Separator = "+")]
        public string[] SkippedTargets { get; } = EnvironmentInfo.SkippedTargets;

        /// <summary>
        /// Disables bootstrapper initialization.
        /// </summary>
        [Parameter("Disables bootstrapper initialization.", Name = "NoInit")]
        public bool NoInitialization { get; }

        //[Parameter("Specifies that no logo should be printed.")]
        //public bool NoLogo { get; set; }

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

        public bool IsLocalBuild { get; } = EnvironmentInfo.IsLocalBuild;
        public bool IsServerBuild { get; } = !EnvironmentInfo.IsLocalBuild;

        public LogLevel LogLevel => (LogLevel) Verbosity;

        public string[] InvokedTargets { get; } = EnvironmentInfo.InvokedTargets;
        public string[] ExecutingTargets { get; }

        /// <summary>
        /// Gets the full path to the root directory where the <c>.nuke</c> file is located.
        /// </summary>
        public virtual PathConstruction.AbsolutePath RootDirectory
        {
            get
            {
                var rootDirectory = FileSystemTasks.FindParentDirectory(EnvironmentInfo.BuildProjectDirectory, x => x.GetFiles(ConfigurationFile).Any());
                ControlFlow.Assert(rootDirectory != null,
                    $"Could not locate '{ConfigurationFile}' file while traversing up from '{EnvironmentInfo.BuildProjectDirectory}'.");

                return (PathConstruction.AbsolutePath) rootDirectory;
            }
        }

        /// <summary>
        /// Full path to the solution file that is referenced in the <c>.nuke</c> file.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SolutionFile
        {
            get
            {
                var nukeFile = Path.Combine(RootDirectory, ConfigurationFile);
                ControlFlow.Assert(File.Exists(nukeFile), $"File.Exists({ConfigurationFile})");

                var solutionFileRelative = File.ReadAllLines(nukeFile)[0];
                ControlFlow.Assert(!solutionFileRelative.Contains(value: '\\'), $"{ConfigurationFile} must use unix-styled separators");

                var solutionFile = Path.GetFullPath(Path.Combine(RootDirectory, solutionFileRelative));
                ControlFlow.Assert(File.Exists(solutionFile), "File.Exists(solutionFile)");

                return (PathConstruction.AbsolutePath) solutionFile;
            }
        }

        /// <summary>
        /// Full path to the solution directory derived the <c>.nuke</c> file.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SolutionDirectory => (PathConstruction.AbsolutePath) Path.GetDirectoryName(SolutionFile);

        /// <summary>
        /// Full path to <c>/.tmp</c>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath TemporaryDirectory
        {
            get
            {
                var temporaryDirectory = Path.Combine(RootDirectory, ".tmp");
                ControlFlow.Assert(Directory.Exists(temporaryDirectory), $"Directory.Exists({temporaryDirectory})");
                return (PathConstruction.AbsolutePath) temporaryDirectory;
            }
        }

        /// <summary>
        /// Full path to <c>/output</c>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath OutputDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "output");

        /// <summary>
        /// Full path to <c>/artifacts</c>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath ArtifactsDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "artifacts");

        /// <summary>
        /// Full path to either <c>/src</c> or <c>/source</c>. Throws an exception if either none or both exist.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SourceDirectory
        {
            get
            {
                var directories = new[] { "src", "source" }.SelectMany(x => Directory.GetDirectories(RootDirectory, x)).ToList();
                ControlFlow.Assert(directories.Count == 1, "Could not locate a single source directory. Candidates are '/src' and '/source'.");
                return (PathConstruction.AbsolutePath) directories.Single();
            }
        }
    }
}
