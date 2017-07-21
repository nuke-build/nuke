// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.IO;
using Nuke.Core.OutputSinks;
using Nuke.Core.Utilities;
using static Nuke.Core.EnvironmentInfo;

[assembly: IconClass(typeof(NukeBuild), "heart3")]

// ReSharper disable VirtualMemberNeverOverridden.Global

namespace Nuke.Core
{
    /// <summary>
    /// Base class for build definitions. Derived types must declare <c>static Main</c> which calls
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
            var executionList = PrepareBuild(defaultTargetExpression);
            return new ExecutionListRunner().Run(executionList);
        }

        private static IReadOnlyCollection<TargetDefinition> PrepareBuild<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            using (DelegateDisposable.CreateBracket(
                () => ControlFlow.IsPreparing = true,
                () => ControlFlow.IsPreparing = false))
            {
                var build = Activator.CreateInstance<T>();

                var defaultTarget = defaultTargetExpression.Compile().Invoke(build);
                var executionList = new TargetDefinitionLoader().GetExecutionList(build, defaultTarget);

                var parameterInjectionService = new InjectionService();
                parameterInjectionService.InjectParameters(build);
                parameterInjectionService.ValidateParameters(executionList, build);

                return executionList;
            }
        }

        protected NukeBuild ()
        {
            Instance = this;
        }

        /// <summary>
        /// The specified log level for the build. Default is <see cref="Core.LogLevel.Information"/>.
        /// </summary>
        public virtual LogLevel LogLevel => Argument<LogLevel?>("verbosity") ?? LogLevel.Information;

        /// <summary>
        /// The specified targets to run. Default is <em>Default</em>, which falls back to the target specified in the <c>Main</c> method via <see cref="Execute{T}"/>.
        /// </summary>
        public virtual IEnumerable<string> Targets => (Argument("target") ?? "Default").Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// The specified configuration to build. Default is <em>Debug</em>.
        /// </summary>
        public virtual string Configuration => Argument("configuration") ?? "Debug";

        public static bool IsLocalBuild => OutputSink.Instance is ConsoleOutputSink;
        public static bool IsServerBuild => !IsLocalBuild;

        /// <summary>
        /// The root directory where the <c>.nuke</c> file is located. By convention also the root for the repository.
        /// </summary>
        public virtual PathConstruction.AbsolutePath RootDirectory
        {
            get
            {
                var buildAssemblyLocation = BuildAssembly.Location.NotNull("executingAssembly != null");
                var rootDirectory = Directory.GetParent(buildAssemblyLocation);

                while (rootDirectory != null && !rootDirectory.GetFiles(c_configFile).Any())
                {
                    rootDirectory = rootDirectory.Parent;
                }

                return (PathConstruction.AbsolutePath) rootDirectory?.FullName.NotNull(
                    $"Could not locate {c_configFile} file while traversing up from {buildAssemblyLocation}.");
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
                    .SingleOrDefault().NotNull("Could not locate single source directory.");
    }
}
