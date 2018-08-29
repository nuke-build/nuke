// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using NuGet.Packaging;

namespace Nuke.Common.Tools.NuGet
{
    partial class NuGetPackage
    {
        public static NuGetPackage LoadFrom(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return LoadFrom(Manifest.ReadFrom(stream, validateSchema: true));
            }
        }

        public static NuGetPackage LoadFrom(Manifest manifest)
        {
            return NuGetPackageMapper.Map(manifest);
        }
    }
}
