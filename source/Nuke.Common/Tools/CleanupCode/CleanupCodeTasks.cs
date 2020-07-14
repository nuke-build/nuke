// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.CleanupCode
{
    public static partial class CleanupCodeTasks
    {
        public const string CleanupCodePluginLatest = null;

        private static string GetPackageExecutable()
        {
            return EnvironmentInfo.IsUnix
                ? "cleanupcode.sh"
                : EnvironmentInfo.Is64Bit
                    ? "cleanupcode.exe"
                    : "cleanupcode.x86.exe";
        }

        private static void PreProcess(ref CleanupCodeSettings toolSettings)
        {
            var installedPlugins = GetInstalledPlugins();
            if (installedPlugins.Count == 0 && toolSettings.Plugins.Count == 0)
                return;

            var shadowDirectory = GetShadowDirectory(toolSettings, installedPlugins);

            FileSystemTasks.CopyDirectoryRecursively(
                Path.GetDirectoryName(toolSettings.ToolPath).NotNull(),
                shadowDirectory,
                DirectoryExistsPolicy.Merge,
                FileExistsPolicy.OverwriteIfNewer);

            installedPlugins.Select(x => x.FileName)
                .ForEach(x => File.Copy(x, Path.Combine(shadowDirectory, Path.GetFileName(x).NotNull()), overwrite: true));

            toolSettings.Plugins.ForEach(x => HttpTasks.HttpDownloadFile(
                $"http://resharper-plugins.jetbrains.com/dotnet/api/v2/Packages(Id='{x.Key}',Version='{x.Value}')/Download",
                Path.Combine(shadowDirectory, $"{x.Key}.nupkg")));
        }

        [CanBeNull]
        private static IProcess StartProcess(CleanupCodeSettings toolSettings)
        {
            var installedPackages = GetInstalledPlugins();
            if (toolSettings.Plugins.Count > 0 || installedPackages.Count > 0)
            {
                toolSettings = toolSettings.SetToolPath(
                    Path.Combine(
                        GetShadowDirectory(toolSettings, installedPackages),
                        GetPackageExecutable()));
            }

            return ProcessTasks.StartProcess(toolSettings);
        }

        // TODO [3]: validation of wave version?

        private static IReadOnlyCollection<NuGetPackageResolver.InstalledPackage> GetInstalledPlugins()
        {
            return NuGetPackageResolver.GetLocalInstalledPackages(ToolPathResolver.NuGetPackagesConfigFile)
                .Where(x => x.Metadata.GetDependencyGroups().SelectMany(y => y.Packages).Any(y => y.Id == "Wave"))
                .ToList();
        }

        private static string GetShadowDirectory(
            CleanupCodeSettings toolSettings,
            IReadOnlyCollection<NuGetPackageResolver.InstalledPackage> installedPlugins)
        {
            var hashCode = toolSettings.ToolPath.Concat(installedPlugins.Select(x => x.Id)).OrderBy(x => x).JoinComma().GetMD5Hash();
            return Path.Combine(NukeBuild.TemporaryDirectory, $"CleanupCode-{hashCode.Substring(startIndex: 0, length: 4)}");
        }
    }
}
