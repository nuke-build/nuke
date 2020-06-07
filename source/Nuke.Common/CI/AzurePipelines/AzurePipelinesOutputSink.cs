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
        {
            _azurePipelines = azurePipelines;
        }

        protected override string TraceCode => "90";
        protected override string InformationCode => "36;1";
        protected override string WarningCode => "33;1";
        protected override string ErrorCode => "31;1";
        protected override string SuccessCode => "32;1";

        internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _azurePipelines.Group(text),
                () => _azurePipelines.EndGroup(text));
        }

        protected override bool EnableWriteWarnings => false;
        protected override bool EnableWriteErrors => false;

        protected override void ReportWarning(string text, string details = null)
        {
            _azurePipelines.LogIssue(AzurePipelinesIssueType.Warning, text);
            if (details != null)
                base.WriteWarning(details);
        }

        protected override void ReportError(string text, string details = null)
        {
            _azurePipelines.LogIssue(AzurePipelinesIssueType.Error, text);
            if (details != null)
                base.WriteError(details);
        }

        internal override void IssueWarning(string message, string filePath = null, int? line = null, int? column = null, string code = null)
        {
            _azurePipelines.LogWarning(message, filePath, line, column, code);
        }

        internal override void IssueError(string message, string filePath = null, int? line = null, int? column = null, string code = null)
        {
            _azurePipelines.LogError(message, filePath, line, column, code);
        }
    }
}
