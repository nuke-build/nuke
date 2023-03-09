// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.SonarScanner
{
    partial class SonarScannerBeginSettings
    {
        private string GetProcessToolPath()
        {
            return SonarScannerTasks.GetToolPath(Framework);
        }
    }

    partial class SonarScannerEndSettings
    {
        private string GetProcessToolPath()
        {
            return SonarScannerTasks.GetToolPath(Framework);
        }
    }

    partial class SonarScannerTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return NuGetToolPathResolver.GetPackageExecutable(
                packageId: "dotnet-sonarscanner|MSBuild.SonarQube.Runner.Tool",
                packageExecutable: "SonarScanner.MSBuild.dll|SonarScanner.MSBuild.exe",
                framework: framework);
        }
    }
}
