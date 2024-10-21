// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration;

public class AzurePipelinesNuGetAuthenticateStep : AzurePipelinesStep
{
    public override void Write(CustomFileWriter writer)
    {
        using (writer.WriteBlock("- task: NuGetAuthenticate@1"))
        {
            writer.WriteLine("displayName: 'NuGet Authenticate'");
        }
    }
}
