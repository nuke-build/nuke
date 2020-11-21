﻿// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Octopus
{
    public partial class OctopusBuildInformationSettings
    {
        private string GetProcessToolPath()
        {
            return OctopusTasks.GetProcessToolPath(Framework);
        }
    }

    public partial class OctopusPackSettings
    {
        private string GetProcessToolPath()
        {
            return OctopusTasks.GetProcessToolPath(Framework);
        }
    }

    public partial class OctopusPushSettings
    {
        private string GetProcessToolPath()
        {
            return OctopusTasks.GetProcessToolPath(Framework);
        }
    }

    public partial class OctopusCreateReleaseSettings
    {
        private string GetProcessToolPath()
        {
            return OctopusTasks.GetProcessToolPath(Framework);
        }
    }

    public partial class OctopusDeployReleaseSettings
    {
        private string GetProcessToolPath()
        {
            return OctopusTasks.GetProcessToolPath(Framework);
        }
    }

    public partial class OctopusTasks
    {
        internal static string GetProcessToolPath(string framework = null)
        {
            return ToolPathResolver.GetPackageExecutable(
                packageId: "OctopusTools|Octopus.DotNet.Cli",
                packageExecutable: "Octo.exe|dotnet-octo.dll",
                framework: framework);
        }
    }
}
