// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
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
                ControlFlow.Assert(BuildProjectDirectory != null, "No build project found. NukeBuild.RootDirectory has to be overridden.");
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

        [CanBeNull]
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
                return (PathConstruction.AbsolutePath) buildProjectDirectory;
            }
        }

    }
}
