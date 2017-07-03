// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.NuGet
{
    partial class NuGetRestoreSettings
    {
        [CanBeNull]
        private string GetPackageSaveMode ()
        {
            switch (PackageSaveMode)
            {
                case null:
                    return null;
                case NuGet.PackageSaveMode.Nupkg:
                    return "nupkg";
                case NuGet.PackageSaveMode.Nuspec:
                    return "nuspec";
                case NuGet.PackageSaveMode.NuspecAndNupkg:
                    return "nuspec;nupkg";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
