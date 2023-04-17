// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public class NpmPackageRequirement : ToolRequirement
{
    public static NpmPackageRequirement Create(string packageId, string version = null)
    {
        return new NpmPackageRequirement
               {
                   PackageId = packageId,
                   Version = version ?? NpmVersionResolver.GetLatestVersion(packageId).GetAwaiter().GetResult()
               };
    }

    private NpmPackageRequirement()
    {
    }

    public string PackageId { get; set; }
    public string Version { get; set; }
}
