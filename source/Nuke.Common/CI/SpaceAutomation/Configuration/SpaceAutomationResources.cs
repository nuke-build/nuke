using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationResources : ConfigurationEntity
    {
        public int? Cpu { get; set; }
        public int? Memory { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            if (Cpu != null || Memory != null)
            {
                using (writer.WriteBlock($"resources"))
                {
                    if (Cpu != null)
                        writer.WriteLine($"cpu = {Cpu}");
                    if (Memory != null)
                        writer.WriteLine($"memory = {Memory}");
                }
            }
        }
    }
}
