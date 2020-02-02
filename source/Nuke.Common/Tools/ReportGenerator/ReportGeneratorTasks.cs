// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.ReportGenerator
{
    partial class ReportGeneratorSettings
    {
        private string GetToolPath()
        {
            return ReportGeneratorTasks.GetToolPath(Framework);
        }
    }

    partial class ReportGeneratorTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return ToolPathResolver.GetPackageExecutable(
                packageId: "ReportGenerator",
                packageExecutable: "ReportGenerator.dll|ReportGenerator.exe",
                framework: framework);
        }
    }
}
