// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration;

[PublicAPI]
public class GitHubActionsJob : ConfigurationEntity
{
    public string Name { get; set; }
    public GitHubActionsImage Image { get; set; }
    public int TimeoutMinutes { get; set; }
    public string ConcurrencyGroup { get; set; }
    public bool ConcurrencyCancelInProgress { get; set; }
    public GitHubActionsStep[] Steps { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        writer.WriteLine($"{Name}:");

        using (writer.Indent())
        {
            writer.WriteLine($"name: {Name}");
            writer.WriteLine($"runs-on: {Image.GetValue()}");

            if (TimeoutMinutes > 0)
            {
                writer.WriteLine($"timeout-minutes: {TimeoutMinutes}");
            }

            if (!ConcurrencyGroup.IsNullOrWhiteSpace() || ConcurrencyCancelInProgress)
            {
                writer.WriteLine("concurrency:");
                using (writer.Indent())
                {
                    var group = ConcurrencyGroup;
                    if (group.IsNullOrWhiteSpace())
                    {
                        // create a default value that only cancels in-progress runs of the same workflow
                        // we don't fall back to github.ref which would disable multiple runs in main/master which is usually what is wanted
                        group = "${{ github.workflow }} @ ${{ github.event.pull_request.head.label || github.head_ref || github.run_id }}";
                    }

                    writer.WriteLine($"group: {group}");
                    if (ConcurrencyCancelInProgress)
                    {
                        writer.WriteLine("cancel-in-progress: true");
                    }
                }
            }

            writer.WriteLine("steps:");
            using (writer.Indent())
            {
                Steps.ForEach(x => x.Write(writer));
            }
        }
    }
}
