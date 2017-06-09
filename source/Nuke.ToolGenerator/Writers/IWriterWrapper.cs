using System;
using System.Linq;

namespace Nuke.ToolGenerator.Writers
{
    public interface IWriterWrapper
    {
        IWriter Writer { get; }
    }
}
