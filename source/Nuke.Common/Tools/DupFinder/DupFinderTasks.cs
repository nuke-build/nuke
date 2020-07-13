// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.Tools.DupFinder
{
    public static partial class DupFinderTasks
    {
        private static string GetPackageExecutable()
        {
            return EnvironmentInfo.IsUnix
                ? "dupfinder.sh"
                : "dupfinder.exe";
        }
    }
}
