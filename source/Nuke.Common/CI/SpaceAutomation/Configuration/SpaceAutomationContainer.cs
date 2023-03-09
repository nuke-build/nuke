// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.SpaceAutomation.Configuration
{
    [PublicAPI]
    public class SpaceAutomationContainer : ConfigurationEntity
    {
        public string Image { get; set; }
        public SpaceAutomationResources Resources { get; set; }
        public Dictionary<string, string> Imports { get; set; }
        public string BuildScript { get; set; }
        public string[] InvokedTargets { get; set; }
        public bool Submodules { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"container({Image.DoubleQuote()})"))
            {
                Resources.Write(writer);
                Imports.ForEach(x => writer.WriteLine($"{x.Key} = {x.Value}"));

                using (writer.WriteBlock("shellScript"))
                {
                    var scriptContent = new List<string>();
                    if (Submodules)
                        scriptContent.Add("git submodule update --init --recursive");

                    scriptContent.Add($"./{BuildScript} {InvokedTargets.JoinSpace()}");

                    writer.WriteArray("content", scriptContent.ToArray());
                }
            }
        }
    }
}
