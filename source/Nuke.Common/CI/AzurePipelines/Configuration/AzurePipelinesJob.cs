// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesJob : ConfigurationEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public AzurePipelinesImage? Image { get; set; }
        public AzurePipelinesJob[] Dependencies { get; set; }
        public int Parallel { get; set; }
        public AzurePipelinesStep[] Steps { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"- job: {Name}"))
            {
                writer.WriteLine($"displayName: {DisplayName.SingleQuote()}");
                writer.WriteLine($"dependsOn: [ {Dependencies.Select(x => x.Name).JoinCommaSpace()} ]");

                if (Image != null)
                {
                    using (writer.WriteBlock("pool:"))
                    {
                        writer.WriteLine($"vmImage: {Image.Value.GetValue().SingleQuote().SingleQuote()}");
                    }
                }

                if (Parallel > 1)
                {
                    using (writer.WriteBlock("strategy:"))
                    {
                        writer.WriteLine($"parallel: {Parallel}");
                    }
                }

                using (writer.WriteBlock("steps:"))
                {
                    Steps.ForEach(x => x.Write(writer));
                }
            }
        }
    }
}
