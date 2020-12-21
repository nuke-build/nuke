using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationTimeoutFailureCondition : SpaceAutomationFailureCondition
    {
        public bool? Timeout { get; set; }
        public int? TimeoutInMinutes { get; set; }
        
        public override void Write(CustomFileWriter writer)
        {
            if (Timeout.HasValue || TimeoutInMinutes.HasValue)
            {
                using (writer.WriteBlock("timeOut"))
                {
                    if (Timeout.HasValue)
                        writer.WriteLine($"enabled = {Timeout.ToString().ToLowerInvariant()}");

                    if (TimeoutInMinutes.HasValue)
                        writer.WriteLine($"timeOutInMinutes = {TimeoutInMinutes}");
                }
            }
        }
    }
}