// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildTasks
    {
        private static string GetToolPath()
        {
            return MSBuildToolPathResolver.Resolve();
        }
    }
}
