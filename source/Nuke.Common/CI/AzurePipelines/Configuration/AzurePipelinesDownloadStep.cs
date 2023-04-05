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
        public string[] ItemPatterns { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: DownloadBuildArtifacts@0"))
            {
                // writer.WriteLine("displayName: Download Artifacts");
                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine("buildType: 'current'");
                    writer.WriteLine("downloadType: 'specific'");
                    using (writer.WriteBlock("itemPattern: |"))
                    {
                        foreach (var itemPattern in ItemPatterns)
                        {
                            writer.WriteLine(itemPattern);
                        }
                    }
                    writer.WriteLine("downloadPath: '$(Build.Repository.LocalPath)'");
                }
            }
        }
    }
}
