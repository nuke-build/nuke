using System;
using System.Linq;
using Nuke.ToolGenerator.Model;

namespace Nuke.ToolGenerator.Writers
{
    public class DataClassWriter : IWriterWrapper
    {
        public DataClassWriter (DataClass dataClass, ToolWriter writer)
        {
            Tool = writer.Tool;
            DataClass = dataClass;
            Writer = writer;
        }

        public Tool Tool { get; }
        public DataClass DataClass { get; }
        public IWriter Writer { get; }
    }
}
