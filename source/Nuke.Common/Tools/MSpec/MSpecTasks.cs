// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.MSpec
{
    partial class MSpecSettings {
        private string GetToolPath() {
            return MSpecTasks.GetToolPath();
        }
    }


    public static partial class MSpecTasks
    {
        internal static string GetToolPath() {
            return ToolPathResolver.GetPackageExecutable(
                packageId: "machine.specifications.runner.console",
                packageExecutable: EnvironmentInfo.Is64Bit ? "mspec-clr4.exe" : "mspec-x86-clr4.exe");
        }
    }
}
