// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationContainer : ConfigurationEntity
    {
        public string Image { get; set; }
        public SpaceAutomationResources Resources { get; set; }
        public string BuildScript { get; set; }
        public string[] InvokedTargets { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"container({Image.DoubleQuote()})"))
            {
                Resources.Write(writer);

                using (writer.WriteBlock("shellScript"))
                {
                    writer.WriteLine($"content = {$"./{BuildScript} {InvokedTargets.JoinSpace()}".DoubleQuote()}");
                }
            }
        }
    }
}
