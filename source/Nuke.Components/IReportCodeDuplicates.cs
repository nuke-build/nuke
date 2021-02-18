// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.ReSharper;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IReportCodeDuplicates : IHazReports, IHazSolution
    {
        AbsolutePath DupFinderReportFile => ReportDirectory / "dupfinder.xml";

        Target ReportCodeDuplicates => _ => _
            .Executes(() =>
            {
                ReSharperDupFinder(_ => _
                    .SetSource(Solution)
                    .SetOutputFile(DupFinderReportFile)
                    .EnableShowText()
                    .SetExcludeFiles(
                        "**/*.Generated.cs",
                        "**/obj/**",
                        "**/bin/**"));
            });
    }
}
