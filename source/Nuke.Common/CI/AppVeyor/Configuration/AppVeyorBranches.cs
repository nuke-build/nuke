// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AppVeyor.Configuration
{
    [PublicAPI]
    public class AppVeyorBranches : ConfigurationEntity
    {
        public string[] Only { get; set; }
        public string[] Except { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            if (Only.Length > 0)
            {
                using (writer.WriteBlock("only:"))
                {
                    Only.ForEach(x => writer.WriteLine($"- {x}"));
                }
            }

            if (Except.Length > 0)
            {
                using (writer.WriteBlock("except:"))
                {
                    Except.ForEach(x => writer.WriteLine($"- {x}"));
                }
            }
        }
    }
}
