// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    // https://docs.microsoft.com/en-us/azure/devops/pipelines/release/caching
    [PublicAPI]
    public class AzurePipelinesCacheStep : AzurePipelinesStep
    {
        public AzurePipelinesImage Image { get; set; }
        public string[] KeyFiles { get; set; }
        public string Path { get; set; }

        private string AdjustedPath =>
            Image.GetValue().StartsWithAnyOrdinalIgnoreCase("ubuntu", "macos")
                ? Path.Replace("~", "$(HOME)")
                : Path.Replace("~", "$(USERPROFILE)");

        private string Identifier => Path
            .Replace(".", "/")
            .Replace("~", "/")
            .Replace("/", "-")
            .Trim('-');

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: Cache@2"))
            {
                writer.WriteLine("displayName: " + $"Cache: {Identifier}".SingleQuote());
                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine($"key: $(Agent.OS) | {Identifier} | {KeyFiles.JoinCommaSpace()}");
                    writer.WriteLine($"restoreKeys: $(Agent.OS) | {Identifier}");
                    writer.WriteLine($"path: {AdjustedPath}");
                }
            }
        }
    }
}
