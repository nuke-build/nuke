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
    public static partial class EnvironmentInfo
    {
        public static AbsolutePath BuildProjectDirectory
        {
            get
            {
                var executingAssembly = Assembly.GetExecutingAssembly().Location;
                var buildProjectDirectory = Directory.GetParent(executingAssembly).NotNull()
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
