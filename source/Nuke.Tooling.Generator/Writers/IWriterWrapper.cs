// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.CodeGeneration.Writers
{
    public interface IWriterWrapper
    {
        IWriter Writer { get; }
    }
}
