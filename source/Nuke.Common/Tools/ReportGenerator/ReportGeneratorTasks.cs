// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.ReportGenerator;

[PublicAPI]
public class ReportGeneratorVerbosityMappingAttribute : VerbosityMappingAttribute
{
    public ReportGeneratorVerbosityMappingAttribute()
        : base(typeof(ReportGeneratorVerbosity))
    {
        Quiet = nameof(ReportGeneratorVerbosity.Off);
        Minimal = nameof(ReportGeneratorVerbosity.Warning);
        Normal = nameof(ReportGeneratorVerbosity.Info);
        Verbose = nameof(ReportGeneratorVerbosity.Verbose);
    }
}
