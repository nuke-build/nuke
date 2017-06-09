// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;

namespace Nuke.Common.Tools.ReSharperWave
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class ReSharperWaveTasks
    {
        public static string ReSharperWave (string packagesConfigFile)
        {
            return NuGetPackageResolver.GetLocalInstalledPackages(packagesConfigFile)
                    .SingleOrDefault(x => x.Id.Equals("Wave", StringComparison.OrdinalIgnoreCase))
                    .AssertNotNull("wavePackage != null")
                    .Version.ToFullString();
        }
    }
}
