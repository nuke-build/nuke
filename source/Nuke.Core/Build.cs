// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.Output;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core
{
    /// <summary>
    /// Base class for build definitions.
    /// </summary>
    [PublicAPI]
    public abstract class Build
    {
        private const string c_configFile = ".nuke";

        public static Build Instance { get; private set; }

        /// <summary>
        /// Represents the main entry point for this build. Also defines the default target.
        /// </summary>
        protected static int Execute<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : Build
        {
            var build = Activator.CreateInstance<T>();
            var defaultTarget = defaultTargetExpression.Compile().Invoke(build);
            var executionList = new TargetDefinitionLoader().GetExecutionList(build, defaultTarget);
            return new ExecutionListRunner().Run(executionList);
        }

        protected Build ()
        {
            Instance = this;
        }

        public virtual LogLevel LogLevel => Argument<LogLevel?>("verbosity") ?? LogLevel.Information;
        public virtual IEnumerable<string> Targets => (Argument("target") ?? "Default").Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
        public virtual string Configuration => Argument("configuration") ?? "Debug";

        public static bool IsLocalBuild => OutputSink.Instance is ConsoleOutputSink;
        public static bool IsServerBuild => !IsLocalBuild;

        public virtual string RootDirectory
        {
            get
            {
                var buildAssemblyLocation = BuildAssembly.Location.NotNull("executingAssembly != null");
                var rootDirectory = Directory.GetParent(buildAssemblyLocation);

                while (rootDirectory != null && !rootDirectory.GetFiles(c_configFile).Any())
                {
                    rootDirectory = rootDirectory.Parent;
                }

                return rootDirectory?.FullName.NotNull(
                    $"Could not locate {c_configFile} file while traversing up from {buildAssemblyLocation}.");
            }
        }

        public virtual string SolutionFile
        {
            get
            {
                var nukeFile = Path.Combine(RootDirectory, c_configFile);
                ControlFlow.Assert(File.Exists(nukeFile), $"File.Exists({c_configFile})");

                var solutionFileRelative = File.ReadAllLines(nukeFile)[0];
                ControlFlow.Assert(!solutionFileRelative.Contains(value: '\\'), $"{c_configFile} must use unix-styled separators");

                var solutionFile = Path.GetFullPath(Path.Combine(RootDirectory, solutionFileRelative));
                ControlFlow.Assert(File.Exists(solutionFile), "File.Exists(solutionFile)");

                return solutionFile;
            }
        }

        public virtual string SolutionDirectory => Path.GetDirectoryName(SolutionFile);

        public virtual string TemporaryDirectory
        {
            get
            {
                var temporaryDirectory = Path.Combine(RootDirectory, ".tmp");
                ControlFlow.Assert(Directory.Exists(temporaryDirectory), $"Directory.Exists({temporaryDirectory})");
                return temporaryDirectory;
            }
        }

        public virtual string OutputDirectory => Path.Combine(RootDirectory, "output");
    }
}
