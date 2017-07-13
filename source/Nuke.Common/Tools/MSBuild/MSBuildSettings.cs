// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Utilities;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildSettings
    {
        private string GetTargetPlatform ()
        {
            if (TargetPlatform == MSBuildTargetPlatform.MSIL)
                return TargetPath == null || TargetPath.EndsWith (".sln", StringComparison.OrdinalIgnoreCase)
                    ? "Any CPU".DoubleQuote()
                    : "AnyCPU";

            return TargetPlatform.ToString ();
        }
    }
}
