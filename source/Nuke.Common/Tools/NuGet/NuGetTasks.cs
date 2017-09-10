// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.NuGet
{
    public static partial class NuGetTasks
    {
        public static NuGetPackSettings DefaultNuGetPack => new NuGetPackSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetOutputDirectory(NukeBuild.Instance.OutputDirectory)
                .SetConfiguration(NukeBuild.Instance.Configuration)
                .SetVersion(GitVersionAttribute.Value?.NuGetVersionV2);

        public static NuGetRestoreSettings DefaultNuGetRestore => new NuGetRestoreSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetTargetPath(NukeBuild.Instance.SolutionFile);
    }
}
