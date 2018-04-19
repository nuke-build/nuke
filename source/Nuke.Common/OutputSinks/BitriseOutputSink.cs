// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    internal class BitriseOutputSink : ConsoleOutputSink
    {
        public override IDisposable WriteBlock(string text)
        {
            Info(FigletTransform.GetText(text, "ansi-shadow"));
            return DelegateDisposable.CreateBracket();
        }
    }
}
