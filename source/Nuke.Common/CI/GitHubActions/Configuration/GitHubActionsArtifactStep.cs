// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration;

public class GitHubActionsArtifactStep : GitHubActionsStep
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Condition { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        writer.WriteLine("- name: " + $"Publish: {Name}".SingleQuote());
        writer.WriteLine("  uses: actions/upload-artifact@v4");

        using (writer.Indent())
        {
            if (!Condition.IsNullOrWhiteSpace())
            {
                writer.WriteLine($"if: {Condition}");
            }

            writer.WriteLine("with:");
            using (writer.Indent())
            {
                writer.WriteLine($"name: {Name}");
                writer.WriteLine($"path: {Path}");
            }
        }
    }
}
