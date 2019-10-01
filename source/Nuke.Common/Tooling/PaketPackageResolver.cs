// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    // TODO: Add similar methods to NuGetPackageResolver
    [PublicAPI]
    public static class PaketPackageResolver
    {
        public static string GetLocalInstalledPackageDirectory(string packageId, string packagesConfigFile)
        {
            var packagesDirectory = GetPackagesDirectory(packagesConfigFile);
            return Path.Combine(packagesDirectory, packageId);
        }

        private static string GetPackagesDirectory(string packagesConfigFile)
        {
            return Path.Combine(Path.GetDirectoryName(packagesConfigFile).NotNull(), "packages");
        }
    }
}
