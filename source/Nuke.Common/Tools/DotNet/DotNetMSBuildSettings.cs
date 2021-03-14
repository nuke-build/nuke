// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.DotNet
{
    partial class DotNetMSBuildSettings
    {
        [CanBeNull]
        private string GetTargetPlatform()
        {
            if (TargetPlatform == null)
                return null;

            if (Equals(TargetPlatform, MSBuildTargetPlatform.MSIL))
            {
                return TargetPath == null || TargetPath.EndsWithOrdinalIgnoreCase(".sln")
                    ? "Any CPU".DoubleQuote()
                    : "AnyCPU";
            }

            return TargetPlatform.ToString();
        }
    }
}
