// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    public class GitHubActionsScheduledTrigger : GitHubActionsDetailedTrigger
    {
        public string Cron { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.Indent())
            {
                writer.WriteLine("schedule:");
                using (writer.Indent())
                {
                    writer.WriteLine($"  - cron: '{Cron}'");
                }
            }
        }
    }
}
