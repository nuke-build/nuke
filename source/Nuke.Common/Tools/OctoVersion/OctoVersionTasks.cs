// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Newtonsoft.Json;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.OctoVersion
{
    public partial class OctoVersionGetVersionSettings
    {
        private string GetProcessToolPath()
        {
            return OctoVersionTasks.GetToolPath(Framework);
        }
    }

    public partial class OctoVersionExecuteSettings
    {
        private string GetProcessToolPath()
        {
            return OctoVersionTasks.GetToolPath(Framework);
        }
    }

    public partial class OctoVersionTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return ToolPathResolver.GetPackageExecutable(
                packageId: "OctoVersion.Tool",
                packageExecutable: "OctoVersion.Tool.dll",
                framework: framework);
        }
    }
}
