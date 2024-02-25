// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration;

[PublicAPI]
public class GitHubActionsConfiguration : ConfigurationEntity
{
    public string Name { get; set; }

    public GitHubActionsTrigger[] ShortTriggers { get; set; }
    public GitHubActionsDetailedTrigger[] DetailedTriggers { get; set; }
    public (GitHubActionsPermissions Type, string Permission)[] Permissions { get; set; }
    public string ConcurrencyGroup { get; set; }
    public bool ConcurrencyCancelInProgress { get; set; }
    public GitHubActionsJob[] Jobs { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        writer.WriteLine($"name: {Name}");
        writer.WriteLine();

        if (ShortTriggers.Length > 0)
            writer.WriteLine($"on: [{ShortTriggers.Select(x => x.GetValue().ToLowerInvariant()).JoinCommaSpace()}]");
        else
        {
            writer.WriteLine("on:");
            using (writer.Indent())
            {
                DetailedTriggers.ForEach(x => x.Write(writer));
            }
        }

        if (Permissions.Length > 0)
        {
            writer.WriteLine();
            writer.WriteLine("permissions:");
            using (writer.Indent())
            {
                Permissions.ForEach(x => writer.WriteLine($"{x.Type.GetValue()}: {x.Permission}"));
            }
        }

        if (!ConcurrencyGroup.IsNullOrWhiteSpace() || ConcurrencyCancelInProgress)
        {
            writer.WriteLine();
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

        writer.WriteLine();

        writer.WriteLine("jobs:");
        using (writer.Indent())
        {
            Jobs.ForEach(x => x.Write(writer));
        }
    }
}
