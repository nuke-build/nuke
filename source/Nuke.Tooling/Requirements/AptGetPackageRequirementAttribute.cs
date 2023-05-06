// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling;

[BaseTypeRequired(typeof(IRequireAptGetPackage))]
public class AptGetPackageRequirementAttribute : ToolRequirementAttributeBase
{
    private readonly string _packageId;

    public AptGetPackageRequirementAttribute(string packageId)
    {
        _packageId = packageId;
    }

    public override ToolRequirement GetRequirement(string version = null)
    {
        return AptGetPackageRequirement.Create(_packageId);
    }
}
