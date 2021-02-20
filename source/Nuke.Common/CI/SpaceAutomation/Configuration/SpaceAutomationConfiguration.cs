// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    [PublicAPI]
    public class SpaceAutomationConfiguration : ConfigurationEntity
    {
        public string Name { get; set; }
        public SpaceAutomationContainer Container { get; set; }
        public SpaceAutomationTrigger[] Triggers { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"job({Name.DoubleQuote()})"))
            {
                using (writer.WriteBlock("git"))
                {
                    writer.WriteLine("depth = UNLIMITED_DEPTH");
                }

                writer.WriteLine();
                Container.Write(writer);

                if (Triggers.Any())
                {
                    writer.WriteLine();
                    using (writer.WriteBlock("startOn"))
                    {
                        Triggers.ForEach(x => x.Write(writer));
                    }
                }
            }
        }
    }
}
