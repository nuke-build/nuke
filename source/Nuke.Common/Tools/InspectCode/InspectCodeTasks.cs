// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.BuildServers;
using Nuke.Core.IO;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
#if !NETCORE
using Nuke.Common.IO;
#endif

namespace Nuke.Common.Tools.InspectCode
{
    public static partial class InspectCodeTasks
    {
        public static InspectCodeSettings DefaultInspectCode => new InspectCodeSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetTargetPath(NukeBuild.Instance.SolutionFile)
                .SetOutput(Path.Combine(NukeBuild.Instance.OutputDirectory, "inspectCode.xml"));

        static partial void PreProcess (InspectCodeSettings toolSettings)
        {
            var installedPlugins = GetInstalledPlugins();
            if (installedPlugins.Count == 0 && toolSettings.Extensions.Count == 0)
                return;

            var shadowDirectory = GetShadowDirectory(toolSettings, installedPlugins);

            FileSystemTasks.CopyRecursively(
                Path.GetDirectoryName(toolSettings.ToolPath).NotNull(),
                shadowDirectory,
                FileSystemTasks.FileExistsPolicy.OverwriteIfNewer);

            installedPlugins.Select(x => x.FileName)
                    .ForEach(x => File.Copy(x, Path.Combine(shadowDirectory, Path.GetFileName(x).NotNull()), overwrite: true));

#if !NETCORE
            toolSettings.Extensions.ForEach(x => HttpTasks.HttpDownloadFile(
                $"https://resharper-plugins.jetbrains.com/api/v2/package/{x}",
                Path.Combine(shadowDirectory, $"{x}.nupkg")));
#else
            ControlFlow.Assert(toolSettings.Extensions.Count == 0,
                "InspectCodeSettings.Extensions is currently not supported on .NET Core. However, after adding the ReSharper gallery feed " +
                "(https://resharper-plugins.jetbrains.com/api/v2), you can reference them as normal NuGet packages in your project file.");
#endif
        }

        [CanBeNull]
        private static IProcess StartProcess(InspectCodeSettings toolSettings, ProcessSettings processSettings)
        {
            var installedPackages = GetInstalledPlugins();
            if (toolSettings.Extensions.Count > 0 || installedPackages.Count > 0)
            {
                toolSettings = toolSettings.SetToolPath(
                    Path.Combine(
                        GetShadowDirectory(toolSettings, installedPackages),
                        toolSettings.GetPackageExecutable()));
            }

            return ProcessTasks.StartProcess(toolSettings, processSettings);
        }

        static partial void PostProcess (InspectCodeSettings toolSettings)
        {
            TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, toolSettings.Output);
        }

        // TODO [3]: validation of wave version?
        private static IReadOnlyCollection<NuGetPackageResolver.InstalledPackage> GetInstalledPlugins ()
        {
            return NuGetPackageResolver.GetLocalInstalledPackages()
                    .Where(x => x.Metadata.GetDependencyGroups().SelectMany(y => y.Packages).Any(y => y.Id == "Wave"))
                    .ToList();
        }

        private static string GetShadowDirectory (
            InspectCodeSettings toolSettings,
            IReadOnlyCollection<NuGetPackageResolver.InstalledPackage> installedPlugins)
        {
            var hashCode = Math.Abs(installedPlugins.Select(x => x.Id).Concat(toolSettings.Extensions)
                    .Aggregate(seed: 0, func: (hc, x) => hc + x.GetHashCode()));
            var hashCodeString = hashCode.ToString().Substring(startIndex: 0, length: 4);
            return Path.Combine(NukeBuild.Instance.TemporaryDirectory, $"InspectCode-{hashCodeString}");
        }
    }
}
