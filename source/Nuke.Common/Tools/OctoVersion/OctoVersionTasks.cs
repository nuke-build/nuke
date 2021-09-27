// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

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

        private static OctoVersionInfo GetResult(IProcess process, OctoVersionGetVersionSettings toolSettings)
        {
            ControlFlow.Assert(toolSettings.OutputJsonFile != null, "toolSettings.OutputJsonFile != null");

            try
            {
                return SerializationTasks.JsonDeserializeFromFile<OctoVersionInfo>(toolSettings.OutputJsonFile, settings =>
                {
                    settings.ContractResolver = new AllWritableContractResolver();
                    return settings;
                });
            }
            catch (Exception exception)
            {
                throw new Exception($"Cannot parse {nameof(OctoVersion)} output from {toolSettings.OutputJsonFile.SingleQuote()}.", exception);
            }
        }
    }
}
