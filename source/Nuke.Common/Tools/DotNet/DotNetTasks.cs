// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    partial class DotNetRunSettings
    {
        private string GetApplicationArguments()
        {
            return ApplicationArguments;
        }
    }

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

        internal static LogLevel ParseLogLevel(string arg)
        {
            var spaces = 0;
            for (var i = 0; i < arg.Length && spaces < 3; i++)
            {
                if (arg[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                if (i >= 4 &&
                    'e' == arg[i - 4] &&
                    'r' == arg[i - 3] &&
                    'r' == arg[i - 2] &&
                    'o' == arg[i - 1] &&
                    'r' == arg[i])
                    return LogLevel.Error;

                if (i >= 6 &&
                    'w' == arg[i - 6] &&
                    'a' == arg[i - 5] &&
                    'r' == arg[i - 4] &&
                    'n' == arg[i - 3] &&
                    'i' == arg[i - 2] &&
                    'n' == arg[i - 1] &&
                    'g' == arg[i])
                    return LogLevel.Warning;
            }

            return LogLevel.Information;
        }
    }
}
