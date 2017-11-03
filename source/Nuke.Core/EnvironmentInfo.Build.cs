// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Core.Utilities.Collections;
using static Nuke.Core.IO.PathConstruction;

namespace Nuke.Core
{
    public static partial class EnvironmentInfo
    {
        /// <summary>
        /// The build entry assembly.
        /// </summary>
        public static Assembly BuildAssembly => Assembly.GetEntryAssembly();

        [CanBeNull]
        public static AbsolutePath BuildDirectory
        {
            get
            {
                var buildAssembly = BuildAssembly.Location.NotNull("buildAssembly != null");
                var buildProjectDirectory = new FileInfo(buildAssembly).Directory.NotNull()
                        .DescendantsAndSelf(x => x.Parent)
                        .Select(x => x.GetFiles("*.csproj", SearchOption.TopDirectoryOnly).SingleOrDefault())
                        .FirstOrDefault(x => x != null)
                        ?.DirectoryName;
                return (AbsolutePath) buildProjectDirectory.NotNull("buildProjectDirectory != null");
            }
        }
    }
}
