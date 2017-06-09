using System;
using System.Linq;

namespace Nuke.ToolGenerator.Writers
{
    public interface IWriter
    {
        void WriteLine (string text);
        void WriteBlock (Action action);
    }
}
