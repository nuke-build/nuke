// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Versioning;
using Nuke.Core;
using Nuke.Core.BuildServers;

namespace Nuke.Common.Tools.InspectCode
{
    public static partial class InspectCodeTasks
    {
        private const int s_versionOffset = 100;

        static partial void PreProcess (InspectCodeSettings toolSettings)
        {
            // TODO: AssertValid();
            // toolSettings.Ass();

            //var assembly = Assembly.ReflectionOnlyLoadFrom(toolSettings.ToolPath);
            //var assemblyVersion = assembly.GetName().Version;
            //var waveVersion = new NuGetVersion(assemblyVersion.Major - s_versionOffset, minor: 0, patch: 0);
            //var installedPlugins = GetInstalledPlugins(waveVersion).ToList();
            //if (installedPlugins.Count == 0)
            //    return;

            //var hashCode = installedPlugins.Select(Path.GetFileName).Aggregate(seed: 0, func: (hc, x) => hc + x.GetHashCode());

            //var inspectCodeDirectory = Path.GetDirectoryName(toolSettings.ToolPath).NotNull();
        }

        private static IEnumerable<string> GetInstalledPlugins (NuGetVersion waveVersion)
        {
            foreach (var installedPackage in NuGetPackageResolver.GetLocalInstalledPackages())
            {
                var zipPackage = installedPackage.Metadata;
                var waveDependency = zipPackage.GetDependencyGroups().SelectMany(x => x.Packages).SingleOrDefault(x => x.Id == "Wave");
                if (waveDependency == null)
                    continue;

                if (!waveDependency.VersionRange.Satisfies(waveVersion))
                {
                    // TODO: ToNormalizedString
                    Logger.Warn(
                        $"Plugin '{installedPackage.Id}' (v{installedPackage.Version}) is not compatible with InspectCode.exe (v{waveVersion}).");
                    continue;
                }

                yield return installedPackage.FileName;
            }
        }

        static partial void PostProcess (InspectCodeSettings toolSettings)
        {
            TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, toolSettings.Output);
        }
    }
}
