// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    public class Process2 : IProcess
    {
        private readonly Process _process;
        private readonly int? _timeout;

        [CanBeNull]
        private readonly BlockingCollection<Output> _output;

        private readonly Func<string, string> _outputFilter;

        public Process2(Process process, int? timeout, [CanBeNull] BlockingCollection<Output> output, Func<string, string> outputFilter)
        {
            _process = process;
            _timeout = timeout;
            _output = output;
            _outputFilter = outputFilter;
        }

        public string FileName => _process.StartInfo.FileName;

        public string Arguments => _outputFilter(_process.StartInfo.Arguments);

        public string WorkingDirectory => _process.StartInfo.WorkingDirectory;

        public IEnumerable<Output> Output
        {
            get
            {
                ControlFlow.Assert(_output != null, "_output != null");
                ControlFlow.Assert(_process.HasExited, "_process.HasExited");
                return _output.Select(x => new Output { Type = x.Type, Text = _outputFilter(x.Text) });
            }
        }

        public int ExitCode => _process.ExitCode;

        public void Dispose()
        {
            _process.Dispose();
        }

        public void Kill()
        {
            _process.Kill();
        }

        public bool WaitForExit()
        {
            var hasExited = _process.WaitForExit(_timeout ?? -1);
            if (!hasExited)
                _process.Kill();
            return hasExited;
        }
    }
}
