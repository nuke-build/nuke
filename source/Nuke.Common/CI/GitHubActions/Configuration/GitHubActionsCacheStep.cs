// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    // https://github.com/actions/cache
    [PublicAPI]
    public class GitHubActionsCacheStep : GitHubActionsStep
    {
        public string[] IncludePatterns { get; set; }
        public string[] ExcludePatterns { get; set; }
        public string[] KeyFiles { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("- name: " + $"Cache: {IncludePatterns.JoinCommaSpace()}".SingleQuote());
            using (writer.Indent())
            {
                writer.WriteLine("uses: actions/cache@v3");
                writer.WriteLine("with:");
                using (writer.Indent())
                {
                    writer.WriteLine("path: |");
                    IncludePatterns.ForEach(x => writer.WriteLine($"  {x}"));
                    ExcludePatterns.ForEach(x => writer.WriteLine($"  !{x}"));
                    writer.WriteLine($"key: ${{{{ runner.os }}}}-${{{{ hashFiles({KeyFiles.Select(x => x.SingleQuote()).JoinCommaSpace()}) }}}}");
                }
            }
        }
    }
}
