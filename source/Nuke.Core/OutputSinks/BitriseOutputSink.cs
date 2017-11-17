﻿// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.BuildServers;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    public class BitriseOutputSink : ConsoleOutputSink
    {
        [CanBeNull]
        public new static IOutputSink Instance { get; } = Bitrise.Instance != null ? new BitriseOutputSink() : null;

        public override IDisposable WriteBlock (string text)
        {
            Info(FigletTransform.GetText(text, "ansi-shadow"));
            return DelegateDisposable.CreateBracket();
        }
    }
}
