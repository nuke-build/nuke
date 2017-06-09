using System;
using System.Linq;
using Nuke.ToolGenerator.Model;

namespace Nuke.ToolGenerator.Writers
{
    public class AliasWriter : IWriterWrapper
    {
        public AliasWriter (Alias alias, ToolWriter toolWriter)
        {
            Tool = toolWriter.Tool;
            Alias = alias;
            Writer = toolWriter;
        }

        public Tool Tool { get; }
        public Alias Alias { get; }
        public IWriter Writer { get; }
    }
}
