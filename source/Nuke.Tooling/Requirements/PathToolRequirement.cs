// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public class PathToolRequirement : ToolRequirement
{
    public static PathToolRequirement Create(string pathExecutable)
    {
        return new PathToolRequirement
               {
                   PathExecutable = pathExecutable,
               };
    }

    public PathToolRequirement()
    {
    }

    public string PathExecutable { get; set; }
}
