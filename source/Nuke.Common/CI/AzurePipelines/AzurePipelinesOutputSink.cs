// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class AzurePipelinesOutputSink : AnsiColorOutputSink
    {
        private readonly AzurePipelines _azurePipelines;

        internal AzurePipelinesOutputSink(AzurePipelines azurePipelines)
            : base(
                traceCode: "90",
                informationCode: "36;1",
                warningCode: "33;1",
                errorCode: "31;1",
                successCode: "32;1")
        {
            _azurePipelines = azurePipelines;
        }

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _azurePipelines.Group(text),
                () => _azurePipelines.EndGroup(text));
        }

        public override void WriteWarning(string text, string details = null)
        {
            _azurePipelines.LogIssue(AzurePipelinesIssueType.Warning, text);
            if (details != null)
                WriteNormal(details);
        }

        public override void WriteError(string text, string details = null)
        {
            _azurePipelines.LogIssue(AzurePipelinesIssueType.Error, text);
            if (details != null)
                WriteNormal(details);
        }
    }
}
