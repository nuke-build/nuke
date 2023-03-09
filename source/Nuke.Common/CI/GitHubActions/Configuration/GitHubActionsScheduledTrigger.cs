// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    [PublicAPI]
    public class GitHubActionsScheduledTrigger : GitHubActionsDetailedTrigger
    {
        public string Cron { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("schedule:");
            using (writer.Indent())
            {
                writer.WriteLine($"- cron: '{Cron}'");
            }
        }
    }
}
