// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AzurePipelines.Configuration;

namespace Nuke.Common.Tests.AzurePipelinesAttributes;

internal sealed class AzureDevOpsDownloadSecureFileStepAttribute : AzurePipelineStepAttribute
{
    public AzureDevOpsDownloadSecureFileStepAttribute(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }

    public override AzurePipelinesStep Get()
    {
        return new AzureDevOpsDownloadSecureFileStep(FileName);
    }
}
