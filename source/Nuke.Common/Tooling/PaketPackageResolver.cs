// Copyright 2018 Maintainers of NUKE.
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
        [CanBeNull]
        public static string TryGetLocalInstalledPackageDirectory(string packageId)
        {
            var packageDirectory = NukeBuild.RootDirectory / "packages" / packageId;
            return Directory.Exists(packageDirectory) ? packageDirectory : null;
        }
    }
}
