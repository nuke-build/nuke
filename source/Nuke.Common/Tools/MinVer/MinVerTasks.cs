﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.MinVer
{
    public static partial class MinVerTasks
    {
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
}
