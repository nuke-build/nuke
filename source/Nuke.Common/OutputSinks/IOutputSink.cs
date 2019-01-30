// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.OutputSinks
{
    public interface IOutputSink
    {
        IDisposable WriteBlock(string text);

        void WriteNormal(string text);
        void WriteTrace(string text);
        void WriteInformation(string text);
        void WriteWarning(string text, string details = null);
        void WriteError(string text, string details = null);
        void WriteSuccess(string text);
    }
}
