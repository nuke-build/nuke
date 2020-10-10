// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    public class GitHubActionsUsingStep : GitHubActionsStep
    {
        public string Using { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"- uses: {Using}");
        }
    }
    public class GitHubActionsCacheStep : GitHubActionsStep
    {
        public string[] IncludePatterns { get; set; }
        public string[] ExcludePatterns { get; set; }
        public string[] KeyFiles { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"- name: Cache {IncludePatterns.JoinComma()}");
            using (writer.Indent())
            {
                writer.WriteLine("uses: actions/cache@v2");
                writer.WriteLine("with:");
                using (writer.Indent())
                {
                    writer.WriteLine("path: |");
                    IncludePatterns.ForEach(x => writer.WriteLine($"  {x}"));
                    ExcludePatterns.ForEach(x => writer.WriteLine($"  !{x}"));
                    writer.WriteLine($"key: ${{{{ runner.os }}}}-${{{{ hashFiles({KeyFiles.Select(x => x.SingleQuote()).JoinComma()}) }}}}");
                }
            }
        }
    }
    public class GitHubActionsArtifactStep : GitHubActionsStep
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("- uses: actions/upload-artifact@v1");

            using (writer.Indent())
            {
                writer.WriteLine("with:");
                using (writer.Indent())
                {
                    writer.WriteLine($"name: {Name}");
                    writer.WriteLine($"path: {Path}");
                }
            }
        }
    }
}
