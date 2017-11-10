// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.IO;
using Nuke.Core.OutputSinks;
using static Nuke.Core.EnvironmentInfo;

// ReSharper disable VirtualMemberNeverOverridden.Global

namespace Nuke.Core
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
        private const string c_configFile = ".nuke";

        /// <summary>
        /// Currently running build instance. Mostly useful for default settings.
        /// </summary>
        public static NukeBuild Instance { get; private set; }

        /// <summary>
        /// Executes the build. The provided expression defines the <em>default</em> target that is invoked,
        /// if no targets have been specified via command-line arguments.
        /// </summary>
        protected static int Execute<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            return BuildExecutor.Execute(defaultTargetExpression);
        }

        protected NukeBuild ()
        {
            Instance = this;
        }

        /// <summary>
        /// Logging verbosity while building. Default is <see cref="Core.Verbosity.Normal"/>.
        /// </summary>
        [Parameter("Logging verbosity while building. Default is 'Normal'.")]
        public Verbosity Verbosity { get; set; } = Verbosity.Normal;

        /// <summary>
        /// Targets to run. Default is <em>Default</em>, which falls back to the target specified in <c>static int Main</c> with <see cref="Execute{T}"/>.
        /// </summary>
        [Parameter("Target(s) to run. Default is '{default_target}'.", Separator = "+")]
        public string[] Target { get; } = { "Default" };

        /// <summary>
        /// Configuration to build. Default is <em>Debug</em> (local) or <em>Release</em> (server).
        /// </summary>
        [Parameter("Configuration to build. Default is 'Debug' (local) or 'Release' (server).")]
        public string Configuration { get; } = IsServerBuild ? "Release" : "Debug";

        /// <summary>
        /// Disables execution of target dependencies.
        /// </summary>
        [Parameter("Disables execution of target dependencies.", Name = "NoDeps")]
        public bool NoDependencies { get; }

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
        [CanBeNull]
        public string[] Help { get; }

        public static bool IsLocalBuild => OutputSink.Instance.GetType() == typeof(ConsoleOutputSink);
        public static bool IsServerBuild => !IsLocalBuild;

        public LogLevel LogLevel => (LogLevel) Verbosity;

        /// <summary>
        /// Gets the full path to the root directory where the <c>.nuke</c> file is located.
        /// </summary>
        public virtual PathConstruction.AbsolutePath RootDirectory
        {
            get
            {
                var buildAssemblyLocation = BuildAssembly.Location.NotNull("buildAssemblyLocation != null");
                var rootDirectory = Directory.GetParent(buildAssemblyLocation);

                while (rootDirectory != null && !rootDirectory.GetFiles(c_configFile).Any())
                {
                    rootDirectory = rootDirectory.Parent;
                }

                return (PathConstruction.AbsolutePath) rootDirectory
                        .NotNull($"Could not locate '{c_configFile}' file while traversing up from '{buildAssemblyLocation}'.")
                        .FullName;
            }
        }

        /// <summary>
        /// Full path to the solution file that is referenced in the <c>.nuke</c> file.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SolutionFile
        {
            get
            {
                var nukeFile = Path.Combine(RootDirectory, c_configFile);
                ControlFlow.Assert(File.Exists(nukeFile), $"File.Exists({c_configFile})");

                var solutionFileRelative = File.ReadAllLines(nukeFile)[0];
                ControlFlow.Assert(!solutionFileRelative.Contains(value: '\\'), $"{c_configFile} must use unix-styled separators");

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
        /// Full path to <c>~\.tmp</c>.
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
        /// Full path to <c>~\output</c>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath OutputDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "output");

        /// <summary>
        /// Full path to <c>~\artifacts</c>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath ArtifactsDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "artifacts");

        /// <summary>
        /// Full path to either <c>~\src</c> or <c>~\source</c>. Throws an exception if either none or both exist.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SourceDirectory
        {
            get
            {
                var directories = new[] { "src", "source" }.SelectMany(x => Directory.GetDirectories(RootDirectory, x)).ToList();
                ControlFlow.Assert(directories.Count == 1, "Could not locate a single source directory. Candidates are '~\\src' and '~\\source'.");
                return (PathConstruction.AbsolutePath) directories.Single();
            }
        }
    }
}
