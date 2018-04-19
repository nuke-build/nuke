// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    public static partial class DotNetTasks
    {
        public static string GetToolPath()
        {
            return ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE")
                   ?? ToolPathResolver.GetPathExecutable("dotnet");
        }

        public static DotNetRestoreSettings DefaultDotNetRestore => new DotNetRestoreSettings()
            .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
            .SetProjectFile(NukeBuild.Instance.SolutionFile);

        public static DotNetBuildSettings DefaultDotNetBuild => new DotNetBuildSettings()
            .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
            .SetProjectFile(NukeBuild.Instance.SolutionFile)
            .EnableNoRestore()
            .SetConfiguration(NukeBuild.Instance.Configuration)
            .SetAssemblyVersion(GitVersionAttribute.Value?.GetNormalizedAssemblyVersion())
            .SetFileVersion(GitVersionAttribute.Value?.GetNormalizedFileVersion())
            .SetInformationalVersion(GitVersionAttribute.Value?.InformationalVersion);

        public static DotNetPublishSettings DefaultDotNetPublish => new DotNetPublishSettings()
            .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
            .SetProject(NukeBuild.Instance.SolutionFile)
            .EnableNoRestore()
            .SetConfiguration(NukeBuild.Instance.Configuration)
            .SetAssemblyVersion(GitVersionAttribute.Value?.GetNormalizedAssemblyVersion())
            .SetFileVersion(GitVersionAttribute.Value?.GetNormalizedFileVersion())
            .SetInformationalVersion(GitVersionAttribute.Value?.InformationalVersion);

        public static DotNetPackSettings DefaultDotNetPack => new DotNetPackSettings()
            .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
            .SetProject(NukeBuild.Instance.SolutionFile)
            .EnableNoBuild()
            .SetConfiguration(NukeBuild.Instance.Configuration)
            .EnableIncludeSymbols()
            .SetOutputDirectory(NukeBuild.Instance.OutputDirectory)
            .SetVersion(GitVersionAttribute.Value?.NuGetVersionV2);

        public static DotNetTestSettings DefaultDotNetTest => new DotNetTestSettings()
            .SetWorkingDirectory(NukeBuild.Instance.SolutionDirectory)
            .EnableNoBuild()
            .SetConfiguration(NukeBuild.Instance.Configuration)
            .SetProjectFile(NukeBuild.Instance.SolutionFile);
    }
}
