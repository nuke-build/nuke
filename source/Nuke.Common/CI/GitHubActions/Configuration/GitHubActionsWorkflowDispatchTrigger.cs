// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    [PublicAPI]
    public class GitHubActionsWorkflowDispatchTrigger : GitHubActionsDetailedTrigger
    {
        public string[] Inputs { get; set; }
        public string[] RequiredInputs { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("workflow_dispatch:");
            using (writer.Indent())
            {
                writer.WriteLine("inputs:");
                using (writer.Indent())
                {
                    void WriteInput(string input, bool required)
                    {
                        writer.WriteLine($"{input}:");
                        using (writer.Indent())
                        {
                            writer.WriteLine($"description: {input.SplitCamelHumpsWithSeparator(" ", Constants.KnownWords).DoubleQuote()}");
                            writer.WriteLine($"required: {required.ToString().ToLowerInvariant()}");
                        }
                    }

                    Inputs.ForEach(x => WriteInput(x, required: false));
                    RequiredInputs.ForEach(x => WriteInput(x, required: true));
                }
            }
        }
    }
}
