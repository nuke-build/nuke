// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration;

public class AzurePipelinesNpmAuthenticateStep : AzurePipelinesStep
{
    public string NpmrcPath { get; set; }

    public override void Write(CustomFileWriter writer)
    {
        using (writer.WriteBlock("- task: npmAuthenticate@0"))
        {
            writer.WriteLine($"displayName: 'npm Authenticate {NpmrcPath}'");
            using (writer.WriteBlock("inputs:"))
            {
                writer.WriteLine($"workingFile: {NpmrcPath.SingleQuote()}");
            }
        }
    }
}
