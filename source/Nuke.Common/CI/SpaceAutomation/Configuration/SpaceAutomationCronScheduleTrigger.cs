// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

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
            writer.WriteLine($"schedule {{ cron({CronExpression.DoubleQuote()}) }}");
        }
    }
}
