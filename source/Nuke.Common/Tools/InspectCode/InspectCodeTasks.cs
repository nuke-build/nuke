// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.BuildServers;

namespace Nuke.Common.Tools.InspectCode
{
    public static partial class InspectCodeTasks
    {
        //static partial void PreProcess (InspectCodeSettings inspectCodeSettings)
        //{
        //    inspectCodeSettings.AssertValid();

        //    var assembly = Assembly.ReflectionOnlyLoadFrom(inspectCodeSettings.ToolPath);
        //    var assemblyVersion = assembly.GetName().Version;
        //    var waveVersion = new SemanticVersion(assemblyVersion.Major - 100, minor: 0, build: 0, revision: 0);

        //    foreach (var installedPackage in NuGetPackageResolver.GetLocalInstalledPackages ())
        //    {
        //        var zipPackage = installedPackage.ZipPackage;
        //        var waveDependency = zipPackage.DependencySets.SelectMany (x => x.Dependencies).SingleOrDefault (x => x.Id == "Wave");
        //        if (waveDependency == null)
        //            continue;

        //        if (waveDependency.VersionSpec.MinVersion.CompareTo (waveVersion) != 0)
        //        {
        //            Logger.Warn ($"Plugin '{zipPackage.Id}' (v{zipPackage.Id}) is not compatible with InspectCode.exe (v{assemblyVersion}).");
        //            continue;
        //        }

        //        var inspectCodeDirectory = Path.GetDirectoryName (inspectCodeSettings.ToolPath).AssertNotNull ();
        //        var installedPackageName = Path.GetFileName (installedPackage.FileName).AssertNotNull ();
        //        File.Copy (installedPackage.FileName, Path.Combine (inspectCodeDirectory, installedPackageName));
        //    }
        //}

        static partial void PostProcess (InspectCodeSettings inspectCodeSettings)
        {
            TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, inspectCodeSettings.Output);
        }
    }
}
