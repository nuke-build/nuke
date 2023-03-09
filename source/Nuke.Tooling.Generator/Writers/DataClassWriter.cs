// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.CodeGeneration.Model;

namespace Nuke.CodeGeneration.Writers
{
    public class DataClassWriter : IWriterWrapper
    {
        public DataClassWriter(DataClass dataClass, ToolWriter writer)
        {
            DataClass = dataClass;
            Writer = writer;
        }

        public DataClass DataClass { get; }
        public IWriter Writer { get; }
    }
}
