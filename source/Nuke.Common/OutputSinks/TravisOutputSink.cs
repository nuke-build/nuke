// Copyright 2019 Maintainers of NUKE.
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
    internal class TravisOutputSink : ConsoleOutputSink
    {
        public override IDisposable WriteBlock(string text)
        {
            Info(FigletTransform.GetText(text));

            return DelegateDisposable.CreateBracket(
                () => Write($"travis_fold:start:{text}"),
                () => Write($"travis_fold:end:{text}"));
        }
    }
}
