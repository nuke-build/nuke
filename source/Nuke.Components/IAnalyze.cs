// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.ReSharper;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

namespace Nuke.Components
{
    public interface IAnalyze : IRestore, IHazArtifacts
    {
        AbsolutePath ReportDirectory => ArtifactsDirectory / "reports";

        Target Analysis => _ => _
            .DependsOn(Restore)
            .Executes(() =>
            {
                ReSharperInspectCode(_ => _
                    .SetTargetPath(Solution)
                    .SetOutput(ReportDirectory / "inspectCode.xml")
                    .When(RootDirectory.Contains(DotNetPath), _ => _
                        .SetDotNetCore(DotNetPath))
                    .CombineWith(InspectCodePlugins, (_, v) => _
                        .AddPlugin(v.PackageId, v.Version)));
            });

        IEnumerable<(string PackageId, string Version)> InspectCodePlugins
            => new (string PackageId, string Version)[0];
    }
}
