// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        /// <summary>
        /// Gets the full path to the root directory where the <c>.nuke</c> file is located.
        /// </summary>
        public virtual PathConstruction.AbsolutePath RootDirectory
        {
            get
            {
                var rootDirectory =
                    FileSystemTasks.FindParentDirectory(BuildProjectDirectory, x => x.GetFiles(ConfigurationFile).Any());
                ControlFlow.Assert(rootDirectory != null,
                    $"Could not locate '{ConfigurationFile}' file while traversing up from '{BuildProjectDirectory}'.");

                return (PathConstruction.AbsolutePath) rootDirectory;
            }
        }

        /// <summary>
        /// Full path to <c>/.tmp</c>.
        /// </summary>
        public virtual PathConstruction.AbsolutePath TemporaryDirectory
        {
            get
            {
                var temporaryDirectory = Path.Combine(RootDirectory, ".tmp");
                FileSystemTasks.EnsureExistingDirectory(temporaryDirectory);
                return (PathConstruction.AbsolutePath) temporaryDirectory;
            }
        }

        public static PathConstruction.AbsolutePath BuildAssemblyDirectory
        {
            get
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                ControlFlow.Assert(entryAssembly.GetTypes().Any(x => x.IsSubclassOf(typeof(NukeBuild))),
                    $"{entryAssembly} doesn't contain a NukeBuild class.");
                return (PathConstruction.AbsolutePath) Path.GetDirectoryName(entryAssembly.Location).NotNull();
            }
        }

        public static PathConstruction.AbsolutePath BuildProjectDirectory
        {
            get
            {
                var buildProjectDirectory = new DirectoryInfo(BuildAssemblyDirectory)
                    .DescendantsAndSelf(x => x.Parent)
                    .Select(x => x.GetFiles("*.csproj", SearchOption.TopDirectoryOnly)
                        .SingleOrDefaultOrError($"Found multiple project files in '{x}'."))
                    .FirstOrDefault(x => x != null)
                    ?.DirectoryName;
                return (PathConstruction.AbsolutePath) buildProjectDirectory.NotNull("buildProjectDirectory != null");
            }
        }

        [Obsolete("Property will be removed in a following version. Please define it yourself, i.e.: "
                  + "[Solution(\"solution.sln\")] readonly Solution Solution;")]
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

        [Obsolete("Property will be removed in a following version. Please define it yourself, i.e.: "
                  + "[Solution(\"solution.sln\")] readonly Solution Solution;")]
        public virtual PathConstruction.AbsolutePath SolutionDirectory => (PathConstruction.AbsolutePath) Path.GetDirectoryName(SolutionFile);

        [Obsolete("Property will be removed in a following version. Please define it yourself, i.e.: "
                  + "AbsolutePath OutputDirectory => RootDirectory / \"output\";")]
        public virtual PathConstruction.AbsolutePath OutputDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "output");

        [Obsolete("Property will be removed in a following version. Please define it yourself, i.e.: "
                  + "AbsolutePath ArtifactsDirectory => RootDirectory / \"artifacts\";")]
        public virtual PathConstruction.AbsolutePath ArtifactsDirectory => (PathConstruction.AbsolutePath) Path.Combine(RootDirectory, "artifacts");

        [Obsolete("Property will be removed in a following version. Please define it yourself, i.e.: "
                  + "AbsolutePath SourceDirectory => RootDirectory / \"source\";")]
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
