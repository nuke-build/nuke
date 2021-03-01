// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    // https://docs.microsoft.com/en-us/azure/devops/pipelines/release/caching
    [PublicAPI]
    public class AzurePipelinesCacheStep : AzurePipelinesStep
    {
        public string[] KeyFiles { get; set; }
        public string Path { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: Cache@2"))
            {
                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine($"key: $(Agent.OS) | {KeyFiles.JoinComma()}");
                    writer.WriteLine("restoreKeys: $(Agent.OS)");
                    writer.WriteLine($"path: {Path}");
                }
            }
        }
    }
}
