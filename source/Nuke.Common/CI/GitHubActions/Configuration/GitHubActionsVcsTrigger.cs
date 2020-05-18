// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    public class GitHubActionsVcsTrigger : GitHubActionsDetailedTrigger
    {
        public GitHubActionsTrigger Kind { get; set; }
        public string[] Branches { get; set; }
        public string[] Tags { get; set; }
        public string[] IncludePaths { get; set; }
        public string[] ExcludePaths { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"{Kind.GetValue()}:");

            using (writer.Indent())
            {
                if (Branches.Length > 0)
                {
                    writer.WriteLine("branches:");
                    using (writer.Indent())
                    {
                        Branches.ForEach(x => writer.WriteLine($"- {x}"));
                    }
                }

                if (Tags.Length > 0)
                {
                    writer.WriteLine("tags:");
                    using (writer.Indent())
                    {
                        Tags.ForEach(x => writer.WriteLine($"- {x}"));
                    }
                }

                if (IncludePaths.Length > 0 || ExcludePaths.Length > 0)
                {
                    writer.WriteLine("paths:");
                    using (writer.Indent())
                    {
                        IncludePaths.ForEach(x => writer.WriteLine($"- {x}"));
                        ExcludePaths.ForEach(x => writer.WriteLine($"- !{x}"));
                    }
                }
            }
        }
    }
}
