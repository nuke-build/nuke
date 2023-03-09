// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.Common.Utilities;

namespace Nuke.CodeGeneration.Writers
{
    public class ToolWriter : IDisposable, IWriter, IWriterWrapper
    {
        private readonly StreamWriter _streamWriter;
        private int _indention;

        public ToolWriter(Tool tool, StreamWriter streamWriter)
        {
            Tool = tool;
            _streamWriter = streamWriter;
        }

        public Tool Tool { get; }
        public IWriter Writer => this;

        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        void IWriter.WriteLine(string text)
        {
            _streamWriter.WriteLine($"{' '.Repeat(_indention * 4)}{text}");
        }

        void IWriter.WriteBlock(Action action)
        {
            this.WriteLine("{");
            _indention++;
            action();
            _indention--;
            this.WriteLine("}");
        }
    }
}
