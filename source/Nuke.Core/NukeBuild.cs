﻿// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Core.BuildServers;
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
        /// The currently running build instance. Mostly useful for default settings.
        /// </summary>
        public static NukeBuild Instance { get; private set; }

        /// <summary>
        /// Executes the build. The provided expression defines the <em>default</em> target that is invoked,
        /// if no targets have been specified on the command line.
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
        /// Verbosity with that the build is run. Default is <see cref="Core.Verbosity.Normal"/>.
        /// </summary>
        [Parameter("Verbosity with that the build is run. Default is 'Normal'.")]
        public Verbosity Verbosity { get; set; } = Verbosity.Normal;

        /// <summary>
        /// Targets to run. Default is <em>Default</em>, which falls back to the target specified in <c>static int Main</c> with <see cref="Execute{T}"/>.
        /// </summary>
        [Parameter("Target(s) to run. Default is specified in 'static int Main' via 'Execute'.", Separator = "+")]
        public string[] Target { get; } = { "Default" };

        /// <summary>
        /// Configuration to build. Default is <em>Debug</em> for local and <em>Release</em> for server builds.
        /// </summary>
        [Parameter("Configuration to build. Default is 'Debug' for local and 'Release' for server builds.")]
        public string Configuration { get; } = IsServerBuild ? "Release" : "Debug";

        /// <summary>
        /// Specifies that no dependencies should be executed. Default is <c>false</c>.
        /// </summary>
        [Parameter("Specifies that no dependencies should be executed. Default is 'false'.", Name = "NoDeps")]
        public bool NoDependencies { get; }

        /// <summary>
        /// Specifies that the bootstrapper should skip initialization. By default this includes updating NuGet.exe and restoring the build project. Default is <c>false</c>.
        /// </summary>
        [Parameter("Specifies that the bootstrapper should skip initialization. By default this includes updating NuGet.exe and restoring the build project. Default is 'false'.", Name = "NoInit")]
        public bool NoInitialization { get; }

        //[Parameter("Specifies that no logo should be printed. Default is is 'false'.")]
        //public bool NoLogo { get; set; }

        /// <summary>
        /// Enables additional checks for the <c>PATH</c> environment variable.
        /// </summary>
        [Parameter("Enables additional checks for the 'PATH' environment variable.")]
        public bool CheckPath { get; }

        /// <summary>
        /// Shows the help text for this build assembly if supplied.
        /// </summary>
        [Parameter("Shows the help text for this build assembly if supplied.")]
        public string[] Help { get; }

        public static bool IsLocalBuild => TeamCity.Instance == null && Bitrise.Instance == null && TeamServices.Instance == null;
        public static bool IsServerBuild => !IsLocalBuild;

        public LogLevel LogLevel => (LogLevel) Verbosity;

        /// <summary>
        /// The root directory where the <c>.nuke</c> file is located. By convention also the root for the repository.
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
        /// The solution file that is referenced in the <c>.nuke</c> file.
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
        /// The solution directory derived from the solution file specified in the <c>.nuke</c> file.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SolutionDirectory => (PathConstruction.AbsolutePath) Path.GetDirectoryName(SolutionFile);

        /// <summary>
        /// The <c>.tmp</c> directory that is located under the <see cref="RootDirectory"/>.
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
        /// The <c>output</c> directory that is located under the <see cref="RootDirectory"/>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath OutputDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "output");

        /// <summary>
        /// The <c>artifacts</c> directory that is located under the <see cref="RootDirectory"/>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath ArtifactsDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "artifacts");

        /// <summary>
        /// The <c>src</c> or <c>source</c> directory that is located under the <see cref="RootDirectory"/>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath SourceDirectory
            => (PathConstruction.AbsolutePath) new[] { "src", "source" }
                    .SelectMany(x => Directory.GetDirectories(RootDirectory, x))
                    .SingleOrDefault().NotNull("Could not locate a single source directory. Candidates are '\\src' and '\\source'.");
    }
}
