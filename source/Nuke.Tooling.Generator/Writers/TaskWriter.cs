// Copyright 2023 Maintainers of NUKE.
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
