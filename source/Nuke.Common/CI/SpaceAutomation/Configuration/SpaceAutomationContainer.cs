// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    [PublicAPI]
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
