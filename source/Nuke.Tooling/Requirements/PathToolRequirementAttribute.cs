// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [BaseTypeRequired(typeof(IRequirePathTool))]
    public class PathToolRequirementAttribute : ToolRequirementAttributeBase
    {
        private readonly string _pathExecutable;

        public PathToolRequirementAttribute(string pathExecutable)
        {
            _pathExecutable = pathExecutable;
        }

        public override ToolRequirement GetRequirement(string version = null)
        {
            return PathToolRequirement.Create(_pathExecutable);
        }
    }
}
