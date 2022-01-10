// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    [PublicAPI]
    public class GitHubActionsCheckoutStep : GitHubActionsStep
    {
        public GitHubActionsSubmodules? Submodules { get; set; }
        public uint? FetchDepth { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("- uses: actions/checkout@v2");

            if (Submodules.HasValue || FetchDepth.HasValue)
            {
                using (writer.Indent())
                {
                    writer.WriteLine("with:");
                    using (writer.Indent())
                    {
                        if (Submodules.HasValue)
                            writer.WriteLine($"submodules: {Submodules.ToString().ToLowerInvariant()}");
                        if (FetchDepth.HasValue)
                            writer.WriteLine($"fetch-depth: {FetchDepth}");
                    }
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
