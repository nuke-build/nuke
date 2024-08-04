// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tests.AzurePipelinesAttributes;

internal sealed class AzureDevOpsDownloadSecureFileStep : AzurePipelinesStep
{
    public AzureDevOpsDownloadSecureFileStep(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; }
    public override void Write(CustomFileWriter writer)
    {
        writer.WriteLine("- task: DownloadSecureFile@1");
        using (writer.Indent())
        {
            writer.WriteLine("inputs:");
            using (writer.Indent())
            {
                writer.WriteLine($"secureFile: '{FileName}'");
            }
        }
    }
}
