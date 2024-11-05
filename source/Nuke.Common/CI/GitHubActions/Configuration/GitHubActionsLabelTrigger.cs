// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration;

[PublicAPI]
public class GitHubActionsLabelTrigger : GitHubActionsDetailedTrigger
{
    public GitHubActionsLabelType[] Types { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        writer.WriteLine("label:");
        using (writer.Indent())
        {
            if (Types.Length > 0)
                writer.WriteLine($"types: [{Types.Select(x => x.GetValue()).JoinCommaSpace()}]");
        }
    }
}
