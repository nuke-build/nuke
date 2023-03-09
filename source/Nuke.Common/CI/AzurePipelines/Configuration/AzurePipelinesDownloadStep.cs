// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesDownloadStep : AzurePipelinesStep
    {
        public string ArtifactName { get; set; }
        public string DownloadPath { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: DownloadBuildArtifacts@0"))
            {
                // writer.WriteLine("displayName: Download Artifacts");
                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine($"artifactName: {ArtifactName}");
                    writer.WriteLine($"downloadPath: {DownloadPath.SingleQuote()}");
                }
            }
        }
    }
}
