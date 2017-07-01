using System;
using System.Linq;
using Nuke.ToolGenerator.Model;

namespace Nuke.ToolGenerator.Writers
{
    public class TaskWriter : IWriterWrapper
    {
        public TaskWriter (Task task, ToolWriter toolWriter)
        {
            Task = task;
            Writer = toolWriter;
        }

        public Task Task { get; }
        public IWriter Writer { get; }
    }
}
