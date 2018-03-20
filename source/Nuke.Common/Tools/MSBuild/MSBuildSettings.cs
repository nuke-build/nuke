// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildSettings
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

        private string GetToolPath()
        {
            return MSBuildToolPathResolver.Resolve(MSBuildVersion, MSBuildPlatform);
        }
    }
}
