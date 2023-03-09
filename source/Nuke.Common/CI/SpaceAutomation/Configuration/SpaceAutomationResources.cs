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
    public class SpaceAutomationResources : ConfigurationEntity
    {
        public string Cpu { get; set; }
        public string Memory { get; set; }

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
