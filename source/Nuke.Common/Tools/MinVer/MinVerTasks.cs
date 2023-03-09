// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.MinVer
{
    partial class MinVerTasks
    {
        internal static string GetToolPath(string framework = null)
        {
            return NuGetToolPathResolver.GetPackageExecutable(
                packageId: "minver-cli",
                packageExecutable: "minver-cli.dll",
                framework: framework);
        }

        private static MinVer GetResult(IProcess process, MinVerSettings toolSettings)
        {
            var versionString = process.Output.Select(x => x.Text).Single(x => !x.StartsWith("MinVer:"));

            var version = new MinVer
                          {
                              MinVerVersion = versionString,
                              MinVerMajor = versionString.Split('.')[0],
                              MinVerMinor = versionString.Split('.')[1],
                              MinVerPatch = versionString.Split('.')[2].Split('-')[0].Split('+')[0],
                              MinVerPreRelease = versionString.Split('+')[0].Contains('-') ? versionString.Split('+')[0].Split(new[] { '-' }, count: 2)[1] : null,
                              MinVerBuildMetadata = versionString.Contains('+') ? versionString.Split(new[] { '+' }, count: 2)[1] : null
                          };

            version.AssemblyVersion = $"{version.MinVerMajor}.0.0.0";
            version.FileVersion = $"{version.MinVerMajor}.{version.MinVerMinor}.{version.MinVerPatch}.0";
            version.PackageVersion = versionString;
            version.Version = versionString;

            return version;
        }
    }

    partial class MinVerSettings
    {
        private string GetProcessToolPath()
        {
            return MinVerTasks.GetToolPath(Framework);
        }
    }
}
