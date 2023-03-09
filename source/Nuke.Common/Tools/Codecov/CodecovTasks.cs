// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Codecov
{
    partial class CodecovSettings
    {
        private string GetProcessToolPath()
        {
            return CodecovTasks.GetToolPath(Framework);
        }
    }

    partial class CodecovTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return NuGetToolPathResolver.GetPackageExecutable(
                packageId: "Codecov.Tool",
                packageExecutable: "codecov.dll",
                framework: framework);
        }
    }
}
