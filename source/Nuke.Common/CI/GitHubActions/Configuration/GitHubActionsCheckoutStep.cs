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
    public class GitHubActionsCheckoutStep : GitHubActionsStep
    {
        public GitHubActionsSubmodules? Submodules { get; set; }
        public uint? FetchDepth { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("- uses: actions/checkout@v3");

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
}
