// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.IO;
using Nuke.Common.Tools.ReSharper;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IReportDuplicates : IHazReports, IHazSolution
    {
        AbsolutePath DupFinderReportFile => ReportDirectory / "dupfinder.xml";

        Target ReportDuplicates => _ => _
            .TryAfter<ITest>()
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

                TeamCity.Instance?.ImportData(TeamCityImportType.DotNetDupFinder, DupFinderReportFile);
            });
    }
}
