// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;

namespace Nuke.Common.CI.AppVeyor
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class AppVeyorOutputSink : AnsiColorOutputSink
    {
        internal AppVeyorOutputSink()
            : base(
                traceCode: "90",
                informationCode: "36;1",
                warningCode: "33;1",
                errorCode: "31;1",
                successCode: "32;1")
        {
        }
    }
}
