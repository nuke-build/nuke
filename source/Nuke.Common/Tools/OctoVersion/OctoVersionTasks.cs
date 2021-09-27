// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

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
            ControlFlow.Assert(!string.IsNullOrEmpty(toolSettings.OutputJsonFile), $"{nameof(toolSettings.OutputJsonFile)} must be set");

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
                throw new Exception($"{nameof(OctoVersion)} exited with code {process.ExitCode}, but cannot parse output file {toolSettings.OutputJsonFile} as JSON",
                    exception);
            }
        }
    }
}
