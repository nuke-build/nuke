using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    [PublicAPI]
    public class SpaceAutomationCronScheduleTrigger : SpaceAutomationTrigger
    {
        public string CronExpression { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"cron({CronExpression.DoubleQuote()})");
        }
    }
}
