// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.OutputSinks
{
    public interface IOutputSink
    {
        void Write(string text);
        IDisposable WriteBlock(string text);

        void Trace(string text);
        void Info(string text);
        void Warn(string text, string details = null);
        void Error(string text, string details = null);
        void Success(string text);
    }
}
