using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    internal class AzurePipelinesNugetAuthenticateStep : AzurePipelinesStep
    {
        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"- task: NuGetAuthenticate@0"))
            {
                writer.WriteLine("displayName: Nuget Authentication");
            }
        }
    }
}
