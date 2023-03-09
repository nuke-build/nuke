// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    // https://docs.microsoft.com/en-us/azure/devops/pipelines/repos/pipeline-options-for-git?view=azure-devops&tabs=yaml#checkout-submodules
    [PublicAPI]
    public class AzurePipelineCheckoutStep : AzurePipelinesStep
    {
        public bool? InclueSubmodules { get; set; }
        public bool? IncludeLargeFileStorage { get; set; }
        public int? FetchDepth { get; set; }
        public bool? Clean { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- checkout: self"))
            {
                if (IncludeLargeFileStorage.HasValue)
                {
                    writer.WriteLine($"lfs: {IncludeLargeFileStorage.Value}".ToLower());
                }

                if (InclueSubmodules.HasValue)
                {
                    writer.WriteLine($"submodules: {InclueSubmodules.Value}".ToLower());
                }

                if (FetchDepth.HasValue)
                {
                    writer.WriteLine($"fetchDepth: {FetchDepth.Value}");
                }

                if (Clean.HasValue)
                {
                    writer.WriteLine($"clean: {Clean.Value}".ToLower());
                }
            }
        }
    }
}
