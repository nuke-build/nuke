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

        public void Write(string text)
        {
            _outputSink.Write(text);
        }

        public IDisposable WriteBlock(string text)
        {
            return _outputSink.WriteBlock(text);
        }

        public void Trace(string text)
        {
            _outputSink.Trace(text);
        }

        public void Info(string text)
        {
            _outputSink.Info(text);
        }

        public void Warn(string text, string details = null)
        {
            _severeMessages.Add(Tuple.Create(LogLevel.Warning, text));
            _outputSink.Warn(text, details);
        }

        public void Error(string text, string details = null)
        {
            _severeMessages.Add(Tuple.Create(LogLevel.Error, text));
            _outputSink.Error(text, details);
        }

        public void Success(string text)
        {
            _outputSink.Success(text);
        }
    }
}
