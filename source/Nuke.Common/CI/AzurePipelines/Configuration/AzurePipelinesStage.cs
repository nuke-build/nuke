using System;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    public class AzurePipelinesStage : AzurePipelinesConfigurationEntity
    {
        public string Name { get; set; }
        public AzurePipelinesImage? Image { get; set; }
        public AzurePipelinesStage[] Dependencies { get; set; }
        public AzurePipelinesJob[] Jobs { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"- stage: {Name.Replace("-", "_")}"))
            {
                writer.WriteLine($"displayName: {Name.SingleQuote()}");
                writer.WriteLine($"dependsOn: [ {Dependencies.Select(x => x.Name).JoinComma()} ]");

                if (Image != null)
                {
                    using (writer.WriteBlock("pool:"))
                    {
                        writer.WriteLine($"vmImage: {Image.Value.GetValue().SingleQuote()}");
                    }
                }

                using (writer.WriteBlock("jobs:"))
                {
                    Jobs.ForEach(x => x.Write(writer));
                }
            }
        }
    }
}