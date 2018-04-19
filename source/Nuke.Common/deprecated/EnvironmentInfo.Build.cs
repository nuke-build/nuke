#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Core.Utilities.Collections;
using static Nuke.Core.IO.PathConstruction;

namespace Nuke.Core
{
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
    public static partial class EnvironmentInfo
    {
        public static AbsolutePath BuildAssemblyDirectory
        {
            get
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                ControlFlow.Assert(entryAssembly.GetTypes().Any(x => x.IsSubclassOf(typeof(NukeBuild))),
                    $"{entryAssembly} doesn't contain a NukeBuild class.");
                return (AbsolutePath) Path.GetDirectoryName(entryAssembly.Location).NotNull();
            }
        }

        public static AbsolutePath BuildProjectDirectory
        {
            get
            {
                var buildProjectDirectory = new DirectoryInfo(BuildAssemblyDirectory)
                    .DescendantsAndSelf(x => x.Parent)
                    .Select(x => x.GetFiles("*.csproj", SearchOption.TopDirectoryOnly)
                                .SingleOrDefaultOrError($"Found multiple project files in '{x}'."))
                    .FirstOrDefault(x => x != null)
                    ?.DirectoryName;
                return (AbsolutePath) buildProjectDirectory.NotNull("buildProjectDirectory != null");
            }
        }
    }
}
