// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.Unity.Logging
{
    internal class FileWatcher
    {
        private readonly string _file;
        private readonly Action<string> _processLineAction;
        private AutoResetEvent _logResetEvent;
        private FileSystemWatcher _fileSystemWatcher;
        private Thread _logReaderThread;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Encoding _encoding;

        public FileWatcher([NotNull] string file, Action<string> processLineAction, Encoding encoding = null)
        {
            _encoding = encoding ?? Encoding.UTF8;
            _file = file;
            _processLineAction = processLineAction;
        }

        public void Start()
        {
            _logResetEvent = new AutoResetEvent(initialState: false);
            _fileSystemWatcher = new FileSystemWatcher(Path.GetPathRoot(_file).NotNull())
                                 {
                                     Filter = Path.GetFileName(_file),
                                     EnableRaisingEvents = true,
                                     NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite
                                 };

            _fileSystemWatcher.Changed += (_, _) => _logResetEvent.Set();

            _cancellationTokenSource = new CancellationTokenSource();
            _logReaderThread = new Thread(ReadLogFile);
            _logReaderThread.Start();
        }

        public void AssertStopped()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Dispose();
            _fileSystemWatcher = null;
            _cancellationTokenSource.Cancel();
            while (_logReaderThread != null)
            {
                if (!_logReaderThread.IsAlive)
                    _logReaderThread = null;
                else
                    Thread.Sleep(millisecondsTimeout: 100);
            }
        }

        // ReSharper disable once CognitiveComplexity
        private void ReadLogFile()
        {
            while (!File.Exists(_file))
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;
                _logResetEvent.WaitOne(millisecondsTimeout: 100);
            }

            using var stream = new FileStream(_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new BinaryReader(stream, _encoding);

            var currentLine = "";
            while (true)
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var currentChar = reader.ReadChar();

                    if (currentChar == '\n')
                    {
                        _processLineAction?.Invoke(currentLine);
                        currentLine = "";
                    }
                    else
                        currentLine += currentChar;
                }

                if (_cancellationTokenSource.IsCancellationRequested)
                    break;
                _logResetEvent.WaitOne(millisecondsTimeout: 100);
            }
        }
    }
}
