using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    public class AzurePipelinesConfiguration : AzurePipelinesConfigurationEntity
    {
        public AzurePipelinesStage[] Stages { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("stages:"))
            {
                Stages.ForEach(x => x.Write(writer));
            }
        }
    }
}
