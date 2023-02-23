// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [BaseTypeRequired(typeof(IRequireNpmPackage))]
    public class NpmPackageRequirementAttribute : ToolRequirementAttributeBase
    {
        private readonly string _packageId;

        public NpmPackageRequirementAttribute(string packageId)
        {
            _packageId = packageId;
        }

        public override ToolRequirement GetRequirement(string version = null)
        {
            return NpmPackageRequirement.Create(_packageId, version);
        }
    }
}
