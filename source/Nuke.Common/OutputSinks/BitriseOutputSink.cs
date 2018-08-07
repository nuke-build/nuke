// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class BitriseOutputSink : ConsoleOutputSink
    {
        public override IDisposable WriteBlock(string text)
        {
            Info(FigletTransform.GetText(text, "ansi-shadow"));
            return DelegateDisposable.CreateBracket();
        }
    }
}
