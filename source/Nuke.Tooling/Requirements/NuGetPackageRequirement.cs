// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public class NuGetPackageRequirement : ToolRequirement
{
    public static NuGetPackageRequirement Create(string packageId, string version = null)
    {
        return new NuGetPackageRequirement
               {
                   PackageId = packageId,
                   Version = version ?? NuGetVersionResolver.GetLatestVersion(packageId, includePrereleases: false).GetAwaiter().GetResult()
               };
    }

    private NuGetPackageRequirement()
    {
    }

    public string PackageId { get; set; }
    public string Version { get; set; }
}