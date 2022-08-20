// Copyright 2021 Maintainers of NUKE.
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
        public string Artifact { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: DownloadPipelineArtifact@2"))
            {
                writer.WriteLine("displayName: Download Artifacts");
                using (writer.WriteBlock("inputs:"))
                {
                    if (!String.IsNullOrEmpty(Artifact))
                    {
                        writer.WriteLine($"artifactName: {Artifact.Split('/', '\\').Last().SingleQuoteIfNeeded()}");
                    }

                    writer.WriteLine($"targetPath: '$(Build.SourcesDirectory)/{Artifact}'"); //test
                }
            }
            using (writer.WriteBlock($"- task: NuGetAuthenticate@0"))
            {

            }
        }
    }
}
