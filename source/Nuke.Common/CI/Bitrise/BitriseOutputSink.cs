// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Bitrise
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class BitriseOutputSink : AnsiColorOutputSink
    {
        protected override string TraceCode => "37";
        protected override string InformationCode => "36;1";
        protected override string WarningCode => "33;1";
        protected override string ErrorCode => "31;1";
        protected override string SuccessCode => "32;1";

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => WriteNormal(FigletTransform.GetText(text, "ansi-shadow")));
        }
    }
}
