using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesPool : ConfigurationEntity
    {
        public AzurePipelinesPool(AzurePipelinesImage image)
        {
            Image = image;
        }

        public AzurePipelinesPool(string name, params string[] demands)
        {
            Name = name;
            Demands = demands;
        }

        public string Name { get; }
        public string[] Demands { get; }
        public AzurePipelinesImage? Image { get; }

        public string GetNameForStage()
        {
            if (Image != null)
            {
                return Image.Value.GetValue();
            }
            else
            {
                return Name;
            }
        }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("pool:"))
            {
                if (Image != null)
                {
                    writer.WriteLine($"vmImage: {Image.Value.GetValue().SingleQuote().SingleQuote()}");
                }
                else if (Name != null)
                {
                    writer.WriteLine($"name: {Name}");

                    if (Demands?.Any() == true)
                    {
                        using (writer.WriteBlock("demands:"))
                        {
                            Demands.ForEach(x => writer.WriteLine($"- {x}"));
                        }
                    }
                }
            }
        }

        public string GetUserHomeDirectory()
        {
            if (Image != null)
            {
                return GetUserHomeDirectory(Image.Value.GetValue());
            }
            else
            {
                var agentOS = Demands?.FirstOrDefault(x => x.StartsWith("Agent.OS"));
                if (agentOS != null)
                {
                    return GetUserHomeDirectory(agentOS.SplitSpace().Last());
                }
            }

            // By default, we assume it's Linux based pool
            return GetUserHomeDirectory("ubuntu");
        }

        private static string GetUserHomeDirectory(string os)
        {
            return os.StartsWithAnyOrdinalIgnoreCase("ubuntu", "macos")
                ? "$(HOME)"
                : "$(USERPROFILE)";
        }
    }
}
