// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesCmdStep : AzurePipelinesStep
    {
        public string[] InvokedTargets { get; set; }
        public string BuildCmdPath { get; set; }
        public int? PartitionSize { get; set; }
        public Dictionary<string, string> Imports { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: CmdLine@2"))
            {
                var arguments = $"{InvokedTargets.JoinSpace()} --skip";
                if (PartitionSize != null)
                    arguments += $" --partition $(System.JobPositionInPhase)/{PartitionSize}";

                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine($"script: './{BuildCmdPath} {arguments}'");
                }

                if (Imports.Count > 0)
                {
                    using (writer.WriteBlock("env:"))
                    {
                        Imports.ForEach(x => writer.WriteLine($"{x.Key}: {x.Value}"));
                    }
                }
            }
        }
    }
}
