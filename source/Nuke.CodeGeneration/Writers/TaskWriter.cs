// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.CodeGeneration.Model;

namespace Nuke.CodeGeneration.Writers
{
    public class TaskWriter : IWriterWrapper
    {
        public TaskWriter(Task task, ToolWriter toolWriter)
        {
            Task = task;
            Writer = toolWriter;
        }

        public Task Task { get; }
        public IWriter Writer { get; }
    }
}
