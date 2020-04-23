// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;

namespace Nuke.Common.Utilities
{
    public class CustomFileWriter : IDisposable
    {
        private readonly FileStream _fileStream;
        private readonly StreamWriter _streamWriter;
        private readonly int _indentationFactor;
        private readonly string _commentPrefix;
        private int _indentation;

        public CustomFileWriter(string filename, int indentationFactor, string commentPrefix, FileMode fileMode = FileMode.Create)
        {
            _fileStream = File.Open(filename, fileMode);
            _streamWriter = new StreamWriter(_fileStream);

            _indentationFactor = indentationFactor;
            _commentPrefix = commentPrefix;
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
            _fileStream.Dispose();
        }

        public void WriteLine(string text = null)
        {
            _streamWriter.WriteLine(
                text != null
                    ? $"{new string(c: ' ', _indentation * _indentationFactor)}{text}"
                    : string.Empty);
        }

        public void WriteComment(string text = null)
        {
            WriteLine($"{_commentPrefix} {text}".TrimEnd());
        }

        public void Write(Action<CustomFileWriter> writer)
        {
            writer(this);
        }

        public IDisposable Indent()
        {
            return DelegateDisposable.CreateBracket(
                () => _indentation++,
                () => _indentation--);
        }
    }
}
