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
            : base(
                traceCode: "90",
                informationCode: "36;1",
                warningCode: "33;1",
                errorCode: "31;1",
                successCode: "32;1")
        {
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
