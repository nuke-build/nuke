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
    public class GitHubActionsWorkflowDispatchTrigger : GitHubActionsDetailedTrigger
    {
        public string[] Inputs { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("workflow_dispatch:");
            using (writer.Indent())
            {
                writer.WriteLine("inputs:");
                using (writer.Indent())
                {
                    foreach (var input in Inputs)
                    {
                        writer.WriteLine($"{input}:");
                        using (writer.Indent())
                        {
                            writer.WriteLine($"description: {input.SplitCamelHumpsWithSeparator(" ", Constants.KnownWords).DoubleQuote()}");
                        }
                    }
                }
            }
        }
    }
}
