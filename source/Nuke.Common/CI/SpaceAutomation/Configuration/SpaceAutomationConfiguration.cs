// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    public class SpaceAutomationConfiguration : ConfigurationEntity
    {
        public string Name { get; set; }
        public SpaceAutomationContainer Container { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"job({Name.DoubleQuote()})"))
            {
                Container.Write(writer);
            }
        }
    }
}
