using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationCronScheduleTrigger : SpaceAutomationTrigger
    {
        public string CronExpression { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"schedule {{ cron({CronExpression.DoubleQuote()}) }}");
        }
    }
}
