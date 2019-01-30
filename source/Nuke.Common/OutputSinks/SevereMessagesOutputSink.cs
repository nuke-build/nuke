// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class SevereMessagesOutputSink : IOutputSink
    {
        private readonly IOutputSink _outputSink;
        private readonly List<Tuple<LogLevel, string>> _severeMessages;

        public SevereMessagesOutputSink(IOutputSink outputSink)
        {
            _outputSink = outputSink;
            _severeMessages = new List<Tuple<LogLevel, string>>();
        }

        public IReadOnlyList<Tuple<LogLevel, string>> SevereMessages => _severeMessages;

        public void WriteNormal(string text)
        {
            _outputSink.WriteNormal(text);
        }

        public IDisposable WriteBlock(string text)
        {
            return _outputSink.WriteBlock(text);
        }

        public void WriteTrace(string text)
        {
            _outputSink.WriteTrace(text);
        }

        public void WriteInformation(string text)
        {
            _outputSink.WriteInformation(text);
        }

        public void WriteWarning(string text, string details = null)
        {
            _severeMessages.Add(Tuple.Create(LogLevel.Warning, text));
            _outputSink.WriteWarning(text, details);
        }

        public void WriteError(string text, string details = null)
        {
            _severeMessages.Add(Tuple.Create(LogLevel.Error, text));
            _outputSink.WriteError(text, details);
        }

        public void WriteSuccess(string text)
        {
            _outputSink.WriteSuccess(text);
        }
    }
}
