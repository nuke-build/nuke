// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.NUnit
{
    [PublicAPI]
    public class NUnitVerbosityMappingAttribute : VerbosityMappingAttribute
    {
        public NUnitVerbosityMappingAttribute()
            : base(typeof(NUnitTraceLevel))
        {
            Quiet = nameof(NUnitTraceLevel.Off);
            Minimal = nameof(NUnitTraceLevel.Warning);
            Normal = nameof(NUnitTraceLevel.Info);
            Verbose = nameof(NUnitTraceLevel.Verbose);
        }
    }
}
