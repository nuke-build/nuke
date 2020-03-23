// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.Octopus
{
    public partial class OctopusPackSettings
    {
        private string GetToolPath()
        {
            return OctopusTasks.GetToolPath(Framework);
        }
    }

    public partial class OctopusPushSettings
    {
        private string GetToolPath()
        {
            return OctopusTasks.GetToolPath(Framework);
        }
    }

    public partial class OctopusCreateReleaseSettings
    {
        private string GetToolPath()
        {
            return OctopusTasks.GetToolPath(Framework);
        }
    }

    public partial class OctopusDeployReleaseSettings
    {
        private string GetToolPath()
        {
            return OctopusTasks.GetToolPath(Framework);
        }
    }

    public partial class OctopusListReleasesSettings
    {
        private string GetToolPath()
        {
            return OctopusTasks.GetToolPath(Framework);
        }
    }

    public partial class OctopusTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return ToolPathResolver.GetPackageExecutable(
                packageId: "OctopusTools|Octopus.DotNet.Cli",
                packageExecutable: "Octo.exe|dotnet-octo.dll",
                framework: framework);
        }

        private static OctopusListReleasesResult[] GetResult(IProcess process, OctopusListReleasesSettings toolSettings)
        {
            var output = process.Output.EnsureOnlyStd().Select(x => x.Text).JoinNewLine();

            return SerializationTasks.JsonDeserialize<OctopusListReleasesResult[]>(output,
                settings =>
                {
                    settings.ContractResolver = new SerializationTasks.AllWritableContractResolver();

                    return settings;
                });
        }
    }
}
