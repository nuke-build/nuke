// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

namespace Nuke.NSwag
{
    public static partial class NSwagTasks
    {
        public static string GetNetCoreDllPath (string runtime)
        {
            var packageDir = (PathConstruction.AbsolutePath) NuGetPackageResolver.GetLocalInstalledPackageDirectory("nswag.msbuild")
                    .NotNull("Package NSwag.MSBuild not found. Please install the package to your build project.");
            return packageDir / "build" / runtime / "dotnet-nswag.dll";
        }

        public static string GetToolPath ()
        {
            ControlFlow.Fail("Settings.NSwagRuntime must be defined to detect the proper nswag executable.");
            return null;
        }

        public enum Runtime
        {
            NetCore10,
            NetCore11,
            NetCore20,
            NetCore21,
            Win
        }
    }
}