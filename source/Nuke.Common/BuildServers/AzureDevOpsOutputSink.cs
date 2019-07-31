// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;

namespace Nuke.Common.BuildServers
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class AzureDevOpsOutputSink : AnsiColorOutputSink
    {
        private readonly AzureDevOps _azureDevOps;

        internal AzureDevOpsOutputSink(AzureDevOps azureDevOps)
        {
            WriteTest();
            _azureDevOps = azureDevOps;
        }

        public override void WriteWarning(string text, string details = null)
        {
            _azureDevOps.LogIssue(AzureDevOpsIssueType.Warning, text);
            if (details != null)
                WriteNormal(details);
        }

        public override void WriteError(string text, string details = null)
        {
            _azureDevOps.LogIssue(AzureDevOpsIssueType.Error, text);
            if (details != null)
                WriteNormal(details);
        }
    }
}
