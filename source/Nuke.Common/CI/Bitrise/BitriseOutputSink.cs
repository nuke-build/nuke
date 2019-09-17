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
        public BitriseOutputSink()
            : base(
                traceCode: "37",
                informationCode: "36;1",
                warningCode: "33;1",
                errorCode: "31;1",
                successCode: "32;1")
        {
        }

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => WriteNormal(FigletTransform.GetText(text, "ansi-shadow")));
        }
    }
}
