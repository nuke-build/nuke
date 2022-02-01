// Copyright 2021 Maintainers of NUKE.
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
        public static string GetLocalInstalledPackageDirectory(string packageId, string packagesConfigFile, string packagesGroup)
        {
            var packagesDirectory = GetPackagesDirectory(packagesConfigFile, packagesGroup);
            return Path.Combine(packagesDirectory, packageId);
        }

        private static string GetPackagesDirectory(string packagesConfigFile, string packagesGroup)
        {
            if (string.IsNullOrWhiteSpace(packagesGroup))
            {
                return Path.Combine(Path.GetDirectoryName(packagesConfigFile).NotNull(), "packages");
            }

            return Path.Combine(Path.GetDirectoryName(packagesConfigFile).NotNull(), "packages", packagesGroup);
        }
    }
}
