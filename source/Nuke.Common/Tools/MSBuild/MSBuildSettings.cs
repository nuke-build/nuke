// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.MSBuild
{
    [PublicAPI]
    public class MSBuildVerbosityMappingAttribute : VerbosityMappingAttribute
    {
        public MSBuildVerbosityMappingAttribute()
            : base(typeof(MSBuildVerbosity))
        {
            Quiet = nameof(MSBuildVerbosity.Quiet);
            Minimal = nameof(MSBuildVerbosity.Minimal);
            Normal = nameof(MSBuildVerbosity.Minimal);
            Verbose = nameof(MSBuildVerbosity.Detailed);
        }
    }

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

        private string GetProcessToolPath()
        {
            return MSBuildToolPathResolver.Resolve(MSBuildVersion, MSBuildPlatform);
        }
    }
}
