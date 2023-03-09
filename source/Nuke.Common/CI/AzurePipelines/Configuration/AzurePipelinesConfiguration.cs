// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesConfiguration : ConfigurationEntity
    {
        public string[] VariableGroups { get; set; }

        [CanBeNull]
        public AzurePipelinesVcsPushTrigger VcsPushTrigger { get; set; }

        [CanBeNull]
        public AzurePipelinesVcsPushTrigger VcsPullRequestTrigger { get; set; }

        public AzurePipelinesStage[] Stages { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            if (VariableGroups.Length > 0)
            {
                using (writer.WriteBlock("variables:"))
                {
                    VariableGroups.ForEach(x => writer.WriteLine($"- group: {x}"));
                    writer.WriteLine();
                }
            }

            if (VcsPushTrigger != null)
            {
                using (writer.WriteBlock("trigger:"))
                {
                    VcsPushTrigger.Write(writer);
                    writer.WriteLine();
                }
            }

            if (VcsPullRequestTrigger != null)
            {
                using (writer.WriteBlock("pr:"))
                {
                    VcsPullRequestTrigger.Write(writer);
                    writer.WriteLine();
                }
            }

            using (writer.WriteBlock("stages:"))
            {
                Stages.ForEach(x => x.Write(writer));
            }
        }
    }
}
