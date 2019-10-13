// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    public class GitHubActionsJob : GitHubActionsConfigurationEntity
    {
        public string Name { get; set; }
        public GitHubActionsImage Image { get; set; }
        public GitHubActionsStep[] Steps { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"{Name}:");

            using (writer.Indent())
            {
                writer.WriteLine($"name: {Name}");
                writer.WriteLine($"runs-on: {Image.ConvertToString()}");
                writer.WriteLine("steps:");
                using (writer.Indent())
                {
                    Steps.ForEach(x => x.Write(writer));
                }
            }
        }
    }
}
