// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.InspectCode
{
    public static partial class InspectCodeTasks
    {
        private static string GetPackageExecutable()
        {
            return EnvironmentInfo.Is64Bit ? "inspectcode.exe" : "inspectcode.x86.exe";
        }

        private static void PreProcess(ref InspectCodeSettings toolSettings)
        {
            var installedPlugins = GetInstalledPlugins();
            if (installedPlugins.Count == 0 && toolSettings.Extensions.Count == 0)
                return;

            var shadowDirectory = GetShadowDirectory(toolSettings, installedPlugins);

            FileSystemTasks.CopyDirectoryRecursively(
                Path.GetDirectoryName(toolSettings.ToolPath).NotNull(),
                shadowDirectory,
                filePolicy: FileSystemTasks.FileExistsPolicy.OverwriteIfNewer);

            installedPlugins.Select(x => x.FileName)
                .ForEach(x => File.Copy(x, Path.Combine(shadowDirectory, Path.GetFileName(x).NotNull()), overwrite: true));

            toolSettings.Extensions.ForEach(x => HttpTasks.HttpDownloadFile(
                $"https://resharper-plugins.jetbrains.com/api/v2/package/{x}",
                Path.Combine(shadowDirectory, $"{x}.nupkg")));
        }

        [CanBeNull]
        private static IProcess StartProcess(InspectCodeSettings toolSettings)
        {
            var installedPackages = GetInstalledPlugins();
            if (toolSettings.Extensions.Count > 0 || installedPackages.Count > 0)
            {
                toolSettings = toolSettings.SetToolPath(
                    Path.Combine(
                        GetShadowDirectory(toolSettings, installedPackages),
                        GetPackageExecutable()));
            }

            return ProcessTasks.StartProcess(toolSettings);
        }

        private static void PostProcess(InspectCodeSettings toolSettings)
        {
            TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, toolSettings.Output);
        }

        // TODO [3]: validation of wave version?

        private static IReadOnlyCollection<NuGetPackageResolver.InstalledPackage> GetInstalledPlugins()
        {
            return NuGetPackageResolver.GetLocalInstalledPackages(ToolPathResolver.NuGetPackagesConfigFile)
                .Where(x => x.Metadata.GetDependencyGroups().SelectMany(y => y.Packages).Any(y => y.Id == "Wave"))
                .ToList();
        }

        private static string GetShadowDirectory(
            InspectCodeSettings toolSettings,
            IReadOnlyCollection<NuGetPackageResolver.InstalledPackage> installedPlugins)
        {
            var hashCode = installedPlugins.Select(x => x.Id).OrderBy(x => x).JoinComma().GetMD5Hash();
            return Path.Combine(NukeBuild.TemporaryDirectory, $"InspectCode-{hashCode.Substring(startIndex: 0, length: 4)}");
        }
    }
}
