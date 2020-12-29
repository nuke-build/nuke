// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;

namespace Nuke.Components
{
    public interface IPush : IPack, ITest
    {
        [Parameter]
        string NuGetSource => TryGetValue(() => NuGetSource) ?? "https://api.nuget.org/v3/index.json";

        [Parameter]
        string NuGetApiKey => TryGetValue(() => NuGetApiKey);

        Target Push => _ => _
            .DependsOn(Test, Pack)
            .Requires(() => NuGetApiKey)
            .Executes(() =>
            {
                DotNetNuGetPush(_ => _
                        .SetSource(NuGetSource)
                        .SetApiKey(NuGetApiKey)
                        .CombineWith(PackagesDirectory.GlobFiles("*.nupkg"), (_, v) => _
                            .SetTargetPath(v))
                        .Apply(PushSettings),
                    completeOnFailure: true,
                    degreeOfParallelism: 5);
            });

        Configure<DotNetNuGetPushSettings> PushSettings => _ => _;
    }
}
