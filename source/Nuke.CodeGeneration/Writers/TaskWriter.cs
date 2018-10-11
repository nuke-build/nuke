// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Generators;
using Nuke.CodeGeneration.Model;
using Nuke.Common.Utilities;

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
