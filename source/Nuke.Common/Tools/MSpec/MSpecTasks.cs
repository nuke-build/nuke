// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.MSpec
{
    partial class MSpecTasks
    {
        internal static string GetToolPath()
        {
            return NuGetToolPathResolver.GetPackageExecutable(
                "machine.specifications.runner.console",
                EnvironmentInfo.Is64Bit ? "mspec-clr4.exe" : "mspec-x86-clr4.exe");
        }
    }
}
