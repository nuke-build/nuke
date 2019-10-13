// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    public class GitHubActionsConfiguration : GitHubActionsConfigurationEntity
    {
        public string Name { get; set; }

        public CI.GitHubActions.GitHubActionsTrigger[] ShortTriggers { get; set; }
        public GitHubActionsTrigger[] DetailedTriggers { get; set; }
        public GitHubActionsJob[] Jobs { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"name: {Name}");
            writer.WriteLine();

            if (ShortTriggers != null)
                writer.WriteLine($"on: [{ShortTriggers.Select(x => x.ToString().ToLowerInvariant()).JoinComma()}]");
            else
            {
                writer.WriteLine("on:");
                using (writer.Indent())
                {
                    DetailedTriggers.ForEach(x => x.Write(writer));
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
}
