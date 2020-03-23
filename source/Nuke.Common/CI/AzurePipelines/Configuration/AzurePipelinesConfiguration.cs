// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    public class AzurePipelinesConfiguration : ConfigurationEntity
    {
        public AzurePipelinesVcsPushTrigger VcsPushTrigger { get; set; }

        public AzurePipelinesStage[] Stages { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            if (VcsPushTrigger != null)
            {
                using (writer.WriteBlock("trigger:"))
                {
                    VcsPushTrigger.Write(writer);
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
