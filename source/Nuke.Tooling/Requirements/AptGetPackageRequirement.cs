﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public class AptGetPackageRequirement : ToolRequirement
{
    public static AptGetPackageRequirement Create(string packageId)
    {
        return new AptGetPackageRequirement
               {
                   PackageId = packageId,
               };
    }

    private AptGetPackageRequirement()
    {
    }

    public string PackageId { get; set; }
}
