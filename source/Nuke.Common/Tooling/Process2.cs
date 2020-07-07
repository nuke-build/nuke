// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Nuke.Common.Tooling
{
    public class Process2 : IProcess
    {
        private readonly Process _process;
        private readonly Func<string, string> _outputFilter;
        private readonly int? _timeout;
        private readonly StreamWriter _logStream;

        public Process2(Process process, Func<string, string> outputFilter, int? timeout, StreamWriter logStream, IReadOnlyCollection<Output> output)
        {
            _process = process;
            _outputFilter = outputFilter;
            _timeout = timeout;
            _logStream = logStream;
            Output = output;
        }

        public string FileName => _process.StartInfo.FileName;

        public string Arguments => _outputFilter.Invoke(_process.StartInfo.Arguments);

        public string WorkingDirectory => _process.StartInfo.WorkingDirectory;

        public IReadOnlyCollection<Output> Output { get; private set; }

        public int ExitCode => _process.ExitCode;

        public void Dispose()
        {
            _process.Dispose();
            _logStream?.Dispose();
        }

        public void Kill()
        {
            _process.Kill();
        }

        public bool WaitForExit()
        {
            // TODO: we are assuming that this method is called directly after process creation
            // use _process.StartTime
            var hasExited = _process.WaitForExit(_timeout ?? -1);
            if (!hasExited)
                _process.Kill();
            return hasExited;
        }
    }
}
